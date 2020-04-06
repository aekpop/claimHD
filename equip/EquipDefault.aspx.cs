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
            function.getListItem(txtBudgetYear, "SELECT trans_budget FROM tbl_transfer GROUP BY trans_budget ORDER BY trans_budget DESC", "trans_budget", "trans_budget");
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

            string send = "SELECT COUNT(*) AS num FROM tbl_transfer WHERE trans_stat = '2' AND complete_stat = '3' AND trans_budget = '"+txtBudgetYear.SelectedValue+"' ";
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


            loadChart();

        }
        protected void loadChart ()
        {

            /*  int nowBudget = int.Parse(function.getBudgetYear("01-" + DateTime.Now.ToString("MM") + "-" + (DateTime.Now.Year + 543).ToString()));
              string budgetss = txtBudgetYear.Text;
              string MonthFullList = "ตุลาคม-มกราคม-กุมภาพันธ์-มีนาคม-เมษายน-พฤษภาคม-มิถุนายน-กรกฎาคม-สิงหาคม-กันยายน-ตุลาคม-พฤศจิกายน-ธันวาคม";
              string[] MonthList = MonthFullList.Split('-');
              string ChartQuery = " select IFNULL(c.month_y,'ตุลาคม') AS monthx,COUNT(c.trans_act_id)AS Total  FROM tbl_transfer_action c "
                                  + " WHERE c.month_y = 'ตุลาคม'  AND c.tran_type = 6 AND  num_success = 'yes' AND"
                                  + " c.budget_y = '" + budgetss + "' "
                                  + " UNION  select IFNULL(c.month_y,'พฤศจิกายน') AS monthx, COUNT(c.trans_act_id)AS Total  FROM tbl_transfer_action c "
                                  + " WHERE c.month_y = 'พฤศจิกายน' AND c.tran_type = 6 AND num_success = 'yes' AND"
                                  + " c.budget_y = '" + budgetss + "'  "
                                  + " UNION  select IFNULL(c.month_y,'ธันวาคม') AS monthx, COUNT(c.trans_act_id)AS Total  FROM tbl_transfer_action c "
                                  + " WHERE c.month_y = 'ธันวาคม'  AND c.tran_type = 6 AND num_success = 'yes' AND"
                                  + " c.budget_y = '" + budgetss + "'  ";
              string ChartQ = ChartQuery
                            + " UNION select IFNULL(c.month_y, 'มกราคม') AS monthx, COUNT(c.trans_act_id)AS Total  FROM tbl_transfer_action c "
                            + " WHERE c.month_y = 'มกราคม'  AND c.tran_type != 6 AND num_success = 'yes' AND"
                            + " c.budget_y = '" + budgetss + "'  "
                            + " UNION select IFNULL(c.month_y, 'กุมภาพันธ์') AS monthx, COUNT(c.trans_act_id)AS Total  FROM tbl_transfer_action c "
                            + " WHERE c.month_y = 'กุมภาพันธ์'  AND c.tran_type = 6 AND num_success = 'yes' AND"
                            + " c.budget_y = '" + budgetss + "'  "
                            + " UNION select IFNULL(c.month_y, 'มีนาคม') AS monthx, COUNT(c.trans_act_id)AS Total  FROM tbl_transfer_action c "
                            + " WHERE c.month_y = 'มีนาคม'  AND c.tran_type = 6 AND num_success = 'yes' AND"
                            + " c.budget_y = '" + budgetss + "'  "
                            + " UNION select IFNULL(c.month_y, 'เมษายน') AS monthx, COUNT(c.trans_act_id)AS Total  FROM tbl_transfer_action c "
                            + " WHERE c.month_y = 'เมษายน'  AND c.tran_type = 6 AND num_success = 'yes' AND"
                            + " c.budget_y = '" + budgetss + "'  "
                            + " UNION select IFNULL(c.month_y, 'พฤษภาคม') AS monthx, COUNT(c.trans_act_id)AS Total  FROM tbl_transfer_action c "
                            + " WHERE c.month_y = 'พฤษภาคม'  AND c.tran_type = 6 AND num_success = 'yes' AND"
                            + " c.budget_y = '" + budgetss + "'  "
                            + " UNION select IFNULL(c.month_y, 'มิถุนายน') AS monthx, COUNT(c.trans_act_id)AS Total  FROM tbl_transfer_action c "
                            + " WHERE c.month_y = 'มิถุนายน'  AND c.tran_type = 6 AND num_success = 'yes' AND"
                            + " c.budget_y = '" + budgetss + "'  "
                            + " UNION select IFNULL(c.month_y, 'กรกฎาคม') AS monthx, COUNT(c.trans_act_id)AS Total  FROM tbl_transfer_action c "
                            + " WHERE c.month_y = 'กรกฎาคม'  AND c.tran_type = 6 AND num_success = 'yes' AND"
                            + " c.budget_y = '" + budgetss + "'  "
                            + " UNION select IFNULL(c.month_y, 'สิงหาคม') AS monthx, COUNT(c.trans_act_id)AS Total  FROM tbl_transfer_action c "
                            + " WHERE c.month_y = 'สิงหาคม'  AND c.tran_type = 6 AND num_success = 'yes' AND"
                            + " c.budget_y = '" + budgetss + "'  "
                            + " UNION select IFNULL(c.month_y, 'กันยายน') AS monthx, COUNT(c.trans_act_id)AS Total  FROM tbl_transfer_action c "
                            + " WHERE c.month_y = 'กันยายน'  AND c.tran_type = 6 AND num_success = 'yes' AND"
                            + " c.budget_y = '" + budgetss + "'  ";
  */
            /*  MySqlDataAdapter da = function.MySqlSelectDataSet(QueryXX);
              DataSet ds = new DataSet();
              da.Fill(ds);
              lbChart1.Visible = true;
              Chart1.DataSource = ds.Tables[0];

              Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
              Chart1.Series["Series1"].Color = Color.DarkOrange;
              Chart1.Series["Series1"].LabelForeColor = Color.Black;
              Chart1.Series["Series1"].IsValueShownAsLabel = true;
              Chart1.Series["Series1"].XValueMember = "monthx";
              Chart1.Series["Series1"].YValueMembers = "Total";
              Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
              Chart1.ChartAreas["ChartArea1"].BackColor = Color.LightGoldenrodYellow;
              Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
              Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
              Chart1.ChartAreas["ChartArea1"].AxisY.Title = "จำนวน";
              Chart1.DataBind(); */
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
            Response.Redirect("/equip/EquipStatistics");
        }

        protected void lbtnSellDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect("/equip/EquipStatistics");
        }

        protected void lbtnRepairDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect("/equip/EquipStatistics");
        }

        protected void lbtnCopyDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect("/equip/EquipStatistics");
        }

        protected void btnMainEQtt_Click(object sender, EventArgs e)
        {
            Response.Redirect("/equip/EquipMain");
        }
    }
}