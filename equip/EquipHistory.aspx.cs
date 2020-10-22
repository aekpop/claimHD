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
	public partial class EquipHistory : System.Web.UI.Page
	{
        ClaimFunction function = new ClaimFunction();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/");
            }

            if (!this.IsPostBack)
            {

            }
        }

        protected void btnSearchEq_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void GridViewSearchEq_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbCpointS = (Label)(e.Row.FindControl("lbCpointS"));
            if (lbCpointS != null)
            {
                lbCpointS.Text = DataBinder.Eval(e.Row.DataItem, "toll_name").ToString();
            }

            Label lbCpointE = (Label)(e.Row.FindControl("lbCpointE"));
            if (lbCpointE != null)
            {
                string CpointE = DataBinder.Eval(e.Row.DataItem, "toll_recieve").ToString();
                string sql = "SELECT * FROM tbl_toll WHERE toll_id =  '" + CpointE + "' ";
                MySqlDataReader rs = function.MySqlSelect(sql);
                if (rs.Read())
                {
                    lbCpointE.Text = rs.GetString("toll_name");
                    rs.Close();
                }
            }

            Label lbDate = (Label)(e.Row.FindControl("lbDate"));
            if (lbDate != null)
            {
                lbDate.Text = function.ConvertDateShortThai((string)DataBinder.Eval(e.Row.DataItem, "date_send"));
            }

            Label lbStatus = (Label)(e.Row.FindControl("lbStatus"));
            

            if (lbStatus != null)
            {
                string Status = DataBinder.Eval(e.Row.DataItem, "num_success").ToString();
                if (Status == "no")
                {
                    lbStatus.Text = "รออนุมัติ";
                    lbStatus.CssClass = "text-danger";
                }else if(Status == "yes")
                {
                    lbStatus.Text = "อนุมัติ";
                    lbStatus.CssClass = "text-success";
                }
                else if (Status == "repair")
                {
                    lbStatus.Text = "ซ่อม";
                    lbStatus.CssClass = "text-warning";
                }
            }
        }
        void BindData()
        {
            if(txtSearchEq.Text != "")
            {
                txtSearchEq.CssClass = "form-control is-valid";
                string equip = txtSearchEq.Text.Trim();
                string sql = "SELECT * FROM tbl_transfer_action t JOIN tbl_transfer f ON t.transfer_id = f.trans_id LEFT JOIN tbl_equipment e ON t.trans_equip_id = e.equipment_id " +
                    " JOIN tbl_toll o ON t.old_toll = o.toll_id Where e.equipment_no LIKE '%" + equip + "%' ORDER BY t.old_no ASC ,f.date_send ASC ";

                MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds);
                GridViewSearchEq.DataSource = ds.Tables[0];
                GridViewSearchEq.DataBind();
            }
            else
            {
                txtSearchEq.CssClass = "form-control is-invalid ";
            }
            
        }

        protected void lbRef_Command(object sender, CommandEventArgs e)
        {

        }

        protected void btnMainEQQ_Click(object sender, EventArgs e)
        {
            Response.Redirect("/equip/EquipMain");
        }
    }
}