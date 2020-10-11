using ClaimProject.Config;
using Microsoft.Diagnostics.Instrumentation.Extensions.Intercept;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimProject.Claim
{
    public partial class DefaultClaim : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public int Nowmonth = int.Parse(DateTime.Now.ToString("MM"));
        public int Nowyear = int.Parse((DateTime.Now.Year + 543).ToString());

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] == null)
            {
                Response.Redirect("/");
            }
            if (!this.IsPostBack)
            {
                loadingpage();
            } 
        }

        protected void loadingpage()
        {
            string sqlConst = "";
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
            string MonthFullList = "ตุลาคม-มกราคม-กุมภาพันธ์-มีนาคม-เมษายน-พฤษภาคม-มิถุนายน-กรกฎาคม-สิงหาคม-กันยายน-ตุลาคม-พฤศจิกายน-ธันวาคม";
            string[] MonthList = MonthFullList.Split('-');

            int Nowbudget = 0;
            if (Nowmonth > 9)
            {
                Nowbudget = Nowyear + 1;
            }

            string ClMouthly = "SELECT COUNT(*) AS numm FROM tbl_claim WHERE claim_cpoint = '"+ Session["UserCpoint"] + "' AND claim_budget_year = '"+ Nowbudget +"' AND claim_month = '" + MonthList[i]+"' ";
            string ClBudget = "SELECT COUNT(*) AS numb FROM tbl_claim WHERE claim_cpoint = '" + Session["UserCpoint"] + "' AND claim_budget_year = '"+ Nowbudget +"' ";
            string ClAllDay = "SELECT COUNT(*) AS numa FROM tbl_claim WHERE claim_cpoint = '" + Session["UserCpoint"] + "' ";

            //แสดงเดือน ปี
            lbClaimNameMonthly.Text = MonthList[i];
            string lbBudget = Nowbudget.ToString();
            lbClaimNameBudget.Text = lbBudget;
            

            MySqlDataReader tr = function.MySqlSelect(ClAllDay);
            if (tr.Read())
            {
                if(tr.GetInt32("numa") != 0)
                {
                    lbClaimStatOverall.Text = tr.GetInt32("numa").ToString() ;
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
                    lbClaimStatBudget.Text = trbg.GetInt32("numb").ToString() ;
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
        }
    }
}