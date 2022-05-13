using System;
using System.IO;
using System.Windows.Forms;

namespace TIS
{
    public partial class AroundCloseForm : Form
    {
        MenuForm mainForm = null;
        Script script = new Script();
        public AroundCloseForm(Form callingForm)
        {
            InitializeComponent();
            mainForm = callingForm as MenuForm;
        }

        private void next()
        {
            string[] cpointsub = File.ReadAllText(script.file_cpoint).Split('|');
            string[] around = File.ReadAllText(script.file_around).Split('|');
            if (txt_emp_id.Text.Trim() == around[0])
            {
                string sql = "UPDATE tbl_status_around SET tbl_status_around_close = '1' WHERE tbl_status_around_close = '0' AND tbl_status_around_emp_open_id = '" + txt_emp_id.Text + "' AND tbl_status_around_cpoint_sub_id = '"+ cpointsub [1]+ "'";
                if (script.InsertUpdae_SQL(sql))
                {
                    MessageBox.Show("ปิดกะเรียบร้อย", "ผลลัพธ์", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if(around[1] == "1")
                    {
                        string sql2 = "DELETE FROM tbl_status_cabinet";
                        script.InsertUpdae_SQL(sql2);
                    }
                    ReportIncomForm ri = new ReportIncomForm(mainForm);
                    if (mainForm.line9 == "9" || mainForm.cpoint_id == "701" || mainForm.cpoint_id == "702" || mainForm.cpoint_id == "710")
                    {
                        //ri.GetReport(int.Parse(around[1]), around[2], true, true, false);
                    }
                    else
                    {
                        //ri.GetReport(int.Parse(around[1]), around[2], false, true, false);
                    }
                    File.Delete(script.file_around);
                    Application.Restart();
                    
                  }
                else
                {
                    MessageBox.Show("Error", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("รหัสรองผู้เปิด/ปิดกะ ต้องเป็นคนเดียวกัน หรือ รหัสไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_emp_id.Clear();
            }
            script.conn.Close();
        }

        private void AroundCloseForm_Load(object sender, EventArgs e)
        {
            txt_emp_id.Focus();
        }

        private void btn_back_Click_1(object sender, EventArgs e)
        {
            //maniForm.Enabled = true;
            this.Close();
        }

        private void btn_next_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show("ปิดกะ");
            if (txt_emp_id.Text != "")
            {
                next();
            }
            else
            {
                MessageBox.Show("กรุณาใส่รหัสผู้ปิดผลัด", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AroundCloseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_emp_id.Text != "")
                {
                    next();
                }
                else
                {
                    MessageBox.Show("กรุณาใส่รหัสผู้ปิดผลัด", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void txt_emp_id_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Script scriptCode = new Script();
            scriptCode.CheckNumber(e);
        }

        private void txt_emp_id_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_emp_id.Text != "")
                {
                    next();
                }
                else
                {
                    MessageBox.Show("กรุณาใส่รหัสผู้ปิดผลัด", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
