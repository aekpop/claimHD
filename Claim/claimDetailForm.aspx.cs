﻿using ClaimProject.Config;
using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimProject.Claim
{
    public partial class claimDetailForm : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public string alert = "";
        public string alertType = "";
        public string icon = "";
        public string status;
        public string Car2 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["codePK"] == null)
            {
                Response.Redirect("/");
            }
            ShowDiv();
            try
            {
                if (!this.IsPostBack)
                {
                    string sql = "";
                    if (function.CheckLevel("Department", Session["UserPrivilegeId"].ToString()))
                    {
                        sql = "SELECT * FROM tbl_cpoint ORDER BY cpoint_id";
                        btnTechno.Visible = true;
                        if (function.GetSelectValue("tbl_claim", "claim_id = '" + Session["codePK"].ToString() + "'", "claim_status") == "6")
                        {
                            btnTechno.Visible = false;
                        }
                    }
                    else
                    {
                        sql = "SELECT * FROM tbl_cpoint WHERE cpoint_id = '" + Session["UserCpoint"].ToString() + "'";
                        btnTechno.Visible = false;
                    }
                    function.getListItem(txtCpoint, sql, "cpoint_name", "cpoint_id");
                    function.GetList(txtAround, "AroundList");
                    function.GetList(txtPosAleat, "PosList");
                    function.GetList(txtPosSup, "PosList");
                    function.GetList(txtPosCom, "PosList");
                    function.GetList(txtCB, "CabinetList");
                    function.GetList(txtCBClaim, "CabinetList");
                    function.getListItem(txtTypeCar, "Select * FROM tbl_cartype order by typecar_id ASC ", "typcar_name", "typcar_name");
                    txtTypeCar.Items.Insert(0, new ListItem("", ""));
                    // function.GetList(txtTypeCar, "typeCar");
                    function.getListItem(txtBrandCar, "select * FROM tbl_brandcar order by brandcar_id ASC", "brandcar_name", "brandcar_name");
                    //function.GetList(txtBrandCar, "brandCar");
                    txtBrandCar.Items.Insert(0, new ListItem("", ""));
                    function.getListItem(ddlSecTypecar, "Select * FROM tbl_cartype order by typecar_id ASC ", "typcar_name", "typcar_name");
                    ddlSecTypecar.Items.Insert(0, new ListItem("", ""));
                    // function.GetList(ddlSecTypecar, "typeCar");
                    function.GetList(ddlbrandcar2, "brandCar");
                    ddlbrandcar2.Items.Insert(0, new ListItem("", ""));
                    statheader.Text = "แจ้งใหม่";
                    statheader.CssClass = "badge badge-danger";
                    lbControlNum.Text = "เลชควบคุม : XXXX-XXXXX";

                    string sql_Device = "SELECT * FROM tbl_device WHERE davice_delete = '0' ORDER BY device_name";

                    function.getListItem(txtDevice, sql_Device, "device_name", "device_id");
                    txtDevice.Items.Insert(0, new ListItem("", ""));
                    BindCom();
                    BindDevice();
                    BindImg();
                    BindDoc();
                    BindPDF();
                    PageLoadData();
                    /*if(function.GetSelectValue("tbl_claim","claim_id='"+ Session["CodePK"].ToString()+"'", "claim_status") != "1")
                    {
                        cardBody.Attributes.Add("readonly","true");
                    }*/

                    //กำหนดสิทธิ์
                    switch (Session["UserPrivilegeId"].ToString())
                    {
                        case "0":
                            break;
                        case "1"://เทคโน

                            break;
                        case "2"://คอม

                            //btnPrintNoteSup.Visible = true;
                            break;
                        case "3"://รอง

                            //btnPrintNoteSup.Visible = true;
                            break;
                        case "4"://สถิติ

                            //btnPrintNoteSup.Visible = false;
                            break;
                        case "6"://viewer
                            btnSaveReport.Visible = false;
                            //btnPrintNoteSup.Visible = false;
                            break;
                        default:

                            //btnPrintNoteSup.Visible = false;
                            break;
                    }
                }
            }
            catch { AlertPop("network fails กรุณาทำรายการใหม่อีกครั้ง", "error"); }
        }

        protected void btnPrintNote_Click(object sender, EventArgs e)
        {
            //GetReport(0);
        }

        protected void btnAddCom_Click(object sender, EventArgs e)
        {
            if (txtComName.Text != "")
            {
                string sql = "INSERT INTO tbl_claim_com_working (com_working_name,com_working_pos,detail_com_id) VALUES ('" + txtComName.Text + "','" + txtPosCom.SelectedItem + "','" + Session["CodePK"].ToString() + "')";
                function.MySqlQuery(sql);
                txtComName.Text = "";
                BindCom();
            }
        }

        void BindCom()
        {
            string sql = "Select * from tbl_claim_com_working where detail_com_id = '" + Session["CodePK"].ToString() + "'";
            MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            ComGridView.DataSource = ds.Tables[0];
            ComGridView.DataBind();
            LabelCom.Text = "พนักงานควบคุมระบบที่ปฏิบัติหน้าที่ " + ds.Tables[0].Rows.Count + " คน";
        }

        protected void ComGridView_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    ((LinkButton)e.Row.Cells[2].Controls[0]).OnClientClick = "return confirm('ต้องการลบเจ้าหน้าที่คอมที่ปฏิบัติงานใช่หรือไม่');";
                }
                catch { }
            }
        }

        protected void ComGridView_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            string sql = "DELETE FROM tbl_claim_com_working WHERE com_working_id = '" + ComGridView.DataKeys[e.RowIndex].Value + "'";
            //string script = "";
            function.MySqlQuery(sql);
            function.Close();
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('" + script + "')", true);
            ComGridView.EditIndex = -1;
            BindCom();
        }

        protected void DeviceGridView_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    ((LinkButton)e.Row.Cells[2].Controls[0]).OnClientClick = "return confirm('ต้องการลบอุปกรณ์ที่ได้รับความเสียหายใช่หรือไม่');";
                }
                catch { }
            }
        }

        protected void DeviceGridView_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            string sql = "Update tbl_device_damaged set device_damaged_delete='1' WHERE device_damaged_id = '" + DeviceGridView.DataKeys[e.RowIndex].Value + "'";
            //string script = "";
            function.MySqlQuery(sql);
            function.Close();
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('" + script + "')", true);
            DeviceGridView.EditIndex = -1;
            BindDevice();
        }

        void BindDevice()
        {
            string sql = "SELECT * FROM tbl_device_damaged dd JOIN tbl_device d ON d.device_id = dd.device_id where claim_id = '" + Session["CodePK"].ToString() + "' AND device_damaged_delete <> '1' ";
            MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            DeviceGridView.DataSource = ds.Tables[0];
            DeviceGridView.DataBind();
            lbClaimDetailNull.Text = "อุปกรณ์ที่ได้รับความเสียหาย " + ds.Tables[0].Rows.Count + " ชิ้น";
        }

        protected void btnAddDeviceBroken_Click(object sender, EventArgs e)
        {
            if (CheckDeviceNotDamaged.Checked) {
            
                AlertPop("แจ้งเพื่อทราบ (อุปกรณ์ไม่ได้รับความเสียหาย) ไม่สามารถเพิ่มอุปกรณ์ได้ ", "error");
            }
            else
            {
                if (txtDeviceBroken.Text != "" && txtDevice.SelectedValue != "")
                {
                    string sql = "INSERT INTO tbl_device_damaged (device_id,device_damaged,claim_id,device_damaged_delete) VALUES ('" + txtDevice.SelectedValue + "','" + txtDeviceBroken.Text.Trim() + "','" + Session["CodePK"].ToString() + "','0')";
                    function.MySqlQuery(sql);
                    BindDevice();
                }
                else
                {
                    AlertPop("ไม่สามารถเพิ่มอุปกรณ์ได้ กรุณาตรวจสอบอีกครั้ง", "error");
                }
            }
            txtDevice.SelectedIndex = 0;
            txtDeviceBroken.Text = "";
        }

            protected void FileGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Image ImgClaim = (Image)(e.Row.FindControl("ImgClaim"));
            if (ImgClaim != null)
            {
                ImgClaim.ImageUrl = (string)DataBinder.Eval(e.Row.DataItem, "claim_img_url");
            }

            LinkButton btnDownload = (LinkButton)(e.Row.FindControl("btnDownload"));
            if (btnDownload != null)
            {
                btnDownload.CommandArgument = ((string)DataBinder.Eval(e.Row.DataItem, "claim_img_url")).ToString();
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    ((LinkButton)e.Row.Cells[2].Controls[0]).OnClientClick = "return confirm('ต้องการรูปภาพแนบ ใช่หรือไม่');";
                }
                catch { }
            }
        }

        protected void FileGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string partFile = function.GetSelectValue("tbl_claim_img", "claim_img_id='" + FileGridView.DataKeys[e.RowIndex].Value + "'", "claim_img_url");
            string sql_delete = "DELETE FROM tbl_claim_img WHERE claim_img_id = '" + FileGridView.DataKeys[e.RowIndex].Value + "'";

            if (function.MySqlQuery(sql_delete))
            {
                if (File.Exists(Server.MapPath(partFile)))
                {
                    File.Delete(Server.MapPath(partFile));
                }
                BindImg();
            }
        }

        protected void btnAddImg_Click(object sender, EventArgs e)
        {
            if (fileImg.HasFile)
            {
                foreach (HttpPostedFile postedFile in fileImg.PostedFiles)
                {
                    Insert(0, postedFile);
                    AlertPop("Upload Complete", "success");
                }
            }
            else
            {
                AlertPop("Error : แนบรูปภาพล้มเหลว ไฟล์เอกสารต้องเป็น *.jpg *.jpge *.png เท่านั้น", "error");
            }
            //Insert(0, fileImg);
        }

        void BindImg()
        {
            string sql = "SELECT * FROM tbl_claim_img where claim_deteil_id = '" + Session["CodePK"].ToString() + "' and claim_img_type = '0'";
            MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            FileGridView.DataSource = ds.Tables[0];
            FileGridView.DataBind();
            LabelImg.Text = "รูปภาพแนบ " + ds.Tables[0].Rows.Count + " ภาพ";
        }

        protected void btnDownload_Command(object sender, CommandEventArgs e)
        {
            DownLoad(e.CommandArgument.ToString());
        }

        public void DownLoad(string FName)
        {
            try
            {
                string strURL = FName;
                string[] typeFile = FName.Split('/');
                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("Content-Disposition", "attachment;filename=\"" + function.getMd5Hash(Session["CodePK"].ToString() + DateTime.Now) + "." + typeFile[typeFile.Length - 1].Split('.')[1] + "\"");
                byte[] data = req.DownloadData(Server.MapPath(strURL));
                response.BinaryWrite(data);
                response.End();
            }
            catch
            {

            }
        }

        public string GetThaiMonth(string fulldate)
        {
            string[] subfuldate = fulldate.Split('-');
            string result = "";
            if (subfuldate[1] == "01") { result = "มกราคม"; }
            else if (subfuldate[1] == "02") { result = "กุมภาพันธ์"; }
            else if (subfuldate[1] == "03") { result = "มีนาคม"; }
            else if (subfuldate[1] == "04") { result = "เมษายน"; }
            else if (subfuldate[1] == "05") { result = "พฤษภาคม"; }
            else if (subfuldate[1] == "06") { result = "มิถุนายน"; }
            else if (subfuldate[1] == "07") { result = "กรกฎาคม"; }
            else if (subfuldate[1] == "08") { result = "สิงหาคม"; }
            else if (subfuldate[1] == "09") { result = "กันยายน"; }
            else if (subfuldate[1] == "10") { result = "ตุลาคม"; }
            else if (subfuldate[1] == "11") { result = "พฤศจิกายน"; }
            else if (subfuldate[1] == "12") { result = "ธันวาคม"; }
            return result;
        }
        protected void btnSaveReport_Click(object sender, EventArgs e)
        {
            string claimmonth = GetThaiMonth(txtStartDate.Text);
            if (rbtForKnow.Checked)
            {
                //DivDamaged.Visible = false;
                status = "6";
            }
            else
            {
                //DivDamaged.Visible = true;
                status = "1";
            }

            if (RadioButton2.Checked) { txtInsurer.Text = "ไม่มีประกัน"; } else { }

            if (RadioButton3.Checked) { txtInsurer.Text = ""; } else { }

            string sql_check = "SELECT * FROM tbl_claim WHERE claim_id='" + Session["CodePK"].ToString() + "'";
            string note_number = "กท./ฝจ./" + txtCpoint.SelectedItem;

            if (txtPoint.Text.Trim().ToLower() != "tsb" && txtPoint.Text.Trim().ToLower() != "") { note_number += " " + txtPoint.Text.Trim(); }
            note_number += "/คร./";
            
            if (note_number == "")
            {
                note_number += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            else
            {
                note_number += txtCpointNote.Text.Trim();
            }

            note_number += "/" + txtCpointDate.Text.Split('-')[2];
            MySqlDataReader rs = function.MySqlSelect(sql_check);

            if (rs.Read())
            {
                rs.Close();
                function.Close();
                //Update
                string sql = "";

                sql = "Update tbl_claim SET claim_equipment='" + txtEquipment.Text + "'" +
                    ", claim_cpoint='" + txtCpoint.SelectedValue + "'" +
                    ", claim_point='" + txtPoint.Text + "'" +
                    ", claim_cpoint_note='" + note_number + "'" +
                    ", claim_cpoint_date='" + txtCpointDate.Text + "'" +
                    ", claim_start_date='" + txtStartDate.Text + "'" +
                    ", claim_budget_year='" + function.getBudgetYear(txtCpointDate.Text) + "'" +
                    ", claim_month='" + claimmonth + "' " +
                    ", claim_status ='" + status + "'" +
                    " WHERE claim_id = '" + Session["CodePK"].ToString() + "'";

                if (function.MySqlQuery(sql))
                {
                    string text = "claim_detail_note_to = '" + txtNoteTo.Text + "'" +
                        ", claim_detail_around='" + txtAround.SelectedItem + "'" +
                        ", claim_detail_point='" + txtPoint.Text.Trim() + "'" +
                        ", claim_detail_point='" + txtPoint.Text.Trim() + "'" +
                        ", claim_detail_time='" + txtTime.Text + "'" +
                        ", claim_detail_user_alear='" + txtNameAleat.Text + "'" +
                        ", claim_detail_pos_user_alear='" + txtPosAleat.SelectedItem + "'" +
                        ", claim_detail_cb='" + txtCB.Text + "'" +
                        ", claim_detail_cb_claim='" + txtCBClaim.Text + "'" +
                        ", claim_detail_direction='" + txtDirection.Text + "'" +
                        ", claim_detail_comefrom = '" + txtComeFrom.Text + "'" +
                        ", claim_detail_direction_in='" + txtDirectionIn.Text + "'" +
                        ", claim_detail_accident='" + txtDetail.Text + "'" +
                        ", claim_detail_supervisor='" + txtSup.Text + "'" +
                        ", claim_detail_supervisor_pos='" + txtPosSup.SelectedItem + "'";

                    if (txtBrandCar.SelectedItem.ToString() == "")
                    {
                        text += ", claim_detail_car = '" + txtTypeCar.SelectedItem + " ,," + txtBrandCar.SelectedItem + " ,สี," + txtColorCar.Text.Trim() + "' ";
                    }
                    else
                    {
                        text += ", claim_detail_car='" + txtTypeCar.SelectedItem + " ,ยี่ห้อ ," + txtBrandCar.SelectedItem + " ,สี," + txtColorCar.Text.Trim() + "' ";
                    }

                    //", claim_detail_car='" + txtTypeCar.SelectedItem + " ,ยี่ห้อ ," + txtBrandCar.SelectedItem + " ,สี," + txtColorCar.Text.Trim() + "'" +
                    text += ", claim_detail_license_plate='" + txtLicensePlate.Text + "'" +
                    ", Licen_Eng ='" + txtLiEng.Text + "'" +
                    ", claim_detail_province='" + txtProvince.Text + "'" +
                    ", Province_Eng='" + txtProEng.Text + "'" +
                    ", claim_detail_driver='" + txtNameDrive.Text + "'" +
                    ", claim_detail_idcard='" + txtIdcard.Text + "'" +
                    ", claim_detail_address='" + txtAddressDriver.Text + "'" +
                    ", claim_detail_lp2='" + txtLp2.Text + "'" +
                    ", claim_detail_insurer='" + txtInsurer.Text + "'" +
                    ", claim_detail_policyholders='" + txtPolicyholders.Text + "'" +
                    ", claim_detail_clemence='" + txtClemence.Text + "'" +
                    ", claim_detail_inform='" + txtInform.Text + "'" +
                    ", claim_detail_tel='" + txtTelDrive.Text + "',claim_detail_provi2 = '" + txtProvince22.Text + "' ";
                    
                    sql = "UPDATE tbl_claim_com SET " + text + " WHERE claim_id = '" + Session["CodePK"].ToString() + "' AND claim_detail_number = '1'";

                    //sql 2nd Car
                    string text2car = "claim_detail_note_to = '" + txtNoteTo.Text + "'" +
                        ", claim_detail_around='" + txtAround.SelectedItem + "'" +
                        ", claim_detail_point='" + txtPoint.Text.Trim() + "'" +
                        ", claim_detail_point='" + txtPoint.Text.Trim() + "'" +
                        ", claim_detail_time='" + txtTime.Text + "'" +
                        ", claim_detail_user_alear='" + txtNameAleat.Text + "'" +
                        ", claim_detail_pos_user_alear='" + txtPosAleat.SelectedItem + "'" +
                        ", claim_detail_cb='" + txtCB.Text + "'" +
                        ", claim_detail_cb_claim='" + txtCBClaim.Text + "'" +
                        ", claim_detail_direction='" + txtDirection.Text + "'" +
                        ", claim_detail_comefrom = '" + txtComeFrom.Text + "'" +
                        ", claim_detail_direction_in='" + txtDirectionIn.Text + "'" +
                        ", claim_detail_accident='" + txtDetail.Text + "'" +
                        ", claim_detail_supervisor='" + txtSup.Text + "'" +
                        ", claim_detail_supervisor_pos='" + txtPosSup.SelectedItem + "'" +
                        ", claim_detail_car='" + ddlSecTypecar.SelectedItem + " ,ยี่ห้อ ," + ddlbrandcar2.SelectedItem + " ,สี," + txtColorcar2.Text.Trim() + "'" +
                        ", claim_detail_license_plate='" + txtnocar2.Text + "'" +
                        ", Licen_Eng ='" + txtLiEng.Text + "'" +
                        ", claim_detail_province='" + txtprovince2.Text + "'" +
                        ", Province_Eng='" + txtProEng.Text + "'" +
                        ", claim_detail_driver='" + txtDriver2.Text + "'" +
                        ", claim_detail_idcard='" + txtIDcar2.Text + "'" +
                        ", claim_detail_address='" + txtAddress2.Text + "'" +
                        ", claim_detail_lp2='" + txtLp2.Text + "'" +
                        ", claim_detail_insurer='" + txtInsurer.Text + "'" +
                        ", claim_detail_policyholders='" + txtPolicyholders.Text + "'" +
                        ", claim_detail_clemence='" + txtClemence.Text + "'" +
                        ", claim_detail_inform='" + txtInform.Text + "'" +
                        ", claim_detail_tel='" + txtTelcar2.Text + "',claim_detail_provi2 = '" + txtProvince22.Text + "' ";
                        
                    string sql2car = "UPDATE tbl_claim_com SET " + text + " WHERE claim_id = '" + Session["CodePK"].ToString() + "' AND claim_detail_number = '2'";

                    if (function.MySqlQuery(sql) || function.MySqlQuery(sql2car))
                    {
                        sql = "UPDATE tbl_status_detail SET detail_status_id = '" + status + "', detail_date_start ='" + txtStartDate.Text + "',detail_date_end ='" + function.ConvertDateTime(txtStartDate.Text, 3) + "' WHERE (detail_status_id='1' OR detail_status_id='6') AND detail_claim_id='" + Session["CodePK"].ToString() + "'";
                        function.MySqlQuery(sql);
                        AlertPop("บันทึกข้อมูลสำเร็จ", "success");
                        //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('บันทึกข้อมูลสำเร็จ')", true);
                        checkInsuran();
                    }
                    else
                    {
                        AlertPop("Error 9000 : บันทึกข้อมูลล้มเหลวกรุณาติดต่อเจ้าหน้าที่", "error");
                        //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Error : บันทึกข้อมูลล้มเหลว')", true);
                    }
                }
                else
                {
                    AlertPop("Error 9001 : บันทึกข้อมูลล้มเหลวกรุณาติดต่อเจ้าหน้าที่", "error");
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Error : บันทึกข้อมูลล้มเหลว')", true);
                }
            }
            else
            {
                rs.Close();
                function.Close();
                //Insert
                string Sql_check = "SELECT * FROM tbl_claim WHERE claim_cpoint = '" + txtCpoint.SelectedValue + "' AND claim_point = '" + txtPoint.Text.Trim() + "' AND SUBSTRING_INDEX(SUBSTRING_INDEX(claim_cpoint_note,'/',-2),'/',1) = '" + txtCpointNote.Text.Trim() + "' AND claim_cpoint_date = '" + txtCpointDate.Text.Trim() + "' AND claim_start_date = '" + txtStartDate.Text.Trim() + "' AND claim_delete = '0'";
                MySqlDataReader rsc = function.MySqlSelect(Sql_check);
                if (!rsc.Read())
                {
                    string sql = "INSERT INTO tbl_claim ( claim_id, claim_equipment, claim_cpoint, claim_point, claim_cpoint_note, claim_cpoint_date, claim_status, claim_start_date, claim_user_start_claim, claim_user_start_claim_time, claim_delete,claim_budget_year, claim_month ) VALUES ( '" + Session["CodePK"].ToString() + "', '" + txtEquipment.Text + "', '" + txtCpoint.SelectedValue + "', '" + txtPoint.Text + "', '" + note_number + "', '" + txtCpointDate.Text + "', '" + status + "', '" + txtStartDate.Text + "', '" + Session["User"].ToString() + "', NOW(), '0','" + function.getBudgetYear(txtCpointDate.Text) + "' , '" + claimmonth + "' )";
                    if (function.MySqlQuery(sql))
                    {
                        string text = "";
                        string values = "";
                        text += "claim_id" +
                            ", claim_detail_note_to" +
                            ", claim_detail_point" +
                            ", claim_detail_around" +
                            ", claim_detail_time" +
                            ", claim_detail_user_alear" +
                            ", claim_detail_pos_user_alear" +
                            ", claim_detail_cb" +
                            ", claim_detail_cb_claim" +
                            ", claim_detail_direction" +
                            ", claim_detail_comefrom" +
                            ", claim_detail_direction_in" +
                            ", claim_detail_accident" +
                            ", claim_detail_supervisor" +
                            ", claim_detail_supervisor_pos" +
                            ", claim_detail_car" +
                            ", claim_detail_license_plate" +
                            ", Licen_Eng " +
                            ", claim_detail_province" +
                            ", Province_Eng " +
                            ", claim_detail_driver" +
                            ", claim_detail_idcard" +
                            ", claim_detail_address" +
                            ", claim_detail_lp2" +
                            ", claim_detail_insurer" +
                            ", claim_detail_policyholders" +
                            ", claim_detail_clemence" +
                            ", claim_detail_inform" +
                            ", claim_detail_tel, claim_detail_number,claim_detail_provi2";

                        values += "'" + Session["CodePK"].ToString() + "'" +
                            ", '" + txtNoteTo.Text + "'" +
                            ", '" + txtPoint.Text + "'" +
                            ", '" + txtAround.SelectedItem + "'" +
                            ", '" + txtTime.Text + "'" +
                            ", '" + txtNameAleat.Text + "'" +
                            ", '" + txtPosAleat.SelectedItem + "'" +
                            ", '" + txtCB.Text + "'" +
                            ", '" + txtCBClaim.Text + "'" +
                            ", '" + txtDirection.Text + "'" +
                            ", '" + txtComeFrom.Text + "'" +
                            ", '" + txtDirectionIn.Text + "'" +
                            ", '" + txtDetail.Text + "'" +
                            ", '" + txtSup.Text + "'" +
                            ", '" + txtPosSup.SelectedItem + "'" +
                            ", '" + txtTypeCar.SelectedItem + " ,ยี่ห้อ ," + txtBrandCar.SelectedItem + " ,สี," + txtColorCar.Text.Trim() + "'" +
                            ", '" + txtLicensePlate.Text + "'" +
                            ", '" + txtLiEng.Text + "'" +
                            ", '" + txtProvince.Text + "'" +
                            ", '" + txtProEng.Text + "'" +
                            ", '" + txtNameDrive.Text + "'" +
                            ", '" + txtIdcard.Text + "'" +
                            ", '" + txtAddressDriver.Text + "'" +
                            ", '" + txtLp2.Text + "'" +
                            ", '" + txtInsurer.Text + "'" +
                            ", '" + txtPolicyholders.Text + "'" +
                            ", '" + txtClemence.Text + "'" +
                            ", '" + txtInform.Text + "'" +
                            ", '" + txtTelDrive.Text + "', '1','" + txtProvince22.Text + "'";

                        sql = "INSERT INTO tbl_claim_com (" + text + ") VALUES (" + values + ")";

                        if (function.MySqlQuery(sql))
                        {
                            sql = "INSERT INTO tbl_status_detail (detail_status_id,detail_claim_id,detail_date_start,detail_date_end) VALUES ('" + status + "','" + Session["CodePK"].ToString() + "','" + txtStartDate.Text + "','" + function.ConvertDateTime(txtStartDate.Text, 3) + "')";
                            if (function.MySqlQuery(sql))
                            {
                                GenerateID();
                                AlertPop("บันทึกข้อมูลสำเร็จ", "success");
                                checkInsuran();
                            }                             
                        }
                        else
                        {
                            AlertPop("Error 8000 : บันทึกข้อมูลล้มเหลว!", "error");
                        }
                    }
                    else
                    {
                        AlertPop("Error 8001 : บันทึกข้อมูลล้มเหลว!!", "error");
                    }
                }
                else
                {
                    AlertPop("แจ้งรายการอุบัติเหตุซ้ำ กรุณาตรวจสอบ", "warning");
                }
            }

        }

        void PageLoadData()
        {
            //string sql = "SELECT * FROM tbl_claim c1 JOIN tbl_claim_com cc ON c1.claim_id = cc.claim_id WHERE c1.claim_id = '" + Session["CodePK"].ToString() + "'";
            string sql = "SELECT * FROM tbl_claim c1 ";
            sql += " JOIN tbl_claim_com cc ON c1.claim_id = cc.claim_id ";
            sql += " JOIN tbl_status ON c1.claim_status = tbl_status.status_id ";
            sql += " JOIN tbl_claim_auto_id id ON c1.claim_id = id.claim_id ";
            sql += " WHERE c1.claim_id = '" + Session["CodePK"].ToString() + "'";

            MySqlDataReader rs = function.MySqlSelect(sql);

            if (rs.Read())
            {
                txtEquipment.Text = rs.GetString("claim_equipment");
                txtCpoint.SelectedValue = rs.GetString("claim_cpoint");
                txtPoint.Text = rs.GetString("claim_point");
                txtCpointNote.Text = rs.GetString("claim_cpoint_note").Split('/')[4];
                txtCpointDate.Text = rs.GetString("claim_cpoint_date");
                txtStartDate.Text = rs.GetString("claim_start_date");
                txtNoteTo.Text = rs.GetString("claim_detail_note_to");
                txtAround.Text = rs.GetString("claim_detail_around");
                txtTime.Text = rs.GetString("claim_detail_time");
                txtNameAleat.Text = rs.GetString("claim_detail_user_alear");
                txtPosAleat.Text = rs.GetString("claim_detail_pos_user_alear");
                txtCB.Text = rs.GetString("claim_detail_cb");
                txtCBClaim.Text = rs.GetString("claim_detail_cb_claim");
                txtDirection.Text = rs.GetString("claim_detail_direction");
                txtDirectionIn.Text = rs.GetString("claim_detail_direction_in");
                txtDetail.Text = rs.GetString("claim_detail_accident");
                txtSup.Text = rs.GetString("claim_detail_supervisor");
                txtPosSup.Text = rs.GetString("claim_detail_supervisor_pos");
                statheader.Text = rs.GetString("status_name");
                statheader.CssClass = "badge badge-" + rs.GetString("status_alert");
                lbControlNum.Text = "เลขควบคุม : "+ rs.GetString("claim_auto_id");
                try
                {
                    txtTypeCar.SelectedValue = rs.GetString("claim_detail_car").Split(',')[0].Trim();
                    txtBrandCar.SelectedValue = rs.GetString("claim_detail_car").Split(',')[2].Trim();
                    txtColorCar.Text = rs.GetString("claim_detail_car").Split(',')[4].Trim();
                    txtLiEng.Text = rs.GetString("Licen_Eng");
                    txtProEng.Text = rs.GetString("Province_Eng");
                    txtProvince22.Text = rs.GetString("claim_detail_provi2");
                }
                catch { txtColorCar.Text = rs.GetString("claim_detail_car"); }
                //txtCar.Text = rs.GetString("claim_detail_car");
                txtLicensePlate.Text = rs.GetString("claim_detail_license_plate");
                txtProvince.Text = rs.GetString("claim_detail_province");
                txtNameDrive.Text = rs.GetString("claim_detail_driver");
                txtIdcard.Text = rs.GetString("claim_detail_idcard");
                txtAddressDriver.Text = rs.GetString("claim_detail_address");
                txtTelDrive.Text = rs.GetString("claim_detail_tel");
                txtComeFrom.Text = rs.GetString("claim_detail_comefrom");
                txtLp2.Text = rs.GetString("claim_detail_lp2");
                txtInsurer.Text = rs.GetString("claim_detail_insurer");
                txtPolicyholders.Text = rs.GetString("claim_detail_policyholders");
                txtClemence.Text = rs.GetString("claim_detail_clemence");
                txtInform.Text = rs.GetString("claim_detail_inform");
                if (rs.GetString("claim_status") == "6")
                {
                    rbtForKnow.Checked = true; CheckDeviceNotDamaged.Checked = true; DivDamaged.Visible = false;
                    lbtnDeletecar2.Visible = false; lbtnsubmitcar2.Visible = false;
                }
                else
                {
                    CheckDeviceNotDamaged.Checked = false; DivDamaged.Visible = true;
                    rbtNormal.Checked = true;
                    if (rs.GetString("claim_status") != "1")
                    {
                        lbtnDeletecar2.Visible = false; lbtnsubmitcar2.Visible = false;
                    }
                }
                /*string chk = txtInsurer.Text;
                if(chk == "ไม่มีประกัน")
                {
                    RadioButton2.Checked = true;
                    txtInsurer.Enabled = false;
                }
                else
                {
                    RadioButton1.Checked = true;
                    txtInsurer.Enabled = true;
                }
                */
                checkInsuran();
            }
            rs.Close();
            string firstsql = "SELECT * FROM tbl_claim_com WHERE claim_id = '" + Session["CodePK"].ToString() + "' AND claim_detail_number = '1'";
            MySqlDataReader fst = function.MySqlSelect(firstsql);

            if (fst.Read())
            {
                divcar2.Visible = true;
                string sqkk = "SELECT * FROM tbl_claim_com WHERE claim_id = '" + Session["CodePK"].ToString() + "' AND claim_detail_number = '2'";
                MySqlDataReader ckk = function.MySqlSelect(sqkk);
                if (ckk.Read())
                {
                    // divcar3.Visible = true;
                    ckk.Close();
                }
            }
            function.Close();
        }

        protected void UploadDocGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Image ImgClaim = (Image)(e.Row.FindControl("DocClaim"));
            
            if (ImgClaim != null)
            {
                string typeFile = (string)DataBinder.Eval(e.Row.DataItem, "claim_img_url");
                string ext = Path.GetExtension(typeFile);

                if (ext == ".pdf")
                {
                    ImgClaim.ImageUrl = "/Claim/Upload/img_pdf.png";
                }
                else
                {
                    ImgClaim.ImageUrl = (string)DataBinder.Eval(e.Row.DataItem, "claim_img_url");
                }
            }

            LinkButton btnDownload = (LinkButton)(e.Row.FindControl("btnDocDownload"));
            if (btnDownload != null)
            {
                btnDownload.CommandArgument = ((string)DataBinder.Eval(e.Row.DataItem, "claim_img_url")).ToString();
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    ((LinkButton)e.Row.Cells[2].Controls[0]).OnClientClick = "return confirm('ต้องการรูปภาพเอกสารแนบ ใช่หรือไม่');";
                }
                catch { }
            }
        }

        protected void UploadDocGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string partFile = function.GetSelectValue("tbl_claim_img", "claim_img_id='" + UploadDocGridView.DataKeys[e.RowIndex].Value + "'", "claim_img_url");
            string sql_delete = "DELETE FROM tbl_claim_img WHERE claim_img_id = '" + UploadDocGridView.DataKeys[e.RowIndex].Value + "'";

            if (function.MySqlQuery(sql_delete))
            {
                if (File.Exists(Server.MapPath(partFile)))
                {
                    File.Delete(Server.MapPath(partFile));
                }
                BindDoc();
            }
        }

        void BindDoc()
        {
            string sql = "SELECT * FROM tbl_claim_img where claim_deteil_id = '" + Session["CodePK"].ToString() + "' and claim_img_type = '1'";
            MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            UploadDocGridView.DataSource = ds.Tables[0];
            UploadDocGridView.DataBind();
            LabelDoc.Text = "รูปภาพเอกสารแนบ " + ds.Tables[0].Rows.Count + " ภาพ";
        }

        protected void btnUploadDoc_Click(object sender, EventArgs e)
        {
            if (FileUploadDoc.HasFile)
            {
                foreach (HttpPostedFile postedFile in FileUploadDoc.PostedFiles)
                {
                    Insert(1, postedFile);
                    AlertPop("Upload Complete", "success");
                }
            }
            else
            {
                AlertPop("Error : แนบรูปภาพเอกสารประกอบ ล้มเหลว ไม่พบไฟล์เอกสาร / ไฟล์เอกสารต้องเป็น *.jpg *.jpge *.png เท่านั้น", "error");
            }
        }

        void Insert(int type, HttpPostedFile file)
        {
            String NewFileDocName = "";
            string typeFile = file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            if (typeFile == "jpg" || typeFile == "jpeg" || typeFile == "png" || typeFile == "pdf")
            {
                if(type == 6)
                {
                    NewFileDocName = "/Claim/Upload/" + file.FileName;
                }else{
                    NewFileDocName = Session["CodePK"].ToString() + new Random().Next(1000, 9999);
                    NewFileDocName = "/Claim/Upload/" + function.getMd5Hash(NewFileDocName) + "." + typeFile;
                }
                
                file.SaveAs(Server.MapPath(NewFileDocName.ToString()));

                string sql_text = "claim_img_url,claim_deteil_id,claim_img_type";
                string sql_value = "'" + NewFileDocName + "','" + Session["CodePK"].ToString() + "','" + type + "'";
                string sql_insert = "INSERT INTO tbl_claim_img (" + sql_text + ") VALUES (" + sql_value + ")";
                function.MySqlQuery(sql_insert);
                BindImg();
                BindDoc();
                BindPDF();
            }
            else
            {
                AlertPop("Error : แนบรูปภาพล้มเหลว ไฟล์เอกสารต้องเป็น *.jpg *.jpge *.png เท่านั้น", "error");
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Error : แนบรูปภาพล้มเหลว ไฟล์เอกสารต้องเป็น *.jpg *.jpge *.png เท่านั้น')", true);
            }
        }

        void ShowDiv()
        {
            if (Session["User"].ToString() == function.GetSelectValue("tbl_claim", "claim_id='" + Session["CodePK"].ToString() + "'", "claim_user_start_claim"))
            {
                btnDelete.Visible = true;
            }
            else
            {
                btnDelete.Visible = false;
            }

            switch (Session["UserPrivilegeId"].ToString())
            {
                case "0":
                    divCom.Visible = true;
                    divSup.Visible = true;
                    //btnPrintNoteSup.Visible = true;
                    break;
                case "1"://เทคโน
                    divCom.Visible = true;
                    divSup.Visible = true;
                    //btnPrintNoteSup.Visible = true;
                    break;
                case "2"://คอม
                    divCom.Visible = true;

                    divSup.Visible = true;
                    //btnPrintNoteSup.Visible = true;
                    break;
                case "3"://รอง
                    divCom.Visible = false;

                    divSup.Visible = true;
                    //btnPrintNoteSup.Visible = true;
                    break;
                case "4"://สถิติ
                    divCom.Visible = true;
                    divSup.Visible = true;
                    //btnPrintNoteSup.Visible = false;
                    break;
                case "6"://viewer
                    divCom.Visible = true;
                    divSup.Visible = true;
                    //btnPrintNoteSup.Visible = false;
                    break;
                default:
                    divCom.Visible = false;
                    divSup.Visible = false;
                    //btnPrintNoteSup.Visible = false;
                    break;
            }
        }

        protected void btnReportImg_Click(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("/Claim/reportImg.rpt"));
            Model.DataSetClaim setClaim = new Model.DataSetClaim();

            string sql = "SELECT claim_img_id,claim_img_url,claim_deteil_id,claim_img_type FROM tbl_claim_img "; 
                   sql += "WHERE claim_deteil_id = '" + Session["CodePK"].ToString() + "' and claim_img_type = '0'";
            MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
            setClaim.Clear();
            da.Fill(setClaim, "tbl_claim_img");

            rpt.SetDataSource(setClaim);
            //rpt.PrintToPrinter(1, true, 0, 0);
            Session["Report"] = rpt;
            Session["ReportTitle"] = "รูปภาพประกอบ";
            Response.Write("<script>");
            Response.Write("window.open('/Report/reportView','_blank')");
            Response.Write("</script>");
        }

        protected void btnPrintNoteSup_Click(object sender, EventArgs e)
        {
            GetReport();
        }

        void GetReport()
        {
            string strNote = "เนื่องด้วยเมื่อวันที่ " + function.ConvertDatelongThai(txtStartDate.Text) + " " + txtAround.Text + " เวลาประมาณ " ;
                   strNote += txtTime.Text + " น. ได้รับแจ้งจาก" + txtNameAleat.Text + " " + txtPosAleat.Text + " ปฏิบัติหน้าที่ประจำด่านฯ " + txtCpoint.SelectedItem;

            if (txtCB.Text != "" && txtCB.Text != "-") { strNote += " ตู้ " + txtCB.Text; }
            strNote += " " + txtDirection.Text + " ได้แจ้งว่าเกิดอุบัติเหตุ" + txtDetail.Text + " จึงได้แจ้งรองผู้จัดการด่านฯ ประจำผลัด คือ " + txtSup.Text + " ให้ทราบ";

            string getcar2 = "select * FROM tbl_claim_com where claim_id = '" + Session["CodePK"].ToString() + "' AND claim_detail_number = '2'";
            string getcar3 = "select * FROM tbl_claim_com where claim_id = '" + Session["CodePK"].ToString() + "' AND claim_detail_number = '3'";
            string car2has = "1"; 
            string car3has = "1";

            MySqlDataReader checkcar2 = function.MySqlSelect(getcar2);
            if (checkcar2.Read())
            {
                string license2 = checkcar2.GetString("claim_detail_license_plate");
                string province2 = checkcar2.GetString("claim_detail_province");
                string cardetail2 = checkcar2.GetString("claim_detail_car");
                string licenEng2 = checkcar2.GetString("Licen_Eng");
                string provinEng2 = checkcar2.GetString("Province_Eng");
                string driver2 = checkcar2.GetString("claim_detail_driver");
                string idcard2 = checkcar2.GetString("claim_detail_idcard");
                string address2 = checkcar2.GetString("claim_detail_address");
                string licenAdd2 = checkcar2.GetString("claim_detail_lp2");
                string provinAdd2 = checkcar2.GetString("claim_detail_provi2");
                string tel2 = checkcar2.GetString("claim_detail_tel");
            }
            else
            {
                car2has = "0";
            }
            checkcar2.Close();
            MySqlDataReader checkcar3 = function.MySqlSelect(getcar3);

            if (checkcar3.Read())
            {
                string license3 = checkcar3.GetString("claim_detail_license_plate");
                string province3 = checkcar3.GetString("claim_detail_province");
                string cardetail3 = checkcar3.GetString("claim_detail_car");
                string licenEng3 = checkcar3.GetString("Licen_Eng");
                string provinEng3 = checkcar3.GetString("Province_Eng");
                string driver3 = checkcar3.GetString("claim_detail_driver");
                string idcard3 = checkcar3.GetString("claim_detail_idcard");
                string address3 = checkcar3.GetString("claim_detail_address");
                string licenAdd3 = checkcar3.GetString("claim_detail_lp2");
                string provinAdd3 = checkcar3.GetString("claim_detail_provi2");
                string tel3 = checkcar3.GetString("claim_detail_tel");
            }
            else
            {
                car3has = "0";
            }

            if (car2has == "1")
            {
                strNote += " หลังจากได้รับแจ้งเหตุเจ้าหน้าที่ควบคุมระบบและรองผู้จัดการด่านฯ ได้ลงไปตรวจสอบที่เกิดเหตุพร้อมบันทึกภาพไว้เป็นหลักฐาน พบคู่กรณีคันที่ ๑ หมายเลขทะเบียน " + txtLicensePlate.Text;
            }
            else
            {
                strNote += " หลังจากได้รับแจ้งเหตุเจ้าหน้าที่ควบคุมระบบและรองผู้จัดการด่านฯ ได้ลงไปตรวจสอบที่เกิดเหตุพร้อมบันทึกภาพไว้เป็นหลักฐาน พบคู่กรณีเป็น หมายเลขทะเบียน " + txtLicensePlate.Text;
            }

            if (txtLp2.Text != "")
            {
                if (txtProvince22.Text != "")
                {
                    if (txtProvince.Text != txtProvince22.Text)
                    {
                        strNote += " จังหวัด " + txtProvince.Text + " ส่วนพ่วงหมายเลขทะเบียน " + txtLp2.Text + " จังหวัด " + txtProvince22.Text;
                        if (txtLiEng.Text != "")
                        {
                            strNote += " หมายเลขทะเบียนสากล " + txtLiEng.Text + " " + txtProEng.Text + " ขับรถมาจาก" + txtComeFrom.Text + "มุ่งหน้า" + txtDirectionIn.Text + " โดยมี" + txtNameDrive.Text + " เลขที่บัตรประจำตัวประชาชนเลขที่ " + txtIdcard.Text + " ที่อยู่ " + txtAddressDriver.Text + " หมายเลขโทรศัพท์ " + txtTelDrive.Text + " เป็นผู้ขับรถยนต์ขันดังกล่าว";
                        }
                        else
                        {
                            strNote += " ขับรถมาจาก" + txtComeFrom.Text + "มุ่งหน้า" + txtDirectionIn.Text + " โดยมี" + txtNameDrive.Text + " เลขที่บัตรประจำตัวประชาชนเลขที่ " + txtIdcard.Text + " ที่อยู่ " + txtAddressDriver.Text + " หมายเลขโทรศัพท์ " + txtTelDrive.Text + " เป็นผู้ขับรถยนต์ขันดังกล่าว";
                        }
                    }
                    else
                    {
                        strNote += " ส่วนพ่วงหมายเลขทะเบียน " + txtLp2.Text;
                        if (txtLiEng.Text != "")
                        {
                            strNote += " จังหวัด" + txtProvince.Text + " หมายเลขทะเบียนสากล " + txtLiEng.Text + " " + txtProEng.Text + " ขับรถมาจาก" + txtComeFrom.Text + "มุ่งหน้า" + txtDirectionIn.Text + " โดยมี" + txtNameDrive.Text + " เลขที่บัตรประจำตัวประชาชนเลขที่ " + txtIdcard.Text + " ที่อยู่ " + txtAddressDriver.Text + " หมายเลขโทรศัพท์ " + txtTelDrive.Text + " เป็นผู้ขับรถยนต์ขันดังกล่าว";
                        }
                        else
                        {
                            strNote += " จังหวัด" + txtProvince.Text + " ขับรถมาจาก" + txtComeFrom.Text + "มุ่งหน้า" + txtDirectionIn.Text + " โดยมี" + txtNameDrive.Text + " เลขที่บัตรประจำตัวประชาชนเลขที่ " + txtIdcard.Text + " ที่อยู่ " + txtAddressDriver.Text + " หมายเลขโทรศัพท์ " + txtTelDrive.Text + " เป็นผู้ขับรถยนต์ขันดังกล่าว";
                        }
                    }
                }
                else
                {
                    if (txtLiEng.Text != "")
                    {
                        strNote += " จังหวัด" + txtProvince.Text + " หมายเลขทะเบียนสากล " + txtLiEng.Text + " " + txtProEng.Text + " ขับรถมาจาก" + txtComeFrom.Text + "มุ่งหน้า" + txtDirectionIn.Text + " โดยมี" + txtNameDrive.Text + " เลขที่บัตรประจำตัวประชาชนเลขที่ " + txtIdcard.Text + " ที่อยู่ " + txtAddressDriver.Text + " หมายเลขโทรศัพท์ " + txtTelDrive.Text + " เป็นผู้ขับรถยนต์ขันดังกล่าว";
                    }
                    else
                    {
                        strNote += " จังหวัด" + txtProvince.Text + " ขับรถมาจาก" + txtComeFrom.Text + "มุ่งหน้า" + txtDirectionIn.Text + " โดยมี" + txtNameDrive.Text + " เลขที่บัตรประจำตัวประชาชนเลขที่ " + txtIdcard.Text + " ที่อยู่ " + txtAddressDriver.Text + " หมายเลขโทรศัพท์ " + txtTelDrive.Text + " เป็นผู้ขับรถยนต์ขันดังกล่าว";
                    }
                }
            }
            else
            {
                if (txtLiEng.Text != "")
                {
                    strNote += " จังหวัด" + txtProvince.Text + " หมายเลขทะเบียนสากล " + txtLiEng.Text + " " + txtProEng.Text + " ขับรถมาจาก" + txtComeFrom.Text + "มุ่งหน้า" + txtDirectionIn.Text + " โดยมี" + txtNameDrive.Text + " เลขที่บัตรประจำตัวประชาชนเลขที่ " + txtIdcard.Text + " ที่อยู่ " + txtAddressDriver.Text + " หมายเลขโทรศัพท์ " + txtTelDrive.Text + " เป็นผู้ขับรถยนต์ขันดังกล่าว";
                }
                else
                {
                    strNote += " จังหวัด" + txtProvince.Text + " ขับรถมาจาก" + txtComeFrom.Text + "มุ่งหน้า" + txtDirectionIn.Text + " โดยมี" + txtNameDrive.Text + " เลขที่บัตรประจำตัวประชาชนเลขที่ " + txtIdcard.Text + " ที่อยู่ " + txtAddressDriver.Text + " หมายเลขโทรศัพท์ " + txtTelDrive.Text + " เป็นผู้ขับรถยนต์ขันดังกล่าว";
                }
            }

            strNote += " ซึ่งรถยนต์คันดังกล่าวได้ทำประกันไว้กับ" + txtInsurer.Text + " หมายเลขเคลมเลขที่ " + txtClemence.Text + " หมายเลขกรมธรรม์ " + txtPolicyholders.Text + " พร้อมนี้ ข้าพเจ้าได้ดำเนินการแจ้งความร้องทุกข์ไว้ที่ " + txtInform.Text + " เป็นหลักฐานแล้ว";

            //strNote += " จากการตรวจสอบเบื้งต้นพบว่ามีทรัพย์สินของทางราชการเสีหาย ดังนี้";
            string name = "";
            string com = "";
            string dev = "";
            string sql_com = "SELECT * FROM tbl_claim_com_working WHERE detail_com_id ='" + Session["CodePK"].ToString() + "'";
            string sql_dev = "SELECT * FROM tbl_device_damaged d JOIN tbl_device dd ON d.device_id = dd.device_id WHERE claim_id ='" + Session["CodePK"].ToString() + "'";

            MySqlDataReader rs = function.MySqlSelect(sql_com);

            int i = 1;

            while (rs.Read())
            {
                if (i == 1)
                {
                    name += "(" + rs.GetString("com_working_name") + ")\r\n" + rs.GetString("com_working_pos");
                    com += "ซึ่งมีเจ้าหน้าที่ควบคุมระบบปฏิบัติหน้าที่ประจำผลัด ดังนี้\r\n                      ";
                    com += i + ". " + rs.GetString("com_working_name");
                }
                else
                {
                    com += "\r\n                      " + i + ". " + rs.GetString("com_working_name");
                }
                i++;
            }
            rs.Close();
            name += "\r\n\r\n\r\n";
            name += "(" + function.GetSelectValue("tbl_claim_com", "claim_id='" + Session["CodePK"].ToString() + "'", "claim_detail_supervisor") + ")";
            name += "\r\n" + function.GetSelectValue("tbl_claim_com", "claim_id='" + Session["CodePK"].ToString() + "'", "claim_detail_supervisor_pos");
            function.Close();

            i = 1;
            rs = function.MySqlSelect(sql_dev);
            while (rs.Read())
            {
                if (i == 1)
                {
                    dev += i + ". " + rs.GetString("device_name") + " " + rs.GetString("device_damaged");
                }
                else
                {
                    dev += "\r\n                      " + i + ". " + rs.GetString("device_name") + " " + rs.GetString("device_damaged");
                }
                i++;
            }
            rs.Close();
            function.Close();

            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("/Claim/reportCom.rpt"));
            rpt.SetParameterValue("cpoint_title", "ด่านฯ " + txtCpoint.SelectedItem + " ฝ่ายบริหารจัดเก็บเงินค่าธรรมเนียม โทร. " + function.GetSelectValue("tbl_cpoint", "cpoint_id='" + txtCpoint.SelectedValue + "'", "cpoint_tel"));
            rpt.SetParameterValue("num_title", "กท./ฝจ./" + txtCpoint.SelectedItem + (txtPoint.Text.ToLower() == "tsb" ? "/" : txtPoint.Text + "/") + txtCpointNote.Text);
            rpt.SetParameterValue("txt_to", txtNoteTo.Text + " " + txtCpoint.SelectedItem);
            rpt.SetParameterValue("date_thai", function.ConvertDatelongThai(txtCpointDate.Text));
            rpt.SetParameterValue("note_title", txtEquipment.Text);
            rpt.SetParameterValue("note_text", strNote);
            rpt.SetParameterValue("name", name);
            rpt.SetParameterValue("part_img", Server.MapPath("/Claim/300px-Thai_government_Garuda_emblem_(Version_2).jpg"));
            rpt.SetParameterValue("list_dev", dev + "\r\n");
            rpt.SetParameterValue("list_com", com != "" ? com + "\r\n" : "");
            Session["Report"] = rpt;
            Session["ReportTitle"] = "บันทึกข้อความ";
            Response.Write("<script>");
            Response.Write("window.open('/Report/reportView','_blank')");
            Response.Write("</script>");
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

        protected void btnDelete_Click(object sender, EventArgs e) // รอปรับ code
        {
            string sql = "DELETE FROM tbl_claim  WHERE claim_id = '" + Session["CodePK"].ToString() + "'";
            string script = "";
            if (function.MySqlQuery(sql))
            {
                sql = "DELETE FROM tbl_claim_com  WHERE claim_id = '" + Session["CodePK"].ToString() + "'";
                function.MySqlQuery(sql);

                sql = "DELETE FROM tbl_claim_com_working  WHERE detail_com_id = '" + Session["CodePK"].ToString() + "'";
                function.MySqlQuery(sql);

                sql = "DELETE FROM tbl_claim_doc  WHERE claim_doc_id = '" + Session["CodePK"].ToString() + "'";
                function.MySqlQuery(sql);

                sql = "DELETE FROM tbl_status_detail  WHERE detail_claim_id = '" + Session["CodePK"].ToString() + "'";
                function.MySqlQuery(sql);

                sql = "DELETE FROM tbl_claim_img  WHERE claim_deteil_id = '" + Session["CodePK"].ToString() + "'";
                function.MySqlQuery(sql);

                script = "ลบข้อมูลสำเร็จ";
            }
            else
            {
                script = "Error : ลบข้อมูลล้มเหลว";
            }
            function.Close();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('" + script + "')", true);
            Response.Redirect("/Claim/claimForm");
        }

        protected void CheckDeviceNotDamaged_CheckedChanged(object sender, EventArgs e)
        {
            // if (CheckDeviceNotDamaged.Checked)
            // {
            //     DivDamaged.Visible = false;
            // }
            // else
            // {
            //     DivDamaged.Visible = true;
            // }
        }

        protected void btnTechno_Click(object sender, EventArgs e)
        {
            //Session["codePK"] = e.CommandName;
            Response.Redirect("/Techno/TechnoFormDetail");
        }

        protected void rbtForKnow_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtForKnow.Checked)
            {
                DivDamaged.Visible = true;
                DivNoDamage.Visible = true;
                status = "6";
            }
            else
            {
                DivNoDamage.Visible = false;
            }
        }

        protected void rbtNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtNormal.Checked)
            {
                DivNoDamage.Visible = false;
                DivDamaged.Visible = true;
                status = "1";
                CheckDeviceNotDamaged.Checked = false;
            }
            else
            {
                DivNoDamage.Visible = true;
            }
        }

        protected void lbtnDeletecar2_Command(object sender, CommandEventArgs e)
        {
            string deletecar2 = "DELETE FROM tbl_claim_com WHERE claim_id = '" + Session["CodePK"].ToString() + "' AND claim_detail_number ='" + lbmodaltitle.Text + "'";
            if (function.MySqlQuery(deletecar2))
            {
                AlertPop("ลบข้อมูลเรียบร้อย", "success");
            }
            else
            {
                AlertPop("ลบข้อมูลล้มเหลว กรุณาติดต่อแอดมิน", "error");
            }
        }
        protected void lbtnsubmitcar2_Command(object sender, CommandEventArgs e)
        {
            if (txtnocar2.Text != "" && txtprovince2.Text != "")
            {
                if (ddlSecTypecar.SelectedValue != "" && ddlbrandcar2.SelectedValue != "")
                {
                    string insertcar2 = "";
                    string textt = "(claim_detail_car" +
                                ", claim_detail_license_plate" +
                                ", Licen_Eng " +
                                ", claim_detail_province" +
                                ", Province_Eng" +
                                ", claim_detail_driver" +
                                ", claim_detail_idcard" +
                                ", claim_detail_address" +
                                ", claim_detail_lp2" +
                                ", claim_detail_tel,claim_detail_provi2,claim_detail_number,claim_id) VALUES " +
                                "('" + ddlSecTypecar.SelectedItem + " ,ยี่ห้อ ," + ddlbrandcar2.SelectedItem + " ,สี," + txtColorcar2.Text.Trim() +
                                "','" + txtnocar2.Text +
                                "','" + txtEngNo2.Text +
                                "','" + txtprovince2.Text +
                                "','" + txtEngProvince2.Text +
                                "','" + txtDriver2.Text +
                                "','" + txtIDcar2.Text +
                                "','" + txtAddress2.Text +
                                "','" + txtnocombind.Text +
                                "','" + txtTelcar2.Text +
                                "','" + txtprovince2222.Text + "','" + lbmodaltitle.Text + "','" + Session["CodePK"].ToString() + "')";
                    insertcar2 = "INSERT INTO tbl_claim_com  " + textt;

                    if (function.MySqlQuery(insertcar2))
                    {
                        //AlertPop("บันทึกข้อมูล สำเร็จ", "success");
                    }
                    else
                    {
                        AlertPop("บันทึกล้มเหลว ติดต่อเจ้าหน้าที่", "error");
                    }
                }
                else
                {
                    AlertPop("กรุณาเลือกประเภทรถ และยี่ห้อ", "error");
                }
            }
            else
            {
                AlertPop("กรุณาใส่เลขทะเบียนและจังหวัด", "error");
            }
        }

        protected void btnCar2_Click(object sender, EventArgs e)
        {
            Car2 = Session["codePK"].ToString();
            lbmodaltitle.Text = "2";
            modalLoadDATA("2");
        }

        protected void btnCar3_Click(object sender, EventArgs e)
        {
            Car2 = Session["codePK"].ToString();
            lbmodaltitle.Text = "3";
            modalLoadDATA("3");
        }

        void modalLoadDATA(string carnum)
        {
            string carload = "";
            if (carnum == "2")
            {
                carload = "select * FROM tbl_claim_com WHERE claim_id = '" + Session["CodePK"].ToString() + "' AND claim_detail_number = '2'";
            }
            else
            {
                carload = "select * FROM tbl_claim_com WHERE claim_id = '" + Session["CodePK"].ToString() + "' AND claim_detail_number = '3'";
            }
            MySqlDataReader SecCar = function.MySqlSelect(carload);

            if (SecCar.Read())
            {
                ddlSecTypecar.SelectedValue = SecCar.GetString("claim_detail_car").Split(',')[0].Trim();
                txtnocar2.Text = SecCar.GetString("claim_detail_license_plate");
                txtprovince2.Text = SecCar.GetString("claim_detail_province");
                txtDriver2.Text = SecCar.GetString("claim_detail_driver");
                txtIDcar2.Text = SecCar.GetString("claim_detail_idcard");
                txtAddress2.Text = SecCar.GetString("claim_detail_address");
                txtTelcar2.Text = SecCar.GetString("claim_detail_tel");
                try
                {
                    ddlbrandcar2.SelectedValue = SecCar.GetString("claim_detail_car").Split(',')[2].Trim();
                    txtColorcar2.Text = SecCar.GetString("claim_detail_car").Split(',')[4].Trim();
                    txtEngNo2.Text = SecCar.GetString("Licen_Eng");
                    txtEngProvince2.Text = SecCar.GetString("Province_Eng");
                }
                catch { }

                lbtnEditcar2.Visible = true;
                lbtnsubmitcar2.Visible = false;
            }
        }

        protected void lbtnEditcar2_Command(object sender, CommandEventArgs e)
        {
            if (txtnocar2.Text != "" && txtprovince2.Text != "")
            {
                string updatecar2 = "";
                string text = "claim_detail_note_to = '" + txtNoteTo.Text + "'" +
                            ", claim_detail_around='" + txtAround.SelectedItem + "'" +
                            ", claim_detail_point='" + txtPoint.Text.Trim() + "'" +
                            ", claim_detail_point='" + txtPoint.Text.Trim() + "'" +
                            ", claim_detail_time='" + txtTime.Text + "'" +
                            ", claim_detail_user_alear='" + txtNameAleat.Text + "'" +
                            ", claim_detail_pos_user_alear='" + txtPosAleat.SelectedItem + "'" +
                            ", claim_detail_cb='" + txtCB.Text + "'" +
                            ", claim_detail_cb_claim='" + txtCBClaim.Text + "'" +
                            ", claim_detail_direction='" + txtDirection.Text + "'" +
                            ", claim_detail_comefrom = '" + txtComeFrom.Text + "'" +
                            ", claim_detail_direction_in='" + txtDirectionIn.Text + "'" +
                            ", claim_detail_accident='" + txtDetail.Text + "'" +
                            ", claim_detail_supervisor='" + txtSup.Text + "'" +
                            ", claim_detail_supervisor_pos='" + txtPosSup.SelectedItem + "'" +
                            ", claim_detail_car='" + ddlSecTypecar.SelectedItem + " ,ยี่ห้อ ," + ddlbrandcar2.SelectedItem + " ,สี," + txtColorcar2.Text.Trim() + "'" +
                            ", claim_detail_license_plate='" + txtnocar2.Text + "'" +
                            ", Licen_Eng ='" + txtEngNo2.Text + "'" +
                            ", claim_detail_province='" + txtprovince2.Text + "'" +
                            ", Province_Eng='" + txtEngProvince2.Text + "'" +
                            ", claim_detail_driver='" + txtDriver2.Text + "'" +
                            ", claim_detail_idcard='" + txtIDcar2.Text + "'" +
                            ", claim_detail_address='" + txtAddress2.Text + "'" +
                            ", claim_detail_lp2='" + txtnocombind.Text + "'" +
                            ", claim_detail_insurer='" + txtInsurer.Text + "'" +
                            ", claim_detail_policyholders='" + txtPolicyholders.Text + "'" +
                            ", claim_detail_clemence='" + txtClemence.Text + "'" +
                            ", claim_detail_inform='" + txtInform.Text + "'" +
                            ", claim_detail_tel='" + txtTelcar2.Text + "',claim_detail_provi2 = '" + txtprovince2222.Text + "' ";
                updatecar2 = "UPDATE tbl_claim_com SET " + text + " WHERE claim_id = '" + Session["CodePK"].ToString() + "' AND claim_detail_number ='" + lbmodaltitle.Text + "'";

                if (function.MySqlQuery(updatecar2))
                {
                    AlertPop("บันทึกสำเร็จ", "success");
                }
                else
                {
                    AlertPop("บันทึกล้มเหลว ติดต่อเจ้าหน้าที่", "error");
                }
            }
            else
            {
                AlertPop("กรุณาใส่เลขทะเบียนและจังหวัด", "error");
            }
        }
        void checkInsuran()
        {
            string chk = txtInsurer.Text;
            if (chk == "ไม่มีประกัน")
            {
                RadioButton2.Checked = true;
                txtInsurer.Enabled = false;
            }
            else
            {
                RadioButton1.Checked = true;
                txtInsurer.Enabled = true;
            }
        }

        void GenerateID()
        {
            string sqlgenID = "";
            sqlgenID = "INSERT INTO `tbl_claim_auto_id` (claim_auto_id , claim_id , claim_delete) VALUES ((CONCAT ('" + function.getBudgetYear(txtCpointDate.Text) + "-', " +
                "LPAD(IFNULL((SELECT SUBSTR(claim_auto_id, 6) FROM `tbl_claim_auto_id` AS `alias` " +
                "WHERE SUBSTR(claim_auto_id, 1, 4) = '" + function.getBudgetYear(txtCpointDate.Text) + "' " +
                "ORDER BY claim_auto_id DESC LIMIT 1 ) + 1, 1), 5, '0' ) ) ) , '" + Session["CodePK"].ToString() + "' , '0') ";
            function.MySqlQuery(sqlgenID);
        }

        protected void UploadDocGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //
        }

        protected void btnFileUploadPDF_Click(object sender, EventArgs e)
        {
            if (FileUploadPDF.HasFile)
            {
                foreach (HttpPostedFile postedFile in FileUploadPDF.PostedFiles)
                {
                    Insert(6, postedFile);
                    AlertPop("Upload Complete", "success");
                }
            }
            else
            {
                AlertPop("Error : แนบรูปภาพเอกสารประกอบ ล้มเหลว ไม่พบไฟล์เอกสาร / ไฟล์เอกสารต้องเป็น *.jpg *.jpge *.png เท่านั้น", "error");
            }
        }

        protected void GridViewUploadPDF_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Image PDFClaim = (Image)(e.Row.FindControl("DocPDF"));

            // if (PDFClaim != null)
            // {
            //     string typeFile = (string)DataBinder.Eval(e.Row.DataItem, "claim_img_url");
            //     string ext = Path.GetExtension(typeFile);

            //     if (ext == ".pdf")
            //     {
            //         PDFClaim.ImageUrl = "/Claim/Upload/img_pdf.png";
            //     }
            //     else
            //     {
            //         PDFClaim.ImageUrl = (string)DataBinder.Eval(e.Row.DataItem, "claim_img_url");
            //     }
            // }

            Label namePDF = (Label)(e.Row.FindControl("namePDF"));
            if(namePDF != null)
            {
                string[] data = DataBinder.Eval(e.Row.DataItem, "claim_img_url").ToString().Split('/');
                namePDF.Text = data[3];
            }
        }

        protected void GridViewUploadPDF_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridViewUploadPDF_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileId = (string)e.CommandArgument;
            string folderPath = Server.MapPath(fileId);
            string[] item = fileId.Split('/');
            string fileName = item[3];

            if (fileId != null)
            {
                string pdfPath = folderPath;

                StreamReader streamReader = new StreamReader(pdfPath);

                Stream stream = streamReader.BaseStream;

                BinaryReader binaryReader = new BinaryReader(stream);

                byte[] sendbyteArray = binaryReader.ReadBytes(Convert.ToInt32(binaryReader.BaseStream.Length));

                if (e.CommandName.Equals("View"))
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Type", "application/pdf");
                    Response.AddHeader("Content-Disposition", "inline");
                    Response.BinaryWrite(sendbyteArray);
                    Response.End();
                }

                if (e.CommandName.Equals("Download"))
                {
                    Response.ContentType = "application/pdf";
                    Response.AppendHeader("Content-Disposition", "attachment; filename= "+ fileName + " ");
                    Response.BinaryWrite(sendbyteArray);
                    Response.End();
                }

                if (e.CommandName.Equals("Delete"))
                {
                    //string partFile = e.CommandArgument.ToString();
                    //string partFile = function.GetSelectValue("tbl_claim_img", "claim_img_id='" + GridViewUploadPDF.DataKeys[e.RowIndex].Value + "'", "claim_img_url");
                    string sql_delete = "UPDATE tbl_claim_img SET claim_img_type = '9' WHERE claim_img_url = '" + fileId + "' AND claim_deteil_id = '" + Session["CodePK"].ToString() + "' ";

                    if (function.MySqlQuery(sql_delete))
                    {
                        AlertPop("Success : ลบข้อมูลสำเร็จ", "success");
                    }
                    BindPDF();
                }
            }
        }

        void BindPDF()
        {
            string sql = "SELECT * FROM tbl_claim_img where claim_deteil_id = '" + Session["CodePK"].ToString() + "' and claim_img_type = '6'";
            MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            GridViewUploadPDF.DataSource = ds.Tables[0];
            GridViewUploadPDF.DataBind();
            lbPDFDoc.Text = "เอกสารแนบ " + ds.Tables[0].Rows.Count + " รายการ";
        }
    }
}