using System;
using ClaimProject.Config;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace ClaimProject.PM
{
    public partial class PMMainForm : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public string[] todayMain = DateTime.Today.ToString("dd-MM-yyyy").Split('-');
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/");
            }
            if (!this.IsPostBack)
            {
                string sql = "";
                string projectSQL = " SELECT * FROM tbl_project ORDER BY project_id ASC ";
                if (function.CheckLevel("Department", Session["UserPrivilegeId"].ToString()))
                {
                    sql = "SELECT * FROM tbl_toll ORDER BY toll_id ASC";
                }
                else
                {
                    sql = "SELECT * FROM tbl_toll WHERE cpoint_id = '" + Session["UserCpoint"].ToString() + "'";
                }

                function.getListItem(DDLProject, projectSQL, "project_name", "project_id");
                DDLProject.Items.Insert(0, new ListItem("<กรุณาเลือกโครงการ>", ""));
                function.getListItem(txtPMCpoint, sql, "toll_name", "toll_id");
                BindDataLeave();
            }
        }

        public string CalMonth (string month)
        {
            switch (month)
            {
                case "01": month = "มกราคม"; break;
                case "02": month = "กุมภาพันธ์"; break;
                case "03": month = "มีนาคม"; break;
                case "04": month = "เมษายน"; break;
                case "05": month = "พฤษภาคม"; break;
                case "06": month = "มิถุนายน"; break;
                case "07": month = "กรกฎาคม"; break;
                case "08": month = "สิงหาคม"; break;
                case "09": month = "กันยายน"; break;
                case "10": month = "ตุลาคม"; break;
                case "11": month = "พฤศจิกายน"; break;
                case "12": month = "ธันวาคม"; break;
            }
            return month;
        }

        public void BindDataLeave()
        {
            string sqlBind = "";
            if(Session["UserPrivilegeId"].ToString() == "2" )
            {
                sqlBind = " SELECT * FROM tbl_pm_detail "
                      + "  JOIN tbl_pm_status ON tbl_pm_status.pm_status_id = tbl_pm_detail.pm_status_id "
                      + "  JOIN tbl_toll ON tbl_toll.toll_id = tbl_pm_detail.pm_toll_id "
                      + "  JOIN tbl_project ON tbl_project.project_id = tbl_pm_detail.project_id "
                      + "  JOIN tbl_company ON tbl_company.company_id = tbl_pm_detail.pm_company_id "
                      + "  JOIN tbl_user ON tbl_user.username = tbl_pm_detail.pm_who_create "
                      + "  WHERE tbl_pm_detail.pm_status_id = '1' AND tbl_toll.cpoint_id = '" + Session["UserCpoint"].ToString() + "'  GROUP BY tbl_pm_detail.pm_ref_no  ORDER BY tbl_pm_detail.pm_ref_no DESC ";
            }
            else
            {
                sqlBind = " SELECT * FROM tbl_pm_detail "
                      + "  JOIN tbl_pm_status ON tbl_pm_status.pm_status_id = tbl_pm_detail.pm_status_id "
                      + "  JOIN tbl_toll ON tbl_toll.toll_id = tbl_pm_detail.pm_toll_id "
                      + "  JOIN tbl_project ON tbl_project.project_id = tbl_pm_detail.project_id "
                      + "  JOIN tbl_company ON tbl_company.company_id = tbl_pm_detail.pm_company_id "
                      + "  JOIN tbl_user ON tbl_user.username = tbl_pm_detail.pm_who_create "
                      + "  WHERE tbl_pm_detail.pm_status_id = '1' GROUP BY tbl_pm_detail.pm_ref_no  ORDER BY tbl_pm_detail.pm_ref_no  DESC  ";
            }
            
                MySqlDataAdapter da = function.MySqlSelectDataSet(sqlBind);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds);
                PMListEdit.DataSource = ds.Tables[0];
                PMListEdit.DataBind();
                lbAmount.Text = "พบข้อมูลจำนวน " + ds.Tables[0].Rows.Count + " แถว";

        }
        public string SortDate(string getdate)
        {
            string sorted = "";

            return sorted;
        }

        protected void PMListEdit_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton lbtnUpdate = (LinkButton)(e.Row.FindControl("lbtnUpdate"));
            if (lbtnUpdate != null)
            {
                lbtnUpdate.CommandName = (string)DataBinder.Eval(e.Row.DataItem, "pm_ref_no").ToString();
            }
            Label lbPMStat = (Label)(e.Row.FindControl("lbPMStat"));
            if (lbPMStat != null)
            {
                lbPMStat.CssClass = "badge badge-" + (string)DataBinder.Eval(e.Row.DataItem, "pm_status_alert");
            }

        }

        protected void btnAddPM_Click(object sender, EventArgs e)
        {
            string PMCpoint = txtPMCpoint.Text;
            string nowAdd = DateTime.Now.ToString("HH.mm") ;
            string todayDate = todayMain[0] + "-" + todayMain[1] + "-" + (int.Parse(todayMain[2]) + 543).ToString();
            string budget = function.getBudgetYear(todayDate);
            string AddPMSql = "INSERT INTO tbl_pm_detail (pm_budget_year, pm_create_date, pm_delete, pm_status_id, pm_act_sdate, pm_toll_id, pm_detail_title, project_id, pm_company_id, pm_who_create, pm_create_time  ) " +
                " VALUES ('"+budget+"','"+ todayDate +"','0','1','-','"+ txtPMCpoint.SelectedValue+ "','"+ DDLProject.SelectedItem + "','" + DDLProject.SelectedValue + "','" + ddlCoporate.SelectedValue + "','"+Session["User"].ToString()+ "', '"+nowAdd+"' )";
            if (function.MySqlQuery(AddPMSql))
            {
                
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('กรุณาใส่ข้อมูลให้ครบถ้วน')", true);
            }
            BindDataLeave();
            function.Close(); 
        }

        protected void btnGotoPMList_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PM/PMListForm.aspx");
        }

        protected void DDLProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlcompany = "SELECT * FROM tbl_company ";
            
            if(DDLProject.SelectedValue == "")
            {
                divCompany.Visible = false;
                divBtnAdd.Visible = false;
            }
            if (DDLProject.SelectedValue == "1")
            {
                divCompany.Visible = true;
                divBtnAdd.Visible = true;
                sqlcompany += " WHERE project_group LIKE '%MA%'";
                function.getListItem(ddlCoporate, sqlcompany, "company_name", "company_id");
            }
            else if(DDLProject.SelectedValue == "2")
            {
                divCompany.Visible = true;
                divBtnAdd.Visible = true;
                sqlcompany += " WHERE company_id = '16' ";
                function.getListItem(ddlCoporate, sqlcompany, "company_name", "company_id");
            }
            else if(DDLProject.SelectedValue == "3")
            {
                divCompany.Visible = true;
                divBtnAdd.Visible = true;
                sqlcompany += " WHERE company_id = '17' ";
                function.getListItem(ddlCoporate, sqlcompany, "company_name", "company_id");
            }
            else if (DDLProject.SelectedValue == "4")
            {
                divCompany.Visible = true;
                divBtnAdd.Visible = true;
                sqlcompany += " WHERE company_id = '18' ";
                function.getListItem(ddlCoporate, sqlcompany, "company_name", "company_id");
            }

        }

        protected void lbtnUpdate_Command(object sender, CommandEventArgs e)
        {
            Session["codePKPM"] = e.CommandName;
            Response.Redirect("PMDetailForm.aspx");
        }
    }
}