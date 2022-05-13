using MySql.Data.MySqlClient;
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
    public partial class MoneybagForm : Form
    {
        MenuForm mainForm = null;
        Script scriptCode = new Script();
        string cpoint_id = "";
        string cpoint_sub_id = "";
        public MoneybagForm(Form callingForm, string cpoint, string sub_cpoint)
        {
            InitializeComponent();
            mainForm = callingForm as MenuForm;
            btn_save.Enabled = false;
            cpoint_id = cpoint;
            cpoint_sub_id = sub_cpoint; // v2.0.3
        }

        public void MoneybagForm_Load(object sender, EventArgs e)
        {
            try
            {
                txt_bag.Clear();
                txt_cabinet.Clear();
                txt_emp_id.Clear();
                txt_money.Clear();
                txt_emp_id.Focus();
                lb_emp_name.Text = "";
                btn_save.Enabled = false;
                //FileInfo DirInfo2 = new FileInfo(scriptCode.file_around);
                //if (DirInfo2.Exists)
                //{
                string[] cid = File.ReadAllText(scriptCode.file_cpoint).Split('|');
                dataGridView1 = scriptCode.GetDataGridViewStatus(dataGridView1);

                string sql = "SELECT * FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id`=`tbl_status_around_id` LEFT JOIN `tbl_emp` ON `tbl_emp_id` =`tbl_income_emp_id`  WHERE tbl_status_around_close = '0' AND tbl_status_around_cpoint_id = '" + cid[0] + "' AND tbl_status_around_cpoint_sub_id = '" + cid[1] + "' ORDER BY `tbl_income_money_bag`";
                MySqlDataReader rs = scriptCode.Select_SQL(sql);
                if (!rs.Read())
                {
                    dataGridView1.Visible = false;
                }
                rs.Close();

                scriptCode.conn.Close();
                //}
            }
            catch { }

        }

        private void txt_emp_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            scriptCode.CheckNumber(e);
        }

        private void txt_bag_KeyPress(object sender, KeyPressEventArgs e)
        {
            scriptCode.CheckNumber(e);
        }

        private void txt_money_KeyPress(object sender, KeyPressEventArgs e)
        {
            scriptCode.CheckNumber(e);
        }

        private void txt_cabinet_KeyPress(object sender, KeyPressEventArgs e)
        {
            scriptCode.CheckNumber(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainForm.Enabled = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //new Script().CheckEmpWorking(txt_emp_id, lb_emp_name);
            if (txt_emp_id.Text != "" && txt_bag.Text != "" && txt_cabinet.Text != "" && txt_money.Text != "" && txt_cabinet.Text != "00" && txt_cabinet.Text != "" && lb_emp_name.Text != "ไม่พบข้อมูลพนักงาน")
            {
                if (!scriptCode.DuplicateBag(txt_bag.Text, scriptCode.GetAroundInt()))
                {
                    MessageBox.Show("ถุงเงินซ้ำ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_bag.Clear();
                }
                else
                {
                    if (txt_bag.Text.Length > 3)
                    {
                        ConfirmMoneyBag cfMoneyBag = new ConfirmMoneyBag(mainForm, this, txt_bag.Text, txt_emp_id.Text, txt_cabinet.Text, txt_money.Text, cpoint_id, cpoint_sub_id);
                        cfMoneyBag.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("กรุณาป้อนถุงเงิน 4 หลัก", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบถ้วน ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_emp_id_KeyUp(object sender, KeyEventArgs e)
        {
            Script script = new Script();
            if (txt_emp_id.Text.Length > 1)
            {
                script.CheckEmpWorking(txt_emp_id, lb_emp_name);
                if (scriptCode.GetEmpName(txt_emp_id.Text)!= "ไม่พบข้อมูลพนักงาน")
                {
                    btn_save.Enabled = true;
                }
                else
                {
                    btn_save.Enabled = false;
                }
                lb_emp_name.Text = script.GetEmpName(txt_emp_id.Text);
            }
        }

        private void txt_money_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lb_emp_name.Text != "ไม่พบข้อมูลพนักงาน")
            {
                if (txt_emp_id.Text != "" && txt_bag.Text != "" && txt_cabinet.Text != "" && txt_money.Text != "")
                {
                    ConfirmMoneyBag cfMoneyBag = new ConfirmMoneyBag(mainForm, this, txt_bag.Text, txt_emp_id.Text, txt_cabinet.Text, txt_money.Text, cpoint_id, cpoint_sub_id);
                    cfMoneyBag.Show();
                }
                else
                {
                    MessageBox.Show("กรุณาป้อนข้อมูลให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void txt_bag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lb_emp_name.Text != "ไม่พบข้อมูลพนักงาน")
            {
                if (txt_emp_id.Text != "" && txt_bag.Text != "" && txt_cabinet.Text != "" && txt_money.Text != "")
                {
                    ConfirmMoneyBag cfMoneyBag = new ConfirmMoneyBag(mainForm, this, txt_bag.Text, txt_emp_id.Text, txt_cabinet.Text, txt_money.Text, cpoint_id, cpoint_sub_id);
                    cfMoneyBag.Show();
                }
                else
                {
                    MessageBox.Show("กรุณาป้อนข้อมูลให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            EditStrapsEmpForm editStraps = new EditStrapsEmpForm(mainForm);
            editStraps.ShowDialog();
        }

        private void txt_bag_KeyUp(object sender, KeyEventArgs e)
        {
            if (!scriptCode.DuplicateBag(txt_bag.Text,scriptCode.GetAroundInt()))
            {
                MessageBox.Show("ถุงเงินซ้ำ","",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txt_bag.Clear();
            }
        }

        private void txt_cabinet_Validating(object sender, CancelEventArgs e)
        {
            if (txt_cabinet.Text.Length <= 1)
            {
                txt_cabinet.Text = "0" + (txt_cabinet.Text==""?"0": txt_cabinet.Text);
            }
            scriptCode.CheckCabinet(txt_cabinet);
        }

        private void txt_money_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_money.Text, out value))
                txt_money.Text = String.Format("{0:N2}", value);
            else
                txt_money.Text = String.Empty;
        }
    }
}
