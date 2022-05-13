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
    public partial class DefectiveFrom : Form
    {
        Script script = new Script();
        AdminScript adminScript = new AdminScript();
        String sql_select = "";
        public DefectiveFrom()
        {
            InitializeComponent();
        }

        private void DefectiveFrom_Load(object sender, EventArgs e)
        {
            date_start.CustomFormat = "MM-yyyy";
            dateSummary.CustomFormat = "yyyy";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string strCon = "server=192.168.101.91;database=tis_main;uid=admintis;pwd=admin25;charset=utf8;";
            reportStrapes(false, script.conn, File.ReadAllText(script.file_cpoint).Split('|')[0]);
        }

        private void reportStrapes(bool print, MySqlConnection para_conn, string cpoint)
        {
            try
            {
                string num = "";
                string sql_num = "SELECT COUNT(*) AS num FROM tbl_straps s LEFT JOIN tbl_emp e ON s.tbl_straps_emp_operate = e.tbl_emp_id LEFT JOIN tbl_emp c ON c.tbl_emp_id = s.tbl_straps_emp_control WHERE MONTH(s.tbl_straps_date) = '" + date_start.Value.Month + "' AND YEAR(s.tbl_straps_date) = '" + date_start.Value.Year + "' AND tbl_straps_status = 1  AND (tbl_straps_note LIKE 'พนักงานเก็บเงินดึงสายรัดขาด%' OR tbl_straps_note LIKE 'ตัดสายรัด เนื่องจากยอดนำส่งรายได้ผิด%' OR tbl_straps_note LIKE 'สายรัดมีตำหนิ%' OR tbl_straps_note LIKE 'อื่นๆ (ระบุหมายเหตุ)%') ORDER BY tbl_straps_date";

                MySqlConnection con = para_conn;
                MySqlCommand cmdd = new MySqlCommand();
                cmdd.Connection = con;
                con.Close();
                con.Open();
                cmdd.CommandText = sql_num;
                MySqlDataReader rs = cmdd.ExecuteReader();
                if (rs.Read())
                {
                     num = rs.GetInt32("num").ToString();
                }

                string sql_query = "SELECT tbl_straps_date AS date_value , s.tbl_straps_number AS straps,CONCAT(e.tbl_emp_id,' ',e.tbl_emp_name) AS emp, CONCAT(c.tbl_emp_id,' ',c.tbl_emp_name) AS control, s.tbl_straps_note AS note FROM tbl_straps s LEFT JOIN tbl_emp e ON s.tbl_straps_emp_operate = e.tbl_emp_id LEFT JOIN tbl_emp c ON c.tbl_emp_id = s.tbl_straps_emp_control WHERE MONTH(s.tbl_straps_date) = '" + date_start.Value.Month + "' AND YEAR(s.tbl_straps_date) = '" + date_start.Value.Year + "' AND tbl_straps_status = 1  AND (tbl_straps_note LIKE 'พนักงานเก็บเงินดึงสายรัดขาด%' OR tbl_straps_note LIKE 'ตัดสายรัด เนื่องจากยอดนำส่งรายได้ผิด%' OR tbl_straps_note LIKE 'สายรัดมีตำหนิ%' OR tbl_straps_note LIKE 'อื่นๆ (ระบุหมายเหตุ)%') ORDER BY tbl_straps_date";
                //string sql_query = "SELECT tbl_straps_date AS date_value , s.tbl_straps_number AS straps,CONCAT(e.tbl_emp_id,' ',e.tbl_emp_name) AS emp, CONCAT(c.tbl_emp_id,' ',c.tbl_emp_name) AS control, s.tbl_straps_note AS note FROM tbl_straps s LEFT JOIN tbl_emp e ON s.tbl_straps_emp_operate = e.tbl_emp_id LEFT JOIN tbl_emp c ON c.tbl_emp_id = s.tbl_straps_emp_control WHERE MONTH(s.tbl_straps_date) = '" + date_start.Value.Month + "' AND YEAR(s.tbl_straps_date) = '" + date_start.Value.Year + "' AND tbl_straps_status = 1  AND tbl_straps_note != 'นำไปใช้รัดถุงเงินพิเศษ (ผจด) / ' ORDER BY tbl_straps_date";
                //String num = "SELECT COUNT(*) AS num FROM tbl_straps s LEFT JOIN tbl_emp e ON s.tbl_straps_emp_operate = e.tbl_emp_id LEFT JOIN tbl_emp c ON c.tbl_emp_id = s.tbl_straps_emp_control WHERE MONTH(s.tbl_straps_date) = '12' AND YEAR(s.tbl_straps_date) = '2021' AND tbl_straps_status = 1  AND tbl_straps_note != 'นำไปใช้รัดถุงเงินพิเศษ (ผจด) / ' ORDER BY tbl_straps_date";
                MySqlDataAdapter adap = new MySqlDataAdapter();
                MySqlConnection conn = para_conn;
                MySqlCommand cmd = new MySqlCommand(); ;
                DataSet_Report dataSet1 = new DataSet_Report();
                
                PopupReport popup = new PopupReport();
                string nameCpoint = script.GetCpoint(cpoint);
                

                popup.Text = "รายงานสายรัดชำรุด ด่านฯ" + nameCpoint;
                cmd.Connection = conn;
                conn.Close();
                conn.Open();
                cmd.CommandText = sql_query;
                adap.SelectCommand = cmd;
                dataSet1.Clear();
                adap.Fill(dataSet1, "tbl_strape");
                 
                conn.Close();
                                              
                DefectiveStrapsReport defectiveStraps = new DefectiveStrapsReport();
                defectiveStraps.SetDataSource(dataSet1);
                defectiveStraps.SetParameterValue("para_cpoint", nameCpoint);

                if (print)
                {
                    try
                    {
                        if (num == "0")
                        {
                            MessageBox.Show("ไม่พิมพ์ " + nameCpoint + " เนื่องจากไม่มีข้อมูล", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            defectiveStraps.PrintToPrinter(1, true, 0, 0);
                            MessageBox.Show("พิมพ์ " + nameCpoint + "สำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                    }
                    catch { MessageBox.Show("พิมพ์ " + nameCpoint + "ไม่สำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {
                    popup.cry_View.ReportSource = defectiveStraps;
                    popup.Show();
                }
            }
            catch { MessageBox.Show("พิมพ์ " + script.GetCpoint(cpoint) + "ไม่สำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminScript adminScript = new AdminScript();
            string sql_query = "SELECT tbl_emp_id, tbl_emp_name, (SELECT COUNT(*) FROM `tbl_code_edit` WHERE `tbl_code_user_emp` = e.`tbl_emp_id` AND MONTH(tbl_code_date) = '" + date_start.Value.Month + "' AND YEAR(tbl_code_date) = '" + date_start.Value.Year + "') AS amount , `tbl_code_date`,tbl_cpoint_id,tbl_cpoint_name,tbl_code_note FROM `tbl_code_edit` LEFT JOIN `tbl_emp` e ON `tbl_code_user_emp` = tbl_emp_id LEFT JOIN `tbl_cpoint` ON `tbl_cpoint_id` = `tbl_code_cpoint` WHERE `tbl_code_status` IS NOT NULL AND MONTH(tbl_code_date) = '" + date_start.Value.Month + "' AND YEAR(tbl_code_date) = '" + date_start.Value.Year + "' ORDER BY tbl_cpoint_id,DATE_FORMAT(tbl_code_date,'%d-%m-%Y'),tbl_code_user_emp";
            MySqlDataAdapter adap = new MySqlDataAdapter();
            MySqlConnection conn = new MySqlConnection(adminScript.strCon);
            MySqlCommand cmd = new MySqlCommand(); ;
            DataSet_Report dataSet1 = new DataSet_Report();
            PopupReport popup = new PopupReport();
            string nameCpoint = script.GetCpoint(File.ReadAllText(script.file_cpoint).Split('|')[0]);

            popup.Text = "รายงานการขอแก้ไขงาน ระบบ TIS";
            cmd.Connection = conn;
            conn.Close();
            conn.Open();
            cmd.CommandText = sql_query;

            adap.SelectCommand = cmd;
            dataSet1.Clear();
            adap.Fill(dataSet1, "report_EditJob");
            conn.Close();

            EditJob editJob = new EditJob();
            editJob.SetDataSource(dataSet1);
            /*DefectiveStrapsReport defectiveStraps = new DefectiveStrapsReport();
            defectiveStraps.SetDataSource(dataSet1);
            defectiveStraps.SetParameterValue("para_cpoint", nameCpoint);*/

            popup.cry_View.ReportSource = editJob;
            popup.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ยืนยันการพิมพ์", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                string sql = "SELECT * FROM tbl_cpoint";
                MySqlDataReader rs = script.Select_SQL(sql);
                string[] cpoint_arry = new string[50];
                int i = 0;
                while (rs.Read())
                {
                    cpoint_arry[i] = rs.GetString("tbl_cpoint_id");
                    i++;
                }
                rs.Close();

                for (int j = 0; j <= i; j++)
                {
                    sql = "SELECT * FROM tbl_cpoint WHERE tbl_cpoint_id = '"+ cpoint_arry[j]+ "'";
                    rs = script.Select_SQL(sql);
                    if (rs.Read())
                    {
                        string strCon = "server=" + rs.GetString("tbl_cpoint_host") + ";database=" + rs.GetString("tbl_cpoint_database") + ";uid=" + rs.GetString("tbl_cpoint_user") + ";pwd=" + rs.GetString("tbl_cpoint_pass") + ";charset=utf8;";
                        MySqlConnection sqlConnection = new MySqlConnection(strCon);
                        if (rs.GetString("tbl_cpoint_id").Trim() != "901" && rs.GetString("tbl_cpoint_id").Trim() != "705" && rs.GetString("tbl_cpoint_id").Trim() != "700")
                        {
                            reportStrapes(true, sqlConnection, rs.GetString("tbl_cpoint_id"));
                        }
                    }
                    rs.Close();
                }
                MessageBox.Show("ออกรายงานสำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //rs.Close();
            }
        }

        private void btnReportSummary_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tbl_cpoint";
            MySqlDataReader rs = script.Select_SQL(sql);
            string[] cpoint_arry = new string[50];
            int i = 0;
            while (rs.Read())
            {
                cpoint_arry[i] = rs.GetString("tbl_cpoint_id");
                i++;
            }
            rs.Close();

            for (int j = 0; j <= i; j++)
            {
                sql = "SELECT * FROM tbl_cpoint WHERE tbl_cpoint_id = '" + cpoint_arry[j] + "'";
                rs = script.Select_SQL(sql);
                if (rs.Read())
                {
                    string strCon = "server=" + rs.GetString("tbl_cpoint_host") + ";database=" + rs.GetString("tbl_cpoint_database") + ";uid=" + rs.GetString("tbl_cpoint_user") + ";pwd=" + rs.GetString("tbl_cpoint_pass") + ";charset=utf8;";
                    MySqlConnection sqlConnection = new MySqlConnection(strCon);
                    if (rs.GetString("tbl_cpoint_id").Trim() != "901" && rs.GetString("tbl_cpoint_id").Trim() != "705" && rs.GetString("tbl_cpoint_id").Trim() != "700")
                    {
                        reportSummary(true, sqlConnection, rs.GetString("tbl_cpoint_id"));
                    }
                }
                rs.Close();
            }
        }

        private void reportSummary(bool print, MySqlConnection para_conn, string cpoint)
        {
            sql_select += "SELECT tbl_cpoint_id as cpoint_id,tbl_cpoint_name as cpoint_name, MAX(CASE WHEN date_r = '01-" + dateSummary.Text.Trim() + "' THEN total ELSE 0 END) date_01, MAX(CASE WHEN date_r = '02-" + dateSummary.Text.Trim() + "' THEN total ELSE 0 END) date_02, MAX(CASE WHEN date_r = '03-" + dateSummary.Text.Trim() + "' THEN total ELSE 0 END) date_03, MAX(CASE WHEN date_r = '04-" + dateSummary.Text.Trim() + "' THEN total ELSE 0 END) date_04, MAX(CASE WHEN date_r = '05-" + dateSummary.Text.Trim() + "' THEN total ELSE 0 END) date_05, MAX(CASE WHEN date_r = '06-" + dateSummary.Text.Trim() + "' THEN total ELSE 0 END) date_06, MAX(CASE WHEN date_r = '07-" + dateSummary.Text.Trim() + "' THEN total ELSE 0 END) date_07, MAX(CASE WHEN date_r = '08-" + dateSummary.Text.Trim() + "' THEN total ELSE 0 END) date_08, MAX(CASE WHEN date_r = '09-" + dateSummary.Text.Trim() + "' THEN total ELSE 0 END) date_09, MAX(CASE WHEN date_r = '10-" + dateSummary.Text.Trim() + "' THEN total ELSE 0 END) date_10, MAX(CASE WHEN date_r = '11-" + dateSummary.Text.Trim() + "' THEN total ELSE 0 END) date_11, MAX(CASE WHEN date_r = '12-" + dateSummary.Text.Trim() + "' THEN total ELSE 0 END) date_12 FROM (SELECT DATE_FORMAT(STR_TO_DATE(a.tbl_status_around_date,'%d-%m-%Y'),'%m-%Y') AS date_r,SUM(i.`tbl_income_bank`) AS total,c.`tbl_cpoint_name`,tbl_cpoint_id FROM `tbl_income` i JOIN `tbl_status_around` a ON i.`tbl_income_around_id` = a.`tbl_status_around_id` JOIN `tbl_cpoint` c ON a.`tbl_status_around_cpoint_id` = c.`tbl_cpoint_id` WHERE a.`tbl_status_around_date` LIKE '%" + dateSummary.Text.Trim() + "' GROUP BY date_r) T1 WHERE tbl_cpoint_id = '" + cpoint + "'";
        }


    }
}
