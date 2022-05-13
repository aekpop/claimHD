using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TIS
{
    class Script
    {
        //public ConnectDB contxt = new ConnectDB();E:\Code Project\TIS\SIS\Script.cs
        public string file_conf = "conf.setting";
        public string file_cpoint = "cpoint.setting";
        public string file_Straps = "settingStraps.setting";
        public string file_around = "around.conf";
        public string file_head_moterway = "head_moterway.txt";
        public string adminlog = "logadmin.filelog";
        public MySqlConnection conn = new MySqlConnection(new ConnectDB().context());
        BackgroundWorker bgWorker;
        ProgressDlg progressDlg;
        private static Bitmap bmpScreenshot;
        private static Graphics gfxScreenshot;
        public void CheckNumber(KeyPressEventArgs e)
        {
            if (e.KeyChar != 46)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        public void Set_Max_Connection()
        {
            try
            {
                string sql = "SET global max_connections = 1000000";
                conn.Close();
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = sql;
                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch { conn.Close(); }
        }

        public bool CheckTime(string time)
        {
            if (time.Length > 4)
            {
                int HH = int.Parse(time.Split(':')[0]);
                int MM = int.Parse(time.Split(':')[1]);
                if (HH < 24 && MM < 60)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetAroundName(string around_id)
        {
            switch (around_id)
            {
                case "1":
                    return "ผลัดที่ 1 เวลา 22:00 น. - 06:00 น.";
                case "2":
                    return "ผลัดที่ 2 เวลา 06:00 น. - 14:00 น.";
                case "3":
                    return "ผลัดที่ 3 เวลา 14:00 น. - 22:00 น.";
                default: return null;
            }

        }

        public string GetAroundTime(string around_id)
        {
            switch (around_id)
            {
                case "1":
                    return "22:00 น. - 06:00 น.";
                case "2":
                    return "06:00 น. - 14:00 น.";
                case "3":
                    return "14:00 น. - 22:00 น.";
                default: return null;
            }

        }

        public bool CheckCabinet(TextBox txt_cabinet)
        {
            /*string sql = "SELECT * FROM tbl_income WHERE tbl_income_status_job = '0' AND tbl_income_cabinet = '" + txt_cabinet.Text + "'";
            MySqlDataReader rs = Select_SQL(sql);
            if (rs.Read())
            {
                MessageBox.Show("ตู้ซ้ำ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cabinet.Clear();
                txt_cabinet.Focus();
                return false;
            }*/
            return true;
        }

       

        public void CheckCabinet2(TextBox txt_job)
        {
 
                string sql_cabinet = "SELECT * FROM tbl_status_cabinet WHERE  tbl_status_cabinet_job = '1' ";//and tbl_status_cabinet_date = Now() tbl_status_cabinet_open = '" + txt_cb.Text + "' AND
                MySqlDataReader rs = Select_SQL(sql_cabinet);
                if (!rs.Read())
                {
                    MessageBox.Show("เลขที่งานซ้ำ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_job.Clear();
                }

        }

        public int GetAroundInt()
        {
            return int.Parse(File.ReadAllText(file_around).Split('|')[1]);

        }

        public MySqlDataReader Select_SQL(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Close();
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                //conn.Close();
                return reader;
            }
            catch { conn.Close(); }
            return null;
        }

        public bool InsertUpdae_SQL(string sql)
        {
            ConnectDB contxt = new ConnectDB();
            conn.Close();
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = sql;
            try
            {
                if (comm.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch
            {
                conn.Close();
                MessageBox.Show("มีปัญหาในการเชื่อมต่อฐานข้อมูล");
                return false;
            }

        }

        public string GetMontThai_yoi(DateTime date)
        {
            string date_txt = "";
            date_txt = date.Day.ToString();
            switch (date.Month.ToString())
            {
                case "1":
                    date_txt += " ม.ค.";
                    break;
                case "2":
                    date_txt += " ก.พ.";
                    break;
                case "3":
                    date_txt += " มี.ค.";
                    break;
                case "4":
                    date_txt += " เม.ย.";
                    break;
                case "5":
                    date_txt += " พ.ค.";
                    break;
                case "6":
                    date_txt += " มิ.ย.";
                    break;
                case "7":
                    date_txt += " ก.ค.";
                    break;
                case "8":
                    date_txt += " ส.ค.";
                    break;
                case "9":
                    date_txt += " ก.ย.";
                    break;
                case "10":
                    date_txt += " ต.ค.";
                    break;
                case "11":
                    date_txt += " พ.ย.";
                    break;
                case "12":
                    date_txt += " ธ.ค.";
                    break;
                default:
                    date_txt += " ";
                    break;
            }
            date_txt += ((date.Year + 543).ToString() + " ").Substring(2, 3);
            return date_txt;
        }

        public string GetMontThai(DateTime date)
        {
            string date_txt = "";
            date_txt = date.Day.ToString();
            switch (date.Month.ToString())
            {
                case "1":
                    date_txt += " มกราคม ";
                    break;
                case "2":
                    date_txt += " กุมภาพันธ์ ";
                    break;
                case "3":
                    date_txt += " มีนาคม ";
                    break;
                case "4":
                    date_txt += " เมษายน ";
                    break;
                case "5":
                    date_txt += " พฤษภาคม ";
                    break;
                case "6":
                    date_txt += " มิถุนายน ";
                    break;
                case "7":
                    date_txt += " กรกฎาคม ";
                    break;
                case "8":
                    date_txt += " สิงหาคม ";
                    break;
                case "9":
                    date_txt += " กันยายน ";
                    break;
                case "10":
                    date_txt += " ตุลาคม ";
                    break;
                case "11":
                    date_txt += " พฤศจิกายน ";
                    break;
                case "12":
                    date_txt += " ธันวาคม ";
                    break;
                default:
                    date_txt += " ";
                    break;
            }
            date_txt += (date.Year + 543);
            return date_txt;
        }

        public string NextStraps(int straps)
        {
            string nextStraps = "";
            if (straps.ToString().Length < 8)
            {
                switch (straps.ToString().Length)
                {
                    case 1:
                        nextStraps = "00000" + straps;
                        break;
                    case 2:
                        nextStraps = "0000" + straps;
                        break;
                    case 3:
                        nextStraps = "000" + straps;
                        break;
                    case 4:
                        nextStraps = "00" + straps;
                        break;
                    case 5:
                        nextStraps = "0" + straps;
                        break;

                }
            }
            return nextStraps;
        }

        public string GetStraps(string emp_control)
        {
            string check_first = "SELECT* FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_emp` ON `tbl_emp_id` = `tbl_income_emp_id` WHERE tbl_status_around_close = '0' AND tbl_status_around_cpoint_id = '" + File.ReadAllText(file_cpoint).Split('|')[0] + "' AND tbl_status_around_cpoint_sub_id = '" + File.ReadAllText(file_cpoint).Split('|')[1] + "' ORDER BY tbl_income_id DESC ";
            MySqlDataReader rs_check_first = Select_SQL(check_first);
            if (rs_check_first.Read() && !rs_check_first.IsDBNull(0))
            {
                string query_straps = "SELECT tbl_straps_number AS tbl_income_straps FROM tbl_straps JOIN tbl_status_around ON tbl_straps_emp_operate = tbl_status_around_emp_open_id WHERE tbl_status_around_close = '0' AND tbl_straps_emp_operate = '" + emp_control + "' AND SUBSTRING(tbl_straps_date,1,10) = DATE(NOW()) UNION SELECT tbl_income_straps FROM tbl_income JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id  WHERE tbl_status_around_close = '0' AND tbl_status_around_cpoint_id = '" + File.ReadAllText(file_cpoint).Split('|')[0] + "' AND tbl_status_around_cpoint_sub_id = '" + File.ReadAllText(file_cpoint).Split('|')[1] + "' AND tbl_income_bank <> 0  ORDER BY tbl_income_straps DESC";
                string[] straps = { "", "", "" };
                MySqlDataReader reader = Select_SQL(query_straps);
                try
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            straps[0] = reader.GetString("tbl_income_straps");
                            straps[1] = (int.Parse(reader.GetString("tbl_income_straps")) + 1).ToString();
                            if (straps[1].Trim().Length < 8)
                            {
                                switch (straps[1].Length)
                                {
                                    case 1:
                                        straps[1] = "00000" + straps[1];
                                        break;
                                    case 2:
                                        straps[1] = "0000" + straps[1];
                                        break;
                                    case 3:
                                        straps[1] = "000" + straps[1];
                                        break;
                                    case 4:
                                        straps[1] = "00" + straps[1];
                                        break;
                                    case 5:
                                        straps[1] = "0" + straps[1];
                                        break;

                                }
                            }
                        }
                        else
                        {
                            return File.ReadAllText(file_around).Split('|')[3];
                        }
                    }
                    else
                    {
                        return File.ReadAllText(file_around).Split('|')[3];
                    }
                    reader.Close();
                    conn.Close();
                }
                catch { conn.Close(); }
                conn.Close();
                return straps[1];
            }
            else
            {
                string sql = "SELECT tbl_straps_number FROM tbl_straps JOIN tbl_status_around ON tbl_straps_emp_operate = tbl_status_around_emp_open_id WHERE tbl_status_around_close = '0' AND tbl_straps_emp_operate = '" + emp_control + "' AND `tbl_straps_number`='" + File.ReadAllText(file_around).Split('|')[3] + "' AND SUBSTRING(tbl_straps_date,1,10) = DATE(NOW())";
                MySqlDataReader rs = new Script().Select_SQL(sql);
                if (rs.Read())
                {
                    string straps = (int.Parse(rs.GetString("tbl_straps_number")) + 1).ToString();
                    if (straps.Trim().Length < 5)
                    {
                        switch (straps.Length)
                        {
                            case 1:
                                straps = "00000" + straps;
                                break;
                            case 2:
                                straps = "0000" + straps;
                                break;
                            case 3:
                                straps = "000" + straps;
                                break;
                            case 4:
                                straps = "00" + straps;
                                break;
                            case 5:
                                straps = "0" + straps;
                                break;

                        }
                        conn.Close();
                        return straps;
                    }
                }
                conn.Close();
                return File.ReadAllText(file_around).Split('|')[3];
            }

        }

        public bool AddCheckStraps(string straps_start)
        {
            int straps_start_int = int.Parse(File.ReadAllText(file_Straps).Split('|')[0]);
            int straps_end_int = int.Parse(File.ReadAllText(file_Straps).Split('|')[1]);
            /////////// insert
            if (int.Parse(straps_start) >= straps_start_int && int.Parse(straps_start) <= straps_end_int && straps_start.Length > 5)
            {
                string sql = "SELECT * FROM tbl_straps WHERE tbl_straps_number ='" + straps_start + "' AND SUBSTR(tbl_straps_date,1,10) = '" + DateTime.Now.Date + "'";
                return true;
            }
            else
            {
                MessageBox.Show("หมายเลขสายรัดไม่ถูกต้องกรุณาตรวจสอบ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //return true;
            conn.Close();
            return false;
        }

        public void GetStrapsEmp(string emp_id, string emp_con, string around, TextBox txt_emp, Label lb_straps, Label income, TextBox txt_straps, Label txt_bag)
        {
            string query_straps = "SELECT tbl_income_id, tbl_income_straps, tbl_emp_name,tbl_income_money_bag FROM tbl_income JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id WHERE tbl_status_around_aid = '" + around + "' AND tbl_status_around_close = '0' AND tbl_income_emp_id = '" + emp_id + "' ORDER BY tbl_income_id DESC";
            MySqlDataReader reader = Select_SQL(query_straps);
            try
            {
                if (reader.Read())
                {
                    income.Text = reader.GetString("tbl_income_id");
                    txt_emp.Text = reader.GetString("tbl_emp_name");
                    lb_straps.Text = reader.GetString("tbl_income_straps");
                    txt_straps.Text = reader.GetString("tbl_income_straps");
                    txt_bag.Text = reader.GetString("tbl_income_money_bag");
                }
                else
                {
                    txt_emp.Text = "ไม่พบข้อมูลการเบิกสายรัด";
                    txt_straps.Clear();
                    ///txt_straps.Text = "ไม่พบข้อมูลการเบิกสายรัด";
                }
                reader.Close();
                conn.Close();
            }
            catch { conn.Close(); }
        }

        public void GetStraps(TextBox emp_id, string emp_con, string around, TextBox txt_emp, Label lb_straps, Label income, TextBox txt_straps, Label txt_bag, int radio_check)
        {
            string query_straps = "SELECT tbl_income_id, tbl_income_straps, tbl_emp_name,tbl_income_money_bag,tbl_emp_id FROM tbl_income JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id WHERE tbl_status_around_aid = '" + around + "'  AND tbl_status_around_close = '0' AND tbl_income_straps = '" + txt_straps.Text.Trim() + "' ORDER BY tbl_income_id DESC";
            MySqlDataReader reader = Select_SQL(query_straps);
            try
            {
                if (reader.Read())
                {
                    if (radio_check == 1)
                    {
                        if (reader.IsDBNull(2))
                        {
                            income.Text = reader.GetString("tbl_income_id");
                            txt_emp.Text = "ถุงเงินพิเศษ";
                            lb_straps.Text = reader.GetString("tbl_income_straps");
                            txt_straps.Text = reader.GetString("tbl_income_straps");
                            txt_bag.Text = reader.GetString("tbl_income_money_bag");
                        }
                    }

                    if (radio_check == 2)
                    {
                        income.Text = reader.GetString("tbl_income_id");
                        emp_id.Text = reader.GetString("tbl_emp_id");
                        txt_emp.Text = reader.GetString("tbl_emp_name");
                        lb_straps.Text = reader.GetString("tbl_income_straps");
                        txt_straps.Text = reader.GetString("tbl_income_straps");
                        txt_bag.Text = reader.GetString("tbl_income_money_bag");
                    }
                }
                else
                {
                    txt_emp.Text = "ไม่พบข้อมูลสายรัด";
                    //txt_straps.Clear();
                    ///txt_straps.Text = "ไม่พบข้อมูลการเบิกสายรัด";
                }
                reader.Close();
                conn.Close();
            }
            catch { conn.Close(); }
        }

        public bool CheckDupStraps(string straps)
        {
            string sql = "SELECT * FROM tbl_straps WHERE tbl_straps_number = '" + straps + "' AND SUBSTR(tbl_straps_date, 1, 10) <= CURDATE() AND SUBSTR(tbl_straps_date, 1, 10) >= DATE_ADD(CURDATE(),INTERVAL -30 DAY)";
            MySqlDataReader rs = Select_SQL(sql);
            if (rs.Read())
            {
                MessageBox.Show("สายรัดถูกใช้ไปแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.Close();
                return false;
            }
            conn.Close();
            return true;
        }

        public string GetEmpName(string emp_id)
        {
            string sql = "SELECT * FROM tbl_emp WHERE tbl_emp_id = '" + emp_id + "'";
            MySqlDataReader reader = Select_SQL(sql);
            try
            {
                if (reader.Read())
                {
                    return reader.GetString("tbl_emp_name");
                }
                else
                {
                    return "ไม่พบข้อมูลพนักงาน";
                }
            }
            catch
            {
            }
            reader.Close();
            conn.Close();
            return "";
        }

        public string GetEmpGroup(string emp_id)
        {
            string sql = "SELECT * FROM `tbl_emp` e JOIN `tbl_emp_group` g ON e.`tbl_emp_group_id` = g.`tbl_emp_group_id` WHERE e.`tbl_emp_id` = '" + emp_id + "'";
            MySqlDataReader reader = Select_SQL(sql);
            try
            {
                if (reader.Read())
                {
                    //conn.Close();
                    return reader.GetString("tbl_emp_group_name");
                }
                else
                {
                    conn.Close();
                    return "ไม่พบข้อมูลพนักงาน";
                }
            }
            catch
            {
                conn.Close();
            }
            reader.Close();
            conn.Close();
            return "";
        }

        public bool DuplicateBag(string bag, int around)
        {
            string sql_around = "SELECT * FROM tbl_income LEFT JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id WHERE (STR_TO_DATE( tbl_status_around_date, '%e-%c-%Y' ) = CURDATE() AND tbl_status_around_aid <> '1') AND tbl_income_money_bag = '" + bag + "'";
            MySqlDataReader rs = Select_SQL(sql_around);
            if (!rs.Read())
            {
                return true;
            }
            rs.Close();
            return false;
        }
        public bool DuplicateBagNext(string bag)
        {
            string sql_aroundNext = "SELECT *  FROM `tbl_income`   WHERE tbl_income_around_id = '10000000000000' AND tbl_income_money_bag = '" + bag + "'";
            MySqlDataReader rs = Select_SQL(sql_aroundNext);
            if (!rs.Read())
            {
                return true;
            }
            rs.Close();
            return false;
        }

        public void Report4(string sql, string txt, string table, string bag_report, string date, int status)
        {
            Load_page();
            MySqlCommand cmd = new MySqlCommand();
            DataSet_Report reportDB = new DataSet_Report();
            MySqlDataAdapter adap = new MySqlDataAdapter();
            CrystalReport4 report4 = new CrystalReport4();

            cmd.Connection = conn;
            cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            adap.SelectCommand = cmd;
            reportDB.Clear();
            adap.Fill(reportDB, table);
            report4.SetDataSource(reportDB);

            report4.SetParameterValue("bag_report", bag_report);
            report4.SetParameterValue("date_report", GetMontThai(DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture)));
            switch (status)
            {
                case 0:
                    report4.SetParameterValue("para_type", "\r\n(ปรับยอด)");
                    report4.SetParameterValue("head_table", "หมายเหตุ");
                    report4.SetParameterValue("title_head", "ปรับยอด");
                    break;
                case 1:
                    report4.SetParameterValue("para_type", "");
                    report4.SetParameterValue("head_table", "ประเภท\r\nเงินนำส่ง");
                    report4.SetParameterValue("title_head", "ผู้ใช้ทางและค่าปรับบัตร");
                    break;
                case 2:
                    report4.SetParameterValue("para_type", "");
                    report4.SetParameterValue("head_table", "ประเภท\r\nเงินนำส่ง");
                    report4.SetParameterValue("title_head", "ติดตามยอดจากระบบ");
                    break;
            }
            report4.SetParameterValue("user_print", File.ReadAllText(file_around).Split('|')[0] + " " + GetEmpName(File.ReadAllText(file_around).Split('|')[0]));
            //reportIncomeKST.PrintToPrinter(1, true, 0, 0);

            PopupReport popup = new PopupReport();

            popup.cry_View.ReportSource = report4;
            popup.Text = txt;
            //popup.cry_View.Zoom(80);
            popup.Show();
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressDlg.ProgressValue = e.ProgressPercentage;
        }

        // This event handler deals with the results of the background operation.
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            progressDlg.Close();
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 1; i <= 100; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(50);
                    worker.ReportProgress(i);
                }
            }
        }

        public void Load_page()
        {
            // New BackgroundWorker

            bgWorker = new BackgroundWorker();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);

            // Start the asynchronous operation.
            bgWorker.RunWorkerAsync();

            // New Dialog
            progressDlg = new ProgressDlg();
            progressDlg.stopProgress = new EventHandler((s, e1) =>
            {
                switch (progressDlg.DialogResult)
                {
                    // When click stop button from Progress Dialog
                    case DialogResult.Cancel:
                        bgWorker.CancelAsync();
                        progressDlg.Close();
                        break;
                }
            });
            progressDlg.ShowDialog();
        }

        /*public bool CheckStrapsRemain()
        {
            string sql = "SELECT * FROM tbl_straps WHERE tbl_straps_status IS NULL";
            MySqlDataReader rs = Select_SQL(sql);
            if (rs.Read())
            {
                StrapsRemainForm strapsRemain = new StrapsRemainForm();
                strapsRemain.ShowDialog();
            }
            else
            {
                AroundCloseForm closeAround = new AroundCloseForm();
                closeAround.ShowDialog();
            }

            return true;
        }*/

        public bool CloseAround(string emp_contorl_id)
        {
            bool ck_job = false;
            string sql_check_job = "SELECT * FROM tbl_income JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id WHERE tbl_income_status_job = '0' AND tbl_status_around_emp_open_id = '" + emp_contorl_id + "'";
            MySqlDataReader reader = Select_SQL(sql_check_job);
            if (!reader.Read())
            {
                ck_job = true;
            }
            else
            {
                MessageBox.Show("ยังประกาศยอดพนักงานไม่ครบ ไม่สามารถปิดกะได้", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ck_job = false;
            }
            reader.Close();
            conn.Close();
            return ck_job;
        }

        public DataGridView GetDataGridViewStatus(DataGridView dataGridView1)
        {
            string[] cid = File.ReadAllText(file_cpoint).Split('|');
            string sql = "SELECT `tbl_income_money_bag` AS 'ถุงเงิน',tbl_income_cabinet AS 'ตู้ที่',`tbl_income_emp_id` AS 'รหัสพนักงาน', IF(`tbl_emp_name` IS NULL,'ถุงเงินพิเศษ (ปรับยอด)',tbl_emp_name) AS 'ชื่อ-สกุล', `tbl_income_money` AS 'เงินยืม' , `tbl_income_straps` AS 'หมายเลขสายรัด',IF(`tbl_emp_name` IS NULL,tbl_income_bank,IF(tbl_income_other=0,tbl_income_other_ts2,tbl_income_other)) AS 'ปรับยอด', IF( tbl_income_status_backmaney = '1', 'คืนเงินยืมแล้ว', IF(tbl_income_status_backmaney IS NULL,'','ยังไม่คืนเงินยืม')) AS 'สถานะเงินยืม' , IF( tbl_income_status_job = '1', 'เสร็จสิ้น', IF(tbl_income_bank IS NULL,'กำลังปฏิบัติงาน','รอวิเคราะห์งาน') ) AS 'สถานะงาน', concat('" + cid[0] + "-',tbl_income_id) AS 'Ref.'  FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id`=`tbl_status_around_id` LEFT JOIN `tbl_emp` ON `tbl_emp_id` =`tbl_income_emp_id`  WHERE tbl_status_around_close = '0' AND tbl_status_around_cpoint_id = '" + cid[0] + "' AND tbl_status_around_cpoint_sub_id = '" + cid[1] + "' ORDER BY `tbl_income_money_bag` DESC";
            ConnectDB contxt = new ConnectDB();
            MySqlConnection conn = new MySqlConnection();
            conn = new MySqlConnection(contxt.context());
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "emp_job");
            conn.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "emp_job";

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["ปรับยอด"].Value.ToString() != "0")
                {
                    dataGridView1.Rows[i].Cells["ปรับยอด"].Style.ForeColor = Color.Red;

                }

                if (dataGridView1.Rows[i].Cells["สถานะเงินยืม"].Value.ToString() == "คืนเงินยืมแล้ว")
                {
                    dataGridView1.Rows[i].Cells["สถานะเงินยืม"].Style.BackColor = ColorTranslator.FromHtml("#228B22");
                    dataGridView1.Rows[i].Cells["สถานะเงินยืม"].Style.ForeColor = Color.White;
                }
                else
                {
                    if (dataGridView1.Rows[i].Cells["สถานะเงินยืม"].Value.ToString() != "")
                    {
                        dataGridView1.Rows[i].Cells["สถานะเงินยืม"].Style.BackColor = ColorTranslator.FromHtml("#FF3300");
                        dataGridView1.Rows[i].Cells["สถานะเงินยืม"].Style.ForeColor = Color.White;
                    }
                }

                if (dataGridView1.Rows[i].Cells["สถานะงาน"].Value.ToString() == "เสร็จสิ้น")
                {
                    dataGridView1.Rows[i].Cells["สถานะงาน"].Style.BackColor = ColorTranslator.FromHtml("#228B22");
                    dataGridView1.Rows[i].Cells["สถานะงาน"].Style.ForeColor = Color.White;
                }
                else if (dataGridView1.Rows[i].Cells["สถานะงาน"].Value.ToString() == "รอวิเคราะห์งาน")
                {
                    dataGridView1.Rows[i].Cells["สถานะงาน"].Style.BackColor = ColorTranslator.FromHtml("#CC3399");
                    dataGridView1.Rows[i].Cells["สถานะงาน"].Style.ForeColor = Color.White;
                }
                else
                {
                    dataGridView1.Rows[i].Cells["สถานะงาน"].Style.BackColor = ColorTranslator.FromHtml("#FF3300");
                    dataGridView1.Rows[i].Cells["สถานะงาน"].Style.ForeColor = Color.White;
                }
            }
            dataGridView1.AutoResizeColumns();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            conn.Close();
            return dataGridView1;
        }

        public DateTime GetDateAround()
        {
            DateTime date_send = DateTime.Now;
            if (date_send.TimeOfDay >= DateTime.ParseExact("22:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay && date_send.TimeOfDay <= DateTime.ParseExact("23:59:59", "HH:mm:ss", CultureInfo.InvariantCulture).TimeOfDay)
            {
                date_send = date_send.AddDays(1);
            }
            return date_send;
        }

        public DateTime GetDateAround(int around)
        {
            DateTime date_send = DateTime.Today.Date;
            if (around == 1)
            {
                date_send = date_send.AddDays(1);
            }
            return date_send;
        }
        public DateTime DateTimeParse(string date)
        {
            return DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public string getEmpName_Group(string emp_id, Label label)
        {
            string sql = "SELECT * FROM tbl_emp e JOIN tbl_emp_group g ON e.tbl_emp_group_id=g.tbl_emp_group_id WHERE `tbl_emp_id` = '" + emp_id + "'";
            ConnectDB contxt = new ConnectDB();
            MySqlConnection conn = new MySqlConnection();
            conn = new MySqlConnection(contxt.context());
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            string emp_data = null;
            try
            {
                if (reader.Read())
                {
                    label.Text = reader.GetString("tbl_emp_name").Trim();
                    label.Text += "\r\nตำแหน่ง " + reader.GetString("tbl_emp_group_name");
                    label.ForeColor = Color.Blue;
                }
                else
                {
                    label.Text = "ไม่พบข้อมูล";
                    label.ForeColor = Color.Red;

                }
                reader.Close();
            }
            catch
            {
                //MessageBox.Show(e.ToString());
                conn.Close();
            }
            conn.Close();
            return emp_data;
        }

        public int getEmp_Group(string emp_id)
        {
            string sql = "SELECT * FROM tbl_emp e JOIN tbl_emp_group g ON e.tbl_emp_group_id=g.tbl_emp_group_id WHERE `tbl_emp_id` = '" + emp_id + "'";
            ConnectDB contxt = new ConnectDB();
            MySqlConnection conn = new MySqlConnection();
            conn = new MySqlConnection(contxt.context());
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            int emp_data = 0;
            try
            {
                if (reader.Read())
                {
                    emp_data = int.Parse(reader.GetString("tbl_emp_group_id").Trim());
                }
                reader.Close();
            }
            catch
            {
                //MessageBox.Show(e.ToString());
                conn.Close();
            }
            conn.Close();
            return emp_data;
        }

        public string getEmpName_Group(string emp_id)
        {
            string sql = "SELECT * FROM tbl_emp e JOIN tbl_emp_group g ON e.tbl_emp_group_id=g.tbl_emp_group_id WHERE `tbl_emp_id` = '" + emp_id + "'";
            ConnectDB contxt = new ConnectDB();
            MySqlConnection conn = new MySqlConnection();
            conn = new MySqlConnection(contxt.context());
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            string emp_data = null;
            try
            {
                if (reader.Read())
                {
                    emp_data = reader.GetString("tbl_emp_name").Trim();
                    emp_data += "|" + reader.GetString("tbl_emp_group_name").Trim();
                }
                else
                {
                    emp_data = "ไม่พบข้อมูล";

                }
                reader.Close();
                conn.Close();
            }
            catch
            {
                //MessageBox.Show(e.ToString());
                conn.Close();
            }
            conn.Close();
            return emp_data;
        }

        public string ThaiBaht(string txt)
        {
            string bahtTxt, n, bahtTH = "";
            double amount;
            try { amount = Convert.ToDouble(txt); }
            catch { amount = 0; }
            bahtTxt = amount.ToString("####.00");
            string[] num = { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
            string[] rank = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };
            string[] temp = bahtTxt.Split('.');
            string intVal = temp[0];
            string decVal = temp[1];
            if (Convert.ToDouble(bahtTxt) == 0)
                bahtTH = "ศูนย์บาทถ้วน";
            else
            {
                for (int i = 0; i < intVal.Length; i++)
                {
                    n = intVal.Substring(i, 1);
                    if (n != "0")
                    {
                        if ((i == (intVal.Length - 1)) && (n == "1"))
                            bahtTH += "เอ็ด";
                        else if ((i == (intVal.Length - 2)) && (n == "2"))
                            bahtTH += "ยี่";
                        else if ((i == (intVal.Length - 2)) && (n == "1"))
                            bahtTH += "";
                        else
                            bahtTH += num[Convert.ToInt32(n)];
                        bahtTH += rank[(intVal.Length - i) - 1];
                    }
                }
                bahtTH += "บาท";
                if (decVal == "00")
                    bahtTH += "ถ้วน";
                else
                {
                    for (int i = 0; i < decVal.Length; i++)
                    {
                        n = decVal.Substring(i, 1);
                        if (n != "0")
                        {
                            if ((i == decVal.Length - 1) && (n == "1"))
                                bahtTH += "เอ็ด";
                            else if ((i == (decVal.Length - 2)) && (n == "2"))
                                bahtTH += "ยี่";
                            else if ((i == (decVal.Length - 2)) && (n == "1"))
                                bahtTH += "";
                            else
                                bahtTH += num[Convert.ToInt32(n)];
                            bahtTH += rank[(decVal.Length - i) - 1];
                        }
                    }
                    bahtTH += "สตางค์";
                }
            }
            return bahtTH;
        }

        public string GetStrapsLast()
        {
            /*string check_first = "SELECT* FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_emp` ON `tbl_emp_id` = `tbl_income_emp_id` WHERE `tbl_status_around_aid` = '" + File.ReadAllText(file_around).Split('|')[1] + "' AND `tbl_status_around_emp_open_id` = '" + File.ReadAllText(file_around).Split('|')[0] + "' AND tbl_status_around_close = '0' AND tbl_income_status_job = '1' ORDER BY tbl_income_id DESC ";
            MySqlDataReader rs_check_first = Select_SQL(check_first);
            if (rs_check_first.Read())
            {*/
            string sql = "SELECT tbl_straps_number FROM tbl_straps WHERE tbl_straps_emp_control = '" + File.ReadAllText(file_around).Split('|')[0] + "'";
            MySqlDataReader rs = Select_SQL(sql);
            string strapsLast = "";
            int strapsNum = 0;
            while (rs.Read())
            {
                strapsNum = int.Parse(rs.GetString("tbl_straps_number"));
            }
            strapsNum += 1;
            switch (strapsNum.ToString().Length)
            {
                case 1:
                    strapsLast = "00000" + strapsNum;
                    break;
                case 2:
                    strapsLast = "0000" + strapsNum;
                    break;
                case 3:
                    strapsLast = "000" + strapsNum;
                    break;
                case 4:
                    strapsLast = "00" + strapsNum;
                    break;
                case 5:
                    strapsLast = "0" + strapsNum;
                    break;

            }

            if (strapsNum == 1)
            {
                conn.Close();
                return File.ReadAllText(file_Straps).Split('|')[0];
            }
            else
            {
                if (int.Parse(strapsLast) > int.Parse(File.ReadAllText(file_Straps).Split('|')[1]))
                {
                    conn.Close();
                    return File.ReadAllText(file_Straps).Split('|')[0];
                }
                else
                {
                    conn.Close();
                    return strapsLast;
                }
            }

            /*}
            else
            {
                return File.ReadAllText(file_around).Split('|')[3];
            }*/

        }

        public int GetPrivilege(string emp_id)
        {
            string sql = "SELECT * FROM tbl_emp WHERE tbl_emp_id = '" + emp_id + "'";
            int privilege = 6;
            MySqlDataReader reader = Select_SQL(sql);
            if (reader.Read())
            {
                privilege = int.Parse(reader.GetString("tbl_emp_group_id"));
            }
            reader.Close();
            conn.Close();
            return privilege;
        }

        public string GetCpoint(string cpoint)
        {
            MySqlDataReader rs = Select_SQL("SELECT * FROM tbl_cpoint WHERE tbl_cpoint_id = '" + cpoint + "'");
            if (rs.Read())
            {
                return rs.GetString("tbl_cpoint_name");
            }
            conn.Close();
            return "";
        }

        public string GetCpointTel(string cpoint)
        {
            MySqlDataReader rs = Select_SQL("SELECT * FROM tbl_cpoint WHERE tbl_cpoint_id = '" + cpoint + "'");
            if (rs.Read())
            {
                //conn.Close();
                return rs.GetString("tbl_cpoint_tel");
            }
            conn.Close();
            return "";
        }

        public void comboBoxProvince(ComboBox province)
        {
            string sql = "SELECT * FROM province ORDER BY PROVINCE_ID";
            MySqlDataReader rs = Select_SQL(sql);
            while (rs.Read())
            {
                province.Items.Add(rs.GetString("PROVINCE_NAME"));
            }
            rs.Close();
            conn.Close();
        }

        public void comboBoxTypeCar(ComboBox type_car)
        {
            string sql = "SELECT * FROM tbl_type_car ORDER BY type_car_id";
            MySqlDataReader rs = Select_SQL(sql);
            while (rs.Read())
            {
                type_car.Items.Add(rs.GetString("type_car_name"));
            }
        }

        public void CheckEmpWorking(TextBox txt_emp_id, Label lb_emp_name)
        {
            if (txt_emp_id.Text.Length > 1)
            {
                string sql = "SELECT *  FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id`=`tbl_status_around_id` LEFT JOIN `tbl_emp` ON `tbl_emp_id` =`tbl_income_emp_id`  WHERE tbl_status_around_close = '0' AND tbl_status_around_cpoint_id = '" + File.ReadAllText(file_cpoint).Split('|')[0] + "' AND tbl_status_around_cpoint_sub_id = '" + File.ReadAllText(file_cpoint).Split('|')[1] + "' AND tbl_income_emp_id = '" + txt_emp_id.Text + "' AND `tbl_income_status_job` = '0' ORDER BY `tbl_income_money_bag` desc";
                MySqlDataReader rs = Select_SQL(sql);
                if (rs.Read())
                {
                    MessageBox.Show("พนักงานอยู่ในสถานะกำลังปฏบัติงาน \r\nกรุณาทำการประกาศยอดก่อนเริ่มทำงานใหม่", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_emp_id.Clear();
                }
                else
                {
                    lb_emp_name.Text = GetEmpName(txt_emp_id.Text);
                }
                rs.Close();
            }
            conn.Close();
        }

        public void CheckEmpAdd(TextBox txt_emp_id, Label lb_emp_name)
        {
            if (txt_emp_id.Text.Length > 1)
            {
                string sql = "SELECT *  FROM `tbl_income`   WHERE tbl_income_around_id = '10000000000000' AND tbl_income_emp_id = '" + txt_emp_id.Text + "'";
                MySqlDataReader rs = Select_SQL(sql);
                if (rs.Read())
                {
                    MessageBox.Show("พนักงานอยู่ในสถานะกำลังปฏบัติงาน \r\nกรุณาทำการประกาศยอดก่อนเริ่มทำงานใหม่", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_emp_id.Clear();
                }
                else
                {
                    lb_emp_name.Text = GetEmpName(txt_emp_id.Text);
                }
                rs.Close();
            }
            conn.Close();
        }

        public DataSet_Report getDataSet(string sql_query, string table)
        {
            MySqlDataAdapter adap = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            DataSet_Report dataSet = new DataSet_Report();
            //string nameCpoint = script.GetCpoint(File.ReadAllText(script.file_cpoint).Split('|')[0]);

            cmd.Connection = conn;
            conn.Close();
            conn.Open();
            cmd.CommandText = sql_query;

            adap.SelectCommand = cmd;
            dataSet.Clear();
            adap.Fill(dataSet, table);
            conn.Close();

            return dataSet;
        }

        public void GetReportTollNotPay(DateTime date_memo, string txt_id_card, string txt_card_num)
        {
            Thread progressThread = new Thread(delegate ()
            {
                ProgressForm progress = new ProgressForm();
                progress.ShowDialog();
            });


            PopupReport popup = new PopupReport();
            TollNotPayment defectiveStraps = new TollNotPayment();
            string sql_query = "SELECT `memo_name_cus`, `memo_home_no`, `memo_moo`, `memo_soi`, `memo_rd`, `memo_subdis`, `memo_dis`, `memo_province_add`, `memo_tel`, `memo_mobile`, `memo_id_card`, `memo_drive_id`, `memo_card_no`, `memo_card_issuer`, `memo_cpoint_id`, `memo_time`, `memo_cabinet`, `memo_type`, `memo_type_id`, `memo_license_plate`, `memo_province_plate`, `memo_brand`, `memo_color`, `mome_note`, `memo_amount`, `memo_fine_amount`, `memo_status`, `memo_bill_book`, `memo_bill_no`, `memo_date_payment`, `memo_emp_id`, `memo_emp_id_payment`, `memo_bag`, `memo_strapes`,STR_TO_DATE(memo_card_is_date, '%d-%m-%Y') AS memo_card_is_date,STR_TO_DATE(memo_card_ex_date, '%d-%m-%Y') AS memo_card_ex_date,STR_TO_DATE(memo_date, '%d-%m-%Y') AS memo_date FROM tbl_memo LEFT JOIN tbl_type_car ON memo_type_id = type_car_id WHERE (memo_id_card = '" + txt_id_card + "' OR memo_card_no = '" + txt_card_num + "') AND memo_status IS NULL AND memo_date = '" + date_memo.ToString("dd-MM-yyyy") + "' order by memo_id desc";
            DataSet_Report setMemo = getDataSet(sql_query, "tbl_memo");
            if (setMemo.Tables["tbl_memo"].Rows.Count < 1)
            {
                MessageBox.Show("ไม่พบข้อมูล", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                progressThread.Start();
                defectiveStraps.SetDataSource(setMemo);
                defectiveStraps.SetParameterValue("para_date_ex", date_memo.AddDays(7));
                defectiveStraps.SetParameterValue("para_cpoint", GetCpoint(File.ReadAllText(file_cpoint).Split('|')[0]));
                defectiveStraps.SetParameterValue("para_subcpoint", File.ReadAllText(file_cpoint).Split('|')[3] == "9" ? "" : File.ReadAllText(file_cpoint).Split('|')[1]);
                defectiveStraps.SetParameterValue("emp_memo", GetEmpName(File.ReadAllText(file_around).Split('|')[0]));
                defectiveStraps.SetParameterValue("emp_group", GetEmpGroup(File.ReadAllText(file_around).Split('|')[0]));

                popup.cry_View.ReportSource = defectiveStraps;
                popup.Show();
                progressThread.Abort();
            }

        }
        public string NotManager(string emp_id)
        {
            string pos_txt = "";
            if (getEmp_Group(emp_id) <30)
            {
                pos_txt = getEmpName_Group(emp_id).Split('|')[1] + "\r\nปฏิบัติหน้าที่แทนผู้จัดการด่านฯ ";
            }
            else
            {
                pos_txt = getEmpName_Group(emp_id).Split('|')[1];
            }
            return pos_txt;
        }

        public string GetPosEmp(int group)
        {
            string sql = "SELECT * FROM tbl_emp_group WHERE tbl_emp_group_id = '" + group + "'";
            MySqlDataReader rs = Select_SQL(sql);
            if (rs.Read())
            {
                return rs.GetString("tbl_emp_group_name");
            }
            return "";
        }

        public int GetSubNum(int cpoint)
        {
            string sql = "SELECT COUNT(*) AS num FROM tbl_cpoint_sub WHERE tbl_cpoint_sub_cid = '" + cpoint + "'";
            MySqlDataReader rs = Select_SQL(sql);
            if (rs.Read())
            {
                return rs.GetInt32("num");
            }
            return 0;
        }       

        public void SaveImages(string filename, string cpoint)
        {
            /*Thread.Sleep(500);
            Screenshot(filename);

            string part = "ftp://10.6.3.201/" + DateTime.Now.ToString("MMM-yyyy") + "/" + cpoint + "/" + DateTime.Now.ToString("dd-MMM-") + (DateTime.Now.Year + 543);
            if (CreateFTPDirectory(part, cpoint))
            {
                uploadFile(part + "/" + filename, "D:\\" + filename, "ftpuser", "admin");
            }
            else
            {
                uploadFile(part + "/" + filename, "D:\\" + filename, "ftpuser", "admin");
            }*/
        }
        public void Screenshot(string filename)
        {
            try
            {
                bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                gfxScreenshot = Graphics.FromImage(bmpScreenshot);
                gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                bmpScreenshot.Save(@"D:\" + filename, ImageFormat.Jpeg);
                gfxScreenshot.Dispose();
            }
            catch { }
        }

        private void uploadFile(string FTPAddress, string filePath, string username, string password)
        {
            //Create FTP request
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(FTPAddress);

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = false;
            request.UseBinary = true;
            request.KeepAlive = false;

            //Load the file
            FileStream stream = File.OpenRead(filePath);
            byte[] buffer = new byte[stream.Length];

            stream.Read(buffer, 0, buffer.Length);
            stream.Close();

            //Upload file
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            //MessageBox.Show("Uploaded Successfully");
        }

        private bool CreateFTPDirectory(string directory, string cpoint)
        {
            directory = DateTime.Now.ToString("MMM-yyyy") + "/" + cpoint + "/" + DateTime.Now.ToString("dd-MMM-") + (DateTime.Now.Year + 543);
            string[] folder = directory.Split('/');
            string ftp = "ftp://10.6.3.201/";
            try
            {
                //create the directory
                for (int i = 0; i < folder.Length; i++)
                {
                    ftp += "/" + folder[i];
                    FtpWebRequest requestDir = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftp));
                    requestDir.Method = WebRequestMethods.Ftp.MakeDirectory;
                    requestDir.Credentials = new NetworkCredential("ftpuser", "admin");
                    requestDir.UsePassive = false;
                    requestDir.UseBinary = true;
                    requestDir.KeepAlive = false;
                    FtpWebResponse response = (FtpWebResponse)requestDir.GetResponse();
                    Stream ftpStream = response.GetResponseStream();

                    ftpStream.Close();
                    response.Close();
                }
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    response.Close();
                    return true;
                }
                else
                {
                    response.Close();
                    return false;
                }
            }
        }
        /*public void AddStraps(TextBox txt_straps, Form callForm)
        {
            Script script = new Script();
            string query_straps = "SELECT COUNT(*) AS count_row FROM tbl_straps WHERE tbl_straps_status IS NULL ORDER BY tbl_straps_number";
            MySqlDataReader reader = script.Select_SQL(query_straps);
            if (reader.Read())
            {
                if (int.Parse(reader.GetString("count_row")) < 1)
                {
                    if (MessageBox.Show("สายรัดหมด ต้องการเพิ่มสายรัดใหม่ ใช่หรือไม่", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FineAndUser30DayForm addStrapsForm = new FineAndUser30DayForm(txt_straps);
                        addStrapsForm.ShowDialog();
                        if (txt_straps.Text == "")
                        {
                            callForm.Close();
                        }
                    }
                    else
                    {
                        callForm.Close();
                    }
                }
            }
            else
            {
                callForm.Close();
            }
        }*/

    }
}
