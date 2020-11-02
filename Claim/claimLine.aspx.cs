using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClaimProject.Config;
using MySql.Data.MySqlClient;

namespace ClaimProject.Claim
{
    public partial class claimLine : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public string colortoll = "0";
        public string AnnexZZ = "";

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Session["user"] == null)
            {
                Response.Redirect("/");
            }

            if (!this.IsPostBack)
            {
                //function.getListItem(ddlClaimBudget, "SELECT cm_budget FROM tbl_cm_detail  GROUP BY cm_budget ORDER by cm_budget DESC", "cm_budget", "cm_budget");

                string sql = "";
                if (function.CheckLevel("Department", Session["UserPrivilegeId"].ToString()))
                {
                    sql = "SELECT * FROM tbl_cpoint ORDER BY cpoint_id";
                    function.getListItem(ddlClaimLine, sql, "cpoint_name", "cpoint_id");

                }
                else
                {
                    sql = "SELECT * FROM tbl_cpoint WHERE cpoint_id = '" + Session["UserCpoint"].ToString() + "'";
                    function.getListItem(ddlClaimLine, sql, "cpoint_name", "cpoint_id");

                }
                ddlClaimLine.Items.Insert(0, new ListItem("เลือกด่านฯ", "0"));
            }
        }

        public void Binddee()
        {
            string cpointt = ddlClaimLine.SelectedValue;
            colortoll = cpointt;
            AnnexZZ = ddlAnnex.SelectedValue;
            {
                if (lbBuild.Visible == true)
                {
                    string sqlchN = "SELECT COUNT(*) AS num FROM tbl_claim cl JOIN  tbl_cpoint cp ON cl.claim_cpoint = cp.cpoint_id " +
                    "JOIN tbl_device_damaged d ON d.claim_id = cl.claim_id JOIN tbl_claim_com t ON cl.claim_id = t.claim_id " +
                    "JOIN tbl_device v ON v.device_id = d.device_id JOIN tbl_status s ON cl.claim_status = s.status_id " +
                    " WHERE cl.claim_delete = '0' AND cl.claim_status BETWEEN 1 AND 4 AND cp.cpoint_id = '" + cpointt + "'  AND d.device_damaged_delete = '0' " +
                    " AND cl.claim_point LIKE '%" + ddlAnnex.SelectedValue + "%'  ORDER BY STR_TO_DATE(cl.claim_start_date, '%d-%m-%Y') DESC";
                    string sql = "SELECT * FROM tbl_claim cl JOIN  tbl_cpoint cp ON cl.claim_cpoint = cp.cpoint_id " +
                    "JOIN tbl_device_damaged d ON d.claim_id = cl.claim_id JOIN tbl_claim_com t ON cl.claim_id = t.claim_id " +
                    "JOIN tbl_device v ON v.device_id = d.device_id JOIN tbl_status s ON cl.claim_status = s.status_id " +
                    " WHERE cl.claim_delete = '0' AND cl.claim_status BETWEEN 1 AND 4 AND cp.cpoint_id = '" + cpointt + "' AND d.device_damaged_delete = '0' " +
                    " AND cl.claim_point LIKE '%" + ddlAnnex.SelectedValue + "%' ORDER BY STR_TO_DATE(cl.claim_start_date, '%d-%m-%Y') DESC";
                    MySqlDataReader chK = function.MySqlSelect(sqlchN);
                    if (chK.Read())
                    {
                        if (chK.GetInt32("num") != 0)
                        {
                            MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
                            System.Data.DataSet ds = new System.Data.DataSet();
                            da.Fill(ds);
                            gridClaimLine.DataSource = ds.Tables[0];
                            gridClaimLine.DataBind();
                        }
                        else
                        {
                            // สร้าง ตารางเสมือน Datatableพร้อม กำหนดฟิล
                            DataTable dtt = new DataTable();
                            dtt.Columns.Add(new DataColumn("claim_id", typeof(string)));
                            dtt.Columns.Add(new DataColumn("claim_start_date", typeof(string)));
                            dtt.Columns.Add(new DataColumn("claim_detail_time", typeof(string)));
                            dtt.Columns.Add(new DataColumn("claim_detail_cb_claim", typeof(string)));
                            dtt.Columns.Add(new DataColumn("device_name", typeof(string)));
                            dtt.Columns.Add(new DataColumn("device_damaged", typeof(string)));
                            dtt.Columns.Add(new DataColumn("status_name", typeof(string)));
                            //สร้าง Row เสมือน Datarow เพื่อเป็นแถวของ Datatable
                            DataRow drr = null;
                            // สร้างแถวใหม่พร้อมกำหนดค่าลงไป
                            drr = dtt.NewRow();
                            drr["claim_id"] = string.Empty;
                            drr["claim_start_date"] = string.Empty;
                            drr["claim_detail_time"] = string.Empty;
                            drr["claim_detail_cb_claim"] = string.Empty;
                            drr["device_name"] = " ไม่มีอุปกรณ์เสียหาย ";
                            drr["device_damaged"] = string.Empty;
                            drr["status_name"] = string.Empty;
                            dtt.Rows.Add(drr);
                            gridClaimLine.DataSource = dtt;
                            gridClaimLine.DataBind();
                        }
                    }
                    //chK.Close();
                    function.Close();


                }
                else
                {
                    string sqlchNN = "SELECT COUNT(*) AS num FROM tbl_claim cl JOIN  tbl_cpoint cp ON cl.claim_cpoint = cp.cpoint_id " +
                                     "JOIN tbl_device_damaged d ON d.claim_id = cl.claim_id JOIN tbl_claim_com t ON cl.claim_id = t.claim_id " +
                                     "JOIN tbl_device v ON v.device_id = d.device_id JOIN tbl_status s ON cl.claim_status = s.status_id " +
                    " WHERE cl.claim_delete = '0' AND cl.claim_status BETWEEN 1 AND 4 AND cp.cpoint_id = '" + cpointt + "'  AND d.device_damaged_delete = '0' " +
                    " ORDER BY STR_TO_DATE(cl.claim_start_date, '%d-%m-%Y') DESC";
                    string sql = "SELECT claim_start_date,claim_detail_time,claim_detail_cb_claim,device_name,device_damaged,status_name FROM tbl_claim cl JOIN  tbl_cpoint cp ON cl.claim_cpoint = cp.cpoint_id " +
                                     "JOIN tbl_device_damaged d ON d.claim_id = cl.claim_id JOIN tbl_claim_com t ON cl.claim_id = t.claim_id " +
                                     "JOIN tbl_device v ON v.device_id = d.device_id JOIN tbl_status s ON cl.claim_status = s.status_id " +
                    " WHERE cl.claim_delete = '0' AND cl.claim_status BETWEEN 1 AND 4 AND cp.cpoint_id = '" + cpointt + "' AND d.device_damaged_delete = '0' AND cl.claim_delete = '0' " +
                    " ORDER BY STR_TO_DATE(cl.claim_start_date, '%d-%m-%Y') DESC";
                    MySqlDataReader chKNN = function.MySqlSelect(sqlchNN);
                    if (chKNN.Read())
                    {
                        if (chKNN.GetInt32("num") != 0)
                        {

                            MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
                            System.Data.DataSet ds = new System.Data.DataSet();
                            da.Fill(ds);
                            gridClaimLine.DataSource = ds.Tables[0];
                            gridClaimLine.DataBind();
                        }
                        else
                        {
                            // สร้าง ตารางเสมือน Datatableพร้อม กำหนดฟิล
                            DataTable dtt = new DataTable();
                            dtt.Columns.Add(new DataColumn("claim_id", typeof(string)));
                            dtt.Columns.Add(new DataColumn("claim_start_date", typeof(string)));
                            dtt.Columns.Add(new DataColumn("claim_detail_time", typeof(string)));
                            dtt.Columns.Add(new DataColumn("claim_detail_cb_claim", typeof(string)));
                            dtt.Columns.Add(new DataColumn("device_name", typeof(string)));
                            dtt.Columns.Add(new DataColumn("device_damaged", typeof(string)));
                            dtt.Columns.Add(new DataColumn("status_name", typeof(string)));
                            //สร้าง Row เสมือน Datarow เพื่อเป็นแถวของ Datatable
                            DataRow drr = null;
                            // สร้างแถวใหม่พร้อมกำหนดค่าลงไป
                            drr = dtt.NewRow();
                            drr["claim_id"] = string.Empty;
                            drr["claim_start_date"] = string.Empty;
                            drr["claim_detail_time"] = string.Empty;
                            drr["claim_detail_cb_claim"] = string.Empty;
                            drr["device_name"] = " ไม่มีอุปกรณ์เสียหาย ";
                            drr["device_damaged"] = string.Empty;
                            drr["status_name"] = string.Empty;
                            dtt.Rows.Add(drr);
                            gridClaimLine.DataSource = dtt;
                            gridClaimLine.DataBind();
                        }
                    }
                    //chKNN.Close();
                    function.Close();
                }

            }
        }

        protected void ddlClaimLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClaimLine.SelectedValue == "703")
            {
                lbBuild.Visible = true;
                ddlAnnex.Visible = true;
            }
            else if (ddlClaimLine.SelectedValue == "704")
            {
                lbBuild.Visible = true;
                ddlAnnex.Visible = true;
            }
            else if (ddlClaimLine.SelectedValue == "706")
            {
                lbBuild.Visible = true;
                ddlAnnex.Visible = true;
            }
            else if (ddlClaimLine.SelectedValue == "707")
            {
                lbBuild.Visible = true;
                ddlAnnex.Visible = true;
            }
            else if (ddlClaimLine.SelectedValue == "708")
            {
                lbBuild.Visible = true;
                ddlAnnex.Visible = true;
            }
            else if (ddlClaimLine.SelectedValue == "709")
            {
                lbBuild.Visible = true;
                ddlAnnex.Visible = true;
            }
            else
            {
                lbBuild.Visible = false;
                ddlAnnex.Visible = false;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Claim/DefaultClaim.aspx");
        }

        protected void btnrecm_Click(object sender, EventArgs e)
        {
            Binddee();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string base64 = Request.Form[hfImageData.UniqueID].Split(',')[1];
            byte[] bytes = Convert.FromBase64String(base64);
            Response.Clear();
            Response.ContentType = "image/png";
            Response.AddHeader("Content-Disposition", "attachment; filename=GridView.png");
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
        }

        protected void printimg_Click(object sender, EventArgs e)
        {

        }

        protected void gridClaimLine_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbnoo = (Label)(e.Row.FindControl("lbnoo"));
            if (lbnoo != null)
            {
                lbnoo.Text = (gridClaimLine.Rows.Count + 1).ToString() + ".";
            }       
        }

        protected void gridClaimLine_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();

                if (colortoll == "701")
                {

                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff52");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.Text = "ด่านฯ ลาดกระบัง";
                    lbShift.Text = ddlShift.SelectedItem.Text;
                }
                else if (colortoll == "702")
                {

                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#24e5ff");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.Text = "ด่านฯ บางบ่อ";
                    lbShift.Text = ddlShift.SelectedItem.Text;
                }
                else if (colortoll == "703")
                {

                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#fc3535");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.Text = "ด่านฯ บางปะกง " + AnnexZZ;
                    lbShift.Text = ddlShift.SelectedItem.Text;
                }
                else if (colortoll == "704")
                {

                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#fc92ee");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.Text = "ด่านฯ พนัสนิคม " + AnnexZZ;
                    lbShift.Text = ddlShift.SelectedItem.Text;
                }
                else if (colortoll == "706")
                {

                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#d080ff");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.Text = "ด่านฯ บ้านบึง " + AnnexZZ;
                    lbShift.Text = ddlShift.SelectedItem.Text;
                }
                else if (colortoll == "707")
                {

                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#282bf7");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    lbHeadToll.Text = "ด่านฯ บางพระ(คีรี) " + AnnexZZ;
                    lbShift.Text = ddlShift.SelectedItem.Text;
                }
                else if (colortoll == "708")
                {

                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#51ed51");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.Text = "ด่านฯ หนองขาม " + AnnexZZ;
                    lbShift.Text = ddlShift.SelectedItem.Text;
                }
                else if (colortoll == "709")
                {

                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#87561e");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    lbHeadToll.Text = "ด่านฯ โป่ง " + AnnexZZ;
                    lbShift.Text = ddlShift.SelectedItem.Text;
                }
                else if (colortoll == "710")
                {

                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#5d5d5e");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    lbHeadToll.Text = "ด่านฯ พัทยา ";
                    lbShift.Text = ddlShift.SelectedItem.Text;
                }
                else if (colortoll == "711")
                {
                    lbHeadToll.Text = "ด่านฯ ห้วยใหญ่ ";
                    lbShift.Text = ddlShift.SelectedItem.Text;
                }
                else if (colortoll == "712")
                {
                    lbHeadToll.Text = "ด่านฯ เขาชีโอน ";
                    lbShift.Text = ddlShift.SelectedItem.Text;
                }
                else if (colortoll == "713")
                {
                    lbHeadToll.Text = "ด่านฯ อู่ตะเภา ";
                    lbShift.Text = ddlShift.SelectedItem.Text;
                }
                else if (colortoll == "902")
                {

                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#c1f21d");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.Text = "ด่านฯ ทับช้าง 1";
                    lbShift.Text = ddlShift.SelectedItem.Text;

                }
                else if (colortoll == "903")
                {

                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#fab641");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.Text = "ด่านฯ ทับช้าง 2";
                    lbShift.Text = ddlShift.SelectedItem.Text;
                }
                else if (colortoll == "904")
                {

                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#5702d6");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    lbHeadToll.Text = "ด่านฯ ธัญบุรี 1";
                    lbShift.Text = ddlShift.SelectedItem.Text;
                }
                else if (colortoll == "905")
                {

                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#49fcc4");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.Text = "ด่านฯ ธัญบุรี 2";
                    lbShift.Text = ddlShift.SelectedItem.Text;
                }

                HeaderCell = new TableCell();
                HeaderCell.Text = lbHeadToll.Text;
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = ddlShift.SelectedItem.Text;
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = lbDatep.Text;
                HeaderCell.ColumnSpan = 1;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "รายงานอุบัติเหตุ";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                gridClaimLine.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }
    }
}