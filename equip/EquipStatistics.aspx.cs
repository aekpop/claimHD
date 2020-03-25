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
    }
}