using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace TIS
{
    public partial class EditJobForm : Form
    {
        Script script = new Script();
        MenuForm mainForm = null;
        AdminScript adminScript = new AdminScript();
        public EditJobForm(Form callForm)
        {
            mainForm = callForm as MenuForm;
            InitializeComponent();
        }

        private void EditJobForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                if (script.GetEmpName(textBox2.Text.Trim()) != "ไม่พบข้อมูลพนักงาน")
                {
                    string sql = "select * from tbl_code_edit where tbl_code_name = '" + textBox1.Text + "' and tbl_code_status is Null";
                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        MySqlDataReader rs = adminScript.GetCodeEdit(sql);
                        if (rs.Read())
                        {
                            adminScript.InsertUpdaeCodeEdit("UPDATE tbl_code_edit SET tbl_code_user_emp='" + textBox2.Text + "',tbl_code_date= NOW(),tbl_code_cpoint='" + mainForm.cpoint_id + "',tbl_code_note='" + textBox3.Text + "' where tbl_code_name = '" + textBox1.Text + "'");
                            sql = "SELECT COUNT(*) AS num FROM tbl_code_edit WHERE tbl_code_user_emp = '" + textBox2.Text + "' AND MONTH(tbl_code_date) = MONTH(CURDATE()) AND YEAR(tbl_code_date) = YEAR(CURDATE())";
                            rs = adminScript.GetCodeEdit(sql);
                            if (rs.Read())
                            {
                                MessageBox.Show(script.GetEmpName(textBox2.Text) + " มีประวัติของแก้ไขงานใน " + script.GetMontThai(DateTime.Now.Date).Split(' ')[1] + " ทั้งหมด " + rs.GetString("num") + " ครั้ง\r\n !!ต้องมีความรอบครอบมากขึ้นกว่านี้^^", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                AdminMenuForm adminEdit = new AdminMenuForm(textBox1.Text.Trim());
                                this.Hide();
                                adminEdit.ShowDialog();
                                this.Close();
                            }
                            //
                        }
                        else
                        {
                            MessageBox.Show("รหัสแก้ไขงานไม่ถูกต้อง", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("รหัสรองฯ ไม่ถูกต้อง", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("กรุณาใส่เหตุที่ต้องแก้ไข", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void EditJobForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Shift)
            {
                string getCode_sql = "SELECT * FROM tbl_code_exigent WHERE status=1";
                MySqlDataReader rs = adminScript.GetCodeEdit(getCode_sql);
                if (rs.Read())
                {
                    rs.Close();
                    if (MessageBox.Show("ยืนยัน ขอรหัสแก้ไขฉุกเฉิน!!!", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string code = adminScript.RandomString(6);
                        int i = 0;
                        while (i < 1)
                        {
                            string sql = "SELECT tbl_code_name FROM tbl_code_edit WHERE tbl_code_name='" + code + "'";
                            rs = adminScript.GetCodeEdit(sql);
                            if (!rs.Read())
                            {
                                adminScript.InsertUpdaeCodeEdit("Insert into tbl_code_edit (tbl_code_name) Values ('" + code + "')");
                                i++;
                            }
                            else
                            {
                                code = adminScript.RandomString(6);
                            }

                        }

                        if (i == 1)
                        {
                            textBox1.Text = code;
                            //this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ไม่ได้รับอนุญาติจาก Admin!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
