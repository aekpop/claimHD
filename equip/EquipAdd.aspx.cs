﻿using System;
using ClaimProject.Config;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Web.UI.HtmlControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO;
//test 10.59
namespace ClaimProject.equip
{
    public partial class EquipAdd : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public string alert = "";
        public string alertType = "";
        public string[] todayMain = DateTime.Today.ToString("dd-MM-yyyy").Split('-');
        public string equiptimeAdd = DateTime.Now.ToString("HH:mm:ss");
        public string EditModal = "";
        public string AddModal = "";
        public string icon = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/");
            }
            if (!this.IsPostBack)
            {
                string chk = Session["UserCpoint"].ToString();
                string username = Session["User"].ToString();
                Session.Add("SQLEQ", "");
                Session.Add("sqlreEQ", "");
                Session.Add("tolleq", "");
                Session.Add("describe","");

                
                function.getListItem(ddlEditCompany, "SELECT * FROM tbl_company Order By company_id ASC", "company_name", "company_id");
                function.getListItem(ddlEditStat, "SELECT * FROM tbl_equipment_status Order By status_id ASC", "status_name", "status_id");
                function.getListItem(ddlEditLocate, "SELECT * FROM tbl_location Order By locate_id ", "locate_name", "locate_id");
                function.getListItem(ddlsearchStat, "SELECT * FROM tbl_equipment_status Order By status_id ", "status_name", "status_id");
                if (Session["UserCpoint"].ToString() != "0" )
                {
                    string cpointToll = "SELECT * FROM tbl_toll " +
                                        "JOIN tbl_cpoint ON tbl_cpoint.cpoint_id = tbl_toll.cpoint_id " +
                                        "WHERE tbl_toll.cpoint_id = '" + Session["UserCpoint"].ToString() + "' Order By tbl_toll.toll_id ASC";
                    function.getListItem(ddlserchToll, cpointToll, "toll_name", "toll_id");
                    function.getListItem(ddlEditCpoint, "SELECT * FROM tbl_toll WHERE tbl_toll.cpoint_id = '" + Session["UserCpoint"].ToString() + "' Order By toll_id ASC", "toll_name", "toll_id");
                }
                else
                {
                    if (username == "sawitree")
                    {
                        function.getListItem(ddlEditCpoint, "SELECT * FROM tbl_toll WHERE toll_EQGroup = '1' Order By toll_id ASC", "toll_name", "toll_id");
                        function.getListItem(ddlserchToll, "SELECT * FROM tbl_toll WHERE toll_EQGroup = '1' Order By toll_id ASC", "toll_name", "toll_id");

                    }
                    else if(username == "supaporn")
                    {
                        function.getListItem(ddlEditCpoint, "SELECT * FROM tbl_toll WHERE toll_EQGroup = '2' Order By toll_id ASC", "toll_name", "toll_id");
                        function.getListItem(ddlserchToll, "SELECT * FROM tbl_toll WHERE toll_EQGroup = '2' Order By toll_id ASC", "toll_name", "toll_id");
                    }
                    else if(username == "watcharee")
                    {
                        function.getListItem(ddlEditCpoint, "SELECT * FROM tbl_toll WHERE toll_EQGroup = '3'  Order By toll_id ASC", "toll_name", "toll_id");
                        function.getListItem(ddlserchToll, "SELECT * FROM tbl_toll WHERE toll_EQGroup = '3'  Order By toll_id ASC", "toll_name", "toll_id");
                    }
                    else
                    {
                      
                        function.getListItem(ddlEditCpoint, "SELECT * FROM tbl_toll Order By toll_id ASC", "toll_name", "toll_id");
                        function.getListItem(ddlserchToll, "SELECT * FROM tbl_toll Order By toll_id ASC", "toll_name", "toll_id");
                        if(username == "pornwimon")
                        {
                            FileEditEQ.Visible = false;
                            btnUpdateEQ.Visible = false;
                        }
                    }

                    ddlserchToll.Items.Insert(0, new ListItem("ทุกด่าน", "0"));
                }

                ddlsearchStat.Items.Insert(0, new ListItem("ทั้งหมด", "0"));
                PriviledgeID();
            }

        }
        protected void PriviledgeID()
        {
            if(Session["UserCpoint"].ToString() == "0" )
            {
                txtEditTH.Enabled = true;
                txtEditEng.Enabled = true;
                txtEditNo.Enabled = true;
                txtEditNoform.Enabled = true;
                txtEditBrand.Enabled = true;
                txtEditSeries.Enabled = true;
                txtEditPrice.Enabled = true;
                txtEditcUnit.Enabled = true;
                txtEditDate.Enabled = true;
                txtEditContract.Enabled = true;
                ddlEditCpoint.Enabled = true;
                ddlEditCompany.Enabled = true;
            }
        }
        public void BindGridData ()
        {
            string ccount = "";
            string sqlgrid = "SELECT * FROM tbl_equipment d " 
                            + " JOIN tbl_user ON tbl_user.username = d.user_update"
                            + " JOIN tbl_toll ON tbl_toll.toll_id = d.toll_id"
                            + " JOIN tbl_location ON tbl_location.locate_id = d.locate_id"
                            + " JOIN tbl_equipment_status ON tbl_equipment_status.status_id = d.Estatus_id"
                            + " WHERE d.user_update = '"+Session["User"].ToString()+ "' " 
                            + " AND d.date_update = '"+ todayMain[0] + "-" + todayMain[1] + "-" + (int.Parse(todayMain[2]) + 543).ToString() + "' "
                            + " Order By d.equipment_no +0 ";
            MySqlDataAdapter da = function.MySqlSelectDataSet(sqlgrid);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            GridEquipAdd.DataSource = ds.Tables[0];
            ccount = (ds.Tables[0].Rows.Count).ToString();
            titlegrid.Text = "รายการที่เพิ่ม/แก้ไขสำเร็จวันนี้ " + ccount +" รายการ";
            titlegrid.Visible = true;
            lbtnTollReport.Visible = true;
            GridEquipAdd.DataBind();
            if (Session["UserCpoint"].ToString() != "0") { lbtnDepartReport.Visible = true; }
        }

        public string UploadEquip()
        {
            String NewFileDocName = "";
             if (FileEditEQ.HasFile)
              {
                  string typeFile = FileEditEQ.FileName.Split('.')[FileEditEQ.FileName.Split('.').Length - 1];
                  if (typeFile == "jpg" || typeFile == "jpeg" || typeFile == "png")
                  {
                      NewFileDocName = "S_" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + FileEditEQ.FileName.Split('.')[0];
                      NewFileDocName = "/equip/Upload/" + function.getMd5Hash(NewFileDocName) + "." + typeFile;
                    FileEditEQ.SaveAs(Server.MapPath(NewFileDocName.ToString()));
                      return NewFileDocName;
                  }
                  else
                  {
                      //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error : แนบรูปภาพล้มเหลว ไฟล์ภาพต้องเป็น *.jpg *.jpeg *.png เท่านั้น')", true);
                      return "typeError";
                  }
              }
              else
              {
                return "";
              }
        }
        public string UploadEquip2()
        {

            int width = 720;
            int height = 480;
            string NewFileDocName = "";
            if(FileEditEQ.HasFile)
            {
                if (FileEditEQ.PostedFile != null)
                {
                    string typeFile = FileEditEQ.FileName.Split('.')[FileEditEQ.FileName.Split('.').Length - 1];
                    if (typeFile == "jpg" || typeFile == "jpeg" || typeFile == "png")
                    {
                        NewFileDocName = "S_" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + FileEditEQ.FileName.Split('.')[0];
                        NewFileDocName = "/equip/Upload/" + function.getMd5Hash(NewFileDocName) + "." + typeFile;

                        Stream stream = FileEditEQ.PostedFile.InputStream;

                        Bitmap image = new Bitmap(stream);
                        Bitmap target = new Bitmap(width, height);

                        Graphics graphic = Graphics.FromImage(target);

                        graphic.DrawImage(image, 0, 0, width, height);
                        target.Save(Server.MapPath(NewFileDocName));
                        return NewFileDocName;
                    }
                    else
                    {
                        return "typeError";
                    }

                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
            
        }
        public bool CheckDuplicate(string num, string serial,string typechk)
        {
            int Numx = 0; int Serix = 0;
            string sqlchkNo = "";
            string sqlchkSe = "";
            if (typechk == "")
            {
                sqlchkNo = "SELECT COUNT(equipment_id) AS amount FROM tbl_equipment WHERE equipment_no = '" + num + "' ";
                sqlchkSe = "SELECT COUNT(equipment_id) AS amut FROM tbl_equipment WHERE equipment_serial = '" + serial + "'";
            }
            else
            {
                sqlchkNo = "SELECT COUNT(equipment_id) AS amount FROM tbl_equipment WHERE equipment_no = '" + num + "' AND equipment_id != '" + typechk + "'";
                sqlchkSe = "SELECT COUNT(equipment_id) AS amut FROM tbl_equipment WHERE equipment_serial = '" + serial + "' AND equipment_id != '" + typechk + "'";
            }
            MySqlDataReader rs = function.MySqlSelect(sqlchkNo);
            if (rs.Read())
            {
                Numx = rs.GetInt32("amount");

                /*   if(Numx != 0 && เปลี่ยนครุภัณฑ์.Text != "")
                   {
                       return false; 
                   }
                   else
                   {
                       MySqlDataReader rd = function.MySqlSelect(sqlchkSe);
                       if (rd.Read())
                       {
                           Serix = rd.GetInt32("amut");
                           if ( Serix != 0 && เปลี่ยนซีเรียล.Text != "") {  return false;  }
                           else { return true;  }
                       }
                       else {  return false; }
                   } */
                return true; //ไว้หลอกคลาสก่อนแก้
            }
            else {  return false; }

            
        }
        protected void GridEquipAdd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton btnEditEquip = (LinkButton)(e.Row.FindControl("btnEditEquip"));
            if (btnEditEquip != null)
            {
                btnEditEquip.CommandName = DataBinder.Eval(e.Row.DataItem, "equipment_id").ToString();

            }
            Label lbnumrowq = (Label)(e.Row.FindControl("lbnumrowq"));
            if (lbnumrowq != null)
            {
                lbnumrowq.Text = (GridEquipAdd.Rows.Count + 1).ToString() + ".";
            }
        }

        protected void btnEditEquip_Command(object sender, CommandEventArgs e)
        {
            EditModal = e.CommandName;
            pkeq.Text = EditModal;
            string sqlEdit = "SELECT * FROM tbl_equipment d "
                            + " JOIN tbl_toll ON tbl_toll.toll_id = d.toll_id"
                            + " JOIN tbl_location ON tbl_location.locate_id = d.locate_id "
                            + " JOIN tbl_equipment_status ON tbl_equipment_status.status_id = d.Estatus_id"
                            + " WHERE d.equipment_id ='"+ pkeq.Text+"' ";
            MySqlDataReader rttt = function.MySqlSelect(sqlEdit);
            if (rttt.Read())
            {
                ddlEditCompany.SelectedValue = rttt.GetString("company_id");
                ddlEditLocate.SelectedValue = rttt.GetString("locate_id");
                ddlEditStat.SelectedValue = rttt.GetString("Estatus_id");
                ddlEditCpoint.SelectedValue = rttt.GetString("toll_id");
                string imgg = rttt.GetString("equipment_img");
                if(rttt.GetString("person_name") != "")
                {
                    txtEditPerson.Text = rttt.GetString("person_name");
                }
                if(rttt.GetString("equip_comment") != "")
                {
                    txtEditNote.Text = rttt.GetString("equip_comment");
                }
                else
                {
                    txtEditNote.Text = "-";
                }
                ImgEditEQ.ImageUrl = "~"+imgg;
                txtEditcUnit.Text = rttt.GetString("equipment_unit");
                txtEditContract.Text = rttt.GetString("equipment_contract_no");
                try
                {
                    txtEditTH.Text = rttt.GetString("equipment_nameth");
                    txtEditEng.Text = rttt.GetString("equipment_name");
                    txtEditNo.Text = rttt.GetString("equipment_no");
                    lbEQIDModal.Text = rttt.GetString("equipment_no");
                    txtEditNoform.Text = rttt.GetString("equipment_serial");
                    txtEditBrand.Text = rttt.GetString("equipment_brand");
                    txtEditSeries.Text = rttt.GetString("equipment_series");
                    txtEditDate.Text = rttt.GetString("equipment_buy_date");
                    txtEditPrice.Text = rttt.GetString("equipment_price_unit");
                    
                    
                    
                }
                catch { }
                    
                
            }
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
        protected void searchEquip_Click(object sender, EventArgs e)
        {
            divSagain.Visible = true;
            divsearch.Visible = false;
            string statt = ddlsearchStat.SelectedValue;
            string Snameth = txtsearchth.Text; string SNum = txtsearchNum.Text; string SToll = ddlserchToll.SelectedValue; string txtTollz = ddlserchToll.SelectedItem.ToString();
            string Ssql = "SELECT * FROM tbl_equipment d "
                            + " JOIN tbl_user ON tbl_user.username = d.user_update"
                            + " JOIN tbl_toll ON tbl_toll.toll_id = d.toll_id"
                            + " JOIN tbl_location ON tbl_location.locate_id = d.locate_id"
                            + " JOIN tbl_equipment_status ON tbl_equipment_status.status_id = d.Estatus_id ";

            string SsqlReport = "SELECT equipment_nameth AS Enameth,equipment_no AS Enumber,equipment_serial AS Eserial," +
                                 " equipment_brand AS Ebrand,equipment_series AS Eseries,locate_name AS Elocate," +
                                 " toll_name AS Etoll,status_name AS Estatus,equip_comment AS Enote," +
                                 " equipment_img AS Epic FROM tbl_equipment d" +
                                 " JOIN tbl_toll ON tbl_toll.toll_id = d.toll_id" +
                                 " JOIN tbl_location ON tbl_location.locate_id = d.locate_id" +
                                 " JOIN tbl_equipment_status ON tbl_equipment_status.status_id = d.Estatus_id ";
            


            if (SToll == "0") //ค้นทุกด่านฯ
            {
                if (Snameth != "") 
                {
                    if (SNum != "")//มีชื่อ+มีเลข+ทุกด่าน
                    {
                        if(statt != "0")
                        {
                            Ssql += " WHERE d.equipment_nameth LIKE '%" + Snameth + "%' " +
                                "AND d.equipment_no LIKE '%" + SNum + "%' AND Estatus_id = '"+statt;
                            SsqlReport += " WHERE d.equipment_nameth LIKE '%" + Snameth + "%' " +
                                "AND d.equipment_no LIKE '%" + SNum + "%' AND Estatus_id = '" + statt;

                            if (txtsearchSerial.Text != "")
                            {
                                Ssql += " AND d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                                SsqlReport += " AND d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                            }

                            if (Session["User"].ToString() == "sawitree")
                            {
                                Ssql += " AND tbl_toll.user_depart = 'sawitree' Order by d.toll_id ASC,d.equipment_no ";
                                SsqlReport += " AND tbl_toll.user_depart = 'sawitree' Order by d.toll_id ASC,d.equipment_no ";
                            }
                            else if(Session["User"].ToString() == "supaporn")
                            {
                                Ssql += " AND tbl_toll.user_depart = 'supaporn' Order by d.toll_id ASC,d.equipment_no ";
                                SsqlReport += " AND tbl_toll.user_depart = 'supaporn' Order by d.toll_id ASC,d.equipment_no ";
                            }
                            else if(Session["User"].ToString() == "watcharee")
                            {
                                Ssql += "AND tbl_toll.user_depart = 'watcharee'  Order by d.toll_id ASC,d.equipment_no  ";
                                SsqlReport += "AND tbl_toll.user_depart = 'watcharee'  Order by d.toll_id ASC,d.equipment_no  ";
                            }
                            else
                            {
                                Ssql += " Order by d.toll_id ASC,d.equipment_no";
                                SsqlReport += " Order by d.toll_id ASC,d.equipment_no";
                            }

                            Session["SQLEQq"] = Ssql;
                            Session["sqlreEQ"] = SsqlReport;
                            SearchBind(); 
                        }
                        else
                        {
                            Ssql += " WHERE d.equipment_nameth LIKE '%" + Snameth + "%' AND d.equipment_no LIKE '%" + SNum + "%' ";
                            SsqlReport += " WHERE d.equipment_nameth LIKE '%" + Snameth + "%' AND d.equipment_no LIKE '%" + SNum + "%'  ";

                            if (txtsearchSerial.Text != "")
                            {
                                Ssql += " AND d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                                SsqlReport += " AND d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                            }

                            if (Session["User"].ToString() == "sawitree")
                            {
                                Ssql += " AND tbl_toll.user_depart = 'sawitree' Order by d.toll_id ASC,d.equipment_no ";
                                SsqlReport += " AND tbl_toll.user_depart = 'sawitree' Order by d.toll_id ASC,d.equipment_no ";
                            }
                            else if (Session["User"].ToString() == "supaporn")
                            {
                                Ssql += " AND tbl_toll.user_depart = 'supaporn' Order by d.toll_id ASC,d.equipment_no ";
                                SsqlReport += " AND tbl_toll.user_depart = 'supaporn' Order by d.toll_id ASC,d.equipment_no ";
                            }
                            else if (Session["User"].ToString() == "watcharee")
                            {
                                Ssql += "AND tbl_toll.user_depart = 'watcharee'  Order by d.toll_id ASC,d.equipment_no  ";
                                SsqlReport += "AND tbl_toll.user_depart = 'watcharee'  Order by d.toll_id ASC,d.equipment_no  ";
                            }
                            else
                            {
                                Ssql += " Order by d.toll_id ASC,d.equipment_no";
                                SsqlReport += " Order by d.toll_id ASC,d.equipment_no";
                            }

                            Session["SQLEQ"] = Ssql.ToString();
                            Session["sqlreEQ"] = SsqlReport;
                            SearchBind();
                        }
                        
                    }
                    else
                    {
                        if(statt != "0")
                        {
                            Ssql += " WHERE d.equipment_nameth LIKE '%" + Snameth + "%' AND Estatus_id = '" + statt + "'   ";
                            SsqlReport += " WHERE d.equipment_nameth LIKE '%" + Snameth + "%' AND Estatus_id = '" + statt + "'   ";
                            if (txtsearchSerial.Text != "")
                            {
                                Ssql += " AND d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                                SsqlReport += " AND d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                            }

                            if (Session["User"].ToString() == "sawitree")
                            {
                                Ssql += " AND tbl_toll.user_depart = 'sawitree' Order by d.toll_id ASC,d.equipment_no ";
                                SsqlReport += " AND tbl_toll.user_depart = 'sawitree'' Order by d.toll_id ASC,d.equipment_no ";
                            }
                            else if (Session["User"].ToString() == "supaporn")
                            {
                                Ssql += " AND tbl_toll.user_depart = 'supaporn' Order by d.toll_id ASC,d.equipment_no ";
                                SsqlReport += " AND tbl_toll.user_depart = 'supaporn' Order by d.toll_id ASC,d.equipment_no ";
                            }
                            else if (Session["User"].ToString() == "watcharee")
                            {
                                Ssql += "AND tbl_toll.user_depart = 'watcharee'  Order by d.toll_id ASC,d.equipment_no  ";
                                SsqlReport += "AND tbl_toll.user_depart = 'watcharee'  Order by d.toll_id ASC,d.equipment_no  ";
                            }
                            else
                            {
                                Ssql += " Order by d.toll_id ASC,d.equipment_no";
                                SsqlReport += " Order by d.toll_id ASC,d.equipment_no";
                            }

                            Session["SQLEQ"] = Ssql.ToString();
                            Session["sqlreEQ"] = SsqlReport;
                            SearchBind();
                        }
                        else
                        {
                            Ssql += " WHERE d.equipment_nameth LIKE '%" + Snameth + "%'   ";
                            SsqlReport += " WHERE d.equipment_nameth LIKE '%" + Snameth + "%'   ";
                            if (txtsearchSerial.Text != "")
                            {
                                Ssql += " AND d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                                SsqlReport += " AND d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                            }


                            if (Session["User"].ToString() == "sawitree")
                            {
                                Ssql += " AND tbl_toll.user_depart = 'sawitree' Order by d.toll_id ASC,d.equipment_no ";
                                SsqlReport += " AND tbl_toll.user_depart = 'sawitree' Order by d.toll_id ASC,d.equipment_no ";
                            }
                            else if (Session["User"].ToString() == "supaporn")
                            {
                                Ssql += " AND tbl_toll.user_depart = 'supaporn' Order by d.toll_id ASC,d.equipment_no ";
                                SsqlReport += " AND tbl_toll.user_depart = 'supaporn'' Order by d.toll_id ASC,d.equipment_no ";
                            }
                            else if (Session["User"].ToString() == "watcharee")
                            {
                                Ssql += "AND tbl_toll.user_depart = 'watcharee'  Order by d.toll_id ASC,d.equipment_no  ";
                                SsqlReport += "AND tbl_toll.user_depart = 'watcharee'  Order by d.toll_id ASC,d.equipment_no  ";
                            }
                            else
                            {
                                Ssql += " Order by d.toll_id ASC,d.equipment_no";
                                SsqlReport += " Order by d.toll_id ASC,d.equipment_no";
                            }


                            Session["SQLEQ"] = Ssql.ToString();
                            Session["sqlreEQ"] = SsqlReport;
                            SearchBind();
                        }
                        
                    }
                }
                else
                {
                    if (SNum != "") //มีเลข+ทุกด่านฯ
                    {
                        if(statt != "0")
                        {
                            Ssql += " WHERE  d.equipment_no LIKE '%" + SNum + "%' AND Estatus_id = '" + statt + "'   ";
                            SsqlReport += " WHERE  d.equipment_no LIKE '%" + SNum + "%' AND Estatus_id = '" + statt + "'  ";

                            if (txtsearchSerial.Text != "")
                            {
                                Ssql += " AND d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                                SsqlReport += " AND d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                            }

                            if (Session["User"].ToString() == "sawitree")
                            {
                                Ssql += " AND tbl_toll.user_depart = 'sawitree' Order by d.toll_id ASC,d.equipment_no ";
                                SsqlReport += " AND tbl_toll.user_depart = 'sawitree' Order by d.toll_id ASC,d.equipment_no ";
                            }
                            else if (Session["User"].ToString() == "supaporn")
                            {
                                Ssql += " AND tbl_toll.user_depart = 'supaporn' Order by d.toll_id ASC,d.equipment_no ";
                                SsqlReport += " AND tbl_toll.user_depart = 'supaporn' Order by d.toll_id ASC,d.equipment_no ";
                            }
                            else if (Session["User"].ToString() == "watcharee")
                            {
                                Ssql += "AND tbl_toll.user_depart = 'watcharee'  Order by d.toll_id ASC,d.equipment_no  ";
                                SsqlReport += "AND tbl_toll.user_depart = 'watcharee'  Order by d.toll_id ASC,d.equipment_no  ";
                            }
                            else
                            {
                                Ssql += " Order by d.toll_id ASC,d.equipment_no";
                                SsqlReport += " Order by d.toll_id ASC,d.equipment_no";
                            }



                            Session["SQLEQ"] = Ssql.ToString();
                            Session["sqlreEQ"] = SsqlReport;
                            SearchBind();

                        }
                        else
                        {
                            Ssql += " WHERE  d.equipment_no LIKE '%" + SNum + "%'  ";
                            SsqlReport += " WHERE  d.equipment_no LIKE '%" + SNum + "%'  ";

                            if (txtsearchSerial.Text != "")
                            {
                                Ssql += " AND d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                                SsqlReport += " AND d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                            }

                            if (Session["User"].ToString() == "sawitree")
                            {
                                Ssql += " AND tbl_toll.user_depart = 'sawitree' Order by d.toll_id ASC,d.equipment_no ";
                                SsqlReport += " AND tbl_toll.user_depart = 'sawitree' Order by d.toll_id ASC,d.equipment_no ";
                            }
                            else if (Session["User"].ToString() == "supaporn")
                            {
                                Ssql += " AND tbl_toll.user_depart = 'supaporn' Order by d.toll_id ASC,d.equipment_no ";
                                SsqlReport += " AND tbl_toll.user_depart = 'supaporn' Order by d.toll_id ASC,d.equipment_no ";
                            }
                            else if (Session["User"].ToString() == "watcharee")
                            {
                                Ssql += "AND tbl_toll.user_depart = 'watcharee'  Order by d.toll_id ASC,d.equipment_no  ";
                                SsqlReport += "AND tbl_toll.user_depart = 'watcharee'  Order by d.toll_id ASC,d.equipment_no  ";
                            }
                            else
                            {
                                Ssql += " Order by d.toll_id ASC,d.equipment_no";
                                SsqlReport += " Order by d.toll_id ASC,d.equipment_no";
                            }
                            Session["SQLEQ"] = Ssql.ToString();
                            Session["sqlreEQ"] = SsqlReport;
                            SearchBind();
                        }
                        
                    }
                    else
                    {
                        if (statt != "0")
                        {

                            AlertPop("กรอกข้อมูลค้นหาอย่างน้อย 1 ประเภท !!!", "error");

                        }
                        else if(txtsearchSerial.Text != "")
                        {
                            Ssql += " WHERE  d.equipment_no LIKE '%" + SNum + "%'  ";
                            SsqlReport += " WHERE  d.equipment_no LIKE '%" + SNum + "%'  ";

                            if (txtsearchSerial.Text != "")
                            {
                                Ssql += " AND d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                                SsqlReport += " AND d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                            }

                            if (Session["User"].ToString() == "sawitree")
                            {
                                Ssql += " AND tbl_toll.user_depart = 'sawitree' Order by d.toll_id ASC,d.equipment_no ";
                                SsqlReport += " AND tbl_toll.user_depart = 'sawitree' Order by d.toll_id ASC,d.equipment_no ";
                            }
                            else if (Session["User"].ToString() == "supaporn")
                            {
                                Ssql += " AND tbl_toll.user_depart = 'supaporn' Order by d.toll_id ASC,d.equipment_no ";
                                SsqlReport += " AND tbl_toll.user_depart = 'supaporn' Order by d.toll_id ASC,d.equipment_no ";
                            }
                            else if (Session["User"].ToString() == "watcharee")
                            {
                                Ssql += "AND tbl_toll.user_depart = 'watcharee'  Order by d.toll_id ASC,d.equipment_no  ";
                                SsqlReport += "AND tbl_toll.user_depart = 'watcharee'  Order by d.toll_id ASC,d.equipment_no  ";
                            }
                            else
                            {
                                Ssql += " Order by d.toll_id ASC,d.equipment_no";
                                SsqlReport += " Order by d.toll_id ASC,d.equipment_no";
                            }

                            Session["SQLEQ"] = Ssql.ToString();
                            Session["sqlreEQ"] = SsqlReport;
                            SearchBind();

                        }
                        else
                        {
                            AlertPop("กรุณากรอกข้อมูลค้นหาอย่างน้อย 1 ประเภท !!!","error");
                        }

                    }
                }
            }
            else //เลือกด่านฯ
            {
                if (Snameth != "")
                {
                    if (SNum != "")  //มีชื่อ+มีเลข+มีด่านฯ
                    {
                        if(statt != "0")
                        {
                            if (txtsearchSerial.Text != "")
                            {
                                Ssql += " WHERE d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                                SsqlReport += " WHERE d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                            }

                            Ssql += " AND d.equipment_nameth LIKE '%" + Snameth + "%' " +
                                "AND d.equipment_no LIKE '%" + SNum + "%' AND d.toll_id='" + SToll + "' AND Estatus_id = '" + statt + "' Order by d.equipment_no ASC ";
                            SsqlReport += " AND d.equipment_nameth LIKE '%" + Snameth + "%' " +
                                "AND d.equipment_no LIKE '%" + SNum + "%' AND d.toll_id='" + SToll + "' AND Estatus_id = '" + statt + "' Order by d.equipment_no ASC ";

                            Session["SQLEQ"] = Ssql.ToString();
                            Session["sqlreEQ"] = SsqlReport;
                            SearchBind();
                        }
                        else
                        {
                            if (txtsearchSerial.Text != "")
                            {
                                Ssql += " WHERE d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                                SsqlReport += " WHERE d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                            }
                            Ssql += " AND d.equipment_nameth LIKE '%" + Snameth + "%' AND d.equipment_no LIKE '%" + SNum + "%' AND d.toll_id='" + SToll + "' Order by d.equipment_no ASC ";
                            SsqlReport += " AND d.equipment_nameth LIKE '%" + Snameth + "%' AND d.equipment_no LIKE '%" + SNum + "%' AND d.toll_id='" + SToll + "' Order by d.equipment_no ASC ";
                            Session["SQLEQ"] = Ssql.ToString();
                            Session["sqlreEQ"] = SsqlReport;
                            SearchBind();
                        }
                        
                    }
                    else //มีชื่อ+มีด่าน
                    {
                        if(statt != "0")
                        {
                            if (txtsearchSerial.Text != "")
                            {
                                Ssql += " WHERE d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                                SsqlReport += " WHERE d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                            }
                            Ssql += " AND d.equipment_nameth LIKE '%" + Snameth + "%' AND d.toll_id='" + SToll + "' AND Estatus_id = '" + statt + "' Order by d.equipment_no ASC ";
                            SsqlReport += " AND d.equipment_nameth LIKE '%" + Snameth + "%' AND d.toll_id='" + SToll + "' AND Estatus_id = '" + statt + "' Order by d.equipment_no ASC ";
                            Session["SQLEQ"] = Ssql.ToString();
                            Session["sqlreEQ"] = SsqlReport;
                            SearchBind();
                        }
                        else
                        {
                            if (txtsearchSerial.Text != "")
                            {
                                Ssql += " WHERE d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                                SsqlReport += " WHERE d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                            }
                            Ssql += " AND d.equipment_nameth LIKE '%" + Snameth + "%' AND d.toll_id='" + SToll + "' Order by d.equipment_no ASC ";
                            SsqlReport += " AND d.equipment_nameth LIKE '%" + Snameth + "%' AND d.toll_id='" + SToll + "' Order by d.equipment_no ASC ";
                            Session["SQLEQ"] = Ssql.ToString();
                            Session["sqlreEQ"] = SsqlReport;
                            SearchBind();
                        }
                        
                    }
                }
                else
                {
                    if (SNum != "") //มีเลข+มีด่าน
                    {
                        if(statt != "0")
                        {
                            if (txtsearchSerial.Text != "")
                            {
                                Ssql += " WHERE d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                                SsqlReport += " WHERE d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                            }
                            Ssql += " AND  d.equipment_no LIKE '%" + SNum + "%' AND d.toll_id='" + SToll + "' AND Estatus_id = '" + statt + "' Order by d.equipment_no ASC ";
                            SsqlReport += " AND  d.equipment_no LIKE '%" + SNum + "%' AND d.toll_id='" + SToll + "' AND Estatus_id = '" + statt + "' Order by d.equipment_no ASC ";
                            Session["SQLEQ"] = Ssql.ToString();
                            Session["sqlreEQ"] = SsqlReport;
                            SearchBind();
                        }
                        else
                        {
                            if (txtsearchSerial.Text != "")
                            {
                                Ssql += " WHERE d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                                SsqlReport += " WHERE d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                            }
                            Ssql += " AND  d.equipment_no LIKE '%" + SNum + "%' AND d.toll_id='" + SToll + "' Order by d.equipment_no ASC ";
                            SsqlReport += " AND  d.equipment_no LIKE '%" + SNum + "%' AND d.toll_id='" + SToll + "' Order by d.equipment_no ASC ";
                            Session["SQLEQ"] = Ssql.ToString();
                            Session["sqlreEQ"] = SsqlReport;
                            SearchBind();
                        }
                        
                    }
                    else   //มีแต่ด่าน
                    {
                        if(statt != "0")
                        {
                            if (txtsearchSerial.Text != "")
                            {
                                Ssql += " WHERE d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                                SsqlReport += " WHERE d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                            }
                            Ssql += " AND  d.toll_id = '" + SToll + "' AND Estatus_id = '" + statt + "' Order by d.equipment_no ASC ";
                            SsqlReport += " AND  d.toll_id = '" + SToll + "' AND Estatus_id = '" + statt + "' Order by d.equipment_no ASC ";
                            Session["SQLEQ"] = Ssql.ToString();
                            Session["sqlreEQ"] = SsqlReport;
                            SearchBind();
                        }
                        else
                        {
                            if (txtsearchSerial.Text != "")
                            {
                                Ssql += " WHERE d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                                SsqlReport += " WHERE d.equipment_serial LIKE '%" + txtsearchSerial.Text + "%' ";
                            }

                            Ssql += " AND  d.toll_id = '" + SToll + "' Order by d.equipment_no ASC ";
                            SsqlReport += " AND  d.toll_id = '" + SToll + "' Order by d.equipment_no ASC ";
                            Session["SQLEQ"] = Ssql.ToString();
                            Session["sqlreEQ"] = SsqlReport;
                            SearchBind();
                        }
                        
                    }
                }
            }



        }


        public void SearchBind()
        {
            string ccount = "";
            string Snameth = txtsearchth.Text; string SNum = txtsearchNum.Text; string txtTollz = ddlserchToll.SelectedItem.ToString();
            string qqq = Session["SQLEQ"].ToString();
            MySqlDataAdapter da = function.MySqlSelectDataSet(qqq);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            GridEquipAdd.DataSource = ds.Tables[0];
            ccount = (ds.Tables[0].Rows.Count).ToString();
            titlegrid.Text = "ผลการค้นหา ( ชื่อครุภัณฑ์: " + Snameth + " | เลขครุภัณฑ์: " + SNum + " | ด่านฯ: " + txtTollz + "  ) พบ " + ccount + " รายการ";
            titlegrid.Visible = true;
            
            GridEquipAdd.DataBind();
            if (Session["UserCpoint"].ToString() == "0"){ lbtnDepartReport.Visible = true; }
            else { lbtnTollReport.Visible = true; }
        }
        protected void btnSagain_Click(object sender, EventArgs e)
        {
            Session["SQLEQ"] = "";
            Response.Redirect("/equip/EquipAdd.aspx");
        }

        protected void btnUpdateEQ_Command(object sender, CommandEventArgs e)
        {
            string picResult = UploadEquip2();
            string TimeNoww = DateTime.Now.ToString("HH:mm");
            string DateNoww = DateTime.Now.ToString("dd-MM") + "-" + (DateTime.Now.Year + 543);
            string updateEqSQL = "UPDATE tbl_equipment SET equipment_name='" + txtEditEng.Text + "', equipment_nameth = '" + txtEditTH.Text + "'," +
                                " equipment_no = '" + txtEditNo.Text + "', equipment_serial = '" + txtEditNoform.Text + "'," +
                                " equipment_brand = '" + txtEditBrand.Text + "', equipment_series='" + txtEditSeries.Text + "'," +
                                " equipment_buy_date='" + txtEditDate.Text + "', equipment_price_unit='" + txtEditPrice.Text + "'," +
                                " equipment_contract_no='" + txtEditContract.Text + "', toll_id='" + ddlEditCpoint.SelectedValue + "'," +
                                " Estatus_id='" + ddlEditStat.SelectedValue + "',company_id='" + ddlEditCompany.SelectedValue + "'," +
                                " locate_id='" + ddlEditLocate.SelectedValue + "', equip_comment='" + txtEditNote.Text + "'," +
                                " person_name='" + txtEditPerson.Text + "', equipment_unit = '" + txtEditcUnit.Text + "', " +
                                " user_update = '" + Session["User"].ToString() +"',time_update='"+TimeNoww+"',date_update='"+DateNoww+"' ";
            
            if(picResult == "typeError")
            {
                ResultPop("แนบรูปภาพล้มเหลว!! ไฟล์ภาพต้องเป็น *.jpg *.jpeg *.png เท่านั้น", "error");
            }
            else if(txtEditNo.Text == "")
            {
                ResultPop("กรุณาใส่เลขครุภัณฑ์!!", "error");
            }
            else 
            {
                if(picResult == "")
                {
                    updateEqSQL += " WHERE equipment_id='" + pkeq.Text + "' ";
                }
                else { updateEqSQL += " ,equipment_img='"+picResult+"' WHERE equipment_id='" + pkeq.Text + "' "; }

                string tORf = CheckDupli(txtEditNo.Text, txtEditNoform.Text, pkeq.Text);

                if (tORf == "1")
                {
                    ResultPop("Error : เลขครุภัณฑ์/Serial ซ้ำในระบบ", "error");
                }
                else if(tORf == "2")
                {
                    ResultPop("Error : การแก้ไขล้มเหลวกรุณาติดต่อเจ้าหน้าที่", "error");
                }
                else
                {
                    if (function.MySqlQuery(updateEqSQL))
                    {
                        ResultPop("อัพเดทข้อมูลสำเร็จเรียบร้อย", "success");
                        SearchBind();
                    }
                }

            }

            
            
            

        }
        protected string CheckDupli (string noEQ,string SerialEQ,string pkEQ)
        {
            int resultNN;
            int resultSS;
            string chkNoEQ = "select COUNT(equipment_id) AS NNN FROM tbl_equipment WHERE equipment_no = '" + noEQ+ "'" +
                "  AND equipment_id != '" + pkEQ +"' ";
            string chkSeEQ = "select COUNT(equipment_id) AS SSS FROM tbl_equipment WHERE equipment_serial = '"+SerialEQ+"'" +
                "  AND equipment_id != '" + pkEQ + "' ";
            
            if((noEQ == "" && SerialEQ == "") ||( noEQ == "-" && SerialEQ == "-"))
            {
                return "0";
            }
            else 
            {
                if(noEQ != "-" && SerialEQ != "-")
                {
                    MySqlDataReader nn = function.MySqlSelect(chkNoEQ);
                    MySqlDataReader ss = function.MySqlSelect(chkSeEQ);
                    if (nn.Read() && ss.Read())
                    {
                        
                        resultNN = nn.GetInt32("NNN");
                        resultSS = ss.GetInt32("SSS");
                        if (resultNN != 0 || resultSS != 0)
                        {
                            return "1";
                        }
                        else { return "0"; }
                    }
                    else
                    {
                        return "2";
                    }
                }
                else if(noEQ == "-" && SerialEQ != "-")
                {
                    MySqlDataReader ss = function.MySqlSelect(chkSeEQ);
                    if (ss.Read())
                    {
                        resultSS = ss.GetInt32("SSS");
                        if (resultSS != 0 )
                        {
                            return "1";
                        }
                        else { return "0"; }
                    }
                    else
                    {
                        return "2";
                    }
                }
                else 
                {
                    MySqlDataReader nn = function.MySqlSelect(chkNoEQ);
                    if (nn.Read())
                    {
                        resultNN = nn.GetInt32("NNN");
                        if (resultNN != 0)
                        {
                            return "1";
                        }
                        else { return "0"; }
                    }
                    else
                    {
                        return "2";
                    }
                }
            }


      /*      if (nn.Read())
            {
                resultNN = nn.GetInt32("NNN");
                resultSS = ss.GetInt32("SSS");
                if (resultNN != 0)
                {
                    return "1";
                }
                else { return "0"; }
            }
            else
            {
                return "1";
            }
            */
        }
        public void ResultPop(string msg, string type)
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
        protected void lbtnAddNewEQ_Command(object sender, CommandEventArgs e)
        {
          /*  string NewFileDocName = "";
            string ImgStr = ""; 
            if (AddFileUpload.HasFile)
            {
                string typeFile = AddFileUpload.FileName.Split('.')[AddFileUpload.FileName.Split('.').Length - 1];
                if (typeFile == "jpg" || typeFile == "jpeg" || typeFile == "png")
                {
                    NewFileDocName = "S_" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + AddFileUpload.FileName.Split('.')[0];
                    NewFileDocName = "/equip/Upload/" + function.getMd5Hash(NewFileDocName) + "." + typeFile;
                    AddFileUpload.SaveAs(Server.MapPath(NewFileDocName.ToString()));
                    ImgStr = NewFileDocName;
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error : แนบรูปภาพล้มเหลว ไฟล์ภาพต้องเป็น *.jpg *.jpeg *.png เท่านั้น')", true);
                }
            }
            else
            {
                ImgStr = "-";
            }
            */

        }

        

        protected void lbtnTollReport_Command(object sender, CommandEventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            string tolltitle = ddlserchToll.SelectedItem.ToString();
            string describe = titlegrid.Text.Remove(0, 10);

            Session["tolleq"] = tolltitle;
            Session["describe"] = describe;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('/equip/EquipReportPage','_newtab');", true);
        }

        protected void lbtnDepartReport_Command(object sender, CommandEventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            string tolltitle = ddlserchToll.SelectedItem.ToString();
            string describe = titlegrid.Text.Remove(0,10);

            Session["tolleq"] = tolltitle;
            Session["describe"] = describe;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('/equip/EquipReportPage','_newtab');", true);
        }

        protected void btnBackHomeADDEQ_Click(object sender, EventArgs e)
        {
            Response.Redirect("/equip/EquipMain.aspx");
        }
    }
}