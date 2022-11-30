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

namespace ClaimProject.CM
{
    public partial class CMEditForm : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public string cm_id = "";
        public string alert = "";
        public string alertType = "";
        public string icon = "";
        public string token = "";
        public string messageLine = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/");
            }

            //if (txtETime.Text == "")
            //{
            //    txtETime.Text = DateTime.Now.ToString("HH.mm");
            //}

            if (Session["UserCpoint"].ToString() == "0")
            {
                txtAnnex.Enabled = true;
            }

            if (Session["user_cpoint"].ToString() == "1")
            {
                btnDeleteCM.Visible = false;
            }

            if (!this.IsPostBack)
            {
                function.getListItem(ddlChanel, "SELECT * FROM tbl_location WHERE locate_group = '1' Order By locate_id ASC", "locate_name", "locate_id");
                ddlChanel.Items.Insert(0, new ListItem("ทุกช่องทาง", ""));
                //function.getListItem(ddlCMBudget, "SELECT cm_budget FROM tbl_cm_detail  GROUP BY cm_budget ORDER by cm_budget DESC", "cm_budget", "cm_budget");
                //function.getListItem(ddlAnnex, "SELECT cm_point FROM tbl_cm_detail  GROUP BY cm_point ORDER by cm_point ASC", "cm_point", "cm_point");
                txtAnnex.Text = Session["Userpoint"].ToString();

                string sql = "";
                if (function.CheckLevel("Department", Session["UserPrivilegeId"].ToString()))
                {
                    sql = "SELECT * FROM tbl_cpoint ORDER BY cpoint_id";
                    function.getListItem(txtCpointSearch, sql, "cpoint_name", "cpoint_id");
                    txtCpointSearch.Items.Insert(0, new ListItem("ทุกด่านฯ", ""));
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
            string checkPoint = Session["Userpoint"].ToString();
            string checkChanel = ddlChanel.SelectedValue;
            if (checkChanel == "")
            {
                if (checkCpoint == "")
                {
                    if (checkPoint == "")
                    {
                        sql += "SELECT * FROM tbl_cm_detail cm " +
                        " JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                        " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                        " JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id" +
                        " JOIN tbl_user u ON cm.cm_user = u.username " +
                        " WHERE cm.cm_detail_status_id='0' " +
                        " ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y'), cm.cm_detail_stime, cm_detail_status_id ASC";
                    }
                    else
                    {
                        sql += "SELECT * FROM tbl_cm_detail cm " +
                       " JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                       " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                       " JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id" +
                       " JOIN tbl_user u ON cm.cm_user = u.username " +
                       " WHERE cm.cm_cpoint = '" + checkCpoint + "' " +
                       " AND cm.cm_detail_status_id='0' AND cm.cm_point = '" + checkPoint + "' " +
                       " ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y'), cm.cm_detail_stime, cm_detail_status_id ASC";
                    }

                }
                else
                {
                    sql += "SELECT * FROM tbl_cm_detail cm " +
                       " JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                       " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                       " JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id" +
                       " JOIN tbl_user u ON cm.cm_user = u.username " +
                       " WHERE cm.cm_cpoint = '" + checkCpoint + "' " +
                       " AND cm.cm_detail_status_id='0' " +
                       " ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y'), cm.cm_detail_stime, cm_detail_status_id ASC";
                }
            }
            else
            {
                if (checkCpoint == "")
                {
                    if (checkPoint == "")
                    {
                        sql += "SELECT * FROM tbl_cm_detail cm " +
                        " JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                        " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                        " JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id" +
                        " JOIN tbl_user u ON cm.cm_user = u.username " +
                        " WHERE cm.cm_detail_status_id='0' AND cm.cm_detail_channel = '" + checkChanel + "' " +
                        " ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y'), cm.cm_detail_stime, cm_detail_status_id ASC";
                    }
                    else
                    {
                        sql += "SELECT * FROM tbl_cm_detail cm " +
                       " JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                       " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                       " JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id" +
                       " JOIN tbl_user u ON cm.cm_user = u.username " +
                       " WHERE cm.cm_cpoint = '" + checkCpoint + "' " +
                       " AND cm.cm_detail_status_id='0' AND cm.cm_point = '" + checkPoint + "' AND cm.cm_detail_channel = '" + checkChanel + "' " +
                       " ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y'), cm.cm_detail_stime, cm_detail_status_id ASC";
                    }

                }
                else
                {
                    sql += "SELECT * FROM tbl_cm_detail cm " +
                       " JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                       " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                       " JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id" +
                       " JOIN tbl_user u ON cm.cm_user = u.username " +
                       " WHERE cm.cm_cpoint = '" + checkCpoint + "' " +
                       " AND cm.cm_detail_status_id='0' AND cm.cm_detail_channel = '" + checkChanel + "' " +
                       " ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y'), cm.cm_detail_stime, cm_detail_status_id ASC";
                }
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
                //lbSDate.Text = function.ConvertDateShortThai((string)DataBinder.Eval(e.Row.DataItem, "cm_detail_sdate"));
                lbSDate.Text = (string)DataBinder.Eval(e.Row.DataItem, "cm_detail_sdate");
                lbSDate.Text += " "+DataBinder.Eval(e.Row.DataItem, "cm_detail_stime");
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
                    if (btnTimeEditCM.Text != "") { btnTimeEditCM.Text += "-"; }
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
            clearCss(); // Clear CSSClass
            cm_id = e.CommandName;
            Label1.Text = "#" + cm_id;
            lbcmid.Text = cm_id;
            string sql = "SELECT * FROM tbl_cm_detail cm JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id JOIN tbl_cpoint c ON c.cpoint_id=cm.cm_cpoint JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id WHERE cm.cm_detail_id = '" + cm_id + "'";
            MySqlDataReader rs = function.MySqlSelect(sql);
            if (rs.Read())
            {
                lbsDate.Text = rs.GetString("cm_detail_sdate");
                lbsTime.Text = rs.GetString("cm_detail_stime");
                Label5.Text = rs.GetString("cpoint_name") + " " + rs.GetString("cm_point");
                Label2.Text = rs.GetString("locate_name");
                Label3.Text = rs.GetString("device_name");
                Label4.Text = rs.GetString("cm_detail_problem");
                string img = rs.GetString("cm_detail_simg");
                ImgCM.ImageUrl = "~" + img;
                if (!rs.IsDBNull(8)) { txtEDate.Text = rs.GetString("cm_detail_edate"); } else { txtEDate.Text = ""; }
                if (!rs.IsDBNull(9)) { txtETime.Text = rs.GetString("cm_detail_etime"); } else { txtETime.Text = DateTime.Now.ToString("HH:mm"); }
                if (!rs.IsDBNull(11)) { txtMethod.Text = rs.GetString("cm_detail_method"); } else { txtMethod.Text = ""; }
                if (!rs.IsDBNull(12)) { txtNote.Text = rs.GetString("cm_detail_note"); } else { txtNote.Text = ""; }
                if (!rs.IsDBNull(19)) { txtEJDate.Text = rs.GetString("cm_detail_ejdate"); } else { txtEJDate.Text = ""; }
                if (!rs.IsDBNull(20)) { txtEJTime.Text = rs.GetString("cm_detail_ejtime"); } else { txtEJTime.Text = DateTime.Now.ToString("HH:mm"); }
            }
            rs.Close();
            function.Close();
        }

        protected void btnUpdateCM_Command(object sender, CommandEventArgs e)
        {
            string sysname = "";

            checkValid();

            if (txtEDate.Text != "" && txtETime.Text != "" && txtEJTime.Text != "" && txtEJDate.Text != "")
            {
                bool chk_time = false;
                try
                {
                    //double.Parse(txtEJTime.Text);
                    //double.Parse(txtETime.Text);
                    chk_time = true;
                }
                catch { }


                if (chk_time)
                {
                    String NewFileDocName = "";
                    String NewFileDocNameService = "";
                    string sqlDocService = "";
                    string Noservice = "";
                    string replace = "";
                    if (txtMethod.Text != "")
                    {
                        if (fileImg.HasFile || fileDocService.HasFile)
                        {
                            string typeFile = fileImg.FileName.Split('.')[fileImg.FileName.Split('.').Length - 1];
                            string typeFileDoc = fileDocService.FileName.Split('.')[fileDocService.FileName.Split('.').Length - 1];
                            if (typeFile == "jpg" || typeFile == "jpeg" || typeFile == "png" || typeFileDoc == "jpg" || typeFileDoc == "jpeg" || typeFileDoc == "png")
                            {
                                NewFileDocName = "E_" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + fileImg.FileName.Split('.')[0];
                                NewFileDocName = "/CM/Upload/" + function.getMd5Hash(NewFileDocName) + "." + typeFile;
                                fileImg.SaveAs(Server.MapPath(NewFileDocName.ToString()));
                                NewFileDocNameService = "E_" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + fileDocService.FileName.Split('.')[0];
                                NewFileDocNameService = "/CM/Upload/" + function.getMd5Hash(NewFileDocNameService) + "." + typeFile;
                                fileDocService.SaveAs(Server.MapPath(NewFileDocNameService.ToString()));

                                if (ckeNoservice.Checked)
                                {
                                    Noservice = "1";
                                    sqlDocService = " ";
                                }
                                else
                                {
                                    Noservice = "0";
                                    sqlDocService = " ,cm_detail_Service_img = '" + NewFileDocNameService + "' ";
                                }

                                if (Chkreplace.Checked)
                                {
                                    replace = " ,cm_detail_replace_name = '" + txtreplaceName.Text + "' ,cm_detail_original_serial = '" + txtoriginalNo.Text + "' ,cm_detail_replace_serial = '" + txtreplaceNo.Text + "' ";
                                }

                                string chkagncy = " SELECT cm_detail_id,drive_group_id,drive_group_agency FROM " +
                                    "tbl_cm_detail JOIN tbl_device ON tbl_cm_detail.cm_detail_driver_id = tbl_device.device_id " +
                                    "JOIN tbl_drive_group ON tbl_drive_group.drive_group_id = tbl_device.davice_group " +
                                    "WHERE cm_detail_id = '" + Label1.Text.Replace('#', ' ').Trim() + "' ";

                                string sql = "UPDATE tbl_cm_detail SET cm_detail_edate = '" + txtEDate.Text + "', " +
                                    "cm_detail_etime = '" + txtETime.Text.Trim() + "', cm_detail_note = '" + txtNote.Text.Trim() + "', " +
                                    "cm_detail_status_id = '1',cm_detail_eimg = '" + NewFileDocName + "',cm_detail_method = '" + txtMethod.Text + "', " +
                                    "cm_detail_ejdate = '" + txtEJDate.Text.Trim() + "' , cm_detail_ejtime = '" + txtEJTime.Text.Trim() + "' , cm_user_endjob = '" + Session["UserName"].ToString() + "' " + sqlDocService + " ," +
                                    "cm_detail_Chknoservice = '" + Noservice + "' " + replace + " " +
                                    "WHERE cm_detail_id = '" + Label1.Text.Replace('#', ' ').Trim() + "'";

                                if (txtCpointSearch.SelectedValue == "902" || txtCpointSearch.SelectedValue == "903" || txtCpointSearch.SelectedValue == "904" || txtCpointSearch.SelectedValue == "905")
                                {
                                    sysname = "MAM9";
                                    //sysname = "test";
                                }
                                else if (txtCpointSearch.SelectedValue == "701" || txtCpointSearch.SelectedValue == "702" || txtCpointSearch.SelectedValue == "703" || txtCpointSearch.SelectedValue == "704")
                                {
                                    sysname = "MAM71";
                                    //sysname = "test";
                                }
                                else if (txtCpointSearch.SelectedValue == "706" || txtCpointSearch.SelectedValue == "707" || txtCpointSearch.SelectedValue == "708" || txtCpointSearch.SelectedValue == "709" || txtCpointSearch.SelectedValue == "710")
                                {
                                    sysname = "MAM72";
                                    //sysname = "test";
                                }
                                else
                                {
                                    sysname = "MAM73";
                                    //sysname = "test";
                                }

                                if (function.MySqlQuery(sql))
                                {
                                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('บันทึกข้อมูลสำเร็จ')", true);
                                    MySqlDataReader rs = function.MySqlSelect(chkagncy);
                                    if (rs.Read())
                                    {
                                        if (rs.GetString("drive_group_id") == "4")
                                        {
                                            sysname = "CMAir";
                                            //sysname = "test";
                                        }

                                        if (txtCpointSearch.SelectedValue != "711" && txtCpointSearch.SelectedValue != "712" && txtCpointSearch.SelectedValue != "713")
                                        {
                                            if (rs.GetString("drive_group_id") == "2") // ซ่อมบำรุง
                                            {
                                                messageLine = Label1.Text + "\nแจ้งใช้งานได้ปกติ : ด่านฯ " + Label5.Text + " (" + Label2.Text + ") \nวันที่แจ้ง : " + lbsDate.Text + " @" + lbsTime.Text + " \nอุปกรณ์ : " + Label3.Text + "\nตรวจสอบพบ : " + Label4.Text + "\nแก้ไข : " + txtMethod.Text + " ";
                                                //function.LineTran(sysname, messageLine);
                                            }
                                            else
                                            {
                                                messageLine = Label1.Text + "\nแจ้งใช้งานได้ปกติ : ด่านฯ " + Label5.Text + " (" + Label2.Text + ") \nวันที่แจ้ง : " + lbsDate.Text + " @" + lbsTime.Text + " \nอุปกรณ์ : " + Label3.Text + "\nตรวจสอบพบ : " + Label4.Text + "\nแก้ไข : " + txtMethod.Text + " ";
                                                function.LineTran(sysname, messageLine);
                                            }
                                        }
                                        else
                                        {
                                            messageLine = Label1.Text + "\nแจ้งใช้งานได้ปกติ : ด่านฯ " + Label5.Text + " (" + Label2.Text + ") \nวันที่แจ้ง : " + lbsDate.Text + " @" + lbsTime.Text + " \nอุปกรณ์ : " + Label3.Text + "\nตรวจสอบพบ : " + Label4.Text + "\nแก้ไข : " + txtMethod.Text + " ";
                                            function.LineTran(sysname, messageLine);
                                        }
                                    }
                                    BindData();
                                }
                                else
                                {
                                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('ล้มเหลวเกิดข้อผิดพลาด กรุณาตรวจสอบขนาดไฟล์ รูปภาพอีกครั้ง')", true);
                                    cm_id = Label1.Text.Replace('#', ' ').Trim();
                                }
                                //function.Close();
                            }
                            else
                            {
                                //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Error : แนบรูปภาพล้มเหลว ไฟล์เอกสารต้องเป็น *.jpg *.jpge *.png เท่านั้น')", true);
                                cm_id = Label1.Text.Replace('#', ' ').Trim();
                            }
                        }
                        else
                        {
                            //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Error : แนบรูปภาพล้มเหลวไม่พบไฟล์')", true);
                            cm_id = Label1.Text.Replace('#', ' ').Trim();
                        }
                        txtMethod.CssClass = "form-control is-valid";
                    }
                    else
                    {
                        //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('กรุณากรอกวิธีแก้ไข')", true);
                        cm_id = Label1.Text.Replace('#', ' ').Trim();
                        txtMethod.CssClass = "form-control is-invalid";
                    }                    
                }
            }
            else
            {
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('กรุณากรอกเวลาเข้าซ่อม / ซ่อมเสร็จ ')", true);
                cm_id = Label1.Text.Replace('#', ' ').Trim();

                //if(txtETime.Text == "")
                //{
                //    txtETime.CssClass = "form-control is-invalid";
                //}
                //else
                //{
                //    txtETime.CssClass = "form-control is-valid";
                //}

                //if (txtEJTime.Text == "")
                //{
                //    txtEJTime.CssClass = "form-control is-invalid";
                //}
                //else
                //{
                //    txtEJTime.CssClass = "form-control is-valid";
                //}
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
                function.AlertPop("ลบรายการแจ้งซ่อมเรียบร้อย", "warning");
            }
            else
            {
                function.AlertPop("ลบรายการแจ้งซ่อมล้มเหลว!! กรุณาติดต่อเจ้าหน้าที่ ", "error");
            }
            function.Close();
            BindData();
        }       

        protected void ckeNoservice_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void clearCss()
        {
            //txtETime.CssClass = "form-control";
            //txtEJTime.CssClass = "form-control";
            txtMethod.CssClass = "form-control";
        }

        public void checkValid()
        {
            if(txtreplaceName.Text == "")
            {
                txtreplaceName.CssClass = "form-control is-invalid";
            }
            else
            {
                txtreplaceName.CssClass = "form-control is-valid";
            }
        }
    }
}