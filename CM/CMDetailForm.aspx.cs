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
        public string alerts = "";
        public string alertTypes = "";
        public string icons = "";
        ClaimFunction function = new ClaimFunction();
        public string EditModal = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/");
            }

            if (!this.IsPostBack)
            {    
                string date = DateTime.Now.ToString("dd-MM") + "-" + (DateTime.Now.Year + 543);
                function.getListItem(ddlChanel, "SELECT * FROM tbl_location WHERE locate_group != '3' Order By locate_id ASC", "locate_name", "locate_id");
                BindData();
                //function.getListItem(ddlBudgetcc, "SELECT cm_budget FROM tbl_cm_detail  GROUP BY cm_budget ORDER by cm_budget DESC", "cm_budget", "cm_budget");
                string sql = "";
                if (function.CheckLevel("Department", Session["UserPrivilegeId"].ToString()))
                {
                    sql = "SELECT * FROM tbl_cpoint ORDER BY cpoint_id";
                    
                    function.getListItem(txtCpoint, sql, "cpoint_name", "cpoint_id");
                    function.getListItem(txtCpointSearch, sql, "cpoint_name", "cpoint_id");
                    txtCpointSearch.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                    txtCpoint.Enabled = true;
                    txtPoint.Enabled = true;
                }
                else
                {
                    sql = "SELECT * FROM tbl_cpoint WHERE cpoint_id = '" + Session["UserCpoint"].ToString() + "'";
                    function.getListItem(txtCpoint, sql, "cpoint_name", "cpoint_id");
                    function.getListItem(txtCpointSearch, sql, "cpoint_name", "cpoint_id");
                    //txtCpointSearch.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                }

                string sql_Device = "SELECT * FROM tbl_device Where davice_delete = '0' ORDER BY device_name";
                function.getListItem(txtDeviceAdd, sql_Device, "device_name", "device_id");
                txtDeviceAdd.Items.Insert(0, new ListItem("", ""));
                txtSTime.Text = DateTime.Now.ToString("HH.mm");
                txtPoint.Text = Session["Userpoint"].ToString();
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
                       // txtChannel.Text = rs.GetString("cm_detail_channel");
                        txtSDate.Text = rs.GetString("cm_detail_sdate");
                        ddlChanel.SelectedValue = rs.GetString("cm_detail_channel");
                        txtSTime.Text = rs.GetString("cm_detail_stime");
                        txtDeviceAdd.SelectedValue = rs.GetString("cm_detail_driver_id");
                        txtProblem.Text = rs.GetString("cm_detail_problem");
                        //txtNote.Text = rs.GetString("cm_detail_note");
                    }
                    rs.Close();
                    function.Close();

                    btnSaveCM.Visible = false;
                    btnEditCM.Visible = true;
                    btnCancelCM.Visible = true;

                    if (function.CheckLevel("Techno", Session["UserPrivilegeId"].ToString()))
                    {
                        btnDeleteCM.Visible = true;
                        //ImgUpload.Visible = true;
                        txtCpoint.Enabled = true;
                        txtPoint.Enabled = true;
                    }
                    else
                    {
                        btnDeleteCM.Visible = false;
                        //ImgUpload.Visible = false;
                    }

                }
                else
                {
                    btnSaveCM.Visible = true;
                    btnEditCM.Visible = false;
                    btnCancelCM.Visible = false;
                    btnDeleteCM.Visible = false;                   
                }
            }



        }
        void BindData()
        {
            string sql = "";
            string checkCpoint = txtCpointSearch.SelectedValue.ToString();
            if (checkCpoint == "")
            {
                sql = "SELECT * FROM tbl_cm_detail cm " +
                    " JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                    " JOIN tbl_location e ON cm.cm_detail_channel = e.locate_id " +
                    " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                    " JOIN tbl_user u ON cm.cm_user = u.username JOIN tbl_drive_group dg ON d.davice_group = dg.drive_group_id " +
                    " WHERE cm.cm_detail_status_id='0' " +
                    " ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y'), cm.cm_detail_stime, cm_detail_status_id ASC";
            }
            else
            {
                sql = "SELECT * FROM tbl_cm_detail cm " +
                   " JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                   " JOIN tbl_location e ON cm.cm_detail_channel = e.locate_id " +
                   " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                   " JOIN tbl_user u ON cm.cm_user = u.username JOIN tbl_drive_group dg ON d.davice_group = dg.drive_group_id " +
                   " WHERE cm.cm_cpoint = '" + checkCpoint + "' AND cm.cm_point = '"+ txtPoint.Text + "' " +
                   " AND cm.cm_detail_status_id='0' " +
                   " ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y'), cm.cm_detail_stime, cm_detail_status_id ASC";
            }

            MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            CMGridView.DataSource = ds.Tables[0];
            CMGridView.DataBind();
            if (ds.Tables[0].Rows.Count == 0) { DivCMGridView.Visible = false; } else { DivCMGridView.Visible = true; }
            function.Close();
        }

        protected string ChkPicInsert ()
        {
            string NewFileDocName = "";
            if(fileImg.HasFile)
            {
                string typeFile = fileImg.FileName.Split('.')[fileImg.FileName.Split('.').Length - 1];
                if(typeFile == "jpg" || typeFile == "jpeg" || typeFile == "png")
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

            if(txtProblem.Text == "")
            {
                //txtProblem.CssClass = "form-control is-invalid ";
                AlertPop("Error : กรุณากรอกปัญหา/อาการ", "error");
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Error : กรุณากรอกปัญหา/อาการ')", true);
            }
            else
            {
                //txtProblem.CssClass = "form-control is-valid";

                if (getChkpic == "picTypeError")
                {
                    AlertPop("Error : แนบรูปภาพล้มเหลว ไฟล์เอกสารต้องเป็น *.jpg *.jpge *.png เท่านั้น", "error");
                   //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Error : แนบรูปภาพล้มเหลว ไฟล์เอกสารต้องเป็น *.jpg *.jpge *.png เท่านั้น')", true);
                }
                else if(getChkpic == "picHasNotImage")
                {
                    AlertPop("Error : ไม่พบรูปภาพ กรุณาตรวจสอบรูปภาพ", "error");
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Error : ไม่พบรูปภาพ กรุณาตรวจสอบรูปภาพอีกครั้ง')", true);
                }
                else if(txtSTime.Text == "")
                {
                    AlertPop("Error : กรุณากรอกเวลาแจ้ง", "error");
                   // ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Error : กรุณากรอกเวลาแจ้ง ')", true);
                }
                else if(txtDeviceAdd.Text == "")
                {
                    AlertPop("Error : กรุณากรอกอุปกรณ์ ", "error");
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Error : กรุณากรอกอุปกรณ์ ')", true);
                }
                else
                {
                    string bgy = function.getBudgetYear(txtSDate.Text);
                    string point = Session["Userpoint"].ToString();
                    string agncy = txtDeviceAdd.SelectedValue.ToString();
                    string chkagncy = "SELECT device_id,drive_group_id,drive_group_agency FROM tbl_device " +
                    "JOIN tbl_drive_group ON tbl_device.davice_group = tbl_drive_group.drive_group_id WHERE device_id = '" + agncy + "' ";
                    

                    string sql_insert = "INSERT INTO tbl_cm_detail (cm_budget,cm_detail_driver_id,cm_detail_problem,cm_detail_status_id,cm_detail_channel,cm_detail_sdate,cm_detail_stime,cm_detail_simg,cm_cpoint,cm_point,cm_user) VALUES ('" + bgy + "','" + txtDeviceAdd.SelectedValue + "','" + txtProblem.Text + "','0','" + ddlChanel.SelectedValue.ToString() + "','" + txtSDate.Text + "','" + txtSTime.Text + "','" + getChkpic + "','" + txtCpoint.SelectedValue + "','" + point + "','" + Session["User"].ToString() + "')";
                    if(function.MySqlQuery(sql_insert))
                    {
                        AlertPop("บันทึกข้อมูลสำเร็จ", "success");
                        MySqlDataReader rs = function.MySqlSelect(chkagncy);
                        if (rs.Read())
                        {
                            if (txtCpoint.SelectedValue != "711" && txtCpoint.SelectedValue != "712" && txtCpoint.SelectedValue != "713")
                            {
                                if (rs.GetString("drive_group_id") == "2" )
                                {
                                    Session["LineTran"] = "\nแจ้งซ่อม : ด่านฯ " + txtCpoint.SelectedItem + " " + txtPoint.Text + "(" + ddlChanel.SelectedItem + ")" + " \nวันที่ : " + txtSDate.Text + " @" + txtSTime.Text + " \nอุปกรณ์ : " + txtDeviceAdd.SelectedItem + " \n ตรวจสอบพบ : " + txtProblem.Text + " ";
                                }
                                else
                                {
                                    Session["LineTran"] = "\nแจ้งซ่อม : ด่านฯ " + txtCpoint.SelectedItem + " " + txtPoint.Text + "(" + ddlChanel.SelectedItem + ") \nวันที่ : " + txtSDate.Text + " @" + txtSTime.Text + " \nอุปกรณ์ : " + txtDeviceAdd.SelectedItem + " \nตรวจสอบพบ : " + txtProblem.Text + " ";
                                    LineTran();
                                }
                            }
                            else
                            {
                                Session["LineTran"] = "\nแจ้งซ่อม : ด่านฯ " + txtCpoint.SelectedItem + " " + txtPoint.Text + "(" + ddlChanel.SelectedItem + ") \nวันที่ : " + txtSDate.Text + " @" + txtSTime.Text + " \nอุปกรณ์ : " + txtDeviceAdd.SelectedItem + " \nตรวจสอบพบ : " + txtProblem.Text + " ";
                                LineTran();
                            }
                                
                        }
                        
                        BindData();
                        ClearDate();
                    }
                    else
                    {
                        AlertPop("ล้มเหลว กรุณาติดต่อผู้ดูแล", "error");
                        //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('ล้มเหลว กรุณาติดต่อผู้ดูแล')", true);
                    }
                    function.Close();
                }

            }

        }

        private void ClearDate()
        {
            txtCpoint.SelectedIndex = 0;
            //txtPoint.Text = "";
            txtDeviceAdd.SelectedIndex = 0;
            txtProblem.Text = "";
            txtProblem.CssClass = "form-control ";
            //txtChannel.Text = "";
            //txtNote.Text = "";
            txtSDate.Text = DateTime.Now.ToString("dd-MM-") + (DateTime.Now.Year + 543);
            txtSTime.Text = DateTime.Now.ToString("HH.mm");
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

            LinkButton btnEditCM = (LinkButton)(e.Row.FindControl("btnEditCM"));
            if (btnEditCM != null)
            {
                btnEditCM.CommandName = DataBinder.Eval(e.Row.DataItem, "cm_detail_id").ToString();
                if(DataBinder.Eval(e.Row.DataItem, "cm_detail_status_id").ToString() != "0")
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
                lbNameFileImg.Text = imgg;
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
                    NewFileDocName = "S_"+DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + fileImg.FileName.Split('.')[0];
                    NewFileDocName = "/CM/Upload/" + function.getMd5Hash(NewFileDocName) + "." + typeFile;
                    fileImg.SaveAs(Server.MapPath(NewFileDocName.ToString()));
                    UpdateCM(NewFileDocName);
                }
                else
                {
                    AlertPop("Error : แนบรูปภาพล้มเหลว ไฟล์เอกสารต้องเป็น *.jpg *.jpge *.png เท่านั้น", "error");
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Error : แนบรูปภาพล้มเหลว ไฟล์เอกสารต้องเป็น *.jpg *.jpge *.png เท่านั้น')", true);
                }
            }
            else
            {
                UpdateCM("");
                //AlertPop("Error : แนบรูปภาพล้มเหลวไม่พบไฟล์", "error");
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Error : แนบรูปภาพล้มเหลวไม่พบไฟล์')", true);
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
                + ddlChanel.SelectedValue.ToString() + "',cm_detail_sdate='" + txtSDate.Text + "',cm_detail_stime='" + txtSTime.Text + "' "+ img +" ,cm_cpoint='" + txtCpoint.SelectedValue 
                + "',cm_point='" + txtPoint.Text + "' WHERE cm_detail_id = '" + txtRef.Value + "'";
            if (function.MySqlQuery(sql_insert))
            {
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('แก้ไขข้อมูลสำเร็จ')", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('แก้ไขข้อมูลสำเร็จ'); window.location='/CM/CMDetailForm';", true);
                BindData();
                //Response.Redirect("/CM/CMDetailForm");
                ClearDate();
            }
            else
            {
                AlertPop("ล้มเหลว เกิดข้อผิดพลาด", "error");
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('ล้มเหลว เกิดข้อผิดพลาด')", true);
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
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('ลบข้อมูลสำเร็จ')", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('ลบข้อมูลสำเร็จ'); window.location='/CM/CMDetailForm';", true);
                BindData();
                ClearDate();
            }
            else
            {
                AlertPop("ล้มเหลว เกิดข้อผิดพลาด", "error");
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('ล้มเหลว เกิดข้อผิดพลาด')", true);
            }
            function.Close();
        }

        protected void btnSearchAddd_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnToReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("/CM/CMLine.aspx");
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

        protected void LineTran()
        {
            string token = "";
            if(txtCpoint.SelectedValue == "902" || txtCpoint.SelectedValue == "903" || txtCpoint.SelectedValue == "904" || txtCpoint.SelectedValue == "905")
            {
                token = "TcwUZJSfjZJf5KPOXd6HEoB6Bx4oXVB6zTAcRzLnf5F";
            }else if(txtCpoint.SelectedValue == "701" || txtCpoint.SelectedValue == "702" || txtCpoint.SelectedValue == "703" || txtCpoint.SelectedValue == "704")
            {
                token = "N30yjwh33RFedbk8csYoXX8iQhiyrNDxqq1tjR8a1GL";
            }else if(txtCpoint.SelectedValue == "706" || txtCpoint.SelectedValue == "707" || txtCpoint.SelectedValue == "708" || txtCpoint.SelectedValue == "709" || txtCpoint.SelectedValue == "710")
            {
                token = "JUv0pwVozllZzQr9gI066f3Vtw0KEMl6QTIUOeiiqtD";
            }
            else
            {
                token = "m36qnn0BYUziwaJutF6mHVZc5cbxQwTFr4dZpP1QWe9";
            }

            if (Session["LineTran"].ToString() != "")
            {
                SreviceLine.WebService_Server serviceLine = new SreviceLine.WebService_Server();
                try
                {
                    serviceLine.MessageToServer(token, Session["LineTran"].ToString(), "", 1, 41);
                    Session["LineTran"] = "";
                }catch(Exception)
                {
                    
                }
                
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
            //alertType = type;
            alerts = msg;
        }
    }
}