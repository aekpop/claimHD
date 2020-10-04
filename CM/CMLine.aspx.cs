using ClaimProject.Config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ClaimProject.CM
{
    public partial class CMLine : System.Web.UI.Page
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
                //function.getListItem(ddlCMBudget, "SELECT cm_budget FROM tbl_cm_detail  GROUP BY cm_budget ORDER by cm_budget DESC", "cm_budget", "cm_budget");

                string sql = "";
                if (function.CheckLevel("Department", Session["UserPrivilegeId"].ToString()))
                {
                    sql = "SELECT * FROM tbl_cpoint ORDER BY cpoint_id";
                    function.getListItem(ddlCMLine, sql, "cpoint_name", "cpoint_id");

                }
                else
                {
                    sql = "SELECT * FROM tbl_cpoint WHERE cpoint_id = '" + Session["UserCpoint"].ToString() + "'";
                    function.getListItem(ddlCMLine, sql, "cpoint_name", "cpoint_id");

                }
                ddlCMLine.Items.Insert(0, new ListItem("เลือกด่านฯ", "0"));                
            }          
        }            
        public void Binddee()
        {             
            string cpointt = ddlCMLine.SelectedValue;
            colortoll = cpointt;
            AnnexZZ = ddlAnnex.SelectedValue;
            {
                if (lbBuild.Visible == true)
                {
                    string sqlchN = "SELECT COUNT(*) AS num FROM tbl_cm_detail cm JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                    " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                    " JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id " +
                    " WHERE cm.cm_detail_status_id='0'   AND c.cpoint_id = '" + cpointt + "' AND cm.cm_point LIKE '%" + ddlAnnex.SelectedValue + "%' " +
                    " ORDER BY STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC";
                    string sql = "SELECT * FROM tbl_cm_detail cm JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                    " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                    " JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id " +
                    " WHERE cm.cm_detail_status_id='0'   AND c.cpoint_id = '" + cpointt + "' AND cm.cm_point LIKE '%" + ddlAnnex.SelectedValue + "%' " +
                    " ORDER BY STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC";
                    MySqlDataReader chK = function.MySqlSelect(sqlchN);
                    if (chK.Read())
                    {
                        if (chK.GetInt32("num") != 0)
                        {
                            MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
                            System.Data.DataSet ds = new System.Data.DataSet();
                            da.Fill(ds);
                            gridCMLine.DataSource = ds.Tables[0];
                            gridCMLine.DataBind();
                        }
                        else
                        {
                            // สร้าง ตารางเสมือน Datatableพร้อม กำหนดฟิล
                            DataTable dtt = new DataTable();
                            dtt.Columns.Add(new DataColumn("cm_detail_id", typeof(string)));
                            dtt.Columns.Add(new DataColumn("cm_detail_sdate", typeof(string)));
                            dtt.Columns.Add(new DataColumn("cm_detail_stime", typeof(string)));
                            dtt.Columns.Add(new DataColumn("locate_name", typeof(string)));
                            dtt.Columns.Add(new DataColumn("device_name", typeof(string)));
                            dtt.Columns.Add(new DataColumn("cm_detail_problem", typeof(string)));
                            dtt.Columns.Add(new DataColumn("cm_detail_status_id", typeof(string)));
                            //สร้าง Row เสมือน Datarow เพื่อเป็นแถวของ Datatable
                            DataRow drr = null;
                            // สร้างแถวใหม่พร้อมกำหนดค่าลงไป
                            drr = dtt.NewRow();
                            drr["cm_detail_id"] = string.Empty;
                            drr["cm_detail_sdate"] = string.Empty;
                            drr["cm_detail_stime"] = string.Empty;
                            drr["locate_name"] = string.Empty;
                            drr["device_name"] = " ไม่มีอุปกรณ์เสียหาย ";
                            drr["cm_detail_problem"] = string.Empty;
                            drr["cm_detail_status_id"] = string.Empty;
                            dtt.Rows.Add(drr);
                            gridCMLine.DataSource = dtt;
                            gridCMLine.DataBind();
                        }
                    }


                }
                else
                {
                    string sqlchNN = "SELECT COUNT(*) AS num FROM tbl_cm_detail cm JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                    " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                    " JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id " +
                    " WHERE cm.cm_detail_status_id='0' AND c.cpoint_id = '" + cpointt + "'  " +
                    " ORDER BY STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC";
                    string sql = "SELECT * FROM tbl_cm_detail cm JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                    " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                    " JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id " +
                    " WHERE cm.cm_detail_status_id='0' AND c.cpoint_id = '" + cpointt + "'  " +
                    " ORDER BY STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC";
                    MySqlDataReader chKNN = function.MySqlSelect(sqlchNN);
                    if (chKNN.Read())
                    {
                        if (chKNN.GetInt32("num") != 0)
                        {

                            MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
                            System.Data.DataSet ds = new System.Data.DataSet();
                            da.Fill(ds);
                            gridCMLine.DataSource = ds.Tables[0];
                            gridCMLine.DataBind();
                        }
                        else
                        {
                            // สร้าง ตารางเสมือน Datatableพร้อม กำหนดฟิล
                            DataTable dtt = new DataTable();
                            dtt.Columns.Add(new DataColumn("cm_detail_id", typeof(string)));
                            dtt.Columns.Add(new DataColumn("cm_detail_sdate", typeof(string)));
                            dtt.Columns.Add(new DataColumn("cm_detail_stime", typeof(string)));
                            dtt.Columns.Add(new DataColumn("locate_name", typeof(string)));
                            dtt.Columns.Add(new DataColumn("device_name", typeof(string)));
                            dtt.Columns.Add(new DataColumn("cm_detail_problem", typeof(string)));
                            dtt.Columns.Add(new DataColumn("cm_detail_status_id", typeof(string)));
                            //สร้าง Row เสมือน Datarow เพื่อเป็นแถวของ Datatable
                            DataRow drr = null;
                            // สร้างแถวใหม่พร้อมกำหนดค่าลงไป
                            drr = dtt.NewRow();
                            drr["cm_detail_id"] = string.Empty;
                            drr["cm_detail_sdate"] = string.Empty;
                            drr["cm_detail_stime"] = string.Empty;
                            drr["locate_name"] = string.Empty;
                            drr["device_name"] = " ไม่มีอุปกรณ์เสียหาย ";
                            drr["cm_detail_problem"] = string.Empty;
                            drr["cm_detail_status_id"] = string.Empty;
                            dtt.Rows.Add(drr);
                            gridCMLine.DataSource = dtt;
                            gridCMLine.DataBind();
                        }
                    }
                }
            
            }
        }

        public void gridCMLine_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbnoo = (Label)(e.Row.FindControl("lbnoo"));
            if (lbnoo != null)
            {
                lbnoo.Text = (gridCMLine.Rows.Count + 1).ToString() + ".";
            }

            Label lbStt = (Label)(e.Row.FindControl("lbStt"));
            if (lbStt != null)
            {
                lbStt.Text = function.GetStatusCM(DataBinder.Eval(e.Row.DataItem, "cm_detail_status_id").ToString());
            }

            


            Label lbSDate = (Label)(e.Row.FindControl("lbSDate"));
            if (lbSDate != null)
            {
                lbSDate.Text = function.ConvertDateShortThai((string)DataBinder.Eval(e.Row.DataItem, "cm_detail_sdate"));
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
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
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (colortoll == "701")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "702")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "703")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "704")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "706")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "707")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "708")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "709")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "710")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "902")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "903")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "904")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "905")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
            }
        }

        protected void btnrecm_Click(object sender, EventArgs e)
        {

            Binddee();
        }

        protected void ddlCMLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCMLine.SelectedValue == "703")
            {
                lbBuild.Visible = true;
                ddlAnnex.Visible = true;
            }
            else if (ddlCMLine.SelectedValue == "704")
            {
                lbBuild.Visible = true;
                ddlAnnex.Visible = true;
            }
            else if (ddlCMLine.SelectedValue == "706")
            {
                lbBuild.Visible = true;
                ddlAnnex.Visible = true;
            }
            else if (ddlCMLine.SelectedValue == "707")
            {
                lbBuild.Visible = true;
                ddlAnnex.Visible = true;
            }
            else if (ddlCMLine.SelectedValue == "708")
            {
                lbBuild.Visible = true;
                ddlAnnex.Visible = true;
            }
            else if (ddlCMLine.SelectedValue == "709")
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

        protected void printimg_Click(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/CM/DefaultCM.aspx");
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

        protected void gridCMLine_RowCreated(object sender, GridViewRowEventArgs e)
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
                    lbHeadToll.Text = "ด่านฯ อู่ตาเภา ";
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
                HeaderCell.Text = "รายงานแจ้งซ่อมอุปกรณ์ CM";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                gridCMLine.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }     
    }
}