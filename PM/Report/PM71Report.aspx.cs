using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using ClaimProject.PM.Report;
using MySql.Data.MySqlClient;
using ClaimProject;
using ClaimProject.Config;
using CrystalDecisions.Shared;
using System.Data;
using System.Net;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Drawing.Printing;
namespace ClaimProject.PM.Report
{
    public partial class PM71Report : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string timeThai = "";
                string sqlrpt = "SELECT pm_ref_no,pm_act_stime,pm_act_etime,cpoint_name,pm_detail_annex,"
                              + " pm_corporate,pm_duration_time,pm_admin_name,pm_ActSDate_thai "
                              + " FROM tbl_pm_detail c "
                              + " JOIN tbl_pm_status d ON d.pm_status_id = c.pm_status_id "
                              + " JOIN tbl_cpoint e ON e.cpoint_id = c.pm_detail_cpoint "
                              + " JOIN tbl_company ON c.pm_corporate = tbl_company.company_name WHERE e.cpoint_sup = '2' AND "
                              + Session["whereSQL"].ToString();
                

                if (Session["statReport"].ToString() == "1")
                {
                    string ssdate = Session["SSD"].ToString();
                    string eedate = Session["EED"].ToString();
                    timeThai = " สาย 7-1  (" + ssdate + " - " + eedate + ")";
                    Session["SSD"] = null;
                    Session["EED"] = null;
                }
                else if (Session["statReport"].ToString() == "0")
                {
                    timeThai = " สาย 7-1  (ปีงบประมาณ " + Session["BudgetY"].ToString() + ")";
                    Session["BudgetY"] = null;
                }
                else if (Session["statReport"].ToString() == "2")
                {
                    timeThai = " สาย 7-1  ( เดือน " + Session["MonthReport"].ToString() + " พ.ศ." + Session["YearReport"].ToString() + " )";
                    Session["MonthReport"] = null;
                    Session["YearReport"] = null;
                }
                Session["statReport"] = null;
                MySqlCommand objcmd = new MySqlCommand();
                MySqlDataAdapter dts = function.MySqlSelectDataSet(sqlrpt);

                PMAllTable dtss = new PMAllTable();
                dts.Fill(dtss, "PMDataSet");

                ReportDocument rrr = new ReportDocument();
                rrr.Load(MapPath("/PM/Report/PMOverall.rpt"));
                rrr.SetDataSource(dtss);
                rrr.SetParameterValue("partOftime", timeThai);
                function.Close();
                this.CRT71.ReportSource = rrr;
                rrr.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "PMReport71");
            }
        }
    }
}