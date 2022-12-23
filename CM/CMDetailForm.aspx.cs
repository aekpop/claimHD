using ClaimProject.Config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimProject.CM
{
    public partial class CMDetailForm : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public string alerts = "";
        public string alertTypes = "";
        public string icons = "";       
        public string EditModal = "";
        public string chkdup = "";
        public string token = "";
        public string messageLine = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/");
            }

            if (!this.IsPostBack)
            {
                string date = DateTime.Now.ToString("dd-MM") + "-" + (DateTime.Now.Year + 543);
                string sql = "";

                function.getListItem(ddlChanel, "SELECT * FROM tbl_location WHERE locate_group != '3' Order By locate_id ASC", "locate_name", "locate_id");

                if (function.CheckLevel("Department", Session["UserPrivilegeId"].ToString()))
                {
                    sql = "SELECT * FROM tbl_cpoint ORDER BY cpoint_id";
                    function.getListItem(txtCpoint, sql, "cpoint_name", "cpoint_id");
                    function.getListItem(txtCpointSearch, sql, "cpoint_name", "cpoint_id");
                    txtCpointSearch.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                    
                }
                else
                {
                    sql = "SELECT * FROM tbl_cpoint WHERE cpoint_id = '" + Session["UserCpoint"].ToString() + "'";
                    function.getListItem(txtCpoint, sql, "cpoint_name", "cpoint_id");
                    function.getListItem(txtCpointSearch, sql, "cpoint_name", "cpoint_id");
                    txtPoint.Text = Session["Userpoint"].ToString();
                    divSearch.Visible = false;
                    txtCmpoint.Enabled = false;
                    txtPoint.Enabled = false;
                    //txtCpointSearch.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                }

                string sql_Device = "SELECT * FROM tbl_device Where davice_delete = '0' ORDER BY device_name";
                function.getListItem(txtDeviceAdd, sql_Device, "device_name", "device_id");
                txtDeviceAdd.Items.Insert(0, new ListItem("", ""));
                txtSTime.Text = DateTime.Now.ToString("HH:mm");
                //txtPoint.Text = Session["Userpoint"].ToString();
               
                BindData();

                if (Request["ref"] != null)
                {
                    txtRef.Value = Request["ref"].ToString();
                    sql = "SELECT * FROM tbl_cm_detail WHERE cm_detail_id = '" + txtRef.Value + "'";
                    MySqlDataReader rs = function.MySqlSelect(sql);
                    if (rs.Read())
                    {
                        txtCpoint.SelectedValue = rs.GetString("cm_cpoint");
                        txtPoint.Text = rs.GetString("cm_point");
                        //txtChannel.Text = rs.GetString("cm_detail_channel");
                        txtSDate.Text = rs.GetString("cm_detail_sdate");
                        ddlChanel.SelectedValue = rs.GetString("cm_detail_channel");
                        txtSTime.Text = rs.GetString("cm_detail_stime");
                        txtDeviceAdd.SelectedValue = rs.GetString("cm_detail_driver_id");
                        txtProblem.Text = rs.GetString("cm_detail_problem");
                        //txtNote.Text = rs.GetString("cm_detail_note");
                        lbNameFileImg.ImageUrl = rs.GetString("cm_detail_simg");
                    }
                    rs.Close();
                    function.Close();
                    btnSaveCM.Visible = false;
                    btnEditCM.Visible = true;
                    btnCancelCM.Visible = true;
                    statheader.Text = "แก้ไข";
                    statheader.CssClass = "badge badge-warning";

                    if (function.CheckLevel("Techno", Session["UserPrivilegeId"].ToString()))
                    {
                        btnDeleteCM.Visible = true;
                        txtCpoint.Enabled = true;
                        txtPoint.Enabled = true;
                    }
                    else
                    {
                        btnDeleteCM.Visible = false;
                    }
                }
                else
                {
                    btnSaveCM.Visible = true;
                    btnEditCM.Visible = false;
                    btnCancelCM.Visible = false;
                    btnDeleteCM.Visible = false;
                    statheader.Text = "แจ้งใหม่";
                    statheader.CssClass = "badge badge-danger";
                }
            }
        }
        void BindData()
        {
            string sql = "";
            string checkCpoint = txtCpointSearch.SelectedValue.ToString();

            //if (txtCmpoint.Text != "")
            //{
            //    txtPoint.Text = txtCmpoint.Text;
            //}

            if (checkCpoint == "")
            {
                sql = "SELECT * FROM tbl_cm_detail cm " +
                        " JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                        " JOIN tbl_location e ON cm.cm_detail_channel = e.locate_id " +
                        " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                        " JOIN tbl_user u ON cm.cm_user = u.username JOIN tbl_drive_group dg ON d.davice_group = dg.drive_group_id " +
                        " WHERE cm.cm_detail_status_id='0' " +
                        " ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC, cm.cm_detail_stime DESC";
            }
            else
            {
                sql = "SELECT * FROM tbl_cm_detail cm " +
                   " JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                   " JOIN tbl_location e ON cm.cm_detail_channel = e.locate_id " +
                   " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                   " JOIN tbl_user u ON cm.cm_user = u.username JOIN tbl_drive_group dg ON d.davice_group = dg.drive_group_id " +
                   " WHERE cm.cm_cpoint = '" + checkCpoint + "' AND cm.cm_point = '" + txtPoint.Text + "' " +
                   " AND cm.cm_detail_status_id='0' " +
                   " ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC, cm.cm_detail_stime DESC";
            }

            MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            CMGridView.DataSource = ds.Tables[0];
            CMGridView.DataBind();
            //if (ds.Tables[0].Rows.Count == 0) { DivCMGridView.Visible = false; } else { DivCMGridView.Visible = true; }
            function.Close();
        }

        protected string ChkPicInsert()
        {
            string NewFileDocName = "";
            if (fileImg.HasFile)
            {
                string typeFile = fileImg.FileName.Split('.')[fileImg.FileName.Split('.').Length - 1];
                if (typeFile == "jpg" || typeFile == "jpeg" || typeFile == "png")
                {
                    NewFileDocName = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + fileImg.FileName.Split('.')[0];
                    NewFileDocName = "/CM/Upload/" + function.getMd5Hash(NewFileDocName) + "." + typeFile;
                    fileImg.SaveAs(Server.MapPath(NewFileDocName.ToString()));
                    return NewFileDocName;
                }
                else
                {
                    return "picTypeError";
                }
            }
            else
            {
                return "picHasNotImage";
            }
        }
        protected void btnSaveCM_Click(object sender, EventArgs e)
        {
            string getChkpic = ChkPicInsert();
            string sysname = "";

            //if (getChkpic == "picTypeError")
            //{
            //    AlertPop("Error : แนบรูปภาพล้มเหลว ไฟล์เอกสารต้องเป็น *.jpg *.jpge *.png เท่านั้น", "error");
            //    lbImg.CssClass = "text-danger fa fa-times";
            //}
            //else if (getChkpic == "picHasNotImage")
            //{
            //    AlertPop("Error : ไม่พบรูปภาพ กรุณาตรวจสอบรูปภาพ", "error");
            //    lbImg.CssClass = "text-danger fa fa-times";
            //}
            //else if (txtSTime.Text == "")
            //{
            //    AlertPop("Error : กรุณาระบุเวลาแจ้ง", "error");
            //    txtSTime.CssClass = "form-control is-invalid";
            //}
            //else if (txtDeviceAdd.Text == "")
            //{
            //    AlertPop("Error : กรุณาเลือกอุปกรณ์ ", "error");
            //}
            //else if (txtProblem.Text == "")
            //{
            //    AlertPop("Error : กรุณาบันทึกปัญหา/อาการ", "error");
            //    txtProblem.CssClass = "form-control is-invalid ";
            //}
            if (txtSTime.Text == "" || txtDeviceAdd.Text == "" || txtProblem.Text == "" || getChkpic == "picTypeError" || getChkpic == "picHasNotImage")
            {
                AlertPop("Error : กรุณาตรวจสอบข้อมูล", "error");

                if(txtSTime.Text == "")
                {
                    txtSTime.CssClass = "form-control is-invalid";
                }
                else
                {
                    txtSTime.CssClass = "form-control is-valid";
                }

                if (txtProblem.Text == "")
                {
                    txtProblem.CssClass = "form-control is-invalid";
                }
                else
                {
                    txtProblem.CssClass = "form-control is-valid";
                }

                if (txtDeviceAdd.Text == "")
                {
                    txtDeviceAdd.CssClass = "custom-combobox-input is-invalid form-control";
                }
                else
                {
                    txtDeviceAdd.CssClass = "custom-combobox-input is-valid form-control";
                }

                if (getChkpic == "picTypeError")
                {
                    lbImg.CssClass = "text-danger fa fa-times";
                }
                else if (getChkpic == "picHasNotImage")
                {
                    lbImg.CssClass = "text-danger fa fa-times";
                }
            }
            else
            {
                string bgy = function.getBudgetYear(txtSDate.Text);
                string point = Session["Userpoint"].ToString();
                string agncy = txtDeviceAdd.SelectedValue.ToString();
                string chkagncy = "SELECT device_id,drive_group_id,drive_group_agency FROM tbl_device " +
                "JOIN tbl_drive_group ON tbl_device.davice_group = tbl_drive_group.drive_group_id WHERE device_id = '" + agncy + "' ";
                string id = "";
                string sql_insert = "INSERT INTO tbl_cm_detail (cm_budget,cm_detail_driver_id,cm_detail_problem,cm_detail_status_id,cm_detail_channel,cm_detail_sdate,cm_detail_stime,cm_detail_simg,cm_cpoint,cm_point,cm_user) VALUES ('" + bgy + "','" + txtDeviceAdd.SelectedValue + "','" + txtProblem.Text + "','0','" + ddlChanel.SelectedValue.ToString() + "','" + txtSDate.Text + "','" + txtSTime.Text + "','" + getChkpic + "','" + txtCpoint.SelectedValue + "','" + point + "','" + Session["User"].ToString() + "')";
                /* เช็คทำรายการซ้ำ */
                Checkduplcate(txtDeviceAdd.SelectedValue, ddlChanel.SelectedValue.ToString(), txtSDate.Text, txtSTime.Text);

                if (chkdup == "1")
                {
                    AlertPop("ล้มเหลว มีแจ้งในระบบแล้ว", "error");
                    chkdup = "";
                }
                else
                {
                    if (function.MySqlQuery(sql_insert))
                    {
                        cssNornal();
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('บันทึกข้อมูลสำเร็จ')", true);
                        MySqlDataReader rs = function.MySqlSelect(chkagncy);
                        if (rs.Read())
                        {
                            if (rs.GetString("drive_group_id") == "4")
                            {
                                sysname = "CMAir";
                                //sysname = "test";
                            }
                            else
                            {
                                if (txtCpoint.SelectedValue == "902" || txtCpoint.SelectedValue == "903" || txtCpoint.SelectedValue == "904" || txtCpoint.SelectedValue == "905")
                                {
                                    sysname = "MAM9";
                                    //sysname = "test";
                                }
                                else if (txtCpoint.SelectedValue == "701" || txtCpoint.SelectedValue == "702" || txtCpoint.SelectedValue == "703" || txtCpoint.SelectedValue == "704")
                                {
                                    sysname = "MAM71";
                                    //sysname = "test";
                                }
                                else if (txtCpoint.SelectedValue == "706" || txtCpoint.SelectedValue == "707" || txtCpoint.SelectedValue == "708" || txtCpoint.SelectedValue == "709" || txtCpoint.SelectedValue == "710")
                                {
                                    sysname = "MAM72";
                                    //sysname = "test";
                                }
                                else
                                {
                                    sysname = "MAM73";
                                    //sysname = "test";
                                }
                            }
                            string sql_id = "SELECT cm_detail_id FROM tbl_cm_detail WHERE cm_detail_simg = '" + getChkpic + "'";
                            MySqlDataReader rd = function.MySqlSelect(sql_id);
                            if (rd.Read())
                            {
                                id = rd.GetString("cm_detail_id");
                            }

                            if (txtCpoint.SelectedValue != "711" && txtCpoint.SelectedValue != "712" && txtCpoint.SelectedValue != "713")
                            {
                                if (rs.GetString("drive_group_id") == "2")
                                {
                                    messageLine = "#" + id + "\nแจ้งซ่อม : ด่านฯ " + txtCpoint.SelectedItem + " " + txtPoint.Text + "(" + ddlChanel.SelectedItem + ")" + " \nวันที่ : " + txtSDate.Text + " @" + txtSTime.Text + " \nอุปกรณ์ : " + txtDeviceAdd.SelectedItem + " \n ตรวจสอบพบ : " + txtProblem.Text + " ";
                                    AlertPop("บันทึกสำเร็จ", "success");
                                    //function.LineTran(sysname, messageLine);                                       
                                }
                                else
                                {
                                    messageLine = "#" + id + "\nแจ้งซ่อม : ด่านฯ " + txtCpoint.SelectedItem + " " + txtPoint.Text + "(" + ddlChanel.SelectedItem + ") \nวันที่ : " + txtSDate.Text + " @" + txtSTime.Text + " \nอุปกรณ์ : " + txtDeviceAdd.SelectedItem + " \nตรวจสอบพบ : " + txtProblem.Text + " ";
                                    AlertPop("บันทึกสำเร็จ", "success");
                                    function.LineTran(sysname, messageLine);
                                }
                            }
                            else
                            {
                                messageLine = "#" + id + "\nแจ้งซ่อม : ด่านฯ " + txtCpoint.SelectedItem + " " + txtPoint.Text + "(" + ddlChanel.SelectedItem + ") \nวันที่ : " + txtSDate.Text + " @" + txtSTime.Text + " \nอุปกรณ์ : " + txtDeviceAdd.SelectedItem + " \nตรวจสอบพบ : " + txtProblem.Text + " ";
                                AlertPop("บันทึกสำเร็จ", "success");
                                function.LineTran(sysname, messageLine);
                            }
                        }
                        BindData();
                        ClearDate();
                    }
                    else
                    {
                        AlertPop("ล้มเหลว กรุณาติดต่อผู้ดูแล", "error");
                    }
                }
                function.Close();
            }

        }

        private void ClearDate()
        {
            txtCpoint.SelectedIndex = 0;
            txtDeviceAdd.SelectedIndex = 0;
            txtProblem.Text = "";
            txtProblem.CssClass = "form-control ";
            txtSDate.Text = DateTime.Now.ToString("dd-MM-") + (DateTime.Now.Year + 543);
            txtSTime.Text = DateTime.Now.ToString("HH:mm");
        }

        protected void CMGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbSDate = (Label)(e.Row.FindControl("lbSDate"));
            if (lbSDate != null)
            {
                lbSDate.Text = (string)DataBinder.Eval(e.Row.DataItem, "cm_detail_sdate") + " " + DataBinder.Eval(e.Row.DataItem, "cm_detail_stime");
            }

            Label lbStatus = (Label)(e.Row.FindControl("lbStatus"));
            if (lbStatus != null)
            {
                lbStatus.Text = function.GetStatusCM(DataBinder.Eval(e.Row.DataItem, "cm_detail_status_id").ToString());
            }

            LinkButton btnEditCM = (LinkButton)(e.Row.FindControl("btnEditCM"));
            if (btnEditCM != null)
            {
                btnEditCM.CommandName = DataBinder.Eval(e.Row.DataItem, "cm_detail_id").ToString();
                if (DataBinder.Eval(e.Row.DataItem, "cm_detail_status_id").ToString() != "0")
                {
                    btnEditCM.Visible = false;
                }
            }
            Label lbRowNum = (Label)(e.Row.FindControl("lbRowNum"));
            if (lbRowNum != null)
            {
                lbRowNum.Text = (CMGridView.Rows.Count + 1).ToString() + ".";
            }
        }

        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            EditModal = e.CommandName;
            pkeq.Text = EditModal;

            string sqlEdit = "SELECT * FROM tbl_cm_detail  "
                            + " WHERE cm_detail_id ='" + pkeq.Text + "' ";
            MySqlDataReader rttt = function.MySqlSelect(sqlEdit);
            if (rttt.Read())
            {
                string imgg = rttt.GetString("cm_detail_simg");
            }
            rttt.Close();
            function.Close();
            Response.Redirect("/CM/CMDetailForm?ref=" + e.CommandName);
        }

        protected void btnEditCM_Click(object sender, EventArgs e)
        {
            String NewFileDocName = "";
            if (fileImg.HasFile)
            {
                string typeFile = fileImg.FileName.Split('.')[fileImg.FileName.Split('.').Length - 1];
                if (typeFile == "jpg" || typeFile == "jpeg" || typeFile == "png")
                {
                    NewFileDocName = "S_" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + fileImg.FileName.Split('.')[0];
                    NewFileDocName = "/CM/Upload/" + function.getMd5Hash(NewFileDocName) + "." + typeFile;
                    fileImg.SaveAs(Server.MapPath(NewFileDocName.ToString()));
                    UpdateCM(NewFileDocName);
                }
                else
                {
                    AlertPop("Error : แนบรูปภาพล้มเหลว ไฟล์เอกสารต้องเป็น *.jpg *.jpge *.png เท่านั้น", "error");
                }
            }
            else
            {
                UpdateCM("");
            }
        }

        private void UpdateCM(string NewFileDocName)
        {
            string img = "";
            if (NewFileDocName != "")
            {
                img = " ,cm_detail_simg = '" + NewFileDocName + "' ";
            }

            string sql_insert = "UPDATE tbl_cm_detail SET cm_detail_driver_id = '" + txtDeviceAdd.SelectedValue + "',cm_detail_problem='" + txtProblem.Text + "',cm_detail_channel='"
                + ddlChanel.SelectedValue.ToString() + "',cm_detail_sdate='" + txtSDate.Text + "',cm_detail_stime='" + txtSTime.Text + "' " + img + " ,cm_cpoint='" + txtCpoint.SelectedValue
                + "',cm_point='" + txtPoint.Text + "' WHERE cm_detail_id = '" + txtRef.Value + "'";
            if (function.MySqlQuery(sql_insert))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('แก้ไขข้อมูลสำเร็จ'); window.location='/CM/CMDetailForm';", true);
                BindData();
                ClearDate();
            }
            else
            {
                AlertPop("ล้มเหลว เกิดข้อผิดพลาด", "error");
            }
            function.Close();
        }

        protected void btnCancelCM_Click(object sender, EventArgs e)
        {
            Response.Redirect("/CM/CMDetailForm");
        }

        protected void btnDeleteCM_Click(object sender, EventArgs e)
        {
            string dateNow = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            string sql_insert = "UPDATE tbl_cm_detail SET cm_detail_status_id='9', cm_delete_time='" + dateNow + "', cm_delete_user ='" + Session["User"].ToString() + "' " +
                " WHERE cm_detail_id='" + txtRef.Value + "' ";
            if (function.MySqlQuery(sql_insert))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('ลบข้อมูลสำเร็จ'); window.location='/CM/CMDetailForm';", true);
                BindData();
                ClearDate();
            }
            else
            {
                AlertPop("ล้มเหลว เกิดข้อผิดพลาด", "error");
            }
            function.Close();
        }

        protected void btnSearchAddd_Click(object sender, EventArgs e)
        {
            //txtPoint.Text = "";
            BindData();
        }

        protected void btnEditCMM_Command(object sender, CommandEventArgs e)
        {
            EditModal = e.CommandName;
            string pkedit = EditModal;
            string sqlEdit = "SELECT * FROM tbl_cm_detail  "
                            + " WHERE cm_detail_id ='" + pkedit + "' ";
            MySqlDataReader rttt = function.MySqlSelect(sqlEdit);
            if (rttt.Read())
            {
                string imgg = rttt.GetString("cm_detail_simg");
            }
            rttt.Close();
            function.Close();
            Response.Redirect("/CM/CMDetailForm?ref=" + e.CommandName);
        }

        protected void CMGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CMGridView.PageIndex = e.NewPageIndex;
            BindData();
        }

        void Checkduplcate(string id, string channel, string date, string time)
        {
            string sql = "SELECT * FROM tbl_cm_detail WHERE cm_detail_driver_id = '" + id + "' AND cm_detail_channel = '" + channel + "' AND cm_detail_sdate = '" + date + "' AND cm_detail_stime = '" + time + "' ";
            MySqlDataReader rs = function.MySqlSelect(sql);
            if (rs.Read())
            {
                chkdup = "1";
            }
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
            //alertTypes = type;
            alerts = msg;
        }

        public void cssNornal()
        {
            txtSTime.CssClass = "form-control";
            txtProblem.CssClass = "form-control";
            txtDeviceAdd.CssClass = "combobox form-control custom-select ";
            lbImg.CssClass = "text-black-50";
        }
    }
}