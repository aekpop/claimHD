using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using System.Windows.Forms;


namespace TIS
{
    public partial class ChargedForm : Form
    {
        Script script = new Script();
        MenuForm mainForm = null;
        public ChargedForm(Form callingForm)
        {
            mainForm = callingForm as MenuForm;
            InitializeComponent();
            //mainForm.Enabled = false;
        }

        private void ChargedForm_Load(object sender, EventArgs e)
        {
          
            string sql = "SELECT * FROM tbl_around ";
            ConnectDB contxt = new ConnectDB();
            MySqlConnection conn = new MySqlConnection();
            conn = new MySqlConnection(contxt.context());
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            cb_around.Text = "เลือก";
            while (reader.Read())
            {
                cb_around.Items.Add("ผลัด " + reader.GetString("tbl_around_id") + " (" + reader.GetString("tbl_around_time") + ")");
            }
            conn.Close();
            /*CultureInfo _cultureEnInfo = new CultureInfo("en-US");
            DateTime dateEng = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"), _cultureEnInfo);
            
            dpk_date.Text = dateEng.ToString("dd/MM/yyyy", _cultureEnInfo);*/
            dpk_date.CustomFormat = "dd-MM-yyyy";
            dpk_date1.CustomFormat = "dd-MM-yyyy";

            string sql_check = "SELECT * FROM tbl_incom_other WHERE tbl_incom_other_list_incom_id = '4' AND tbl_incom_other_date_send = SUBSTR(DATE_FORMAT( NOW(), '%d-%m-%Y' ),1,10)";
            MySqlDataReader rs = script.Select_SQL(sql_check);
            if (rs.Read())
            {
                rs.Close();
            }
            else
            {
                sql_check = "SELECT * FROM tbl_status_around WHERE tbl_status_around_close = '0' AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "'";
                rs = script.Select_SQL(sql_check);
                if (rs.Read())
                {
                    //txt_straps.Text = script.GetStraps(rs.GetString("tbl_status_around_emp_open_id"));
                }
                else
                {
                    MessageBox.Show("รองผู้จัดการด่านยังไม่ได้ทำการเปิดกะ ยังไม่สามารถนำส่งเงินรายได้ ได้ในขณะนี้", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }

            if (tabControl1.SelectedTab == tabPage1)
            {
                txt_t1_1.Text = "ส่งเงินรายได้ขาดระบบ ตามบันทึกที่ ";
                lb_title.Text = tabPage1.Text;
                lb_date.Text = "";
                lb_line1.Text = txt_t1_1.Text + txt_rs.Text;
                txt_t1_1.ReadOnly = true;
                //txt_note.Enabled = false;
            }
        }

        private void txt_detail_KeyUp(object sender, KeyEventArgs e)
        {
            CultureInfo _cultureEnInfo = new CultureInfo("th-TH");
            DateTime dateEng = Convert.ToDateTime(dpk_date.Value, _cultureEnInfo);
            txt_rs.Text = "กท./ต./" + txt_detail.Text + " ลว." + dateEng.ToString("dd MMMyy", _cultureEnInfo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Script script = new Script();
            DateTime date_send = script.GetDateAround().AddDays(-1);
            //MessageBox.Show(t1.TimeOfDay.ToString());
            int list_income = 0;
            string sql = "";
            bool save = false;


            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage1"])
            {
                if (txt_emp_name.Text != "ไม่พบข้อมูล" && txt_amount.Text != "")
                {
                    list_income = 4;
                    if (MessageBox.Show("ยืนยันบันทึกข้อมูล", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string time = txt_start.Text + "-" + txt_end.Text;
                        sql = "INSERT INTO tbl_incom_other ( tbl_incom_other_rec, tbl_incom_other_emp_id, tbl_incom_other_date, tbl_incom_other_around, tbl_incom_other_cabinet, tbl_incom_other_job, tbl_incom_other_time, tbl_incom_other_amount,tbl_incom_other_date_send,tbl_incom_other_list_incom_id,tbl_incom_cpoint_id,tbl_incom_cpoint_sub_id,tbl_incom_other_note) VALUES ('" + txt_t1_1.Text + txt_rs.Text + "','" + txt_emp_id.Text + "','" + script.GetMontThai(dpk_date1.Value) + "','" + cb_around.Text.Split(' ')[1] + "','" + txt_cb.Text + "','" + txt_job.Text + "','" + time + "','" + double.Parse(txt_amount.Text) + "','" + date_send.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + "','" + list_income + "','" + mainForm.cpoint_id + "','" + mainForm.sub_cpoint + "','เรียกเก็บจาก ')";
                        save = true;
                    }
                }
                else
                {
                    MessageBox.Show("กรุณาใส่ข้อมูลให้ถูกต้องครบถ้วน", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])
            {
                if (MessageBox.Show("ยืนยันบันทึกข้อมูล", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    list_income = 7;
                    sql = "INSERT INTO tbl_incom_other ( tbl_incom_other_rec,tbl_incom_other_amount,tbl_incom_other_date_send,tbl_incom_other_list_incom_id,tbl_incom_cpoint_id,tbl_incom_cpoint_sub_id,tbl_incom_other_note) VALUES ('" + txt_t2_1.Text + txt_rs.Text + "','" + double.Parse(txt_t2_4.Text) + "','" + date_send.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + "','" + list_income + "','" + mainForm.cpoint_id + "','" + mainForm.sub_cpoint + "','" + txt_t2_2.Text + "\r\n" + txt_t2_3.Text + "')";
                    save = true;
                }
            }

            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage3"])
            {
                if (MessageBox.Show("ยืนยันบันทึกข้อมูล", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    list_income = 8;
                    sql = "INSERT INTO tbl_incom_other ( tbl_incom_other_rec, tbl_incom_other_amount,tbl_incom_other_date_send,tbl_incom_other_list_incom_id,tbl_incom_cpoint_id,tbl_incom_cpoint_sub_id,tbl_incom_other_note) VALUES ('" + txt_t3_1.Text + txt_rs.Text + "','" + double.Parse(txt_t3_4.Text) + "','" + date_send.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + "','" + list_income + "','" + mainForm.cpoint_id + "','" + mainForm.sub_cpoint + "','" + txt_t3_2.Text + "\r\n" + txt_t3_3.Text + "')";
                    save = true;
                }
            }

            if (save)
            {
                if (script.InsertUpdae_SQL(sql))
                {
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mainForm.Enabled = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ผิดผลาด", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainForm.Enabled = true;
            this.Close();
        }

        private void dpk_date_ValueChanged(object sender, EventArgs e)
        {
            CultureInfo _cultureEnInfo = new CultureInfo("th-TH");
            DateTime dateEng = Convert.ToDateTime(dpk_date.Value, _cultureEnInfo);
            txt_rs.Text = "กท./ต./" + txt_detail.Text + " ลว." + dateEng.ToString("dd MMMyy", _cultureEnInfo);
            lb_line1.Text = txt_t1_1.Text + txt_rs.Text;
        }

        private void cb_around_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void dpk_date_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void dpk_date1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void cb_startH_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void cb_startM_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void cb_endH_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void cb_endM_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void txt_emp_id_KeyUp(object sender, KeyEventArgs e)
        {
            string sql = "SELECT * FROM tbl_emp WHERE tbl_emp_id = '" + txt_emp_id.Text + "'";
            ConnectDB contxt = new ConnectDB();
            MySqlConnection conn = new MySqlConnection();
            conn = new MySqlConnection(contxt.context());
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txt_emp_name.Text = reader.GetString("tbl_emp_name");
                lb_line3.Text = "เรียกเก็บจาก " + txt_emp_name.Text;
            }
            else
            {
                txt_emp_name.Text = "ไม่พบข้อมูล";
                //lb_line3.Text = "" + txt_note.Text;
            }
        }

        private void txt_emp_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script script = new Script();
            script.CheckNumber(e);
        }

        private void txt_bag_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script script = new Script();
            script.CheckNumber(e);
        }

        private void txt_cb_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script script = new Script();
            script.CheckNumber(e);
        }

        private void txt_job_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txt_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script script = new Script();
            script.CheckNumber(e);
        }

        private void cb_around_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cb_around.Text);
            get_lb_line2();
        }

        private void dpk_date1_ValueChanged(object sender, EventArgs e)
        {
            get_lb_line2();
        }

        private void get_lb_line2()
        {
            string around_tx = "";
            if (cb_around.Text != "เลือก")
            {
                around_tx = cb_around.Text.Split(' ')[0] + "ที่ " + cb_around.Text.Split(' ')[1];
            }
            lb_line2.Text = "วันที่ " + script.GetMontThai(dpk_date1.Value) + " ตู้ที่ " + txt_cb.Text + " งาน " + txt_job.Text + " " + around_tx + " เวลาปฏิบัติงาน " + txt_start.Text + "-" + txt_end.Text + " น.";
        }

        private void txt_cb_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txt_cb.Text.Length <= 1)
            {
                txt_cb.Text = "0" + (txt_cb.Text == "" ? "0" : txt_cb.Text);
            }
        }

        private void txt_start_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!script.CheckTime(txt_start.Text))
            {
                MessageBox.Show("รูปแบบเวลาไม่ถูกต้อง ตัวอย่าง 00:00 - 23:59", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_start.Clear();
                txt_start.Focus();
            }
        }

        private void txt_end_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!script.CheckTime(txt_end.Text))
            {
                MessageBox.Show("รูปแบบเวลาไม่ถูกต้อง ตัวอย่าง 00:00 - 23:59", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_end.Clear();
                txt_end.Focus();
            }
        }

        private void txt_amount_Leave(object sender, EventArgs e)
        {
            GetNumbreFormat(txt_amount);
        }

        private void txt_detail_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            lb_line1.Text = txt_t1_1.Text + txt_rs.Text;
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            lb_line1.Text = txt_t1_1.Text + txt_rs.Text;
        }

        private void txt_cb_KeyUp(object sender, KeyEventArgs e)
        {
            get_lb_line2();
        }

        private void txt_job_KeyUp(object sender, KeyEventArgs e)
        {
            get_lb_line2();
        }

        private void txt_start_KeyUp(object sender, KeyEventArgs e)
        {
            get_lb_line2();
        }

        private void txt_end_KeyUp(object sender, KeyEventArgs e)
        {
            get_lb_line2();
        }

        private void txt_note_KeyUp(object sender, KeyEventArgs e)
        {
            txt_emp_id_KeyUp(null, null);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage1"])
            {
                txt_t1_1.Text = "ส่งเงินรายได้ขาดระบบ ตามบันทึกที่ ";
                lb_title.Text = tabPage1.Text;
                lb_date.Text = "";
                txt_detail_KeyUp(null, null);

                lb_line1.Text = txt_t1_1.Text + txt_rs.Text;
                txt_t1_1.ReadOnly = true;
                txt_detail.Enabled = true;
                dpk_date.Enabled = true;
                //txt_note.Enabled = false;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])
            {
                 txt_rs.Text = "";
                 lb_title.Text = tabPage2.Text;
                 lb_date.Text = "วันที่ " + script.GetMontThai(DateTime.Now.Date);
                 lb_line1.Text = txt_t2_1.Text;
                 lb_line2.Text = txt_t2_2.Text;
                 lb_line3.Text = txt_t2_3.Text;
                 txt_t1_1.ReadOnly = false;
                 txt_detail.Enabled = false;
                 dpk_date.Enabled = false;
                //txt_note.Enabled = true;

            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage3"])
            {
                txt_rs.Text = "";
                lb_title.Text = tabPage3.Text;
                lb_date.Text = "วันที่ " + script.GetMontThai(DateTime.Now.Date);
                lb_line1.Text = txt_t3_1.Text;
                lb_line2.Text = txt_t3_2.Text;
                lb_line3.Text = txt_t3_3.Text;
                txt_t1_1.ReadOnly = false;
                txt_detail.Enabled = false;
                dpk_date.Enabled = false;
                //txt_note.Enabled = true;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabPage1_Click(null, null);
            tabPage2_Click(null, null);
            tabPage3_Click(null, null);
        }

        private void txt_t2_1_KeyUp(object sender, KeyEventArgs e)
        {
            tabPage2_Click(null, null);
        }

        private void txt_t2_2_KeyUp(object sender, KeyEventArgs e)
        {
            tabPage2_Click(null, null);
        }

        private void txt_t2_3_KeyUp(object sender, KeyEventArgs e)
        {
            tabPage2_Click(null, null);
        }

        private void txt_t3_2_KeyUp(object sender, KeyEventArgs e)
        {
            tabPage3_Click(null, null);
        }

        private void txt_t3_1_KeyUp(object sender, KeyEventArgs e)
        {
            tabPage3_Click(null, null);
        }

        private void txt_t3_3_KeyUp(object sender, KeyEventArgs e)
        {
            tabPage3_Click(null, null);
        }

        private void txt_t2_4_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_t3_4_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void GetNumbreFormat(TextBox text)
        {
            Double value;
            if (Double.TryParse(text.Text, out value))
                text.Text = String.Format("{0:N2}", value);
            else
                text.Text = String.Empty;
        }

        private void txt_t2_4_Leave(object sender, EventArgs e)
        {
            GetNumbreFormat(txt_t2_4);
        }

        private void txt_t3_4_Leave(object sender, EventArgs e)
        {
            GetNumbreFormat(txt_t3_4);
        }

        private void txt_rs_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txt_t3_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FormEditCharged FormEditCharged = new FormEditCharged(this);
            FormEditCharged.ShowDialog();
           
            //this.Enabled = false;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
