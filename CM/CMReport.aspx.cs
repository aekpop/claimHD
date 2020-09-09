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
    public partial class CMReport : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public string cm_id = "";
        public string alert = "";
        public string alertType = "";
        public string icon = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/");
            }

            //if (txtETime.Text == "") { txtETime.Text = DateTime.Now.ToString("HH.mm"); }

            if (!this.IsPostBack)
            {
                function.getListItem(ddlCMBudget, "SELECT cm_budget FROM tbl_cm_detail  GROUP BY cm_budget ORDER by cm_budget DESC", "cm_budget", "cm_budget");               
                string sql = "";
                if (function.CheckLevel("Department", Session["UserPrivilegeId"].ToString()))
                {
                    sql = "SELECT * FROM tbl_cpoint ORDER BY cpoint_id";
                    function.getListItem(txtCpointSearch, sql, "cpoint_name", "cpoint_id");
                    txtCpointSearch.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                }
                else
                {
                    sql = "SELECT * FROM tbl_cpoint WHERE cpoint_id = '" + Session["UserCpoint"].ToString() + "'";
                    function.getListItem(txtCpointSearch, sql, "cpoint_name", "cpoint_id");
                    //txtCpointSearch.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                }
                BindData();
            }

        }
        void BindData()
        {
            string sql = "";
            string checkCpoint = txtCpointSearch.SelectedValue;
            if (checkCpoint == "")
            {
                sql += "SELECT * FROM tbl_cm_detail cm " +
                    " JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                    " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                    " WHERE cm.cm_budget = '" + ddlCMBudget.SelectedValue + "' " +
                    " ORDER BY cm_cpoint,cm_point,cm_detail_channel,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y'), cm.cm_detail_stime, cm_detail_status_id ASC";
            }
            else
            {
                sql += "SELECT * FROM tbl_cm_detail cm " +
                   " JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                   " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                   " WHERE cm.cm_cpoint = '" + checkCpoint + "' " +
                   " AND cm.cm_budget = '" + ddlCMBudget.SelectedValue + "' " +
                   " ORDER BY cm_cpoint,cm_point,cm_detail_channel,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y'), cm.cm_detail_stime, cm_detail_status_id ASC";
            }

            MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            // if (ds.Tables[0].Rows.Count == 0) { DivCMGridView.Visible = false; } else { DivCMGridView.Visible = true; }
            //lbCMNull.Text = "พบข้อมูลจำนวน " + ds.Tables[0].Rows.Count + " แถว";

        }

        protected void btnResult_Click(object sender, EventArgs e)
        {

        }

        protected void btnCoverReport_Click(object sender, EventArgs e)
        {

        }

        protected void ltnAllPM_Command(object sender, CommandEventArgs e)
        {

        }

        protected void ltnNum2_Command(object sender, CommandEventArgs e)
        {

        }

        protected void ltnNum3_Command(object sender, CommandEventArgs e)
        {

        }

        protected void ltnNum4_Command(object sender, CommandEventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbSDate = (Label)(e.Row.FindControl("lbSDate"));
            if (lbSDate != null)
            {
                lbSDate.Text = function.ConvertDateShortThai((string)DataBinder.Eval(e.Row.DataItem, "cm_detail_sdate"));
            }

            Label lbStatus = (Label)(e.Row.FindControl("lbStatus"));
            if (lbStatus != null)
            {
                lbStatus.Text = function.GetStatusCM(DataBinder.Eval(e.Row.DataItem, "cm_detail_status_id").ToString());
            }

            Label btnDateEditCM = (Label)(e.Row.FindControl("btnDateEditCM"));
            if (btnDateEditCM != null)
            {
                if (!DataBinder.Eval(e.Row.DataItem, "cm_detail_edate").Equals(DBNull.Value))
                {
                    btnDateEditCM.Text = function.ConvertDateShortThai((string)DataBinder.Eval(e.Row.DataItem, "cm_detail_edate"));
                }
            }

            Label btnTimeEditCM = (Label)(e.Row.FindControl("btnTimeEditCM"));
            if (btnTimeEditCM != null)
            {
                if (!DataBinder.Eval(e.Row.DataItem, "cm_detail_etime").Equals(DBNull.Value))
                {
                    btnTimeEditCM.Text = (string)DataBinder.Eval(e.Row.DataItem, "cm_detail_etime");
                    if (btnTimeEditCM.Text != "") { btnTimeEditCM.Text += " น."; }
                }
            }
            
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnSearchEdit_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }

}
