using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace TIS
{
    public partial class TS3FormReport : Form
    {
        Script script = new Script();
        MenuForm mainForm = null;
        int around = 0;
        DateTime date_start_r1;
        public TS3FormReport(Form callFrom, int a, DateTime date)
        {
            mainForm = callFrom as MenuForm;
            around = a;
            date_start_r1 = date;
            InitializeComponent();
        }

        private void TS3FormReport_Load(object sender, EventArgs e)
        {
            string sql = "SELECT tbl_emp_name,tbl_emp_group_name FROM tbl_income JOIN tbl_status_around ON tbl_status_around_id=tbl_income_around_id JOIN tbl_emp ON tbl_income_emp_id = tbl_emp_id JOIN tbl_emp_group ON tbl_emp_group.tbl_emp_group_id = tbl_emp.tbl_emp_group_id WHERE tbl_status_around_date = '" + date_start_r1.ToString("dd-MM-yyyy")+"' AND tbl_status_around_aid = '"+around+ "' AND tbl_emp.tbl_emp_group_id='6'";
            MySqlDataReader rs = script.Select_SQL(sql);
            while (rs.Read())
            {
                comboBox1.Items.Add(rs.GetString("tbl_emp_name"));
                label5.Text = rs.GetString("tbl_emp_group_name")+" (หัวหน้า)";
            }
            rs.Close();
            script.conn.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                script.Load_page();
                MySqlDataAdapter adap = new MySqlDataAdapter();
                MySqlConnection conn = script.conn;
                MySqlCommand cmd;
                DataSet_Report reportDB = new DataSet_Report();
                PopupReport popup = new PopupReport();
                popup.Text = "ใบท้าย ธร.3";
                string sql = "SELECT 'เงินเกินบัญชี' AS title, null AS row_num, tbl_emp_name, CONCAT('ตู้   ',tbl_income_cabinet)  AS tbl_income_cabinet, CONCAT(tbl_income_in_time,' น. - ',tbl_income_out_time,' น.') AS tbl_around_time, 'จำนวน' AS unit, tbl_income_over AS amount FROM tbl_income JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_status_around_id = tbl_income_around_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id  WHERE tbl_status_around_aid = '" + around + "' AND tbl_status_around_date = '" + date_start_r1.ToString("dd-MM-yyyy") + "' AND tbl_income_over > 0 AND tbl_status_around_cpoint_id ='" + mainForm.cpoint_id + "' UNION SELECT 'เงินเกินบัญชี' AS title, 0 AS row_num, NULL AS tbl_emp_name, 'ตู้ 99' AS tbl_income_cabinet, NULL AS tbl_around_time, IF( SUM(tbl_income_over) IS NOT NULL, 'รวม', NULL ) AS unit, SUM(tbl_income_over) AS amount FROM tbl_income JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_status_around_id = tbl_income_around_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '" + around + "' AND tbl_status_around_date = '" + date_start_r1.ToString("dd-MM-yyyy") + "' AND tbl_income_over > 0 AND tbl_status_around_cpoint_id ='" + mainForm.cpoint_id + "' UNION SELECT 'ผู้ใช้ทางไม่รับเงินทอน' AS title, NULL AS row_num, tbl_emp_name, CONCAT('ตู้   ',tbl_income_cabinet) AS tbl_income_cabinet , CONCAT(tbl_income_in_time,' น. - ',tbl_income_out_time,' น.') AS tbl_around_time, 'จำนวน' AS unit, tbl_income_user AS amount FROM tbl_income JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_status_around_id = tbl_income_around_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '" + around + "' AND tbl_status_around_date = '" + date_start_r1.ToString("dd-MM-yyyy") + "' AND tbl_income_user > 0 AND tbl_status_around_cpoint_id ='" + mainForm.cpoint_id + "' UNION SELECT 'ผู้ใช้ทางไม่รับเงินทอน' AS title, 0 AS row_num, NULL AS tbl_emp_name, 'ตู้ 99' AS tbl_income_cabinet, NULL AS tbl_around_time, IF( SUM(tbl_income_user) IS NOT NULL, 'รวม', NULL ) AS unit, SUM(tbl_income_user) AS amount FROM tbl_income JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_status_around_id = tbl_income_around_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '" + around + "' AND tbl_status_around_date = '" + date_start_r1.ToString("dd-MM-yyyy") + "' AND tbl_income_user > 0 AND tbl_status_around_cpoint_id ='" + mainForm.cpoint_id + "' ORDER BY tbl_income_cabinet,tbl_around_time";
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Close();
                conn.Open();
                cmd.CommandText = sql;
                //cmd.Parameters.Add("@row", 1);
                //cmd.Parameters.Add("@row_u", 1);
                adap.SelectCommand = cmd;
                reportDB.Clear();
                adap.Fill(reportDB, "Report_ts3");
                conn.Close();

                Report_TS3 myReport = new Report_TS3();
                string direction = "";
                if (mainForm.cpoint_id == "902" || mainForm.cpoint_id == "904") { direction = "ขาเข้า"; }
                if (mainForm.cpoint_id == "903" || mainForm.cpoint_id == "905") { direction = "ขาออก"; }
                myReport.SetDataSource(reportDB);
                //myReport.SetParameterValue("para_head", "");
                myReport.SetParameterValue("para_cpoint", script.GetCpoint(mainForm.cpoint_id));
                myReport.SetParameterValue("para_around", script.GetAroundTime(around.ToString()));
                myReport.SetParameterValue("para_date", date_start_r1);
                myReport.SetParameterValue("para_in_out", direction);
                myReport.SetParameterValue("para_user", script.getEmpName_Group(textBox1.Text).Split('|')[0]);
                myReport.SetParameterValue("para_group_user", script.NotManager(textBox1.Text));
                myReport.SetParameterValue("para_head", comboBox1.Text);
                myReport.SetParameterValue("para_print", textBox2.Text.Trim());
                myReport.SetParameterValue("pos", label5.Text.Split(':')[0]);

                //myReport.PrintToPrinter(1, true, 0, 0);
                popup.cry_View.ReportSource = myReport;
                popup.Show();
            }
            else
            {

            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            script.getEmpName_Group(textBox1.Text, label2);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
