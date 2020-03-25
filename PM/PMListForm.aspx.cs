using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClaimProject.Config;
using MySql.Data.MySqlClient;
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
using System.Drawing;
//using ClaimProject.PM.Report;

namespace ClaimProject.PM
{
    public partial class PMListForm : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public string[] todayy = DateTime.Today.ToString("dd-MM-yyyy").Split('-');
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                function.getListItem(PMSearchCpoint, "SELECT *  FROM tbl_cpoint c ORDER by c.cpoint_id ", "cpoint_name", "cpoint_id");
                function.getListItem(PMSearchStat, "SELECT * FROM tbl_pm_status ORDER BY tbl_pm_status.pm_status_id ", "pm_status_name", "pm_status_id");
                function.getListItem(PMSearchProj, "SELECT * FROM tbl_project ","project_name","project_id");
                function.getListItem(PMSearchBudget, "SELECT pm_budget_year FROM tbl_pm_detail Group By pm_budget_year Order By pm_budget_year DESC ", "pm_budget_year", "pm_budget_year");
                PMSearchStat.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                PMSearchProj.Items.Insert(0, new ListItem("ทั้งหมด", ""));

                string sql = "";
                if (Session["UserCpoint"] != null)
                {
                    if (Session["UserCpoint"].ToString() == "0")
                    {
                        sql = "SELECT * FROM tbl_cpoint ORDER BY cpoint_id";
                        function.getListItem(PMSearchCpoint, sql, "cpoint_name", "cpoint_id");
                        PMSearchCpoint.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                    }
                    else
                    {
                        btnNewPM.Visible = true;
                        sql = "SELECT * FROM tbl_cpoint WHERE cpoint_id = '" + Session["UserCpoint"].ToString() + "'";
                        function.getListItem(PMSearchCpoint, sql, "cpoint_name", "cpoint_id");
                    }
                }
                else
                {
                    Response.Redirect("/");
                }
                BindData();

            }
        }

        void BindData() //สำหรับค้นทั้งหมด
        {

            string PMcpoint = PMSearchCpoint.SelectedValue;
            string PMRef = PMSearchRef.Text;
            string PMTopic = PMSearchProj.Text;
            string PMStatus = PMSearchStat.SelectedValue;
            string sqlx = "";

            if (Session["UserPrivilegeId"].ToString() != "0" && Session["UserPrivilegeId"].ToString() != "1") //สำหรับด่านจะแสดงสถานะรอดำเนินการขึ้นมาก่อน
            {
                sqlx = "SELECT * FROM tbl_pm_detail  "
                    + " JOIN tbl_pm_status ON tbl_pm_status.pm_status_id = tbl_pm_detail.pm_status_id "
                    + " JOIN tbl_toll ON tbl_toll.toll_id = tbl_pm_detail.pm_toll_id "
                    + " JOIN tbl_project ON tbl_project.project_id = tbl_pm_detail.project_id "
                    + " JOIN tbl_company ON tbl_company.company_id = tbl_pm_detail.pm_company_id  "
                    + "  JOIN tbl_user ON tbl_user.username = tbl_pm_detail.pm_who_create "
                    + " WHERE tbl_toll.cpoint_id ='" + Session["UserCpoint"].ToString() + "' "
                    + " ORDER BY tbl_pm_detail.pm_status_id ASC " ;

                MySqlDataAdapter da = function.MySqlSelectDataSet(sqlx);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds);
                PMListGridview.DataSource = ds.Tables[0];
                PMListGridview.DataBind();
                lbPMNull.Text = "พบข้อมูลจำนวน " + ds.Tables[0].Rows.Count + " แถว";

            }
            else  //สำหรับแอดมินตรวจสอบจะเริ่มแสดงแต่สถานะรอตรวจสอบ
            {
                sqlx = "SELECT * FROM tbl_pm_detail  "
                    + " JOIN tbl_pm_status ON tbl_pm_status.pm_status_id = tbl_pm_detail.pm_status_id "
                    + " JOIN tbl_toll ON tbl_toll.toll_id = tbl_pm_detail.pm_toll_id "
                    + " JOIN tbl_project ON tbl_project.project_id = tbl_pm_detail.project_id "
                    + " JOIN tbl_company ON tbl_company.company_id = tbl_pm_detail.pm_company_id  "
                    + " JOIN tbl_user ON tbl_user.username = tbl_pm_detail.pm_who_create "
                    + " WHERE tbl_pm_detail.pm_status_id = '2' OR tbl_pm_detail.pm_status_id = '3'  ORDER BY tbl_pm_detail.pm_status_id ASC ";

                MySqlDataAdapter da = function.MySqlSelectDataSet(sqlx);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds);
                PMListGridview.DataSource = ds.Tables[0];
                PMListGridview.DataBind();
                lbPMNull.Text = "พบข้อมูลจำนวน " + ds.Tables[0].Rows.Count + " แถว";
            }

        }


        protected void btnNewPM_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PM/PMMainForm.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string PMcpoint = PMSearchCpoint.SelectedValue;
            string PMStatus = PMSearchStat.SelectedValue;
            string PMRef = PMSearchRef.Text;
            string PMProj = PMSearchProj.SelectedValue;
            string PMBudget = PMSearchBudget.SelectedItem.ToString();
            string sqly = "SELECT * FROM tbl_pm_detail  "
                    + " JOIN tbl_pm_status ON tbl_pm_status.pm_status_id = tbl_pm_detail.pm_status_id "
                    + " JOIN tbl_toll ON tbl_toll.toll_id = tbl_pm_detail.pm_toll_id "
                    + " JOIN tbl_project ON tbl_project.project_id = tbl_pm_detail.project_id "
                    + " JOIN tbl_company ON tbl_company.company_id = tbl_pm_detail.pm_company_id  "
                    + " JOIN tbl_user ON tbl_user.username = tbl_pm_detail.pm_who_create " ;
            SearchArea.Visible = false;
            btnSearch.Visible = false;
            btnNewSearch.Visible = true;

            
            if (PMRef != "") //Have Ref
            {
                if (PMcpoint == "")//All cpoint 
                {
                    if(PMProj == "") //All Project
                    {
                        if(PMStatus == "") //1.(Ref:AllCpoint:AllProj:AllStat)
                        {
                            sqly += " WHERE tbl_pm_detail.pm_ref_no LIKE '%" + PMRef + "%'"
                                    + " AND tbl_pm_detail.pm_budget_year = '" + PMBudget + "'"
                                    + " AND tbl_pm_detail.pm_delete = '0'"
                                    + " ORDER BY tbl_pm_detail.pm_status_id ASC " ;
                        }
                        else //2.(Ref:AllCpoint:AllProj:Stat)
                        {
                            sqly += " WHERE tbl_pm_detail.pm_ref_no LIKE '%" + PMRef + "%'"
                                    + " AND tbl_pm_detail.pm_status_id = '"+PMStatus+ "'"
                                    + " AND tbl_pm_detail.pm_budget_year = '" + PMBudget + "'"
                                    + " AND tbl_pm_detail.pm_delete = '0'"
                                    + " ORDER BY tbl_pm_detail.pm_status_id ASC ";
                        }
                    }
                    else //Project
                    {
                        if (PMStatus == "") //3.(Ref:AllCpoint:Proj:AllStat)
                        {
                            sqly += " WHERE tbl_pm_detail.pm_ref_no LIKE '%" + PMRef + "%'"
                                    + " AND tbl_pm_detail.project_id = '"+PMProj+ "'"
                                    + " AND tbl_pm_detail.pm_budget_year = '" + PMBudget + "'"
                                    + " AND tbl_pm_detail.pm_delete = '0'"
                                    + " ORDER BY tbl_pm_detail.pm_status_id ASC ";
                        }
                        else//4.(Ref:AllCpoint:Proj:Stat)
                        {
                            sqly += " WHERE tbl_pm_detail.pm_ref_no LIKE '%" + PMRef + "%'"
                                    + " AND tbl_pm_detail.project_id = '" + PMProj + "'"
                                    + " AND tbl_pm_detail.pm_status_id = '" + PMStatus + "'"
                                    + " AND tbl_pm_detail.pm_budget_year = '" + PMBudget + "'"
                                    + " AND tbl_pm_detail.pm_delete = '0'"
                                    + " ORDER BY tbl_pm_detail.pm_status_id ASC ";
                        }
                    }
                }
                else // cpoint
                {
                    if (PMProj == "") //All proj
                    {
                        if (PMStatus == "") //5.(Ref:Cpoint:AllProj:AllStat)
                        {
                            sqly += " WHERE tbl_pm_detail.pm_ref_no LIKE '%" + PMRef + "%'"
                                    + " AND tbl_toll.cpoint_id = '" + PMcpoint + "'"
                                    + " AND tbl_pm_detail.pm_budget_year = '" + PMBudget + "'"
                                    + " AND tbl_pm_detail.pm_delete = '0'"
                                    + " ORDER BY tbl_pm_detail.pm_status_id ASC ";
                        }
                        else//6. (Ref:Cpoint:AllProj:Stat)
                        {
                            sqly += " WHERE tbl_pm_detail.pm_ref_no LIKE '%" + PMRef + "%'"
                                    + " AND tbl_toll.cpoint_id = '" + PMcpoint + "'"
                                    + " AND tbl_pm_detail.pm_budget_year = '" + PMBudget + "'"
                                    + " AND tbl_pm_detail.pm_status_id = '" + PMStatus + "'"
                                    + " AND tbl_pm_detail.pm_delete = '0'"
                                    + " ORDER BY tbl_pm_detail.pm_status_id ASC ";
                        }
                    }
                    else //Project
                    {
                        if (PMStatus == "") //7. (Ref:Cpoint:Proj:AllStat)
                        {
                            sqly += " WHERE tbl_pm_detail.pm_ref_no LIKE '%" + PMRef + "%'"
                                    + " AND tbl_toll.cpoint_id = '" + PMcpoint + "'"
                                    + " AND tbl_pm_detail.pm_budget_year = '" + PMBudget + "'"
                                    + " AND tbl_pm_detail.project_id = '" + PMProj + "'"
                                    + " AND tbl_pm_detail.pm_delete = '0'"
                                    + " ORDER BY tbl_pm_detail.pm_status_id ASC ";
                        }
                        else //8. (Ref:Cpoint:Proj:Stat)
                        {
                            sqly += " WHERE tbl_pm_detail.pm_ref_no LIKE '%" + PMRef + "%'"
                                    + " AND tbl_toll.cpoint_id = '" + PMcpoint + "'"
                                    + " AND tbl_pm_detail.pm_budget_year = '" + PMBudget + "'"
                                    + " AND tbl_pm_detail.project_id = '" + PMProj + "'"
                                    + " AND tbl_pm_detail.pm_status_id = '" + PMStatus + "'"
                                    + " AND tbl_pm_detail.pm_delete = '0'"
                                    + " ORDER BY tbl_pm_detail.pm_status_id ASC ";
                        }
                    }
                }

            }
            else  //Not Ref
            {
                if (PMcpoint == "")// All cpoint
                {
                    if (PMProj == "") // All Project
                    {
                        if (PMStatus == "") //9. (NotRef:AllCpoint:AllProj:AllStat)
                        {
                            sqly += " WHERE tbl_pm_detail.pm_delete = '0' "
                                    + " ORDER BY tbl_pm_detail.pm_status_id ASC ";
                        }
                        else //10. (NotRef:AllCpoint:AllProj:Stat)
                        {
                            sqly += " WHERE tbl_pm_detail.pm_delete = '0' "
                                    + " AND tbl_pm_detail.pm_status_id = '" + PMStatus + "'"
                                    + " AND tbl_pm_detail.pm_budget_year = '" + PMBudget + "'"
                                    + " ORDER BY tbl_pm_detail.pm_status_id ASC ";
                        }
                    }
                    else // Project
                    {
                        if (PMStatus == "") //11. (NotRef:AllCpoint:Proj:AllStat)
                        {
                            sqly += " WHERE tbl_pm_detail.pm_delete = '0' "
                                    + " AND tbl_pm_detail.project_id = '" + PMProj + "'"
                                    + " AND tbl_pm_detail.pm_budget_year = '" + PMBudget + "'"
                                    + " ORDER BY tbl_pm_detail.pm_status_id ASC ";
                        }
                        else //12. (NotRef:AllCpoint:AllProj:Stat)
                        {
                            sqly += " WHERE tbl_pm_detail.pm_delete = '0' "
                                    + " AND tbl_pm_detail.pm_budget_year = '" + PMBudget + "'"
                                    + " AND tbl_pm_detail.pm_status_id = '" + PMStatus + "'"
                                    + " ORDER BY tbl_pm_detail.pm_status_id ASC ";
                        }
                    }
                }
                else// Cpoint
                {
                    if (PMProj == "") //All Proj
                    {
                        if (PMStatus == "") //13. (NotRef:Cpoint:AllProj:AllStat)
                        {
                            sqly += " WHERE tbl_pm_detail.pm_delete = '0' "
                                    + " AND tbl_toll.cpoint_id = '" + PMcpoint + "'"
                                    + " AND tbl_pm_detail.pm_budget_year = '" + PMBudget + "'"
                                    + " ORDER BY tbl_pm_detail.pm_status_id ASC ";
                        }
                        else //14. (NotRef:Cpoint:AllProj:Stat)
                        {
                            sqly += " WHERE tbl_pm_detail.pm_delete = '0' "
                                    + " AND tbl_toll.cpoint_id = '" + PMcpoint + "'"
                                    + " AND tbl_pm_detail.pm_budget_year = '" + PMBudget + "'"
                                    + " AND tbl_pm_detail.pm_status_id = '" + PMStatus + "'"
                                    + " ORDER BY tbl_pm_detail.pm_status_id ASC ";
                        }
                    }
                    else // Project
                    {
                        if (PMStatus == "") //15. (NotRef:Cpoint:Proj:AllStat)
                        {
                            sqly += " WHERE tbl_pm_detail.pm_delete = '0' "
                                    + " AND tbl_toll.cpoint_id = '" + PMcpoint + "'"
                                    + " AND tbl_pm_detail.pm_budget_year = '" + PMBudget + "'"
                                    + " AND tbl_pm_detail.project_id = '" + PMProj + "'"
                                    + " ORDER BY tbl_pm_detail.pm_status_id ASC ";
                        }
                        else //16. (NotRef:Cpoint:Proj:Stat)
                        {
                            sqly += " WHERE tbl_pm_detail.pm_delete = '0' "
                                    + " AND tbl_toll.cpoint_id = '" + PMcpoint + "'"
                                    + " AND tbl_pm_detail.pm_budget_year = '" + PMBudget + "'"
                                    + " AND tbl_pm_detail.project_id = '" + PMProj + "'"
                                    + " AND tbl_pm_detail.pm_status_id = '" + PMStatus + "'"
                                    + " ORDER BY tbl_pm_detail.pm_status_id ASC ";
                        }
                    }
                }
            }

            MySqlDataAdapter da = function.MySqlSelectDataSet(sqly);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            PMListGridview.DataSource = ds.Tables[0];
            PMListGridview.DataBind();
            lbPMNull.Text = "พบข้อมูลจำนวน " + ds.Tables[0].Rows.Count + " แถว";
            lbSearchResult.Text = "ผลการค้นหารายการ PM  --->  ด่านฯ: ("+ PMSearchCpoint.SelectedItem + ") , รายการ: ("+ PMSearchProj.SelectedItem+ ") , เลขอ้างอิง: ("+ PMSearchRef.Text+ ") , สถานะ: ("+ PMSearchStat.SelectedItem + ") , ปีงบประมาณ: ("+ PMSearchBudget.SelectedItem+ ") ";

        }
        public int GetMonthValue(string mm )
        {
            string[] MonthSub = mm.Split(' ');
            int MonthValue = 0 ;
            switch (MonthSub[1])
            {
                case "ม.ค.":
                    MonthValue = 1;
                    break;
                case "ก.พ.":
                    MonthValue = 2;
                    break;
                case "มี.ค.":
                    MonthValue = 3;
                    break;
                case "เม.ย.":
                    MonthValue = 4;
                    break;
                case "พ.ค.":
                    MonthValue = 5;
                    break;
                case "มิ.ย.":
                    MonthValue = 6;
                    break;
                case "ก.ค.":
                    MonthValue = 7;
                    break;
                case "ส.ค.":
                    MonthValue = 8;
                    break;
                case "ก.ย.":
                    MonthValue = 9;
                    break;
                case "ต.ค.":
                    MonthValue = 10;
                    break;
                case "พ.ย.":
                    MonthValue = 11;
                    break;
                case "ธ.ค.":
                    MonthValue = 12;
                    break;
            }

            return MonthValue;
        }
        protected void PMListGridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            Label lbPMACTSDate = (Label)(e.Row.FindControl("lbPMACTSDate"));
            if (lbPMACTSDate != null)
            {
               lbPMACTSDate.Text = function.ConvertDateShortThai((string)DataBinder.Eval(e.Row.DataItem, "pm_act_sdate"));
            }

            Label lbPMStat = (Label)(e.Row.FindControl("lbPMStat"));
            if (lbPMStat != null)
            {
                lbPMStat.CssClass = "badge badge-" + (string)DataBinder.Eval(e.Row.DataItem, "pm_status_alert");  
                if(lbPMStat.Text == "รอตรวจสอบ") { lbPMStat.ToolTip = "รอแอดมินตรวจสอบการแจ้งPM"; }
                else if (lbPMStat.Text == "กำลังส่งใบเซอร์วิส") { lbPMStat.ToolTip = "รอเทียบระบบกับใบเซอร์วิส"; }
                else if (lbPMStat.Text == "ตรวจสอบเรียบร้อย") { lbPMStat.ToolTip = "ระบบกับใบเซอร์วิสตรงกัน"; } 
            }

            LinkButton lbtnPMRef = (LinkButton)(e.Row.FindControl("lbtnPMRef"));
            if (lbtnPMRef != null)
            {
                lbtnPMRef.CommandName = (string)DataBinder.Eval(e.Row.DataItem, "pm_ref_no").ToString();
            }

            LinkButton lbtnCpoint = (LinkButton)(e.Row.FindControl("lbtnCpoint"));
            if (lbtnCpoint != null)
            {
                lbtnCpoint.CommandName = (string)DataBinder.Eval(e.Row.DataItem, "pm_ref_no").ToString();
            }

            LinkButton lbPMCorporate = (LinkButton)(e.Row.FindControl("lbPMCorporate"));
            if (lbPMCorporate != null)
            {
                lbPMCorporate.CommandName = (string)DataBinder.Eval(e.Row.DataItem, "pm_ref_no").ToString();
            }

            LinkButton lbtnPMList = (LinkButton)(e.Row.FindControl("lbtnPMList"));
            if (lbtnPMList != null)
            {
                lbtnPMList.CommandName = (string)DataBinder.Eval(e.Row.DataItem, "pm_ref_no").ToString();
            }

            LinkButton lbtnRefNo = (LinkButton)(e.Row.FindControl("lbtnRefNo"));
            if (lbtnRefNo != null)
            {
                if (lbPMStat.Text != "รอบริษัทเข้าPM")
                {
                    lbtnRefNo.Visible = true;
                    lbtnRefNo.CommandName = (string)DataBinder.Eval(e.Row.DataItem, "pm_ref_no").ToString();
                }
                else
                {
                    lbtnRefNo.Visible = false;
                }
            }

        }

        protected void lbtnPMRef_Command(object sender, CommandEventArgs e)
        {
            Session["codePKPM"] = e.CommandName;
            Session["View"] = false;
            //string PmStat = function.GetSelectValue("tbl_pm_detail", "pm_ref_no='" + e.CommandName + "'", "pm_status_id");
            Response.Redirect("PMDetailForm.aspx");
        }
        protected void PMListGridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PMListGridview.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void btnNewSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PM/PMListForm.aspx");
            btnNewSearch.Visible = false;
            btnSearch.Visible = true;
            lbSearchResult.Text = "";
        }
    }
}