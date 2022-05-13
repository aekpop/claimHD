using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TIS
{
    public partial class OfficialReportForm : Form
    {
        Script script = new Script();
        MenuForm mainForm = null;
        DateTime date_start;
        DateTime date_end;
        string user_send;
        public OfficialReportForm(Form callFrom, DateTime dStart, DateTime dEnd, string uSend)
        {
            mainForm = callFrom as MenuForm;
            date_start = dStart;
            date_end = dEnd;
            user_send = uSend;
            InitializeComponent();
        }

        private void OfficialReportForm_Load(object sender, EventArgs e)
        {
            label1.Text = "  1. ใบรับส่งทรัพย์สิน\r\n";
            label1.Text += "  2.ใบนำฝากเงิน Pay - In / ใบรับฝากเงิน DEPOSIT RECEIPT\r\n";
            label1.Text += "  3.รายงานการนำส่งเงินรายได้ค่าธรรมเนียมผ่านทาง\r\n";
            if (mainForm.line9 == "9") { label1.Text += "  4.แบบ ธร.3\r\n"; } else { label1.Text += "  4.แบบ ธร.4\r\n"; }
            if (mainForm.line9 == "9") { label1.Text += "  5.แบบ ธร.4\r\n"; } else { label1.Text += "  5.ส่งเงินเกินระบบ\r\n"; }
            if (mainForm.line9 == "9") { label1.Text += "  6.ส่งเงินเกินบัญชี\r\n"; } else { label1.Text += "  6.ส่งเงินผู้ใช้ทางไม่รับเงินทอน\r\n"; }
            if (mainForm.line9 == "9") { label1.Text += "  7.ส่งเงินผู้ใช้ทางไม่รับเงินทอน\r\n"; } else { label1.Text += "  7.ส่งเงินค่าปรับบัตร Transit Card\r\n"; }
            label1.Text += "  8.ส่งเงินผู้ใช้ทางมาชำระเงินภายหลัง(ตามกำหนด)\r\n";
            label1.Text += "  9.ส่งเงินผู้ใช้ทางมาชำระเงินภายหลัง(เกินกำหนด ปรับ 10 เท่า)\r\n";
            label1.Text += "10.ส่งเงินติดตามรายได้\r\n";
            label1.Text += "11.อื่นๆ";

            if ((date_start.Month == date_end.AddDays(1).Month) && (date_start.Year == date_end.AddDays(1).Year))
            {
                date_send.Text = date_start.Day + " - " + script.GetMontThai(date_end.AddDays(1));
            }
            else if ((date_start.Month != date_end.AddDays(1).Month) && (date_start.Year != date_end.AddDays(1).Year))
            {
                //date_send.Text = script.GetMontThai(date_start).Split(' ')[0] + " " + script.GetMontThai(date_start).Split(' ')[1] + " - " + script.GetMontThai(date_end.AddDays(1));
                date_send.Text = script.GetMontThai(date_start).Split(' ')[0] + " " + script.GetMontThai(date_start).Split(' ')[1] + " " + script.GetMontThai(date_start).Split(' ')[2] + " - " + script.GetMontThai(date_end.AddDays(1));
            }
            else  
            {
                date_send.Text = script.GetMontThai(date_start).Split(' ')[0] + " " + script.GetMontThai(date_start).Split(' ')[1] + " - " + script.GetMontThai(date_end.AddDays(1));
               // date_send.Text = script.GetMontThai(date_start).Split(' ')[0] + " " + script.GetMontThai(date_start).Split(' ')[1] + " " + script.GetMontThai(date_start).Split(' ')[2] + " - " + script.GetMontThai(date_end.AddDays(1));
            }
            SelectHisReport();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            SaveHisReport();
            Print(false, 1);
        }

        private int CountDoc()
        {
            int i = 0;

            if (numeric1.Value > 0) { i++; }
            if (numeric2.Value > 0) { i++; }
            if (numeric3.Value > 0) { i++; }
            if (numeric4.Value > 0) { i++; }
            if (numeric5.Value > 0) { i++; }
            if (numeric6.Value > 0) { i++; }
            if (numeric7.Value > 0) { i++; }
            if (numeric8.Value > 0) { i++; }
            if (numeric9.Value > 0) { i++; }
            if (numeric10.Value > 0) { i++; }
            if (numeric11.Value > 0) { i++; }

            return i;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveHisReport();
            Print(false, 2);
        }

        private void Print(bool print, int doc)
        {
            Thread progressThread = new Thread(delegate ()
            {
                ProgressForm progress = new ProgressForm();
                //progress.Text = "กำลังพิมพ์...";
                progress.ShowDialog();
            });

            progressThread.Start();
            if (mainForm.line9 == "9")
            {
                OfficialReport9 report9 = new OfficialReport9();
                report9.SetParameterValue("user_print", script.GetEmpName(mainForm.emp_control_id));
                report9.SetParameterValue("cpoint", script.GetCpoint(mainForm.cpoint_id));
                report9.SetParameterValue("doc_number", txt_doc_num.Text.Trim() == "" ? "                  " : txt_doc_num.Text.Trim());
                report9.SetParameterValue("tel_cpoint", script.GetCpointTel(mainForm.cpoint_id));
                report9.SetParameterValue("date_report", date_send.Text);
                report9.SetParameterValue("num_doc", CountDoc());
                report9.SetParameterValue("1", numeric1.Value.ToString() == "0" ? "-" : numeric1.Value.ToString());
                report9.SetParameterValue("2", numeric2.Value.ToString() == "0" ? "-" : numeric2.Value.ToString());
                report9.SetParameterValue("3", numeric3.Value.ToString() == "0" ? "-" : numeric3.Value.ToString());
                report9.SetParameterValue("4", numeric4.Value.ToString() == "0" ? "-" : numeric4.Value.ToString());
                report9.SetParameterValue("5", numeric5.Value.ToString() == "0" ? "-" : numeric5.Value.ToString());
                report9.SetParameterValue("6", numeric6.Value.ToString() == "0" ? "-" : numeric6.Value.ToString());
                report9.SetParameterValue("7", numeric7.Value.ToString() == "0" ? "-" : numeric7.Value.ToString());
                report9.SetParameterValue("8", numeric8.Value.ToString() == "0" ? "-" : numeric8.Value.ToString());
                report9.SetParameterValue("9", numeric9.Value.ToString() == "0" ? "-" : numeric9.Value.ToString());
                report9.SetParameterValue("10", numeric10.Value.ToString() == "0" ? "-" : numeric10.Value.ToString());
                report9.SetParameterValue("11", numeric11.Value.ToString() == "0" ? "-" : numeric11.Value.ToString());
                report9.SetParameterValue("user_send", script.GetEmpName(user_send));
                report9.SetParameterValue("user_send_group", script.NotManager(user_send));
                report9.SetParameterValue("head_moterway", File.ReadAllLines(script.file_head_moterway));
                report9.SetParameterValue("total_doc", (numeric1.Value + numeric2.Value + numeric3.Value + numeric4.Value + numeric5.Value + numeric6.Value + numeric7.Value + numeric8.Value + numeric9.Value + numeric10.Value + numeric11.Value));
                if (mainForm.line9 == "9") { report9.SetParameterValue("send_h", "1"); } else { if (int.Parse(mainForm.cpoint_id) < 705) { report9.SetParameterValue("send_h", "2"); } else { report9.SetParameterValue("send_h", "3"); } }
                report9.SetParameterValue("other_send", textBox1.Text.Trim());
                report9.SetParameterValue("q_print", doc);

                if (print)
                {
                    try
                    {
                        report9.PrintToPrinter(1, true, 0, 0);
                    }
                    catch
                    {
                        MessageBox.Show("พิมพ์ไม่สำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    PopupReport popup = new PopupReport();
                    popup = new PopupReport();
                    popup.cry_View.ReportSource = report9;
                    //popup.cry_View.PrintMode = false;
                    popup.Text = "บันทึกข้อมความ";
                    //popup.cry_View.Zoom(80);
                    popup.Show();
                }
            }
            else
            {
                OfficialReport7 report7 = new OfficialReport7();
                report7.SetParameterValue("user_print", script.GetEmpName(mainForm.emp_control_id));
                report7.SetParameterValue("cpoint", script.GetCpoint(mainForm.cpoint_id));
                report7.SetParameterValue("doc_number", txt_doc_num.Text.Trim() == "" ? "                   " : txt_doc_num.Text.Trim());
                report7.SetParameterValue("tel_cpoint", script.GetCpointTel(mainForm.cpoint_id));
                report7.SetParameterValue("date_report", date_send.Text);
                report7.SetParameterValue("num_doc", CountDoc());
                report7.SetParameterValue("1", numeric1.Value.ToString() == "0" ? "-" : numeric1.Value.ToString());
                report7.SetParameterValue("2", numeric2.Value.ToString() == "0" ? "-" : numeric2.Value.ToString());
                report7.SetParameterValue("3", numeric3.Value.ToString() == "0" ? "-" : numeric3.Value.ToString());
                report7.SetParameterValue("4", numeric4.Value.ToString() == "0" ? "-" : numeric4.Value.ToString());
                report7.SetParameterValue("5", numeric5.Value.ToString() == "0" ? "-" : numeric5.Value.ToString());
                report7.SetParameterValue("6", numeric6.Value.ToString() == "0" ? "-" : numeric6.Value.ToString());
                report7.SetParameterValue("7", numeric7.Value.ToString() == "0" ? "-" : numeric7.Value.ToString());
                report7.SetParameterValue("8", numeric8.Value.ToString() == "0" ? "-" : numeric8.Value.ToString());
                report7.SetParameterValue("9", numeric9.Value.ToString() == "0" ? "-" : numeric9.Value.ToString());
                report7.SetParameterValue("10", numeric10.Value.ToString() == "0" ? "-" : numeric10.Value.ToString());
                report7.SetParameterValue("11", numeric11.Value.ToString() == "0" ? "-" : numeric11.Value.ToString());
                report7.SetParameterValue("user_send", script.GetEmpName(user_send));
                report7.SetParameterValue("user_send_group", script.NotManager(user_send));
                report7.SetParameterValue("total_doc", (numeric1.Value + numeric2.Value + numeric3.Value + numeric4.Value + numeric5.Value + numeric6.Value + numeric7.Value + numeric8.Value + numeric9.Value + numeric10.Value + numeric11.Value));
                report7.SetParameterValue("head_moterway", File.ReadAllLines(script.file_head_moterway));
                if (mainForm.line9 == "9") { report7.SetParameterValue("send_h", "1"); }
                else
                {
                    if (int.Parse(mainForm.cpoint_id) == 701) { report7.SetParameterValue("send_h", "1"); }
                    else
                    {
                        if (int.Parse(mainForm.cpoint_id) == 702) { report7.SetParameterValue("send_h", "2"); }
                        else
                        {
                            if (int.Parse(mainForm.cpoint_id) == 703) { report7.SetParameterValue("send_h", "2"); }
                            else
                            {
                                if (int.Parse(mainForm.cpoint_id) == 704) { report7.SetParameterValue("send_h", "2"); }
                                else
                                {
                                    if (int.Parse(mainForm.cpoint_id) == 706) { report7.SetParameterValue("send_h", "2"); }
                                    else
                                    {
                                        if (int.Parse(mainForm.cpoint_id) == 707) { report7.SetParameterValue("send_h", "2"); }
                                        else
                                        {
                                            if (int.Parse(mainForm.cpoint_id) == 708) { report7.SetParameterValue("send_h", "2"); }

                                            else { report7.SetParameterValue("send_h", "3"); }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                report7.SetParameterValue("other_send", textBox1.Text.Trim());
                report7.SetParameterValue("q_print", doc);


                if (print)
                {
                    try
                    {
                        report7.PrintToPrinter(1, true, 0, 0);
                    }
                    catch
                    {
                        MessageBox.Show("พิมพ์ไม่สำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    PopupReport popup = new PopupReport();
                    popup = new PopupReport();
                    popup.cry_View.ReportSource = report7;
                    //popup.cry_View.PrintMode = false;
                    popup.Text = "บันทึกข้อมความ";
                    //popup.cry_View.Zoom(80);
                    popup.Show();
                }
            }
            progressThread.Abort();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveHisReport();
            Print(false, 3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveHisReport();
            if (MessageBox.Show("ต้องการพิมพ์ทั้งหมด ใช่หรือไม่", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Print(true, 1);
                Print(true, 2);
                Print(true, 3);
                MessageBox.Show("พิมพ์สำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveHisReport()
        {
            string sql_check = "SELECT * FROM tbl_his_report WHERE his_cpoint = '" + mainForm.cpoint_id + "' AND his_cpoint_sub = '" + mainForm.sub_cpoint + "' AND his_s_date = '" + date_start.ToString("yyyy-MM-dd") + "'";
            string sql_action = "";
            string text = "";
            string values = "";
            MySqlDataReader rs = script.Select_SQL(sql_check);
            if (rs.Read())
            {
                values += "his_not_title = '" + txt_doc_num.Text.Trim() + "'" +
                    ",his_not_1 = '" + numeric1.Value + "'" +
                    ",his_not_2 = '" + numeric2.Value + "'" +
                    ",his_not_3 = '" + numeric3.Value + "'" +
                    ",his_not_4 = '" + numeric4.Value + "'" +
                    ",his_not_5 = '" + numeric5.Value + "'" +
                    ",his_not_6 = '" + numeric6.Value + "'" +
                    ",his_not_7 = '" + numeric7.Value + "'" +
                    ",his_not_8 = '" + numeric8.Value + "'" +
                    ",his_not_9 = '" + numeric9.Value + "'" +
                    ",his_not_10 = '" + numeric10.Value + "'" +
                    ",his_not_11 = '" + numeric11.Value + "'" +
                    ",his_not_11_text = '" + textBox1.Text.Trim() + "'";
                sql_action = "UPDATE tbl_his_report SET " + values + " WHERE his_cpoint = '" + mainForm.cpoint_id + "' AND his_cpoint_sub = '" + mainForm.sub_cpoint + "' AND his_s_date = '" + date_start.ToString("yyyy-MM-dd") + "' ";
                script.InsertUpdae_SQL(sql_action);
            }
            else
            {
                text += "his_not_title,his_not_1,his_not_2,his_not_3,his_not_4,his_not_5,his_not_6,his_not_7,his_not_8,his_not_9,his_not_10,his_not_11,his_not_11_text";
                values += "'" + txt_doc_num.Text.Trim() + "',"
                    + "'" + numeric1.Value + "',"
                    + "'" + numeric2.Value + "',"
                    + "'" + numeric3.Value + "',"
                    + "'" + numeric4.Value + "',"
                    + "'" + numeric5.Value + "',"
                    + "'" + numeric6.Value + "',"
                    + "'" + numeric7.Value + "',"
                    + "'" + numeric8.Value + "',"
                    + "'" + numeric9.Value + "',"
                    + "'" + numeric10.Value + "',"
                    + "'" + numeric11.Value + "',"
                    + "'" + textBox1.Text.Trim() + "',";
                sql_action = "INSERT INTO tbl_his_report (" + text + ") VALUES (" + values + ")";
                script.InsertUpdae_SQL(sql_action);
            }
            rs.Close();
            script.conn.Close();

        }

        private void SelectHisReport()
        {
            try
            {
                string sql = "SELECT * FROM tbl_his_report WHERE his_cpoint = '" + mainForm.cpoint_id + "' AND his_cpoint_sub = '" + mainForm.sub_cpoint + "' AND his_s_date = '" + date_start.ToString("yyyy-MM-dd") + "'";
                MySqlDataReader rs = script.Select_SQL(sql);
                if (rs.Read())
                {
                    txt_doc_num.Text = rs.GetString("his_not_title");
                    numeric1.Value = rs.GetInt32("his_not_1");
                    numeric2.Value = rs.GetInt32("his_not_2");
                    numeric3.Value = rs.GetInt32("his_not_3");
                    numeric4.Value = rs.GetInt32("his_not_4");
                    numeric5.Value = rs.GetInt32("his_not_5");
                    numeric6.Value = rs.GetInt32("his_not_6");
                    numeric7.Value = rs.GetInt32("his_not_7");
                    numeric8.Value = rs.GetInt32("his_not_8");
                    numeric9.Value = rs.GetInt32("his_not_9");
                    numeric10.Value = rs.GetInt32("his_not_10");
                    numeric11.Value = rs.GetInt32("his_not_11");
                    textBox1.Text = rs.GetString("his_not_11_text");
                }
                else
                {
                    txt_doc_num.Text = "";
                    numeric1.Value = 0;
                    numeric2.Value = 0;
                    numeric3.Value = 0;
                    numeric4.Value = 0;
                    numeric5.Value = 0;
                    numeric6.Value = 0;
                    numeric7.Value = 0;
                    numeric8.Value = 0;
                    numeric9.Value = 0;
                    numeric10.Value = 0;
                    numeric11.Value = 0;
                    textBox1.Text = "";
                }
                rs.Close();
                script.conn.Close();
            }
            catch { }
        }
    }
}
