using MySql.Data;
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
    public partial class EmpSendMoneyForm : Form
    {
        MenuForm mainForm = null;
        public EmpSendMoneyForm(Form callingForm)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                next();
            }
            else
            {
                MessageBox.Show("กรุณาใส่รหัสูพนักงาน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Focus();
            }
        }

        private void next()
        {
            bool chk_back_money = false;
            string sql = "SELECT * FROM tbl_income JOIN tbl_emp ON tbl_income_emp_id = tbl_emp_id WHERE tbl_emp_id = '" + textBox1.Text + "' AND tbl_income_status_backmaney = '0'";
            ConnectDB contxt = new ConnectDB();
            MySqlConnection conn = new MySqlConnection();
            conn = new MySqlConnection(contxt.context());
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    BackMoneyForm backMoneyForm = new BackMoneyForm(mainForm,textBox1.Text);
                    this.Close();
                    backMoneyForm.ShowDialog();
                }
                else
                {
                    chk_back_money = true;
                }
                reader.Close();

                if (chk_back_money)
                {
                    sql = "SELECT * FROM tbl_income JOIN tbl_emp ON tbl_income_emp_id = tbl_emp_id WHERE tbl_emp_id = '" + textBox1.Text + "' AND tbl_income_status_backmaney = '1' AND tbl_income_bank IS NULL";
                    cmd = new MySqlCommand(sql, conn);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        //MessageBox.Show("คืนเงินแล้ว");
                        SendMoneyForm sendMoneyForm = new SendMoneyForm(mainForm,textBox1.Text);
                        sendMoneyForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบข้อมูล หรืออาจจะนำส่งรายได้ไปแล้ว", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox1.Clear();
                        textBox1.Focus();
                    }
                }
            }
            catch
            {
                //MessageBox.Show(e.ToString());
            }
            conn.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                next();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Script().CheckNumber(e);
        }
    }
}
