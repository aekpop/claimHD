using ClaimProject.Config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimProject.equip
{
    public partial class EquipReportAll : System.Web.UI.Page
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
                //Session.Add("CheckTran", "");
                LoadPaging();
            }
        }
        protected void LoadPaging()
        {
            //ddlreportType
            function.getListItem(ddlreportToll, "select * FROM tbl_toll ORDER BY toll_id ASC ", "toll_name", "toll_id");
            ddlreportType.Items.Insert(0, new ListItem("รายงานโอนย้ายประจำปีงบประมาณ", "0"));
            ddlreportType.Items.Insert(1, new ListItem("รายงานโอนย้ายประจำเดือน", "1"));
            function.getListItem(ddlreportBudget, "SELECT budget_y FROM tbl_transfer_action GROUP BY budget_y ORDER BY budget_y DESC", "budget_y", "budget_y");
            ddlreportMonth.Items.Insert(0, new ListItem("มกราคม", "1"));
            ddlreportMonth.Items.Insert(1, new ListItem("กุมภาพันธ์", "2"));
            ddlreportMonth.Items.Insert(2, new ListItem("มีนาคม", "3"));
            ddlreportMonth.Items.Insert(3, new ListItem("เมษายน", "4"));
            ddlreportMonth.Items.Insert(4, new ListItem("พฤษภาคม", "5"));
            ddlreportMonth.Items.Insert(5, new ListItem("มิถุนายน", "6"));
            ddlreportMonth.Items.Insert(6, new ListItem("กรกฎาคม", "7"));
            ddlreportMonth.Items.Insert(7, new ListItem("สิงหาคม", "8"));
            ddlreportMonth.Items.Insert(8, new ListItem("กันยายน", "9"));
            ddlreportMonth.Items.Insert(9, new ListItem("ตุลาคม", "10"));
            ddlreportMonth.Items.Insert(10, new ListItem("พฤศจิกายน", "11"));
            ddlreportMonth.Items.Insert(11, new ListItem("ธันวาคม", "12"));
            ddlreportMonth.Items.Insert(12, new ListItem("all", ""));
        }

        protected void lbtnreportQ_Command(object sender, CommandEventArgs e)
        {
            bind();
        }

        protected void bind()
        {
            string sql = "SELECT toll_name,COUNT(toll_send) AS ครั้ง FROM tbl_transfer tf JOIN tbl_toll t ON tf.toll_send = t.toll_id WHERE thai_month = '" + ddlreportMonth.SelectedItem+ "' AND trans_budget = '" + ddlreportBudget.SelectedValue + "' AND tf.complete_stat IN(2,3,6,7) GROUP BY toll_send ORDER BY toll_send";
            MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            gridReport.DataSource = ds.Tables[0];
            int countt = ds.Tables[0].Rows.Count;
            gridReport.DataBind();
            if (countt == 0)
            {
                lbAmountgrid.Text = "ไม่พบรายการ";
            }
            else { lbAmountgrid.Text = "พบ " + countt.ToString() + " รายการ"; }

            string sqlre = "SELECT toll_name,COUNT(toll_recieve) AS ครั้ง FROM tbl_transfer tf JOIN tbl_toll t ON tf.toll_recieve = t.toll_id WHERE thai_month = '" + ddlreportMonth.SelectedItem + "' AND trans_budget = '" + ddlreportBudget.SelectedValue + "' AND tf.complete_stat IN(2,3,6,7) GROUP BY toll_recieve ORDER BY toll_recieve";
            MySqlDataAdapter dare = function.MySqlSelectDataSet(sqlre);
            System.Data.DataSet dsre = new System.Data.DataSet();
            dare.Fill(dsre);
            GridView1.DataSource = dsre.Tables[0];
            int counttt = dsre.Tables[0].Rows.Count;
            GridView1.DataBind();
            if (counttt == 0)
            {
                Label1.Text = "ไม่พบรายการ";
            }
            else { Label1.Text = "พบ " + counttt.ToString() + " รายการ"; }
        }

        protected void gridReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbRowNum = (Label)(e.Row.FindControl("lbRowNum"));
            if (lbRowNum != null)
            {
                lbRowNum.Text = (gridReport.Rows.Count + 1).ToString() + ".";
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbRowNum = (Label)(e.Row.FindControl("lbRowNum"));
            if (lbRowNum != null)
            {
                lbRowNum.Text = (GridView1.Rows.Count + 1).ToString() + ".";
            }
        }
    }
}