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
    public partial class CoverPageAdmin : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string timeThai = "";
                string list9 = Session["List9"].ToString();
                string list71 = Session["List71"].ToString();
                string list72 = Session["List72"].ToString();
                string finaltext = Session["finalText"].ToString();
                string textlist = Session["AmountReport"].ToString();
                string name = Session["UserName"].ToString();
                Session["List9"] = null;
                Session["List71"] = null;
                Session["List72"] = null;
                Session["finalText"] = null;
                Session["AmountReport"] = null;
                string[] gettoday = DateTime.Now.ToString("dd-MM-yyyy").Split('-');
                string todayy = "";
                if(gettoday[0].Substring(0,1) == "0")
                {
                    todayy = function.ConvertDatelongThai(gettoday[0].Substring(1, 1) + "-" + gettoday[1] + "-" + (int.Parse(gettoday[2]) + 543).ToString());
                    
                }
                else
                {
                    todayy = function.ConvertDatelongThai(gettoday[0]+ "-" + gettoday[1] + "-" + (int.Parse(gettoday[2]) + 543).ToString());
                }

                string sqlrpt = "SELECT company_name,cpoint_name,cpoint_sup,cpoint_tel,pm_ref_no," 
                              + " pm_act_sdate,pm_act_stime,pm_act_etime,pm_com_name "
                              + " FROM tbl_pm_detail c " 
                              + " JOIN tbl_pm_status d ON d.pm_status_id = c.pm_status_id "
                              + " JOIN tbl_cpoint e ON e.cpoint_id = c.pm_detail_cpoint "
                              + " JOIN tbl_company ON c.pm_corporate = tbl_company.company_name WHERE "
                              + Session["whereSQL"].ToString(); 

                if (Session["statReport"].ToString() == "1")
                {
                    string ssdate = Session["SSD"].ToString();
                    string eedate = Session["EED"].ToString();
                    timeThai = "ตั้งแต่วันที่ " + ssdate + " - " + eedate  ;
                    Session["SSD"] = null;
                    Session["EED"] = null;
                }
                else if (Session["statReport"].ToString() == "0")
                {
                    timeThai = "ปีงบประมาณ " + Session["BudgetY"].ToString() ;
                    Session["BudgetY"] = null;
                }
                else if (Session["statReport"].ToString() == "2")
                {
                    timeThai = "ประจำ เดือน " + Session["MonthReport"].ToString() + " พ.ศ." + Session["YearReport"].ToString() ;
                    Session["MonthReport"] = null;
                    Session["YearReport"] = null;
                }

                Session["statReport"] = null;
                

                MySqlCommand objcmd = new MySqlCommand();
                MySqlDataAdapter dts = function.MySqlSelectDataSet(sqlrpt);

                PMAllTable dtss = new PMAllTable();
                dts.Fill(dtss, "PMDataSet");

                ReportDocument rrr = new ReportDocument();
                rrr.Load(MapPath("/PM/Report/PMAdminReport.rpt"));
                rrr.SetDataSource(dtss);

                rrr.SetParameterValue("admin", name);
                rrr.SetParameterValue("listtext", textlist);
                rrr.SetParameterValue("final", finaltext);
                rrr.SetParameterValue("9list", list9);
                rrr.SetParameterValue("71list", list71);
                rrr.SetParameterValue("72list", list72);
                rrr.SetParameterValue("time", timeThai);
                rrr.SetParameterValue("today",todayy);
                rrr.SetParameterValue("image", Server.MapPath("/PM/Report/300px-Thai_government_Garuda_emblem_(Version_2).jpg"));
                function.Close();
                this.CRTCover.ReportSource = rrr;
                rrr.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "PMCoverReport");
            }
        }
    }
}