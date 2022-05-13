using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace TIS
{
    public partial class FineAndUser30DayForm : Form
    {

        MenuForm mainForm = null;
        AroundOpenForm openForm = null;
        Script script = new Script();
        int day = 30;
        DateTime date_start = DateTime.Now.Date;
        public bool status = false; 
        public FineAndUser30DayForm(Form callForm,Form callFormOpen)
        {
            mainForm = callForm as MenuForm;
            openForm = callFormOpen as AroundOpenForm; 
            InitializeComponent();
        }

        /*private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditStrapsForm editStrapsForm = new EditStrapsForm(this, txt_bag.Text, "0", mainForm.emp_control_id, txt_straps);
            editStrapsForm.ShowDialog();
        }*/

        private void FineAndUser30DayForm_Load(object sender, EventArgs e)
        {
            string sql = "SELECT ( SELECT SUM(tbl_income_user) AS tbl_income_user FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE ( tbl_income_user <> 0 OR tbl_income_fine <> 0 ) AND DATEDIFF(STR_TO_DATE('" + DateTime.Today.ToString("dd-MM-yyyy")+ "','%e-%c-%Y'), STR_TO_DATE( tbl_status_around_date, '%e-%c-%Y' ) ) = 30 AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' ) AS income_user, ( SELECT SUM(tbl_income_fine) AS tbl_income_fine FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE ( tbl_income_user <> 0 OR tbl_income_fine <> 0 ) AND DATEDIFF( STR_TO_DATE( '28-05-2018', '%e-%c-%Y' ), STR_TO_DATE( tbl_status_around_date, '%e-%c-%Y' ) ) = 30 AND tbl_cpoint_id = '" + mainForm.cpoint_id+"' ) AS income_fine, ( SELECT SUM(memo_amount) FROM tbl_memo WHERE memo_status = '1' AND memo_bag IS NULL AND memo_strapes IS NULL ) AS income_after_pay FROM DUAL";
            MySqlDataReader reader = script.Select_SQL(sql);
            if (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    groupBox3.Visible = true;
                    /*if (script.GetStraps(mainForm.emp_control_id) != "")
                    {
                        txt_straps.Text = script.GetStraps(mainForm.emp_control_id);
                    }
                    else
                    {
                        //script.AddStraps(txt_straps, this);
                    }*/

                    reader = script.Select_SQL(sql);
                    reader.Read();
                    lb_message.Text = "***มีรายการ ดังนี้\r\n";
                    lb_message.Text += " เงินผู้ใช้ทางไม่รับเงินทอน เกิน 30 วัน :  " + reader.GetString("income_user") + "   บาท\r\n";
                    lb_message.Text += " เงินค่าปรับบัตรหาย เกิน 30 วัน :  " + reader.GetString("income_fine") + "   บาท\r\n";
                    lb_message.Text += " เงินผู้ใช้ทางมาชำระภายหลัง และ ค่าปรับกรณีฝ่าด่าน :  " + reader.GetString("income_after_pay") + "   บาท";
                }
            }
            reader.Close();
            script.conn.Close();
            txt_straps.Text = script.GetStraps(mainForm.emp_control_id);

            //txt_straps.Text = script.GetStraps(mainForm.emp_control_id);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_bag.Text != "")
            {
                if (MessageBox.Show("ยืนยันการนำส่ง ผู้ใช้ทาง เงินค่าปรับบัตร เกิน 30 วัน ดังนี้ \r\n " + lb_message.Text.Replace("\n", "").Split('\r')[1]+ "\r\n" + lb_message.Text.Replace("\n", "").Split('\r')[2], "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string query_sql = "SELECT tbl_status_around_aid, tbl_around_time, tbl_status_around_date, tbl_income_money_bag, tbl_income_straps, tbl_income_emp_id, tbl_emp_name, tbl_income_cabinet, tbl_income_job, tbl_income_in_time, tbl_income_out_time, tbl_income_total, tbl_income_user, tbl_income_other, tbl_cpoint_name,tbl_cpoint_id, STR_TO_DATE( tbl_status_around_date, '%e-%c-%Y' ) AS date_around, '3' AS sta ,tbl_status_around_cpoint_sub_id FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id  WHERE ( tbl_income_user <> 0) AND DATEDIFF( STR_TO_DATE('" + date_start.ToString("dd-MM-yyyy") + "', '%e-%c-%Y'), STR_TO_DATE( tbl_status_around_date, '%e-%c-%Y' ) ) = " + day + " AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' UNION SELECT tbl_status_around_aid, tbl_around_time, tbl_status_around_date, tbl_income_money_bag, tbl_income_straps, tbl_income_emp_id, tbl_emp_name, tbl_income_cabinet, tbl_income_job, tbl_income_in_time, tbl_income_out_time, tbl_income_total, tbl_income_fine AS tbl_income_user, tbl_income_other, tbl_cpoint_name,tbl_cpoint_id, STR_TO_DATE( tbl_status_around_date, '%e-%c-%Y' ) AS date_around , '2' AS sta, tbl_status_around_cpoint_sub_id FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE ( tbl_income_fine <> 0) AND DATEDIFF( STR_TO_DATE('" + date_start.ToString("dd-MM-yyyy") + "', '%e-%c-%Y'), STR_TO_DATE( tbl_status_around_date, '%e-%c-%Y' ) ) = " + day + " AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "'";
                    MySqlDataReader reader = script.Select_SQL(query_sql);
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            string insert_query = "INSERT INTO tbl_incom_other (tbl_incom_other_bag,tbl_incom_other_bag_emp, tbl_incom_other_emp_id, tbl_incom_other_cabinet, tbl_incom_other_job, tbl_incom_other_date, tbl_incom_other_time, tbl_incom_other_list_incom_id, tbl_incom_other_amount, tbl_incom_other_date_send,tbl_incom_other_around,tbl_incom_other_straps,tbl_incom_cpoint_id) VALUES ('" + txt_bag.Text + "','" + reader.GetString("tbl_income_money_bag") + "','" + reader.GetString("tbl_income_emp_id") + "','" + reader.GetString("tbl_income_cabinet") + "','" + reader.GetString("tbl_income_job") + "','" + reader.GetString("tbl_status_around_date") + "','" + reader.GetString("tbl_income_in_time") + "-" + reader.GetString("tbl_income_out_time") + "','" + reader.GetString("sta") + "','" + reader.GetString("tbl_income_user") + "','" + date_start.ToString("dd-MM-yyyy") + "','" + reader.GetString("tbl_status_around_aid") + "','" + txt_straps.Text + "','" + reader.GetString("tbl_cpoint_id") + "')";
                            //string sql_straps = "INSERT INTO tbl_straps(tbl_straps_number, tbl_straps_status, tbl_straps_bag, tbl_straps_emp_control, tbl_straps_date) VALUES('" + txt_straps.Text + "', '0', '" + txt_bag.Text + "', '" + mainForm.emp_control_id + "', DATE(NOW()))";

                            if (script.InsertUpdae_SQL(insert_query))
                            {
                                status = true;
                            }
                        }
                    }
                    reader.Close();

                    string sql_straps = "INSERT INTO tbl_straps(tbl_straps_number, tbl_straps_status, tbl_straps_bag, tbl_straps_emp_control, tbl_straps_date) VALUES('" + txt_straps.Text + "', '0', '" + txt_bag.Text + "', '" + mainForm.emp_control_id + "', DATE(NOW()))";
                    if (script.InsertUpdae_SQL(sql_straps))
                    {
                        status = true;
                    }

                    query_sql = "SELECT * FROM tbl_memo WHERE memo_status = '1' AND memo_bag IS NULL AND memo_strapes IS NULL";
                    reader = script.Select_SQL(query_sql);
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            string insert_query = "UPDATE tbl_memo SET memo_bag = '"+txt_bag.Text+ "' , memo_strapes = '" + txt_straps.Text + "' WHERE memo_id = '" + reader.GetString("memo_id") +"'";
                            //string sql_straps = "INSERT INTO tbl_straps(tbl_straps_number, tbl_straps_status, tbl_straps_bag, tbl_straps_emp_control, tbl_straps_date) VALUES('" + txt_straps.Text + "', '0', '" + txt_bag.Text + "', '" + mainForm.emp_control_id + "', DATE(NOW()))";

                            if (script.InsertUpdae_SQL(insert_query))
                            {
                                status = true;
                            }
                        }
                    }
                    reader.Close();

                    if (status)
                    {
                        MessageBox.Show("บันทึกข้อมูลสำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ผิดพลาด", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("กรุณาใส่ถูงเงิน", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_bag.Focus();
            }
        }

        private void txt_bag_KeyUp(object sender, KeyEventArgs e)
        {
            /*if (!script.DuplicateBag(txt_bag.Text, int.Parse(mainForm.around_num)))
            {
                MessageBox.Show("ถุงเงินซ้ำ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_bag.Clear();
            }*/
        }

        private void FineAndUser30DayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditStrapsForm editStrapsForm = new EditStrapsForm(this, txt_bag.Text, "", mainForm.emp_control_id, txt_straps);
            editStrapsForm.ShowDialog();
        }
    }
}
