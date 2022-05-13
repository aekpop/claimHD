using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using Syncfusion.XlsIO;
using System.Threading;

namespace TIS
{
    public partial class exportDateForm : Form
    {
        Script script = new Script();
        AdminScript adminScript = new AdminScript();
        String sql_export = "";
        public exportDateForm()
        {
            InitializeComponent();
        }

        public void Export(string sql_para)
        {
            
            string sql = sql_para;
            string data_text = "";
            string name = "";
            MySqlDataReader rs = adminScript.Select_SQL("SELECT * FROM tbl_cpoint where tbl_cpoint_status = '0' order by tbl_cpoint_id");
            int i = 1;
            while (rs.Read())
            {
                if (i == 1)
                {
                    data_text += rs.GetString("tbl_cpoint_id");
                    name += rs.GetString("tbl_cpoint_name");
                }
                else
                {
                    data_text += "," + rs.GetString("tbl_cpoint_id");
                    name += "," + rs.GetString("tbl_cpoint_name");
                }
                i++;
            }
            rs.Close();
            script.conn.Close();

            string[] cpoint = data_text.Split(',');
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                for (i = 0; i < cpoint.Length; i++)
                {
                    MySqlConnection connection = adminScript.getConn(cpoint[i]);
                    try
                    {
                        MySqlDataAdapter data = adminScript.Select_SQLDataAdapter(sql, connection);
                        DataTable dat = new DataTable("Execl");
                        DataSet da = new DataSet();
                        data.Fill(da);
                        data.Fill(dat);
                        

                        DateTime date = DateTime.Now;
                        //dat.WriteXml(saveFileDialog1.FileName.Split('.')[0] + "_" + cpoint[i] + ".xls");
                        string folderPath = saveFileDialog1.FileName.Split('.')[0] + "_" ;

                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(da);
                            wb.SaveAs(folderPath + dateTimePicker1.Value.ToString("ddMMMyyyy")+"-"+ dateTimePicker2.Value.ToString("ddMMMyyyy") +"_"+ name.Split(',')[i] + ".xlsx");
                        }
                        //MessageBox.Show("export ข้อมูลด่านฯ " + name.Split(',')[i]+" สำเร็จ");
                    }
                    catch
                    {
                        MessageBox.Show("!!!Error : export ข้อมูลด่านฯ " + name.Split(',')[i] + " ล้มเหลว มีปัญหาการเชื่อมต่อ","ผิดพลาด",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                MessageBox.Show("export สำเร็จ");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            backgroundWorker1.RunWorkerAsync();
            sql_export = "SELECT a.tbl_status_around_date AS 'วันที่', CONCAT( i.tbl_income_in_time, '-', i.tbl_income_out_time ) AS 'เวลา', a.tbl_status_around_aid AS 'ผลัด', i.tbl_income_cabinet AS 'ตู้', e.tbl_emp_name AS 'ชื่อ-สกุลพนักงาน', i.tbl_income_over AS 'เกินบัญชี', i.tbl_income_over_sys AS 'เกินระบบ' FROM tbl_income i JOIN tbl_status_around a ON i.tbl_income_around_id = a.tbl_status_around_id JOIN tbl_cpoint c ON c.tbl_cpoint_id = a.tbl_status_around_cpoint_id JOIN tbl_emp e ON e.tbl_emp_id = i.tbl_income_emp_id WHERE (( i.tbl_income_over IS NOT NULL AND i.tbl_income_over <> 0 ) OR ( i.tbl_income_over_sys IS NOT NULL AND i.tbl_income_over_sys <> 0 )) AND STR_TO_DATE(a.tbl_status_around_date,'%d-%m-%Y') BETWEEN STR_TO_DATE('"+dateTimePicker1.Text+ "','%d-%m-%Y') AND STR_TO_DATE('" + dateTimePicker2.Text + "','%d-%m-%Y')";
            Export(sql_export);
            progressBar1.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            backgroundWorker1.RunWorkerAsync();
            sql_export = "SELECT a.tbl_status_around_date AS 'วันที่', CONCAT( i.tbl_income_in_time, '-', i.tbl_income_out_time ) AS 'เวลา', a.tbl_status_around_aid AS 'ผลัด', i.tbl_income_cabinet AS 'ตู้', e.tbl_emp_name AS 'ชื่อ-สกุลพนักงาน', i.tbl_income_user_tmp AS 'เงินผู้ใช้ทาง', i.tbl_income_fine_tmp AS 'ค่าปรับบัตรหาย',i.tbl_income_user AS 'คืนเงินผู้ใช้ทาง', i.tbl_income_fine AS 'คืนค่าปรับบัตรหาย' FROM tbl_income i JOIN tbl_status_around a ON i.tbl_income_around_id = a.tbl_status_around_id JOIN tbl_cpoint c ON c.tbl_cpoint_id = a.tbl_status_around_cpoint_id JOIN tbl_emp e ON e.tbl_emp_id = i.tbl_income_emp_id WHERE (( i.tbl_income_user_tmp IS NOT NULL AND i.tbl_income_user_tmp <> 0 ) OR ( i.tbl_income_fine_tmp IS NOT NULL AND i.tbl_income_fine_tmp <> 0 )) AND STR_TO_DATE(a.tbl_status_around_date,'%d-%m-%Y') BETWEEN STR_TO_DATE('" + dateTimePicker1.Text + "','%d-%m-%Y') AND STR_TO_DATE('" + dateTimePicker2.Text + "','%d-%m-%Y')";
            Export(sql_export);
            progressBar1.Visible = false;
        }

        private void exportDateForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.CustomFormat = "dd-MM-yyyy";
            dateTimePicker2.Value = DateTime.Now;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            for (int i = 1; i <= 100; i++)
            {
                // Wait 100 milliseconds.
                Thread.Sleep(100);
                // Report progress.
                backgroundWorker1.ReportProgress(i);
                
            }
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            progressBar1.Value = e.ProgressPercentage;
            // Set the text.
            this.Text = e.ProgressPercentage.ToString();
        }
    }
}
