using ClaimProject.Config;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace ClaimProject
{
    public partial class Login : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();

        private string IPAddress;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string sql = "SELECT * FROM tbl_cpoint WHERE cpoint_login = '1' ORDER BY cpoint_id";
                function.getListItem(txtCpoint, sql, "cpoint_name", "cpoint_id");
                string sqlp = "SELECT * FROM tbl_annex ";
                function.getListItem(txtPoint, sqlp, "Annex_name", "Annex_id");
            }
        }

        private void MsgBox(string message)
        {
            msgBox.Text = "<div class='alert alert-danger' style='font-size:large;'><strong>ผิดพลาด! </strong><br/>" + message + "</div>";
        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string filePath = "D:/log/login/Login_log";
            string TimeNoww = DateTime.Now.ToString("HH:mm");
            string DateNoww = DateTime.Now.ToString("dd-MM") + "-" + (DateTime.Now.Year + 543);
            string IPAddress = GetIP();
            string mess = "";
            if (txtUser.Text.Trim() == "")
            {
                sb.Append("\r\n" + DateNoww + " " + TimeNoww + " IP:" + IPAddress + " Login_Failure");
                // flush every 20 seconds as you do it
                File.AppendAllText(filePath +  "_" + DateNoww + ".txt" , sb.ToString());
                sb.Clear();
                mess += "- กรุณาป้อน Username<br/>";
            }

            if (txtPass.Text.Trim() == "")
            {
                sb.Append("\r\n" + DateNoww + " " + TimeNoww + " User:" + txtUser.Text.Trim() + " IP:" + IPAddress + " Login_Failure");
                // flush every 20 seconds as you do it
                File.AppendAllText(filePath + "_" + DateNoww + ".txt", sb.ToString());
                sb.Clear();
                mess += "- กรุณาป้อน Password<br/>";
            }

            if (mess == "")
            {
                string sql = "SELECT * FROM tbl_user WHERE username ='" + txtUser.Text.Trim() + "' AND PASSWORD = '" + txtPass.Text.Trim() + "' AND delete_status = '0' ";
                MySqlDataReader rs = function.MySqlSelect(sql);
                if (rs.Read())
                {
                    if (!rs.IsDBNull(0))
                    {
                        string cpoint = "";
                        string point = "";
                        if (rs.GetString("user_cpoint") == "0")
                        {
                            cpoint = "0";
                        }
                        else
                        {
                            if (rs.GetString("level") == "5" && rs.GetString("user_cpoint") == "1")
                            {
                                cpoint = rs.GetString("cpoint_id");
                            }
                            else
                            {
                                cpoint = txtCpoint.SelectedValue;
                                if (cpoint == "703" || cpoint == "704" || cpoint == "706" || cpoint == "707" || cpoint == "708" || cpoint == "709")
                                {
                                    point = txtPoint.SelectedValue;
                                }
                                else
                                {
                                    point = " ";
                                }
                            } 
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
                        Session.Add("user_cpoint", rs.GetString("user_cpoint"));
                        Session.Add("alert", "");

                        string userrr = txtUser.Text;
                        if (userrr == "lbmotorway")
                        {
                            cpoint = "701";
                        }
                        else if(userrr == "bbmotorway")
                        {
                            cpoint = "702";
                        }
                        else if (userrr == "bkmotorway")
                        {
                            cpoint = "703";
                        }
                        else if (userrr == "pnmotorway")
                        {
                            cpoint = "704";
                        }
                        else if (userrr == "bgmotorway")
                        {
                            cpoint = "706";
                        }
                        else if (userrr == "bpmotorway")
                        {
                            cpoint = "707";
                        }
                        else if (userrr == "nkmotorway")
                        {
                            cpoint = "708";
                        }
                        else if (userrr == "pomotorway")
                        {
                            cpoint = "709";
                        }
                        else if (userrr == "pymotorway")
                        {
                            cpoint = "710";
                        }
                        else if (userrr == "hymotorway")
                        {
                            cpoint = "711";
                        }
                        else if (userrr == "kcmotorway")
                        {
                            cpoint = "712";
                        }
                        else if (userrr == "utmotorway")
                        {
                            cpoint = "713";
                        }
                        else if (userrr == "tc1motorway")
                        {
                            cpoint = "902";
                        }
                        else if (userrr == "tc2motorway")
                        {
                            cpoint = "903";
                        }
                        else if (userrr == "ty1motorway")
                        {
                            cpoint = "904";
                        }
                        else if (userrr == "ty2motorway")
                        {
                            cpoint = "905";
                        }

                        
                        Session.Add("UserCpoint", cpoint);
                        Session.Add("Userpoint", point);
                        Session.Timeout = 28800;

                        

                        //Response.Charset = "UTF-8";
                        HttpCookie newCookie = new HttpCookie("ClaimLogin");
                        newCookie["User"] = txtUser.Text;
                        newCookie["UserName"] = rs.GetString("name");
                        newCookie["UserPrivilegeId"] = rs.GetString("level");
                        newCookie["UserPrivilege"] = function.GetLevel(int.Parse(rs.GetString("level")));
                        newCookie["UserCpoint"] = cpoint;
                        newCookie["Userpoint"] = point;
                        //newCookie.Expires = DateTime.Now.AddDays(1);
                        newCookie.Expires = DateTime.Now.AddSeconds(30);
                        Response.Cookies.Add(newCookie);
                        //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language = 'javascript'>alert('dd')</script>");

                        sb.Append("\r\n" + DateNoww + " " + TimeNoww + " User:" + Session["User"].ToString() + " Cp:" + cpoint + " p:" + point + " IP:" + IPAddress +" Login_Success");
                        // flush every 20 seconds as you do it
                        File.AppendAllText(filePath + "_" + DateNoww + ".txt", sb.ToString());
                        sb.Clear();

                        if (Session["UserPrivilegeId"].ToString() == "5" )
                        {

                            Response.Redirect("/equip/EquipDefault");
                        }
                        else
                        {
                            Response.Redirect("/");
                        }
                        
                    }
                    else
                    {
                        sb.Append("\r\n" + DateNoww + " " + TimeNoww + " User:" + txtUser.Text.Trim() + " IP:" + IPAddress + " Login_Failure");
                        // flush every 20 seconds as you do it
                        File.AppendAllText(filePath + "_" + DateNoww + ".txt", sb.ToString());
                        sb.Clear();
                        mess += "- Username หรือ Password ไม่ถูกต้อง";
                    }
                }
                else
                {
                    sb.Append("\r\n" + DateNoww + " " + TimeNoww + " User:" + txtUser.Text.Trim() + " IP:" + IPAddress + " Login_Failure");
                    // flush every 20 seconds as you do it
                    File.AppendAllText(filePath + "_" + DateNoww + ".txt", sb.ToString());
                    sb.Clear();
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

        public string GetIPAddress()
        {
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddress = Convert.ToString(IP);
                }
            }
            return IPAddress;
        }

        public static String GetIP()
        {
            String ip =
                HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return ip;
        }
    }
}