using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TIS
{
    public partial class EmpToEditMoneyForm : Form
    {
        MenuForm mainForm = null;
        Script script = new Script();

        public EmpToEditMoneyForm(Form callingForm)
        {
            InitializeComponent();
            mainForm = callingForm as MenuForm;
            //mainForm.Enabled = false;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            mainForm.Enabled = true;
            this.Close();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (txt_emp_id.Text != "")
            {
                if (script.GetEmpName(txt_emp_id.Text) != "ไม่พบข้อมูลพนักงาน")
                {
                    string sql = "SELECT * FROM `tbl_income` WHERE `tbl_income_status_job` <> '1' AND tbl_income_bank IS NOT NULL AND `tbl_income_emp_id` = '" + txt_emp_id.Text.Trim()+"' ORDER BY `tbl_income_id` DESC";
                    MySqlDataReader reader = script.Select_SQL(sql);
                    if (reader.Read())
                    {
                        EditMoneyForm select = new EditMoneyForm(mainForm, txt_emp_id.Text.Trim());
                        select.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบข้อมูล อาจยังไม่ได้นำส่งรายได้ หรืออาจจะวิเคราะห์งานไปแล้ว!!","",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        txt_emp_id.Clear();
                        txt_emp_id.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("รหัสพนักงานไม่ถูกต้อง!!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_emp_id.Clear();
                }
            }
            else
            {
                MessageBox.Show("กรุณาใส่รหัสพนักงาน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_emp_id.Focus();
            }
        }


        private void txt_emp_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script scriptCode = new Script();
            scriptCode.CheckNumber(e);
        }

        private void txt_emp_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_emp_id.Text != "")
                {
                    btn_next_Click(null, null);
                }
                else
                {
                    MessageBox.Show("กรุณานาใส่รหัสพนักงาน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_emp_id.Focus();
                }
            }
        }

        private void EditMoneyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_emp_id.Text != "")
                {
                    btn_next_Click(null, null);
                }
                else
                {
                    MessageBox.Show("กรุณานาใส่รหัสพนักงาน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_emp_id.Focus();
                }
            }
        }

        private void EmpToEditMoneyForm_Load(object sender, EventArgs e)
        {
            //
        }
    }
}
