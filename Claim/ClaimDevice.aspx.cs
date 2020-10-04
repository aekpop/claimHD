using ClaimProject.Config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimProject.Claim
{
    public partial class ClaimDevice : System.Web.UI.Page
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
                
                function.getListItem(txtSearchStatus, "SELECT * FROM tbl_status ORDER by status_id", "status_name", "status_id");
                txtSearchStatus.Items.Insert(0, new ListItem("ทั้งหมด", "0"));
                string sql = "";
                string sqlCh = "";
                string Userp = Session["UserCpoint"].ToString();

                if (function.CheckLevel("Department", Session["UserPrivilegeId"].ToString()))
                {
                    sql = "SELECT * FROM tbl_cpoint ORDER BY cpoint_id";
                    function.getListItem(txtSearchCpoint, sql, "cpoint_name", "cpoint_id");
                    txtSearchCpoint.Items.Insert(0, new ListItem("ทั้งหมด", ""));

                    
                }
                else
                {
                    if ( Userp == "703" || Userp == "704" || Userp == "706" || Userp == "707" || Userp == "708" || Userp == "709")
                    {
                        txtPoint.Enabled = true;
                    }
                    else
                    {
                        txtPoint.Enabled = false;
                    }
                    sql = "SELECT * FROM tbl_cpoint WHERE cpoint_id = '" + Session["UserCpoint"].ToString() + "'";
                    function.getListItem(txtSearchCpoint, sql, "cpoint_name", "cpoint_id");
                    BindData(txtSearchCpoint.SelectedValue, txtPoint.Text.Trim(), 0 ,"" ,"");
                }

                sqlCh = "SELECT * FROM tbl_location where locate_group = '1' ORDER BY locate_id";
                function.getListItem(txtSearchChannel, sqlCh, "locate_name", "locate_id");
                txtSearchChannel.Items.Insert(0, new ListItem("ทั้งหมด", ""));

                string sql_Device = "SELECT * FROM tbl_device ORDER BY device_name";
                function.getListItem(txtDeviceDamage, sql_Device, "device_name", "device_id");


                txtDeviceDamage.Items.Insert(0, new ListItem("", ""));


            }
        }

        void BindData(string cpoint, string point, int except ,string datestart ,string dateend)
        {
            
            

            string sql = "";
            string conCpoint = "";
            //ค้นหาแบบเลือกวันที่ได้
            string dataS = txtDateStart.Text.Trim();
            string dateE = txtDateEnd.Text.Trim();

            if (cpoint != "")
            {
                if(CheckAllDay.Checked)
                {
                    conCpoint = "AND c.claim_cpoint = '" + cpoint + "' AND c.claim_point Like '%" + point + "%' ";

                    if (except > 0)
                    {
                        if (CheckDeviceNotDamaged.Checked)
                        {
                            conCpoint += "AND c.claim_status <> '" + except + "'";
                        }
                        else
                        {
                            conCpoint += "AND c.claim_status = '" + except + "'";
                        }

                    }
                }
                else
                {
                    conCpoint = "AND c.claim_cpoint = '" + cpoint + "' AND c.claim_point Like '%" + point + "%' AND STR_TO_DATE(c.claim_start_date,'%d-%m-%Y') BETWEEN " +
                    "STR_TO_DATE( '" + dataS + "','%d-%m-%Y') AND STR_TO_DATE('" + dateE + "' ,'%d-%m-%Y')";
                    if (except > 0)
                    {
                        if (CheckDeviceNotDamaged.Checked)
                        {
                            conCpoint += "AND c.claim_status <> '" + except + "'";
                        }
                        else
                        {
                            conCpoint += "AND c.claim_status = '" + except + "'";
                        }

                    }
                }
                
            }
            else
            {
                if(CheckAllDay.Checked)
                {
                    if (txtSearchStatus.SelectedValue == "0")
                    {
                        conCpoint = " ";
                    }
                    else
                    {
                        conCpoint = " AND c.`claim_status` = " + txtSearchStatus.SelectedValue + " ";
                    }
                }
                else
                {
                    if (txtSearchStatus.SelectedValue == "0")
                    {
                        conCpoint = "AND STR_TO_DATE(c.claim_start_date,'%d-%m-%Y') BETWEEN " +
                        "STR_TO_DATE( '" + dataS + "','%d-%m-%Y') AND STR_TO_DATE('" + dateE + "' ,'%d-%m-%Y') ";
                    }
                    else
                    {
                        conCpoint = "AND c.`claim_status` = " + txtSearchStatus.SelectedValue + " AND STR_TO_DATE(c.claim_start_date,'%d-%m-%Y') BETWEEN " +
                        "STR_TO_DATE( '" + dataS + "','%d-%m-%Y') AND STR_TO_DATE('" + dateE + "' ,'%d-%m-%Y') ";
                    }
                }
                
                
            }
            try
            {
                if (txtSearchChannel.SelectedValue == "")
                {
                    if(txtDeviceDamage.SelectedValue == "")
                    {
                        sql = "SELECT * FROM tbl_claim c JOIN `tbl_claim_com` cc ON cc.`claim_id` = c.`claim_id` JOIN tbl_device_damaged dd ON dd.`claim_id` = c.`claim_id` " +
                                "AND dd.`device_damaged_delete` <> 1 JOIN `tbl_device` d ON d.`device_id` = dd.`device_id` JOIN `tbl_status` s ON s.`status_id` = c.`claim_status` " +
                                "JOIN `tbl_cpoint` cp ON c.`claim_cpoint` = cp.`cpoint_id` WHERE c.`claim_status` <> 5 AND c.`claim_status` <> 6 AND c.`claim_delete` <> 1 " + conCpoint + " " +                                
                                "ORDER BY c.claim_cpoint,c.claim_point,STR_TO_DATE(c.claim_start_date,'%d-%m-%Y') ASC";
                    }
                    else
                    {
                        sql = "SELECT * FROM tbl_claim c JOIN `tbl_claim_com` cc ON cc.`claim_id` = c.`claim_id` JOIN tbl_device_damaged dd ON dd.`claim_id` = c.`claim_id` " +
                                "AND dd.`device_damaged_delete` <> 1 JOIN `tbl_device` d ON d.`device_id` = dd.`device_id` JOIN `tbl_status` s ON s.`status_id` = c.`claim_status` " +
                                "JOIN `tbl_cpoint` cp ON c.`claim_cpoint` = cp.`cpoint_id` WHERE c.`claim_status` <> 5 AND c.`claim_status` <> 6 AND c.`claim_delete` <> 1 " + conCpoint + " " +
                                "AND  dd.`device_id` = " + txtDeviceDamage.SelectedValue + "  " +
                                "ORDER BY c.claim_cpoint,c.claim_point,STR_TO_DATE(c.claim_start_date,'%d-%m-%Y') ASC";
                    }
                    
                }
                else
                {
                    if (txtDeviceDamage.SelectedValue == "")
                    {
                        sql = "SELECT * FROM tbl_claim c JOIN `tbl_claim_com` cc ON cc.`claim_id` = c.`claim_id` JOIN tbl_device_damaged dd ON dd.`claim_id` = c.`claim_id` " +
                                "AND dd.`device_damaged_delete` <> 1 JOIN `tbl_device` d ON d.`device_id` = dd.`device_id` JOIN `tbl_status` s ON s.`status_id` = c.`claim_status` " +
                                "JOIN `tbl_cpoint` cp ON c.`claim_cpoint` = cp.`cpoint_id` WHERE c.`claim_status` <> 5 AND c.`claim_status` <> 6 AND c.`claim_delete` <> 1 " + conCpoint + " " +
                                "AND  claim_detail_cb_claim = '" + txtSearchChannel.SelectedItem + "' " +
                                "ORDER BY c.claim_cpoint,c.claim_point,STR_TO_DATE(c.claim_start_date,'%d-%m-%Y') ASC";
                    }
                    else
                    {
                        sql = "SELECT * FROM tbl_claim c JOIN `tbl_claim_com` cc ON cc.`claim_id` = c.`claim_id` JOIN tbl_device_damaged dd ON dd.`claim_id` = c.`claim_id` " +
                                "AND dd.`device_damaged_delete` <> 1 JOIN `tbl_device` d ON d.`device_id` = dd.`device_id` JOIN `tbl_status` s ON s.`status_id` = c.`claim_status` " +
                                "JOIN `tbl_cpoint` cp ON c.`claim_cpoint` = cp.`cpoint_id` WHERE c.`claim_status` <> 5 AND c.`claim_status` <> 6 AND c.`claim_delete` <> 1 " + conCpoint + " " +
                                "AND  claim_detail_cb_claim = '" + txtSearchChannel.SelectedItem + "' AND  dd.`device_id` = " + txtDeviceDamage.SelectedValue + " " +
                                "ORDER BY c.claim_cpoint,c.claim_point,STR_TO_DATE(c.claim_start_date,'%d-%m-%Y') ASC";
                    }
                    
                }
                
                MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds);
                ClaimGridView.DataSource = ds.Tables[0];
                ClaimGridView.DataBind();

                lbClaimNull.Text = "พบข้อมูลจำนวน " + ds.Tables[0].Rows.Count + " แถว";
            }
            catch { }
        }

        protected void ClaimGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbClaimSDate = (Label)(e.Row.FindControl("lbClaimSDate"));
            if (lbClaimSDate != null)
            {
                lbClaimSDate.Text = function.ConvertDateShortThai((string)DataBinder.Eval(e.Row.DataItem, "claim_start_date"));
            }

            Label lbDay = (Label)(e.Row.FindControl("lbDay"));
            if (lbDay != null)
            {
                string[] data = DataBinder.Eval(e.Row.DataItem, "claim_start_date").ToString().Split('-');
                DateTime dateStart = DateTime.ParseExact(data[0] + "-" + data[1] + "-" + (int.Parse(data[2]) - 543), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                DateDifference differnce = new DateDifference(dateStart);

                if (differnce.ToString() == "")
                {
                    lbDay.CssClass = "badge badge-danger";
                    lbDay.Text = "NEW!!";
                }
                else
                {
                    lbDay.Text = differnce.ToString();
                }
            }

            Label lbClaimStatus = (Label)(e.Row.FindControl("lbClaimStatus"));
            if (lbClaimStatus != null)
            {
                lbClaimStatus.CssClass = "badge badge-" + (string)DataBinder.Eval(e.Row.DataItem, "status_alert");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindData(txtSearchCpoint.SelectedValue, txtPoint.Text.Trim(), int.Parse(txtSearchStatus.SelectedValue) , txtDateStart.Text.Trim(), txtDateEnd.Text.Trim());                
            }
            catch { }
        }

        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Claim" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            ClaimGridView.GridLines = GridLines.Both;
            ClaimGridView.HeaderStyle.Font.Bold = true;
            ClaimGridView.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }

        protected void CheckAllDay_CheckedChanged(object sender, EventArgs e)
        {
            if(CheckAllDay.Checked)
            {
                txtDateStart.Enabled = false ;
                txtDateEnd.Enabled = false ;
            }
            else
            {
                txtDateStart.Enabled = true;
                txtDateEnd.Enabled = true;
            }
        }
    }
}