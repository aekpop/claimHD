using ClaimProject.Config;
using Microsoft.Diagnostics.Instrumentation.Extensions.Intercept;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace ClaimProject.Claim
{
    public partial class DefaultClaim : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public int Nowmonth = int.Parse(DateTime.Now.ToString("MM"));
        public int Nowyear = int.Parse((DateTime.Now.Year + 543).ToString());
        public string sqlcp = "";
        public string year = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "";
            if (Session["User"] == null)
            {
                Response.Redirect("/");
            }
            if (!this.IsPostBack)
            {
                sql = "SELECT claim_status AS stat , status_name FROM tbl_claim c JOIN tbl_device_damaged d ON c.`claim_id` = d.`claim_id` ";
                sql += "JOIN `tbl_device` t ON d.`device_id` = t.`device_id` JOIN `tbl_status` st ON c.`claim_status` = st.`status_id` ";

                if (function.CheckLevel("Department", Session["UserPrivilegeId"].ToString()))
                {
                    sqlcp = " ";
                    sql += " ";
                }
                else
                {
                    sqlcp = "AND claim_cpoint = " + Session["UserCpoint"] + " ";
                    sql += "WHERE claim_cpoint = '" + Session["UserCpoint"] + "'";
                }

                lbcpoint.Text = function.GetSelectValue("tbl_cpoint", "cpoint_id = '" + Session["UserCpoint"] + "' ", "cpoint_id");
                sql += " GROUP BY `claim_status` ";
                function.getListItem(ddlstatus, sql, "status_name", "status_name");
                loadingpage();
                //getLineChartData(ddlbudget.SelectedValue, Session["UserCpoint"].ToString());
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
            else
            {
                Nowbudget = Nowyear;
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

        protected void lbtnClaim_Command(object sender, CommandEventArgs e)
        {

        }

        //[WebMethod]
        //public static ChartData GetChartData()
        //{
        //    // Get the data from database.
        //    DataTable dt = new DataTable();
        //    dt.Columns.AddRange(new DataColumn[] {
        //new DataColumn("Month"),new DataColumn("Motorcycles"),new DataColumn("Bicycles") });
        //    dt.Rows.Add("January", 30, 65);
        //    dt.Rows.Add("February", 50, 60);
        //    dt.Rows.Add("March", 40, 81);
        //    dt.Rows.Add("April", 20, 80);
        //    dt.Rows.Add("May", 80, 60);
        //    dt.Rows.Add("June", 30, 60);

        //    ChartData chartData = new ChartData();
        //    chartData.Labels = dt.AsEnumerable().Select(x => x.Field<string>("Month")).ToArray();
        //    chartData.DatasetLabels = new string[] { "Motorcycles", "Bicycles" };
        //    List<int[]> datasetDatas = new List<int[]>();

        //    List<int> motorcycles = new List<int>();
        //    List<int> bicycles = new List<int>();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        motorcycles.Add(Convert.ToInt32(dr["Motorcycles"]));
        //        bicycles.Add(Convert.ToInt32(dr["Bicycles"]));
        //    }

        //    datasetDatas.Add(motorcycles.ToArray());
        //    datasetDatas.Add(bicycles.ToArray());
        //    chartData.DatasetDatas = datasetDatas;
        //    return chartData;
        //}

        //public class ChartData
        //{
        //    public string[] Labels { get; set; }
        //    public string[] DatasetLabels { get; set; }
        //    public List<int[]> DatasetDatas { get; set; }
        //}

        [WebMethod]
        public static List<object> getLineChartData(string status, string cp)
        {
            ClaimFunction function = new ClaimFunction();
            string sql = "";

            List<object> iData = new List<object>();
            List<string> labels = new List<string>();
            List<string> labels1 = new List<string>();

            string query1 = "SELECT claim_budget_year , COUNT(*) AS num FROM tbl_claim ";
                   query1 += "WHERE tbl_claim.`claim_delete` = '0' ";

            if (cp == "")
            {
                query1 += " GROUP BY claim_budget_year ORDER BY claim_budget_year DESC";
                cp = " ";
                sql = " WHERE claim_status = '5' ";               
            }
            else
            {
                query1 += "AND claim_cpoint = '" + cp + "' GROUP BY claim_budget_year ORDER BY claim_budget_year DESC";
                cp = "WHERE claim_cpoint = '" + cp + "' ";
                sql = " AND claim_status = '5' ";               
            }

            //First get distinct Month Name for select Year.
             
                   

            DataTable dtLabels = function.MySqlSelectDataTable(query1);
            foreach (DataRow drow in dtLabels.Rows)
            {
                labels.Add(drow["claim_budget_year"].ToString());
            }
            iData.Add(labels);

            //string query_DataSet_1 = " SELECT c.`claim_budget_year`,t.`device_initials`, COUNT(*) AS num FROM tbl_claim c JOIN tbl_device_damaged d ON c.`claim_id` = d.`claim_id` ";
            //       query_DataSet_1 += "JOIN `tbl_device` t ON d.`device_id` = t.`device_id` ";
            //       query_DataSet_1 += cp + "  GROUP BY d.`device_id` ORDER BY num DESC";

            DataTable dtDataItemsSets_1 = function.MySqlSelectDataTable(query1);
            List<int> lst_dataItem_1 = new List<int>();
            foreach (DataRow dr in dtDataItemsSets_1.Rows)
            {
                lst_dataItem_1.Add(Convert.ToInt32(dr["num"].ToString()));
            }
            iData.Add(lst_dataItem_1);

            string query_DataSet_2 = "SELECT a.claim_budget_year , COUNT(b.claim_budget_year) AS num ";
            query_DataSet_2 += "FROM (SELECT claim_id, claim_budget_year FROM tbl_claim WHERE tbl_claim.claim_delete = '0') a ";
            query_DataSet_2 += "LEFT JOIN ( SELECT claim_id, claim_budget_year FROM tbl_claim "+ cp + sql + ") b ";
            query_DataSet_2 += "ON a.claim_id = b.claim_id ";
            query_DataSet_2 += "GROUP BY a.claim_budget_year ORDER BY a.claim_budget_year DESC";
           
            DataTable dtDataItemsSets_2 = function.MySqlSelectDataTable(query_DataSet_2);

            //foreach (DataRow droww in dtDataItemsSets_2.Rows)
            //{
            //    labels1.Add(droww["claim_budget_year"].ToString());
            //}
            //iData.Add(labels1);

            List<int> lst_dataItem_2 = new List<int>();
            foreach (DataRow dr in dtDataItemsSets_2.Rows)
            {
                lst_dataItem_2.Add(Convert.ToInt32(dr["num"].ToString()));
            }
            iData.Add(lst_dataItem_2);
            return iData;
        }
    }
}