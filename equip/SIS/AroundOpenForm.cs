using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace TIS
{
    public partial class AroundOpenForm : Form
    {
        MenuForm maniForm = null;
        string cpoint_id;
        string emp_id;
        int day = 30;
        string filename = "NextAround.txt";
        Script script = new Script();
        public AroundOpenForm(string emp, Form callingForm, string cpoint)
        {
            maniForm = callingForm as MenuForm;
            InitializeComponent();
            cpoint_id = cpoint;
            emp_id = emp;
            ConnectDB contxt = new ConnectDB();
            MySqlConnection conn = new MySqlConnection();
            conn = new MySqlConnection(contxt.context());
            string sql = "SELECT * FROM tbl_emp e JOIN tbl_emp_group g ON e.tbl_emp_group_id = g.tbl_emp_group_id WHERE tbl_emp_id = '" + emp_id + "'";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            //MessageBox.Show(sql);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {

                        txt_emp_name.Text = reader.GetString("tbl_emp_name");
                        txt_emp_name.BackColor = DefaultBackColor;
                        txt_emp_name.ForeColor = Color.Blue;
                        lb_group.Text = reader.GetString("tbl_emp_group_name");
                        lb_group.BackColor = DefaultBackColor;
                        lb_group.ForeColor = Color.Blue;
                    }
                }
                reader.Close();
            }
            catch
            {

            }
            conn.Close();

            //txt_emp.Text = data[0]+" "+data[1]+" "+data[2]+" "+data[3];
        }

        private void AroundOpenForm_Load(object sender, EventArgs e)
        {
            lb_date_show.Text = new Script().GetMontThai(script.GetDateAround());
            //txt_straps_start.Text = new Script().GetStrapsLast();
            if (DateTime.Now.TimeOfDay >= DateTime.ParseExact("06:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay && DateTime.Now.TimeOfDay < DateTime.ParseExact("14:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay)
            {
                rb_2.Checked = true;

                rb_3.Enabled = false;
                rb_1.Enabled = false;
               
            }
            if (DateTime.Now.TimeOfDay >= DateTime.ParseExact("14:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay && DateTime.Now.TimeOfDay < DateTime.ParseExact("22:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay)
            {
                rb_3.Checked = true;

                rb_2.Enabled = false;
                rb_1.Enabled = false;
                
            }
            if ((DateTime.Now.TimeOfDay >= DateTime.ParseExact("22:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay && DateTime.Now.TimeOfDay < DateTime.ParseExact("23:59:59", "HH:mm:ss", CultureInfo.InvariantCulture).TimeOfDay))
            {
                rb_1.Checked = true;

                rb_2.Enabled = false;
                rb_3.Enabled = false;
                
            }
            if((DateTime.Now.TimeOfDay >= DateTime.ParseExact("00:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay && DateTime.Now.TimeOfDay < DateTime.ParseExact("06:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay))
            {
                rb_1.Checked = true;

                rb_2.Enabled = false;
                rb_3.Enabled = false;
                
            }
            txt_straps_start.Focus();

            /*if (rb_2.Checked)
            {
                string date = DateTime.Now.ToString("dd-MM-yyyy");
                string query_sql = "SELECT tbl_status_around_aid, tbl_around_time, tbl_status_around_date, tbl_income_money_bag, tbl_income_straps, tbl_income_emp_id, tbl_emp_name, tbl_income_cabinet, tbl_income_job, tbl_income_in_time, tbl_income_out_time, tbl_income_total, tbl_income_user, tbl_income_other, tbl_cpoint_name,tbl_cpoint_id, STR_TO_DATE( tbl_status_around_date, '%e-%c-%Y' ) AS date_around, '3' AS sta ,tbl_status_around_cpoint_sub_id FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id  WHERE ( tbl_income_user <> 0) AND DATEDIFF( STR_TO_DATE('" + date + "', '%e-%c-%Y'), STR_TO_DATE( tbl_status_around_date, '%e-%c-%Y' ) ) = " + day + " AND tbl_status_around_cpoint_id = '" + cpoint_id + "' AND tbl_status_around_cpoint_sub_id = '" + maniForm.sub_cpoint + "' UNION SELECT tbl_status_around_aid, tbl_around_time, tbl_status_around_date, tbl_income_money_bag, tbl_income_straps, tbl_income_emp_id, tbl_emp_name, tbl_income_cabinet, tbl_income_job, tbl_income_in_time, tbl_income_out_time, tbl_income_total, tbl_income_fine AS tbl_income_user, tbl_income_other, tbl_cpoint_name,tbl_cpoint_id, STR_TO_DATE( tbl_status_around_date, '%e-%c-%Y' ) AS date_around , '2' AS sta, tbl_status_around_cpoint_sub_id FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE ( tbl_income_fine <> 0) AND DATEDIFF( STR_TO_DATE('" + date + "', '%e-%c-%Y'), STR_TO_DATE( tbl_status_around_date, '%e-%c-%Y' ) ) = " + day + " AND tbl_status_around_cpoint_id = '" + maniForm.cpoint_id + "' AND tbl_status_around_cpoint_sub_id = '" + maniForm.sub_cpoint + "'";
                MySqlDataReader rs = script.Select_SQL(query_sql);

                if (rs.Read()&& File.ReadAllText(script.file_cpoint).Split('|')[3] == "1")
                {
                    FineAndUser30DayForm fineAndUser = new FineAndUser30DayForm(maniForm, this);
                    fineAndUser.ShowDialog();
                    if (!fineAndUser.status)
                    {
                        this.Close();
                    }
                }
            }*/
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            AroundForm form = new AroundForm(maniForm, cpoint_id);
            form.Show();
            this.Close();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (rb_2.Checked || rb_1.Checked || rb_3.Checked)
            {
                if (txt_straps_start.Text.Trim() != "" && txt_straps_start.Text.Trim().Length >5)
                {
                    string around = (rb_2.Checked ? rb_2.Text : rb_1.Checked ? rb_1.Text : rb_3.Checked ? rb_3.Text : "");
                    if (MessageBox.Show("ยืนยันการเปิดกะ \r\nวันที่ " + lb_date_show.Text + "\r\n" + around+"\r\nหมายเลขสายรัดเริ่มต้น : "+txt_straps_start.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Script script = new Script();
                        //script.AddCheckStraps(txt_straps_start.Text, emp_id);
                        InsertAround();

                    }
                }
                else
                {
                    MessageBox.Show("กรุณาใส่หมายเลขสายรัดเริ่มต้น 6 หรือ 8 หลัก", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกผลัด", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void InsertAround()
        {
            if (script.AddCheckStraps(txt_straps_start.Text))
            {
                ConnectDB contxt = new ConnectDB();
                MySqlConnection conn = new MySqlConnection();
                conn = new MySqlConnection(contxt.context());
                int aid = 0;

                if (rb_2.Checked)
                {
                    //MessageBox.Show("2");
                    aid = 2;
                }
                if (rb_3.Checked)
                {
                    //MessageBox.Show("3");
                    aid = 3;
                }
                if (rb_1.Checked)
                {
                    //MessageBox.Show("1");
                    aid = 1;
                }
                conn.Open();
                DateTime date_send = new Script().GetDateAround();
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO tbl_status_around (tbl_status_around_aid,tbl_status_around_emp_open_id,tbl_status_around_close,tbl_status_around_date,tbl_status_around_cpoint_id,tbl_status_around_cpoint_sub_id) VALUES(@aid, @emp_id,'0',@date,@cpoint,@subcpoint)";
                comm.Parameters.Add("@aid", aid);
                comm.Parameters.Add("@emp_id", emp_id);
                comm.Parameters.Add("@date", date_send.ToString("dd-MM-yyyy"));
                comm.Parameters.Add("@cpoint", cpoint_id);
                comm.Parameters.Add("@subcpoint", maniForm.sub_cpoint);
                comm.ExecuteNonQuery();
                conn.Close();

                StreamWriter file = new StreamWriter(script.file_around);
                file.WriteLine(emp_id + "|" + aid + "|" + date_send.ToString("dd-MM-yyyy") + "|" + txt_straps_start.Text + "|");
                file.Close();

                FileInfo DirInfo2 = new FileInfo(filename);
                if (DirInfo2.Exists)
                {
                    string[] data1 = File.ReadAllText(new Script().file_around).Split('|');
                    Script script = new Script();
                    string status_around_id = "";
                    MySqlDataReader rs = script.Select_SQL("SELECT * FROM tbl_status_around WHERE `tbl_status_around_aid`='" + data1[1] + "' AND `tbl_status_around_emp_open_id`='" + data1[0] + "' AND `tbl_status_around_close` = '0'");
                    if (rs.Read())
                    {
                        status_around_id = rs.GetString("tbl_status_around_id");
                        string[] data = File.ReadAllLines(filename);
                        foreach (string line in data)
                        {
                            string[] line_data = line.Split('|');
                            script.InsertUpdae_SQL("UPDATE tbl_income SET tbl_income_around_id = '" + status_around_id + "' WHERE tbl_income_emp_id='" + line_data[0] + "' AND tbl_income_around_id ='10000000000000' AND tbl_income_money_bag = '" + line_data[1] + "'");
                        }
                        File.Delete(filename);
                    }
                    rs.Close();
                    script.conn.Close();
                }

                //maniForm.Refresh();
                Application.Restart();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txt_straps_start_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script scriptCode = new Script();
            scriptCode.CheckNumber(e);
        }

        private void txt_straps_end_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script scriptCode = new Script();
            scriptCode.CheckNumber(e);
        }

        private void txt_straps_start_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_straps_start_KeyUp(object sender, KeyEventArgs e)
        {
            if (!script.CheckDupStraps(txt_straps_start.Text))
            {
                txt_straps_start.Clear();
            }
        }
    }
}
