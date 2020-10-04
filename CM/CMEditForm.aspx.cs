using ClaimProject.Config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimProject.CM
{
    public partial class CMEditForm : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public string cm_id = "";
        public string alert = "";
        public string alertType = "";
        public string icon = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/");
            }

            if (txtETime.Text == "")
            {
                txtETime.Text = DateTime.Now.ToString("HH.mm");
            }

            if (Session["UserCpoint"].ToString() == "703" || Session["UserCpoint"].ToString() == "704" || Session["UserCpoint"].ToString() == "706" || Session["UserCpoint"].ToString() == "707" 
                || Session["UserCpoint"].ToString() == "708" || Session["UserCpoint"].ToString() == "709")
            {
                ddlAnnex.Visible = true;
            }

            if (!this.IsPostBack)
            {
                //function.getListItem(ddlCMBudget, "SELECT cm_budget FROM tbl_cm_detail  GROUP BY cm_budget ORDER by cm_budget DESC", "cm_budget", "cm_budget");
                function.getListItem(ddlAnnex, "SELECT cm_point FROM tbl_cm_detail  GROUP BY cm_point ORDER by cm_point ASC", "cm_point", "cm_point");
                

                string sql = "";
                if (function.CheckLevel("Department", Session["UserPrivilegeId"].ToString()))
                {
                    sql = "SELECT * FROM tbl_cpoint ORDER BY cpoint_id";
                    function.getListItem(txtCpointSearch, sql, "cpoint_name", "cpoint_id");
                    txtCpointSearch.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                }
                else
                {
                    sql = "SELECT * FROM tbl_cpoint WHERE cpoint_id = '" + Session["UserCpoint"].ToString() + "'";
                    function.getListItem(txtCpointSearch, sql, "cpoint_name", "cpoint_id");
                    //txtCpointSearch.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                }
                BindData();
            }

        }


        void BindData()
        {
            string sql = "";
            string checkCpoint = txtCpointSearch.SelectedValue;
            string checkPoint = ddlAnnex.SelectedValue;
            if (checkCpoint == "")
            {
                if(checkPoint == "")
                {
                    sql += "SELECT * FROM tbl_cm_detail cm " +
                    " JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                    " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                    " JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id" +
                    " JOIN tbl_user u ON cm.cm_user = u.username " + 
                    " WHERE cm.cm_detail_status_id='0' " +
                    " ORDER BY cm_cpoint,cm_point,cm_detail_channel,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y'), cm.cm_detail_stime, cm_detail_status_id ASC";
                }
                else
                {
                    sql += "SELECT * FROM tbl_cm_detail cm " +
                   " JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                   " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                   " JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id" +
                   " JOIN tbl_user u ON cm.cm_user = u.username " +
                   " WHERE cm.cm_cpoint = '" + checkCpoint + "' " +
                   " AND cm.cm_detail_status_id='0' AND cm.cm_point = '" + ddlAnnex.SelectedValue + "' " +
                   " ORDER BY cm_cpoint,cm_point,cm_detail_channel,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y'), cm.cm_detail_stime, cm_detail_status_id ASC";
                }
                
            }
            else
            {
                sql += "SELECT * FROM tbl_cm_detail cm " +
                   " JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                   " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                   " JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id" +
                   " JOIN tbl_user u ON cm.cm_user = u.username " +
                   " WHERE cm.cm_cpoint = '" +checkCpoint+"' " +
                   " AND cm.cm_detail_status_id='0' AND cm.cm_point = '" + ddlAnnex.SelectedValue + "' " +
                   " ORDER BY cm_cpoint,cm_point,cm_detail_channel,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y'), cm.cm_detail_stime, cm_detail_status_id ASC";
            }
                
                MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds);
                CMGridView.DataSource = ds.Tables[0];
                CMGridView.DataBind();
               // if (ds.Tables[0].Rows.Count == 0) { DivCMGridView.Visible = false; } else { DivCMGridView.Visible = true; }
                //lbCMNull.Text = "พบข้อมูลจำนวน " + ds.Tables[0].Rows.Count + " แถว";
            
        }

        protected void CMGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbSDate = (Label)(e.Row.FindControl("lbSDate"));
            if (lbSDate != null)
            {
                lbSDate.Text = function.ConvertDateShortThai((string)DataBinder.Eval(e.Row.DataItem, "cm_detail_sdate"));
            }

            Label lbStatus = (Label)(e.Row.FindControl("lbStatus"));
            if (lbStatus != null)
            {
                lbStatus.Text = function.GetStatusCM(DataBinder.Eval(e.Row.DataItem, "cm_detail_status_id").ToString());
            }

            Label btnDateEditCM = (Label)(e.Row.FindControl("btnDateEditCM"));
            if (btnDateEditCM != null)
            {
                if (!DataBinder.Eval(e.Row.DataItem, "cm_detail_edate").Equals(DBNull.Value))
                {
                    btnDateEditCM.Text = function.ConvertDateShortThai((string)DataBinder.Eval(e.Row.DataItem, "cm_detail_edate"));
                }
            }

            Label btnTimeEditCM = (Label)(e.Row.FindControl("btnTimeEditCM"));
            if (btnTimeEditCM != null)
            {
                if (!DataBinder.Eval(e.Row.DataItem, "cm_detail_etime").Equals(DBNull.Value))
                {
                    btnTimeEditCM.Text = (string)DataBinder.Eval(e.Row.DataItem, "cm_detail_etime");
                    if (btnTimeEditCM.Text != "") { btnTimeEditCM.Text += " น."; }
                }
            }

            LinkButton btnStatusUpdate = (LinkButton)(e.Row.FindControl("btnStatusUpdate"));
            if (btnStatusUpdate != null)
            {
                btnStatusUpdate.CommandName = (string)DataBinder.Eval(e.Row.DataItem, "cm_detail_id").ToString();
                if (DataBinder.Eval(e.Row.DataItem, "cm_detail_status_id").ToString() == "1")
                {
                    btnStatusUpdate.Text = "&#xf044;";
                    btnStatusUpdate.CssClass = "fas text-warning";
                    btnStatusUpdate.ToolTip = "แก้ไข";
                }
            }
        }

        protected void btnStatusUpdate_Command(object sender, CommandEventArgs e)
        {
            cm_id = e.CommandName;
            Label1.Text = "#" + cm_id;
            lbcmid.Text = cm_id;
            string sql = "SELECT * FROM tbl_cm_detail cm JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id JOIN tbl_cpoint c ON c.cpoint_id=cm.cm_cpoint JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id WHERE cm.cm_detail_id = '" + cm_id + "'";
            MySqlDataReader rs = function.MySqlSelect(sql);
            if (rs.Read())
            {
                Label5.Text = rs.GetString("cpoint_name") + " " + rs.GetString("cm_point");
                Label2.Text = rs.GetString("locate_name");
                Label3.Text = rs.GetString("device_name");
                Label4.Text = rs.GetString("cm_detail_problem");
                if (!rs.IsDBNull(8)) { txtEDate.Text = rs.GetString("cm_detail_edate"); } else { txtEDate.Text = ""; }
                if (!rs.IsDBNull(9)) { txtETime.Text = rs.GetString("cm_detail_etime"); } else { txtETime.Text = DateTime.Now.ToString("HH.mm"); }
                if (!rs.IsDBNull(11)) { txtMethod.Text = rs.GetString("cm_detail_method"); } else { txtMethod.Text = ""; }
                if (!rs.IsDBNull(12)) { txtNote.Text = rs.GetString("cm_detail_note"); } else { txtNote.Text = ""; }
            }
            rs.Close();
            function.Close();
        }

        protected void btnUpdateCM_Command(object sender, CommandEventArgs e)
        {
            if (txtEDate.Text != "" && txtETime.Text != "")
            {
                bool chk_time = false;
                try
                {
                    double.Parse(txtETime.Text);
                    chk_time = true;
                }
                catch { ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('กรุณาใส่เวลาให้ถูกต้อง ไม่ต้องใส่ น.')", true); }

                if (chk_time)
                {
                    String NewFileDocName = "";
                    if (txtMethod.Text != "")
                    {
                        if (fileImg.HasFile)
                        {
                            string typeFile = fileImg.FileName.Split('.')[fileImg.FileName.Split('.').Length - 1];
                            if (typeFile == "jpg" || typeFile == "jpeg" || typeFile == "png")
                            {
                                NewFileDocName = "E_" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + fileImg.FileName.Split('.')[0];
                                NewFileDocName = "/CM/Upload/" + function.getMd5Hash(NewFileDocName) + "." + typeFile;
                                fileImg.SaveAs(Server.MapPath(NewFileDocName.ToString()));
                                string sql = "UPDATE tbl_cm_detail SET cm_detail_edate = '" + txtEDate.Text + "', cm_detail_etime = '" + txtETime.Text.Trim() + "', cm_detail_note = '" + txtNote.Text.Trim() + "', cm_detail_status_id = '1',cm_detail_eimg='" + NewFileDocName + "',cm_detail_method='" + txtMethod.Text + "' WHERE cm_detail_id = '" + Label1.Text.Replace('#', ' ').Trim() + "'";
                                if (function.MySqlQuery(sql))
                                {
                                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('บันทึกข้อมูลสำเร็จ')", true);
                                    BindData();
                                }
                                else
                                {
                                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('ล้มเหลวเกิดข้อผิดพลาด')", true);
                                }
                            }
                            else
                            {
                                //AlertPop("Error : แนบรูปภาพล้มเหลว ไฟล์เอกสารต้องเป็น *.jpg *.jpge *.png เท่านั้น", "error");
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Error : แนบรูปภาพล้มเหลว ไฟล์เอกสารต้องเป็น *.jpg *.jpge *.png เท่านั้น')", true);
                            }
                        }
                        else
                        {
                            //UpdateCM("");
                            //AlertPop("Error : แนบรูปภาพล้มเหลวไม่พบไฟล์", "error");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Error : แนบรูปภาพล้มเหลวไม่พบไฟล์')", true);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('**กรุณาใส่วิธีแก้ไข')", true);
                    }
                }
            }
        }

        protected void btnSearchEdit_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnDeleteCM_Command(object sender, CommandEventArgs e)
        {
            string dateNow = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            string sqlDelete = "UPDATE tbl_cm_detail SET cm_detail_status_id='9', cm_delete_time='" + dateNow + "', cm_delete_user ='" + Session["User"].ToString() + "' " +
                " WHERE cm_detail_id='" + lbcmid.Text + "' ";

            if (function.MySqlQuery(sqlDelete))
            {
                AlertPop("ลบรายการแจ้งซ่อมเรียบร้อย", "warning");
            }
            else
            {
                AlertPop("ลบรายการแจ้งซ่อมล้มเหลว!! กรุณาติดต่อเจ้าหน้าที่ ", "error");
            }
            BindData();
        }

        public void AlertPop(string msg, string type)
        {
            switch (type)
            {
                case "success":
                    icon = "add_alert";
                    alertType = "success";
                    break;
                case "error":
                    icon = "error";
                    alertType = "danger";
                    break;
                case "warning":
                    icon = "warning";
                    alertType = "warning";
                    break;
            }
            //alertType = type;
            alert = msg;
        }

    }
}