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
                if (Session["UserPrivilegeId"].ToString() == "5" || Session["UserPrivilegeId"].ToString() == "2")
                {
                    if (Session["User"].ToString() != "supaporn" && Session["User"].ToString() != "watcharee" && Session["User"].ToString() != "sawitree" && Session["User"].ToString() != "yuiequip")
                    {
                        div1.Visible = false;
                        div2.Visible = false;
                        div4.Visible = false;
                        div6.Visible = false;
                        tblClerical.Visible = false;
                        divaddnew.Visible = false;
                        divcheckk.Visible = false;
                        divcheckkk.Visible = false;
                    }
                    else
                    {
                        tblToll.Visible = false;
                    }
                    
                }   Session.Add("ddlsearchType", "0");
                    Session.Add("ddlsearchStat", "0");
                    Session.Add("BackWhat", "");            
                    Session.Add("LineTran", "");
                    Session["BackWhat"] = "";
                    loadingpage();
            }
        }

        protected void loadingpage()
        {

            function.getListItem(txtBudgetYear, "SELECT trans_budget FROM tbl_transfer GROUP BY trans_budget ORDER BY trans_budget DESC", "trans_budget", "trans_budget");
            string newTran = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE complete_stat = '2' AND user_send ='" + Session["UserName"].ToString() + "' ";
            string newTranact = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE complete_stat = '2' AND num_success = 'no' AND user_send ='" + Session["UserName"].ToString() + "' ";
            string sqlcpSearch = "";
            string sqlcpSearchtotal = "";
            string sqltran = "";
            string sqlUser = "";

            if (Session["UserCpoint"].ToString() == "0")
            {
                if (Session["User"].ToString() == "sawitree")
                {
                    sqlcpSearch += " 7010' OR toll_send = '9010' OR toll_send = '9020' OR toll_send ='9030' OR toll_send ='9040 ";
                    sqlcpSearchtotal = "7010' OR toll_id = '9010' OR toll_id = '9020' OR toll_id ='9030' OR toll_id ='9040 ";
                    sqltran = " 7010' OR tbl_transfer.toll_send = '9010' OR tbl_transfer.toll_send = '9020' OR tbl_transfer.toll_send ='9030' OR tbl_transfer.toll_send ='9040 ";
                    sqlUser = " AND user_send = '" + Session["UserName"].ToString() + "' ";
                }
                else if (Session["User"].ToString() == "supaporn")
                {
                    sqlcpSearch += " 7020' OR toll_send = '7031' OR toll_send = '7032' OR toll_send = '7033' OR toll_send = '7041' OR toll_send = '7042' OR toll_send = '7051' OR toll_send = '7052'" +
                        "OR toll_send ='7061' OR toll_send = ' 7062 ' OR toll_send = ' 7063 ' OR toll_send = ' 7064 ";
                    sqlcpSearchtotal = " 7020' OR toll_id = '7031' OR toll_id = '7032' OR toll_id = '7033' OR toll_id = '7041' OR toll_id = '7042' OR toll_id = '7051' OR toll_id = '7052'" +
                        "OR toll_id ='7061' OR toll_id = ' 7062 ' OR toll_id = ' 7063 ' OR toll_id = ' 7064 ";
                    sqltran = " 7020' OR tbl_transfer.toll_send = '7031' OR tbl_transfer.toll_send = '7032' OR tbl_transfer.toll_send = '7033' OR tbl_transfer.toll_send = '7041' OR tbl_transfer.toll_send = '7042' OR tbl_transfer.toll_send = '7051' OR tbl_transfer.toll_send = '7052'" +
                        "OR tbl_transfer.toll_send ='7061' OR tbl_transfer.toll_send = ' 7062 ' OR tbl_transfer.toll_send = ' 7063 ' OR tbl_transfer.toll_send = ' 7064 ";
                    sqlUser = " AND user_send = '" + Session["UserName"].ToString() + "' ";
                }
                else if (Session["User"].ToString() == "watcharee")
                {
                    sqlcpSearch += " 7071' OR toll_send = '7072' OR toll_send = '7073' OR toll_send = '7074' OR toll_send = '7075' OR toll_send = '7076' OR toll_send = '7081' OR toll_send = '7082'" +
                        "OR toll_send ='7083' OR toll_send = ' 7084 ' OR toll_send = ' 7090 ' OR toll_send = ' 7100 ' OR toll_send = ' 7110 ' OR toll_send = ' 7120 ";
                    sqlcpSearchtotal = " 7071' OR toll_id = '7072' OR toll_id = '7073' OR toll_id = '7074' OR toll_id = '7075' OR toll_id = '7076' OR toll_id = '7081' OR toll_id = '7082'" +
                        "OR toll_id ='7083' OR toll_id = ' 7084 ' OR toll_id = ' 7090 ' OR toll_id = ' 7100 ' OR toll_id = ' 7110 ' OR toll_id = ' 7120 ";
                    sqltran = " 7071' OR tbl_transfer.toll_send = '7072' OR tbl_transfer.toll_send = '7073' OR tbl_transfer.toll_send = '7074' OR tbl_transfer.toll_send = '7075' OR tbl_transfer.toll_send = '7076' OR tbl_transfer.toll_send = '7081' OR tbl_transfer.toll_send = '7082'" +
                        "OR tbl_transfer.toll_send ='7083' OR tbl_transfer.toll_send = ' 7084 ' OR tbl_transfer.toll_send = ' 7090 ' OR tbl_transfer.toll_send = ' 7100 ' OR tbl_transfer.toll_send = ' 7110 ' OR tbl_transfer.toll_send = ' 7120 ";
                    sqlUser = " AND user_send = '" + Session["UserName"].ToString() + "' ";
                }
                else
                {
                    sqlcpSearch += " 7010' OR toll_send = '9010' OR toll_send = '9020' OR toll_send ='9030' OR toll_send ='9040' OR toll_send ='7020' OR toll_send = '7031' OR toll_send = '7032' OR toll_send = '7033' OR toll_send = '7041' OR toll_send = '7042' OR toll_send = '7051' OR toll_send = '7052'" +
                        "OR toll_send ='7061' OR toll_send = ' 7062 ' OR toll_send = ' 7063 ' OR toll_send = '7064' OR toll_send = '7071' OR toll_send = '7072' OR toll_send = '7073' OR toll_send = '7074' OR toll_send = '7075' OR toll_send = '7076' OR toll_send = '7081' OR toll_send = '7082'" +
                        "OR toll_send ='7083' OR toll_send = ' 7084 ' OR toll_send = ' 7090 ' OR toll_send = ' 7100 ' OR toll_send = ' 7110 ' OR toll_send = ' 7120 ";
                    sqlcpSearchtotal = "7010' OR toll_id = '9010' OR toll_id = '9020' OR toll_id ='9030' OR toll_id ='9040' OR toll_id = '7020' OR toll_id = '7031' OR toll_id = '7032' OR toll_id = '7033' OR toll_id = '7041' OR toll_id = '7042' OR toll_id = '7051' OR toll_id = '7052'" +
                        "OR toll_id ='7061' OR toll_id = ' 7062 ' OR toll_id = ' 7063 ' OR toll_id = '7064' OR toll_id = '7071' OR toll_id = '7072' OR toll_id = '7073' OR toll_id = '7074' OR toll_id = '7075' OR toll_id = '7076' OR toll_id = '7081' OR toll_id = '7082'" +
                        "OR toll_id ='7083' OR toll_id = ' 7084 ' OR toll_id = ' 7090 ' OR toll_id = ' 7100 ' OR toll_id = ' 7110 ' OR toll_id = ' 7120 ";
                    sqltran = "7010' OR tbl_transfer.toll_send = '9010' OR tbl_transfer.toll_send = '9020' OR tbl_transfer.toll_send ='9030' OR tbl_transfer.toll_send ='9040' OR tbl_transfer.toll_send ='7020' OR tbl_transfer.toll_send = '7031' OR tbl_transfer.toll_send = '7032' OR tbl_transfer.toll_send = '7033' OR tbl_transfer.toll_send = '7041' OR tbl_transfer.toll_send = '7042' OR tbl_transfer.toll_send = '7051' OR tbl_transfer.toll_send = '7052'" +
                        "OR tbl_transfer.toll_send ='7061' OR tbl_transfer.toll_send = ' 7062 ' OR tbl_transfer.toll_send = ' 7063 ' OR tbl_transfer.toll_send = '7064' OR tbl_transfer.toll_send = '  7071' OR tbl_transfer.toll_send = '7072' OR tbl_transfer.toll_send = '7073' OR tbl_transfer.toll_send = '7074' OR tbl_transfer.toll_send = '7075' OR tbl_transfer.toll_send = '7076' OR tbl_transfer.toll_send = '7081' OR tbl_transfer.toll_send = '7082'" +
                        "OR tbl_transfer.toll_send ='7083' OR tbl_transfer.toll_send = ' 7084 ' OR tbl_transfer.toll_send = ' 7090 ' OR tbl_transfer.toll_send = ' 7100 ' OR tbl_transfer.toll_send = ' 7110 ' OR tbl_transfer.toll_send = ' 7120 ";
                    sqlUser = " ";
                }
            }
            else if (Session["UserCpoint"].ToString() == "701")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='7010 ";
                sqlcpSearchtotal = "7010 ";
                sqltran = "7010 ";
            }
            else if (Session["UserCpoint"].ToString() == "702")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='7020 ";
                sqlcpSearchtotal = "7020 ";
                sqltran = "7020 ";
            }
            else if (Session["UserCpoint"].ToString() == "703")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='7031' OR toll_recieve = '7032' OR toll_recieve = '7033";
                sqlcpSearchtotal = "7031' OR toll_id = '7032' OR toll_id = '7033";
                sqltran = "7031' OR tbl_transfer.toll_send = '7032' OR tbl_transfer.toll_send = '7033";
            }
            else if (Session["UserCpoint"].ToString() == "704")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='7041' OR toll_recieve = ' 7042 ";
                sqlcpSearchtotal = "7041' OR toll_id = '7042";
                sqltran = "7041' OR tbl_transfer.toll_send = '7042";
            }
            else if (Session["UserCpoint"].ToString() == "706")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='7051' OR toll_recieve = ' 7052 ";
                sqlcpSearchtotal = "7051' OR toll_id = '7052";
                sqltran = "7051' OR tbl_transfer.toll_send = '7052";
            }
            else if (Session["UserCpoint"].ToString() == "707")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='7061' OR toll_recieve = ' 7062 ' OR toll_recieve = ' 7063 ' OR toll_recieve = ' 7064 ";
                sqlcpSearchtotal = "7061' OR toll_id = ' 7062 ' OR toll_id = ' 7063 ' OR toll_id = ' 7064 ";
                sqltran = "7061' OR tbl_transfer.toll_send = ' 7062 ' OR tbl_transfer.toll_send = ' 7063 ' OR tbl_transfer.toll_send = ' 7064 ";
            }
            else if (Session["UserCpoint"].ToString() == "708")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='7071' OR toll_recieve = ' 7072 ' OR toll_recieve = ' 7073 ' OR toll_recieve = ' 7074 ' OR toll_recieve = ' 7075 ' OR toll_recieve = ' 7076 ";
                sqlcpSearchtotal = "7071' OR toll_id = ' 7072 ' OR toll_id = ' 7073 ' OR toll_id = ' 7074 ' OR toll_id = ' 7075 ' OR toll_id = ' 7076 ";
                sqltran = "7071' OR tbl_transfer.toll_send = ' 7072 ' OR tbl_transfer.toll_send = ' 7073 ' OR tbl_transfer.toll_send = ' 7074 ' OR tbl_transfer.toll_send = ' 7075 ' OR tbl_transfer.toll_send = ' 7076 ";
            }
            else if (Session["UserCpoint"].ToString() == "709")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='7081' OR toll_recieve = ' 7082 ' OR toll_recieve = ' 7083 ' OR toll_recieve = ' 7084 ";
                sqlcpSearchtotal = "7081' OR toll_id = ' 7082 ' OR toll_id = ' 7083 ' OR toll_id = ' 7084 ";
                sqltran = "7081' OR tbl_transfer.toll_send = ' 7082 ' OR tbl_transfer.toll_send = ' 7083 ' OR tbl_transfer.toll_send = ' 7084 ";
            }
            else if (Session["UserCpoint"].ToString() == "710")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='7090 ";
                sqlcpSearchtotal = "7090 ";
                sqltran = "7090 ";
            }
            else if (Session["UserCpoint"].ToString() == "711")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='7100 ";
                sqlcpSearchtotal = "7100 ";
                sqltran = "7100 ";
            }
            else if (Session["UserCpoint"].ToString() == "712")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='7110 ";
                sqlcpSearchtotal = "7110 ";
                sqltran = "7110 ";
            }
            else if (Session["UserCpoint"].ToString() == "713")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='7120 ";
                sqlcpSearchtotal = "7120 ";
                sqltran = "7120 ";
            }
            else if (Session["UserCpoint"].ToString() == "902")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='9010 ";
                sqlcpSearchtotal = "9010 ";
                sqltran = "9010 ";
            }
            else if (Session["UserCpoint"].ToString() == "903")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='9020 ";
                sqlcpSearchtotal = "9020 ";
                sqltran = "9020 ";
            }
            else if (Session["UserCpoint"].ToString() == "904")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='9030 ";
                sqlcpSearchtotal = "9030 ";
                sqltran = "9030 ";
            }
            else if (Session["UserCpoint"].ToString() == "905")
            {
                sqlcpSearch += " 9200' AND toll_recieve ='9040 ";
                sqlcpSearchtotal = "9040 ";
                sqltran = "9040 ";
            }

            MySqlDataReader ttr = function.MySqlSelect(newTran);

            if (ttr.Read())
            {
                if (ttr.GetInt32("num") != 0)
                {
                    lbnew.ForeColor = System.Drawing.Color.Red;
                    lbnew.Text = ttr.GetInt32("num").ToString();
                    ttr.Close();
                }
                else
                {
                    lbnew.Text = ttr.GetInt32("num").ToString();
                    ttr.Close();
                }

                MySqlDataReader tract = function.MySqlSelect(newTranact);
                if (tract.Read())
                {
                    if (tract.GetInt32("devv") != 0)
                    {
                        lbnew1.ForeColor = System.Drawing.Color.Red;
                        lbnew1.Text = tract.GetInt32("devv").ToString() + " รายการ";
                        tract.Close();
                    }
                    else
                    {
                        lbnew1.Text = tract.GetInt32("devv").ToString() + " รายการ";
                        tract.Close();
                    }

                }
            }



            string tran = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE trans_stat = '1' AND complete_stat = '3' AND user_send ='" + Session["UserName"].ToString() + "' ";
            string tranact = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE tran_type = '1' AND num_success = 'yes' AND user_send ='" + Session["UserName"].ToString() + "' ";
            MySqlDataReader tr = function.MySqlSelect(tran);
            if (tr.Read())
            {
                lbTran.Text = tr.GetInt32("num").ToString();
                tr.Close();
                MySqlDataReader tract = function.MySqlSelect(tranact);
                if (tract.Read())
                {
                    lbTran2.Text = tract.GetInt32("devv").ToString() + " รายการ";
                    tract.Close();
                }
            }

            string send = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE trans_stat = '6' AND complete_stat = '3'  AND user_send ='" + Session["UserName"].ToString() + "' ";
            string sendact = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE tran_type = '6' AND num_success = 'yes' AND user_send ='" + Session["UserName"].ToString() + "' ";
            MySqlDataReader snd = function.MySqlSelect(send);
            if (snd.Read())
            {
                lbSendHead.Text = snd.GetInt32("num").ToString();
                snd.Close();
                MySqlDataReader sndact = function.MySqlSelect(sendact);
                if (sndact.Read())
                {
                    lbSendHead2.Text = sndact.GetInt32("devv").ToString() + " รายการ";
                    sndact.Close();
                }
            }

            string sell = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE trans_stat = '3' AND complete_stat = '3' AND user_send ='" + Session["UserName"].ToString() + "' ";
            string sellact = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE tran_type = '3' AND num_success = 'yes' AND user_send ='" + Session["UserName"].ToString() + "' ";
            MySqlDataReader see = function.MySqlSelect(sell);
            if (see.Read())
            {
                lbSell.Text = see.GetInt32("num").ToString();
                see.Close();
                MySqlDataReader sella = function.MySqlSelect(sellact);
                if (sella.Read())
                {
                    lbSell2.Text = sella.GetInt32("devv").ToString() + " รายการ";
                    sella.Close();
                }

            }

            string rep = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE trans_stat = '4' AND complete_stat = '3' AND user_send ='" + Session["UserName"].ToString() + "' ";
            string repact = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE tran_type = '4' AND num_success = 'yes' AND user_send ='" + Session["UserName"].ToString() + "' ";
            MySqlDataReader ree = function.MySqlSelect(rep);
            if (ree.Read())
            {
                lbRepair.Text = ree.GetInt32("num").ToString();
                ree.Close();
                MySqlDataReader reeact = function.MySqlSelect(repact);
                if (reeact.Read())
                {
                    lbRepair2.Text = reeact.GetInt32("devv").ToString() + " รายการ";
                    reeact.Close();
                }

            }

            string copy = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE trans_stat = '5' AND complete_stat = '3' AND user_send ='" + Session["UserName"].ToString() + "' ";
            string copact = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE tran_type = '5' AND num_success = 'yes' AND user_send ='" + Session["UserName"].ToString() + "' ";
            MySqlDataReader pee = function.MySqlSelect(copy);
            if (pee.Read())
            {
                lbCopy.Text = pee.GetInt32("num").ToString();
                pee.Close();
                MySqlDataReader peeact = function.MySqlSelect(copact);
                if (peeact.Read())
                {
                    lbCopy2.Text = peeact.GetInt32("devv").ToString() + " รายการ";
                    peeact.Close();
                }

            }

            string seee = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE trans_stat = '2' AND complete_stat = '3' AND user_send ='" + Session["UserName"].ToString() + "' ";
            string seeer = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE tran_type = '2' AND num_success = 'yes' AND user_send ='" + Session["UserName"].ToString() + "' ";
            MySqlDataReader sert = function.MySqlSelect(seee);
            if (sert.Read())
            {
                Label2.Text = sert.GetInt32("num").ToString();
                pee.Close();
                MySqlDataReader seeact = function.MySqlSelect(seeer);
                if (seeact.Read())
                {
                    Label3.Text = seeact.GetInt32("devv").ToString() + " รายการ";
                    seeact.Close();
                }

            }

            string seeto = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE complete_stat BETWEEN '2' AND '3' AND user_send ='" + Session["UserName"].ToString() + "' ";
            string seetot = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE complete_stat BETWEEN '2' AND '3' AND user_send ='" + Session["UserName"].ToString() + "' ";
            MySqlDataReader seert = function.MySqlSelect(seeto);
            if (seert.Read())
            {
                lbTotal.Text = seert.GetInt32("num").ToString();
                seert.Close();
                MySqlDataReader seeeer = function.MySqlSelect(seetot);
                if (seeeer.Read())
                {
                    lbTotal2.Text = seeeer.GetInt32("devv").ToString() + " รายการ";
                    seeeer.Close();
                }

            }

            string seereceipt = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE complete_stat = '2' AND (toll_send ='" + sqlcpSearch + "') ";
            string seereceiptt = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE complete_stat = '2' AND (toll_send ='" + sqlcpSearch + "') ";
            MySqlDataReader seerre = function.MySqlSelect(seereceipt);
            if (seerre.Read())
            {
                lbreceive.Text = seerre.GetInt32("num").ToString();
                seerre.Close();
                MySqlDataReader seeeere = function.MySqlSelect(seereceiptt);
                if (seeeere.Read())
                {
                    lbreceive2.Text = seeeere.GetInt32("devv").ToString() + " รายการ";
                    seeeere.Close();
                }

            }


            string eqTotal = "SELECT COUNT(*) AS num FROM tbl_equipment WHERE toll_id = '" + sqlcpSearchtotal + "' ";
            string eqNormal = "SELECT COUNT(*) AS numn FROM tbl_equipment WHERE (toll_id = '" + sqlcpSearchtotal + "' )AND Estatus_id = '1'";
            string eqBroken = "SELECT COUNT(*) AS numb FROM tbl_equipment WHERE (toll_id = '" + sqlcpSearchtotal + "' )AND Estatus_id = '2'";
            string sqlStatus = "";
            string sqlrt = "SELECT COUNT(*) AS numt FROM tbl_transfer WHERE complete_stat = '3' AND ( tbl_transfer.toll_send = '" + sqltran + "' ) AND tbl_transfer.trans_stat = " + sqlStatus + " ";
            string sqleqrt = "SELECT COUNT(*) AS numqt FROM tbl_transfer LEFT JOIN tbl_transfer_action ON tbl_transfer.trans_id = tbl_transfer_action.transfer_id WHERE num_success = 'yes' AND ( tbl_transfer.toll_send = '" + sqltran + "' ) AND tbl_transfer.trans_stat = " + sqlStatus + " ";
            string sqlrt4 = "SELECT COUNT(*) AS numt FROM tbl_transfer WHERE complete_stat = '3' AND ( tbl_transfer.toll_send = '" + sqltran + "' ) AND tbl_transfer.trans_stat = " + sqlStatus + " ";
            string sqleqrt4 = "SELECT COUNT(*) AS numqt FROM tbl_transfer LEFT JOIN tbl_transfer_action ON tbl_transfer.trans_id = tbl_transfer_action.transfer_id WHERE num_success = 'yes' AND ( tbl_transfer.toll_send = '" + sqltran + "' ) AND tbl_transfer.trans_stat = " + sqlStatus + " ";
            string sqlrt7 = "SELECT COUNT(*) AS numt FROM tbl_transfer WHERE complete_stat = '3' AND ( tbl_transfer.toll_send = '" + sqltran + "' ) AND tbl_transfer.trans_stat = " + sqlStatus + " ";
            string sqleqrt7 = "SELECT COUNT(*) AS numqt FROM tbl_transfer LEFT JOIN tbl_transfer_action ON tbl_transfer.trans_id = tbl_transfer_action.transfer_id WHERE num_success = 'yes' AND ( tbl_transfer.toll_send = '" + sqltran + "' ) AND tbl_transfer.trans_stat = " + sqlStatus + " ";
            string sqltr = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE complete_stat = '3' " + sqlUser + " AND tbl_transfer.trans_stat = " + sqlStatus + " ";
            string sqlact = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE num_success = 'yes' " + sqlUser + " AND t.trans_stat = " + sqlStatus + " ";
            string sqltr6 = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE complete_stat = '3' " + sqlUser + " AND tbl_transfer.trans_stat = " + sqlStatus + " ";
            string sqlact6 = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE num_success = 'yes' " + sqlUser + " AND t.trans_stat = " + sqlStatus + " ";
            string sqlrec = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE complete_stat = '3' AND (toll_send =' "+sqlcpSearch+ "') ";
            string sqleqerc = "SELECT COUNT(*) AS devv FROM tbl_transfer_action JOIN tbl_transfer t ON t.trans_id = tbl_transfer_action.transfer_id WHERE complete_stat = '3' AND(toll_send = '" + sqlcpSearch + "') ";
            //string tranSentTotal = "";
            //string tranClaimTotal = "";
            MySqlDataReader rt = function.MySqlSelect(eqTotal);
            if (rt.Read())
            {
                lbEqTotal.Text = String.Format("{0:n0}", rt.GetInt32("num")) ;
                rt.Close();
            }
            MySqlDataReader rt1 = function.MySqlSelect(eqNormal);
            if (rt1.Read())
            {
                lbEqNorm.Text = String.Format("{0:n0}", rt1.GetInt32("numn")) ;
                rt1.Close();
            }
            MySqlDataReader rt2 = function.MySqlSelect(eqBroken);
            if (rt2.Read())
            {
                lbEqBork.Text = String.Format("{0:n0}", rt2.GetInt32("numb")) ;
                rt2.Close();
            }
            //Sent HQ ********************** NO complete
            sqlStatus = "2"; 
            sqlrt += sqlStatus;
            sqleqrt += sqlStatus;
            MySqlDataReader rt3 = function.MySqlSelect(sqlrt);
            if (rt3.Read())
            {
                MySqlDataReader rtt3 = function.MySqlSelect(sqleqrt);
                if (rtt3.Read())
                {
                    lbStaSentToll.Text = String.Format("{0:n0}", rt3.GetInt32("numt"));
                    lbeqSentToll.Text = " " + String.Format("{0:n0}", rtt3.GetInt32("numqt"));
                    lbStaTransfer.Text = String.Format("{0:n0}", rt3.GetInt32("numt")) + " / " + String.Format("{0:n0}", rtt3.GetInt32("numqt"));
                    rt3.Close();
                    rtt3.Close();

                }
            }
            //ซ่อม
            sqlStatus = "4";
            sqlrt4 += sqlStatus;
            sqleqrt4 += sqlStatus;
            MySqlDataReader rt4 = function.MySqlSelect(sqlrt4);
            if (rt4.Read())
            {
                MySqlDataReader rtt4 = function.MySqlSelect(sqleqrt4);
                if (rtt4.Read())
                {
                    lbStaClaimToll.Text = String.Format("{0:n0}", rt4.GetInt32("numt"));
                    lbeqClaimToll.Text = " " + String.Format("{0:n0}", rtt4.GetInt32("numqt"));
                    lbStaClaim.Text = String.Format("{0:n0}", rt4.GetInt32("numt")) + " / " + String.Format("{0:n0}", rtt4.GetInt32("numqt"));
                    rt4.Close();
                    rtt4.Close();
                }
            }
            //ยืม
            sqlStatus = "7";
            sqlrt7 += sqlStatus;
            sqleqrt7 += sqlStatus;
            MySqlDataReader rt5 = function.MySqlSelect(sqlrt7);
            if (rt5.Read())
            {
                MySqlDataReader rtt5 = function.MySqlSelect(sqleqrt7);
                if (rtt5.Read())
                {
                    //lbStaRentToll.Text = String.Format("{0:n0}", rt5.GetInt32("numt"));
                    //lbeqRentToll.Text = " " + String.Format("{0:n0}", rtt5.GetInt32("numqt"));
                    lbStaRent.Text = String.Format("{0:n0}", rt5.GetInt32("numt")) + " / " + String.Format("{0:n0}", rtt5.GetInt32("numqt"));
                    rt5.Close();
                    rtt5.Close();
                }
            }
            //โอนย้าย
            sqlStatus = "1";
            sqltr += sqlStatus;
            sqlact += sqlStatus;
            MySqlDataReader rt6 = function.MySqlSelect(sqltr);
            if (rt6.Read())
            {
                MySqlDataReader rtt6 = function.MySqlSelect(sqlact);
                if (rtt6.Read())
                {
                    lbStatrans.Text = String.Format("{0:n0}", rt6.GetInt32("num")) + " / " + String.Format("{0:n0}", rtt6.GetInt32("devv")); 
                    rt6.Close();
                    rtt6.Close();

                }
            }
            //
            sqlStatus = "6";
            sqltr6 += sqlStatus;
            sqlact6 += sqlStatus;
            MySqlDataReader rt7 = function.MySqlSelect(sqltr6);
            if (rt7.Read())
            {
                MySqlDataReader rtt7 = function.MySqlSelect(sqlact6);
                if (rtt7.Read())
                {
                    lbStaSent.Text = String.Format("{0:n0}", rt7.GetInt32("num")) + " / " + String.Format("{0:n0}", rtt7.GetInt32("devv"));
                    rt7.Close();
                    rtt7.Close();
                }
            }

            MySqlDataReader rt8 = function.MySqlSelect(sqlrec);
            if (rt8.Read())
            {
                MySqlDataReader rtt8 = function.MySqlSelect(sqleqerc);
                if (rtt8.Read())
                {
                    lbStaRecieptToll.Text = String.Format("{0:n0}", rt8.GetInt32("num")) + " / " + String.Format("{0:n0}", rtt8.GetInt32("devv"));
                    rt8.Close();
                    rtt8.Close();
                }
            }
            if (lbreceive.Text != "0")
            {
                lbAmountWait.Text = lbreceive.Text;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
            else
            {
                alertWaitTrans.Visible = false;
            }
            
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