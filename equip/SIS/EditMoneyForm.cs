using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TIS
{
    public partial class EditMoneyForm : Form
    {
        MenuForm mainForm = null;
        string emp_id = "";
        Script script = new Script();
        double other_money = 0;

        public EditMoneyForm(Form callingForm, string empId)
        {
            InitializeComponent();
            mainForm = callingForm as MenuForm;
            emp_id = empId;
        }

        private void EditMoneyForm_Load(object sender, EventArgs e)
        {
            txt_m_out.Visible = false;
            txt_use_out.Visible = false;
            checkBox2.Visible = false;

            //txt_straps_number.Text = script.GetStraps(mainForm.emp_control_id);
            string sql = "SELECT * FROM `tbl_income` LEFT JOIN `tbl_emp` ON `tbl_income_emp_id`=`tbl_emp_id` WHERE `tbl_income_bank` IS NOT NULL AND `tbl_income_emp_id` = '" + emp_id + "' ORDER BY `tbl_income_id` DESC";
            MySqlDataReader rs = script.Select_SQL(sql);
            if (rs.Read())
            {
                txt_emp_id.Text = emp_id;
                txt_emp_name.Text = rs.GetString("tbl_emp_name");
                txt_bag.Text = rs.GetString("tbl_income_money_bag");
                txt_bc.Text = rs.GetString("tbl_income_cabinet");
                txt_emp_send.Text = double.Parse(rs.GetString("tbl_income_bank")).ToString("#,##0.00");
                lb_around_id.Text = rs.GetString("tbl_income_around_id");
                lb_income_id.Text = rs.GetString("tbl_income_id");
                txt_user.Text = rs.GetString("tbl_income_user");
                txt_fine.Text = rs.GetString("tbl_income_fine");
                lb_bank.Text = rs.GetString("tbl_income_bank");
            }
            if (mainForm.line9 == "7")
            {
                label29.Visible = false;
                txt_ts2.Visible = false;
                label30.Visible = false;
                label26.Visible = false;
                label25.Visible = false;
                label28.Visible = false;
                label27.Visible = false;
                txt_over_ts2.Visible = false;
                txt_other_ts2.Visible = false;
            }
            else
            {
                label23.Visible = false;
                txt_over_sys.Visible = false;
                label24.Visible = false;
            }
            rs.Close();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            mainForm.Enabled = true;
            this.Close();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if ((txt_bag_number.Text != "" && txt_straps_number.Text != "") || (double.Parse(txt_other_ts2.Text) + double.Parse(txt_other_sys.Text) == 0))
            {
                if (!script.DuplicateBag(txt_bag_number.Text, script.GetAroundInt()) && txt_bag_number.Enabled && lb_income_edit.Text == "")
                {
                    MessageBox.Show("ถุงเงินซ้ำ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_bag_number.Clear();
                }
                else
                {
                    if (MessageBox.Show("ยืนยันเพื่อบันทึกข้อมูล ใช่หรือไม่", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (txt_sys.Text == "") { txt_sys.Text = "0"; }
                        if (txt_ts2.Text == "") { txt_ts2.Text = "0"; }
                        string update_income = "UPDATE tbl_income SET tbl_income_over='" + double.Parse(txt_over_ts2.Text) + "',tbl_income_other_ts2='" + double.Parse(txt_other_ts2.Text) + "',tbl_income_over_sys='" + double.Parse(txt_over_sys.Text) + "',tbl_income_other='" + double.Parse(txt_other_sys.Text) + "',tbl_income_status_job = '1',tbl_income_user = '" + double.Parse(txt_user.Text)+ "',tbl_income_fine = '" + double.Parse(txt_fine.Text)+ "',tbl_income_user_tmp = '" + double.Parse(txt_user.Text) + "',tbl_income_fine_tmp = '" + double.Parse(txt_fine.Text) + "',tbl_income_total = '" + (double.Parse(lb_bank.Text)+ double.Parse(txt_fine.Text)+ double.Parse(txt_user.Text)) + "',tbl_income_amount_system ='" + double.Parse(txt_sys.Text) + "',tbl_income_amount_ts2='" + double.Parse(txt_ts2.Text) + "' WHERE tbl_income_id = '" + lb_income_id.Text.Trim() + "' AND tbl_income_emp_id = '" + txt_emp_id.Text.Trim() + "'";
                        script.InsertUpdae_SQL(update_income);
                        MySqlDataReader rs = script.Select_SQL("SELECT SUM(tbl_income_other_ts2) + SUM(tbl_income_other) AS sum FROM tbl_income WHERE tbl_income_around_id = '" + lb_around_id.Text.Trim() + "'");
                        if (rs.Read())
                        {

                            string update_income_edit = "UPDATE tbl_income SET tbl_income_bank='" + rs.GetString("sum") + "' ,tbl_income_total = '" + rs.GetString("sum") + "' WHERE tbl_income_id = '" + lb_income_edit.Text.Trim() + "'";
                            rs.Close();
                            if (script.InsertUpdae_SQL(update_income_edit))
                            {
                                MessageBox.Show("บันทึกข้อมูล สำเร็จ!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                script.SaveImages(DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + "_" + txt_emp_id.Text + "_" + lb_income_id.Text + "_วิเคราะห์งาน.jpg", mainForm.cpoint_id);
                                this.Close();
                            }
                            else
                            {
                                if (double.Parse(txt_other_ts2.Text) + double.Parse(txt_other_sys.Text) > 0)
                                {
                                    
                                    string insert = "INSERT INTO tbl_income (`tbl_income_money_bag`,`tbl_income_straps`,`tbl_income_total`,`tbl_income_bank`,`tbl_income_status_job`,tbl_income_around_id) VALUES ('" + txt_bag_number.Text.Trim() + "','" + txt_straps_number.Text.Trim() + "','" + (double.Parse(txt_other_ts2.Text) + double.Parse(txt_other_sys.Text)) + "','" + (double.Parse(txt_other_ts2.Text) + double.Parse(txt_other_sys.Text)) + "','1','" + lb_around_id.Text.Trim() + "')";
                                    if (script.InsertUpdae_SQL(insert))
                                    {
                                        if (script.InsertUpdae_SQL("INSERT INTO tbl_straps (tbl_straps_number,tbl_straps_status,tbl_straps_bag,tbl_straps_emp_control,tbl_straps_date) VALUES ('" + txt_straps_number.Text.Trim() + "','0','" + txt_bag_number.Text + "' ,'" + mainForm.emp_control_id + "',NOW())"))
                                        {
                                            MessageBox.Show("บันทึกข้อมูล เรียบร้อยแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            script.SaveImages(DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + "_" + txt_emp_id.Text + "_" + lb_income_id.Text + "_วิเคราะห์งาน.jpg", mainForm.cpoint_id);
                                            this.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Error SendMoneyForm", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        /*MessageBox.Show("บันทึกข้อมูล สำเร็จ!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();*/
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("บันทึกข้อมูล สำเร็จ!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    script.SaveImages(DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + "_" + txt_emp_id.Text + "_" + lb_income_id.Text + "_วิเคราะห์งาน.jpg", mainForm.cpoint_id);
                                    this.Close();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            script.conn.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditStrapsForm editStrapsForm = new EditStrapsForm(this, txt_bag_number.Text, emp_id, mainForm.emp_control_id, txt_straps_number);
            editStrapsForm.ShowDialog();
        }

        private void txt_bag_number_KeyUp(object sender, KeyEventArgs e)
        {
            if (!script.DuplicateBag(txt_bag_number.Text, script.GetAroundInt()))
            {
                MessageBox.Show("ถุงเงินซ้ำ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_bag_number.Clear();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txt_emp_send_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txt_over_ts2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txt_ts2_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateIncome();
        }

        private void txt_sys_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateIncome();
           
        }


        private void CalculateIncome()
        {
            try
            {
                double emp_send = double.Parse(txt_emp_send.Text == "" ? "0" : txt_emp_send.Text);
                double ts2_send = double.Parse(txt_ts2.Text == "" ? "0" : txt_ts2.Text);
                double sys_send = double.Parse(txt_sys.Text == "" ? "0" : txt_sys.Text);
                if (radioButton2.Checked)
                {
                    sys_send = 0;
                }
                if (sys_send == ts2_send)
                {
                    CalculateFine();
                    txt_other_sys.Text = "0.00";
                    txt_over_sys.Text = "0.00";
                }
                else
                {
                    if (sys_send > ts2_send)
                    {
                        CalculateFine();
                        txt_other_ts2.Text = "0.00";
                        
                    }
                    else
                    {
                        CalculateFine();
                        txt_other_sys.Text = "0.00";
                    }

                }


                string chk_fine = "SELECT * FROM `tbl_income` WHERE `tbl_income_emp_id` IS NULL AND `tbl_income_around_id` = '" + lb_around_id.Text + "'";
                MySqlDataReader rs = script.Select_SQL(chk_fine);
                if (rs.Read())
                {
                    txt_bag_number.Text = rs.GetString("tbl_income_money_bag");
                    txt_straps_number.Text = rs.GetString("tbl_income_straps");
                    lb_income_edit.Text = rs.GetString("tbl_income_id");
                    txt_bag_number.ReadOnly = true;
                    btn_submit.Enabled = true;
                }
                else if (groupBox1.Visible)
                {
                    txt_straps_number.Text = script.GetStraps(mainForm.emp_control_id);
                    btn_submit.Enabled = true;
                }
                else
                {
                    lb_income_edit.Text = "";
                    btn_submit.Enabled = true;
                }

                if (mainForm.line9 == "7")
                {
                    txt_over_ts2.Text = "0.00";
                    txt_other_ts2.Text = "0.00";
                }
                else
                {
                    txt_over_sys.Text = "0.00";
                    //txt_other_sys.Text = "0.00";
                }

            }
            catch { }


        }


        private void CalculateFine()
        {
            try
            {
                double emp_send = double.Parse(txt_emp_send.Text == "" ? "0" : txt_emp_send.Text);
                double ts2_send = double.Parse(txt_ts2.Text == "" ? "0" : txt_ts2.Text);
                double sys_send = double.Parse(txt_sys.Text == "" ? "0" : txt_sys.Text);
                if (radioButton2.Checked) { sys_send = 0; }

                if ((emp_send - ts2_send) >= 0)
                {
                    txt_other_ts2.Text = "0.00";
                    txt_over_ts2.Text = (emp_send - ts2_send).ToString("#,##0.00");
                    txt_over_ts2.ForeColor = Color.Green;
                    //groupBox1.Visible = false;
                }
                else
                {
                    txt_over_ts2.Text = "0.00";
                    txt_other_ts2.Text = (ts2_send - emp_send).ToString("#,##0.00");
                    txt_other_ts2.ForeColor = Color.Red;
                    //groupBox1.Visible = true;
                }

                if ((emp_send - sys_send) >= 0)
                {
                    txt_other_sys.Text = "0.00";
                    txt_over_sys.Text = (emp_send - sys_send).ToString("#,##0.00");
                    txt_over_sys.ForeColor = Color.Green;
                    //groupBox1.Visible = false;
                }
                else if(!radioButton2.Checked)
                {
                    txt_over_sys.Text = "0.00";
                    txt_other_sys.Text = (sys_send - emp_send).ToString("#,##0.00");
                    txt_other_sys.ForeColor = Color.Red;
                    //groupBox1.Visible = true;
                    if (sys_send < emp_send)
                    {
                        txt_over_ts2.Text = (emp_send - ts2_send).ToString("#,##0.00");
                    }
                    else
                    {
                        txt_over_ts2.Text = (sys_send - ts2_send).ToString("#,##0.00");
                    }
                }
                else
                {
                    txt_other_sys.Text = "0.00";
                    other_money = 0;
                    txt_over_ts2.Text = (ts2_send - emp_send).ToString("#,##0.00");
                }

                if ((double.Parse(txt_other_sys.Text)+ double.Parse(txt_other_ts2.Text))>0)
                {
                    groupBox1.Visible = true;
                    other_money = double.Parse(txt_other_ts2.Text)+ double.Parse(txt_other_sys.Text);
                }
                else
                {
                    groupBox1.Visible = false;
                }

                /*if (radioButton2.Checked)
                {
                    txt_other_sys.Text = "0.00";
                    groupBox1.Visible = false;
                }*/
                if (double.Parse(txt_over_ts2.Text) < 0)
                {
                    txt_over_ts2.Text = "0.00";
                }
            }
            catch { }
        }

        private void txt_straps_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            CalculateIncome();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            CalculateIncome();
        }

        private void txt_ts2_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_ts2.Text, out value))
                txt_ts2.Text = String.Format("{0:N2}", value);
            else
                txt_ts2.Text = String.Empty;
        }

        private void txt_sys_Leave(object sender, EventArgs e)
        {
           Double value;
            if (Double.TryParse(txt_sys.Text, out value))
                txt_sys.Text = String.Format("{0:N2}", value);
            else
                txt_sys.Text = String.Empty;
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txt_bag.Enabled)
            {
                txt_bag.Enabled = false;
            }
            else
            {
                txt_bag.Enabled = true;
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txt_bc.Enabled)
            {
                txt_bc.Enabled = false;
            }
            else
            {
                txt_bc.Enabled = true;
            }
        }

        private void txt_bag_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_bc_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void changDouble(TextBox txt_result)
        {
            Double value;
            if (Double.TryParse(txt_result.Text, out value))
                txt_result.Text = String.Format("{0:N2}", value);
            else
                txt_result.Text = String.Empty;
        }

        private void txt_user_Leave(object sender, EventArgs e)
        {
            changDouble(txt_user);
        }

        private void txt_fine_Leave(object sender, EventArgs e)
        {
            changDouble(txt_fine);
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txt_sys_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_m_out.Visible = true;



            }
            else
            {
                txt_m_out.Visible = false;
                txt_m_out.Text = "";
                CalculateIncome();
            }
        }

        private void txt_m_out_TextChanged(object sender, EventArgs e)
        {
            double m_out = double.Parse(txt_m_out.Text == "" ? "0" : txt_m_out.Text);
            double emp_send = double.Parse(txt_emp_send.Text == "" ? "0" : txt_emp_send.Text);
            double ts2_send = double.Parse(txt_ts2.Text == "" ? "0" : txt_ts2.Text);
            double sys_send = double.Parse(txt_sys.Text == "" ? "0" : txt_sys.Text);
            txt_other_sys.Text = m_out.ToString("#,##0.00");
            txt_over_sys.Text = ((emp_send + m_out) - sys_send).ToString("#,##0.00");
        }

        private void txt_m_out_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_m_out.Text, out value))
                txt_m_out.Text = String.Format("{0:N2}", value);
            else
                txt_m_out.Text = String.Empty;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                txt_use_out.Visible = true;



            }
            else
            {
                txt_use_out.Visible = false;
                txt_use_out.Text = "";
                CalculateIncome();
            }
        }
        private void txt_use_out_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_use_out.Text, out value))
                txt_use_out.Text = String.Format("{0:N2}", value);
            else
                txt_use_out.Text = String.Empty;
        }
        private void txt_use_out_TextChanged(object sender, EventArgs e)
        {
            double use_out = double.Parse(txt_use_out.Text == "" ? "0" : txt_use_out.Text);
            double emp_send = double.Parse(txt_emp_send.Text == "" ? "0" : txt_emp_send.Text);
            double ts2_send = double.Parse(txt_ts2.Text == "" ? "0" : txt_ts2.Text);
            double sys_send = double.Parse(txt_sys.Text == "" ? "0" : txt_sys.Text);
            //txt_other_sys.Text = use_out.ToString("#,##0.00");
            txt_over_sys.Text = ((emp_send + use_out) - sys_send).ToString("#,##0.00");
        }
    }
}
