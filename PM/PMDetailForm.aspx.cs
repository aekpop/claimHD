using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClaimProject.Config;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ClaimProject.PM
{
    public partial class PMDetailForm : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        int imageValue = 0;
        public string alertType = "";
        public string icon = "";
        public string alert = "";
        public string pkk = "";
        public string[] locatedtt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["codePKPM"] == null)
            {
                Response.Redirect("/");
            }
            if (!this.IsPostBack)
            {
                //function.GetList(ddlPosition, "PosList");
                //BindImg();
                if (Session["UserPrivilegeId"].ToString() == "0" || Session["UserPrivilegeId"].ToString() == "1")
                {
                    lbDeRef.Visible = true;
                    ComSubmit.Visible = false;
                }
                else
                {
                    //ImgPM.Enabled = false;
                    btnAddImagePM.Enabled = false;
                    PMImageGridView.Enabled = false;
                    ComSubmit.Visible = true;
                }
                PageLoadData();
                VisibleButton();
                BindImg();
                ColorOfButton("1");
            }
        }
        public void VisibleButton()
        {
            string chkPMStat = "select * FROM tbl_pm_detail WHERE pm_ref_no = '" + Session["codePKPM"].ToString() + "'";
            MySqlDataReader ss = function.MySqlSelect(chkPMStat);
            if (ss.Read())
            {
                string xx = ss.GetString("pm_status_id");
                if (xx == "2")
                {
                    lbstatNow.Text = "..สถานะรายการ PM : รอตรวจสอบ..";
                    lbstatNow.BackColor = System.Drawing.Color.DeepSkyBlue;
                    lbstatNow.ForeColor = System.Drawing.Color.White;
                    if (Session["UserPrivilegeId"].ToString() == "0" || Session["UserPrivilegeId"].ToString() == "1")
                    {
                        AdminCheck.Visible = true;
                    }
                }
                else if (xx == "3" )
                {
                    lbstatNow.Text = "..สถานะรายการ PM : อยู่ระหว่างส่งใบเซอร์วิส..";
                    lbstatNow.BackColor = System.Drawing.Color.Yellow;
                    lbstatNow.ForeColor = System.Drawing.Color.Black;
                    ComSubmit.Visible = false;
                    AdminCheck.Visible = false;
                    btnSavelocate.Visible = false;
                    if (Session["UserPrivilegeId"].ToString() == "0" || Session["UserPrivilegeId"].ToString() == "1")
                    {
                        AdComplete.Visible = true;

                    }

                }
                else if (xx == "4")
                {
                    lbstatNow.Text = "..สถานะรายการ PM : รายการ PM เสร็จสมบูรณ์..";
                    lbstatNow.BackColor = System.Drawing.Color.ForestGreen;
                    lbstatNow.ForeColor = System.Drawing.Color.White;
                    ComSubmit.Visible = false;
                    AdminCheck.Visible = false;
                    AdComplete.Visible = false;
                    btnSavelocate.Visible = false;
                }
                else
                {
                    lbstatNow.Text = "..สถานะรายการ PM : แจ้งรายการ PM ใหม่..";
                    lbstatNow.BackColor = System.Drawing.Color.LightPink;
                    lbstatNow.ForeColor = System.Drawing.Color.Black;
                }
            }
        }
        public void ColorOfButton(string kkk)
        {
            string ssqqll;
            string rayLocate = "";
            
                for (int i = 1; i < 60; i++)
                {
                    ssqqll = "  SELECT COUNT(d.equipment_id) AS num FROM tbl_equipment_action e "
                          + " JOIN tbl_equipment d ON d.equipment_id = e.equip_id "
                          + " WHERE d.locate_id = '" + i.ToString() + "' AND e.pm_ref_no = '" + Session["codePKPM"].ToString() + "' ";
                    MySqlDataReader ss = function.MySqlSelect(ssqqll);

                    if (ss.Read()) { rayLocate += ss.GetInt32("num").ToString() + "-"; } else { break; }
                }
            
            locatedtt = rayLocate.Split('-');
            if (locatedtt[0] != "")
            {
                DivImg.Visible = true;
                if (locatedtt[0] != "0") { btnEn1.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[1] != "0") { btnEn2.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[2] != "0") { btnEn3.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[3] != "0") { btnEn4.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[4] != "0") { btnEn5.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[5] != "0") { btnEn6.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[6] != "0") { btnEn7.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[7] != "0") { btnEn8.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[8] != "0") { btnEn9.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[9] != "0") { btnEn10.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[10] != "0") { btnEn11.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[11] != "0") { btnEn12.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[12] != "0") { btnEn13.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[13] != "0") { btnEn14.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[14] != "0") { btnEn15.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[15] != "0") { btnEn16.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[16] != "0") { btnEn17.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[17] != "0") { btnEn18.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[18] != "0") { btnEn19.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[19] != "0") { btnEn20.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[20] != "0") { btnEx1.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[21] != "0") { btnEx2.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[22] != "0") { btnEx3.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[23] != "0") { btnEx4.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[24] != "0") { btnEx5.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[25] != "0") { btnEx6.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[26] != "0") { btnEx7.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[27] != "0") { btnEx8.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[28] != "0") { btnEx9.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[29] != "0") { btnEx10.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[30] != "0") { btnEx11.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[31] != "0") { btnEx12.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[32] != "0") { btnEx13.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[33] != "0") { btnEx14.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[34] != "0") { btnEx15.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[35] != "0") { btnEx16.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[36] != "0") { btnEx17.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[37] != "0") { btnEx18.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[38] != "0") { btnEx19.BackColor = System.Drawing.Color.ForestGreen; } if (locatedtt[39] != "0") { btnEx20.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[40] != "0") { btnEx20.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[41] != "0") { btnEx20.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[42] != "0") { btnEx20.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[44] != "0") { btnEx20.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[45] != "0") { btnEx20.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[46] != "0") { btnEx20.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[47] != "0") { btnEx20.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[48] != "0") { btnEx20.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[49] != "0") { btnEx20.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[50] != "0") { btnEx20.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[51] != "0") { btnEx20.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[52] != "0") { btnEx20.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[53] != "0") { btnEx20.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[54] != "0") { btnEx20.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[55] != "0") { btnEx20.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[56] != "0") { btnEx20.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[57] != "0") { btnEx20.BackColor = System.Drawing.Color.ForestGreen; }
                if (locatedtt[58] != "0") { btnEx20.BackColor = System.Drawing.Color.ForestGreen; }


            }

        }

        public void TollVisible(string ddd)
        {
            int IDtoll = int.Parse(ddd);
            if(IDtoll == 7010)
            { btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; 
              btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
              btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7020)
            {
                btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false; btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false;
                btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx9.Visible = false; btnEx10.Visible = false; btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false;
                btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7031)
            {
                btnEn4.Visible = false; btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx5.Visible = false; btnEx6.Visible = false; btnEx7.Visible = false; btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7032)
            {
                btnEn4.Visible = false; btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx4.Visible = false; btnEx5.Visible = false; btnEx6.Visible = false; btnEx7.Visible = false; btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7033)
            {
                btnEn4.Visible = false; btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx5.Visible = false; btnEx6.Visible = false; btnEx7.Visible = false; btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7041)
            {
                btnEn4.Visible = false; btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7042)
            {
                btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx5.Visible = false; btnEx6.Visible = false; btnEx7.Visible = false; btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7051)
            {
                btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7052)
            {
                btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx5.Visible = false; btnEx6.Visible = false; btnEx7.Visible = false; btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7061)
            {
                btnEn1.Visible = false; btnEn2.Visible = false; btnEn3.Visible = false; btnEn4.Visible = false; btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7062)
            {
                btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx1.Visible = false; btnEx2.Visible = false; btnEx3.Visible = false; btnEx4.Visible = false; btnEx5.Visible = false; btnEx6.Visible = false; btnEx7.Visible = false; btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7063)
            {
                btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx1.Visible = false; btnEx2.Visible = false; btnEx3.Visible = false; btnEx4.Visible = false; btnEx5.Visible = false; btnEx6.Visible = false; btnEx7.Visible = false; btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7064)
            {
                btnEn1.Visible = false; btnEn2.Visible = false; btnEn3.Visible = false; btnEn4.Visible = false; btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx10.Visible = false;btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7071)
            {
                btnEn1.Visible = false; btnEn2.Visible = false; btnEn3.Visible = false; btnEn4.Visible = false; btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7072)
            {
                btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx1.Visible = false; btnEx2.Visible = false; btnEx3.Visible = false; btnEx4.Visible = false; btnEx5.Visible = false; btnEx6.Visible = false; btnEx7.Visible = false; btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7073)
            {
                btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx1.Visible = false; btnEx2.Visible = false; btnEx3.Visible = false; btnEx4.Visible = false; btnEx5.Visible = false; btnEx6.Visible = false; btnEx7.Visible = false; btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7074)
            {
                btnEn1.Visible = false; btnEn2.Visible = false; btnEn3.Visible = false; btnEn4.Visible = false; btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx6.Visible = false; btnEx7.Visible = false; btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7075)
            {
                btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx1.Visible = false; btnEx2.Visible = false; btnEx3.Visible = false; btnEx4.Visible = false; btnEx5.Visible = false; btnEx6.Visible = false; btnEx7.Visible = false; btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7076)
            {
                btnEn1.Visible = false; btnEn2.Visible = false; btnEn3.Visible = false; btnEn4.Visible = false; btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx5.Visible = false; btnEx6.Visible = false; btnEx7.Visible = false; btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7081)
            {
                btnEn1.Visible = false; btnEn2.Visible = false; btnEn3.Visible = false; btnEn4.Visible = false; btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx5.Visible = false; btnEx6.Visible = false; btnEx7.Visible = false; btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7082)
            {
                btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx1.Visible = false; btnEx2.Visible = false; btnEx3.Visible = false; btnEx4.Visible = false; btnEx5.Visible = false; btnEx6.Visible = false; btnEx7.Visible = false; btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7083)
            {
                btnEn1.Visible = false; btnEn2.Visible = false; btnEn3.Visible = false; btnEn4.Visible = false; btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx7.Visible = false; btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7084)
            {
                btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx1.Visible = false; btnEx2.Visible = false; btnEx3.Visible = false; btnEx4.Visible = false; btnEx5.Visible = false; btnEx6.Visible = false; btnEx7.Visible = false; btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 7090)
            {
                btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false;
                btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 9010)
            {
                btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx1.Visible = false; btnEx2.Visible = false; btnEx3.Visible = false; btnEx4.Visible = false; btnEx5.Visible = false; btnEx6.Visible = false; btnEx7.Visible = false; btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 9020)
            {
                btnEn1.Visible = false; btnEn2.Visible = false; btnEn3.Visible = false; btnEn4.Visible = false; btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 9030)
            {
                btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx1.Visible = false; btnEx2.Visible = false; btnEx3.Visible = false; btnEx4.Visible = false; btnEx5.Visible = false; btnEx6.Visible = false; btnEx7.Visible = false; btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 9040)
            {
                btnEn1.Visible = false; btnEn2.Visible = false; btnEn3.Visible = false; btnEn4.Visible = false; btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx19.Visible = false; btnEx20.Visible = false;
            }
            else if(IDtoll == 9200)
            {
                btnEn1.Visible = false; btnEn2.Visible = false; btnEn3.Visible = false; btnEn4.Visible = false; btnEn5.Visible = false; btnEn6.Visible = false; btnEn7.Visible = false; btnEn8.Visible = false; btnEn9.Visible = false; btnEn10.Visible = false;
                btnEn11.Visible = false; btnEn12.Visible = false; btnEn13.Visible = false; btnEn14.Visible = false; btnEn15.Visible = false; btnEn16.Visible = false; btnEn17.Visible = false; btnEn18.Visible = false; btnEn19.Visible = false; btnEn20.Visible = false;
                btnEx1.Visible = false; btnEx2.Visible = false; btnEx3.Visible = false; btnEx4.Visible = false; btnEx5.Visible = false; btnEx6.Visible = false; btnEx7.Visible = false; btnEx8.Visible = false; btnEx9.Visible = false; btnEx10.Visible = false;
                btnEx11.Visible = false; btnEx12.Visible = false; btnEx13.Visible = false; btnEx14.Visible = false; btnEx15.Visible = false; btnEx16.Visible = false; btnEx17.Visible = false; btnEx18.Visible = false; btnEx19.Visible = false; btnEx20.Visible = false;
            }
        }
        public void PageLoadData()
        {

           string sqlLoad = " SELECT * FROM tbl_pm_detail "
                        + "  JOIN tbl_pm_status ON tbl_pm_status.pm_status_id = tbl_pm_detail.pm_status_id "
                        + "  JOIN tbl_toll ON tbl_toll.toll_id = tbl_pm_detail.pm_toll_id "
                        + "  JOIN tbl_project ON tbl_project.project_id = tbl_pm_detail.project_id "
                        + "  JOIN tbl_company ON tbl_company.company_id = tbl_pm_detail.pm_company_id "
                        + "  JOIN tbl_user ON tbl_user.username = tbl_pm_detail.pm_who_create "
                        + "  WHERE tbl_pm_detail.pm_ref_no = '"+ Session["codePKPM"].ToString() + "' ";
            MySqlDataReader rs = function.MySqlSelect(sqlLoad);

            if (rs.Read())
            {
                string tollx = rs.GetString("pm_toll_id");
                    TollVisible(tollx);
                    lbTolldd.Text = tollx;
                    lbDeCpoint.Text = rs.GetString("toll_name");
                    lbDeRef.Text = rs.GetString("pm_ref_no");
                    lbproject.Text = rs.GetString("project_name");
                    lbcompany.Text = rs.GetString("company_name");
                    companyII.Text = rs.GetString("pm_company_id");
            }
        }

            void BindImg()
            {
                
                string sql = "SELECT * FROM tbl_ma_img where ref_id = '" + lbDeRef.Text + "' and img_type = '1'";
                MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds);
                PMImageGridView.DataSource = ds.Tables[0];
                PMImageGridView.DataBind();
                lbAmountImg.Text = "แนบภาพสำเร็จ " + ds.Tables[0].Rows.Count + " ภาพ";
                imageValue = ds.Tables[0].Rows.Count;
                checkimagevalues.Text = imageValue.ToString(); 
            }

            void Insert(int type, FileUpload file)
            {
                String NewFileDocName = "";
                if (file.HasFile)
                {
                    string typeFile = file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                    if (typeFile == "jpg" || typeFile == "jpeg" || typeFile == "png")
                    {
                        NewFileDocName = Session["CodePKPM"].ToString() + new Random().Next(1000, 9999);
                        NewFileDocName = "/PM/Upload/" + function.getMd5Hash(NewFileDocName) + "." + typeFile;
                        file.SaveAs(Server.MapPath(NewFileDocName.ToString()));

                        string sql_text = "img_name,ref_id,img_type";
                        string sql_value = "'" + NewFileDocName + "','" + Session["CodePKPM"].ToString() + "','" + type + "'";
                        string sql_insert = "INSERT INTO tbl_ma_img (" + sql_text + ") VALUES (" + sql_value + ")";
                        function.MySqlQuery(sql_insert);
                    BindImg();
                    }
                    else
                    {
                        //AlertPop("Error : แนบรูปภาพล้มเหลว ไฟล์เอกสารต้องเป็น *.jpg *.jpeg *.png เท่านั้น", "error");
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error : แนบรูปภาพล้มเหลว ไฟล์เอกสารต้องเป็น *.jpg *.jpeg *.png เท่านั้น')", true);
                        //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Error : แนบรูปภาพล้มเหลว ไฟล์เอกสารต้องเป็น *.jpg *.jpge *.png เท่านั้น')", true);
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error : แนบรูปภาพล้มเหลวไม่พบไฟล์')", true);
                    //AlertPop("Error : แนบรูปภาพล้มเหลวไม่พบไฟล์", "error");
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Error : แนบรูปภาพล้มเหลวไม่พบไฟล์')", true);
                }
            }


            protected void btnBack_Click(object sender, EventArgs e)
            {
                Response.Redirect("/PM/PMListForm.aspx");
            }

            protected void btnAddImagePM_Click(object sender, EventArgs e)
            {
                Insert(1, ImgPM);
            }

            protected void PMImageGridView_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                Image ImgPM = (Image)(e.Row.FindControl("ImgPM"));
                if (ImgPM != null)
                {
                    ImgPM.ImageUrl = (string)DataBinder.Eval(e.Row.DataItem, "img_name");
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

            protected void PMImageGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
                string partFile = function.GetSelectValue("tbl_ma_img", "MAimg_id='" + PMImageGridView.DataKeys[e.RowIndex].Value + "'", "img_name");

                string sql_delete = "DELETE FROM tbl_ma_img WHERE MAimg_id = '" + PMImageGridView.DataKeys[e.RowIndex].Value + "'";
                if (function.MySqlQuery(sql_delete))
                {
                    if (File.Exists(Server.MapPath(partFile)))
                    {
                        File.Delete(Server.MapPath(partFile));
                    }
                    BindImg();
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
                }
                alert = msg;
            }
            protected void btnChkService_Click(object sender, EventArgs e)
            {

            }

            protected void lbtnDownload_Command(object sender, CommandEventArgs e)
            {
                
            }
        protected void gridviewPM_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            RadioButton rbtOKk = (RadioButton)e.Row.FindControl("rbtOK");
            RadioButton rbtBreakk = (RadioButton)e.Row.FindControl("rbtBreak");
            RadioButton rbtNoPM = (RadioButton)e.Row.FindControl("rbtNoPM");
            Label EqipStat = (Label)e.Row.FindControl("EqipStat");

            if (EqipStat != null)
            {
                if(EqipStat.Text == "0") { rbtNoPM.Checked = true; }
                else if(EqipStat.Text == "1") { rbtOKk.Checked = true; }
                else if(EqipStat.Text == "2") { rbtBreakk.Checked = true; }

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#e3e1e1");
                e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#c9ffc9");
                e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffd6d6");
                e.Row.Cells[7].BackColor = System.Drawing.ColorTranslator.FromHtml("white");
                e.Row.Cells[7].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffe8c9");
                e.Row.Cells[8].BackColor = System.Drawing.ColorTranslator.FromHtml("white");
                e.Row.Cells[8].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffe8c9");
               
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#6b6a6a");
                e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#339e33");
                e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#9c2222");
                e.Row.Cells[7].BackColor = System.Drawing.ColorTranslator.FromHtml("white");
                e.Row.Cells[8].BackColor = System.Drawing.ColorTranslator.FromHtml("white");
                
            }

        }
        public string CheckActionList(string btnlocate)
        {
            return "";
        }

        public void BtnActionList (string locateid)
        {
            lbLocate.Text = locateid;
            int amountt = 0;
            string sqlItem = ""; string[] countCheck;
            string chkHAD = "SELECT COUNT(tbl_equipment_action.action_id) AS amount  "
                            + " FROM tbl_equipment_action"
                            + " JOIN tbl_equipment ON tbl_equipment.equipment_id = tbl_equipment_action.equip_id "
                   + " WHERE pm_ref_no = '"+ Session["codePKPM"].ToString() + "' AND tbl_equipment.toll_id = '"+lbTolldd.Text+"' AND tbl_equipment.locate_id = '"+lbLocate.Text+"' ";
           
            MySqlDataReader red = function.MySqlSelect(chkHAD);
            if (red.Read())
            {
                amountt = red.GetInt32("amount");

            }
            if(amountt == 0)  //gridviewpm2
            {
                gridviewPM.Visible = false; gridviewpm2.Visible = true;
                sqlItem += "SELECT * FROM tbl_equipment " 
                            + " WHERE toll_id = '"+lbTolldd.Text+"' AND locate_id = '"+locateid+ "'" 
                            + " AND company_id = '"+companyII.Text+"'  " 
                            + " ORDER BY equipment_id ASC ";
                MySqlDataAdapter da = function.MySqlSelectDataSet(sqlItem);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds);
                gridviewpm2.DataSource = ds.Tables[0];
                gridviewpm2.DataBind();
                
                countCheck = CountRadio("2").Split('-');
                resultChecked.Text = "ไม่ได้PM = " + countCheck[0] + "  /PMแล้วปกติ = " + countCheck[1] + "  /PMแล้วพบชำรุด = " + countCheck[2]
                                    + "   (จากทั้งหมด " + (int.Parse(countCheck[0]) + int.Parse(countCheck[1]) + int.Parse(countCheck[2])).ToString() + ")";
            }
            else   //gridviewPM
            {
                gridviewpm2.Visible = false; gridviewPM.Visible = true;
                sqlItem += "SELECT * "
                    + " FROM tbl_equipment_action a  JOIN tbl_equipment e ON e.equipment_id = a.equip_id " 
                    + " WHERE e.toll_id = '"+lbTolldd.Text+"' AND e.locate_id = '"+locateid+"' " 
                    + " AND e.company_id = '"+companyII.Text+"' AND a.action_delete = '0' ORDER BY e.equipment_id ASC ";
                MySqlDataAdapter da = function.MySqlSelectDataSet(sqlItem);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds);
                gridviewPM.DataSource = ds.Tables[0];
                gridviewPM.DataBind();
                countCheck = CountRadio("1").Split('-');
                resultChecked.Text = "ไม่ได้PM = " + countCheck[0] + "    /PMแล้วปกติ = " + countCheck[1] + "    /PMแล้วพบชำรุด = " + countCheck[2]
                                    + "   (จากทั้งหมด "+ (int.Parse(countCheck[0])+ int.Parse(countCheck[1])+ int.Parse(countCheck[2])).ToString() + ")";
            }
        }
        protected string CountRadio (string whatgrid)
        {
            int nopm = 0;
            int pm = 0;
            int broke = 0;
            string allreturn = "";
            GridViewRow row = null;
            if(whatgrid == "1")
            {
                for (int i = 0; i < gridviewPM.Rows.Count; i++)
                {
                    row = gridviewPM.Rows[i];
                    bool NoTrue = ((RadioButton)row.FindControl("rbtNoPM")).Checked;
                    bool YesTrue = ((RadioButton)row.FindControl("rbtOK")).Checked;
                    bool BreakTrue = ((RadioButton)row.FindControl("rbtBreak")).Checked;
                    if (NoTrue){ nopm++; }
                    if (YesTrue) { pm++; }
                    if(BreakTrue) { broke++; }
                }
            }
            else
            {
                for (int i = 0; i < gridviewpm2.Rows.Count; i++)
                {
                    row = gridviewpm2.Rows[i];
                    bool NoTrue = ((RadioButton)row.FindControl("rbtNoPM2")).Checked;
                    bool YesTrue = ((RadioButton)row.FindControl("rbtOK2")).Checked;
                    bool BreakTrue = ((RadioButton)row.FindControl("rbtBreak2")).Checked;
                    if (NoTrue) { nopm++; }
                    if (YesTrue) { pm++; }
                    if (BreakTrue) { broke++; }
                }
            }
            allreturn = nopm.ToString() + "-" + pm.ToString() + "-" + broke.ToString();
            return allreturn;
        }

        protected void btnEn1_Click(object sender, EventArgs e)
        {
            
                btnEn1.BackColor = System.Drawing.Color.DarkOrange; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
                btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
                btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
                btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
                btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
                btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
                btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
                btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
                btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
                btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
                BtnActionList("1");
        }
        protected void btnEn2_Click(object sender, EventArgs e)
        {
            
                btnEn2.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
                btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
                btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
                btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
                btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
                btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
                btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
                btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
                btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
                btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
            
            BtnActionList("2");
        }
        protected void btnEn3_Click(object sender, EventArgs e)
        {
            
                btnEn3.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
                btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
                btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
                btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
                btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
                btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
                btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
                btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
                btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
                btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
            
            BtnActionList("3");
        }
        protected void btnEn4_Click(object sender, EventArgs e)
        {
                btnEn4.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray;
                btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
                btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
                btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
                btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
                btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
                btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
                btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
                btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
                btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
            
        }
        protected void btnEn5_Click(object sender, EventArgs e)
        {
            
            
            btnEn5.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
            ColorOfButton("");
            BtnActionList("5");
        }
        protected void btnEn6_Click(object sender, EventArgs e)
        {
            BtnActionList("6");
            btnEn6.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;

        }
        protected void btnEn7_Click(object sender, EventArgs e)
        {
            BtnActionList("7");
            btnEn7.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEn8_Click(object sender, EventArgs e)
        {
            BtnActionList("8");
            btnEn8.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEn9_Click(object sender, EventArgs e)
        {
            BtnActionList("9");
            btnEn9.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEn10_Click(object sender, EventArgs e)
        {
            BtnActionList("10");
            btnEn10.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEn11_Click(object sender, EventArgs e)
        {
            BtnActionList("11");
            btnEn11.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEn12_Click(object sender, EventArgs e)
        {
            BtnActionList("12");
            btnEn12.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEn13_Click(object sender, EventArgs e)
        {
            BtnActionList("13");
            btnEn13.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEn14_Click(object sender, EventArgs e)
        {
            BtnActionList("14");
            btnEn14.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEn15_Click(object sender, EventArgs e)
        {
            BtnActionList("15");
            btnEn15.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEn16_Click(object sender, EventArgs e)
        {
            BtnActionList("16");
            btnEn16.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEn17_Click(object sender, EventArgs e)
        {
            BtnActionList("17");
            btnEn17.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEn18_Click(object sender, EventArgs e)
        {
            BtnActionList("18");
            btnEn18.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEn19_Click(object sender, EventArgs e)
        {
            BtnActionList("19");
            btnEn19.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEn20_Click(object sender, EventArgs e)
        {
            BtnActionList("20");
            btnEn20.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx1_Click(object sender, EventArgs e)
        {
            BtnActionList("21");
            btnEx1.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx2_Click(object sender, EventArgs e)
        {
            BtnActionList("22");
            btnEx2.BackColor = System.Drawing.Color.DarkOrange; btnEx1.BackColor = System.Drawing.Color.DimGray; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx3_Click(object sender, EventArgs e)
        {
            BtnActionList("23");
            btnEx3.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx4_Click(object sender, EventArgs e)
        {
            BtnActionList("24");
            btnEx4.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx5_Click(object sender, EventArgs e)
        {
            BtnActionList("25");
            btnEx5.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx6_Click(object sender, EventArgs e)
        {
            BtnActionList("26");
          
            btnEx6.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx7_Click(object sender, EventArgs e)
        {
            BtnActionList("27");
            btnEx7.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx8_Click(object sender, EventArgs e)
        {
            BtnActionList("28");
            btnEx8.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx9_Click(object sender, EventArgs e)
        {
            BtnActionList("29");
            btnEx9.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx10_Click(object sender, EventArgs e)
        {
            BtnActionList("30");
            btnEx10.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx11_Click(object sender, EventArgs e)
        {
            BtnActionList("31");
            btnEx11.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx12_Click(object sender, EventArgs e)
        {
            BtnActionList("32");
            btnEx12.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx13_Click(object sender, EventArgs e)
        {
            BtnActionList("33");
            btnEx13.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx14_Click(object sender, EventArgs e)
        {
            BtnActionList("34");
            btnEx14.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx15_Click(object sender, EventArgs e)
        {
            BtnActionList("35");
            btnEx15.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx16_Click(object sender, EventArgs e)
        {
            BtnActionList("36");
            btnEx16.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx17_Click(object sender, EventArgs e)
        {
            BtnActionList("37");
            btnEx17.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx18_Click(object sender, EventArgs e)
        {
            BtnActionList("38");
            btnEx18.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx19_Click(object sender, EventArgs e)
        {
            BtnActionList("39");
            btnEx19.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx20.BackColor = System.Drawing.Color.DimGray;
        }
        protected void btnEx20_Click(object sender, EventArgs e)
        {
            BtnActionList("40");
            btnEx20.BackColor = System.Drawing.Color.DarkOrange; btnEn1.BackColor = System.Drawing.Color.DimGray; btnEn2.BackColor = System.Drawing.Color.DimGray; btnEn3.BackColor = System.Drawing.Color.DimGray; btnEn4.BackColor = System.Drawing.Color.DimGray;
            btnEn5.BackColor = System.Drawing.Color.DimGray; btnEn6.BackColor = System.Drawing.Color.DimGray; btnEn7.BackColor = System.Drawing.Color.DimGray; btnEn8.BackColor = System.Drawing.Color.DimGray;
            btnEn9.BackColor = System.Drawing.Color.DimGray; btnEn10.BackColor = System.Drawing.Color.DimGray; btnEn11.BackColor = System.Drawing.Color.DimGray; btnEn12.BackColor = System.Drawing.Color.DimGray;
            btnEn13.BackColor = System.Drawing.Color.DimGray; btnEn14.BackColor = System.Drawing.Color.DimGray; btnEn15.BackColor = System.Drawing.Color.DimGray; btnEn16.BackColor = System.Drawing.Color.DimGray;
            btnEn17.BackColor = System.Drawing.Color.DimGray; btnEn18.BackColor = System.Drawing.Color.DimGray; btnEn19.BackColor = System.Drawing.Color.DimGray; btnEn20.BackColor = System.Drawing.Color.DimGray;
            btnEx1.BackColor = System.Drawing.Color.DimGray; btnEx2.BackColor = System.Drawing.Color.DimGray; btnEx3.BackColor = System.Drawing.Color.DimGray; btnEx4.BackColor = System.Drawing.Color.DimGray;
            btnEx5.BackColor = System.Drawing.Color.DimGray; btnEx6.BackColor = System.Drawing.Color.DimGray; btnEx7.BackColor = System.Drawing.Color.DimGray; btnEx8.BackColor = System.Drawing.Color.DimGray;
            btnEx9.BackColor = System.Drawing.Color.DimGray; btnEx10.BackColor = System.Drawing.Color.DimGray; btnEx11.BackColor = System.Drawing.Color.DimGray; btnEx12.BackColor = System.Drawing.Color.DimGray;
            btnEx13.BackColor = System.Drawing.Color.DimGray; btnEx14.BackColor = System.Drawing.Color.DimGray; btnEx15.BackColor = System.Drawing.Color.DimGray; btnEx16.BackColor = System.Drawing.Color.DimGray;
            btnEx17.BackColor = System.Drawing.Color.DimGray; btnEx18.BackColor = System.Drawing.Color.DimGray; btnEx19.BackColor = System.Drawing.Color.DimGray;
            
        }

        protected void gridviewpm2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            RadioButton rbtOKk2 = (RadioButton)e.Row.FindControl("rbtOK2");
            RadioButton rbtBreakk2 = (RadioButton)e.Row.FindControl("rbtBreak2");
            RadioButton rbtNoPM2 = (RadioButton)e.Row.FindControl("rbtNoPM2");
            Label EqipStat2 = (Label)e.Row.FindControl("EqipStat2");
            Label CodeEquipment2 = (Label)e.Row.FindControl("CodeEquipment2");

            if (EqipStat2 != null)
            {
                if (EqipStat2.Text == "0") { rbtNoPM2.Checked = true;  }
                else if (EqipStat2.Text == "1") { rbtOKk2.Checked = true;  }
                else if (EqipStat2.Text == "2") { rbtBreakk2.Checked = true;  }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#e3e1e1");
                e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#c9ffc9");
                e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffd6d6");
                e.Row.Cells[7].BackColor = System.Drawing.ColorTranslator.FromHtml("white");
                e.Row.Cells[7].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffe8c9");
                e.Row.Cells[8].BackColor = System.Drawing.ColorTranslator.FromHtml("white");
                e.Row.Cells[8].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffe8c9");
                

            }
            if(e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#6b6a6a");
                e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#339e33");
                e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#9c2222");
                e.Row.Cells[7].BackColor = System.Drawing.ColorTranslator.FromHtml("white");
                e.Row.Cells[8].BackColor = System.Drawing.ColorTranslator.FromHtml("white");
               
            }
        }
        public void QueryLocatePM ()
        {
            string equipIDD = ""; string actionChk = ""; string pmnote = ""; string SQLPMM = "";
            string todayLO = DateTime.Now.ToString("MM-dd-yyyy hh:mm tt");
            int doOrnot = 0;
                if (gridviewpm2.Visible )
                {
                    
                    for (int i = 0; i < gridviewpm2.Rows.Count; i++)
                    {
                        equipIDD = ((Label)gridviewpm2.Rows[i].FindControl("EQid2")).Text;
                        actionChk = ((Label)gridviewpm2.Rows[i].FindControl("EqipStat2")).Text;
                        pmnote = ((TextBox)gridviewpm2.Rows[i].FindControl("notepm2")).Text;
                        
                        SQLPMM = "INSERT INTO tbl_equipment_action (action_time,action_who,equip_id,action_note,action_stat,action_type_id,action_delete,pm_ref_no)"
                              + " VALUES ('"+todayLO+"','" + Session["User"].ToString() + "','" + equipIDD + "','" + pmnote + "','" + actionChk + "','1','0','" + Session["codePKPM"].ToString() + "') ";
                        if (function.MySqlQuery(SQLPMM))
                        {
                                doOrnot++;
                        }
                        else
                        { doOrnot = 0; break; }
                    }
                    if(doOrnot != 0) { Response.Redirect("/PM/PMDetailForm"); }
                    else { AlertPop("บันทึกข้อมูลล้มเหลว ติดต่อเจ้าหน้าที่","error"); }
                }
                else if (gridviewPM.Visible)
                {
                    for (int i = 0; i < gridviewPM.Rows.Count; i++)
                    {
                        equipIDD = ((Label)gridviewPM.Rows[i].FindControl("EQid")).Text;
                        actionChk = ((Label)gridviewPM.Rows[i].FindControl("EqipStat")).Text;
                        pmnote = ((TextBox)gridviewPM.Rows[i].FindControl("notepm")).Text;
                    SQLPMM = "UPDATE tbl_equipment_action SET equip_id='" + equipIDD + "',action_note = '" + pmnote + "',action_stat='" + actionChk + "' "
                            + " ,action_type_id='1',action_time='"+todayLO+"',action_who='"+ Session["User"].ToString() + "'  WHERE pm_ref_no = '" + Session["codePKPM"].ToString() + "' AND equip_id = '"+equipIDD+"' ";

                        if (function.MySqlQuery(SQLPMM)) { doOrnot++; }
                        else { doOrnot = 0; break; }
                    }
                    if (doOrnot != 0) { Response.Redirect("/PM/PMDetailForm"); }
                    else { AlertPop("บันทึกข้อมูลล้มเหลว ติดต่อเจ้าหน้าที่", "error"); }
                }

        }

        protected void btnSavelocate_Click(object sender, EventArgs e)
        {
            QueryLocatePM();
        }

        protected void rbtOK2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdio = (RadioButton)sender;
            GridViewRow rowrd = (GridViewRow)rdio.NamingContainer;
            int rIndex = rowrd.RowIndex;
            Label lb;
            rdio = (RadioButton)gridviewpm2.Rows[rIndex].FindControl("rbtOK2");
            lb = (Label)gridviewpm2.Rows[rIndex].FindControl("EqipStat2");

            if (rdio.Checked)
            {
                lb.Text = "1";
                
            }
            string[] countCheck;
            countCheck = CountRadio("2").Split('-');
            resultChecked.Text = "ไม่ได้PM = " + countCheck[0] + "  /PMแล้วปกติ = " + countCheck[1] + "  /PMแล้วพบชำรุด = " + countCheck[2]
                                + "   (จากทั้งหมด " + (int.Parse(countCheck[0]) + int.Parse(countCheck[1]) + int.Parse(countCheck[2])).ToString() + ")";
        }

        protected void rbtNoPM2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdio = (RadioButton)sender;
            GridViewRow rowrd = (GridViewRow)rdio.NamingContainer;
            int rIndex = rowrd.RowIndex;
            Label lb;
            rdio = (RadioButton)gridviewpm2.Rows[rIndex].FindControl("rbtNoPM2");
            lb = (Label)gridviewpm2.Rows[rIndex].FindControl("EqipStat2");

            if (rdio.Checked)
            {
                lb.Text = "0";
            }
            string[] countCheck;
            countCheck = CountRadio("2").Split('-');
            resultChecked.Text = "ไม่ได้PM = " + countCheck[0] + "  /PMแล้วปกติ = " + countCheck[1] + "  /PMแล้วพบชำรุด = " + countCheck[2]
                + "   (จากทั้งหมด " + (int.Parse(countCheck[0]) + int.Parse(countCheck[1]) + int.Parse(countCheck[2])).ToString() + ")";
        }

        protected void rbtBreak2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdio = (RadioButton)sender;
            GridViewRow rowrd = (GridViewRow)rdio.NamingContainer;
            int rIndex = rowrd.RowIndex;
            Label lb;
            rdio = (RadioButton)gridviewpm2.Rows[rIndex].FindControl("rbtBreak2");
            lb = (Label)gridviewpm2.Rows[rIndex].FindControl("EqipStat2");

            if (rdio.Checked)
            {
                lb.Text = "2";
            }
            string[] countCheck;
            countCheck = CountRadio("2").Split('-');
            resultChecked.Text = "ไม่ได้PM = " + countCheck[0] + "  /PMแล้วปกติ = " + countCheck[1] + "  /PMแล้วพบชำรุด = " + countCheck[2]
                + "   (จากทั้งหมด " + (int.Parse(countCheck[0]) + int.Parse(countCheck[1]) + int.Parse(countCheck[2])).ToString() + ")";
        }

        protected void rbtNoPM_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdio = (RadioButton)sender;
            GridViewRow rowrd = (GridViewRow)rdio.NamingContainer;
            int rIndex = rowrd.RowIndex;
            Label lb;
            rdio = (RadioButton)gridviewPM.Rows[rIndex].FindControl("rbtNoPM");
            lb = (Label)gridviewPM.Rows[rIndex].FindControl("EqipStat");

            if (rdio.Checked)
            {
                lb.Text = "0";
            }
            string[] countCheck;
            countCheck = CountRadio("1").Split('-');
            resultChecked.Text = "ไม่ได้PM = " + countCheck[0] + "  /PMแล้วปกติ = " + countCheck[1] + "  /PMแล้วพบชำรุด = " + countCheck[2]
                + "   (จากทั้งหมด " + (int.Parse(countCheck[0]) + int.Parse(countCheck[1]) + int.Parse(countCheck[2])).ToString() + ")";
        }

        protected void rbtOK_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdio = (RadioButton)sender;
            GridViewRow rowrd = (GridViewRow)rdio.NamingContainer;
            int rIndex = rowrd.RowIndex;
            Label lb;
            rdio = (RadioButton)gridviewPM.Rows[rIndex].FindControl("rbtOK");
            lb = (Label)gridviewPM.Rows[rIndex].FindControl("EqipStat");

            if (rdio.Checked)
            {
                lb.Text = "1";
            }
            string[] countCheck;
            countCheck = CountRadio("1").Split('-');
            resultChecked.Text = "ไม่ได้PM = " + countCheck[0] + "  /PMแล้วปกติ = " + countCheck[1] + "  /PMแล้วพบชำรุด = " + countCheck[2]
                + "   (จากทั้งหมด " + (int.Parse(countCheck[0]) + int.Parse(countCheck[1]) + int.Parse(countCheck[2])).ToString() + ")";
        }

        protected void rbtBreak_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdio = (RadioButton)sender;
            GridViewRow rowrd = (GridViewRow)rdio.NamingContainer;
            int rIndex = rowrd.RowIndex;
            Label lb;
            rdio = (RadioButton)gridviewPM.Rows[rIndex].FindControl("rbtBreak");
            lb = (Label)gridviewPM.Rows[rIndex].FindControl("EqipStat");
            
            if (rdio.Checked)
            {
                lb.Text = "2";
            }
            string[] countCheck;
            countCheck = CountRadio("1").Split('-');
            resultChecked.Text = "ไม่ได้PM = " + countCheck[0] + "  /PMแล้วปกติ = " + countCheck[1] + "  /PMแล้วพบชำรุด = " + countCheck[2]
                + "   (จากทั้งหมด " + (int.Parse(countCheck[0]) + int.Parse(countCheck[1]) + int.Parse(countCheck[2])).ToString() + ")";
        }

       

        



        protected void ComSubmit_Click(object sender, EventArgs e)
        {
            string Submit = "UPDATE tbl_pm_detail SET pm_status_id ='2' WHERE pm_ref_no = '"+ Session["codePKPM"].ToString() + "'";
            if (function.MySqlQuery(Submit))
            {
                AlertPop("บันทึกเรียบร้อย", "success");
                PageLoadData();
                VisibleButton();
                ColorOfButton("1");
            }
            else
            {
                AlertPop("บันทึกล้มเหลว ติดต่อนักพัฒนา", "error");
            }
        }

        protected void AdminCheck_Click(object sender, EventArgs e)
        {
            string chkpm = "UPDATE tbl_pm_detail SET pm_status_id ='3' WHERE pm_ref_no = '" + Session["codePKPM"].ToString() + "'";
            if (function.MySqlQuery(chkpm))
            {
                AlertPop("บันทึกการตรวจสอบเรียบร้อย", "success");
                PageLoadData();
                VisibleButton();
                ColorOfButton("1");
            }
            else
            {
                AlertPop("บันทึกตรวจสอบล้มเหลว ติดต่อนักพัฒนา", "error");
            }
        }

        protected void AdComplete_Click(object sender, EventArgs e)
        {
            string complete = "UPDATE tbl_pm_detail SET pm_status_id ='4' WHERE pm_ref_no = '" + Session["codePKPM"].ToString() + "'";
            if (function.MySqlQuery(complete))
            {
                AlertPop("บันทึกการตรวจสอบเรียบร้อย", "success");
                PageLoadData();
                VisibleButton();
                ColorOfButton("1");
            }
            else
            {
                AlertPop("บันทึกตรวจสอบล้มเหลว ติดต่อนักพัฒนา", "error");
            }
        }

        protected void rbtBuilding_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtBuilding.Checked == true)
            {
                divEN.Visible = false;
                divEX.Visible = false;
                divBuilding1.Visible = true;
                divBuilding2.Visible = true;
            }
            else if(rbtLane.Checked == true)
            {
                divEN.Visible = true;
                divEX.Visible = true;
                divBuilding1.Visible = false;
                divBuilding2.Visible = false;

            }
        }

        protected void rbtLane_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtBuilding.Checked == true)
            {
                divEN.Visible = false;
                divEX.Visible = false;
                divBuilding1.Visible = true;
                divBuilding2.Visible = true;
            }
            else if (rbtLane.Checked == true)
            {
                divEN.Visible = true;
                divEX.Visible = true;
                divBuilding1.Visible = false;
                divBuilding2.Visible = false;
            }
        }

        protected void btn41_Click(object sender, EventArgs e)
        {
            BtnActionList("41");
            btn41.BackColor = System.Drawing.Color.DarkOrange; btn42.BackColor = System.Drawing.Color.DimGray; btn44.BackColor = System.Drawing.Color.DimGray; btn45.BackColor = System.Drawing.Color.DimGray;
            btn46.BackColor = System.Drawing.Color.DimGray;
            btn47.BackColor = System.Drawing.Color.DimGray; btn48.BackColor = System.Drawing.Color.DimGray; btn49.BackColor = System.Drawing.Color.DimGray; btn50.BackColor = System.Drawing.Color.DimGray;
            btn51.BackColor = System.Drawing.Color.DimGray; btn52.BackColor = System.Drawing.Color.DimGray; btn53.BackColor = System.Drawing.Color.DimGray; btn54.BackColor = System.Drawing.Color.DimGray;
            btn55.BackColor = System.Drawing.Color.DimGray; btn56.BackColor = System.Drawing.Color.DimGray; btn57.BackColor = System.Drawing.Color.DimGray; btn58.BackColor = System.Drawing.Color.DimGray;
            
        }

        protected void btn42_Click(object sender, EventArgs e)
        {
            BtnActionList("42");
            btn41.BackColor = System.Drawing.Color.DimGray; btn42.BackColor = System.Drawing.Color.DarkOrange; btn44.BackColor = System.Drawing.Color.DimGray; btn45.BackColor = System.Drawing.Color.DimGray;
            btn46.BackColor = System.Drawing.Color.DimGray;
            btn47.BackColor = System.Drawing.Color.DimGray; btn48.BackColor = System.Drawing.Color.DimGray; btn49.BackColor = System.Drawing.Color.DimGray; btn50.BackColor = System.Drawing.Color.DimGray;
            btn51.BackColor = System.Drawing.Color.DimGray; btn52.BackColor = System.Drawing.Color.DimGray; btn53.BackColor = System.Drawing.Color.DimGray; btn54.BackColor = System.Drawing.Color.DimGray;
            btn55.BackColor = System.Drawing.Color.DimGray; btn56.BackColor = System.Drawing.Color.DimGray; btn57.BackColor = System.Drawing.Color.DimGray; btn58.BackColor = System.Drawing.Color.DimGray;

        }

        protected void btn44_Click(object sender, EventArgs e)
        {
            BtnActionList("44");
            btn41.BackColor = System.Drawing.Color.DimGray; btn42.BackColor = System.Drawing.Color.DimGray; btn44.BackColor = System.Drawing.Color.DarkOrange; btn45.BackColor = System.Drawing.Color.DimGray;
            btn46.BackColor = System.Drawing.Color.DimGray;
            btn47.BackColor = System.Drawing.Color.DimGray; btn48.BackColor = System.Drawing.Color.DimGray; btn49.BackColor = System.Drawing.Color.DimGray; btn50.BackColor = System.Drawing.Color.DimGray;
            btn51.BackColor = System.Drawing.Color.DimGray; btn52.BackColor = System.Drawing.Color.DimGray; btn53.BackColor = System.Drawing.Color.DimGray; btn54.BackColor = System.Drawing.Color.DimGray;
            btn55.BackColor = System.Drawing.Color.DimGray; btn56.BackColor = System.Drawing.Color.DimGray; btn57.BackColor = System.Drawing.Color.DimGray; btn58.BackColor = System.Drawing.Color.DimGray;

        }

        protected void btn45_Click(object sender, EventArgs e)
        {
            BtnActionList("45");
            btn41.BackColor = System.Drawing.Color.DimGray; btn42.BackColor = System.Drawing.Color.DimGray; btn44.BackColor = System.Drawing.Color.DimGray; btn45.BackColor = System.Drawing.Color.DarkOrange;
            btn46.BackColor = System.Drawing.Color.DimGray;
            btn47.BackColor = System.Drawing.Color.DimGray; btn48.BackColor = System.Drawing.Color.DimGray; btn49.BackColor = System.Drawing.Color.DimGray; btn50.BackColor = System.Drawing.Color.DimGray;
            btn51.BackColor = System.Drawing.Color.DimGray; btn52.BackColor = System.Drawing.Color.DimGray; btn53.BackColor = System.Drawing.Color.DimGray; btn54.BackColor = System.Drawing.Color.DimGray;
            btn55.BackColor = System.Drawing.Color.DimGray; btn56.BackColor = System.Drawing.Color.DimGray; btn57.BackColor = System.Drawing.Color.DimGray; btn58.BackColor = System.Drawing.Color.DimGray;

        }

        protected void btn46_Click(object sender, EventArgs e)
        {
            BtnActionList("46");
            btn41.BackColor = System.Drawing.Color.DimGray; btn42.BackColor = System.Drawing.Color.DimGray; btn44.BackColor = System.Drawing.Color.DimGray; btn45.BackColor = System.Drawing.Color.DimGray;
            btn46.BackColor = System.Drawing.Color.DarkOrange;
            btn47.BackColor = System.Drawing.Color.DimGray; btn48.BackColor = System.Drawing.Color.DimGray; btn49.BackColor = System.Drawing.Color.DimGray; btn50.BackColor = System.Drawing.Color.DimGray;
            btn51.BackColor = System.Drawing.Color.DimGray; btn52.BackColor = System.Drawing.Color.DimGray; btn53.BackColor = System.Drawing.Color.DimGray; btn54.BackColor = System.Drawing.Color.DimGray;
            btn55.BackColor = System.Drawing.Color.DimGray; btn56.BackColor = System.Drawing.Color.DimGray; btn57.BackColor = System.Drawing.Color.DimGray; btn58.BackColor = System.Drawing.Color.DimGray;

        }

        protected void btn47_Click(object sender, EventArgs e)
        {
            BtnActionList("47");
            btn41.BackColor = System.Drawing.Color.DimGray; btn42.BackColor = System.Drawing.Color.DimGray; btn44.BackColor = System.Drawing.Color.DimGray; btn45.BackColor = System.Drawing.Color.DimGray;
            btn46.BackColor = System.Drawing.Color.DimGray;
            btn47.BackColor = System.Drawing.Color.DarkOrange; btn48.BackColor = System.Drawing.Color.DimGray; btn49.BackColor = System.Drawing.Color.DimGray; btn50.BackColor = System.Drawing.Color.DimGray;
            btn51.BackColor = System.Drawing.Color.DimGray; btn52.BackColor = System.Drawing.Color.DimGray; btn53.BackColor = System.Drawing.Color.DimGray; btn54.BackColor = System.Drawing.Color.DimGray;
            btn55.BackColor = System.Drawing.Color.DimGray; btn56.BackColor = System.Drawing.Color.DimGray; btn57.BackColor = System.Drawing.Color.DimGray; btn58.BackColor = System.Drawing.Color.DimGray;

        }

        protected void btn48_Click(object sender, EventArgs e)
        {
            BtnActionList("48");
            btn41.BackColor = System.Drawing.Color.DimGray; btn42.BackColor = System.Drawing.Color.DimGray; btn44.BackColor = System.Drawing.Color.DimGray; btn45.BackColor = System.Drawing.Color.DimGray;
            btn46.BackColor = System.Drawing.Color.DimGray;
            btn47.BackColor = System.Drawing.Color.DimGray; btn48.BackColor = System.Drawing.Color.DarkOrange; btn49.BackColor = System.Drawing.Color.DimGray; btn50.BackColor = System.Drawing.Color.DimGray;
            btn51.BackColor = System.Drawing.Color.DimGray; btn52.BackColor = System.Drawing.Color.DimGray; btn53.BackColor = System.Drawing.Color.DimGray; btn54.BackColor = System.Drawing.Color.DimGray;
            btn55.BackColor = System.Drawing.Color.DimGray; btn56.BackColor = System.Drawing.Color.DimGray; btn57.BackColor = System.Drawing.Color.DimGray; btn58.BackColor = System.Drawing.Color.DimGray;

        }

        protected void btn49_Click(object sender, EventArgs e)
        {
            BtnActionList("49");
            btn41.BackColor = System.Drawing.Color.DimGray; btn42.BackColor = System.Drawing.Color.DimGray; btn44.BackColor = System.Drawing.Color.DimGray; btn45.BackColor = System.Drawing.Color.DimGray;
            btn46.BackColor = System.Drawing.Color.DimGray;
            btn47.BackColor = System.Drawing.Color.DimGray; btn48.BackColor = System.Drawing.Color.DimGray; btn49.BackColor = System.Drawing.Color.DarkOrange; btn50.BackColor = System.Drawing.Color.DimGray;
            btn51.BackColor = System.Drawing.Color.DimGray; btn52.BackColor = System.Drawing.Color.DimGray; btn53.BackColor = System.Drawing.Color.DimGray; btn54.BackColor = System.Drawing.Color.DimGray;
            btn55.BackColor = System.Drawing.Color.DimGray; btn56.BackColor = System.Drawing.Color.DimGray; btn57.BackColor = System.Drawing.Color.DimGray; btn58.BackColor = System.Drawing.Color.DimGray;

        }

        protected void btn50_Click(object sender, EventArgs e)
        {
            BtnActionList("50");
            btn41.BackColor = System.Drawing.Color.DimGray; btn42.BackColor = System.Drawing.Color.DimGray; btn44.BackColor = System.Drawing.Color.DimGray; btn45.BackColor = System.Drawing.Color.DimGray;
            btn46.BackColor = System.Drawing.Color.DimGray;
            btn47.BackColor = System.Drawing.Color.DimGray; btn48.BackColor = System.Drawing.Color.DimGray; btn49.BackColor = System.Drawing.Color.DimGray; btn50.BackColor = System.Drawing.Color.DarkOrange;
            btn51.BackColor = System.Drawing.Color.DimGray; btn52.BackColor = System.Drawing.Color.DimGray; btn53.BackColor = System.Drawing.Color.DimGray; btn54.BackColor = System.Drawing.Color.DimGray;
            btn55.BackColor = System.Drawing.Color.DimGray; btn56.BackColor = System.Drawing.Color.DimGray; btn57.BackColor = System.Drawing.Color.DimGray; btn58.BackColor = System.Drawing.Color.DimGray;

        }

        protected void btn51_Click(object sender, EventArgs e)
        {
            BtnActionList("51");
            btn41.BackColor = System.Drawing.Color.DimGray; btn42.BackColor = System.Drawing.Color.DimGray; btn44.BackColor = System.Drawing.Color.DimGray; btn45.BackColor = System.Drawing.Color.DimGray;
            btn46.BackColor = System.Drawing.Color.DimGray;
            btn47.BackColor = System.Drawing.Color.DimGray; btn48.BackColor = System.Drawing.Color.DimGray; btn49.BackColor = System.Drawing.Color.DimGray; btn50.BackColor = System.Drawing.Color.DimGray;
            btn51.BackColor = System.Drawing.Color.DarkOrange; btn52.BackColor = System.Drawing.Color.DimGray; btn53.BackColor = System.Drawing.Color.DimGray; btn54.BackColor = System.Drawing.Color.DimGray;
            btn55.BackColor = System.Drawing.Color.DimGray; btn56.BackColor = System.Drawing.Color.DimGray; btn57.BackColor = System.Drawing.Color.DimGray; btn58.BackColor = System.Drawing.Color.DimGray;

        }

        protected void btn52_Click(object sender, EventArgs e)
        {
            BtnActionList("52");
            btn41.BackColor = System.Drawing.Color.DimGray; btn42.BackColor = System.Drawing.Color.DimGray; btn44.BackColor = System.Drawing.Color.DimGray; btn45.BackColor = System.Drawing.Color.DimGray;
            btn46.BackColor = System.Drawing.Color.DimGray;
            btn47.BackColor = System.Drawing.Color.DimGray; btn48.BackColor = System.Drawing.Color.DimGray; btn49.BackColor = System.Drawing.Color.DimGray; btn50.BackColor = System.Drawing.Color.DimGray;
            btn51.BackColor = System.Drawing.Color.DimGray; btn52.BackColor = System.Drawing.Color.DarkOrange; btn53.BackColor = System.Drawing.Color.DimGray; btn54.BackColor = System.Drawing.Color.DimGray;
            btn55.BackColor = System.Drawing.Color.DimGray; btn56.BackColor = System.Drawing.Color.DimGray; btn57.BackColor = System.Drawing.Color.DimGray; btn58.BackColor = System.Drawing.Color.DimGray;

        }

        protected void btn53_Click(object sender, EventArgs e)
        {
            BtnActionList("53");
            btn41.BackColor = System.Drawing.Color.DimGray; btn42.BackColor = System.Drawing.Color.DimGray; btn44.BackColor = System.Drawing.Color.DimGray; btn45.BackColor = System.Drawing.Color.DimGray;
            btn46.BackColor = System.Drawing.Color.DimGray;
            btn47.BackColor = System.Drawing.Color.DimGray; btn48.BackColor = System.Drawing.Color.DimGray; btn49.BackColor = System.Drawing.Color.DimGray; btn50.BackColor = System.Drawing.Color.DimGray;
            btn51.BackColor = System.Drawing.Color.DimGray; btn52.BackColor = System.Drawing.Color.DimGray; btn53.BackColor = System.Drawing.Color.DarkOrange; btn54.BackColor = System.Drawing.Color.DimGray;
            btn55.BackColor = System.Drawing.Color.DimGray; btn56.BackColor = System.Drawing.Color.DimGray; btn57.BackColor = System.Drawing.Color.DimGray; btn58.BackColor = System.Drawing.Color.DimGray;

        }

        protected void btn54_Click(object sender, EventArgs e)
        {
            BtnActionList("54");
            btn41.BackColor = System.Drawing.Color.DimGray; btn42.BackColor = System.Drawing.Color.DimGray; btn44.BackColor = System.Drawing.Color.DimGray; btn45.BackColor = System.Drawing.Color.DimGray;
            btn46.BackColor = System.Drawing.Color.DimGray;
            btn47.BackColor = System.Drawing.Color.DimGray; btn48.BackColor = System.Drawing.Color.DimGray; btn49.BackColor = System.Drawing.Color.DimGray; btn50.BackColor = System.Drawing.Color.DimGray;
            btn51.BackColor = System.Drawing.Color.DimGray; btn52.BackColor = System.Drawing.Color.DimGray; btn53.BackColor = System.Drawing.Color.DimGray; btn54.BackColor = System.Drawing.Color.DarkOrange;
            btn55.BackColor = System.Drawing.Color.DimGray; btn56.BackColor = System.Drawing.Color.DimGray; btn57.BackColor = System.Drawing.Color.DimGray; btn58.BackColor = System.Drawing.Color.DimGray;

        }

        protected void btn55_Click(object sender, EventArgs e)
        {
            BtnActionList("55");
            btn41.BackColor = System.Drawing.Color.DimGray; btn42.BackColor = System.Drawing.Color.DimGray; btn44.BackColor = System.Drawing.Color.DimGray; btn45.BackColor = System.Drawing.Color.DimGray;
            btn46.BackColor = System.Drawing.Color.DimGray;
            btn47.BackColor = System.Drawing.Color.DimGray; btn48.BackColor = System.Drawing.Color.DimGray; btn49.BackColor = System.Drawing.Color.DimGray; btn50.BackColor = System.Drawing.Color.DimGray;
            btn51.BackColor = System.Drawing.Color.DimGray; btn52.BackColor = System.Drawing.Color.DimGray; btn53.BackColor = System.Drawing.Color.DimGray; btn54.BackColor = System.Drawing.Color.DimGray;
            btn55.BackColor = System.Drawing.Color.DarkOrange; btn56.BackColor = System.Drawing.Color.DimGray; btn57.BackColor = System.Drawing.Color.DimGray; btn58.BackColor = System.Drawing.Color.DimGray;

        }

        protected void btn56_Click(object sender, EventArgs e)
        {
            BtnActionList("56");
            btn41.BackColor = System.Drawing.Color.DimGray; btn42.BackColor = System.Drawing.Color.DimGray; btn44.BackColor = System.Drawing.Color.DimGray; btn45.BackColor = System.Drawing.Color.DimGray;
            btn46.BackColor = System.Drawing.Color.DimGray;
            btn47.BackColor = System.Drawing.Color.DimGray; btn48.BackColor = System.Drawing.Color.DimGray; btn49.BackColor = System.Drawing.Color.DimGray; btn50.BackColor = System.Drawing.Color.DimGray;
            btn51.BackColor = System.Drawing.Color.DimGray; btn52.BackColor = System.Drawing.Color.DimGray; btn53.BackColor = System.Drawing.Color.DimGray; btn54.BackColor = System.Drawing.Color.DimGray;
            btn55.BackColor = System.Drawing.Color.DimGray; btn56.BackColor = System.Drawing.Color.DarkOrange; btn57.BackColor = System.Drawing.Color.DimGray; btn58.BackColor = System.Drawing.Color.DimGray;

        }

        protected void btn57_Click(object sender, EventArgs e)
        {
            BtnActionList("57");
            btn41.BackColor = System.Drawing.Color.DimGray; btn42.BackColor = System.Drawing.Color.DimGray; btn44.BackColor = System.Drawing.Color.DimGray; btn45.BackColor = System.Drawing.Color.DimGray;
            btn46.BackColor = System.Drawing.Color.DimGray;
            btn47.BackColor = System.Drawing.Color.DimGray; btn48.BackColor = System.Drawing.Color.DimGray; btn49.BackColor = System.Drawing.Color.DimGray; btn50.BackColor = System.Drawing.Color.DimGray;
            btn51.BackColor = System.Drawing.Color.DimGray; btn52.BackColor = System.Drawing.Color.DimGray; btn53.BackColor = System.Drawing.Color.DimGray; btn54.BackColor = System.Drawing.Color.DimGray;
            btn55.BackColor = System.Drawing.Color.DimGray; btn56.BackColor = System.Drawing.Color.DimGray; btn57.BackColor = System.Drawing.Color.DarkOrange; btn58.BackColor = System.Drawing.Color.DimGray;

        }

        protected void btn58_Click(object sender, EventArgs e)
        {
            BtnActionList("58");
            btn41.BackColor = System.Drawing.Color.DimGray; btn42.BackColor = System.Drawing.Color.DimGray; btn44.BackColor = System.Drawing.Color.DimGray; btn45.BackColor = System.Drawing.Color.DimGray;
            btn46.BackColor = System.Drawing.Color.DimGray;
            btn47.BackColor = System.Drawing.Color.DimGray; btn48.BackColor = System.Drawing.Color.DimGray; btn49.BackColor = System.Drawing.Color.DimGray; btn50.BackColor = System.Drawing.Color.DimGray;
            btn51.BackColor = System.Drawing.Color.DimGray; btn52.BackColor = System.Drawing.Color.DimGray; btn53.BackColor = System.Drawing.Color.DimGray; btn54.BackColor = System.Drawing.Color.DimGray;
            btn55.BackColor = System.Drawing.Color.DimGray; btn56.BackColor = System.Drawing.Color.DimGray; btn57.BackColor = System.Drawing.Color.DimGray; btn58.BackColor = System.Drawing.Color.DarkOrange;

        }
    }
}