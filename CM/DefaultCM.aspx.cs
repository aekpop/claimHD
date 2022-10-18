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
        public string NowDate = DateTime.Now.ToString("dd-MM") + "-" + (DateTime.Now.Year + 543);
        public string sqlcp = "";
        public string cpoint = "";
        public string point = "";
        public string sqlmonth = "";
        public string sqlnofix = "";
        public string chkAdmin = "";
        public string agency_id = "";
        public string cpoint_id = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                Response.Redirect("/");
            }
            if (!this.IsPostBack)
            {
                sqlmonth = Nowmonth + "-" + Nowyear;
                ddlCMNameMonthly.Items.Insert(0, new ListItem("เลือก", "0"));
                ddlCMNameMonthly.Items.Insert(1, new ListItem("มกราคม", "1"));
                ddlCMNameMonthly.Items.Insert(2, new ListItem("กุมภาพันธ์", "2"));
                ddlCMNameMonthly.Items.Insert(3, new ListItem("มีนาคม", "3"));
                ddlCMNameMonthly.Items.Insert(4, new ListItem("เมษายน", "4"));
                ddlCMNameMonthly.Items.Insert(5, new ListItem("พฤษภาคม", "5"));
                ddlCMNameMonthly.Items.Insert(6, new ListItem("มิถุนายน", "6"));
                ddlCMNameMonthly.Items.Insert(7, new ListItem("กรกฎาคม", "7"));
                ddlCMNameMonthly.Items.Insert(8, new ListItem("สิงหาคม", "8"));
                ddlCMNameMonthly.Items.Insert(9, new ListItem("กันยายน", "9"));
                ddlCMNameMonthly.Items.Insert(10, new ListItem("ตุลาคม", "10"));
                ddlCMNameMonthly.Items.Insert(11, new ListItem("พฤศจิกายน", "11"));
                ddlCMNameMonthly.Items.Insert(12, new ListItem("ธันวาคม", "12"));
            }

            if (function.CheckLevel("Department", Session["UserPrivilegeId"].ToString()))
            {
                chkAdmin = "1";
                Div6.Visible = true;
                sqlcp = " ";
                cpoint = " ";
                point = " ";
                //sqlmonth = " WHERE cm_detail_sdate LIKE '%" + Nowmonth + "-" + Nowyear + "' ";
                sqlnofix = " WHERE cm_detail_status_id = '0' ";
            }
            else
            {
                chkAdmin = "0";
                Div6.Visible = false;
                //divpm.Visible = false;
                //divpm2.Visible = false;
                //Div3.Visible = false;
                //Div2.Visible = false;
                sqlcp = "AND cm_cpoint = " + Session["UserCpoint"] + " ";
                cpoint = " WHERE cm_cpoint = " + Session["UserCpoint"] + " ";
                //sqlmonth = "AND cm_detail_sdate LIKE '%" + Nowmonth + "-" + Nowyear + "' ";
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
            int chk = ddlCMNameMonthly.SelectedIndex;
            if (chk == 0)
            {
                i = Nowmonth;
                ddlCMNameMonthly.SelectedIndex = i;
            }
            else
            {
                i = chk;
                sqlmonth = i + "-" + Nowyear;
            }

            //string now = Nowday + "-" + i + "-" + Nowyear.ToString();
            string MonthFullList = "KKK-มกราคม-กุมภาพันธ์-มีนาคม-เมษายน-พฤษภาคม-มิถุนายน-กรกฎาคม-สิงหาคม-กันยายน-ตุลาคม-พฤศจิกายน-ธันวาคม";
            string[] MonthList = MonthFullList.Split('-');

            //แสดงเดือน ปี
            //lbCMNameMonthly.Text = MonthList[i];

            lbdateShow.Text = "วันนี้";

            int Nowbudget = 0;
            if (i > 9)
            {
                Nowbudget = Nowyear + 1;
            }
            else
            {
                Nowbudget = Nowyear;
            }

            string mYconn = i + "-" + Nowyear;

            

            string CMsqlDay = "SELECT COUNT(*) AS numd FROM tbl_cm_detail WHERE cm_detail_status_id != '9' " + sqlcp + " " + point + " AND cm_detail_sdate = '" + NowDate + "' ";
            string CMsqlMonth = "SELECT COUNT(*) AS numm FROM tbl_cm_detail WHERE cm_detail_status_id != '9' " + sqlcp + " " + point + " AND cm_budget = '" + Nowbudget + "' AND cm_detail_sdate LIKE '%" + mYconn + "' ";
            string CMsqlBudget = "SELECT COUNT(*) AS numb FROM tbl_cm_detail WHERE cm_detail_status_id != '9' " + sqlcp + " " + point + "AND cm_budget = '" + Nowbudget + "' ";
            string CMsqlOverall = "SELECT COUNT(*) AS numa FROM tbl_cm_detail WHERE cm_detail_status_id != '9' " + sqlcp + " " + point + " ";
            //ค้างซ่อม
            string CMsqlDayNot = "SELECT COUNT(*) AS numdn FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_detail_status_id != '2' " + sqlcp + " " + point + " AND cm_detail_sdate ='" + NowDate + "' ";
            string CMsqlMonthNot = "SELECT COUNT(*) AS nummn FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_detail_status_id != '2' " + sqlcp + " " + point + "AND cm_budget = '" + Nowbudget + "' AND cm_detail_sdate LIKE '%" + mYconn + "' ";
            string CMsqlBudgetNot = "SELECT COUNT(*) AS numbn FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_detail_status_id != '2' " + sqlcp + " " + point + "AND cm_budget = '" + Nowbudget + "' ";
            string CMsqlOverallNot = "SELECT COUNT(*) AS numan FROM tbl_cm_detail WHERE cm_detail_status_id != '9' AND cm_detail_status_id != '2' " + sqlcp + " " + point + " ";

            string CMsqlFixbacktoday = "SELECT COUNT(*) AS numfd FROM tbl_cm_detail WHERE cm_detail_status_id = '2' " + sqlcp + " " + point + "AND cm_detail_edate = '" + NowDate + "' ";
            string CMsqlFixbackMouth = "SELECT COUNT(*) AS numfm FROM tbl_cm_detail WHERE cm_detail_status_id = '2' " + sqlcp + " " + point + "AND cm_budget = '" + Nowbudget + "' AND cm_detail_edate LIKE '%" + mYconn + "' ";
            string CMsqlFixbackYear = "SELECT COUNT(*) AS numfy FROM tbl_cm_detail WHERE cm_detail_status_id = '2' " + sqlcp + " " + point + "AND cm_budget = '" + Nowbudget + "' ";
            string CMsqlFixbackOverall = "SELECT COUNT(*) AS numfo FROM tbl_cm_detail WHERE cm_detail_status_id = '2' " + sqlcp + " " + point + " ";

            string CMsqlnoFixbacktoday = "SELECT COUNT(*) AS numnofd FROM tbl_cm_detail WHERE cm_detail_status_id = '3' " + sqlcp + " " + point + "AND cm_detail_edate = '" + NowDate + "' ";
            string CMsqlnoFixbackMouth = "SELECT COUNT(*) AS numnofm FROM tbl_cm_detail WHERE cm_detail_status_id = '3' " + sqlcp + " " + point + "AND cm_budget = '" + Nowbudget + "' AND cm_detail_edate LIKE '%" + mYconn + "' ";
            string CMsqlnoFixbackYear = "SELECT COUNT(*) AS numnofy FROM tbl_cm_detail WHERE cm_detail_status_id = '3' " + sqlcp + " " + point + "AND cm_budget = '" + Nowbudget + "' ";
            string CMsqlnoFixbackOverall = "SELECT COUNT(*) AS numnofo FROM tbl_cm_detail WHERE cm_detail_status_id = '3' " + sqlcp + " " + point + " ";

            lbMAtoll.Text = function.GetSelectValue("tbl_drive_group", "drive_group_id='1'", "drive_group_agency");
            lbHq.Text = function.GetSelectValue("tbl_drive_group", "drive_group_id='3'", "drive_group_agency");
            lbAsset.Text = function.GetSelectValue("tbl_drive_group", "drive_group_id='2'", "drive_group_agency");
            lbAir.Text = function.GetSelectValue("tbl_drive_group", "drive_group_id='4'", "drive_group_agency");


            string CMSqlPending = "CALL GetCM_Pending(" + chkAdmin + " ,'" + Session["UserCpoint"] + "' , 1)";
            MySqlDataReader rd = function.MySqlSelect(CMSqlPending);
            if (rd.Read())
            {
                lbAmoMAtoll.Text = rd.GetInt32("num").ToString();
                rd.Close();
            }

            CMSqlPending = "CALL GetCM_Pending(" + chkAdmin + " ,'" + Session["UserCpoint"] + "' , 2)";
            MySqlDataReader rs = function.MySqlSelect(CMSqlPending);
            if (rs.Read())
            {
                lbAmoMAasset.Text = rs.GetInt32("num").ToString();
                rs.Close();
            }

            CMSqlPending = "CALL GetCM_Pending(" + chkAdmin + " ,'" + Session["UserCpoint"] + "' , 3)";
            MySqlDataReader rss = function.MySqlSelect(CMSqlPending);
            if (rss.Read())
            {
                lbAmoMAhq.Text = rss.GetInt32("num").ToString();
                rss.Close();
            }

            CMSqlPending = "CALL GetCM_Pending(" + chkAdmin + " ,'" + Session["UserCpoint"] + "' , 4)";
            MySqlDataReader rrss = function.MySqlSelect(CMSqlPending);
            if (rrss.Read())
            {
                lbAmoMAair.Text = rrss.GetInt32("num").ToString();
                rrss.Close();
            }

            //notication survey
            string sqlNotiSur = "SELECT COUNT(*) AS numnoS FROM tbl_cm_detail WHERE cm_detail_status_id = '1' ";

            lbTop5CMMonthly.Text = MonthList[i];
            string lbBudget = Nowbudget.ToString();
            lbCMNameBudget.Text = lbBudget;

            MySqlDataReader trdd = function.MySqlSelect(CMsqlDay);
            if (trdd.Read())
            {
                lbCMStatDay.Text = trdd.GetInt32("numd").ToString();
                trdd.Close();
            }
            function.Close();

            MySqlDataReader trmm = function.MySqlSelect(CMsqlMonth);
            if (trmm.Read())
            {
                lbCMStatMonthly.Text = trmm.GetInt32("numm").ToString();
                trmm.Close();
            }
            function.Close();

            MySqlDataReader trbg = function.MySqlSelect(CMsqlBudget);
            if (trbg.Read())
            {
                lbCMStatBudget.Text = trbg.GetInt32("numb").ToString();
                trbg.Close();
            }
            function.Close();

            MySqlDataReader troa = function.MySqlSelect(CMsqlOverall);
            if (troa.Read())
            {
                lbCMStatOverall.Text = troa.GetInt32("numa").ToString();
                troa.Close();
            }
            function.Close();

            MySqlDataReader trfd = function.MySqlSelect(CMsqlFixbacktoday);
            if (trfd.Read())
            {
                if (trfd.GetInt32("numfd") != 0)
                {
                    MySqlDataReader trnofd = function.MySqlSelect(CMsqlnoFixbacktoday);
                    if (trnofd.Read())
                    {
                        if (trnofd.GetInt32("numnofd") != 0)
                        {
                            lbFixBack.Text = trfd.GetInt32("numfd").ToString() + " / " + trnofd.GetInt32("numnofd").ToString();
                            trfd.Close();
                            trnofd.Close();
                        }
                        else
                        {
                            lbFixBack.Text = trfd.GetInt32("numfd").ToString() + " / 0 ";
                            trfd.Close();
                            trnofd.Close();
                        }
                    }
                }
                else
                {
                    lbFixBack.Text = "0 / 0";
                    trfd.Close();
                }
            }
            function.Close();

            MySqlDataReader trfm = function.MySqlSelect(CMsqlFixbackMouth);
            if (trfm.Read())
            {
                MySqlDataReader trnofm = function.MySqlSelect(CMsqlnoFixbackMouth);
                if (trnofm.Read())
                {
                    lbFixbackMonth.Text = trfm.GetInt32("numfm").ToString() + " / " + trnofm.GetInt32("numnofm").ToString();
                    trfm.Close();
                    trnofm.Close();
                }
            }
            function.Close();

            MySqlDataReader trfy = function.MySqlSelect(CMsqlFixbackYear);
            if (trfy.Read())
            {
                MySqlDataReader trnofy = function.MySqlSelect(CMsqlnoFixbackYear);
                if (trnofy.Read())
                {
                    lbFixbackyear.Text = trfy.GetInt32("numfy").ToString() + " / " + trnofy.GetInt32("numnofy").ToString();
                    trnofy.Close();
                    trfy.Close();
                }
            }
            function.Close();

            MySqlDataReader trfo = function.MySqlSelect(CMsqlFixbackOverall);
            if (trfo.Read())
            {
                MySqlDataReader trnofo = function.MySqlSelect(CMsqlnoFixbackOverall);
                if (trnofo.Read())
                {
                    lbFixbackOverall.Text = trfo.GetInt32("numfo").ToString() + " / " + trnofo.GetInt32("numnofo").ToString();
                    trfo.Close();
                    trnofo.Close();
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
            string sqlLsTotal = "CALL GetCM_LsTodayResult(" + chkAdmin + " ,'" + Session["UserCpoint"] + "')";

            MySqlDataAdapter da = function.MySqlSelectDataSet(sqlLsTotal);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            lsTodayGridview.DataSource = ds.Tables[0];
            lsTodayGridview.DataBind();
            function.Close();

            string sqlTopMoTotal = "CALL GetCM_TopMoTotal(" + chkAdmin + " ,'" + Session["UserCpoint"] + "','" + sqlmonth + "')";

            MySqlDataAdapter dA = function.MySqlSelectDataSet(sqlTopMoTotal);
            System.Data.DataSet dS = new System.Data.DataSet();
            dA.Fill(dS);
            GridViewNoService.DataSource = dS.Tables[0];
            GridViewNoService.DataBind();
            function.Close();

            string sqlNofix = "CALL GetCM_NofixResult(" + chkAdmin + " ,'" + Session["UserCpoint"] + "')";

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
                lbnofixDevice.ToolTip = DataBinder.Eval(e.Row.DataItem, "device_name").ToString() + " " + locate;
            }
        }

        protected void lbtnMa_Command(object sender, CommandEventArgs e)
        {
            agency_id = "1";
            cpoint_id = Session["UserCpoint"].ToString();
            viewpage();
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('/CM/CMReport?agency=" + agency_id + "&" + "cpoint=" + cpoint_id + "','_newtab');", true);
        }

        protected void lbCMNameMonthly_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lbtnAir_Command(object sender, CommandEventArgs e)
        {
            agency_id = "4";
            cpoint_id = Session["UserCpoint"].ToString();
            viewpage();
        }

        protected void lbtnAsset_Command(object sender, CommandEventArgs e)
        {
            agency_id = "2";
            cpoint_id = Session["UserCpoint"].ToString();
            viewpage();
        }

        protected void lbtnHq_Command(object sender, CommandEventArgs e)
        {
            agency_id = "3";
            cpoint_id = Session["UserCpoint"].ToString();
            viewpage();
        }

        void viewpage()
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('/CM/CMReport?agency=" + agency_id + "&" + "cpoint=" + cpoint_id + "','_newtab');", true);
        }
    }
}