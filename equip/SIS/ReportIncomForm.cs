using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace TIS
{
    public partial class ReportIncomForm : Form
    {
        MenuForm mainForm = null;
        Script script = new Script();
        public ReportIncomForm(Form callForm)
        {
            mainForm = callForm as MenuForm;
            InitializeComponent();
        }

        private void ReportIncomForm_Load(object sender, EventArgs e)
        {
            date_start_r1.CustomFormat = "dd-MM-yyyy";
            if (mainForm.line9 == "9" || mainForm.cpoint_id == "701" || mainForm.cpoint_id == "702" || mainForm.cpoint_id == "710")
            {
                btn_report1.Enabled = false;
                btn_report2.Text += script.GetCpoint(mainForm.cpoint_id);
            }
            else
            {
                btn_report1.Enabled = true;
                btn_report1.Text += script.GetCpoint(mainForm.cpoint_id) + " " + mainForm.sub_cpoint;
                btn_report2.Text += script.GetCpoint(mainForm.cpoint_id);
            }

            if (mainForm.line9 == "9")
            {
                button1.Visible = true;
            }
        }

        private void btn_report1_Click(object sender, EventArgs e)
        {
            GetReport(GetAroundCheck(), date_start_r1.Text, false, false, false);
        }

        private void btn_report2_Click(object sender, EventArgs e)
        {
            GetReport(GetAroundCheck(), date_start_r1.Text, true, false, false);
        }

        public void GetReport(int around, string date, bool all, bool print, bool sendBank)
        {
            if (around != 0)
            {
                script.Load_page();
                MySqlDataAdapter adap = new MySqlDataAdapter();
                MySqlConnection conn = script.conn;
                MySqlCommand cmd;
                DataSet_Report reportDB = new DataSet_Report();
                PopupReport popup = new PopupReport();
                popup.Text = "รายงานการนำส่งรายได้ค่าธรรมเนียมผ่านทาง";
                string sql = "";
                string sql1 = "";
                string sql_mana = "";
                if (sendBank)
                {
                }
                else
                {
                    string sql_line9 = "IF(tbl_income_over_sys=0,null,tbl_income_over_sys)";
                    if (mainForm.line9 == "9")
                    {
                        sql_line9 = "null";
                    }

                    if (all)
                    {
                        string sum_select = "(SELECT SUM(tbl_incom_other_amount) FROM tbl_incom_other WHERE tbl_incom_other_date_send = '" + date_start_r1.Text + "' AND ( tbl_incom_other_list_incom_id = 2 OR tbl_incom_other_list_incom_id = 3 ) AND tbl_incom_cpoint_id = '" + mainForm.cpoint_id + "')";
                        sql = "SELECT tbl_status_around_aid, tbl_around_time, tbl_status_around_date, tbl_income_money_bag, tbl_income_straps AS tbl_income_straps, IF( tbl_income_emp_id IS NULL, 'ถุงเงินพิเศษ', tbl_income_emp_id ) AS tbl_income_emp_id, IF( e.tbl_emp_name IS NULL, CONCAT(o.`tbl_emp_name`,'(รองฯ)'), e.tbl_emp_name ) AS tbl_emp_name, tbl_income_cabinet, tbl_income_job, tbl_income_in_time, tbl_income_out_time, tbl_income_total, tbl_income_bank, IF(tbl_income_user_tmp=0,null,tbl_income_user_tmp) as tbl_income_user, IF(tbl_income_fine_tmp=0,null,tbl_income_fine_tmp) as tbl_income_fine, IF(tbl_income_other=0,null,tbl_income_other) as tbl_income_other, tbl_cpoint_name, STR_TO_DATE( tbl_status_around_date, '%e-%c-%Y' ) AS date_around,IF(tbl_income_over = 0,null,tbl_income_over) as tbl_income_over," + sql_line9 + " as tbl_income_over_sys,IF(tbl_income_other_ts2=0,null,tbl_income_other_ts2) as tbl_income_other_ts2 FROM tbl_income LEFT JOIN tbl_emp e ON e.tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id LEFT JOIN tbl_emp o ON o.`tbl_emp_id` = `tbl_status_around_emp_open_id`";
                        sql += " WHERE tbl_status_around_aid = '" + around + "' AND tbl_status_around_date = '" + date + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' ORDER BY tbl_income_cabinet,tbl_income_job";
                        sql1 = "SELECT tbl_incom_other_around AS tbl_status_around_aid, '" + date_start_r1.Text + "' AS tbl_around_time, tbl_incom_other_date AS tbl_status_around_date, tbl_incom_other_bag AS tbl_income_money_bag, tbl_incom_other_straps AS tbl_income_straps, IF(tbl_incom_other_emp_id IS NOT NULL,'ถุงเงินพิเศษ',NULL) AS tbl_income_emp_id, IF(tbl_incom_other_emp_id IS NOT NULL,'*ผู้ใช้ทางและค่าปรับบัตรหายที่เกิน 30 วัน',NULL) AS tbl_emp_name, '' AS tbl_income_cabinet, '' AS tbl_income_job, '' AS tbl_income_in_time, '' AS tbl_income_out_time, " + sum_select + " AS tbl_income_total, " + sum_select + " AS tbl_income_bank, '0' AS tbl_income_user, '0' AS tbl_income_fine, '0' AS tbl_income_other, '" + script.GetCpoint(mainForm.cpoint_id) + "' AS tbl_cpoint_name, STR_TO_DATE( tbl_incom_other_date_send, '%e-%c-%Y' ) AS date_around FROM tbl_incom_other  WHERE tbl_incom_other_date_send ='" + date_start_r1.Text + "' AND (tbl_incom_other_list_incom_id = 2 OR tbl_incom_other_list_incom_id = 3) AND tbl_incom_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY tbl_incom_cpoint_sub_id";
                        sql_mana = "SELECT tbl_emp_name ,tbl_emp_group_name,CONCAT(tbl_cpoint_name,' ',tbl_status_around_cpoint_sub_id) AS cpoint_report FROM tbl_status_around a JOIN tbl_emp e ON a.tbl_status_around_emp_open_id = e.tbl_emp_id JOIN tbl_emp_group g ON g.tbl_emp_group_id = e.tbl_emp_group_id JOIN tbl_cpoint c ON c.tbl_cpoint_id = a.tbl_status_around_cpoint_id WHERE tbl_status_around_aid = '" + around + "' AND tbl_status_around_date = '" + date + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' ORDER BY tbl_status_around_cpoint_sub_id";
                    }
                    else
                    {
                        sql = "SELECT tbl_status_around_aid, tbl_around_time, tbl_status_around_date, tbl_income_money_bag, tbl_income_straps AS tbl_income_straps, IF( tbl_income_emp_id IS NULL, 'ถุงเงินพิเศษ', tbl_income_emp_id ) AS tbl_income_emp_id, IF( e.tbl_emp_name IS NULL, CONCAT(o.`tbl_emp_name`,'(รองฯ)'), e.tbl_emp_name ) AS tbl_emp_name, tbl_income_cabinet, tbl_income_job, tbl_income_in_time, tbl_income_out_time, tbl_income_total, tbl_income_bank, IF(tbl_income_user_tmp=0,null,tbl_income_user_tmp) as tbl_income_user, IF(tbl_income_fine_tmp=0,null,tbl_income_fine_tmp) as tbl_income_fine, IF(tbl_income_other=0,null,tbl_income_other) as tbl_income_other, tbl_cpoint_name, STR_TO_DATE( tbl_status_around_date, '%e-%c-%Y' ) AS date_around,IF(tbl_income_over = 0,null,tbl_income_over) as tbl_income_over," + sql_line9 + " as tbl_income_over_sys,IF(tbl_income_other_ts2=0,null,tbl_income_other_ts2) as tbl_income_other_ts2 FROM tbl_income LEFT JOIN tbl_emp e ON e.tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id LEFT JOIN tbl_emp o ON o.`tbl_emp_id` = `tbl_status_around_emp_open_id`";
                        sql += " WHERE tbl_status_around_aid = '" + around + "' AND tbl_status_around_date = '" + date + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' AND tbl_status_around_cpoint_sub_id = '" + mainForm.sub_cpoint + "' ORDER BY tbl_income_cabinet,tbl_income_job";
                        sql1 = "SELECT tbl_incom_other_around AS tbl_status_around_aid, '" + date_start_r1.Text + "' AS tbl_around_time, tbl_incom_other_date AS tbl_status_around_date, tbl_incom_other_bag AS tbl_income_money_bag, tbl_incom_other_straps AS tbl_income_straps, IF(tbl_incom_other_emp_id IS NOT NULL,'ถุงเงินพิเศษ',NULL) AS tbl_income_emp_id, IF(tbl_incom_other_emp_id IS NOT NULL,'*ผู้ใช้ทางและค่าปรับบัตรหายที่เกิน 30 วัน',NULL) AS tbl_emp_name, '' AS tbl_income_cabinet, '' AS tbl_income_job, '' AS tbl_income_in_time, '' AS tbl_income_out_time, SUM(tbl_incom_other_amount) AS tbl_income_total, SUM(tbl_incom_other_amount) AS tbl_income_bank, '0' AS tbl_income_user, '0' AS tbl_income_fine, '0' AS tbl_income_other, '" + script.GetCpoint(mainForm.cpoint_id) + "' AS tbl_cpoint_name, STR_TO_DATE( tbl_incom_other_date_send, '%e-%c-%Y' ) AS date_around FROM tbl_incom_other  WHERE tbl_incom_other_date_send ='" + date_start_r1.Text + "' AND (tbl_incom_other_list_incom_id = 2 OR tbl_incom_other_list_incom_id = 3) AND tbl_incom_cpoint_id = '" + mainForm.cpoint_id + "' AND tbl_incom_cpoint_sub_id = '" + mainForm.sub_cpoint + "'";
                        sql_mana = "SELECT tbl_emp_name ,tbl_emp_group_name,CONCAT(tbl_cpoint_name,' ',tbl_status_around_cpoint_sub_id) AS cpoint_report FROM tbl_status_around a JOIN tbl_emp e ON a.tbl_status_around_emp_open_id = e.tbl_emp_id JOIN tbl_emp_group g ON g.tbl_emp_group_id = e.tbl_emp_group_id JOIN tbl_cpoint c ON c.tbl_cpoint_id = a.tbl_status_around_cpoint_id WHERE tbl_status_around_aid = '" + around + "' AND tbl_status_around_date = '" + date + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' AND tbl_status_around_cpoint_sub_id = '" + mainForm.sub_cpoint + "' ORDER BY tbl_status_around_cpoint_sub_id";
                    }
                }

                cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Close();
                conn.Open();
                cmd.CommandText = sql;

                adap.SelectCommand = cmd;
                reportDB.Clear();
                adap.Fill(reportDB, "Report_Around");
                conn.Close();

                if (reportDB.Tables[0].Rows.Count < 1)
                {
                    MessageBox.Show("ไม่พบข้อมูล", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (sendBank)
                    {
                        /*
                        ReportSendBank p_sendBank = new ReportSendBank();
                        p_sendBank.SetDataSource(reportDB);
                        p_sendBank.SetParameterValue("user_print", mainForm.emp_control_id + " " + script.GetEmpName(mainForm.emp_control_id));
                        p_sendBank.SetParameterValue("date_job", date_start_r1.Value);
                        p_sendBank.SetParameterValue("sub_cpoint", all ? "" : mainForm.sub_cpoint);

                        popup.cry_View.ReportSource = p_sendBank;
                        popup.Show();
                        */
                    }
                    else
                    {
                        CrystalReport1 myReport = new CrystalReport1();
                        myReport.SetDataSource(reportDB);
                        string us_p = "Administrator System";
                        if (mainForm.emp_control_id != "") { us_p = script.GetEmpName(mainForm.emp_control_id); }
                        myReport.SetParameterValue("user_print", us_p);
                        myReport.SetParameterValue("date_job", date_start_r1.Value);
                        myReport.SetParameterValue("sub_cpoint", all ? "" : mainForm.sub_cpoint);
                        int i = 1;
                        int sub = script.GetSubNum(int.Parse(mainForm.cpoint_id));
                        MySqlDataReader rs = script.Select_SQL(sql_mana);
                        while (rs.Read())
                        {
                            myReport.SetParameterValue("DeputyManager" + i, rs.GetString("tbl_emp_name"));
                            if (sub > 1)
                            {
                                myReport.SetParameterValue("cpoint" + i, rs.GetString("cpoint_report"));
                            }
                            else
                            {
                                myReport.SetParameterValue("cpoint" + i, rs.GetString("cpoint_report").Substring(0,rs.GetString("cpoint_report").Length-1));
                            }
                            

                            string[] pos = rs.GetString("tbl_emp_group_name").Split(' ');
                            if (pos.Length > 2)
                            {
                                string pos_tmp = "";
                                for (int j = 0; j < pos.Length; j++) { if (j == 0) { pos_tmp += pos[j] + "\r\n"; } else { pos_tmp += pos[j] + " "; } }
                                myReport.SetParameterValue("DeputyManager" + i + "_pos", pos_tmp);
                            }
                            else
                            {
                                myReport.SetParameterValue("DeputyManager" + i + "_pos", rs.GetString("tbl_emp_group_name"));
                            }
                            i++;
                        }
                        rs.Close();
                        script.conn.Close();

                        if (i <= 3)
                        {
                            if (i <= 2)
                            {
                                myReport.SetParameterValue("cpoint2", "");
                                myReport.SetParameterValue("DeputyManager2", "");
                                myReport.SetParameterValue("DeputyManager2_pos", "");
                            }
                            myReport.SetParameterValue("cpoint3", "");
                            myReport.SetParameterValue("DeputyManager3", "");
                            myReport.SetParameterValue("DeputyManager3_pos", "");
                        }

                        if (print)
                        {
                            try
                            {
                                myReport.PrintToPrinter(1, true, 0, 0);
                            }
                            catch
                            {
                                MessageBox.Show("พิมพ์ไม่สำเร็จ กรุณาพิมพ์ในระบบย้อนหลัง", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            //myReport.PrintToPrinter(1, true, 0, 0);
                            popup.cry_View.ReportSource = myReport;
                            if (!all)
                            {
                                popup.cry_View.ShowPrintButton = false;
                                popup.cry_View.ShowExportButton = false;
                            }
                            popup.Show();
                        }
                    }
                }
            }
        }

        private int GetAroundCheck()
        {
            if (rd_p1.Checked) { return 1; }
            if (rd_p2.Checked) { return 2; }
            if (rd_p3.Checked) { return 3; }
            MessageBox.Show("กรุณาเลือกผลัด", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return 0;
        }

        private void date_start_r1_ValueChanged(object sender, EventArgs e)
        {
            if (date_start_r1.Value > DateTime.Today)
            {
                //MessageBox.Show("เลือกวันที่ไม่ถูกต้อง");
                date_start_r1.Value = DateTime.Today;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TS3FormReport s3FormReport = new TS3FormReport(mainForm, GetAroundCheck(), date_start_r1.Value);
            s3FormReport.ShowDialog();
        }
    }
}
