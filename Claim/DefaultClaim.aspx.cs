using ClaimProject.Config;
using Microsoft.Diagnostics.Instrumentation.Extensions.Intercept;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimProject.Claim
{
    public partial class DefaultClaim : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public int Nowmonth = int.Parse(DateTime.Now.ToString("MM"));
        public int Nowyear = int.Parse((DateTime.Now.Year + 543).ToString());
        public string sqlcp = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] == null)
            {
                Response.Redirect("/");
            }
            if (!this.IsPostBack)
            {
                if (function.CheckLevel("Department", Session["UserPrivilegeId"].ToString()))
                { sqlcp = " "; } else { sqlcp = "AND claim_cpoint = " + Session["UserCpoint"] + " "; }
                loadingpage();
                //GetChartData();
            }
        }

        protected void loadingpage()
        {
            //string sqlConst = "";
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
            string MonthFullList = "ตุลาคม-มกราคม-กุมภาพันธ์-มีนาคม-เมษายน-พฤษภาคม-มิถุนายน-กรกฎาคม-สิงหาคม-กันยายน-ตุลาคม-พฤศจิกายน-ธันวาคม";
            string[] MonthList = MonthFullList.Split('-');

            int Nowbudget = 0;
            if (Nowmonth > 9)
            {
                Nowbudget = Nowyear + 1;
            }

            string ClMouthly = "SELECT COUNT(*) AS numm FROM tbl_claim WHERE claim_delete = 0 " + sqlcp + " AND claim_budget_year = '" + Nowbudget + "' AND claim_month = '" + MonthList[i] + "' ";
            string ClBudget = "SELECT COUNT(*) AS numb FROM tbl_claim WHERE claim_delete = 0 " + sqlcp + " AND claim_budget_year = '" + Nowbudget + "' ";
            string ClAllDay = "SELECT COUNT(*) AS numa FROM tbl_claim WHERE claim_delete = 0 " + sqlcp + " ";

            string sqltotalSta1 = "SELECT COUNT(*) AS numTo1 FROM tbl_claim WHERE claim_delete = 0 " + sqlcp + " AND claim_status = 1 ";
            string sqltotalSta2 = "SELECT COUNT(*) AS numTo2 FROM tbl_claim WHERE claim_delete = 0 " + sqlcp + " AND claim_status = 2 ";
            string sqltotalSta3 = "SELECT COUNT(*) AS numTo3 FROM tbl_claim WHERE claim_delete = 0 " + sqlcp + " AND claim_status = 3 ";
            string sqltotalSta4 = "SELECT COUNT(*) AS numTo4 FROM tbl_claim WHERE claim_delete = 0 " + sqlcp + " AND claim_status = 4 ";
            string sqltotalSta5 = "SELECT COUNT(*) AS numTo5 FROM tbl_claim WHERE claim_delete = 0 " + sqlcp + " AND claim_status = 5 ";
            string sqltotalSta6 = "SELECT COUNT(*) AS numTo6 FROM tbl_claim WHERE claim_delete = 0 " + sqlcp + " AND claim_status = 6 ";

            //แสดงเดือน ปี
            lbClaimNameMonthly.Text = MonthList[i];
            string lbBudget = Nowbudget.ToString();
            lbClaimNameBudget.Text = lbBudget;


            MySqlDataReader tr = function.MySqlSelect(ClAllDay);
            if (tr.Read())
            {
                if (tr.GetInt32("numa") != 0)
                {
                    lbClaimStatOverall.Text = tr.GetInt32("numa").ToString();
                    tr.Close();
                }
                else
                {
                    lbClaimStatOverall.Text = "0";
                    tr.Close();
                }
            }
            function.Close();

            MySqlDataReader trbg = function.MySqlSelect(ClBudget);
            if (trbg.Read())
            {
                if (trbg.GetInt32("numb") != 0)
                {
                    lbClaimStatBudget.Text = trbg.GetInt32("numb").ToString();
                    trbg.Close();
                }
                else
                {
                    lbClaimStatBudget.Text = "0";
                    trbg.Close();
                }
            }
            function.Close();

            MySqlDataReader trmn = function.MySqlSelect(ClMouthly);
            if (trmn.Read())
            {
                if (trmn.GetInt32("numm") != 0)
                {
                    lbClaimStatMonthly.Text = trmn.GetInt32("numm").ToString();
                    trmn.Close();
                }
                else
                {
                    lbClaimStatMonthly.Text = "0";
                    trmn.Close();
                }
            }
            function.Close();

            MySqlDataReader st1 = function.MySqlSelect(sqltotalSta1);
            if (st1.Read())
            {
                if (st1.GetInt32("numTo1") != 0)
                {
                    lbTotalSta1.Text = st1.GetInt32("numTo1").ToString();
                    st1.Close();
                }
                else
                {
                    lbTotalSta1.Text = "0";
                    st1.Close();
                }
            }

            MySqlDataReader st2 = function.MySqlSelect(sqltotalSta2);
            if (st2.Read())
            {
                if (st2.GetInt32("numTo2") != 0)
                {
                    lbTotalSta2.Text = st2.GetInt32("numTo2").ToString();
                    st2.Close();
                }
                else
                {
                    lbTotalSta2.Text = "0";
                    st2.Close();
                }
            }

            MySqlDataReader st3 = function.MySqlSelect(sqltotalSta3);
            if (st3.Read())
            {
                if (st3.GetInt32("numTo3") != 0)
                {
                    lbTotalSta3.Text = st3.GetInt32("numTo3").ToString();
                    st3.Close();
                }
                else
                {
                    lbTotalSta3.Text = "0";
                    st3.Close();
                }
            }

            MySqlDataReader st4 = function.MySqlSelect(sqltotalSta4);
            if (st4.Read())
            {
                if (st4.GetInt32("numTo4") != 0)
                {
                    lbTotalSta4.Text = st4.GetInt32("numTo4").ToString();
                    st4.Close();
                }
                else
                {
                    lbTotalSta4.Text = "0";
                    st4.Close();
                }
            }

            MySqlDataReader st5 = function.MySqlSelect(sqltotalSta5);
            if (st5.Read())
            {
                if (st5.GetInt32("numTo5") != 0)
                {
                    lbTotalSta5.Text = st5.GetInt32("numTo5").ToString();
                    st5.Close();
                }
                else
                {
                    lbTotalSta5.Text = "0";
                    st5.Close();
                }
            }

            MySqlDataReader st6 = function.MySqlSelect(sqltotalSta6);
            if (st6.Read())
            {
                if (st6.GetInt32("numTo6") != 0)
                {
                    lbTotalSta6.Text = st6.GetInt32("numTo6").ToString();
                    st6.Close();
                }
                else
                {
                    lbTotalSta6.Text = "0";
                    st6.Close();
                }
            }
        }

        protected void GetChartData()
        {
            string query = "SELECT claim_cpoint, COUNT(claim_id) AS Amount";
            query += " FROM tbl_claim WHERE claim_budget_year = 2563 AND claim_delete = 0 GROUP BY claim_cpoint";
            
            
        
        }
    }
}