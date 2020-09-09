using ClaimProject.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using System.Configuration;
using System.Drawing;


namespace ClaimProject.equip
{
    public partial class EquipDefault : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/");
            }
            if (!this.IsPostBack)
            {
                if (Session["UserPrivilegeId"].ToString() == "5")
                {
                    if (Session["User"].ToString() != "supaporn" && Session["User"].ToString() != "watcharee" && Session["User"].ToString() != "sawitree" && Session["User"].ToString() != "yuiequip")
                    {
                        div1.Visible = false;
                        div2.Visible = false;
                        div4.Visible = false;
                        div6.Visible = false;
                    }
                    
                }               
                   // Session.Add("BackWhat", "");
                    Session.Add("LineTran", "");
                    loadingpage();
            }

        }
        
        protected void loadingpage()
        {

            function.getListItem(txtBudgetYear, "SELECT trans_budget FROM tbl_transfer GROUP BY trans_budget ORDER BY trans_budget DESC", "trans_budget", "trans_budget");
            string newTran = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE complete_stat = '2' AND user_send ='" + Session["UserName"].ToString() + "' ";
            string newTranact = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE complete_stat = '2' AND num_success = 'no' AND user_send ='" + Session["UserName"].ToString() + "' ";
            string sqlcpSearch = "";


            if (Session["UserCpoint"].ToString() == "0")
            {
                if(Session["User"].ToString() == "sawitree")
                {
                    sqlcpSearch += " 7010' OR toll_send = '9010' OR toll_send = '9020' OR toll_send ='9030' OR toll_send ='9040 ";
                }
                else if (Session["User"].ToString() == "supaporn")
                {
                    sqlcpSearch += " 7020' OR toll_send = '7031' OR toll_send = '7032' OR toll_send = '7033' OR toll_send = '7041' OR toll_send = '7042' OR toll_send = '7051' OR toll_send = '7052'" +
                        "OR toll_send ='7061' OR toll_send = ' 7062 ' OR toll_send = ' 7063 ' OR toll_send = ' 7064 ";
                }
            }
            else if (Session["UserCpoint"].ToString() == "701")
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

            MySqlDataReader ttr = function.MySqlSelect(newTran);

            if (ttr.Read())
            {
                if (ttr.GetInt32("num") != 0)
                {
                    lbnew.ForeColor = System.Drawing.Color.Red;
                    lbnew.Text = ttr.GetInt32("num").ToString() + " รายการ";
                    ttr.Close();
                }
                else
                {
                    lbnew.Text = ttr.GetInt32("num").ToString() + " รายการ";
                    ttr.Close();
                }            
                
                MySqlDataReader tract = function.MySqlSelect(newTranact);
                if (tract.Read())
                {
                    if (tract.GetInt32("devv") != 0)
                    {
                        lbnew1.ForeColor = System.Drawing.Color.Red;
                        lbnew1.Text = tract.GetInt32("devv").ToString() + " อุปกรณ์";
                        tract.Close();
                    }
                    else
                    {
                        lbnew1.Text = tract.GetInt32("devv").ToString() + " อุปกรณ์";
                        tract.Close();
                    }
                        
                }
            }



            string tran = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE trans_stat = '1' AND complete_stat = '3' AND user_send ='" + Session["UserName"].ToString() + "' ";
            string tranact = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE tran_type = '1' AND num_success = 'yes' AND user_send ='" + Session["UserName"].ToString() + "' ";
            MySqlDataReader tr = function.MySqlSelect(tran);
            if(tr.Read())
            {
                lbTran.Text = tr.GetInt32("num").ToString() + " รายการ";
                tr.Close();
                MySqlDataReader tract = function.MySqlSelect(tranact);
                if(tract.Read())
                {
                    lbTran2.Text = tract.GetInt32("devv").ToString() + " อุปกรณ์";
                    tract.Close();
                }
            }

            string send = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE trans_stat = '6' AND complete_stat = '3'  AND user_send ='" + Session["UserName"].ToString() + "' ";
            string sendact = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE tran_type = '6' AND num_success = 'yes' AND user_send ='" + Session["UserName"].ToString() + "' ";
            MySqlDataReader snd = function.MySqlSelect(send);
            if (snd.Read())
            {
                lbSendHead.Text = snd.GetInt32("num").ToString() + " รายการ";
                snd.Close();
                MySqlDataReader sndact = function.MySqlSelect(sendact);
                if (sndact.Read())
                {
                    lbSendHead2.Text = sndact.GetInt32("devv").ToString() + " อุปกรณ์";
                    sndact.Close();
                }
            }

            string sell = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE trans_stat = '3' AND complete_stat = '3' AND user_send ='" + Session["UserName"].ToString() + "' ";
            string sellact = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE tran_type = '3' AND num_success = 'yes' AND user_send ='" + Session["UserName"].ToString() + "' ";
            MySqlDataReader see = function.MySqlSelect(sell);
            if (see.Read())
            {
                lbSell.Text = see.GetInt32("num").ToString() + " รายการ";
                see.Close();
                MySqlDataReader sella = function.MySqlSelect(sellact);
                if (sella.Read())
                {
                    lbSell2.Text = sella.GetInt32("devv").ToString() + " อุปกรณ์";
                    sella.Close();
                }

            }

            string rep = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE trans_stat = '4' AND complete_stat = '3' AND user_send ='" + Session["UserName"].ToString() + "' ";
            string repact = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE tran_type = '4' AND num_success = 'yes' AND user_send ='" + Session["UserName"].ToString() + "' ";
            MySqlDataReader ree = function.MySqlSelect(rep);
            if (ree.Read())
            {
                lbRepair.Text = ree.GetInt32("num").ToString() + " รายการ";
                ree.Close();
                MySqlDataReader reeact = function.MySqlSelect(repact);
                if (reeact.Read())
                {
                    lbRepair2.Text = reeact.GetInt32("devv").ToString() + " อุปกรณ์";
                    reeact.Close();
                }

            }

            string copy = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE trans_stat = '5' AND complete_stat = '3' AND user_send ='" + Session["UserName"].ToString() + "' ";
            string copact = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE tran_type = '5' AND num_success = 'yes' AND user_send ='" + Session["UserName"].ToString() + "' ";
            MySqlDataReader pee = function.MySqlSelect(copy);
            if (pee.Read())
            {
                lbCopy.Text = pee.GetInt32("num").ToString() + " รายการ";
                pee.Close();
                MySqlDataReader peeact = function.MySqlSelect(copact);
                if (peeact.Read())
                {
                    lbCopy2.Text = peeact.GetInt32("devv").ToString() + " อุปกรณ์";
                    peeact.Close();
                }

            }

            string seee = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE trans_stat = '2' AND complete_stat = '3' AND user_send ='" + Session["UserName"].ToString() + "' ";
            string seeer = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE tran_type = '2' AND num_success = 'yes' AND user_send ='" + Session["UserName"].ToString() + "' ";
            MySqlDataReader sert = function.MySqlSelect(seee);
            if (sert.Read())
            {
                Label2.Text = sert.GetInt32("num").ToString() + " รายการ";
                pee.Close();
                MySqlDataReader seeact = function.MySqlSelect(seeer);
                if (seeact.Read())
                {
                    Label3.Text = seeact.GetInt32("devv").ToString() + " อุปกรณ์";
                    seeact.Close();
                }

            }

            string seeto = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE complete_stat BETWEEN '1' AND '3' AND user_send ='" + Session["UserName"].ToString() + "' ";
            string seetot = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE user_send ='" + Session["UserName"].ToString() + "' ";
            MySqlDataReader seert = function.MySqlSelect(seeto);
            if (seert.Read())
            {
                lbTotal.Text = seert.GetInt32("num").ToString() + " รายการ";
                seert.Close();
                MySqlDataReader seeeer = function.MySqlSelect(seetot);
                if (seeeer.Read())
                {
                    lbTotal2.Text = seeeer.GetInt32("devv").ToString() + " อุปกรณ์";
                    seeeer.Close();
                }

            }

            string seereceipt = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE complete_stat = '2' AND (toll_send ='" + sqlcpSearch + "') ";
            string seereceiptt = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE complete_stat = '2' AND (toll_send ='" + sqlcpSearch + "') ";
            MySqlDataReader seerre = function.MySqlSelect(seereceipt);
            if (seerre.Read())
            {
                lbreceive.Text = seerre.GetInt32("num").ToString() + " รายการ";
                seerre.Close();
                MySqlDataReader seeeere = function.MySqlSelect(seereceiptt);
                if (seeeere.Read())
                {
                    lbreceive2.Text = seeeere.GetInt32("devv").ToString() + " อุปกรณ์";
                    seeeere.Close();
                }

            }

            loadChart();

        }
        protected void loadChart ()
        {
            int Nowmonth = int.Parse(DateTime.Now.ToString("MM"));

              int nowBudget = int.Parse(function.getBudgetYear("01-" + DateTime.Now.ToString("MM") + "-" + (DateTime.Now.Year + 543).ToString()));
              string budgetss = txtBudgetYear.Text;
              string MonthFullList = "ตุลาคม-มกราคม-กุมภาพันธ์-มีนาคม-เมษายน-พฤษภาคม-มิถุนายน-กรกฎาคม-สิงหาคม-กันยายน-ตุลาคม-พฤศจิกายน-ธันวาคม";
              string[] MonthList = MonthFullList.Split('-');
              string ChartQuery = " SELECT IFNULL(c.thai_month,'ตุลาคม') AS 'monthx' "
                                    + ", COUNT(CASE WHEN c.trans_stat = 1 THEN c.trans_id END) 'tran'"
                                    + ", COUNT(CASE WHEN c.trans_stat = 2 THEN c.trans_id END) 'sendde'"
                                    + ", COUNT(CASE WHEN c.trans_stat = 3 THEN c.trans_id END) 'selle'"
                                    + ", COUNT(CASE WHEN c.trans_stat = 4 THEN c.trans_id END) 'Repairr'"
                                    + ", COUNT(CASE WHEN c.trans_stat = 5 THEN c.trans_id END) 'copy'"
                                    + ", COUNT(CASE WHEN c.trans_stat = 6 THEN c.trans_id END) 'sendhe'"
                                    + " FROM tbl_transfer c "
                                    + " WHERE c.thai_month = 'ตุลาคม' AND c.trans_budget = '" + budgetss + "'  AND c.complete_stat != '1' "
                                    + " UNION SELECT IFNULL(c.thai_month,'พฤศจิกายน') AS 'monthx' "
                                    + ", COUNT(CASE WHEN c.trans_stat = 1 THEN c.trans_id END) 'tran'"
                                    + ", COUNT(CASE WHEN c.trans_stat = 2 THEN c.trans_id END) 'sendde'"
                                    + ", COUNT(CASE WHEN c.trans_stat = 3 THEN c.trans_id END) 'selle'"
                                    + ", COUNT(CASE WHEN c.trans_stat = 4 THEN c.trans_id END) 'Repairr'"
                                    + ", COUNT(CASE WHEN c.trans_stat = 5 THEN c.trans_id END) 'copy'"
                                    + ", COUNT(CASE WHEN c.trans_stat = 6 THEN c.trans_id END) 'sendhe'"
                                    + " FROM tbl_transfer c "
                                    + " WHERE c.thai_month = 'พฤศจิกายน' AND c.trans_budget = '" + budgetss + "'  AND c.complete_stat != '1' "
                                    + " UNION SELECT IFNULL(c.thai_month,'ธันวาคม') AS 'monthx' "
                                    + ", COUNT(CASE WHEN c.trans_stat = 1 THEN c.trans_id END) 'tran'"
                                    + ", COUNT(CASE WHEN c.trans_stat = 2 THEN c.trans_id END) 'sendde'"
                                    + ", COUNT(CASE WHEN c.trans_stat = 3 THEN c.trans_id END) 'selle'"
                                    + ", COUNT(CASE WHEN c.trans_stat = 4 THEN c.trans_id END) 'Repairr'"
                                    + ", COUNT(CASE WHEN c.trans_stat = 5 THEN c.trans_id END) 'copy'"
                                    + ", COUNT(CASE WHEN c.trans_stat = 6 THEN c.trans_id END) 'sendhe'"
                                    + " FROM tbl_transfer c "
                                    + " WHERE c.thai_month = 'ธันวาคม' AND c.trans_budget = '" + budgetss + "'  AND c.complete_stat != '1' ";
                                
                                if(Nowmonth < 10 )
                                {
                                    for(int i = 1 ; i <= Nowmonth ; i++ )
                                    {
                                        ChartQuery += " UNION SELECT IFNULL(c.thai_month,'" + MonthList[i] + "') AS 'monthx' "
                                                    + ", COUNT(CASE WHEN c.trans_stat = 1 THEN c.trans_id END) 'tran'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 2 THEN c.trans_id END) 'sendde'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 3 THEN c.trans_id END) 'selle'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 4 THEN c.trans_id END) 'Repairr'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 5 THEN c.trans_id END) 'copy'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 6 THEN c.trans_id END) 'sendhe'"
                                                    + " FROM tbl_transfer c "
                                                    + " WHERE c.thai_month = '" + MonthList[i] + "' AND c.trans_budget = '" + budgetss + "'  AND c.complete_stat != '1' ";
                                    }
                                }
                                else if(Nowmonth > 10)
                                {
                                    ChartQuery = " SELECT IFNULL(c.thai_month,'ตุลาคม') AS 'monthx' "
                                                    + ", COUNT(CASE WHEN c.trans_stat = 1 THEN c.trans_id END) 'tran'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 2 THEN c.trans_id END) 'sendde'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 3 THEN c.trans_id END) 'selle'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 4 THEN c.trans_id END) 'Repairr'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 5 THEN c.trans_id END) 'copy'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 6 THEN c.trans_id END) 'sendhe'"
                                                    + " FROM tbl_transfer c "
                                                    + " WHERE c.thai_month = 'ตุลาคม' AND c.trans_budget = '" + budgetss + "'  AND c.complete_stat != '1' ";
                                    for (int i = 1; i <= Nowmonth; i++)
                                    {
                                        ChartQuery += " UNION SELECT IFNULL(c.thai_month,'" + MonthList[i] + "') AS 'monthx' "
                                                    + ", COUNT(CASE WHEN c.trans_stat = 1 THEN c.trans_id END) 'tran'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 2 THEN c.trans_id END) 'sendde'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 3 THEN c.trans_id END) 'selle'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 4 THEN c.trans_id END) 'Repairr'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 5 THEN c.trans_id END) 'copy'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 6 THEN c.trans_id END) 'sendhe'"
                                                    + " FROM tbl_transfer c "
                                                    + " WHERE c.thai_month = '" + MonthList[i] + "' AND c.trans_budget = '" + budgetss + "'  AND c.complete_stat != '1' ";
                                    }
                                }
                                else
                                {
                                    ChartQuery = " SELECT IFNULL(c.thai_month,'ตุลาคม') AS 'monthx' "
                                                    + ", COUNT(CASE WHEN c.trans_stat = 1 THEN c.trans_id END) 'tran'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 2 THEN c.trans_id END) 'sendde'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 3 THEN c.trans_id END) 'selle'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 4 THEN c.trans_id END) 'Repairr'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 5 THEN c.trans_id END) 'copy'"
                                                    + ", COUNT(CASE WHEN c.trans_stat = 6 THEN c.trans_id END) 'sendhe'"
                                                    + " FROM tbl_transfer c "
                                                    + " WHERE c.thai_month = 'ตุลาคม' AND c.trans_budget = '" + budgetss + "'  AND c.complete_stat != '1' ";
                                }

            

    
              MySqlDataAdapter da = function.MySqlSelectDataSet(ChartQuery);
              DataSet ds = new DataSet();
              da.Fill(ds);
              Chart1.DataSource = ds.Tables[0];

              Chart1.Series["Series1"].ChartType = SeriesChartType.Line;
              Chart1.Series["Series1"].Color = Color.ForestGreen;
              Chart1.Series["Series1"].LabelForeColor = Color.ForestGreen;
              //Chart1.Series["Series1"].IsValueShownAsLabel = true;
              Chart1.Series["Series1"].XValueMember = "monthx";
              Chart1.Series["Series1"].YValueMembers = "tran";
                  Chart1.Series["Series2"].ChartType = SeriesChartType.Line;
                  Chart1.Series["Series2"].Color = Color.HotPink;
                  Chart1.Series["Series2"].LabelForeColor = Color.HotPink;
                  //Chart1.Series["Series2"].IsValueShownAsLabel = true;
                  Chart1.Series["Series2"].XValueMember = "monthx";
                  Chart1.Series["Series2"].YValueMembers = "sendde";
              Chart1.Series["Series3"].ChartType = SeriesChartType.Line;
              Chart1.Series["Series3"].Color = Color.DarkOrange;
              Chart1.Series["Series3"].LabelForeColor = Color.DarkOrange;
              //Chart1.Series["Series3"].IsValueShownAsLabel = true;
              Chart1.Series["Series3"].XValueMember = "monthx";
              Chart1.Series["Series3"].YValueMembers = "selle";
                    Chart1.Series["Series4"].ChartType = SeriesChartType.Line;
                    Chart1.Series["Series4"].Color = Color.DarkGray;
                    Chart1.Series["Series4"].LabelForeColor = Color.DarkGray;
                    //Chart1.Series["Series4"].IsValueShownAsLabel = true;
                    Chart1.Series["Series4"].XValueMember = "monthx";
                    Chart1.Series["Series4"].YValueMembers = "Repairr";
            Chart1.Series["Series5"].ChartType = SeriesChartType.Line;
            Chart1.Series["Series5"].Color = Color.DeepSkyBlue;
            Chart1.Series["Series5"].LabelForeColor = Color.DeepSkyBlue;
            //Chart1.Series["Series5"].IsValueShownAsLabel = true;
            Chart1.Series["Series5"].XValueMember = "monthx";
            Chart1.Series["Series5"].YValueMembers = "copy";
                Chart1.Series["Series6"].ChartType = SeriesChartType.Line;
                Chart1.Series["Series6"].Color = Color.Red;
                Chart1.Series["Series6"].LabelForeColor = Color.Red;
                //Chart1.Series["Series6"].IsValueShownAsLabel = true;
                Chart1.Series["Series6"].XValueMember = "monthx";
                Chart1.Series["Series6"].YValueMembers = "sendhe";

            Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
              Chart1.ChartAreas["ChartArea1"].BackColor = Color.White;
              Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
              Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
              Chart1.ChartAreas["ChartArea1"].AxisY.Title = "จำนวน";
              Chart1.DataBind(); 
        }
        
        protected void txtBudgetYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void lbtnTranDetail_Click(object sender, EventArgs e)
        {
            Session.Add("ddlsearchStat", "3");
            Session.Add("ddlsearchType", "1");
            Response.Redirect("/equip/EquipTranList");
        }

        protected void lbtnSendHeadDetail_Click(object sender, EventArgs e)
        {
            Session.Add("ddlsearchStat" , "0");
            Session.Add("ddlsearchType" , "6");
            Response.Redirect("/equip/EquipTranList");
        }

        protected void lbtnSellDetail_Click(object sender, EventArgs e)
        {
            Session.Add("ddlsearchType", "0");
            Session.Add("ddlsearchStat", "0");
            Response.Redirect("/equip/EquipTranList");
        }

        protected void lbtnRepairDetail_Click(object sender, EventArgs e)
        {
            Session.Add("ddlsearchType", "4");
            Session.Add("ddlsearchStat", "3");
            Response.Redirect("/equip/EquipTranList");
        }

        protected void lbtnCopyDetail_Click(object sender, EventArgs e)
        {
            Session.Add("ddlsearchType", "2"); //tran
            Session.Add("ddlsearchStat", "3"); //complete
            Response.Redirect("/equip/EquipTranList");
        }

        protected void btnMainEQtt_Click(object sender, EventArgs e)
        {
            Response.Redirect("/equip/EquipMain");
        }

        protected void lbtnNewTranDetail_Click(object sender, EventArgs e)
        {
            Session.Add("ddlsearchType" , "0");
            Session.Add("ddlsearchStat" , "2");
            Response.Redirect("/equip/EquipTranList");
        }

        protected void lbtnTotalDetail_Click(object sender, EventArgs e)
        {
            Session.Add("ddlsearchType", "0");
            Session.Add("ddlsearchStat", "0");
            Response.Redirect("/equip/EquipTranList");
        }

        protected void lbtnReceiveDetail_Click(object sender, EventArgs e)
        {

            Session.Add("ddlsearchStat", "2");
            Response.Redirect("/equip/EquipTranGetList");
        }
    }
}