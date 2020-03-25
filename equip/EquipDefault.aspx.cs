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
            if (!this.IsPostBack)
            {
                loadingpage();
            }


        }
        
        protected void loadingpage()
        {
            string tran = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE trans_stat = '1' AND complete_stat = '3' ";
            string tranact = "SELECT COUNT(*) AS devv FROM tbl_transfer_action WHERE tran_type = '1' AND num_success = 'yes'";
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

            string send = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE trans_stat = '2' AND complete_stat = '3' ";
            string sendact = "SELECT COUNT(*) AS devv FROM tbl_transfer_action WHERE tran_type = '2' AND num_success = 'yes'";
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

            string sell = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE trans_stat = '3' AND complete_stat = '3' ";
            string sellact = "SELECT COUNT(*) AS devv FROM tbl_transfer_action WHERE tran_type = '3' AND num_success = 'yes'";
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

            string rep = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE trans_stat = '4' AND complete_stat = '3' ";
            string repact = "SELECT COUNT(*) AS devv FROM tbl_transfer_action WHERE tran_type = '4' AND num_success = 'repair'";
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

            string copy = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE trans_stat = '5' AND complete_stat = '3' ";
            string copact = "SELECT COUNT(*) AS devv FROM tbl_transfer_action WHERE tran_type = '5' AND num_success = 'yes'";
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




        }
        protected void txtBudgetYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lbtnTranDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect("/equip/EquipStatistics");
        }

        protected void lbtnSendHeadDetail_Click(object sender, EventArgs e)
        {

        }

        protected void lbtnSellDetail_Click(object sender, EventArgs e)
        {

        }

        protected void lbtnRepairDetail_Click(object sender, EventArgs e)
        {

        }

        protected void lbtnCopyDetail_Click(object sender, EventArgs e)
        {

        }
    }
}