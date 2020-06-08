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
    public partial class EquipStatistics : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string dater = DateTime.Now.ToString("dd-MM") + "-" + (DateTime.Now.Year + 543);
                string tty = "";
                function.getListItem(txtBudgetYear, "SELECT trans_budget FROM tbl_transfer  GROUP BY trans_budget ORDER by trans_budget DESC", "trans_budget", "trans_budget");
                MySqlDataReader redf = function.MySqlSelect("SELECT trans_budget FROM tbl_transfer  GROUP BY trans_budget ORDER by trans_budget DESC LIMIT 1");
                if(redf.Read())
                {
                    tty = redf.GetString("trans_budget");
                    redf.Close();
                }
                string ghot = function.getBudgetYear(dater);
                if(tty != ghot)
                {
                    txtBudgetYear.Items.Insert(0, new ListItem(ghot,ghot));
                    txtBudgetYear.SelectedValue = ghot;
                }
                string startTollSQL = "";
                string endTollSQL = "";
                
                if(Session["UserCpoint"].ToString() != "0")
                {
                    startTollSQL = "Select * from tbl_cpoint WHERE cpoint_id = '"+Session["UserCpoint"].ToString()+ "' AND cpoint_id != '921'  ";
                    endTollSQL = "Select * From tbl_cpoint WHERE cpoint_id ='920'";
                }
                else
                {
                    startTollSQL = "Select * from tbl_cpoint WHERE cpoint_id != '921' order by cpoint_id ASC  ";
                    endTollSQL = "Select * From tbl_cpoint WHERE cpoint_id != '921' order by cpoint_id ASC";
                }
                function.getListItem(ddlstatType, "select * from tbl_transfer_status order by trans_stat_id ASC ", "trans_stat_name", "trans_stat_id");
                function.getListItem(ddlStartTolls, startTollSQL,"cpoint_name", "cpoint_id");
                ddlStartTolls.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                function.getListItem(ddlEndTolls, endTollSQL, "cpoint_name", "cpoint_id");
                ddlEndTolls.Items.Insert(0, new ListItem("ทั้งหมด", ""));

            }


                


        }

        protected void genGraph()
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

        protected void btnBackMainStatEQ_Click(object sender, EventArgs e)
        {
            Response.Redirect("/equip/EquipDefault");
        }

        protected void gridStattis_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton lbtnDetail = (LinkButton)(e.Row.FindControl("lbtnDetail"));
            if (lbtnDetail != null)
            {
                lbtnDetail.CommandName = (string)DataBinder.Eval(e.Row.DataItem, "trans_id");
            }
            Label lbstat = (Label)(e.Row.FindControl("lbstat"));
            if (lbstat != null)
            {
                lbstat.CssClass = "badge badge-" + (string)DataBinder.Eval(e.Row.DataItem, "complete_badge");
            }

        }

        protected void lbtnDetail_Command(object sender, CommandEventArgs e)
        {

        }

        protected void rbtDurations_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtDurations.Checked == true)
            {
                txtBudgetYear.Enabled = false;
                txtStartDate.Enabled = true;
                txtEndDate.Enabled = true;
            }
            else if(rbtBudgets.Checked == true)
            {
                txtBudgetYear.Enabled = true;
                txtStartDate.Enabled = false;
                txtEndDate.Enabled = false;
            }
        }

        protected void rbtBudgets_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtBudgets.Checked == true)
            {
                txtBudgetYear.Enabled = true;
                txtStartDate.Enabled = false;
                txtEndDate.Enabled = false;
            }
            else if(rbtDurations.Checked == true)
            {
                txtBudgetYear.Enabled = false;
                txtStartDate.Enabled = true;
                txtEndDate.Enabled = true;
            }
        }

        protected void btnMainEQt_Click(object sender, EventArgs e)
        {
            Response.Redirect("/equip/EquipDefault");
        }
    }
}