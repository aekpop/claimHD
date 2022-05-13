using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows.Forms;

namespace TIS
{
    public partial class ConfirmMoneyBag : Form
    {
        MoneybagForm moneyBagF = null;
        MenuForm mainForm = null;
        string bag = "";
        string emp_id = "";
        string cabinet = "";
        string money = "";
        string cpoint_id = "";
        string cpoint_sub_id = "";
        Script scriptCode = new Script();
        public ConfirmMoneyBag(Form callingFrm, Form callingMoneyBagForm, string bag_tmp, string emp_id_tmp, string cabinet_tmp, string money_tmp, string cpoint , string sub_cpoint)
        {
            InitializeComponent();
            mainForm = callingFrm as MenuForm;
            moneyBagF = callingMoneyBagForm as MoneybagForm;
            bag = bag_tmp;
            emp_id = emp_id_tmp;
            cabinet = cabinet_tmp;
            money = money_tmp;
            cpoint_id = cpoint;
            cpoint_sub_id = sub_cpoint; // v2.0.3
            //MessageBox.Show(bag+"\r\n"+ emp_id + "\r\n" +cabinet + "\r\n" +money);
            //moneyBagF.Enabled = false;
        }

        private void txt_emp_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            scriptCode.CheckNumber(e);
        }

        private void txt_emp_id_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            moneyBagF.Enabled = true;
            this.Close();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            next();
        }
        private void next()
        {
            if (txt_emp_id.Text != "")
            {
                string dateNow = DateTime.Today.ToString("dd-MM-yyyy");
                string dateNext = DateTime.Now.AddDays(-1).ToString("dd-MM-yyyy");
                string dateNextDay = dateNext.Split('-')[0] + "-" + dateNext.Split('-')[1] + "-" + dateNext.Split('-')[2];
                bool check = false;

                string sql_around = "SELECT * FROM tbl_status_around WHERE tbl_status_around_emp_open_id = '" + txt_emp_id.Text + "' AND tbl_status_around_close = '0'  AND tbl_status_around_cpoint_id = '" + cpoint_id + "' AND tbl_status_around_cpoint_sub_id = '" + cpoint_sub_id + "'";

                //MessageBox.Show(sql_around + "\r\n\r\n" + sqL_check_bag);
                string sql = "SELECT * FROM tbl_income WHERE tbl_income_emp_id = '"+emp_id+"' AND tbl_income_status_job = '0'";
                MySqlDataReader reader = scriptCode.Select_SQL(sql);
                if (reader.Read())
                {
                    check = false;
                    MessageBox.Show("พนักงานปฏิบัติงานอยู่!!!","",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    this.Close();
                }
                else
                {
                    check = true;
                }
                try
                {
                    if (check)
                    {
                        
                        if (File.ReadAllText(scriptCode.file_around).Split('|')[0] == txt_emp_id.Text)
                        {
                            MySqlDataReader rs = scriptCode.Select_SQL(sql_around);
                            if (rs.Read())
                            {
                                //MessageBox.Show("ok");
                                if (scriptCode.InsertUpdae_SQL("INSERT INTO tbl_income (tbl_income_money_bag,tbl_income_emp_id,tbl_income_cabinet,tbl_income_around_id,tbl_income_money,tbl_income_status_job,tbl_income_status_backmaney) VALUE ('" + bag + "','" + emp_id + "','" + cabinet + "','" + rs.GetString("tbl_status_around_id") + "','" + double.Parse(money) + "','0','0')"))
                                {
                                    MessageBox.Show("เรียบร้อย", "ผลลัพธ์", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    mainForm.btn_send.Enabled = true;
                                    moneyBagF.Close();

                                    moneyBagF = new MoneybagForm(mainForm, mainForm.cpoint_id , mainForm.sub_cpoint);
                                    moneyBagF.ShowDialog();

                                    mainForm.Enabled = true;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Error", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("รหัสไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txt_emp_id.Clear();
                                txt_emp_id.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("รหัสไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txt_emp_id.Clear();
                            txt_emp_id.Focus();
                        }
                    }
                }
                catch
                {
                    //MessageBox.Show(e.ToString());
                }
                scriptCode.conn.Close();
                //MessageBox.Show(sqL_check_bag+"\r\n\r\n"+sql_around);
            }
            else
            {
                MessageBox.Show("กรุงณาป้อนรหัสเพื่อยืนยัน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_emp_id_KeyDown_1(object sender, KeyEventArgs e)
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

        private void txt_emp_id_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Script script = new Script();
            script.CheckNumber(e);
        }
    }
}
