using ClaimProject.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimProject
{
    public partial class SiteMaster : MasterPage
    {
        public string navchk = "";
        ClaimFunction function = new ClaimFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Charset = "UTF-8";
            txtUrlchk.Text = Request.Url.AbsolutePath.ToString();

            if (Request.Cookies["ClaimLogin"] != null)
            {
                Session.Add("User", Request.Cookies["ClaimLogin"]["User"]);
                Session.Add("UserName", function.GetSelectValue("tbl_user","username = '"+ Request.Cookies["ClaimLogin"]["User"] + "'","name"));
                Session.Add("UserPrivilegeId", function.GetSelectValue("tbl_user", "username = '" + Request.Cookies["ClaimLogin"]["User"] + "'", "level"));
                Session.Add("UserPrivilege", function.GetLevel(int.Parse(Session["UserPrivilegeId"].ToString())));
                Session.Add("UserCpoint", Request.Cookies["ClaimLogin"]["UserCpoint"]);
                Session.Add("Userpoint", Request.Cookies["ClaimLogin"]["Userpoint"]);
                Session.Add("ddlsearchType", "0");
                Session.Add("ddlsearchStat", "0");
                Session.Add("BackWhat", "");
                Session.Add("LineTran", "");
                Session.Add("txtSearchEq", "");
                Session.Timeout = 28800;
            }

            if (Session["User"] == null)
            {
                Response.Redirect("/Login");
            }
            else
            {
                lbUser.Text = Session["UserName"].ToString() + "<br>" + Session["UserPrivilege"] + " " + function.GetSelectValue("tbl_cpoint", "cpoint_id='" + Session["UserCpoint"].ToString() + "'", "cpoint_name" ) +" "+ function.GetSelectValue("tbl_annex", "Annex_id='" + Session["Userpoint"].ToString() + "'", "Annex_name");

                if (function.CheckLevel("Techno", Session["UserPrivilegeId"].ToString()))
                {
                    if (Session["UserPrivilegeId"].ToString() == "1")
                    {
                        Li2.Visible = false;
                        equipDiv.Visible = false;
                    }
                    else
                    {
                        equipDiv.Visible = false;
                        Li2.Visible = false;
                        nav3.Visible = true;
                    }
                        
                }
                else
                {
                    if(Session["UserPrivilegeId"].ToString() == "5")
                    {
                        if (Session["UserCpoint"].ToString() == "0")
                        {
                            nav3.Visible = false;
                            equipDiv.Visible = false;
                            nav0.Visible = false;
                            nav1.Visible = false;
                            Li2.Visible = false;
                            Li1.Visible = false;
                            searchEn.Visible = false;
                            Li3.Visible = false;
                            Li4.Visible = true;
                        }
                        else
                        {
                            nav3.Visible = false;
                            equipDiv.Visible = true;
                            nav0.Visible = false;
                            nav1.Visible = true;
                            Li2.Visible = false;
                            Li1.Visible = false;
                            searchEn.Visible = false;
                            Li3.Visible = false;
                            Li4.Visible = false;
                        }
                        
                    }
                    else if (Session["UserPrivilegeId"].ToString() == "4")
                    {
                        nav3.Visible = false;
                        equipDiv.Visible = false;
                        searchEn.Visible = false;
                        Li3.Visible = false;
                        Li2.Visible = false;
                        Li4.Visible = false;
                    }
                    else
                    {
                        equipDiv.Visible = true;
                        nav3.Visible = false;
                    }
                    
                }

                if (!function.CheckLevel("Department", Session["UserPrivilegeId"].ToString()))
                {
                        nav0.Visible = false;
                        //nav6.Visible = false;
                        Li3.Visible = false;
                        Li4.Visible = false;
                }
                
            }
        }
        public string UserName()
        {
            return Session["UserName"].ToString();
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            string filePath = "D:/log/login/Login_log";
            string IPAddress = ClaimFunction.GetIP();
            string TimeNoww = DateTime.Now.ToString("HH:mm");
            string DateNoww = DateTime.Now.ToString("dd-MM") + "-" + (DateTime.Now.Year + 543);
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n" + DateNoww + " " + TimeNoww + " User:" + Session["User"].ToString() + " IP:" + IPAddress + " Logout_Success");
            File.AppendAllText(filePath + "_" + DateNoww + ".txt", sb.ToString());
            sb.Clear();

            Session.Abandon();
            Session.Clear();
            Session.Contents.RemoveAll();
            Session.RemoveAll();
            Response.Cookies["ClaimLogin"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/");

            
        }

        protected void txtUrlchk_TextChanged(object sender, EventArgs e)
        {
          /*  if(txtUrlchk.Text == "/Claim/claimDetailForm")
            {
                navchk = "claim";
            }
            else
            {

            } */

        }

        private void URLchanges ()
        {

        }
    }
}