using ClaimProject.Config;
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
            function.getListItem(ddlreportBudget, "SELECT budget_y FROM tbl_transfer_action GROUP BY budget_y ORDER BY budget_y", "budget_y", "budget_y");
            ddlreportMonth.Items.Insert(0, new ListItem("มกราคม", "0"));
            ddlreportMonth.Items.Insert(1, new ListItem("กุมภาพันธ์", "1"));
            ddlreportMonth.Items.Insert(2, new ListItem("มีนาคม", "2"));
            ddlreportMonth.Items.Insert(3, new ListItem("เมษายน", "3"));
            ddlreportMonth.Items.Insert(4, new ListItem("พฤษภาคม", "4"));
            ddlreportMonth.Items.Insert(5, new ListItem("มิถุนายน", "5"));
            ddlreportMonth.Items.Insert(6, new ListItem("กรกฎาคม", "6"));
            ddlreportMonth.Items.Insert(7, new ListItem("สิงหาคม", "7"));
            ddlreportMonth.Items.Insert(8, new ListItem("กันยายน", "8"));
            ddlreportMonth.Items.Insert(9, new ListItem("ตุลาคม", "9"));
            ddlreportMonth.Items.Insert(10, new ListItem("พฤศจิกายน", "10"));
            ddlreportMonth.Items.Insert(11, new ListItem("ธันวาคม", "11"));
            ddlreportMonth.Items.Insert(12, new ListItem("all", "12"));
        }

        protected void lbtnreportQ_Command(object sender, CommandEventArgs e)
        {

        }
    }
}