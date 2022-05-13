using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TIS
{
    public partial class RefunForm : Form
    {
        Script script = new Script();
        MenuForm mainForm = null;
        public string user = "0";
        public string fine = "0";
        public string[] data = null;
        public int income_id = 0;
        public RefunForm(Form callingForm)
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

        private void RefunForm_Load(object sender, EventArgs e)
        {
            date_value.CustomFormat = "dd-MM-yyyy";
        }

        private void rdo_fine_CheckedChanged(object sender, EventArgs e)
        {
            txt_fine.Enabled = true;
            txt_user.Enabled = false;
            txt_user.Text = "0";
            txt_fine.Text = "140";
            txt_fine.ReadOnly = true;
        }

        private void rdo_user_CheckedChanged(object sender, EventArgs e)
        {
            txt_user.Enabled = true;
            txt_fine.Enabled = false;
            txt_user.Text = "0";
        }

        private void date_value_ValueChanged(object sender, EventArgs e)
        {
            ClearData();
            DateTime d1 = DateTime.ParseExact(date_value.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime d2 = DateTime.Today;
            TimeSpan dt = d2 - d1;
            txt_job.Enabled = false;
            txt_job.Items.Clear();
            cb_cb.Enabled = false;
            cb_cb.Items.Clear();
            if (dt.Days > 30)
            {
                MessageBox.Show("เกินกำหนดรับเงินคืนมาแล้ว " + (dt.Days - 30) + " วัน \r\n เงินถูกส่งเป็นรายได้แผ่นดินไปแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cb_around.Enabled = false;
            }
            else { cb_around.Enabled = true;  GetEmp(); }

        }

        private void cb_around_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetEmp();
            txt_job.Enabled = false;
            txt_job.Items.Clear();
            cb_cb.Enabled = false;
            cb_cb.Items.Clear();
            ClearData();
        }

        private void GetEmp()
        {
            ClearData();
            if (cb_around.Text != "เลือก")
            {
                cb_emp_name.Items.Clear();
                string date_select = date_value.Text;
                string sql = "SELECT * FROM tbl_income JOIN tbl_emp ON tbl_income_emp_id = tbl_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id WHERE (tbl_income_user <> '0' OR tbl_income_fine <> '0') AND tbl_status_around_date = '" + date_select + "' AND tbl_status_around_aid = '" + cb_around.Text + "' AND tbl_status_around_cpoint_id = '"+mainForm.cpoint_id+"'";
                //MessageBox.Show(sql);
                ConnectDB contxt = new ConnectDB();
                MySqlConnection conn = new MySqlConnection();
                conn = new MySqlConnection(contxt.context());
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    //cb_emp_name.SelectedIndex = 0;
                    int i = 0;
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            if (i == 0)
                            {
                                cb_emp_name.Text = "เลือกพนักงานที่ทำรายการ";
                                //txt_job.Text = "เลือกงาน";
                            }

                            cb_emp_name.Items.Add(reader.GetString("tbl_emp_id") +" : " + reader.GetString("tbl_emp_name"));
                            //txt_job.Items.Add(reader.GetString("tbl_income_job"));
                            cb_emp_name.Enabled = true;
                            //txt_job.Enabled = true;
                        }
                        i++;
                    }
                    if (i == 0)
                    {
                        cb_emp_name.Items.Clear();
                        cb_emp_name.Enabled = false;
                    }

                    reader.Close();
                }
                catch
                {

                }
                conn.Close();
            }
        }

        private void cb_emp_name_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void cb_emp_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearData();
            string sql = "SELECT `tbl_income_cabinet` FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` WHERE (tbl_income_user <> '0' OR tbl_income_fine <> '0') AND `tbl_status_around_date` = '" + date_value.Text + "' AND `tbl_status_around_aid` = '" + cb_around.Text + "' AND `tbl_income_emp_id` = '" + cb_emp_name.Text.Split(':')[0].Trim() +"'";
            MySqlDataReader rs = script.Select_SQL(sql);
            cb_cb.Items.Clear();
            txt_job.Items.Clear();
            txt_job.Enabled = false;
            cb_cb.Text = "เลือก";
            while (rs.Read())
            {
                cb_cb.Items.Add(rs.GetString("tbl_income_cabinet"));
                cb_cb.Enabled = true;
            }
            rs.Close();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if ((rdo_fine.Checked == true || rdo_user.Checked == true) && (txt_fine.Text != "" || txt_user.Text != ""))
            {
                if (Int32.Parse(txt_fine.Text) <= Int32.Parse(fine) && Int32.Parse(txt_user.Text) <= Int32.Parse(user))
                {
                    if (MessageBox.Show("ยืนยันข้อมูลคืนเงินผู้ใช้ทาง\r\n"+(rdo_fine.Checked?rdo_fine.Text:rdo_user.Checked?rdo_user.Text:"")+" จำนวน "+ (rdo_fine.Checked ? txt_fine.Text : rdo_user.Checked ? txt_user.Text : "") + " บาท", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //groupBox1.Enabled = false;
                        if ((rdo_fine.Checked == true || rdo_user.Checked == true) && (txt_fine.Text != "" || txt_user.Text != ""))
                        {
                            ConfirmRefunForm confirmRefun = new ConfirmRefunForm(this, mainForm);
                            confirmRefun.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("กรุณาเลือกรายการที่คืนเงินผู้ใช้ทาง และใส่จำนวนเงินให้ถูกต้อง", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("จำนวนเงินไม่ถูกต้อง","",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกรายการที่คืนเงินลูกค้า และใส่จำนวนเงินให้ถูกต้อง", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void txt_fine_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script scriptCode = new Script();
            scriptCode.CheckNumber(e);
        }

        private void txt_user_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script scriptCode = new Script();
            scriptCode.CheckNumber(e);
        }
        private void ClearData()
        {
            //cb_emp_name.Items.Clear();
            rdo_user.Enabled = false;
            rdo_fine.Enabled = false;
            rdo_user.Checked = false;
            rdo_fine.Checked = false;
            lb_user.Visible = false;
            lb_fine.Visible = false;
            txt_fine.Enabled = false;
            txt_user.Enabled = false;
            txt_user.Text = "0";
            txt_fine.Text = "0";
        }

        private void txt_job_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show((txt_job.SelectedItem as ComboboxItem).Value.ToString());
            ClearData();
            data = cb_emp_name.SelectedItem.ToString().Split(':');
            string sql = "SELECT * FROM tbl_income JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id WHERE (tbl_income_user <> '0' OR tbl_income_fine <> '0') AND tbl_income_emp_id = '" + data[0].Trim() + "' AND tbl_status_around_aid = '" + cb_around.Text + "' AND tbl_income_job = '" + txt_job.Text + "' AND tbl_status_around_date = '"+ date_value.Text + "'";
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
                    if (!reader.IsDBNull(10))//10 = tbl_income_user
                    {
                        user = reader.GetString("tbl_income_user");
                    }
                    else { user = "0"; }
                    if (!reader.IsDBNull(11))// 11 = tbl_income_fine
                    {
                        fine = reader.GetString("tbl_income_fine");
                    }
                    else { fine = "0"; }

                    rdo_user.Enabled = Int32.Parse(user) > 0 ? true : false;
                    rdo_fine.Enabled = Int32.Parse(fine) > 0 ? true : false;

                    lb_user.Text = "( มีเงินในระบบ : " + user + " บาท )";
                    lb_fine.Text = "( มีเงินในระบบ : " + fine + " บาท )";
                    lb_user.Visible = true;
                    lb_fine.Visible = true;
                    
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            conn.Close();
        }

        private void txt_job_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void cb_around_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void date_value_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void txt_fine_Validating(object sender, CancelEventArgs e)
        {

        }

        private void cb_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearData();
            if (cb_cb.Text != "เลือก")
            {
                txt_job.Items.Clear();
                string date_select = date_value.Text;
                string sql = "SELECT tbl_income_id,tbl_income_job FROM tbl_income JOIN tbl_emp ON tbl_income_emp_id = tbl_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id WHERE (tbl_income_user <> '0' OR tbl_income_fine <> '0') AND `tbl_status_around_date` = '" + date_value.Text + "' AND `tbl_status_around_aid` = '" + cb_around.Text + "' AND `tbl_income_emp_id` = '" + cb_emp_name.Text.Split(':')[0].Trim() + "' AND tbl_income_cabinet = '"+cb_cb.Text+"'";
                //MessageBox.Show(sql);
                MySqlDataReader reader = script.Select_SQL(sql);
                try
                {
                    //cb_emp_name.SelectedIndex = 0;
                    int i = 0;
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            if (i == 0)
                            {
                                //cb_emp_name.Text = "เลือกพนักงานที่ทำรายการ";
                                txt_job.Text = "เลือกงาน";
                            }

                            //cb_emp_name.Items.Add(reader.GetString("tbl_emp_id") + " : " + reader.GetString("tbl_status_around_id") + " : " + reader.GetString("tbl_emp_name"));
                            ComboboxItem item = new ComboboxItem(reader.GetString("tbl_income_job"), reader.GetString("tbl_income_id"));
                            txt_job.Items.Add(item);
                            //txt_job.Items.Add(reader.GetString("tbl_income_job"));
                            //cb_emp_name.Enabled = true;
                            txt_job.Enabled = true;
                        }
                        i++;
                    }
                    if (i == 0)
                    {
                        txt_job.Items.Clear();
                        txt_job.Enabled = false;
                    }

                    reader.Close();
                }
                catch
                {

                }
            }
        }

        private void cb_cb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
