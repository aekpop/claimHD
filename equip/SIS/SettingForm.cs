using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace TIS
{
    public partial class SettingForm : Form
    {
        MenuForm maniForm = null;
        Script script = new Script();
        AdminScript adminScript = new AdminScript();
        public SettingForm(Form callingForm)
        {
            InitializeComponent();
            maniForm = callingForm as MenuForm;
            //maniForm.Enabled = false;
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        private void SettingForm_Load(object sender, EventArgs e)
        {
            FileInfo DirInfo1 = new FileInfo(script.file_conf);
            if (DirInfo1.Exists)
            {
                string[] server = File.ReadAllText(@script.file_conf).Replace("\r", "").Split(';');
                txt_server.Text = server[0].Split('=')[1];
                txt_database.Text = server[1].Split('=')[1];
                txt_user.Text = server[2].Split('=')[1];
                txt_pass.Text = server[3].Split('=')[1];
                groupBox3.Enabled = true;
                groupBox2.Enabled = true;
                FileInfo DirInfo3 = new FileInfo(script.file_Straps);
                if (DirInfo3.Exists)
                {
                    string[] straps = File.ReadAllText(@script.file_Straps).Split('|');
                    txt_straps_start.Text = straps[0];
                    txt_straps_end.Text = straps[1];
                }
                GetCPoint();

                FileInfo DirInfo2 = new FileInfo(script.file_cpoint);
                if (DirInfo2.Exists)
                {
                    string[] cpoint = File.ReadAllText(@script.file_cpoint).Split('|');
                    txt_cpoint.Text = cpoint[0];
                    cb_sub_cpoint.Text = cpoint[1];
                    txt_cpoint_sub.Text = cpoint[1];
                    if (cpoint[2] == "1") { ceb_turakan.Checked = true; }
                    if (cpoint[3] == "9") { chk_tsb.Checked = true; }
                    //btn_back_user_fine.Enabled = false;
                    GetCPoint();
                    cb_sub_cpoint.Text = cpoint[1];
                }
            }
            //txt_server.Focus();
            //maniForm.btn_setting.Enabled = false;
            string ipAdd = GetLocalIPAddress().Split('.')[0] + "." + GetLocalIPAddress().Split('.')[1] + "." + GetLocalIPAddress().Split('.')[2];
            if (ipAdd == "192.168.101")
            {
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
            }
            else
            {
                //button4.Enabled = false;
                //button5.Enabled = false;
                //button6.Enabled = false;
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            StreamWriter file = File.AppendText(new Script().adminlog);
            file.WriteLine("--->setting --->Close" + "--date:" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            file.Close();
            maniForm.Enabled = true;
            this.Close();
        }

        private void txt_cpoint_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txt_cpoint.Text.Length == 3)
                {
                    GetCPoint();
                    if (txt_cpoint.Text.Substring(0, 1) == "9")
                    {
                        chk_tsb.Checked = true;
                    }
                    else
                    {
                        chk_tsb.Checked = false;
                    }
                }
            }
            catch { }
        }

        private void btn_save_cpoint_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void GetCPoint()
        {
            string sql = "SELECT * FROM tbl_cpoint WHERE tbl_cpoint_id = '" + txt_cpoint.Text + "'";
            MySqlDataReader reader = script.Select_SQL(sql);
            if (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    txt_cpoint_name.Text = reader.GetString("tbl_cpoint_name");
                    txt_server.Text = reader.GetString("tbl_cpoint_host");
                    txt_database.Text = reader.GetString("tbl_cpoint_database");
                    txt_user.Text = reader.GetString("tbl_cpoint_user");
                    txt_pass.Text = reader.GetString("tbl_cpoint_pass");
                    string get_sub = "SELECT * FROM tbl_cpoint_sub WHERE tbl_cpoint_sub_cid = '" + txt_cpoint.Text + "'";
                    reader.Close();
                    reader = script.Select_SQL(get_sub);
                    cb_sub_cpoint.Items.Clear();
                    cb_sub_cpoint.Text = "";
                    while (reader.Read())
                    {
                        cb_sub_cpoint.Enabled = true;
                        cb_sub_cpoint.Items.Add(reader.GetString("tbl_cpoint_sub_id"));
                    }
                    reader.Close();
                    //txt_manager.Text = reader.GetString("tbl_prefix_name") + " " + reader.GetString("tbl_emp_name") + "   " + reader.GetString("tbl_emp_lname");
                }
            }
            else
            {
                txt_cpoint_name.Text = "ไม่พบข้อมูล";
                txt_cpoint.Clear();
            }

        }

        private void txt_bag_start_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script scriptCode = new Script();
            scriptCode.CheckNumber(e);
        }

        private void txt_bag_end_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script scriptCode = new Script();
            scriptCode.CheckNumber(e);
        }

        private void txt_cpoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script scriptCode = new Script();
            scriptCode.CheckNumber(e);
        }

        private void txt_cpoint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save();
            }
        }

        private void Save()
        {
            if (txt_cpoint.Text != "" && cb_sub_cpoint.Text != "")
            {
                //MessageBox.Show(txt_cpoint.Text);
                File.Delete(script.file_cpoint);
                StreamWriter file = new StreamWriter(script.file_cpoint, true);
                string turakan = "0";
                string line9 = "7";
                if (ceb_turakan.Checked)
                {
                    turakan = "1";
                }
                if (chk_tsb.Checked)
                {
                    line9 = "9";
                }
                file.WriteLine(txt_cpoint.Text + "|" + cb_sub_cpoint.Text + "|" + turakan + "|" + line9 + "|");
                file.Close();
                MessageBox.Show("ตั้งค่าด่านสำเร็จ", "ผลลัพธ์", MessageBoxButtons.OK, MessageBoxIcon.Information);
                file = File.AppendText(new Script().adminlog);
                file.WriteLine("--->setting --->check point" + "--Detail:" + txt_cpoint.Text + "--date:" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                file.Close();
                //Application.Restart();
                //maniForm.MenuForm_Load(null, null);
                //this.Close();
            }
            else
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string serverName = txt_server.Text.Trim(); // Address server (for local database "localhost")
                string userName = txt_user.Text.Trim();  // user name
                string dbName = txt_database.Text.Trim(); //Name database
                string port = "3306"; // Port for connection
                string password = txt_pass.Text.Trim(); // Password for connection 
                string conStr = "server=" + serverName +
                           ";user=" + userName +
                           ";database=" + dbName +
                           ";port=" + port +
                           ";password=" + password + ";";

                using (MySqlConnection con = new MySqlConnection(conStr))
                {
                    string sql0 = "SELECT @@IDENTITY"; //any request for cheking
                    MySqlCommand cmd0 = new MySqlCommand(sql0, con);
                    con.Open();
                    cmd0.ExecuteScalar();

                    MessageBox.Show("Connection True.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // label 
                    con.Close();
                    button2.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Connection False.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_server.Text != "" && txt_database.Text != "" && txt_user.Text != "" && txt_pass.Text != "")
            {
                StreamWriter file = new StreamWriter(script.file_conf);
                string server = "server=" + txt_server.Text.Trim() + ";database=" + txt_database.Text.Trim() + ";uid=" + txt_user.Text.Trim() + ";pwd=" + txt_pass.Text.Trim() + ";charset=utf8;";
                file.WriteLine(server);
                file.Close();
                MessageBox.Show("บันทึกการการเชื่อมต่อสำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                file = File.AppendText(new Script().adminlog);
                file.WriteLine("--->setting --->Database: " + server + "--date:" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                file.Close();
                //maniForm.MenuForm_Load(null, null);
                //Application.Restart();
                //this.Close();
            }
            else
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_save_straps_Click(object sender, EventArgs e)
        {
            if (txt_straps_start.Text != "" && txt_straps_end.Text != "")
            {
                //MessageBox.Show(txt_cpoint.Text);
                StreamWriter file = new StreamWriter(script.file_Straps);
                file.WriteLine(txt_straps_start.Text + "|" + txt_straps_end.Text + "|");
                file.Close();
                MessageBox.Show("ตั้งค่าสายรัดสำเร็จ", "ผลลัพธ์", MessageBoxButtons.OK, MessageBoxIcon.Information);
                file = File.AppendText(new Script().adminlog);
                file.WriteLine("--->setting --->straps setting" + "--Detail:" + txt_straps_start.Text + "-" + txt_straps_end.Text + "--date:" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                file.Close();
                //maniForm.MenuForm_Load(null, null);
                //Application.Restart();
                //this.Close();
            }
            else
            {
                MessageBox.Show("กรุณาใส่หมายเลขสายรัดเริ่มต้น และหมายเลขสายรัดสิ้นสุด", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_straps_start_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_straps_end_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void cb_sub_cpoint_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_save_cpoint_Click(null, null);
            }
        }

        private void txt_straps_end_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_save_straps_Click(null, null);
            }
        }

        private void SettingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //maniForm.btn_setting.Enabled = false;
            Application.Restart();
        }

        private void cb_sub_cpoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_cpoint_sub.Text = cb_sub_cpoint.Text;
        }

        private void cb_sub_cpoint_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void btn_back_user_fine_Click(object sender, EventArgs e)
        {
            /*ImportPrevious import = new ImportPrevious(maniForm);
            import.ShowDialog();*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminMenuForm adminMenu = new AdminMenuForm("");
            adminMenu.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addEmpForm addEmp = new addEmpForm();
            addEmp.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            editEmpForm empForm = new editEmpForm();
            empForm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            exportDateForm exportDate = new exportDateForm();
            exportDate.ShowDialog();
        }

        private void txt_straps_start_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
