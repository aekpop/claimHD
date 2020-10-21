using ClaimProject.Config;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Session.Timeout = 28800;
            }

            if (Session["User"] == null)
            {
                Response.Redirect("/Login");
            }
            else
            {
                lbUser.Text = "ยินดีต้อนรับ : " + Session["UserName"].ToString() + " : " + Session["UserPrivilege"] + " " + function.GetSelectValue("tbl_cpoint", "cpoint_id='" + Session["UserCpoint"].ToString() + "'", "cpoint_name" ) +" "+ function.GetSelectValue("tbl_annex", "Annex_id='" + Session["Userpoint"].ToString() + "'", "Annex_name");
                if (function.CheckLevel("Techno", Session["UserPrivilegeId"].ToString()))
                {
                    if(Session["UserPrivilegeId"].ToString() == "4")
                    {
                        nav3.Visible = false;
                        equipDiv.Visible = false;
                        searchEn.Visible = false;
                    }
                    else
                    {
                        nav3.Visible = true;
                    }
                    
                }
                else
                {
                    if(Session["UserPrivilegeId"].ToString() == "5")
                    {
                        nav3.Visible = false;
                        equipDiv.Visible = true;
                        nav0.Visible = false;
                        nav1.Visible = false;
                        Li2.Visible = false;
                        Li1.Visible = false;
                        searchEn.Visible = false;
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
                }
            }
        }
        public string UserName()
        {
            return Session["UserName"].ToString();
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
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