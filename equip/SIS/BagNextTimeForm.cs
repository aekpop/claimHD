using System;
using System.IO;
using System.Windows.Forms;

namespace TIS
{
    public partial class BagNextTimeForm : Form
    {
        Script script = new Script();
        string filename = "NextAround.txt";
        public BagNextTimeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            script.CheckEmpAdd(txt_emp_id, lb_emp_name);
            if (!script.DuplicateBagNext(txt_bag.Text))
            {
                MessageBox.Show("ถุงเงินซ้ำ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_bag.Clear();
            }
            else
            {
                Next();
            }

        }

        private void txt_emp_id_KeyUp(object sender, KeyEventArgs e)
        {
            script.CheckEmpWorking(txt_emp_id, lb_emp_name);
        }

        private void txt_emp_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void BagNextTimeForm_Load(object sender, EventArgs e)
        {
            txt_emp_id.Focus();
            try
            {
                string[] data = File.ReadAllLines(filename);
                int num = 1;
                foreach (string line in data)
                {
                    string[] line_data = line.Split('|');
                    listBox1.Items.Add(num + ". รหัสพนักงาน : " + line_data[0] + "  " + script.GetEmpName(line_data[0]) + " | ถุงเงิน : " + line_data[1] + " | ตู้ : " + line_data[2] + " | จำนวนเงินยืม : " + line_data[3]);
                    num++;
                }
            }
            catch { }
        }

        private void txt_money_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_money_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Next();
            }
        }
        private void Next()
        {
            if (txt_bag.Text != "" && txt_bag.Text.Length > 3 && txt_cabinet.Text != "00" && txt_cabinet.Text != "" && txt_money.Text != "" && lb_emp_name.Text != "ไม่พบข้อมูลพนักงาน")
            {
                if (!groupbox1.Enabled)
                {
                    if (MessageBox.Show("ยืนยันเบิกถุงเงิน", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (script.InsertUpdae_SQL("INSERT INTO tbl_income (tbl_income_money_bag,tbl_income_emp_id,tbl_income_cabinet,tbl_income_money,tbl_income_status_job,tbl_income_status_backmaney,tbl_income_around_id) VALUE ('" + txt_bag.Text + "','" + txt_emp_id.Text + "','" + txt_cabinet.Text + "','" + double.Parse(txt_money.Text) + "','0','0','10000000000000')"))
                        {
                            MessageBox.Show("เรีบยร้อย", "ผลลัพธ์", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FileInfo DirInfo2 = new FileInfo(filename);
                            if (!DirInfo2.Exists)
                            {
                                StreamWriter file = new StreamWriter(@filename, true);
                                file.WriteLine(txt_emp_id.Text + "|" + txt_bag.Text + "|" + txt_cabinet.Text + "|" + double.Parse(txt_money.Text) + "|");
                                file.Close();
                            }
                            else
                            {
                                StreamWriter file = File.AppendText(@filename);
                                file.WriteLine(txt_emp_id.Text + "|" + txt_bag.Text + "|" + txt_cabinet.Text + "|" + double.Parse(txt_money.Text) + "|");
                                file.Close();
                            }
                            BagNextTimeForm bagNextTime = new BagNextTimeForm();
                            bagNextTime.ShowDialog();
                            this.Close();
                            //mainForm.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Error", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    groupbox1.Enabled = false;
                    btn_edit.Visible = true;
                    button1.Text = "ยืนยัน";
                }
            }
            else
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_bag_KeyUp(object sender, KeyEventArgs e)
        {
            int around = script.GetAroundInt();
            /*if ((around) > 3)
            {
                around = 1;
            }*/

            if (!script.DuplicateBag(txt_bag.Text, around))
            {
                MessageBox.Show("ถุงเงินซ้ำ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_bag.Clear();
            }
        }

        private void txt_cabinet_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txt_cabinet.Text.Length <= 1)
            {
                txt_cabinet.Text = "0" + (txt_cabinet.Text == "" ? "0" : txt_cabinet.Text);
            }
            script.CheckCabinet(txt_cabinet);
        }

        private void txt_money_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_money.Text, out value))
                txt_money.Text = String.Format("{0:N2}", value);
            else
                txt_money.Text = String.Empty;
        }

        private void btn_edit_Click_1(object sender, EventArgs e)
        {
            btn_edit.Visible = false;
            groupbox1.Enabled = true;
            button1.Text = "บันทึก";
        }
    }
}
