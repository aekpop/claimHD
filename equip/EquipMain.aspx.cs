using ClaimProject.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimProject.equip
{
    public partial class EquipMain : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/");
            }
            if (!this.IsPostBack)
            {
                Session.Add("BackWhat", "");
                Session.Add("LineTran", "");
                Session["BackWhat"] = "";
            }
            if (Session["UserPrivilegeId"].ToString() != "2" && Session["UserPrivilegeId"].ToString() != "4")
            {
                string userrrrr = Session["UserName"].ToString();
               if (Session["UserPrivilegeId"].ToString() == "5")
                {
                  /* if(userrrrr != "นางสาวสาวิตรี  มะโนรัตน์" && userrrrr != "นางสาวสุภาพร ดาราศาสตร์" &&
                        userrrrr != "นางสาววัชรี วงศ์สุรินทร์" && userrrrr != "นางสาวพรวิมล โคมขาว")
                   {*/
                        if (Session["UserCpoint"].ToString() == "0")
                        {
                            divaddnew.Visible = true;
                        }
                        else
                        {
                            divaddnew.Visible = false;
                        }
                 /*   }
                    else
                    {
                        divTransfer.Visible = false;
                        divaddnew.Visible = false;
                    }
                 */   
                    
                }
            }
            else 
            {
                divTransfer.Visible = false;
                divEquip.Visible = false;
            }
        }
    }
}