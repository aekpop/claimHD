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
    public partial class ConfirmRefunForm : Form
    {
        RefunForm refunForm = null;
        MenuForm mainForm = null;
        public ConfirmRefunForm(Form callingForm,Form callMainForm)
        {
            InitializeComponent();
            refunForm = callingForm as RefunForm;
            refunForm.Enabled = false;
            mainForm = callMainForm as MenuForm;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            refunForm.Enabled = true;
            this.Close();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            next();
        }

        private void txt_emp_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script script = new Script();
            script.CheckNumber(e);
        }

        private void txt_emp_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_emp_id.Text != "")
                {
                    next();
                }
                else
                {
                    MessageBox.Show("กรุณาใส่รหัสเพื่อยืนยัน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void next()
        {
            ConnectDB contxt = new ConnectDB();
            MySqlConnection conn = new MySqlConnection();
            conn = new MySqlConnection(contxt.context());
            MySqlCommand comm = conn.CreateCommand();
            bool check = false;

            string sql_check_emp = "SELECT tbl_emp_id FROM tbl_emp WHERE tbl_emp_id = '"+txt_emp_id.Text+ "' AND (tbl_emp_group_id=3 OR tbl_emp_group_id=7 OR tbl_emp_group_id=4 OR tbl_emp_group_id=10 OR tbl_emp_group_id=11 OR tbl_emp_group_id > 10)";
            comm = new MySqlCommand(sql_check_emp, conn);
            conn.Open();
            MySqlDataReader reader = comm.ExecuteReader();
            if (reader.Read())
            {
                check = true;
            }
            else
            {
                MessageBox.Show("รหัสไม่ถูกต้อง หรือไม่มีสิทธิ์ทำรายการ","",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            conn.Close();

            if (check)
            {
                string sql_insert = "INSERT INTO tbl_refun (tbl_refun_job,tbl_refun_transaction,tbl_refun_amount,tbl_refun_emp,tbl_refun_note,tbl_refun_date) VALUES ('" + (refunForm.txt_job.SelectedItem as ComboboxItem).Value.ToString() + "','" + (refunForm.rdo_fine.Checked ? "ค่าปรับบัตรหาย" : "เงินทอน") + "','" + (refunForm.rdo_fine.Checked ? refunForm.txt_fine.Text : refunForm.txt_user.Text) + "','" + txt_emp_id.Text + "','"+refunForm.txt_note.Text+"',NOW())";
                conn.Open();
                comm.CommandText = sql_insert;
                if (comm.ExecuteNonQuery() > 0)
                {
                    check = true;
                }
                else
                {
                    check = false;
                }
                conn.Close();
                if (check)
                {
                    if (refunForm.rdo_fine.Checked == true)
                    {
                        if (refunForm.txt_fine.Text != "")
                        {
                            if (Int32.Parse(refunForm.txt_fine.Text) <= Int32.Parse(refunForm.fine))
                            {
                                conn.Open();
                                string sql = "UPDATE tbl_income SET tbl_income_fine = '" + (Int32.Parse(refunForm.fine) - Int32.Parse(refunForm.txt_fine.Text)) + "' WHERE tbl_income_id = '" + (refunForm.txt_job.SelectedItem as ComboboxItem).Value.ToString() + "'";
                                comm.CommandText = sql;
                                comm.ExecuteNonQuery();
                                MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "ผลลัพธ์", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                conn.Close();
                                mainForm.Enabled = true;
                                refunForm.Close();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("ยอดเงินที่คืนผู้ใช้ทางมากกว่าเงินในระบบ " + (Int32.Parse(refunForm.txt_fine.Text) - Int32.Parse(refunForm.fine)) + " บาท", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }

                    if (refunForm.rdo_user.Checked == true)
                    {
                        if (refunForm.txt_user.Text != "")
                        {
                            if (Int32.Parse(refunForm.txt_user.Text) <= Int32.Parse(refunForm.user))
                            {
                                conn.Open();
                                string sql = "UPDATE tbl_income SET tbl_income_user = '" + (Int32.Parse(refunForm.user) - Int32.Parse(refunForm.txt_user.Text)) + "' WHERE tbl_income_id = '" + (refunForm.txt_job.SelectedItem as ComboboxItem).Value.ToString() + "'";
                                comm.CommandText = sql;
                                comm.ExecuteNonQuery();
                                MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "ผลลัพธ์", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                conn.Close();
                                refunForm.Close();
                                mainForm.Enabled = true;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("ยอดเงินที่คืนผู้ใช้ทางมากกว่าเงินในระบบ " + (Int32.Parse(refunForm.txt_user.Text) - Int32.Parse(refunForm.user)) + " บาท", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
            }
        }

    }
}
