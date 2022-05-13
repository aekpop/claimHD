
using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace TIS
{
    public partial class BackMoneyForm : Form
    {
        MenuForm mainForm = null;
        string emp_id = "";
        public BackMoneyForm(Form callingForm, string emp)
        {
            InitializeComponent();
            mainForm = callingForm as MenuForm;
            //mainForm.Enabled = false;
            emp_id = emp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainForm.Enabled = true;
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script script = new Script();
            script.CheckNumber(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script script = new Script();
            script.CheckNumber(e);
        }

        private void txt_emp_id_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (txt_chang.Text != "" || txt_fine.Text != "")
            {
                next();
            }
            else
            {
                MessageBox.Show("กรุณาใส่จำนวนเงินครบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_money.Focus();
            }
        }
        private void next()
        {
            //MessageBox.Show("คืนเงิน");
            if (txt_fine.Text == "")
            {
                txt_fine.Text = "0.00";
            }

            if (double.Parse(txt_fine.Text) % 140 != 0)
            {
                MessageBox.Show("จำนวนเงินค่าปรับบัตรไม่ถูกต้อง", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_fine.Clear();
                txt_fine.Focus();
            }
            else
            {
                if (MessageBox.Show("คืนเงินยืม\r\n" + txt_emp_id.Text + " " + txt_emp_name.Text + "\r\n- จำนวน " + txt_money.Text + " บาท \r\n- เงินผู้ใช้ทางไม่รับเงินทอน " + txt_chang.Text + " บาท \r\n- ค่าปรับบัตรหาย " + txt_fine.Text + " บาท \r\n----------------------\r\nยืนยัน ใช่ หรือ ไม่", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ConnectDB contxt = new ConnectDB();
                    MySqlConnection conn = new MySqlConnection();
                    conn = new MySqlConnection(contxt.context());
                    conn.Open();
                    MySqlCommand comm = conn.CreateCommand();
                    try
                    {
                        comm.CommandText = "UPDATE tbl_income SET tbl_income_user = '" + double.Parse(txt_chang.Text) + "' ,tbl_income_fine = '" + double.Parse(txt_fine.Text) + "' ,tbl_income_status_backmaney = '1' WHERE tbl_income_emp_id = '" + txt_emp_id.Text + "' AND tbl_income_status_backmaney = '0' AND tbl_income_money_bag = '" + txt_bag.Text + "'";
                        comm.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mainForm.Enabled = true;
                        this.Close();
                    }
                    catch
                    {
                        //
                    }
                }
            }
        }

        private void txt_emp_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_money.Text != "")
            {
                next();
            }
            else
            {
                MessageBox.Show("กรุณาใส่จำนวนเงิน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_money.Focus();
            }
        }

        private void txt_money_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_money.Text != "")
            {
                next();
            }
            else
            {
                MessageBox.Show("กรุณาใส่จำนวนเงิน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_money.Focus();
            }
        }

        private void BackMoneyForm_Load(object sender, EventArgs e)
        {
            if(mainForm.line9 == "9")
            {
                label10.Visible = false;
                txt_fine.Visible = false;
                label9.Visible = false;
            }

            string sql = "SELECT * FROM tbl_income JOIN tbl_emp ON tbl_income_emp_id = tbl_emp_id WHERE tbl_emp_id = '" + emp_id + "' AND tbl_income_status_backmaney = '0'";
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
                    txt_emp_id.Text = emp_id;
                    txt_emp_name.Text = reader.GetString("tbl_emp_name");
                    txt_bag.Text = reader.GetString("tbl_income_money_bag");
                    txt_money.Text = String.Format("{0:N2}", double.Parse(reader.GetString("tbl_income_money")));
                    button2.Enabled = true;
                }
                reader.Close();
            }
            catch
            {
                //MessageBox.Show(e.ToString());
            }
        }

        private void txt_chang_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Script().CheckNumber(e);
        }

        private void txt_fine_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Script().CheckNumber(e);
        }

        private void txt_chang_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txt_chang.Text == "") { txt_chang.Text = "0"; }
        }

        private void txt_fine_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txt_fine.Text == "")
            {
                txt_fine.Text = "0";
            }
        }

        private void txt_chang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_chang.Text != "" && txt_fine.Text != "")
                {
                    next();
                }
                else
                {
                    MessageBox.Show("กรุณาใส่จำนวนเงินครบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_money.Focus();
                }
            }
        }

        private void txt_chang_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_chang.Text, out value))
                txt_chang.Text = String.Format("{0:N2}", value);
            else
                txt_chang.Text = String.Empty;
        }

        private void txt_fine_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_fine.Text, out value))
                txt_fine.Text = String.Format("{0:N2}", value);
            else
                txt_fine.Text = String.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ยืนยันการคืนเงินยืม รับเงินคืนเรียบร้อยแล้ว ใช่หรือไม่","",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                groupBox2.Enabled = true;
                btn_next.Enabled = true;
            }
        }
    }
}
