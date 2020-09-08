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

namespace ClaimProject
{
    public partial class EquipTranList : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public string alerts = "";
        public string alertTypes = "";
        public string icons = "";
        public string ReModal = "";
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
                ddlsearchType.SelectedItem.Value = Session["ddlsearchType"].ToString();
                ddlsearchStat.Items.Insert(0, new ListItem("ทั้งหมด", "0"));
                ddlsearchStat.SelectedItem.Value = Session["ddlsearchStat"].ToString();
            }
            LineTran();
            LoadPaging();
            Session["ddlsearchType"] = "0";
            Session["ddlsearchStat"] = "0";
        }
        protected void LineTran ()
        {
            if(Session["LineTran"].ToString() != "")
            {
                 SreviceLine.WebService_Server serviceLine = new SreviceLine.WebService_Server();
                 serviceLine.MessageToServer("wDLRWPWgBvJRMEk69ebQVGumxOfiTKCgXoUwKeKPQyh", Session["LineTran"].ToString(), "", 1, 41);
                 Session["LineTran"] = "";
            }                   
        }
        protected void btnnewTranpage_Click(object sender, EventArgs e)
        {
            string pkCode = "";
            string cpoint = Session["UserCpoint"].ToString();
            if (cpoint.Length < 3)
            {
                cpoint = "10" + cpoint;
            }

            while (pkCode == "")
            {
                pkCode = function.GenTransferPK(int.Parse(cpoint));
            }

            if (pkCode != "")
            {
                Session["TransID"] = pkCode;
                Session["TransNew"] = "0";
                Response.Redirect("/equip/EquipNewTrans");
            }
            
        }

        protected void LoadPaging ()
        {
            if(Session["User"].ToString() == "pornwimon")
            {
                btnnewTranpage.Visible = false;
            }
            
            string TransRef = Session["TransID"].ToString();
            //COLLATE utf8_general_ci
            string sqlsendSearch = "SELECT * FROM tbl_transfer " +
                         " JOIN tbl_transfer_status on tbl_transfer.trans_stat = tbl_transfer_status.trans_stat_id" +
                         " JOIN tbl_toll on tbl_toll.toll_id = tbl_transfer.toll_send " +
                         " JOIN tbl_trans_complete on tbl_trans_complete.complete_id = tbl_transfer.complete_stat ";
            string type = ddlsearchType.SelectedValue;
            string EndState = ddlsearchEndToll.SelectedValue;
            string status = ddlsearchStat.SelectedValue ;
            if (Session["UserCpoint"].ToString() == "0")
            {
                sqlsendSearch += " WHERE cpoint_id = '920' AND user_send = '"+ Session["UserName"].ToString() + "'   ";
            }
            else
            {
                sqlsendSearch += " WHERE cpoint_id = '" + Session["UserCpoint"].ToString() + "'  ";
            }

            if (EndState == "0") // ทุกปลายทาง
            {
                if (type == "0")// ทุกประเภทรายการ
                {
                    if (status == "0") //ทุกสถานะ
                    {
                        if(txtRefTran.Text != "")
                        {
                            sqlsendSearch += " AND complete_stat !='5' AND trans_stat !='7'  AND trans_id like '%" + txtRefTran.Text+ "%'  Order By tbl_transfer.complete_stat ASC, STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        else
                        {
                            sqlsendSearch += " AND complete_stat !='5' AND trans_stat !='7'   Order By tbl_transfer.complete_stat ASC , STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        
                    }
                    else
                    {
                        if (txtRefTran.Text != "")
                        {
                            sqlsendSearch += " AND complete_stat = '" + status + "' AND trans_stat != '7' AND trans_id like '%" + txtRefTran.Text + "%' Order By tbl_transfer.complete_stat ASC, STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        else
                        {
                            sqlsendSearch += " AND complete_stat = '" + status + "' AND trans_stat != '7' Order By tbl_transfer.complete_stat ASC, STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        

                    }
                }
                else
                {
                    if (status == "0") //ทุกสถานะ
                    {
                        if (txtRefTran.Text != "")
                        {
                            sqlsendSearch += " AND complete_stat !='5'  AND trans_stat = '" + ddlsearchType.SelectedValue + "' AND trans_id like '%" + txtRefTran.Text + "%' Order By tbl_transfer.complete_stat ASC, STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        else
                        {
                            sqlsendSearch += " AND complete_stat !='5'  AND trans_stat = '" + ddlsearchType.SelectedValue + "' Order By tbl_transfer.complete_stat ASC, STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        

                    }
                    else
                    {
                        if (txtRefTran.Text != "")
                        {
                            sqlsendSearch += " AND trans_stat = '" + ddlsearchType.SelectedValue + "' AND complete_stat = '" + status + "' AND trans_id like '%" + txtRefTran.Text + "%' Order By tbl_transfer.complete_stat ASC, STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        else
                        {
                            sqlsendSearch += " AND trans_stat = '" + ddlsearchType.SelectedValue + "' AND complete_stat = '" + status + "' Order By tbl_transfer.complete_stat ASC, STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        

                    }
                }
            }
            else
            {
                if (type == "0")// ทุกประเภทรายการ
                {
                    if (status == "0") //ทุกสถานะ
                    {
                        if (txtRefTran.Text != "")
                        {
                            sqlsendSearch += " AND trans_stat !='7' AND trans_id like '%" + txtRefTran.Text + "%' AND complete_stat !='5'  AND toll_recieve = '" + ddlsearchEndToll.SelectedValue + "' Order By tbl_transfer.complete_stat ASC, STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        else
                        {
                            sqlsendSearch += " AND trans_stat !='7' AND complete_stat !='5' AND toll_recieve = '" + ddlsearchEndToll.SelectedValue + "' Order By tbl_transfer.complete_stat ASC, STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        

                    }
                    else
                    {
                        if (txtRefTran.Text != "")
                        {
                            sqlsendSearch += " AND trans_stat !='7' AND trans_id like '%" + txtRefTran.Text + "%' AND toll_recieve = '" + ddlsearchEndToll.SelectedValue + "' AND complete_stat = '" + status + "' Order By tbl_transfer.complete_stat ASC, STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        else
                        {
                            sqlsendSearch += " AND trans_stat !='7' AND toll_recieve = '" + ddlsearchEndToll.SelectedValue + "' AND complete_stat = '" + status + "' Order By tbl_transfer.complete_stat ASC, STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        

                    }
                }
                else
                {
                    if (status == "0") //ทุกสถานะ
                    {
                        if (txtRefTran.Text != "")
                        {
                            sqlsendSearch += " AND trans_id like '%" + txtRefTran.Text + "%' AND complete_stat !='5'  AND toll_recieve = '" + ddlsearchEndToll.SelectedValue + "' " +
                                " AND trans_stat = '" + ddlsearchType.SelectedValue + "' Order By tbl_transfer.complete_stat ASC, STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        else
                        {
                            sqlsendSearch += " AND complete_stat !='5'  AND toll_recieve = '" + ddlsearchEndToll.SelectedValue + "' AND trans_stat = '" + ddlsearchType.SelectedValue + "' Order By tbl_transfer.complete_stat ASC, STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        

                    }
                    else  // เลือกเฉพาะทุกอย่าง
                    {
                        if (txtRefTran.Text != "")
                        {
                            sqlsendSearch += " AND trans_id like '%" + txtRefTran.Text + "%' AND toll_recieve = '" + ddlsearchEndToll.SelectedValue + "' AND trans_stat = '" + ddlsearchType.SelectedValue + "' AND complete_stat = '" + status + "' Order By tbl_transfer.complete_stat ASC, STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        else
                        {
                            sqlsendSearch += " AND toll_recieve = '" + ddlsearchEndToll.SelectedValue + "' AND trans_stat = '" + ddlsearchType.SelectedValue + "' AND complete_stat = '" + status + "' Order By tbl_transfer.complete_stat ASC, STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        

                    }
                }
            }

            MySqlDataAdapter da = function.MySqlSelectDataSet(sqlsendSearch);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            gridTranlist.DataSource = ds.Tables[0];
            int countt = ds.Tables[0].Rows.Count;
            gridTranlist.DataBind();
            if(countt == 0)
            {
                lbAmountgrid.Text = "ไม่พบรายการที่ค้นหา..";
            }
            else { lbAmountgrid.Text = "พบ " + countt.ToString() + " รายการ"; }
        }

        protected void gridTranlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            LinkButton lbtntrans = (LinkButton)(e.Row.FindControl("lbtntrans"));
            if (lbtntrans != null)
            {
                lbtntrans.CommandName = (string)DataBinder.Eval(e.Row.DataItem, "trans_id");
            }

            Label lbEndtrans = (Label)(e.Row.FindControl("lbEndtrans"));
            if (lbEndtrans != null)
            {
                string gettollname = "SELECT toll_name from tbl_toll where toll_id = '" + lbEndtrans.Text + "' ";
                MySqlDataReader namee = function.MySqlSelect(gettollname);
                if (namee.Read())
                {
                    lbEndtrans.Text = namee.GetString("toll_name");
                }
                else { lbEndtrans.Text = "ยังไม่ระบุ"; }
            }
            Label lbstat = (Label)(e.Row.FindControl("lbstat"));
            if (lbstat != null)
            {
                lbstat.CssClass = "badge badge-" + (string)DataBinder.Eval(e.Row.DataItem, "complete_badge");
                lbtntrans.CssClass = (string)DataBinder.Eval(e.Row.DataItem, "complete_link");
                
            }
            LinkButton lbtnprintTran = (LinkButton)(e.Row.FindControl("lbtnprintTran"));
            if (lbstat != null)
            {
                lbtnprintTran.CommandName = (string)DataBinder.Eval(e.Row.DataItem, "trans_id");
                if (DataBinder.Eval(e.Row.DataItem, "complete_name").ToString() == "แจ้งใหม่" ||
                    DataBinder.Eval(e.Row.DataItem, "complete_name").ToString() == "สำเร็จ" )
                {
                    lbtnprintTran.Visible = true;
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //e.Row.Attributes["onmouseover"] = "onMouseOver('" + (e.Row.RowIndex + 1) + "')";
                //e.Row.Attributes["onmouseout"] = "onMouseOut('" + (e.Row.RowIndex + 1) + "')";
            }
            Label lbRowNum = (Label)(e.Row.FindControl("lbRowNum"));
            if (lbRowNum != null)
            {
                lbRowNum.Text = (gridTranlist.Rows.Count + 1).ToString() + ".";
            }
         
        }
        protected void lbtntrans_Command(object sender, CommandEventArgs e)
        {
            Session["TransID"] = e.CommandName;
            Session["TransNew"] = "1";
            Response.Redirect("/equip/EquipNewTrans");
        }

        protected void lbtnUptran_Command(object sender, CommandEventArgs e)
        {

        }

        protected void lbtnSearchSend_Command(object sender, CommandEventArgs e)
        {
            
            LoadPaging();
        }

        protected void btnMainEQ_Click(object sender, EventArgs e)
        {
            Response.Redirect("/equip/EquipMain");
        }

        protected void lbtnprintTran_Command(object sender, CommandEventArgs e)
        {
            ReModal = e.CommandName; 
            string checkcommand = e.CommandName;
            Session["TranRepId"] = e.CommandName;
            
        }
        public void AlertPop(string msg, string type)
        {
            switch (type)
            {
                case "success":
                    icons = "add_alert";
                    alertTypes = "success";
                    break;
                case "error":
                    icons = "error";
                    alertTypes = "danger";
                    break;
                case "warning":
                    icons = "warning";
                    alertTypes = "warning";
                    break;
            }
            //alertType = type;
            alerts = msg;
        }

        protected void lbtnGoReport_Command(object sender, CommandEventArgs e)
        {
            Session["CopyTran"] = "";
            if (txtSenderName.Text == "")
            {
                Session["SenderTran"] = ".";
            }
            else
            {
                Session["SenderTran"] = txtSenderName.Text;
            }
            if (txtPosSender.Text == "")
            {
                Session["PosSender"] = "..";
            }
            else
            {
                Session["PosSender"] = txtPosSender.Text;
            }

            ReportDocument rpt = new ReportDocument();

            if (Session["TranRepId"].ToString() != "")
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('/equip/EquipReportTran','_newtab');", true);
            }
            else
            {
                AlertPop("Error Report!! ติดต่อเจ้าหน้าที่", "error");
            }
        }

        protected void lbtnGoReportCopy_Command(object sender, CommandEventArgs e)
        {
            Session["CopyTran"] = "สำเนา";
            if (txtSenderName.Text == "")
            {
                Session["SenderTran"] = ".";
            }
            else
            {
                Session["SenderTran"] = txtSenderName.Text;
            }
            if (txtPosSender.Text == "")
            {
                Session["PosSender"] = "..";
            }
            else
            {
                Session["PosSender"] = txtPosSender.Text;
            }

            ReportDocument rpt = new ReportDocument();

            if (Session["TranRepId"].ToString() != "")
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('/equip/EquipReportTran','_newtab');", true);
            }
            else
            {
                AlertPop("Error Report!! ติดต่อเจ้าหน้าที่", "error");
            }
        }

        protected void gridTranlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridTranlist.PageIndex = e.NewPageIndex;
            LoadPaging();
        }
    }
}