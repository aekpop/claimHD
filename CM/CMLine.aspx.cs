using ClaimProject.Config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            }

        }

        public void Binddee ()
        {
            string cpointt = ddlCMLine.SelectedValue;
            colortoll = cpointt;
            AnnexZZ = ddlAnnex.SelectedValue;
            if (lbBuild.Visible == true)
            {
                string sql = "SELECT * FROM tbl_cm_detail cm JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                    " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                    " JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id " +
                    " WHERE cm.cm_detail_status_id='0'   AND c.cpoint_id = '" + cpointt + "' AND cm.cm_point LIKE '%"+ddlAnnex.SelectedValue+"%' " +
                    " ORDER BY STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC";
                MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds);
                gridCMLine.DataSource = ds.Tables[0];
                gridCMLine.DataBind();
            }
            else
            {
                string sql = "SELECT * FROM tbl_cm_detail cm JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                    " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                    " JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id " +
                    " WHERE (cm.cm_detail_status_id='0' OR cm.cm_detail_status_id='1')  AND c.cpoint_id = '" + cpointt + "'  " +
                    " ORDER BY STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC";
                MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds);
                gridCMLine.DataSource = ds.Tables[0];
                gridCMLine.DataBind();
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
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff52");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff52");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff52");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff52");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff52");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff52");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff52");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff52");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.Text = "ด่านฯ ลาดกระบัง";
                }
                else if (colortoll == "702")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#24e5ff");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#24e5ff");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#24e5ff");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#24e5ff");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#24e5ff");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#24e5ff");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#24e5ff");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#24e5ff");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.Text = "ด่านฯ บางบ่อ";
                }
                else if (colortoll == "703")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#fc3535");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#fc3535");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#fc3535");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#fc3535");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#fc3535");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#fc3535");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#fc3535");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#fc3535");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.Text = "ด่านฯ บางปะกง "+AnnexZZ;
                }
                else if (colortoll == "704")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#fc92ee");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#fc92ee");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#fc92ee");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#fc92ee");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#fc92ee");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#fc92ee");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#fc92ee");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#fc92ee");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.Text = "ด่านฯ พนัสนิคม " + AnnexZZ;
                }
                else if (colortoll == "706")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#d080ff");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#d080ff");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#d080ff");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#d080ff");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#d080ff");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#d080ff");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#d080ff");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#d080ff");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.Text = "ด่านฯ บ้านบึง " + AnnexZZ;
                }
                else if (colortoll == "707")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#282bf7");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#282bf7");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#282bf7");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#282bf7");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#282bf7");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#282bf7");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#282bf7");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#282bf7");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    lbHeadToll.Text = "ด่านฯ บางพระ(คีรี) " + AnnexZZ;
                }
                else if (colortoll == "708")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#51ed51");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#51ed51");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#51ed51");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#51ed51");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#51ed51");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#51ed51");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#51ed51");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#51ed51");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.Text = "ด่านฯ หนองขาม " + AnnexZZ;
                }
                else if (colortoll == "709")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#87561e");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#87561e");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#87561e");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#87561e");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#87561e");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#87561e");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#87561e");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#87561e");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    lbHeadToll.Text = "ด่านฯ โป่ง " + AnnexZZ;
                }
                else if (colortoll == "710")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#5d5d5e");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#5d5d5e");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#5d5d5e");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#5d5d5e");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#5d5d5e");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#5d5d5e");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#5d5d5e");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#5d5d5e");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    lbHeadToll.Text = "ด่านฯ พัทยา ";
                }
                else if (colortoll == "902")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#c1f21d");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#c1f21d");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#c1f21d");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#c1f21d");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#c1f21d");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#c1f21d");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#c1f21d");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#c1f21d");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.Text = "ด่านฯ ทับช้าง 1";
                }
                else if (colortoll == "903")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#fab641");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#fab641");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#fab641");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#fab641");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#fab641");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#fab641");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#fab641");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#fab641");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.Text = "ด่านฯ ทับช้าง 2";
                }
                else if (colortoll == "904")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#5702d6");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#5702d6");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#5702d6");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#5702d6");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#5702d6");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#5702d6");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#5702d6");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#5702d6");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    lbHeadToll.Text = "ด่านฯ ธัญบุรี 1";
                }
                else if (colortoll == "905")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#49fcc4");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#49fcc4");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#49fcc4");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#49fcc4");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#49fcc4");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#49fcc4");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#49fcc4");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.BackColor = System.Drawing.ColorTranslator.FromHtml("#49fcc4");
                    lbHeadToll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lbHeadToll.Text = "ด่านฯ ธัญบุรี 2";
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if(colortoll == "701")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffc7");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffc7");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffc7");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffc7");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffc7");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffc7");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffc7");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "702")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#c9f9ff");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#c9f9ff");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#c9f9ff");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#c9f9ff");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#c9f9ff");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#c9f9ff");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#c9f9ff");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "703")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffa6a6");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffa6a6");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffa6a6");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffa6a6");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffa6a6");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffa6a6");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffa6a6");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "704")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffd9fa");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffd9fa");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffd9fa");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffd9fa");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffd9fa");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffd9fa");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffd9fa");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "706")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#efd4ff");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#efd4ff");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#efd4ff");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#efd4ff");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#efd4ff");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#efd4ff");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#efd4ff");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "707")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#c8c9fa");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#c8c9fa");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#c8c9fa");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#c8c9fa");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#c8c9fa");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#c8c9fa");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#c8c9fa");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "708")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#c7fcc7");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#c7fcc7");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#c7fcc7");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#c7fcc7");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#c7fcc7");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#c7fcc7");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#c7fcc7");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "709")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#e3cdb3");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#e3cdb3");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#e3cdb3");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#e3cdb3");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#e3cdb3");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#e3cdb3");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#e3cdb3");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "710")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#d4d4d6");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#d4d4d6");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#d4d4d6");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#d4d4d6");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#d4d4d6");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#d4d4d6");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#d4d4d6");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "902")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#e6fc9d");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#e6fc9d");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#e6fc9d");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#e6fc9d");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#e6fc9d");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#e6fc9d");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#e6fc9d");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "903")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffe9c4");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffe9c4");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffe9c4");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffe9c4");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffe9c4");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffe9c4");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffe9c4");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "904")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#e2cfff");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#e2cfff");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#e2cfff");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#e2cfff");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#e2cfff");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#e2cfff");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#e2cfff");
                    e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                }
                else if (colortoll == "905")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#d1fff1");
                    e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#d1fff1");
                    e.Row.Cells[1].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#d1fff1");
                    e.Row.Cells[2].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#d1fff1");
                    e.Row.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#d1fff1");
                    e.Row.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#d1fff1");
                    e.Row.Cells[5].ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#d1fff1");
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
            if(ddlCMLine.SelectedValue == "703")
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
    }
}