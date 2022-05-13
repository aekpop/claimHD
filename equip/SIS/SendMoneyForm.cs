using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace TIS
{
    public partial class SendMoneyForm : Form
    {
        public MenuForm mainForm = null;
        string emp_id;
        double total_tmp = 0;
        double chang_tmp = 0;
        double fine_tmp = 0;
        double bank_tmp = 0;
        Script script = new Script();
        public SendMoneyForm(Form callingForm, string emp)
        {
            InitializeComponent();
            mainForm = callingForm as MenuForm;
            emp_id = emp;
            txt_start.Focus();
            chkdate.Text = DateTime.Now.ToString("dd-MM-yyyy");


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script scriptCode = new Script();
            scriptCode.CheckNumber(e);
        }

        private void txt_chang_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script scriptCode = new Script();
            scriptCode.CheckNumber(e);
        }

        private void txt_fine_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script scriptCode = new Script();
            scriptCode.CheckNumber(e);
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (btn_confirm.Text == "ยืนยัน")
            {
                if (txt_start.Text.Length == 5 && txt_end.Text.Length == 5)
                {
                    if (txt_job.Text != "" && txt_bank.Text != "")
                    {
                        if (double.Parse(txt_fine.Text) % 140 != 0)
                        {
                            MessageBox.Show("จำนวนเงินค่าปรับบัตรไม่ถูกต้อง", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //txt_fine.Clear();
                            txt_fine.Focus();
                        }
                        else
                        {

                                string sql_cabinet = "SELECT * FROM tbl_status_cabinet WHERE tbl_status_cabinet_open = '" + txt_cb.Text + "' AND tbl_status_cabinet_job = '" + txt_job.Text + "' AND tbl_status_cabinet_date = '" + chkdate.Text + "' ";//and tbl_status_cabinet_date = Now() tbl_status_cabinet_open = '" + txt_cb.Text + "' AND
                                Script script = new Script();
                                MySqlDataReader rs = script.Select_SQL(sql_cabinet);
                            if (!rs.Read())
                            {
                                groupbox1.Enabled = false;
                                btn_confirm.Text = "ส่งข้อมูล";
                                btn_back.Text = "แก้ไขข้อมูล";
                            }
                            else
                            {

                                MessageBox.Show("เลขที่งานซ้ำ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txt_job.Clear();
                            }
                           


                        }

                    }
                    else
                    {
                        MessageBox.Show("กรุณาข้อมูลให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_job.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("กรุณาป้อน เวลาเข้า และ เวลาออก ให้ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else if (btn_confirm.Text == "ส่งข้อมูล")
            {
                string txt = groupbox1.Text + "\r\n------------------------------------\r\n" + txt_emp_name.Text + "\r\n เวลาปฏิบัติงาน : " + txt_start.Text + " - " + txt_end.Text + "\r\n งานที่ " + txt_job.Text + "  " + "ถุงเงิน : " + txt_bag.Text + "\r\n หมายเลขสายรัด : " + txt_straps.Text + "\r\nจำนวนเงินที่ประกาศยอด :  " + txt_bank.Text + " บาท\r\n------------------------------------";
                if (MessageBox.Show(txt+"\r\nยืนยันข้อมูลถูกต้อง ใช่หรือไม่?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //MessageBox.Show("บันทึกโลด");
                    Script script = new Script();
                    total_tmp = double.Parse(txt_bank.Text) + chang_tmp + fine_tmp;
                    bank_tmp = double.Parse(txt_bank.Text);
                    try
                    {
                        
                        if (script.InsertUpdae_SQL("UPDATE tbl_income SET tbl_income_straps = '" + txt_straps.Text + "',tbl_income_job = '" + txt_job.Text + "', tbl_income_in_time = '" + txt_start.Text + "', tbl_income_out_time = '" + txt_end.Text + "', tbl_income_total = '" + double.Parse(txt_total.Text) + "', tbl_income_bank  = '" + double.Parse(txt_bank.Text) + "',tbl_income_user = '" + chang_tmp + "',tbl_income_fine = '" + fine_tmp + "',tbl_income_cabinet ='"+txt_cb.Text.Trim()+"',tbl_income_money_bag ='"+txt_bag.Text.Trim()+ "',tbl_income_user_tmp = '"+txt_user.Text.Trim()+"',tbl_income_fine_tmp='"+txt_fine.Text.Trim() + "'  WHERE tbl_income_emp_id = '" + emp_id + "' AND tbl_income_status_backmaney = '1' AND tbl_income_status_job = '0' AND tbl_income_id = '" + income_id.Text + "'"))
                        {
                            //MessageBox.Show("UPDATE tbl_straps SET tbl_straps_status = '0',tbl_straps_bag = '" + txt_bag.Text + "' ,tbl_straps_emp_operate = '" + txt_emp_id.Text + "',tbl_straps_emp_control='" + mainForm.emp_control_id + "' WHERE tbl_straps_id = '" + txt_straps_id.Text + "'");
                            if (bank_tmp > 0)
                            {
                                if (script.InsertUpdae_SQL("INSERT INTO tbl_straps (tbl_straps_number,tbl_straps_status,tbl_straps_bag,tbl_straps_emp_operate,tbl_straps_emp_control,tbl_straps_date) VALUES ('" + txt_straps.Text + "','0','" + txt_bag.Text + "' , '" + txt_emp_id.Text + "','" + mainForm.emp_control_id + "',NOW())")) // (script.InsertUpdae_SQL("INSERT INTO tbl_status_cabinet (tbl_status_cabinet_date,tbl_status_cabinet_open,tbl_status_cabinet_job) VALUES (NOW(),'" + txt_cb.Text + "' , '" + txt_job.Text + "'"))
                                {
                                    if (script.InsertUpdae_SQL("INSERT INTO tbl_status_cabinet (tbl_status_cabinet_open,tbl_status_cabinet_job,tbl_status_cabinet_date) VALUES ('" + txt_cb.Text + "' , '" + txt_job.Text + "','" + chkdate.Text + "')"))
                                    {
                                        mainForm.button2.Enabled = true;
                                        mainForm.btn_edit.Enabled = true;
                                        mainForm.Enabled = true;
                                        MessageBox.Show("บันทึกข้อมูล เรียบร้อยแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        script.SaveImages(DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + "_" + txt_emp_id.Text + "_" + txt_straps.Text + "_" + income_id.Text + "_ส่งเงินรายได้.jpg", mainForm.cpoint_id);
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Error SendMoneyForm", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                script.InsertUpdae_SQL("UPDATE tbl_income SET tbl_income_status_job ='1'  WHERE tbl_income_emp_id = '" + emp_id + "' AND tbl_income_status_backmaney = '1' AND tbl_income_status_job = '0' AND tbl_income_id = '" + income_id.Text + "'");
                                MessageBox.Show("บันทึกข้อมูล เรียบร้อยแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error SendMoneyForm", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
            }
        }

        private void group_sendMoney_Enter(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.Text == "ย้อนกลับ")
            {
                mainForm.Enabled = true;
                this.Close();
            }
            else
            {
                groupbox1.Enabled = true;
                btn_back.Text = "ย้อนกลับ";
                btn_confirm.Text = "ยืนยัน";

                txt_bank.TextAlign = HorizontalAlignment.Center;

            }
        }
        private void calculateBank()
        {
            try
            {
                txt_bank.Text = int.Parse(txt_bank.Text).ToString("N", new CultureInfo("en-US"));
            }
            catch (Exception e)
            {
                MessageBox.Show("ป้อนข้อมูลผิดรูปแบบ " + e.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_total_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txt_total.Text == "") { txt_total.Text = "0"; }
            calculateBank();
        }
        private void txt_job_KeyPress(object sender, KeyEventArgs e)
        {

 

        }
        private void txt_job_Validated(object sender, EventArgs e)
        {
            
        }
        private void txt_chang_KeyUp(object sender, KeyEventArgs e)
        {
            calculateBank();
        }

        private void txt_fine_KeyUp(object sender, KeyEventArgs e)
        {
            calculateBank();
        }

        private void txt_job_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void SendMoneyForm_Load(object sender, EventArgs e)
        {
            txt_start.Focus();
            string sql = "SELECT * FROM tbl_income JOIN tbl_emp ON tbl_income_emp_id = tbl_emp_id WHERE tbl_emp_id = '" + emp_id + "' AND tbl_income_status_backmaney = '1' AND tbl_income_status_job = '0'";
            Script script = new Script();
            MySqlDataReader reader = script.Select_SQL(sql);
            try
            {
                if (reader.Read())
                {
                    txt_emp_id.Text = emp_id;
                    txt_emp_name.Text = reader.GetString("tbl_emp_name");
                    txt_bag.Text = reader.GetString("tbl_income_money_bag");
                    txt_cb.Text = reader.GetString("tbl_income_cabinet");
                    chang_tmp = int.Parse(reader.GetString("tbl_income_user"));
                    fine_tmp = int.Parse(reader.GetString("tbl_income_fine"));
                    txt_user.Text = chang_tmp.ToString();
                    txt_fine.Text = fine_tmp.ToString();
                    income_around_id.Text = reader.GetString("tbl_income_around_id");
                    income_id.Text = reader.GetString("tbl_income_id");
                }
                reader.Close();
                script.conn.Close();
            }
            catch
            {
                //MessageBox.Show(e.ToString());
            }
            txt_straps.Text = script.GetStraps(mainForm.emp_control_id);
            txt_straps.ForeColor = Color.Red;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditStrapsForm editStrapsForm = new EditStrapsForm(this, txt_bag.Text, txt_emp_id.Text, mainForm.emp_control_id, txt_straps);
            editStrapsForm.ShowDialog();
        }

        private void txt_start_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Script scriptCode = new Script();
            if (!scriptCode.CheckTime(txt_start.Text))
            {
                MessageBox.Show("รูปแบบเวลาไม่ถูกต้อง ตัวอย่าง 00:00 - 23:59", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_start.Clear();
                txt_start.Focus();
            }
        }

        private void txt_end_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Script scriptCode = new Script();
            if (!scriptCode.CheckTime(txt_end.Text))
            {
                MessageBox.Show("รูปแบบเวลาไม่ถูกต้อง ตัวอย่าง 00:00 - 23:59", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_end.Clear();
                txt_end.Focus();
            }
        }

        private void txt_start_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void txt_emp_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_confirm_Click(null, null);
            }
        }

        private void txt_bank_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txt_over_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_straps_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txt_bank_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_bank.Text, out value))
                txt_bank.Text = String.Format("{0:N2}", value);
            else
                txt_bank.Text = String.Empty;

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_bank.Text, out value))
                txt_bank.Text = String.Format("{0:N2}", value);
            else
                txt_bank.Text = String.Empty;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_fine.Text, out value))
                txt_fine.Text = String.Format("{0:N2}", value);
            else
                txt_fine.Text = String.Empty;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_user.Text, out value))
                txt_user.Text = String.Format("{0:N2}", value);
            else
                txt_user.Text = String.Empty;
        }

        private void txt_bank_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void txt_bank_KeyUp(object sender, KeyEventArgs e)
        {
            //Calculate_total();
        }

        private void txt_user_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                chang_tmp = double.Parse(txt_user.Text);
                //Calculate_total();
                CalculateIncome();
            }
            catch { }
        }

        private void txt_fine_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {
                fine_tmp = double.Parse(txt_fine.Text);
                //Calculate_total();
                CalculateIncome();
            }
            catch { }
        }

        private void edit_user_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txt_user.Enabled)
            {
                txt_user.Enabled = false;
            }
            else
            {
                txt_user.Enabled = true;
            }
        }

        private void edit_fine_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txt_fine.Enabled)
            {
                txt_fine.Enabled = false;
            }
            else
            {
                txt_fine.Enabled = true;
            }
        }

        private void txt_ts2_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateIncome();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_ts2_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_sys_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void textBox2_Leave_1(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_emp_send.Text, out value))
                txt_emp_send.Text = String.Format("{0:N2}", value);
            else
                txt_emp_send.Text = String.Empty;
        }


        private void CalculateIncome()
        {
            try
            {
                double emp_send = double.Parse(txt_emp_send.Text == "" ? "0" : txt_emp_send.Text);
                CalculateTotal();


            }
            catch { }
        }
        private void CalculateTotal()
        {
            try
            {
                bank_tmp = double.Parse(txt_emp_send.Text);

                txt_bank.Text = bank_tmp.ToString("#,##0.00");
                txt_total.Text = txt_total.Text = (chang_tmp + fine_tmp + double.Parse(txt_bank.Text)).ToString("#,##0.00");
            }
            catch { }
        }
        private void CalculateFine()
        {
            try
            {
                double emp_send = double.Parse(txt_emp_send.Text == "" ? "0" : txt_emp_send.Text);
                fine_tmp = double.Parse(txt_fine.Text);
                chang_tmp = double.Parse(txt_user.Text);
            }
            catch { }
        }
        private void txt_sys_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateIncome();
        }

        private void txt_over_ts2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txt_other_ts2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txt_other_sys_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txt_emp_send_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateIncome();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            CalculateIncome();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditStrapsForm editStrapsForm = new EditStrapsForm(this, txt_bag.Text, txt_emp_id.Text, mainForm.emp_control_id, txt_straps);
            editStrapsForm.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txt_fine_Validated(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(txt_fine.Text) % 140 != 0)
                {
                    MessageBox.Show("ค่าปรับบัตรไม่ถูกต้อง");
                    txt_fine.Clear();
                    txt_fine.Focus();
                }
            }
            catch { txt_fine.Text = "0.00"; }
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txt_bag.ReadOnly)
            {
                txt_bag.ReadOnly = false;
            }
            else
            {
                txt_bag.ReadOnly = true;
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txt_cb.ReadOnly)
            {
                txt_cb.ReadOnly = false;
            }
            else
            {
                txt_cb.ReadOnly = true;
            }
        }

        private void txt_bag_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txt_cb_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txt_cb.Text.Length <= 1)
            {
                txt_cb.Text = "0" + (txt_cb.Text == "" ? "0" : txt_cb.Text);
            }
            script.CheckCabinet(txt_cb);
        }

        private void txt_bag_Validated(object sender, EventArgs e)
        {
            if (!txt_bag.ReadOnly)
            {
                if (!script.DuplicateBag(txt_bag.Text, script.GetAroundInt()))
                {
                    MessageBox.Show("ถุงเงินซ้ำ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_bag.Clear();
                }
            }
        }

        private void txt_total_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txt_emp_send_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_straps.Clear();
                txt_emp_send.Text = "0.00";
                txt_emp_send.ReadOnly = true;
                CalculateIncome();
            }
            else
            {
                txt_straps.Text = script.GetStraps(mainForm.emp_control_id);
                txt_emp_send.ReadOnly = false;
                txt_emp_send.Clear();
            }
        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_emp_send_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
