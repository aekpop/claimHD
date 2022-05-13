using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TIS
{
    public partial class EscapePaymenyForm : Form
    {
        Script script = new Script();
        public EscapePaymenyForm()
        {
            InitializeComponent();
        }

        private void EscapePaymenyForm_Load(object sender, EventArgs e)
        {
            script.comboBoxProvince(combo_province);
            script.comboBoxProvince(combo_province1);
            script.comboBoxTypeCar(combo_type_car);
            card_is_date.CustomFormat = "dd-MM-yyyy";
            card_ex_date.CustomFormat = "dd-MM-yyyy";
            date_memo.CustomFormat = "dd-MM-yyyy";
            //time_memo.Format = ;
            time_memo.ShowUpDown = true;
            time_memo.CustomFormat = "HH:mm";
        }

        private void txt_toll_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_toll_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_toll.Text.Length > 0)
            {
                txt_fine.Text = (int.Parse(txt_toll.Text) * 10).ToString();
                txt_total.Text = (int.Parse(txt_toll.Text) + int.Parse(txt_fine.Text)).ToString();
            }
            else
            {
                txt_toll.Text = "0";
                txt_fine.Text = (int.Parse(txt_toll.Text) * 10).ToString();
                txt_total.Text = (int.Parse(txt_toll.Text) + int.Parse(txt_fine.Text)).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_name.Text != "" && txt_home_num.Text != "" && txt_moo.Text != "" && txt_soi.Text != "" && txt_rd.Text != "" && txt_subdis.Text != "" && txt_dis.Text != "" && combo_province.Text != "" && txt_moo.Text != "" && txt_id_card.Text != "" && txt_user_issuer.Text != "" && txt_plate.Text != "" && combo_province1.Text != "" && txt_brand.Text != "" && txt_color.Text != "" && txt_cb.Text != "" && txt_toll.Text != "" && txt_bill.Text != "" && txt_bill_no.Text != "")
            {

                if (button1.Text == "บันทึก")
            {
                button1.Text = "ยืนยัน";
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
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
                        string cpoint = File.ReadAllText(script.file_cpoint).Split('|')[0];
                        string col = "`memo_id_list_id`,`memo_name_cus`,`memo_home_no`,`memo_moo`,`memo_soi`,`memo_rd`,`memo_subdis`,`memo_dis`,`memo_province_add`,`memo_tel`,memo_mobile,`memo_id_card`,`memo_card_no`,`memo_card_issuer`,`memo_card_is_date`,`memo_card_ex_date`,`memo_cpoint_id`,`memo_date`,`memo_time`,`memo_cabinet`,`memo_type_id`,`memo_license_plate`,`memo_province_plate`,`memo_brand`,`memo_color`,`mome_note`,`memo_emp_id`,memo_amount,memo_emp_id_payment,memo_status,memo_bill_book,memo_bill_no,memo_date_payment";
                        string value = "'6','" + txt_name.Text + "','" + txt_home_num.Text + "','" + txt_moo.Text + "','" + txt_soi.Text + "','" + txt_rd.Text + "','" + txt_subdis.Text + "','" + txt_dis.Text + "','" + combo_province.Text + "','" + txt_tel.Text + "','" + txt_mobile.Text + "','" + txt_id_card.Text + "','" + txt_card_num.Text + "','" + txt_user_issuer.Text + "','" + card_is_date.Text + "','" + card_ex_date.Text + "','" + cpoint + "','" + date_memo.Text + "','" + time_memo.Text + "','" + txt_cb.Text + "','" + combo_type_car.Text + "','" + txt_plate.Text + "','" + combo_province1.Text + "','" + txt_brand.Text + "','" + txt_color.Text + "','" + txt_note.Text.Trim() + "','" + emp_id + "','" + txt_total.Text.Trim() + "','" + emp_id + "','1','"+txt_bill.Text+"','"+txt_bill_no.Text+"','"+DateTime.Today.ToString("dd-MM-yyyy")+"'";
                        string sql_insert = "INSERT INTO `tbl_memo` (" + col + ") VALUE (" + value + ")";
                        if (script.InsertUpdae_SQL(sql_insert))
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

        private void txt_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void combo_province_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void combo_province1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void combo_type_car_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txt_tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_bill_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_bill_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }
    }
}
