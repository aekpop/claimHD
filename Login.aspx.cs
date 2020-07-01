using ClaimProject.Config;
using MySql.Data.MySqlClient;
using System;
using System.Net;
using System.Web;

namespace ClaimProject
{
    public partial class Login : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string sql = "SELECT * FROM tbl_cpoint WHERE cpoint_login = '1' ORDER BY cpoint_id";
                function.getListItem(txtCpoint, sql, "cpoint_name", "cpoint_id"); 
            }
        }

        private void MsgBox(string message)
        {
            msgBox.Text = "<div class='alert alert-danger' style='font-size:large;'><strong>ผิดพลาด! </strong><br/>" + message + "</div>";
        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            string mess = "";
            if (txtUser.Text.Trim() == "")
            {
                mess += "- กรุณาป้อน Username<br/>";
            }

            if (txtPass.Text.Trim() == "")
            {
                mess += "- กรุณาป้อน Password<br/>";
            }

            if (mess == "")
            {
                string sql = "SELECT * FROM tbl_user WHERE username ='" + txtUser.Text.Trim() + "' AND PASSWORD = '" + txtPass.Text.Trim() + "'";
                MySqlDataReader rs = function.MySqlSelect(sql);
                if (rs.Read())
                {
                    if (!rs.IsDBNull(0))
                    {
                        string cpoint = "";
                        string userN = rs.GetString("username");
                        if (rs.GetString("user_cpoint") == "0")
                        {
                            cpoint = "0";
                        }
                        else
                        {
                            if(userN == "ty1motorway"){ cpoint = "904"; }
                            else if(userN == "ty2motorway"){ cpoint = "905"; }
                            else if (userN == "tc1motorway") { cpoint = "902"; }
                            else if (userN == "tc2motorway") { cpoint = "903"; }
                            else if (userN == "lbmotorway") { cpoint = "701"; }
                            else if (userN == "bbmotorway") { cpoint = "702"; }
                            else if (userN == "bkmotorway") { cpoint = "703"; }
                            else if (userN == "pnmotorway") { cpoint = "704"; }
                            else if (userN == "bgmotorway") { cpoint = "706"; }
                            else if (userN == "bpmotorway") { cpoint = "707"; }
                            else if (userN == "nkmotorway") { cpoint = "708"; }
                            else if (userN == "pomotorway") { cpoint = "709"; }
                            else if (userN == "pymotorway") { cpoint = "710"; }
                            else if (userN == "utmotorway") { cpoint = "713"; }
                            else { cpoint = txtCpoint.SelectedValue; }
                            
                        }
                        // Storee Session
                        Session.Add("EQAddAlert", "");
                        Session.Add("NewEQPK", "");
                        Session.Add("NewEQPKtype", "");
                        Session.Add("EQLevel",rs.GetString("eq_level"));
                        Session.Add("User", txtUser.Text);
                        Session.Add("UserName", rs.GetString("name"));
                        Session.Add("UserPrivilegeId", rs.GetString("level"));
                        Session.Add("UserPrivilege", function.GetLevel(int.Parse(rs.GetString("level"))));
                        Session.Add("UserCpoint", cpoint);
                        Session.Timeout = 28800;

                        
                        //Response.Charset = "UTF-8";
                        HttpCookie newCookie = new HttpCookie("ClaimLogin");
                        newCookie["User"] = txtUser.Text;
                        newCookie["UserName"] = rs.GetString("name");
                        newCookie["UserPrivilegeId"] = rs.GetString("level");
                        newCookie["UserPrivilege"] = function.GetLevel(int.Parse(rs.GetString("level")));
                        newCookie["UserCpoint"] = cpoint;
                        //newCookie.Expires = DateTime.Now.AddDays(1);
                        newCookie.Expires = DateTime.Now.AddSeconds(30);
                        Response.Cookies.Add(newCookie);
                        //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language = 'javascript'>alert('dd')</script>");
                        if(Session["UserPrivilegeId"].ToString() == "5" )
                        {
                            Response.Redirect("/equip/EquipMain");
                        }
                        else
                        {
                            Response.Redirect("/");
                        }
                        
                    }
                    else
                    {
                        mess += "- Username หรือ Password ไม่ถูกต้อง";
                    }
                }
                else
                {
                    mess += "- Username หรือ Password ไม่ถูกต้อง";
                }
                rs.Close();
                function.Close();
            }

            if (mess != "")
            {
                MsgBox(mess);
            }
            else
            {
                msgBox.Text = "";
            }

        }

        protected void linkDownload_Click(object sender, EventArgs e)
        {
            DownLoad("/Claim/Upload/chrome_installer.exe");
        }

        public void DownLoad(string FName)
        {
            try
            {
                string strURL = FName;
                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("Content-Disposition", "attachment;filename=\"chrome_installer.exe\"");
                byte[] data = req.DownloadData(Server.MapPath(strURL));
                response.BinaryWrite(data);
                response.End();
            }
            catch
            {

            }
        }
    }
}