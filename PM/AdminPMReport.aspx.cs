using ClaimProject.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using ClaimProject.PM.Report;
using CrystalDecisions.CrystalReports.Engine;
using System.Globalization;

namespace ClaimProject.PM
{
    public partial class AdminPMReport : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        string StartD = "";
        string EndD = "";
        string SQLWhere = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                /*DateTime ddd = DateTime.ParseExact("28-03-2019", "dd-MM-yyyy", CultureInfo.InvariantCulture);
                //string[] DateInRecord = ddd.Split('-');
                DateTime TimeInRecord = DateTime.ParseExact("28-03-2019", "dd-MM-yyyy", CultureInfo.InvariantCulture);
                DateTime today = DateTime.Today;

                DateDifference diff = new DateDifference(ddd, TimeInRecord);
                checksomthing.Text = diff.ToString();*/

                //GridViewAllbyBudget
                DateTime myDateTime = DateTime.Now;
                string lastYear = (int.Parse(myDateTime.Year.ToString()) + 543).ToString();
                int calculateYear = int.Parse(lastYear);
                rbtBudget.Checked = true;
                rbtBudget_CheckedChanged(null, null);
                string getCpointName = "SELECT * FROM tbl_cpoint Order by cpoint_id ASC";
                function.getListItem(txtStation, getCpointName, "cpoint_name", "cpoint_id");
                //เพิ่มไอเทมให้เลือกในดรอบดาว  (ตำแหน่ง , สร้างใหม่(ชื่ออะไร,values))
                txtStation.Items.Insert(0, new System.Web.UI.WebControls.ListItem("ทั้งหมด", ""));
                function.getListItem(txtBudgetYear, "SELECT pm_budget_year FROM tbl_pm_detail  GROUP BY pm_budget_year DESC", "pm_budget_year", "pm_budget_year");
                ddlThaiYear.Items.Insert(0, new System.Web.UI.WebControls.ListItem(lastYear, lastYear));
                ddlThaiYear.Items.Insert(1, new System.Web.UI.WebControls.ListItem((calculateYear - 1).ToString(), (calculateYear - 1).ToString()));
                ddlThaiYear.Items.Insert(2, new System.Web.UI.WebControls.ListItem((calculateYear - 2).ToString(), (calculateYear - 2).ToString()));
                ddlThaiYear.Items.Insert(3, new System.Web.UI.WebControls.ListItem((calculateYear - 3).ToString(), (calculateYear - 3).ToString()));
                
            }
        }

        protected void rbtBudget_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtBudget.Checked == true)
            {
                lbBudget.Visible = true;
                lbStartDate.Visible = false;
                lbEndDate.Visible = false;
                txtStartDate.Visible = false;
                txtEndDate.Visible = false;
                txtBudgetYear.Visible = true;
                btnResult.Visible = true;
                Label1.Visible = false;
                ddlThaiYear.Visible = false;
                Label2.Visible = false;
                ddlMonth.Visible = false;
            }
            else if (rbtDuration.Checked == true)
            {
                lbStartDate.Visible = true;
                lbEndDate.Visible = true;

                lbBudget.Visible = false;

                txtBudgetYear.Visible = false;
                txtStartDate.Visible = true;
                txtEndDate.Visible = true;
                btnResult.Visible = true;

                Label1.Visible = false;
                ddlThaiYear.Visible = false;
                Label2.Visible = false;
                ddlMonth.Visible = false;
            }
            else if (rbtMonth.Checked == true)
            {
                Label1.Visible = true;
                ddlThaiYear.Visible = true;
                Label2.Visible = true;
                ddlMonth.Visible = true;
                btnResult.Visible = true;
                txtBudgetYear.Visible = false;
                lbStartDate.Visible = false;
                lbEndDate.Visible = false;
                txtStartDate.Visible = false;
                txtEndDate.Visible = false;
                lbBudget.Visible = false;
            }

        }
        protected void rbtDuration_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtBudget.Checked == true)
            {
                lbBudget.Visible = true;
                lbStartDate.Visible = false;
                lbEndDate.Visible = false;
                txtStartDate.Visible = false;
                txtEndDate.Visible = false;
                txtBudgetYear.Visible = true;
                btnResult.Visible = true;
                Label1.Visible = false;
                ddlThaiYear.Visible = false;
                Label2.Visible = false;
                ddlMonth.Visible = false;
            }
            else if (rbtDuration.Checked == true)
            {
                lbStartDate.Visible = true;
                lbEndDate.Visible = true;

                lbBudget.Visible = false;

                txtBudgetYear.Visible = false;
                txtStartDate.Visible = true;
                txtEndDate.Visible = true;
                btnResult.Visible = true;

                Label1.Visible = false;
                ddlThaiYear.Visible = false;
                Label2.Visible = false;
                ddlMonth.Visible = false;
            }
            else if (rbtMonth.Checked == true)
            {
                Label1.Visible = true;
                ddlThaiYear.Visible = true;
                Label2.Visible = true;
                ddlMonth.Visible = true;
                btnResult.Visible = true;
                txtBudgetYear.Visible = false;
                lbStartDate.Visible = false;
                lbEndDate.Visible = false;
                txtStartDate.Visible = false;
                txtEndDate.Visible = false;
                lbBudget.Visible = false;
            }
        }
        protected void rbtMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtBudget.Checked == true)
            {
                lbBudget.Visible = true;
                lbStartDate.Visible = false;
                lbEndDate.Visible = false;
                txtStartDate.Visible = false;
                txtEndDate.Visible = false;
                txtBudgetYear.Visible = true;
                btnResult.Visible = true;
                Label1.Visible = false;
                ddlThaiYear.Visible = false;
                Label2.Visible = false;
                ddlMonth.Visible = false;
            }
            else if (rbtDuration.Checked == true)
            {
                lbStartDate.Visible = true;
                lbEndDate.Visible = true;

                lbBudget.Visible = false;

                txtBudgetYear.Visible = false;
                txtStartDate.Visible = true;
                txtEndDate.Visible = true;
                btnResult.Visible = true;

                Label1.Visible = false;
                ddlThaiYear.Visible = false;
                Label2.Visible = false;
                ddlMonth.Visible = false;
            }
            else if (rbtMonth.Checked == true)
            {
                Label1.Visible = true;
                ddlThaiYear.Visible = true;
                Label2.Visible = true;
                ddlMonth.Visible = true;
                btnResult.Visible = true;
                txtBudgetYear.Visible = false;
                lbStartDate.Visible = false;
                lbEndDate.Visible = false;
                txtStartDate.Visible = false;
                txtEndDate.Visible = false;
                lbBudget.Visible = false;
            }

        }



        public void btnResult_Click(object sender, EventArgs e)
        {
            BindData();     
        }

        protected void ltnAllPM_Command(object sender, CommandEventArgs e)
        {
            //PMAllTable report = new PMAllTable();
            Response.Redirect("/PM/Report/PMAllReport.aspx");
        }
        protected void ltnNum2_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("/PM/Report/PM9Report.aspx");
        }

        protected void ltnNum3_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("/PM/Report/PM71Report.aspx");
        }

        protected void ltnNum4_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("/PM/Report/PM72Report.aspx");
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbnum = (Label)(e.Row.FindControl("lbnum"));
            if (lbnum != null)
            {
                lbnum.Text = (GridView1.Rows.Count + 1).ToString();
            }
                Label lblActDate = (Label)(e.Row.FindControl("lblActDate"));
            if (lblActDate != null)
            {
                lblActDate.Text = function.ConvertDateShortThai((string)DataBinder.Eval(e.Row.DataItem, "pm_act_sdate"));
            }
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbnum2 = (Label)(e.Row.FindControl("lbnum2"));
            if (lbnum2 != null)
            {
                lbnum2.Text = (GridView2.Rows.Count + 1).ToString();
            }
            Label lblActDate2 = (Label)(e.Row.FindControl("lblActDate2"));
            if (lblActDate2 != null)
            {
                lblActDate2.Text = function.ConvertDateShortThai((string)DataBinder.Eval(e.Row.DataItem, "pm_act_sdate"));
            }
        }
        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbnum3 = (Label)(e.Row.FindControl("lbnum3"));
            if (lbnum3 != null)
            {
                lbnum3.Text = (GridView3.Rows.Count + 1).ToString();
            }
            Label lblActDate3 = (Label)(e.Row.FindControl("lblActDate3"));
            if (lblActDate3 != null)
            {
                lblActDate3.Text = function.ConvertDateShortThai((string)DataBinder.Eval(e.Row.DataItem, "pm_act_sdate"));
            }
        }
        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbnum4 = (Label)(e.Row.FindControl("lbnum4"));
            if (lbnum4 != null)
            {
                lbnum4.Text = (GridView4.Rows.Count + 1).ToString();
            }
            Label lblActDate4 = (Label)(e.Row.FindControl("lblActDate4"));
            if (lblActDate4 != null)
            {
                lblActDate4.Text = function.ConvertDateShortThai((string)DataBinder.Eval(e.Row.DataItem, "pm_act_sdate"));
            }
        }
        protected void BindData()
        {
            Session["whereSQL"] = null;
            Session["statReport"] = null;
            Session["SSD"] = null;
            Session["EED"] = null;

            string CurYear = ddlThaiYear.SelectedValue;
            int CurMonth = int.Parse(ddlMonth.SelectedValue);
            string Budget = txtBudgetYear.Text;
            StartD = function.ConvertDateShortThai(txtStartDate.Text);
            EndD = function.ConvertDateShortThai(txtEndDate.Text);
            string ssd = txtStartDate.Text;
            string eed = txtEndDate.Text;
            string durateTime = "";
            if (rbtBudget.Checked == true)
            {
                Session["statReport"] = "0";
                SQLWhere = " c.pm_budget_year = '" + Budget + "' AND c.pm_status_id = '3' "
                            + " ORDER BY STR_TO_DATE(c.pm_act_sdate, '%d-%m-%Y'),c.pm_detail_annex ASC ";
                Session["BudgetY"] = Budget;
                durateTime = " (ปีงบประมาณ "+Budget + " )";
            }
            else if (rbtDuration.Checked == true)
            {
                Session["statReport"] = "1";
                SQLWhere = " STR_TO_DATE(pm_act_sdate,'%d-%m-%Y') "
                           + " BETWEEN STR_TO_DATE('" + ssd + "','%d-%m-%Y') "
                           + " AND STR_TO_DATE('" + eed + "','%d-%m-%Y') AND c.pm_status_id = '3' "
                           + " ORDER BY STR_TO_DATE(c.pm_act_sdate, '%d-%m-%Y'),c.pm_detail_annex ASC ";
                string[] dateSSD = function.ConvertDatelongThai(ssd).Split(' ');
                Session["SSD"] = dateSSD[0];
                Session["EED"] = function.ConvertDatelongThai(eed);
                durateTime = "( "+Session["SSD"].ToString() + " - " +Session["EED"].ToString()+ " )";
            }
            else if (rbtMonth.Checked == true)
            {
                Session["statReport"] = "2";
                Session["MonthReport"] = ddlMonth.SelectedItem ;
                Session["YearReport"] = ddlThaiYear.SelectedItem;
                durateTime = "   ( เดือน "+Session["MonthReport"].ToString() + "  พ.ศ." + Session["YearReport"].ToString()+ " )";
                string betweenx = "";
                if(CurMonth < 10)
                {
                    betweenx = "0" + CurMonth.ToString() + "-" + CurYear;
                    SQLWhere = " STR_TO_DATE(SUBSTR(pm_act_sdate,4,7),'%m-%Y')"
                           + " BETWEEN STR_TO_DATE(SUBSTR('01-" + betweenx + "',4,7),'%m-%Y') AND STR_TO_DATE(SUBSTR('26-" + betweenx + "',4,7),'%m-%Y')  AND c.pm_status_id = '3' "
                           + " ORDER BY STR_TO_DATE(c.pm_act_sdate, '%d-%m-%Y'),c.pm_detail_annex ASC ";
                }
                else
                {
                    betweenx = CurMonth.ToString() + "-" + CurYear;
                    SQLWhere = " STR_TO_DATE(SUBSTR(pm_act_sdate,4,7),'%m-%Y')"
                           + " BETWEEN STR_TO_DATE(SUBSTR('01-" + betweenx + "',4,7),'%m-%Y') AND STR_TO_DATE(SUBSTR('26-" + betweenx + "',4,7),'%m-%Y')  AND c.pm_status_id = '3' "
                           + " ORDER BY STR_TO_DATE(c.pm_act_sdate, '%d-%m-%Y'),c.pm_detail_annex ASC ";
                }
                    
            }
            if (txtStation.SelectedValue == "")
            {
                btnCoverReport.Visible = true;
                string SQLToReport = " SELECT * FROM tbl_pm_detail c "
                + " JOIN tbl_pm_status d ON d.pm_status_id = c.pm_status_id "
                + " JOIN tbl_cpoint e ON e.cpoint_id = c.pm_detail_cpoint "
                + " JOIN tbl_company ON tbl_company.company_name = c.pm_corporate WHERE "
                + SQLWhere;

                string SQLToReport9 = " SELECT * FROM tbl_pm_detail c "
                + " JOIN tbl_pm_status d ON d.pm_status_id = c.pm_status_id "
                + " JOIN tbl_cpoint e ON e.cpoint_id = c.pm_detail_cpoint "
                + " JOIN tbl_company ON tbl_company.company_name = c.pm_corporate WHERE e.cpoint_sup = '1' AND "
                + SQLWhere;

                string SQLToReport71 = " SELECT * FROM tbl_pm_detail c "
                + " JOIN tbl_pm_status d ON d.pm_status_id = c.pm_status_id "
                + " JOIN tbl_cpoint e ON e.cpoint_id = c.pm_detail_cpoint "
                + " JOIN tbl_company ON tbl_company.company_name = c.pm_corporate WHERE e.cpoint_sup = '2' AND "
                + SQLWhere;

                string SQLToReport72 = " SELECT * FROM tbl_pm_detail c "
                + " JOIN tbl_pm_status d ON d.pm_status_id = c.pm_status_id "
                + " JOIN tbl_cpoint e ON e.cpoint_id = c.pm_detail_cpoint "
                + " JOIN tbl_company ON tbl_company.company_name = c.pm_corporate WHERE e.cpoint_sup = '3' AND "
                + SQLWhere;

                Session["whereSQL"] = SQLWhere;
                MySqlDataAdapter da = function.MySqlSelectDataSet(SQLToReport);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                
                lbPMNull.Visible = true;
                if (ds.Tables[0].Rows.Count != 0)
                { GridView1.Visible = true; ltnAllPM.Visible = true;
                    lbPMNull.Text = "รายงาน PM รวมทุกด่านฯ " + durateTime + "   จำนวน " + ds.Tables[0].Rows.Count + " รายการ";
                }
                else
                {
                    GridView1.Visible = true; ltnAllPM.Visible = false;
                    lbPMNull.Text = "รายงาน PM รวมทุกด่านฯ " + durateTime + "   ไม่พบรายการ";
                }

                MySqlDataAdapter da9 = function.MySqlSelectDataSet(SQLToReport9);
                System.Data.DataSet ds9 = new System.Data.DataSet();
                da9.Fill(ds9);
                GridView2.DataSource = ds9.Tables[0];
                GridView2.DataBind();
                
                lbnum2.Visible = true;
                string Count9 = ds9.Tables[0].Rows.Count.ToString();
                if (ds9.Tables[0].Rows.Count != 0)
                { GridView2.Visible = true; ltnNum2.Visible = true;
                    lbnum2.Text = "รายงาน PM สาย 9 " + durateTime + "   จำนวน " + ds9.Tables[0].Rows.Count + " รายการ";
                }
                else
                {
                    GridView2.Visible = true; ltnNum2.Visible = false;
                    lbnum2.Text = "รายงาน PM สาย 9 " + durateTime + "  ไม่พบรายการ";
                }

                MySqlDataAdapter da71 = function.MySqlSelectDataSet(SQLToReport71);
                System.Data.DataSet ds71 = new System.Data.DataSet();
                da71.Fill(ds71);
                GridView3.DataSource = ds71.Tables[0];
                GridView3.DataBind();
                string Count71 = ds71.Tables[0].Rows.Count.ToString();
                lbnum3.Visible = true;
                if (ds71.Tables[0].Rows.Count != 0)
                { GridView3.Visible = true; ltnNum3.Visible = true;
                    lbnum3.Text = "รายงาน PM สาย 7-1 " + durateTime + "   จำนวน " + ds71.Tables[0].Rows.Count + " รายการ";
                }
                else
                {
                    GridView3.Visible = true; ltnNum3.Visible = false;
                    lbnum3.Text = "รายงาน PM สาย 7-1 " + durateTime + "   ไม่พบรายการ";
                }

                MySqlDataAdapter da72 = function.MySqlSelectDataSet(SQLToReport72);
                System.Data.DataSet ds72 = new System.Data.DataSet();
                da72.Fill(ds72);
                GridView4.DataSource = ds72.Tables[0];
                GridView4.DataBind();
                string Count72 = ds72.Tables[0].Rows.Count.ToString();
                lbnum4.Visible = true;
                if (ds72.Tables[0].Rows.Count != 0)
                { GridView4.Visible = true; ltnNum4.Visible = true;
                    lbnum4.Text = "รายงาน PM สาย 7-2 " + durateTime + "   จำนวน " + ds72.Tables[0].Rows.Count + " รายการ";
                }
                else
                {
                    GridView4.Visible = true; ltnNum4.Visible = false;
                    lbnum4.Text = "รายงาน PM สาย 7-2 " + durateTime + "  ไม่พบรายการ";
                }
                supdiv.Visible = true;

                if(Count9 != "0" && Count71 != "0" && Count72 != "0")//1 1 1
                {
                    Session["finalText"] = "ตามเอกสารแนบ ดังต่อไปนี้";
                    Session["List9"] = "3. รายงานการเข้าบำรุงรักษาอุปกรณ์ระบบจัดเก็บค่าธรรมเนียมผ่านทาง (PM) หมายเลข 9 ช่วงบางปะอิน-บางพลี จำนวน " + Count9+" รายการ";
                    Session["List71"] = "1. รายงานการเข้าบำรุงรักษาอุปกรณ์ระบบจัดเก็บค่าธรรมเนียมผ่านทาง (PM) หมายเลข 7 ช่วงกรุงเทพ-ชลบุรี จำนวน " + Count71 + " รายการ";
                    Session["List72"] = "2. รายงานการเข้าบำรุงรักษาอุปกรณ์ระบบจัดเก็บค่าธรรมเนียมผ่านทาง (PM) หมายเลข 7 ช่วงชลบุรี-พัทยา จำนวน " + Count72 + " รายการ";
                    Session["AmountReport"] = "บนทางหลวงพิเศษหมายเลข 7 ช่วงกรุงเทพ-ชลบุรี บนทางหลวงพิเศษหมายเลข 7 ช่วงชลบุรี-พัทยา บนทางหลวงพิเศษหมายเลข 9 ช่วงบางปะอิน-บางพลี";
                }
                else if(Count9 == "0" && Count71 != "0" && Count72 != "0")//0 1 1
                {
                    Session["finalText"] = "ตามเอกสารแนบ ดังต่อไปนี้";
                    Session["List9"] = "";
                    Session["List71"] = "1. รายงานการเข้าบำรุงรักษาอุปกรณ์ระบบจัดเก็บค่าธรรมเนียมผ่านทาง (PM) หมายเลข 7 ช่วงกรุงเทพ-ชลบุรี จำนวน " + Count71 + " รายการ";
                    Session["List72"] = "2. รายงานการเข้าบำรุงรักษาอุปกรณ์ระบบจัดเก็บค่าธรรมเนียมผ่านทาง (PM) หมายเลข 7 ช่วงชลบุรี-พัทยา จำนวน " + Count72 + " รายการ";
                    Session["AmountReport"] = "บนทางหลวงพิเศษหมายเลข 7 ช่วงกรุงเทพ-ชลบุรี บนทางหลวงพิเศษหมายเลข 7 ช่วงชลบุรี-พัทยา";
                }
                else if (Count9 != "0" && Count71 == "0" && Count72 != "0")// 1 0 1
                {
                    Session["finalText"] = "ตามเอกสารแนบ ดังต่อไปนี้";
                    Session["List9"] = "2. รายงานการเข้าบำรุงรักษาอุปกรณ์ระบบจัดเก็บค่าธรรมเนียมผ่านทาง (PM) หมายเลข 9 ช่วงบางปะอิน-บางพลี จำนวน " + Count9 + " รายการ";
                    Session["List71"] = "";
                    Session["List72"] = "1. รายงานการเข้าบำรุงรักษาอุปกรณ์ระบบจัดเก็บค่าธรรมเนียมผ่านทาง (PM) หมายเลข 7 ช่วงชลบุรี-พัทยา จำนวน " + Count72 + " รายการ";
                    Session["AmountReport"] = "บนทางหลวงพิเศษหมายเลข 7 ช่วงชลบุรี-พัทยา บนทางหลวงพิเศษหมายเลข 9 ช่วงบางปะอิน-บางพลี";
                }
                else if(Count9 != "0" && Count71 == "0" && Count72 == "0")// 1 0 0
                {
                    Session["finalText"] = "ตามเอกสารแนบ ดังต่อไปนี้";
                    Session["List9"] = "1. รายงานการเข้าบำรุงรักษาอุปกรณ์ระบบจัดเก็บค่าธรรมเนียมผ่านทาง (PM) หมายเลข 9 ช่วงบางปะอิน-บางพลี จำนวน " + Count9 + " รายการ";
                    Session["List71"] = "";
                    Session["List72"] = "";
                    Session["AmountReport"] = "บนทางหลวงพิเศษหมายเลข 9 ช่วงบางปะอิน-บางพลี";
                }
                else if (Count9 != "0" && Count71 != "0" && Count72 == "0")// 1 1 0
                {
                    Session["finalText"] = "ตามเอกสารแนบ ดังต่อไปนี้";
                    Session["List9"] = "2. รายงานการเข้าบำรุงรักษาอุปกรณ์ระบบจัดเก็บค่าธรรมเนียมผ่านทาง (PM) หมายเลข 9 ช่วงบางปะอิน-บางพลี จำนวน " + Count9 + " รายการ";
                    Session["List71"] = "1. รายงานการเข้าบำรุงรักษาอุปกรณ์ระบบจัดเก็บค่าธรรมเนียมผ่านทาง (PM) หมายเลข 7 ช่วงกรุงเทพ-ชลบุรี จำนวน " + Count71 + " รายการ";
                    Session["List72"] = "";
                    Session["AmountReport"] = "บนทางหลวงพิเศษหมายเลข 7 ช่วงกรุงเทพ-ชลบุรี บนทางหลวงพิเศษหมายเลข 9 ช่วงบางปะอิน-บางพลี";
                }
                else if (Count9 == "0" && Count71 != "0" && Count72 == "0")// 0 1 0
                {
                    Session["finalText"] = "ตามเอกสารแนบ ดังต่อไปนี้";
                    Session["List9"] = "";
                    Session["List71"] = "1. รายงานการเข้าบำรุงรักษาอุปกรณ์ระบบจัดเก็บค่าธรรมเนียมผ่านทาง (PM) หมายเลข 7 ช่วงกรุงเทพ-ชลบุรี จำนวน " + Count71 + " รายการ";
                    Session["List72"] = "";
                    Session["AmountReport"] = "บนทางหลวงพิเศษหมายเลข 7 ช่วงกรุงเทพ-ชลบุรี";
                }
                else if (Count9 == "0" && Count71 == "0" && Count72 != "0")// 0 0 1
                {
                    Session["finalText"] = "ตามเอกสารแนบ ดังต่อไปนี้";
                    Session["List9"] = "";
                    Session["List71"] = "";
                    Session["List72"] = "1. รายงานการเข้าบำรุงรักษาอุปกรณ์ระบบจัดเก็บค่าธรรมเนียมผ่านทาง (PM) หมายเลข 7 ช่วงชลบุรี-พัทยา จำนวน " + Count72 + " รายการ";
                    Session["AmountReport"] = "บนทางหลวงพิเศษหมายเลข 7 ช่วงชลบุรี-พัทยา";
                }
                else if (Count9 == "0" && Count71 == "0" && Count72 == "0")// 0 0 0
                {
                    Session["finalText"] = "";
                    Session["List9"] = "";
                    Session["List71"] = "";
                    Session["List72"] = "";
                    Session["AmountReport"] = "ผลการตรวจสอบพบว่าไม่มีการเข้าบำรุงรักษาอุปกรณ์ ";
                }
                function.Close();
            }

            if (txtStation.SelectedValue != "")
            {
                btnCoverReport.Visible = false;
                supdiv.Visible = false;
                Session["statReport"] = "3";
                Session["CpointPMReport"] = txtStation.SelectedItem ;
                string SQLToReport = " SELECT * FROM tbl_pm_detail c "
                + " JOIN tbl_pm_status d ON d.pm_status_id = c.pm_status_id "
                + " JOIN tbl_cpoint e ON e.cpoint_id = c.pm_detail_cpoint "
                + " JOIN tbl_company ON tbl_company.company_name = c.pm_corporate WHERE "
                + " e.cpoint_id LIKE '%"+txtStation.SelectedValue+"%' AND "+SQLWhere;
                Session["whereSQL"] = SQLWhere;
                MySqlDataAdapter da = function.MySqlSelectDataSet(SQLToReport);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                
                if (ds.Tables[0].Rows.Count == 0)
                {
                    lbPMNull.Text = "รายงาน PM  ด่านฯ " + txtStation.SelectedItem + " " + durateTime + " ไม่พบรายการ";
                    ltnAllPM.Visible = false;
                }
                else { ltnAllPM.Visible = true;
                    lbPMNull.Text = "รายงาน PM  ด่านฯ " + txtStation.SelectedItem + " " + durateTime + "    จำนวน " + ds.Tables[0].Rows.Count + " รายการ"; }
                GridView1.Visible = true;
                function.Close();
            }

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindData();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.BindData();
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            this.BindData();
        }

        protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView4.PageIndex = e.NewPageIndex;
            this.BindData();
        }

        protected void btnCoverReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PM/Report/CoverPageAdmin.aspx");
        }
    }
}