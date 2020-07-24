using System;
using ClaimProject.Config;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;


namespace ClaimProject.equip
{
    public partial class EquipLoanList : System.Web.UI.Page
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
                Session.Add("TransID", "");
                Session.Add("TransNew", "");
                Session.Add("sqlreEQ", "");
                Session.Add("SenderTran", "");
                Session.Add("PosSender", "");
                Session.Add("CopyTran", "");
                Session["TranRepId"] = "";
                Session["TransNew"] = "";
                Session["BackWhat"] = "Send";
                function.getListItem(ddlsearchEndToll, "SELECT * FROM tbl_toll Order By toll_id ASC", "toll_name", "toll_id");
                function.getListItem(ddlsearchType, "SELECT * FROM tbl_transfer_status Order by trans_stat_id ASC ", "trans_stat_name", "trans_stat_id");
                function.getListItem(ddlsearchStat, "SELECT * FROM tbl_trans_complete WHERE complete_id != '4' AND complete_id != '5'  order by complete_id asc ", "complete_name", "complete_id");
                ddlsearchEndToll.Items.Insert(0, new ListItem("ทั้งหมด", "0"));
                ddlsearchType.Items.Insert(0, new ListItem("ทั้งหมด", "0"));
                ddlsearchStat.Items.Insert(0, new ListItem("ทั้งหมด", "0"));
            }
        }

        protected void btnMainEQ_Click(object sender, EventArgs e)
        {
            Response.Redirect("/equip/EquipMain");
        }

        protected void lbtnSearchSend_Command(object sender, CommandEventArgs e)
        {

        }

        protected void lbtntrans_Command(object sender, CommandEventArgs e)
        {

        }

        protected void lbtnprintTran_Command(object sender, CommandEventArgs e)
        {

        }

        protected void gridTranlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gridTranlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}