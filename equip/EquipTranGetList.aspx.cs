using System;
using ClaimProject.Config;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace ClaimProject.equip
{
    public partial class EquipTranGetList : System.Web.UI.Page
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
                Session["TransID"] = "";
                Session["TransNew"] = "";
                Session["BackWhat"] = "Get";
                function.getListItem(ddlsearchEndToll, "SELECT * FROM tbl_toll Order By toll_id ASC", "toll_name", "toll_id");
                function.getListItem(ddlsearchType, "SELECT * FROM tbl_transfer_status Order by trans_stat_id ASC ", "trans_stat_name", "trans_stat_id");
                function.getListItem(ddlsearchStat, "SELECT * FROM tbl_trans_complete WHERE complete_id != '1' AND complete_id != '4'  AND complete_id != '5' AND complete_id != '6'  order by complete_id asc ", "complete_name", "complete_id");
                ddlsearchEndToll.Items.Insert(0, new ListItem("ทั้งหมด", "0"));
                ddlsearchType.Items.Insert(0, new ListItem("ทั้งหมด", "0"));
                ddlsearchStat.Items.Insert(0, new ListItem("ทั้งหมด", "0"));
                ddlsearchStat.SelectedItem.Value = Session["ddlsearchStat"].ToString();
            }
            LineGetTran();
            LoadPaging();
            Session["ddlsearchStat"] = "0";

        }
        protected void LineGetTran()
        {
            if (Session["LineTran"].ToString() != "")
            {
                SreviceLine.WebService_Server serviceLine = new SreviceLine.WebService_Server();
                serviceLine.MessageToServer("wDLRWPWgBvJRMEk69ebQVGumxOfiTKCgXoUwKeKPQyh", Session["LineTran"].ToString(), "", 1, 41);
                Session["LineTran"] = "";
            }

        }
        protected void LoadPaging()
        {
            
            string TransRef = Session["TransID"].ToString();
            //COLLATE utf8_general_ci
            string sqlsendSearch = "SELECT * FROM tbl_transfer " +
                         " JOIN tbl_transfer_status on tbl_transfer.trans_stat = tbl_transfer_status.trans_stat_id" +
                         " JOIN tbl_toll on tbl_toll.toll_id = tbl_transfer.toll_send " +
                         " JOIN tbl_trans_complete on tbl_trans_complete.complete_id = tbl_transfer.complete_stat ";

            string type = ddlsearchType.SelectedValue;
            string EndState = ddlsearchEndToll.SelectedValue;
            string status = ddlsearchStat.SelectedValue;
            if (Session["UserCpoint"].ToString() == "0")
            {
                if (Session["User"].ToString() == "sawitree")
                {
                    sqlsendSearch += "WHERE (toll_send ='7010' or toll_send ='9010' " +
                        "or toll_send ='9020' or toll_send ='9030' )";
                }
                else if (Session["User"].ToString() == "supaporn")
                {
                    sqlsendSearch += "WHERE (toll_send ='7020' or toll_send ='7031' " +
                        "or toll_send ='7032' or toll_send ='7033' or toll_send ='7041' " +
                        "or toll_send ='7042' or toll_send ='7051' " +
                        "or toll_send ='7052' or toll_send ='7061' or toll_send ='7062' " +
                        "or toll_send ='7063' or toll_send ='7064') ";
                }
                else
                {
                    sqlsendSearch += " WHERE (toll_recieve = '9200' OR toll_recieve = '9300' OR toll_recieve = '9400' OR toll_recieve = '9500')  ";
                }
            }
            else
            {
                if(Session["UserCpoint"].ToString() == "701")
                {
                    sqlsendSearch += "WHERE (toll_recieve ='7010' ) ";
                }
                else if(Session["UserCpoint"].ToString() == "702")
                {
                    sqlsendSearch += "WHERE (toll_recieve ='7020' )  ";
                }
                else if (Session["UserCpoint"].ToString() == "703")
                {
                    sqlsendSearch += "WHERE (toll_recieve ='7031' or toll_recieve ='7032' or toll_recieve ='7033' ) ";
                }
                else if (Session["UserCpoint"].ToString() == "704")
                {
                    sqlsendSearch += "WHERE (toll_recieve ='7041' or toll_recieve ='7042' ) ";
                }
                else if (Session["UserCpoint"].ToString() == "706")
                {
                    sqlsendSearch += "WHERE (toll_recieve ='7051' or toll_recieve ='7052' ) ";
                }
                else if (Session["UserCpoint"].ToString() == "707")
                {
                    sqlsendSearch += "WHERE ( toll_recieve ='7061' or toll_recieve ='7062' " +
                        "or toll_recieve ='7063' or toll_recieve ='7064' )";
                }
                else if (Session["UserCpoint"].ToString() == "708")
                {
                    sqlsendSearch += "WHERE (toll_recieve ='7071' or toll_recieve ='7072' " +
                        "or toll_recieve ='7073' or toll_recieve ='7074' or toll_recieve ='7075' " +
                        "or toll_recieve ='7076' ) ";
                }
                else if (Session["UserCpoint"].ToString() == "709")
                {
                    sqlsendSearch += "WHERE (toll_recieve ='7081' or toll_recieve ='7082' " +
                        "or toll_recieve ='7083' or toll_recieve ='7084' )";
                }
                else if (Session["UserCpoint"].ToString() == "710")
                {
                    sqlsendSearch += "WHERE toll_recieve ='7090'  ";
                }
                else if (Session["UserCpoint"].ToString() == "711")
                {
                    sqlsendSearch += "WHERE toll_recieve ='7100'  ";
                }
                else if (Session["UserCpoint"].ToString() == "712")
                {
                    sqlsendSearch += "WHERE toll_recieve ='7110'  ";
                }
                else if (Session["UserCpoint"].ToString() == "713")
                {
                    sqlsendSearch += "WHERE (toll_recieve ='7120' ) ";
                }
                else if (Session["UserCpoint"].ToString() == "902")
                {
                    sqlsendSearch += "WHERE (toll_recieve ='9010' ) ";
                }
                else if (Session["UserCpoint"].ToString() == "903")
                {
                    sqlsendSearch += "WHERE (toll_recieve ='9020' ) ";
                }
                else if (Session["UserCpoint"].ToString() == "904")
                {
                    sqlsendSearch += "WHERE (toll_recieve ='9030' ) ";
                }
                else if (Session["UserCpoint"].ToString() == "905")
                {
                    sqlsendSearch += "WHERE (toll_recieve ='9040' ) ";
                }
            }

            if (EndState == "0") // ทุกปลายทาง
            {
                if (type == "0")// ทุกประเภทรายการ
                {
                    if (status == "0") //ทุกสถานะ
                    {
                        if (txtRefTran.Text != "")
                        {
                            sqlsendSearch += " AND trans_stat !='7' AND trans_id like '%" + txtRefTran.Text + "%' AND complete_stat IN (2,3) Order By FIELD(complete_stat,2,3), STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        else
                        {
                            sqlsendSearch += " AND trans_stat !='7' AND complete_stat IN (2,3) Order By FIELD(complete_stat,2,3), STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        
                    }
                    else
                    {
                        if (txtRefTran.Text != "")
                        {
                            sqlsendSearch += " AND trans_stat !='7' AND trans_id like '%" + txtRefTran.Text + "%' AND complete_stat = '" + status + "' Order By  STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        else
                        {
                            sqlsendSearch += " AND trans_stat !='7' AND complete_stat = '" + status + "' Order By  STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        

                    }
                }
                else
                {
                    if (status == "0") //ทุกสถานะ
                    {
                        if (txtRefTran.Text != "")
                        {
                            sqlsendSearch += " AND trans_id like '%" + txtRefTran.Text + "%'  AND trans_stat = '" + ddlsearchType.SelectedValue + "' AND complete_stat IN (2,3,6) Order By FIELD(complete_stat,2,6,3), STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        else
                        {
                            sqlsendSearch += " AND trans_stat = '" + ddlsearchType.SelectedValue + "' AND complete_stat IN (2,3) Order By FIELD(complete_stat,2,3), STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                       

                    }
                    else
                    {
                        if (txtRefTran.Text != "")
                        {
                            sqlsendSearch += " AND trans_id like '%" + txtRefTran.Text + "%' AND trans_stat = '" + ddlsearchType.SelectedValue + "' AND complete_stat = '" + status + "' Order By  STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        else
                        {
                            sqlsendSearch += " AND trans_stat = '" + ddlsearchType.SelectedValue + "' AND complete_stat = '" + status + "' Order By  STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
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
                            sqlsendSearch += " AND trans_stat !='7' AND trans_id like '%" + txtRefTran.Text + "%'  AND toll_recieve = '" + ddlsearchEndToll.SelectedValue + "' AND complete_stat IN (2,3) Order By FIELD(complete_stat,2,3), STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        else
                        {
                            sqlsendSearch += " AND trans_stat !='7' AND toll_recieve = '" + ddlsearchEndToll.SelectedValue + "' AND complete_stat IN (2,3) Order By FIELD(complete_stat,2,3), STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        

                    }
                    else
                    {
                        if (txtRefTran.Text != "")
                        {
                            sqlsendSearch += " AND trans_stat !='7' AND trans_id like '%" + txtRefTran.Text + "%' AND toll_recieve = '" + ddlsearchEndToll.SelectedValue + "' AND complete_stat = '" + status + "' Order By  STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        else
                        {
                            sqlsendSearch += " AND trans_stat !='7' AND toll_recieve = '" + ddlsearchEndToll.SelectedValue + "' AND complete_stat = '" + status + "' Order By STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        

                    }
                }
                else
                {
                    if (status == "0") //ทุกสถานะ
                    {
                        if (txtRefTran.Text != "")
                        {
                            sqlsendSearch += " AND trans_id like '%" + txtRefTran.Text + "%'  AND toll_recieve = '" + ddlsearchEndToll.SelectedValue + "' AND trans_stat = '" + ddlsearchType.SelectedValue + "' AND complete_stat IN (2,3) Order By FIELD(complete_stat,2,3), STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        else
                        {
                            sqlsendSearch += " AND toll_recieve = '" + ddlsearchEndToll.SelectedValue + "' AND trans_stat = '" + ddlsearchType.SelectedValue + "' AND complete_stat IN (2,3) Order By FIELD(complete_stat,2,3), STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";
                        }
                        

                    }
                    else  // เลือกเฉพาะทุกอย่าง
                    {
                        if (txtRefTran.Text != "")
                        {
                            sqlsendSearch += " AND trans_id like '%" + txtRefTran.Text + "%' AND toll_recieve = '" + ddlsearchEndToll.SelectedValue + "' AND trans_stat = '" + ddlsearchType.SelectedValue + "' AND complete_stat = '" + status + "' Order By  STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";

                        }
                        else
                        {
                            sqlsendSearch += " AND toll_recieve = '" + ddlsearchEndToll.SelectedValue + "' AND trans_stat = '" + ddlsearchType.SelectedValue + "' AND complete_stat = '" + status + "' Order By  STR_TO_DATE(date_send, '%d-%m-%Y') DESC ";

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
            if (countt == 0)
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

                lbtntrans.Visible = true;

            }
            Label lbstat = (Label)(e.Row.FindControl("lbstat"));
            if (lbstat != null)
            {
                if(lbstat.Text == "รอซ่อม")
                {
                    lbstat.CssClass = "badge";
                    lbstat.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
                    lbstat.BackColor = System.Drawing.ColorTranslator.FromHtml("#542285");
                }
                else
                {
                    lbstat.CssClass = "badge badge-" + (string)DataBinder.Eval(e.Row.DataItem, "complete_badge");
                }
                
                lbtntrans.CssClass = (string)DataBinder.Eval(e.Row.DataItem, "complete_link");

            }

            Label lbEndtrans = (Label)(e.Row.FindControl("lbEndtrans"));
            if (lbEndtrans != null)
            {
                string gettollname = "SELECT toll_name from tbl_toll where toll_id = '" + lbEndtrans.Text + "' ";
                MySqlDataReader namee = function.MySqlSelect(gettollname);
                if (namee.Read())
                {
                    lbEndtrans.Text = namee.GetString("toll_name");
                    namee.Close();
                }
                else
                {
                    if(lbstat.Text == "รอซ่อม")
                    {
                        string companyname = "select company_name FROM tbl_transfer d " +
                            " JOIN tbl_company e ON e.company_id = d.company_repair" +
                            " WHERE trans_id = '"+ lbtntrans.CommandName + "'";
                        MySqlDataReader comp = function.MySqlSelect(companyname);
                        if(comp.Read())
                        {
                            lbEndtrans.Text = function.ShortTextCom(comp.GetString("company_name"));
                            comp.Close();
                        }
                        else
                        {
                            lbEndtrans.Text = "-";
                        }
                    }
                    else
                    {
                        lbEndtrans.Text = "ยังไม่ระบุ";
                    }
                    
                }
            }
            

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2ffd9");
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Session["User"].ToString() == "pornwimon")
                {
                    e.Row.Cells[0].Visible = false;
                }
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
        
    }
}