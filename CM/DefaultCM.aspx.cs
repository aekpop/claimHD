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

            }
            else
            {
                Div6.Visible = false;
                divpm.Visible = false;
                divpm2.Visible = false;
                Div3.Visible = false;
                //Div2.Visible = false;
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
            string now = Nowday + "-" + Nowmonth.ToString() + "-" + Nowyear.ToString();
            string MonthFullList = "ตุลาคม-มกราคม-กุมภาพันธ์-มีนาคม-เมษายน-พฤษภาคม-มิถุนายน-กรกฎาคม-สิงหาคม-กันยายน-ตุลาคม-พฤศจิกายน-ธันวาคม";
            string[] MonthList = MonthFullList.Split('-');

            int Nowbudget = 0;
            if (Nowmonth > 9)
            {
                Nowbudget = Nowyear + 1;
            }

            string CMsqlDay = "SELECT COUNT(*) AS numd FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_cpoint = '" + Session["UserCpoint"] + "' AND cm_detail_sdate ='"+ now +"' ";
            string CMsqlMonth = "SELECT COUNT(*) AS numm FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_cpoint = '" + Session["UserCpoint"] + "' AND cm_budget = '" + Nowbudget + "' ";
            string CMsqlBudget = "SELECT COUNT(*) AS numb FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_cpoint = '" + Session["UserCpoint"] + "' AND cm_budget = '"+ Nowbudget +"' ";
            string CMsqlOverall = "SELECT COUNT(*) AS numa FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_cpoint = '" + Session["UserCpoint"] + "' ";

            //แสดงเดือน ปี
            lbCMNameMonthly.Text = MonthList[i];
            string lbBudget = Nowbudget.ToString();
            lbCMNameBudget.Text = lbBudget;

            MySqlDataReader trdd = function.MySqlSelect(CMsqlDay);
            if (trdd.Read())
            {
                if (trdd.GetInt32("numd") != 0)
                {
                    lbCMStatDay.Text = trdd.GetInt32("numd").ToString();
                    trdd.Close();
                }
                else
                {
                    lbCMStatDay.Text = "0";
                    trdd.Close();
                }
            }
            function.Close();

            MySqlDataReader trmm = function.MySqlSelect(CMsqlMonth);
            if (trmm.Read())
            {
                if (trmm.GetInt32("numm") != 0)
                {
                    lbCMStatMonthly.Text = trmm.GetInt32("numm").ToString();
                    trmm.Close();
                }
                else
                {
                    lbCMStatMonthly.Text = "0";
                    trmm.Close();
                }
            }
            function.Close();

            MySqlDataReader trbg = function.MySqlSelect(CMsqlBudget);
            if (trbg.Read())
            {
                if (trbg.GetInt32("numb") != 0)
                {
                    lbCMStatBudget.Text = trbg.GetInt32("numb").ToString();
                    trbg.Close();
                }
                else
                {
                    lbCMStatBudget.Text = "0";
                    trbg.Close();
                }
            }
            function.Close();

            MySqlDataReader troa = function.MySqlSelect(CMsqlOverall);
            if (troa.Read())
            {
                if (troa.GetInt32("numa") != 0)
                {
                    lbCMStatOverall.Text = troa.GetInt32("numa").ToString();
                    troa.Close();
                }
                else
                {
                    lbCMStatOverall.Text = "0";
                    troa.Close();
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
            }

            Label lbAmount = (Label)(e.Row.FindControl("lbAmount"));
            if (lbAmount != null)
            {
                lbAmount.Text = (string)DataBinder.Eval(e.Row.DataItem, "num").ToString();
            }

        }

        protected void databind()
        {
            string cpoint = Session["UserCpoint"].ToString();
            string sqlLsTotal = "SELECT COUNT(cm_detail_driver_id) AS num , cm_detail_driver_id ,device_name " +
                " FROM tbl_cm_detail c JOIN tbl_device d ON c.cm_detail_driver_id = d.device_id " +
                " WHERE cm_cpoint = '"+ cpoint + "' GROUP BY cm_detail_driver_id ORDER BY COUNT(cm_detail_driver_id) DESC LIMIT 5 ";

            MySqlDataAdapter da = function.MySqlSelectDataSet(sqlLsTotal);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            lsTodayGridview.DataSource = ds.Tables[0];
            lsTodayGridview.DataBind();
            function.Close();
        }
    }
}