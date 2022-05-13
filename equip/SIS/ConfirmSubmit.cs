using System;
using System.IO;
using System.Windows.Forms;

namespace TIS
{
    public partial class ConfirmSubmit : Form
    {
        MenuForm menuForm = null;
        public bool ReturnForm { get; set; }
        public ConfirmSubmit(Form callingForm)
        {
            InitializeComponent();
            menuForm = callingForm as MenuForm;
            //menuForm.Enabled = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            next();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            menuForm.Enabled = true;
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                next();
            }
        }
        private void next()
        {
            Script script = new Script();
            FileInfo DirInfo = new FileInfo(new Script().file_conf);
            if (!DirInfo.Exists)
            {
                if (textBox1.Text == "admin25")
                {
                    ReturnForm = true;
                    //menuForm.Enabled = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("รหัสไม่ถูกต้อง", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (script.GetPrivilege(textBox1.Text.Trim()) == 1)
                {
                    ReturnForm = true;
                    StreamWriter logAdmin = null;
                    DirInfo = new FileInfo(script.adminlog);
                    if (!DirInfo.Exists)
                    {
                        logAdmin = new StreamWriter(script.adminlog, true);
                        logAdmin.WriteLine("login:" + textBox1.Text + "--date:" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                        logAdmin.Close();
                    }
                    else
                    {
                        logAdmin = File.AppendText(script.adminlog);
                        logAdmin.WriteLine("login:" + textBox1.Text + "--date:" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                        logAdmin.Close();
                    }
                    //menuForm.Enabled = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("คุณไม่มีสิทธิ์ในการตั้งค่ระบบ หรือ รหัสไม่ถูกต้อง", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ConfirmSubmit_Load(object sender, EventArgs e)
        {
            FileInfo DirInfo = new FileInfo(new Script().file_conf);
            if (!DirInfo.Exists)
            {
                label1.Text = "กรุณาใส่รหัส การตั้งค่า";
            }
            else
            {
                label1.Text = "กรุณาใส่รหัส Admin";
            }
        }

        private void ConfirmSubmit_FormClosed(object sender, FormClosedEventArgs e)
        {
            menuForm.btn_setting.Enabled = false;
           // menuForm.btn_setting.Visible = false;
        }
    }
}
