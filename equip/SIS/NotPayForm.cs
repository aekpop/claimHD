using System;
using System.IO;
using System.Windows.Forms;

namespace TIS
{
    public partial class NotPayForm : Form
    {
        Script script = new Script();
        public NotPayForm()
        {
            InitializeComponent();
        }

        private void NotPayForm_Load(object sender, EventArgs e)
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
            if (File.ReadAllText(script.file_cpoint).Split('|')[3] == "9")
            {
                txt_fine_amount.Enabled = false;
                txt_fine_amount.Text = "0";
            }

        }

        private void combo_province_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void combo_province_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void combo_province1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_name.Text != "" && txt_home_num.Text != "" && txt_moo.Text != "" && txt_soi.Text != "" && txt_rd.Text != "" && txt_subdis.Text != "" && txt_dis.Text != "" && combo_province.Text != "" && txt_mobile.Text != "" && txt_id_card.Text != "" && txt_user_issuer.Text != "" && txt_plate.Text != "" && combo_province1.Text != "" && txt_brand.Text != "" && txt_color.Text != "" && txt_cb.Text != "" && txt_amount.Text != "" && txt_type.Text != "")
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
                            string col = "`memo_id_list_id`,`memo_name_cus`,`memo_home_no`,`memo_moo`,`memo_soi`,`memo_rd`,`memo_subdis`,`memo_dis`,`memo_province_add`,`memo_tel`,memo_mobile,`memo_id_card`,`memo_card_no`,`memo_card_issuer`,`memo_card_is_date`,`memo_card_ex_date`,`memo_cpoint_id`,`memo_date`,`memo_time`,`memo_cabinet`,`memo_type_id`,`memo_license_plate`,`memo_province_plate`,`memo_brand`,`memo_color`,`mome_note`,`memo_emp_id`,memo_amount,`memo_fine_amount`,`memo_drive_id`,memo_type";
                            string value = "'5','" + txt_name.Text + "','" + txt_home_num.Text + "','" + txt_moo.Text + "','" + txt_soi.Text + "','" + txt_rd.Text + "','" + txt_subdis.Text + "','" + txt_dis.Text + "','" + combo_province.Text.Trim() + "','" + txt_tel.Text + "','" + txt_mobile.Text + "','" + txt_id_card.Text.Trim() + "','" + txt_card_num.Text.Trim() + "','" + txt_user_issuer.Text + "','" + card_is_date.Text + "','" + card_ex_date.Text + "','" + cpoint + "','" + date_memo.Text + "','" + time_memo.Text + "','" + txt_cb.Text + "','" + combo_type_car.Text + "','" + txt_plate.Text + "','" + combo_province1.Text.Trim() + "','" + txt_brand.Text + "','" + txt_color.Text + "','" + txt_note.Text.Trim() + "','" + emp_id + "','"+txt_amount.Text.Trim()+"','"+txt_fine_amount.Text.Trim()+"','"+txt_drive_id.Text.Trim()+"','"+txt_type.Text+"'";
                            string sql_insert = "INSERT INTO `tbl_memo` (" + col + ") VALUE (" + value + ")";
                            if (script.InsertUpdae_SQL(sql_insert))
                            {
                                MessageBox.Show("บันทึกข้อมูลสำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                script.GetReportTollNotPay(date_memo.Value, txt_id_card.Text.Trim(), txt_card_num.Text.Trim());
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


        private void combo_type_car_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Text = "บันทึก";
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            button2.Visible = false;
        }

        private void txt_name_KeyDown_1(object sender, KeyEventArgs e)
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

        private void combo_province_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void txt_tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void combo_type_car_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void combo_province1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txt_id_card_KeyPress(object sender, KeyPressEventArgs e)
        {
            //script.CheckNumber(e);
        }

        private void txt_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_moo_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_home_num_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
