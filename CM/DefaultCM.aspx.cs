using ClaimProject.Config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimProject.CM
{
    public partial class DefaultCM : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public int Nowmonth = int.Parse(DateTime.Now.ToString("MM"));
        public int Nowyear = int.Parse((DateTime.Now.Year + 543).ToString());
        public string Nowday = DateTime.Now.ToString("dd");
        public string sqlcp = "";
        public string cpoint = "";
        public string point = "";
        public string sqlmonth = "";
        public string sqlnofix = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                Response.Redirect("/");
            }
            if (!this.IsPostBack)
            {
                /* string actYear = "";
                 string actMonth = "";
                 string TimeToChangeStat = "";
                 if (DateTime.Today.Month.ToString() == "1")
                 {
                     actYear = (int.Parse(DateTime.Today.Year.ToString()) + 542).ToString();
                     actMonth = "12";
                     TimeToChangeStat = "01-" + actMonth + "-" + actYear;
                 }
                 else
                 {
                     actYear = (int.Parse(DateTime.Today.Year.ToString()) + 543).ToString();
                     actMonth = (int.Parse(DateTime.Today.Month.ToString()) - 1).ToString();
                     TimeToChangeStat = "01-" + actMonth + "-" + actYear;
                 }

                 string UpdatePMSQL = "UPDATE tbl_pm_detail c SET pm_status_id = '5' "
                                 + " WHERE c.pm_status_id = '1' AND STR_TO_DATE(SUBSTR(c.pm_contract_date,4,7),'%m-%Y') "
                                 + " BETWEEN STR_TO_DATE(SUBSTR('"+TimeToChangeStat+"',4,7),'%m-%Y') AND STR_TO_DATE(SUBSTR('"+TimeToChangeStat+"',4,7),'%m-%Y') ";
                 function.MySqlQuery(UpdatePMSQL);*/
            }

            if (function.CheckLevel("Department", Session["UserPrivilegeId"].ToString()))
            {
                Div6.Visible = true;
                sqlcp = " ";
                cpoint = " ";
                point = " ";
                sqlmonth = " WHERE cm_detail_sdate LIKE '%" + Nowmonth + "-" + Nowyear + "' ";
                sqlnofix = " WHERE cm_detail_status_id = '0' ";
            }
            else
            {
                Div6.Visible = false;
                divpm.Visible = false;
                divpm2.Visible = false;
                Div3.Visible = false;
                //Div2.Visible = false;
                sqlcp = "AND cm_cpoint = " + Session["UserCpoint"] + " ";
                cpoint = " WHERE cm_cpoint = " + Session["UserCpoint"] + " ";
                sqlmonth = "AND cm_detail_sdate LIKE '%" + Nowmonth + "-" + Nowyear + "' ";
                sqlnofix = " AND cm_detail_status_id = '0' ";

                if (Session["UserCpoint"].ToString() == "703" || Session["UserCpoint"].ToString() == "704" || Session["UserCpoint"].ToString() == "706" || Session["UserCpoint"].ToString() == "707" || Session["UserCpoint"].ToString() == "708" || Session["UserCpoint"].ToString() == "709")
                {
                    point = " AND cm_point = " + Session["Userpoint"] + " ";
                }
                else
                {
                    point = " ";
                }
                
            }
            loadingpage();
            databind();
        }

        protected void loadingpage()
        {
            string sqlcpSearch = "";

            if (Session["UserCpoint"].ToString() == "701")
            {
                sqlcpSearch += " 7010 ";
            }
            else if (Session["UserCpoint"].ToString() == "702")
            {
                sqlcpSearch += " 7020 ";
            }
            else if (Session["UserCpoint"].ToString() == "703")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='7031' OR toll_recieve = '7032' OR toll_recieve = '7033";
            }
            else if (Session["UserCpoint"].ToString() == "704")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='7041' OR toll_recieve = ' 7042 ";
            }
            else if (Session["UserCpoint"].ToString() == "706")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='7051' OR toll_recieve = ' 7052 ";
            }
            else if (Session["UserCpoint"].ToString() == "707")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='7061' OR toll_recieve = ' 7062 ' OR toll_recieve = ' 7063 ' OR toll_recieve = ' 7064 ";
            }
            else if (Session["UserCpoint"].ToString() == "708")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='7071' OR toll_recieve = ' 7072 ' OR toll_recieve = ' 7073 ' OR toll_recieve = ' 7074 ' OR toll_recieve = ' 7075 ' OR toll_recieve = ' 7076 ";
            }
            else if (Session["UserCpoint"].ToString() == "709")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='7081' OR toll_recieve = ' 7082 ' OR toll_recieve = ' 7083 ' OR toll_recieve = ' 7084 ";
            }
            else if (Session["UserCpoint"].ToString() == "710")
            {
                sqlcpSearch += " 7090 ";
            }
            else if (Session["UserCpoint"].ToString() == "711")
            {
                sqlcpSearch += " 7100 ";
            }
            else if (Session["UserCpoint"].ToString() == "712")
            {
                sqlcpSearch += " 7110 ";
            }
            else if (Session["UserCpoint"].ToString() == "713")
            {
                sqlcpSearch += " 7120 ";
            }
            else if (Session["UserCpoint"].ToString() == "902")
            {
                sqlcpSearch += " 9010 ";
            }
            else if (Session["UserCpoint"].ToString() == "903")
            {
                sqlcpSearch += " 9020 ";
            }
            else if (Session["UserCpoint"].ToString() == "904")
            {
                sqlcpSearch += "9030 ";
            }
            else if (Session["UserCpoint"].ToString() == "905")
            {
                sqlcpSearch += " 9040 ";
            }
            

            int i = 0;
            i = Nowmonth;
            string now = Nowday + "-" + Nowmonth.ToString() + "-" + Nowyear.ToString();
            string MonthFullList = "ตุลาคม-มกราคม-กุมภาพันธ์-มีนาคม-เมษายน-พฤษภาคม-มิถุนายน-กรกฎาคม-สิงหาคม-กันยายน-ตุลาคม-พฤศจิกายน-ธันวาคม";
            string[] MonthList = MonthFullList.Split('-');

            int Nowbudget = 0;
            if (Nowmonth > 9)
            {
                Nowbudget = Nowyear + 1;
            }

            string mYconn = Nowmonth+"-"+ Nowyear;


            //string CMsqlDay = "SELECT COUNT(*) AS numd FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_cpoint = '" + Session["UserCpoint"] + "' AND cm_detail_sdate ='"+ now +"' ";
            //string CMsqlMonth = "SELECT COUNT(*) AS numm FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_cpoint = '" + Session["UserCpoint"] + "' AND cm_budget = '" + Nowbudget + "' ";
            //string CMsqlBudget = "SELECT COUNT(*) AS numb FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_cpoint = '" + Session["UserCpoint"] + "' AND cm_budget = '"+ Nowbudget +"' ";
            //string CMsqlOverall = "SELECT COUNT(*) AS numa FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_cpoint = '" + Session["UserCpoint"] + "' ";
            //ค้างซ่อม
            //string CMsqlDayNot = "SELECT COUNT(*) AS numdn FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_detail_status_id != '2' AND cm_cpoint = '" + Session["UserCpoint"] + "' AND cm_detail_sdate ='" + now + "' ";
            //string CMsqlMonthNot = "SELECT COUNT(*) AS nummn FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_detail_status_id != '2' AND cm_cpoint = '" + Session["UserCpoint"] + "' AND cm_budget = '" + Nowbudget + "' ";
            //string CMsqlBudgetNot = "SELECT COUNT(*) AS numbn FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_detail_status_id != '2' AND cm_cpoint = '" + Session["UserCpoint"] + "' AND cm_budget = '" + Nowbudget + "' ";
            //string CMsqlOverallNot = "SELECT COUNT(*) AS numan FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_detail_status_id != '2' AND cm_cpoint = '" + Session["UserCpoint"] + "' ";

            string CMsqlDay = "SELECT COUNT(*) AS numd FROM tbl_cm_detail WHERE cm_detail_status_id != '9' "+ sqlcp +" "+ point + " AND cm_detail_sdate = '" + now + "' ";
            string CMsqlMonth = "SELECT COUNT(*) AS numm FROM tbl_cm_detail WHERE cm_detail_status_id != '9' " + sqlcp + " "+ point +" AND cm_budget = '" + Nowbudget + "' AND cm_detail_sdate LIKE '%"+ mYconn + "' ";
            string CMsqlBudget = "SELECT COUNT(*) AS numb FROM tbl_cm_detail WHERE cm_detail_status_id != '9' " + sqlcp + " " + point + "AND cm_budget = '" + Nowbudget + "' ";
            string CMsqlOverall = "SELECT COUNT(*) AS numa FROM tbl_cm_detail WHERE cm_detail_status_id != '9' " + sqlcp + " " + point +" ";
            //ค้างซ่อม
            string CMsqlDayNot = "SELECT COUNT(*) AS numdn FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_detail_status_id != '2' " + sqlcp + " " + point + " AND cm_detail_sdate ='" + now + "' ";
            string CMsqlMonthNot = "SELECT COUNT(*) AS nummn FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_detail_status_id != '2' " + sqlcp + " " + point + "AND cm_budget = '" + Nowbudget + "' AND cm_detail_sdate LIKE '%" + mYconn + "' ";
            string CMsqlBudgetNot = "SELECT COUNT(*) AS numbn FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_detail_status_id != '2' " + sqlcp + " " + point + "AND cm_budget = '" + Nowbudget + "' ";
            string CMsqlOverallNot = "SELECT COUNT(*) AS numan FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_detail_status_id != '2' " + sqlcp + " " + point + " ";

            string CMsqlFixbacktoday = "SELECT COUNT(*) AS numfd FROM tbl_cm_detail WHERE cm_detail_status_id = '2' " + sqlcp + " " + point + "AND cm_detail_edate = '" + now + "' ";
            string CMsqlFixbackMouth = "SELECT COUNT(*) AS numfm FROM tbl_cm_detail WHERE cm_detail_status_id = '2' " + sqlcp + " " + point + "AND cm_budget = '" + Nowbudget + "' AND cm_detail_edate LIKE '%" + mYconn + "' ";
            string CMsqlFixbackYear = "SELECT COUNT(*) AS numfy FROM tbl_cm_detail WHERE cm_detail_status_id = '2' " + sqlcp + " " + point + "AND cm_budget = '" + Nowbudget + "' ";
            string CMsqlFixbackOverall = "SELECT COUNT(*) AS numfo FROM tbl_cm_detail WHERE cm_detail_status_id = '2' "+ sqlcp + " " + point + " ";
            //notication survey
            string sqlNotiSur = "SELECT COUNT(*) AS numnoS FROM tbl_cm_detail WHERE cm_detail_status_id = '1' ";


            //แสดงเดือน ปี
            lbCMNameMonthly.Text = MonthList[i];
            lbTop5CMMonthly.Text = MonthList[i];
            string lbBudget = Nowbudget.ToString();
            lbCMNameBudget.Text = lbBudget;

            MySqlDataReader trdd = function.MySqlSelect(CMsqlDay);
            if (trdd.Read())
            {
                if (trdd.GetInt32("numd") != 0)
                {
                    MySqlDataReader trddn = function.MySqlSelect(CMsqlDayNot);
                    if (trddn.Read())
                    {
                        if (trddn.GetInt32("numdn") != 0)
                        {
                            lbCMStatDay.Text = trdd.GetInt32("numd").ToString() + " / " + trddn.GetInt32("numdn").ToString();
                            trdd.Close();
                            trddn.Close();
                        }
                        else
                        {
                            lbCMStatDay.Text = trdd.GetInt32("numd").ToString() + " / 0";
                            trdd.Close();
                            trddn.Close();
                        }
                    }
                }
                else
                {
                    lbCMStatDay.Text = "0 / 0";
                    trdd.Close();
                }
            }
            function.Close();

            MySqlDataReader trmm = function.MySqlSelect(CMsqlMonth);
            if (trmm.Read())
            {
                if (trmm.GetInt32("numm") != 0)
                {
                    MySqlDataReader trmmn = function.MySqlSelect(CMsqlMonthNot);
                    if (trmmn.Read())
                    {
                        if (trmmn.GetInt32("nummn") != 0)
                        {
                            lbCMStatMonthly.Text = trmm.GetInt32("numm").ToString() + " / " + trmmn.GetInt32("nummn").ToString();
                            trmm.Close();
                            trmmn.Close();
                        }
                        else
                        {

                            lbCMStatMonthly.Text = trmm.GetInt32("numm").ToString() + " / 0";
                            trmm.Close();
                            trmmn.Close();
                        }
                    }
                }
                else
                {
                    lbCMStatMonthly.Text = "0 / 0";
                    trmm.Close();
                }
            }
            function.Close();

            MySqlDataReader trbg = function.MySqlSelect(CMsqlBudget);
            if (trbg.Read())
            {
                if (trbg.GetInt32("numb") != 0)
                {
                    MySqlDataReader trbgn = function.MySqlSelect(CMsqlBudgetNot);
                    if (trbgn.Read())
                    {
                        if (trbgn.GetInt32("numbn") != 0)
                        {
                            lbCMStatBudget.Text = trbg.GetInt32("numb").ToString() + " / " + trbgn.GetInt32("numbn").ToString();
                            trbg.Close();
                            trbgn.Close();
                        }
                        else
                        {
                            lbCMStatBudget.Text = trbg.GetInt32("numb").ToString() + " / 0";
                            trbg.Close();
                            trbgn.Close();
                        }
                    }                       
                }
                else
                {
                    lbCMStatBudget.Text = "0 / 0";
                    trbg.Close();
                }
            }
            function.Close();

            MySqlDataReader troa = function.MySqlSelect(CMsqlOverall);
            if (troa.Read())
            {
                if (troa.GetInt32("numa") != 0)
                {
                    MySqlDataReader troan = function.MySqlSelect(CMsqlOverallNot);
                    if (troan.Read())
                    {
                        if (troan.GetInt32("numan") != 0)
                        {
                            lbCMStatOverall.Text = troa.GetInt32("numa").ToString() + " / " + troan.GetInt32("numan").ToString();
                            troa.Close();
                            troan.Close();
                        }
                        else
                        {
                            lbCMStatOverall.Text = troa.GetInt32("numa").ToString() + " / 0 ";
                            troa.Close();
                            troan.Close();
                        }
                    }
                }
                else
                {
                    lbCMStatOverall.Text = "0 / 0";
                    troa.Close();
                }
            }
            function.Close();

            MySqlDataReader trfd = function.MySqlSelect(CMsqlFixbacktoday);
            if (trfd.Read())
            {
                if (trfd.GetInt32("numfd") != 0)
                {
                    lbFixBack.Text = trfd.GetInt32("numfd").ToString();
                    trfd.Close();
                }
                else
                {
                    lbFixBack.Text = "0";
                    trfd.Close();
                }
            }
            function.Close();

            MySqlDataReader trfm = function.MySqlSelect(CMsqlFixbackMouth);
            if (trfm.Read())
            {
                if (trfm.GetInt32("numfm") != 0)
                {
                    lbFixbackMonth.Text = trfm.GetInt32("numfm").ToString();
                    trfm.Close();
                }
                else
                {
                    lbFixbackMonth.Text = "0";
                    trfm.Close();
                }
            }
            function.Close();

            MySqlDataReader trfy = function.MySqlSelect(CMsqlFixbackYear);
            if (trfy.Read())
            {
                if (trfy.GetInt32("numfy") != 0)
                {
                    lbFixbackyear.Text = trfy.GetInt32("numfy").ToString();
                    trfy.Close();
                }
                else
                {
                    lbFixbackyear.Text = "0";
                    trfy.Close();
                }
            }
            function.Close();

            MySqlDataReader trfo = function.MySqlSelect(CMsqlFixbackOverall);
            if (trfo.Read())
            {
                if (trfo.GetInt32("numfo") != 0)
                {
                    lbFixbackOverall.Text = trfo.GetInt32("numfo").ToString();
                    trfo.Close();
                }
                else
                {
                    lbFixbackOverall.Text = "0";
                    trfo.Close();
                }
            }
            function.Close();

            MySqlDataReader trnos = function.MySqlSelect(sqlNotiSur);
            if (trnos.Read())
            {
                if (trnos.GetInt32("numnoS") != 0)
                {
                    lbSurveyNoti.Text = trnos.GetInt32("numnoS").ToString();
                    lbSurveyNoti.CssClass = "badge badge-danger";
                    trnos.Close();
                }
                else
                {
                    lbSurveyNoti.Text = " ";
                    trnos.Close();
                }
            }
            function.Close();

        }

        protected void lsTodayGridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbDevice = (Label)(e.Row.FindControl("lbDevice"));
            if (lbDevice != null)
            {
                lbDevice.Text = (string)DataBinder.Eval(e.Row.DataItem, "device_name").ToString();
                lbDevice.Text = function.ShortText(DataBinder.Eval(e.Row.DataItem, "device_name").ToString());
                lbDevice.ToolTip = DataBinder.Eval(e.Row.DataItem, "device_name").ToString();
            }

            Label lbAmount = (Label)(e.Row.FindControl("lbAmount"));
            if (lbAmount != null)
            {
                lbAmount.Text = (string)DataBinder.Eval(e.Row.DataItem, "num").ToString();
            }

        }

        protected void databind()
        {
            string sqlLsTotal = "SELECT COUNT(cm_detail_driver_id) AS num , cm_detail_driver_id ,device_name " +
                " FROM tbl_cm_detail c JOIN tbl_device d ON c.cm_detail_driver_id = d.device_id " +
                " "+ cpoint + " GROUP BY cm_detail_driver_id ORDER BY COUNT(cm_detail_driver_id) DESC LIMIT 5 ";

            MySqlDataAdapter da = function.MySqlSelectDataSet(sqlLsTotal);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            lsTodayGridview.DataSource = ds.Tables[0];
            lsTodayGridview.DataBind();
            function.Close();

            string sqlTopMoTotal = "SELECT COUNT(cm_detail_driver_id) AS num , cm_detail_driver_id ,device_name " +
                " FROM tbl_cm_detail c JOIN tbl_device d ON c.cm_detail_driver_id = d.device_id " +
                " " + cpoint + " " + sqlmonth + "  GROUP BY cm_detail_driver_id ORDER BY COUNT(cm_detail_driver_id) DESC LIMIT 5 ";

            MySqlDataAdapter dA = function.MySqlSelectDataSet(sqlTopMoTotal);
            System.Data.DataSet dS = new System.Data.DataSet();
            dA.Fill(dS);
            GridViewNoService.DataSource = dS.Tables[0];
            GridViewNoService.DataBind();
            function.Close();

            string sqlNofix = "SELECT device_name,cm_detail_sdate,locate_name  " +
                " FROM tbl_cm_detail c JOIN tbl_device d ON c.cm_detail_driver_id = d.device_id JOIN tbl_location l ON c.cm_detail_channel = l.locate_id " +
                " " + cpoint + " "+ sqlnofix + " ORDER BY STR_TO_DATE(cm_detail_sdate,'%d-%m-%Y') ASC LIMIT 5 ";

            MySqlDataAdapter DA = function.MySqlSelectDataSet(sqlNofix);
            System.Data.DataSet DS = new System.Data.DataSet();
            DA.Fill(DS);
            GridViewNoFix.DataSource = DS.Tables[0];
            GridViewNoFix.DataBind();
            function.Close();
        }

        protected void GridViewNoService_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbMonthDevice = (Label)(e.Row.FindControl("lbDevice"));
            if (lbMonthDevice != null)
            {
                lbMonthDevice.Text = (string)DataBinder.Eval(e.Row.DataItem, "device_name").ToString();
                lbMonthDevice.Text = function.ShortText(DataBinder.Eval(e.Row.DataItem, "device_name").ToString());
                lbMonthDevice.ToolTip = DataBinder.Eval(e.Row.DataItem, "device_name").ToString();
            }

            Label lbMonthAmount = (Label)(e.Row.FindControl("lbAmount"));
            if (lbMonthAmount != null)
            {
                lbMonthAmount.Text = (string)DataBinder.Eval(e.Row.DataItem, "num").ToString();
            }
        }

        protected void GridViewNoFix_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbnofixDevice = (Label)(e.Row.FindControl("lbnofixDevice"));
            if (lbnofixDevice != null)
            {
                lbnofixDevice.Text = (string)DataBinder.Eval(e.Row.DataItem, "device_name").ToString();
                lbnofixDevice.Text = function.ShortText(DataBinder.Eval(e.Row.DataItem, "device_name").ToString());
                string locate = DataBinder.Eval(e.Row.DataItem, "locate_name").ToString();
                lbnofixDevice.ToolTip = DataBinder.Eval(e.Row.DataItem, "device_name" ).ToString() + " " + locate ;
            }
        }
    }
}