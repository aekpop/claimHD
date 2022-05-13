using System;
using System.Windows.Forms;

namespace TIS
{
    public partial class EditStrapsEmpForm : Form
    {
        MenuForm mainForm = null;
        public EditStrapsEmpForm(Form callForm)
        {
            mainForm = callForm as MenuForm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_emp_name.Text != "ไม่พบข้อมูลการเบิกสายรัด" && txt_emp_name.Text != "ไม่พบข้อมูลสายรัดถุงเงินพิเศษ" && txt_straps_old.Text != "ไม่พบข้อมูลการเบิกสายรัด" && combo_note.Text != "" && txt_straps_old.Text != "")
            {
                string emp_id = txt_emp_id.Text == "" ? "NULL" : txt_emp_id.Text;
                string update_straps_income = "UPDATE tbl_income SET tbl_income_straps = '" + txt_straps_new.Text + "' WHERE tbl_income_id = '" + lb_income_id.Text + "'";
                string update_straps_old = "INSERT INTO tbl_straps (tbl_straps_number,tbl_straps_bag,tbl_straps_emp_operate,tbl_straps_emp_control,tbl_straps_status,tbl_straps_note,tbl_straps_date) VALUES ('" + txt_straps_id_old.Text+"','"+txt_bag.Text+"',"+ emp_id + ",'"+mainForm.emp_control_id+ "','1','" + combo_note.Text + " / " + txt_straps_note.Text + "',NOW())";
                //string update_straps_new = "UPDATE tbl_straps SET tbl_straps_status = '0', tbl_straps_bag = '" + txt_bag.Text + "', tbl_straps_emp_operate = '" + txt_emp_id.Text + "', tbl_straps_emp_control = '" + mainForm.emp_control_id + "' WHERE tbl_straps_id = '" + txt_straps_id_new.Text + "'";
                Script script = new Script();
                if (MessageBox.Show("ยืนยัน บันทึกข้อมูล ใช่หรือไม่", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    script.SaveImages(DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + "_" + emp_id + "_" + txt_straps_id_old.Text+"_old" + "_เปลี่ยนสายรัดหน้าหลัก.jpg",mainForm.cpoint_id);
                    if (script.InsertUpdae_SQL(update_straps_income) && script.InsertUpdae_SQL(update_straps_old))
                    {
                    MessageBox.Show("บันทึกข้อมูลสำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Moneybag.Show();
                    mainForm.Enabled = true;
                    this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_emp_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script script = new Script();
            script.CheckNumber(e);
        }

        private void txt_emp_id_KeyUp(object sender, KeyEventArgs e)
        {
            Script script = new Script();
            if (txt_emp_id.Text.Length > 1)
            {
                script.GetStrapsEmp(txt_emp_id.Text, mainForm.emp_control_id, mainForm.around_num, txt_emp_name, txt_straps_id_old, lb_income_id, txt_straps_old, txt_bag);
                if (txt_emp_name.Text != "ไม่พบข้อมูลการเบิกสายรัด")
                {
                    txt_straps_new.Text = script.GetStraps(mainForm.emp_control_id);
                }
                else
                {
                    txt_straps_new.Text = "";
                }
            }
        }

        private void EditStrapsEmpForm_Load(object sender, EventArgs e)
        {

        }

        private void txt_straps_old_KeyUp(object sender, KeyEventArgs e)
        {
            int radio_check = 0;
            if (radioButton1.Checked) { radio_check = 1; }
            if (radioButton2.Checked) { radio_check = 2; }
            if (radioButton3.Checked) { radio_check = 3; }

            Script script = new Script();
            if (txt_straps_id_old.Text.Length > 5)
            {
                script.GetStraps(txt_emp_id, mainForm.emp_control_id, mainForm.around_num, txt_emp_name, txt_straps_id_old, lb_income_id, txt_straps_old, txt_bag, radio_check);
                if (txt_emp_name.Text != "ไม่พบข้อมูลสายรัด")
                {
                    txt_straps_new.Text = script.GetStraps(mainForm.emp_control_id);
                }
                else
                {
                    txt_straps_new.Text = "";
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void txt_straps_old_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Script().CheckNumber(e);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                txt_emp_id.Clear();
                txt_emp_name.Text = "ถุงเงินพิเศษ";
                txt_straps_old.ReadOnly = false;
                txt_emp_id.Enabled = false;
                txt_straps_old.Clear();
                txt_straps_new.Clear();
                txt_straps_note.Clear();
                txt_straps_old.Focus();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                txt_emp_id.Clear();
                txt_emp_name.Text = "";
                txt_straps_old.ReadOnly = false;
                txt_emp_id.Enabled = false;
                txt_straps_old.Clear();
                txt_straps_new.Clear();
                txt_straps_old.Focus();
                txt_straps_note.Clear();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                txt_emp_id.Clear();
                txt_emp_id.Focus();
                txt_emp_name.Text = "";
                txt_straps_old.ReadOnly = true;
                txt_emp_id.Enabled = true;
                txt_straps_old.Clear();
                txt_straps_new.Clear();
                txt_straps_note.Clear();
            }
        }

        private void combo_note_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
