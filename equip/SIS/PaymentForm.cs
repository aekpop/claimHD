using System;
using MySql.Data;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;
using MySql.Data.MySqlClient;

namespace TIS
{
    public partial class PaymentForm : Form
    {
        Script script = new Script();
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            date_memo.CustomFormat = "dd-MM-yyyy";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_id_card.Text != "" && txt_name.Text != "ไม่พบข้อมูล" && txt_bill.Text != "" && txt_bill_no.Text != "")
            {
                if (button1.Text == "บันทึก")
                {
                    button1.Text = "ยืนยัน";
                    groupBox2.Enabled = false;
                    groupBox1.Enabled = false;
                    button2.Visible = true;
                }
                else
                {
                    if (MessageBox.Show("ยืนยันข้อมุลถูกต้อง ใช่ หรือ ไม่", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        GetEmpConfirmForm getEmp = new GetEmpConfirmForm();
                        getEmp.ShowDialog();
                        if (getEmp.checkValue)
                        {
                            string emp_id = getEmp.emp_id;
                            string update = "UPDATE `tbl_memo` SET `memo_amount`='" + txt_total.Text.Trim() + "',`memo_status`='1',`memo_bill_book`='" + txt_bill.Text.Trim() + "',`memo_bill_no`='" + txt_bill_no.Text.Trim() + "',`memo_date_payment`='" + date_pay.Value.ToString("dd-MM-yyyy") + "',`memo_emp_id_payment`='" + emp_id + "' WHERE `memo_id` = '" + lb_memo_id.Text.Trim() + "' AND `memo_status` IS NULL";
                            if (script.InsertUpdae_SQL(update))
                            {
                                MessageBox.Show("บันทึกข้อมูลสำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Error : ผิดผลาด", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("ใส่ข้อมูลให้ครบถ้วน", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Text = "บันทึก";
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            button2.Visible = false;
        }

        private void txt_id_card_KeyUp(object sender, KeyEventArgs e)
        {
            string sql_query = "SELECT * FROM tbl_memo WHERE memo_date = '" + date_memo.Text + "' AND memo_status IS NULL AND (memo_id_card = '" + txt_id_card.Text + "' OR memo_drive_id='" + txt_id_card.Text + "') order by memo_id desc";
            MySqlDataReader rs = script.Select_SQL(sql_query);
            if (rs.Read())
            {
                DateTime dateScheduled = DateTime.ParseExact(rs.GetString("memo_date"), "dd-MM-yyyy", CultureInfo.InvariantCulture).AddDays(7);
                TimeSpan dt = date_pay.Value - dateScheduled;
                txt_name.Text = rs.GetString("memo_name_cus");
                txt_palnt.Text = rs.GetString("memo_license_plate");
                txt_brand.Text = rs.GetString("memo_brand");
                txt_color.Text = rs.GetString("memo_color");
                txt_date_scheduled.Text = dateScheduled.ToString("dd-MM-yyyy");
                txt_toll.Text = rs.GetString("memo_amount");
                try { txt_fine_amount.Text = rs.GetString("memo_fine_amount"); } catch { txt_fine_amount.Text = "0.00"; }
                lb_memo_id.Text = rs.GetString("memo_id");
                if (dt.Days < 1)
                {
                    lb_status.Text = "ชำระภายในกำหนด";
                    lb_status.ForeColor = Color.Green;
                    txt_fine.Text = "0.00";
                    txt_total.Text = (double.Parse(txt_toll.Text) + double.Parse(txt_fine_amount.Text)).ToString();
                }
                else
                {
                    lb_status.Text = "เกินกำหนดชำระมาแล้ว " + (dt.Days) + " วัน";
                    lb_status.ForeColor = Color.Red;
                    txt_fine.Text = (double.Parse(txt_toll.Text) * 10).ToString();
                    txt_total.Text = (double.Parse(txt_toll.Text) + double.Parse(txt_fine.Text) + double.Parse(txt_fine_amount.Text)).ToString();
                }

            }
            else
            {
                txt_name.Text = "ไม่พบข้อมูล";
                txt_palnt.Clear();
                txt_brand.Clear();
                txt_color.Clear();
                txt_date_scheduled.Clear();
                txt_toll.Clear();
                lb_status.Text = "";
                txt_fine.Clear();
                txt_total.Clear();
            }
        }

        private void date_memo_ValueChanged(object sender, EventArgs e)
        {
            txt_id_card.Clear();
        }

        private void txt_bill_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_bill_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void date_pay_ValueChanged(object sender, EventArgs e)
        {
            txt_id_card_KeyUp(null,null);
        }
    }
}
