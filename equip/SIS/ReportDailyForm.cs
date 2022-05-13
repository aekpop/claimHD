using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace TIS
{
    public partial class ReportDailyForm : Form
    {
        MenuForm mainForm = null;
        Script script = new Script();
        string sp = "          ";
        bool un_sys = false;
        public ReportDailyForm(Form callForm)
        {
            mainForm = callForm as MenuForm;
            InitializeComponent();
        }

        private void ReportDailyForm_Load(object sender, EventArgs e)
        {
            if (DateTime.Today < DateTime.ParseExact("03-07-2018", "dd-MM-yyyy", CultureInfo.InvariantCulture))
            {
                txt_total.Visible = true;
                label1.Visible = true;
                label10.Visible = true;
            }
            else
            {
                txt_total.Visible = false;
                label1.Visible = false;
                label10.Visible = false;
            }

            date_start_r2.CustomFormat = "dd-MM-yyyy";
            date_end_r2.CustomFormat = "dd-MM-yyyy";
            date_start_r2.Value = DateTime.Today.AddDays(-1);
            date_end_r2.Value = DateTime.Today.AddDays(-1);
            //txt_straps.Text = script.GetStraps(mainForm.emp_control_id);


            if (mainForm.line9 != "9")
            {
                button3.Enabled = false;
                btn_ts4_9.Enabled = false;
                button4.Enabled = false;

                button1.Enabled = true;
                btn_ts4.Enabled = true;
                btn_f_30.Enabled = true;
            }
            else
            {
                button3.Enabled = true;
                btn_ts4_9.Enabled = true;
                button4.Enabled = true;

                button1.Enabled = false;
                btn_ts4.Enabled = false;
                btn_f_30.Enabled = false;
            }
        }

        private void rd_print2_CheckedChanged(object sender, EventArgs e)
        {
            date_end_r2.Enabled = true;
        }

        private void date_end_r2_ValueChanged(object sender, EventArgs e)
        {
            if (date_end_r2.Value >= DateTime.Today)
            {
                date_end_r2.Value = DateTime.Today.AddDays(-1);
            }
            if (date_end_r2.Value < date_start_r2.Value)
            {
                date_end_r2.Value = date_start_r2.Value.AddDays(1);
            }
            SelectHisReport();
        }

        private void date_start_r2_ValueChanged(object sender, EventArgs e)
        {
            if (date_start_r2.Value >= DateTime.Today)
            {
                date_start_r2.Value = DateTime.Today.AddDays(-1);
            }
            if (date_end_r2.Value < date_start_r2.Value)
            {
                date_end_r2.Value = date_start_r2.Value.AddDays(1);
            }
            SelectHisReport();
        }

        private void rd_print1_CheckedChanged(object sender, EventArgs e)
        {
            date_end_r2.Enabled = false;
            //date_end_r2.Value = DateTime.Today;
        }

        private void txt_no_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txt_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_u1_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txtx_main_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_u2_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_u3_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_u1_KeyUp(object sender, KeyEventArgs e)
        {
            script.getEmpName_Group(txt_u1.Text, label_u1);
        }

        private void txtx_main_KeyUp(object sender, KeyEventArgs e)
        {
            script.getEmpName_Group(txtx_main.Text, label_main);
        }

        private void txt_u2_KeyUp(object sender, KeyEventArgs e)
        {
            script.getEmpName_Group(txt_u2.Text, label_u2);
        }

        private void txt_u3_KeyUp(object sender, KeyEventArgs e)
        {
            script.getEmpName_Group(txt_u3.Text, label_u3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FineAndUser30DayForm fineAndUser30Day = new FineAndUser30DayForm(mainForm, this);
            fineAndUser30Day.ShowDialog();
        }

        private void btn_ts4_Click(object sender, EventArgs e)
        {
            SaveHisReport();
            if (txt_u1.Text.Length >= 5 && txtx_main.Text.Length >= 5 && txt_u2.Text.Length >= 5 && txt_u3.Text.Length >= 5 && cb_province.Text != "เลือก")
            {
                //string[] user_send = { txtx_main.Text, txt_u1.Text, txt_u2.Text, txt_u3.Text };
                un_sys = false;
                GetReport(1, date_start_r2, date_end_r2, false);
            }
            else
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void GetReport(int report_num, DateTimePicker txt_date_start, DateTimePicker txt_date_end, bool print)
        {
            DateTime date_around = txt_date_start.Value;
            DateTime date_aroundNext = txt_date_start.Value.AddDays(1);

            string sql = "";
            if (un_sys)
            {
                sql += "SELECT '' AS title, STR_TO_DATE(tbl_status_around_date,'%d-%c-%Y') AS date_frist, CONCAT('ผลัดที่ ',tbl_around_id) as around, tbl_around_time as around_time,(SUM(tbl_income_bank)-(SUM(IF(tbl_income_over IS NOT NULL,tbl_income_over,0)))) as amount, '' as note from tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND (tbl_status_around_aid = 2 OR tbl_status_around_aid = 3) AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' group by tbl_status_around_aid UNION SELECT '' AS title, STR_TO_DATE(tbl_status_around_date,'%d-%c-%Y') AS date_frist, CONCAT('ผลัดที่ ',tbl_around_id) AS around, tbl_around_time AS around_time,(SUM(tbl_income_bank)-(SUM(IF(tbl_income_over IS NOT NULL,tbl_income_over,0)))) AS amount, '' AS note FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_date = '" + date_aroundNext.ToString("dd-MM-yyyy") + "' AND tbl_status_around_aid = 1 AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY tbl_status_around_aid";
            }
            else
            {
                sql += "SELECT '' AS title, STR_TO_DATE(tbl_status_around_date,'%d-%c-%Y') AS date_frist, CONCAT('ผลัดที่ ',tbl_around_id) as around, tbl_around_time as around_time,(SUM(tbl_income_bank)-(SUM(IF(tbl_income_over IS NOT NULL,tbl_income_over,0)) + SUM(IF(tbl_income_over_sys IS NOT NULL,tbl_income_over_sys,0)))) as amount, '' as note from tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND (tbl_status_around_aid = 2 OR tbl_status_around_aid = 3) AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' group by tbl_status_around_aid UNION SELECT '' AS title, STR_TO_DATE(tbl_status_around_date,'%d-%c-%Y') AS date_frist, CONCAT('ผลัดที่ ',tbl_around_id) AS around, tbl_around_time AS around_time,(SUM(tbl_income_bank)-(SUM(IF(tbl_income_over IS NOT NULL,tbl_income_over,0)) + SUM(IF(tbl_income_over_sys IS NOT NULL,tbl_income_over_sys,0)))) AS amount, '' AS note FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_date = '" + date_aroundNext.ToString("dd-MM-yyyy") + "' AND tbl_status_around_aid = 1 AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY tbl_status_around_aid";
            }
            if (rd_print2.Checked)
            {
                int max = (txt_date_end.Value - txt_date_start.Value).Days;

                ////ผลัด
                if (mainForm.line9 == "9")
                {
                    //สาย 9
                    if (un_sys)
                    {
                        for (int i = 1; i <= max; i++)
                        {
                            date_around = date_around.AddDays(1);
                            date_aroundNext = date_aroundNext.AddDays(1);
                            sql += " UNION SELECT '' AS title, STR_TO_DATE(tbl_status_around_date,'%d-%c-%Y') AS date_frist, CONCAT('ผลัดที่ ',tbl_around_id) as around, tbl_around_time as around_time,(SUM(tbl_income_bank)-(SUM(IF(tbl_income_over IS NOT NULL,tbl_income_over,0)))) as amount, '' as note from tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND (tbl_status_around_aid = 2 OR tbl_status_around_aid = 3) AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' group by tbl_status_around_aid UNION SELECT '' AS title, STR_TO_DATE(tbl_status_around_date,'%d-%c-%Y') AS date_frist, CONCAT('ผลัดที่ ',tbl_around_id) AS around, tbl_around_time AS around_time,(SUM(tbl_income_bank)-(SUM(IF(tbl_income_over IS NOT NULL,tbl_income_over,0)))) AS amount, '' AS note FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_date = '" + date_aroundNext.ToString("dd-MM-yyyy") + "' AND tbl_status_around_aid = 1 AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY tbl_status_around_aid";
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= max; i++)
                        {
                            date_around = date_around.AddDays(1);
                            date_aroundNext = date_aroundNext.AddDays(1);
                            sql += " UNION SELECT '' AS title, STR_TO_DATE(tbl_status_around_date,'%d-%c-%Y') AS date_frist, CONCAT('ผลัดที่ ',tbl_around_id) as around, tbl_around_time as around_time,(SUM(tbl_income_bank)-(SUM(IF(tbl_income_over IS NOT NULL,tbl_income_over,0)) + SUM(IF(tbl_income_over_sys IS NOT NULL,tbl_income_over_sys,0)))) as amount, '' as note from tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND (tbl_status_around_aid = 2 OR tbl_status_around_aid = 3) AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' group by tbl_status_around_aid UNION SELECT '' AS title, STR_TO_DATE(tbl_status_around_date,'%d-%c-%Y') AS date_frist, CONCAT('ผลัดที่ ',tbl_around_id) AS around, tbl_around_time AS around_time,(SUM(tbl_income_bank)-(SUM(IF(tbl_income_over IS NOT NULL,tbl_income_over,0)) + SUM(IF(tbl_income_over_sys IS NOT NULL,tbl_income_over_sys,0)))) AS amount, '' AS note FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_date = '" + date_aroundNext.ToString("dd-MM-yyyy") + "' AND tbl_status_around_aid = 1 AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY tbl_status_around_aid";
                        }
                    }
                }
                else
                {
                    //สาย 7
                    for (int i = 1; i <= max; i++)
                    {
                        date_around = date_around.AddDays(1);
                        date_aroundNext = date_aroundNext.AddDays(1);
                        sql += " UNION SELECT '' AS title, STR_TO_DATE(tbl_status_around_date,'%d-%c-%Y') AS date_frist, CONCAT('ผลัดที่ ',tbl_around_id) as around, tbl_around_time as around_time,(SUM(tbl_income_bank)-(SUM(IF(tbl_income_over IS NOT NULL,tbl_income_over,0)) + SUM(IF(tbl_income_over_sys IS NOT NULL,tbl_income_over_sys,0)))) as amount, '' as note from tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND (tbl_status_around_aid = 2 OR tbl_status_around_aid = 3) AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' group by tbl_status_around_aid UNION SELECT '' AS title, STR_TO_DATE(tbl_status_around_date,'%d-%c-%Y') AS date_frist, CONCAT('ผลัดที่ ',tbl_around_id) AS around, tbl_around_time AS around_time,(SUM(tbl_income_bank)-(SUM(IF(tbl_income_over IS NOT NULL,tbl_income_over,0)) + SUM(IF(tbl_income_over_sys IS NOT NULL,tbl_income_over_sys,0)))) AS amount, '' AS note FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_date = '" + date_aroundNext.ToString("dd-MM-yyyy") + "' AND tbl_status_around_aid = 1 AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY tbl_status_around_aid";
                    }
                }

                //เงินเกินบัญชี
                if (mainForm.line9 == "9")
                {
                    date_around = txt_date_start.Value;
                    date_aroundNext = txt_date_start.Value.AddDays(1);
                    for (int i = 0; i <= max; i++)
                    {
                        sql += " UNION SELECT 'ส่งเงินเกินบัญชี' AS title, STR_TO_DATE( `tbl_status_around_date`, '%d-%c-%Y' ) AS date_frist, CONCAT( 'ผลัดที่ ', tbl_around_id ) AS around, tbl_around_time AS around_time, SUM(tbl_income_over) AS amount, '' AS note FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_status_around_aid = '2' AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_around_id`";
                        sql += " UNION SELECT 'ส่งเงินเกินบัญชี' AS title, STR_TO_DATE( `tbl_status_around_date`, '%d-%c-%Y' ) AS date_frist, CONCAT( 'ผลัดที่ ', tbl_around_id ) AS around, tbl_around_time AS around_time, SUM(tbl_income_over) AS amount, '' AS note FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_status_around_aid = '3' AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_around_id`";
                        sql += " UNION SELECT 'ส่งเงินเกินบัญชี' AS title, STR_TO_DATE( `tbl_status_around_date`, '%d-%c-%Y' ) AS date_frist, CONCAT( 'ผลัดที่ ', tbl_around_id ) AS around, tbl_around_time AS around_time, SUM(tbl_income_over) AS amount, '' AS note FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE tbl_status_around_date = '" + date_around.AddDays(1).ToString("dd-MM-yyyy") + "' AND tbl_status_around_aid = '1' AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_around_id`";
                        date_around = date_around.AddDays(1);
                        date_aroundNext = date_aroundNext.AddDays(1);
                    }
                }

                //เงินเกินระบบ
                if (!un_sys)
                {
                    date_around = txt_date_start.Value;
                    date_aroundNext = txt_date_start.Value.AddDays(1);
                    for (int i = 0; i <= max; i++)
                    {
                        sql += " UNION SELECT 'ส่งเงินเกินระบบ' AS title, STR_TO_DATE( `tbl_status_around_date`, '%d-%c-%Y' ) AS date_frist, CONCAT( 'ผลัดที่ ', tbl_around_id ) AS around, tbl_around_time AS around_time, SUM(tbl_income_over_sys) AS amount, '' AS note FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_status_around_aid = '2' AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_around_id`";
                        sql += " UNION SELECT 'ส่งเงินเกินระบบ' AS title, STR_TO_DATE( `tbl_status_around_date`, '%d-%c-%Y' ) AS date_frist, CONCAT( 'ผลัดที่ ', tbl_around_id ) AS around, tbl_around_time AS around_time, SUM(tbl_income_over_sys) AS amount, '' AS note FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_status_around_aid = '3' AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_around_id`";
                        sql += " UNION SELECT 'ส่งเงินเกินระบบ' AS title, STR_TO_DATE( `tbl_status_around_date`, '%d-%c-%Y' ) AS date_frist, CONCAT( 'ผลัดที่ ', tbl_around_id ) AS around, tbl_around_time AS around_time, SUM(tbl_income_over_sys) AS amount, '' AS note FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE tbl_status_around_date = '" + date_around.AddDays(1).ToString("dd-MM-yyyy") + "' AND tbl_status_around_aid = '1' AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_around_id`";
                        date_around = date_around.AddDays(1);
                        date_aroundNext = date_aroundNext.AddDays(1);
                    }
                }

                //ผู้ใช้ทาง
                date_around = txt_date_start.Value;
                date_aroundNext = txt_date_start.Value.AddDays(1);
                for (int i = 0; i <= max; i++)
                {
                    sql += " UNION (SELECT 'ส่งเงินผู้ใช้ทางไม่รับเงินทอน' AS title, STR_TO_DATE( `tbl_status_around_date`, '%d-%c-%Y' ) AS date_frist, CONCAT('ผลัดที่ ',tbl_around_id) AS around, tbl_around_time AS around_time, SUM(tbl_income_user) AS amount, '' AS note FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE DATEDIFF( STR_TO_DATE( '" + date_around.ToString("dd-MM-yyyy") + "', '%d-%c-%Y' ), STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) ) = 30 AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_around_id` )";
                    date_around = date_around.AddDays(1);
                    date_aroundNext = date_aroundNext.AddDays(1);
                }
                //ปรับบัตร
                if (mainForm.line9 != "9")
                {
                    date_around = txt_date_start.Value;
                    date_aroundNext = txt_date_start.Value.AddDays(1);
                    for (int i = 0; i <= max; i++)
                    {
                        sql += " UNION (SELECT 'ส่งเงินค่าปรับบัตร Transit Card'AS title, STR_TO_DATE( `tbl_status_around_date`, '%d-%c-%Y' ) AS date_frist, CONCAT('ผลัดที่ ',tbl_around_id) AS around, tbl_around_time AS around_time, SUM(tbl_income_fine) AS amount, '' AS note FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE DATEDIFF( STR_TO_DATE( '" + date_around.ToString("dd-MM-yyyy") + "', '%d-%c-%Y' ), STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) ) = 30 AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_around_id`)";
                        date_around = date_around.AddDays(1);
                        date_aroundNext = date_aroundNext.AddDays(1);
                    }
                }
                //ติดตามรายได้จากระบบ
                date_around = txt_date_start.Value;
                date_aroundNext = txt_date_start.Value.AddDays(1);
                for (int i = 0; i <= max; i++)
                {
                    sql += " UNION (SELECT tbl_list_incom_name AS title, NULL AS date_frist, NULL AS around, NULL AS around_time, tbl_incom_other_amount AS amount, CONCAT('" + sp + "',tbl_incom_other_rec,'\r\n','วันที่ ',tbl_incom_other_date,' ตู้ ',tbl_incom_other_cabinet,' งาน ',tbl_incom_other_job,' ผลัดที่ ',tbl_incom_other_around,' เวลาปฏิบัติงาน ',tbl_incom_other_time,' น. \r\n',tbl_incom_other_note,' ',tbl_emp_name) AS note FROM tbl_incom_other JOIN tbl_emp ON tbl_emp_id=tbl_incom_other_emp_id JOIN tbl_list_incom ON tbl_list_incom_id = tbl_incom_other_list_incom_id WHERE tbl_incom_other_list_incom_id = '4' AND tbl_incom_other_date_send = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_incom_cpoint_id = '" + mainForm.cpoint_id + "')";
                    date_around = date_around.AddDays(1);
                    date_aroundNext = date_aroundNext.AddDays(1);
                }

                //ผู้ใช้ทางมาชำระบภายหลัง
                date_around = txt_date_start.Value;
                date_aroundNext = txt_date_start.Value.AddDays(1);
                for (int i = 0; i <= max; i++)
                {
                    sql += " UNION (SELECT CONCAT(tbl_list_incom_name,IF(DATEDIFF(STR_TO_DATE(memo_date_payment,'%d-%c-%Y'),STR_TO_DATE(memo_date,'%d-%c-%Y'))<8,'(ตามกำหนด)','(เกินกำหนด)')) AS title, NULL AS date_frist, NULL AS around, NULL around_time, memo_amount AS amount, CONCAT('" + sp + "ผ่านด่านฯ','วันที่ ',DAY(STR_TO_DATE(memo_date,'%d-%c-%Y')),'/',MONTH(STR_TO_DATE(memo_date,'%d-%c-%Y')),'/',(YEAR(STR_TO_DATE(memo_date,'%d-%c-%Y'))+543),' เวลา ',memo_time,' น.',' ตู้ ',memo_cabinet,'\r\nหมายเลขทะเบียน ',memo_license_plate,' ',memo_province_plate,' ',memo_type_id,' สี',memo_color,' ยี่ห้อ ',memo_brand,'\r\nใบเสร็จรับเงินเล่มที่ ',memo_bill_book,' เลขที่ ',memo_bill_no,' ลว.',DATE_FORMAT( DATE_ADD( STR_TO_DATE (memo_date_payment,'%d-%m-%Y'), INTERVAL 543 YEAR ), '%d/%m/%Y' )) AS note FROM tbl_memo JOIN tbl_list_incom ON tbl_list_incom_id = memo_id_list_id WHERE (memo_status IS NOT NULL) AND memo_date_payment = '" + date_around.ToString("dd-MM-yyyy") + "' AND memo_cpoint_id = '" + mainForm.cpoint_id + "' AND memo_id_list_id = '5')";
                    date_around = date_around.AddDays(1);
                    date_aroundNext = date_aroundNext.AddDays(1);
                }

                //ส่งเงินค่าปรับกรณีผู้ใช้ทางฝ่าด่าน
                date_around = txt_date_start.Value;
                date_aroundNext = txt_date_start.Value.AddDays(1);
                for (int i = 0; i <= max; i++)
                {
                    sql += " UNION (SELECT tbl_list_incom_name AS title, NULL AS date_frist, NULL AS around, NULL around_time, memo_amount AS amount, CONCAT('" + sp + "ฝ่าด่านฯ','วันที่ ',DAY(STR_TO_DATE(memo_date,'%d-%c-%Y')),'/',MONTH(STR_TO_DATE(memo_date,'%d-%c-%Y')),'/',(YEAR(STR_TO_DATE(memo_date,'%d-%c-%Y'))+543),' เวลา ',memo_time,' น.',' ตู้ ',memo_cabinet,'\r\nหมายเลขทะเบียน ',memo_license_plate,' ',memo_province_plate,' ',memo_type_id,' สี',memo_color,' ยี่ห้อ ',memo_brand,'\r\nใบเสร็จรับเงินเล่มที่ ',memo_bill_book,' เลขที่ ',memo_bill_no,' ลว.',DATE_FORMAT( DATE_ADD( STR_TO_DATE (memo_date_payment,'%d-%m-%Y'), INTERVAL 543 YEAR ), '%d/%m/%Y' )) AS note FROM tbl_memo JOIN tbl_list_incom ON tbl_list_incom_id = memo_id_list_id WHERE (memo_status IS NOT NULL) AND memo_date_payment = '" + date_around.ToString("dd-MM-yyyy") + "' AND memo_cpoint_id = '" + mainForm.cpoint_id + "' AND memo_id_list_id = '6')";
                    date_around = date_around.AddDays(1);
                    date_aroundNext = date_aroundNext.AddDays(1);
                }

                //ส่งเงินรายได้เพิ่มเติม
                date_around = txt_date_start.Value;
                date_aroundNext = txt_date_start.Value.AddDays(1);
                for (int i = 0; i <= max; i++)
                {
                    // sql += " UNION (SELECT tbl_list_incom_name AS title, NULL AS date_frist, NULL AS around, NULL around_time, tbl_incom_other_amount AS amount, CONCAT('" + sp + "',tbl_incom_other_rec,'\r\n',tbl_incom_other_note) AS note FROM tbl_incom_other JOIN tbl_list_incom ON tbl_list_incom_id = tbl_incom_other_list_incom_id WHERE tbl_incom_other_list_incom_id = '7' AND tbl_incom_other_date_send = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_incom_cpoint_id = '" + mainForm.cpoint_id + "')";
                    sql += " UNION (SELECT tbl_list_incom_name AS title, NULL AS date_frist, NULL AS around, NULL around_time, tbl_incom_other_amount AS amount, CONCAT('" + sp + "',tbl_incom_other_rec,tbl_incom_other_note) AS note FROM tbl_incom_other JOIN tbl_list_incom ON tbl_list_incom_id = tbl_incom_other_list_incom_id WHERE tbl_incom_other_list_incom_id = '7' AND tbl_incom_other_date_send = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_incom_cpoint_id = '" + mainForm.cpoint_id + "')";
                    date_around = date_around.AddDays(1);
                    date_aroundNext = date_aroundNext.AddDays(1);
                }

                //ส่งเงินอื่นๆ
                date_around = txt_date_start.Value;
                date_aroundNext = txt_date_start.Value.AddDays(1);
                for (int i = 0; i <= max; i++)
                {
                    sql += " UNION (SELECT tbl_list_incom_name AS title, NULL AS date_frist, NULL AS around, NULL around_time, tbl_incom_other_amount AS amount, CONCAT('" + sp + "',tbl_incom_other_rec,tbl_incom_other_note) AS note FROM tbl_incom_other JOIN tbl_list_incom ON tbl_list_incom_id = tbl_incom_other_list_incom_id WHERE tbl_incom_other_list_incom_id = '8' AND tbl_incom_other_date_send = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_incom_cpoint_id = '" + mainForm.cpoint_id + "')";
                    date_around = date_around.AddDays(1);
                    date_aroundNext = date_aroundNext.AddDays(1);
                }
            }
            else
            {
                if (mainForm.line9 == "9")
                {
                    sql += " UNION SELECT 'ส่งเงินเกินบัญชี' AS title, STR_TO_DATE( `tbl_status_around_date`, '%d-%c-%Y' ) AS date_frist, CONCAT( 'ผลัดที่ ', tbl_around_id ) AS around, tbl_around_time AS around_time, SUM(tbl_income_over) AS amount, '' AS note FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_status_around_aid = '2' AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_around_id`";
                    sql += " UNION SELECT 'ส่งเงินเกินบัญชี' AS title, STR_TO_DATE( `tbl_status_around_date`, '%d-%c-%Y' ) AS date_frist, CONCAT( 'ผลัดที่ ', tbl_around_id ) AS around, tbl_around_time AS around_time, SUM(tbl_income_over) AS amount, '' AS note FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_status_around_aid = '3' AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_around_id`";
                    sql += " UNION SELECT 'ส่งเงินเกินบัญชี' AS title, STR_TO_DATE( `tbl_status_around_date`, '%d-%c-%Y' ) AS date_frist, CONCAT( 'ผลัดที่ ', tbl_around_id ) AS around, tbl_around_time AS around_time, SUM(tbl_income_over) AS amount, '' AS note FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE tbl_status_around_date = '" + date_around.AddDays(1).ToString("dd-MM-yyyy") + "' AND tbl_status_around_aid = '1' AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_around_id`";
                }

                if (!un_sys)
                {
                    sql += " UNION SELECT 'ส่งเงินเกินระบบ' AS title, STR_TO_DATE( `tbl_status_around_date`, '%d-%c-%Y' ) AS date_frist, CONCAT( 'ผลัดที่ ', tbl_around_id ) AS around, tbl_around_time AS around_time, SUM(tbl_income_over_sys) AS amount, '' AS note FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_status_around_aid = '2' AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_around_id`";
                    sql += " UNION SELECT 'ส่งเงินเกินระบบ' AS title, STR_TO_DATE( `tbl_status_around_date`, '%d-%c-%Y' ) AS date_frist, CONCAT( 'ผลัดที่ ', tbl_around_id ) AS around, tbl_around_time AS around_time, SUM(tbl_income_over_sys) AS amount, '' AS note FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_status_around_aid = '3' AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_around_id`";
                    sql += " UNION SELECT 'ส่งเงินเกินระบบ' AS title, STR_TO_DATE( `tbl_status_around_date`, '%d-%c-%Y' ) AS date_frist, CONCAT( 'ผลัดที่ ', tbl_around_id ) AS around, tbl_around_time AS around_time, SUM(tbl_income_over_sys) AS amount, '' AS note FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE tbl_status_around_date = '" + date_around.AddDays(1).ToString("dd-MM-yyyy") + "' AND tbl_status_around_aid = '1' AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_around_id`";
                }

                sql += " UNION (SELECT 'ส่งเงินผู้ใช้ทางไม่รับเงินทอน' AS title, STR_TO_DATE( `tbl_status_around_date`, '%d-%c-%Y' ) AS date_frist, CONCAT('ผลัดที่ ',tbl_around_id) AS around, tbl_around_time AS around_time, SUM(tbl_income_user) AS amount, '' AS note FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE DATEDIFF( STR_TO_DATE( '" + date_around.ToString("dd-MM-yyyy") + "', '%d-%c-%Y' ), STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) ) = 30 AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_around_id` )";

                if (mainForm.line9 != "9")
                {
                    sql += " UNION (SELECT 'ส่งเงินค่าปรับบัตร Transit Card' AS title, STR_TO_DATE( `tbl_status_around_date`, '%d-%c-%Y') AS date_frist, CONCAT('ผลัดที่ ',tbl_around_id) AS around, tbl_around_time AS around_time, SUM(tbl_income_fine) AS amount, '' AS note FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE DATEDIFF( STR_TO_DATE( '" + date_around.ToString("dd-MM-yyyy") + "', '%d-%c-%Y' ), STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) ) = 30 AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_around_id`)";
                }

                sql += " UNION (SELECT tbl_list_incom_name AS title, NULL AS date_frist, NULL AS around, NULL AS around_time, tbl_incom_other_amount AS amount, CONCAT('" + sp + "',tbl_incom_other_rec,'\r\n','วันที่ ',tbl_incom_other_date,' ตู้ ',tbl_incom_other_cabinet,' งาน ',tbl_incom_other_job,' ผลัดที่ ',tbl_incom_other_around,' เวลาปฏิบัติงาน ',tbl_incom_other_time,' น. \r\n',tbl_incom_other_note,' ',tbl_emp_name) AS note FROM tbl_incom_other JOIN tbl_emp ON tbl_emp_id=tbl_incom_other_emp_id JOIN tbl_list_incom ON tbl_list_incom_id = tbl_incom_other_list_incom_id WHERE tbl_incom_other_list_incom_id = '4' AND tbl_incom_other_date_send = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_incom_cpoint_id = '" + mainForm.cpoint_id + "')";
                sql += " UNION (SELECT CONCAT(tbl_list_incom_name,IF(DATEDIFF(STR_TO_DATE(memo_date_payment,'%d-%c-%Y'),STR_TO_DATE(memo_date,'%d-%c-%Y'))<8,'(ตามกำหนด)','(เกินกำหนด)')) AS title, NULL AS date_frist, NULL AS around, NULL around_time, memo_amount AS amount, CONCAT('" + sp + "ผ่านด่านฯ','วันที่ ',DAY(STR_TO_DATE(memo_date,'%d-%c-%Y')),'/',MONTH(STR_TO_DATE(memo_date,'%d-%c-%Y')),'/',(YEAR(STR_TO_DATE(memo_date,'%d-%c-%Y'))+543),' เวลา ',memo_time,' น.',' ตู้ ',memo_cabinet,'\r\nหมายเลขทะเบียน ',memo_license_plate,' ',memo_province_plate,' ',memo_type_id,' สี',memo_color,' ยี่ห้อ ',memo_brand,'\r\nใบเสร็จรับเงินเล่มที่ ',memo_bill_book,' เลขที่ ',memo_bill_no,' ลว.',DATE_FORMAT( DATE_ADD( STR_TO_DATE (memo_date_payment,'%d-%m-%Y'), INTERVAL 543 YEAR ), '%d/%m/%Y' )) AS note FROM tbl_memo JOIN tbl_list_incom ON tbl_list_incom_id = memo_id_list_id WHERE (memo_status IS NOT NULL) AND memo_date_payment = '" + date_around.ToString("dd-MM-yyyy") + "' AND memo_cpoint_id = '" + mainForm.cpoint_id + "' AND memo_id_list_id = '5')";
                sql += " UNION (SELECT tbl_list_incom_name AS title, NULL AS date_frist, NULL AS around, NULL around_time, memo_amount AS amount, CONCAT('" + sp + "ฝ่าด่านฯ','วันที่ ',DAY(STR_TO_DATE(memo_date,'%d-%c-%Y')),'/',MONTH(STR_TO_DATE(memo_date,'%d-%c-%Y')),'/',(YEAR(STR_TO_DATE(memo_date,'%d-%c-%Y'))+543),' เวลา ',memo_time,' น.',' ตู้ ',memo_cabinet,'\r\nหมายเลขทะเบียน ',memo_license_plate,' ',memo_province_plate,' ',memo_type_id,' สี',memo_color,' ยี่ห้อ ',memo_brand,'\r\nใบเสร็จรับเงินเล่มที่ ',memo_bill_book,' เลขที่ ',memo_bill_no,' ลว.',DATE_FORMAT( DATE_ADD( STR_TO_DATE (memo_date_payment,'%d-%m-%Y'), INTERVAL 543 YEAR ), '%d/%m/%Y' )) AS note FROM tbl_memo JOIN tbl_list_incom ON tbl_list_incom_id = memo_id_list_id WHERE (memo_status IS NOT NULL) AND memo_date_payment = '" + date_around.ToString("dd-MM-yyyy") + "' AND memo_cpoint_id = '" + mainForm.cpoint_id + "' AND memo_id_list_id = '6')";
                sql += " UNION (SELECT tbl_list_incom_name AS title, NULL AS date_frist, NULL AS around, NULL around_time, tbl_incom_other_amount AS amount, CONCAT('" + sp + "',tbl_incom_other_rec,'" + sp + "',tbl_incom_other_note) AS note FROM tbl_incom_other JOIN tbl_list_incom ON tbl_list_incom_id = tbl_incom_other_list_incom_id WHERE tbl_incom_other_list_incom_id = '7' AND tbl_incom_other_date_send = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_incom_cpoint_id = '" + mainForm.cpoint_id + "')";
                sql += " UNION (SELECT tbl_list_incom_name AS title, NULL AS date_frist, NULL AS around, NULL around_time, tbl_incom_other_amount AS amount, CONCAT('" + sp + "',tbl_incom_other_rec,'" + sp + "',tbl_incom_other_note) AS note FROM tbl_incom_other JOIN tbl_list_incom ON tbl_list_incom_id = tbl_incom_other_list_incom_id WHERE tbl_incom_other_list_incom_id = '8' AND tbl_incom_other_date_send = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_incom_cpoint_id = '" + mainForm.cpoint_id + "')";
            }

            ConnectDB contxt = new ConnectDB();
            MySqlConnection conn = new MySqlConnection();
            conn = new MySqlConnection(contxt.context());
            MySqlCommand cmd;
            conn.Open();
            script.Load_page();
            cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            MySqlDataAdapter adap = new MySqlDataAdapter();
            DataSet_Report reportDB = new DataSet_Report();
            adap.SelectCommand = cmd;
            reportDB.Clear();
            adap.Fill(reportDB, "Data_report");

            switch (report_num)
            {
                case 1:
                    Report2_first report = new Report2_first();
                    report.SetDataSource(reportDB);
                    report.SetParameterValue("doc_number", txt_no.Text == "" ? "................................" : txt_no.Text);
                    report.SetParameterValue("user_send", script.getEmpName_Group(txt_u1.Text).Split('|')[0]);
                    report.SetParameterValue("group_send", script.NotManager(txt_u1.Text));
                    report.SetParameterValue("user_send1", script.getEmpName_Group(txt_u2.Text).Split('|')[0]);
                    report.SetParameterValue("group_send1", script.getEmpName_Group(txt_u2.Text).Split('|')[1]);

                    report.SetParameterValue("user_send2", script.getEmpName_Group(txt_u3.Text).Split('|')[0]);
                    report.SetParameterValue("group_send2", script.getEmpName_Group(txt_u3.Text).Split('|')[1]);
                    report.SetParameterValue("user_main", script.getEmpName_Group(txtx_main.Text).Split('|')[0]);
                    report.SetParameterValue("group_main", script.NotManager(txtx_main.Text));
                    report.SetParameterValue("cpoint", script.GetCpoint(mainForm.cpoint_id));
                    if (rd_print2.Checked)
                    {
                        report.SetParameterValue("date_send", script.GetMontThai(txt_date_end.Value.AddDays(1)));
                    }
                    else
                    {
                        report.SetParameterValue("date_send", script.GetMontThai(txt_date_start.Value.AddDays(1)));
                    }
                    PopupReport popup = new PopupReport();

                    if (print)
                    {
                        try
                        {
                            report.PrintToPrinter(1, true, 0, 0);
                        }
                        catch
                        {
                            MessageBox.Show("พิมพ์ไม่สำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        popup.cry_View.ReportSource = report;
                        //MessageBox.Show(popup.cry_View.GetCurrentPageNumber().ToString());
                        popup.Text = "ใบนำส่งเงินรายได้ค่าธรรมเนียมผ่านทางให้คณะกรรมการ ก.ส.ธ. (ธร.4)";
                        //popup.cry_View.Zoom(80);
                        popup.Show();
                        ////cry_View.Visible = true;
                    }
                    break;
                case 2:
                    ReportIncomeKST2 reportIncomeKST = new ReportIncomeKST2();
                    reportIncomeKST.SetDataSource(reportDB);
                    DateTime date_end = txt_date_end.Value;

                    reportIncomeKST.SetParameterValue("doc_number", txt_no.Text == "" ? ".........." : txt_no.Text);
                    reportIncomeKST.SetParameterValue("user_send1", script.getEmpName_Group(txt_u2.Text).Split('|')[0]);
                    reportIncomeKST.SetParameterValue("group_send1", script.getEmpName_Group(txt_u2.Text).Split('|')[1]);
                    reportIncomeKST.SetParameterValue("user_send2", script.getEmpName_Group(txt_u3.Text).Split('|')[0]);
                    reportIncomeKST.SetParameterValue("group_send2", script.getEmpName_Group(txt_u3.Text).Split('|')[1]);
                    reportIncomeKST.SetParameterValue("user_main", script.getEmpName_Group(txtx_main.Text).Split('|')[0]);
                    reportIncomeKST.SetParameterValue("group_main", script.NotManager(txtx_main.Text));
                    reportIncomeKST.SetParameterValue("cpoint", script.GetCpoint(mainForm.cpoint_id));
                    reportIncomeKST.SetParameterValue("province", cb_province.Text);
                    if (rd_print2.Checked)
                    {
                        if ((txt_date_start.Value.Month == date_end.AddDays(1).Month) && (txt_date_start.Value.Year == date_end.AddDays(1).Year))
                        {
                            reportIncomeKST.SetParameterValue("date_report", (txt_date_start.Value.Day + " - " + script.GetMontThai(date_end.AddDays(1))));
                        }
                        else if ((txt_date_start.Value.Month != date_end.AddDays(1).Month) && (txt_date_start.Value.Year == date_end.AddDays(1).Year))
                        {
                            reportIncomeKST.SetParameterValue("date_report", script.GetMontThai(txt_date_start.Value).Split(' ')[0] + " " + script.GetMontThai(txt_date_start.Value).Split(' ')[1] + " - " + script.GetMontThai(date_end.AddDays(1)));
                        }
                        else if ((txt_date_start.Value.Month != date_end.AddDays(1).Month) && (txt_date_start.Value.Year != date_end.AddDays(1).Year))
                        {
                            reportIncomeKST.SetParameterValue("date_report", script.GetMontThai(txt_date_start.Value).Split(' ')[0] + " " + script.GetMontThai(txt_date_start.Value).Split(' ')[1] + " " + script.GetMontThai(txt_date_start.Value).Split(' ')[2] + " - " + script.GetMontThai(date_end.AddDays(1)));
                        }
                            reportIncomeKST.SetParameterValue("date_send", script.GetMontThai(txt_date_end.Value.AddDays(1)));
                    }
                    else
                    {
                        /*   if (txt_date_start.Value.Month == txt_date_start.Value.AddDays(1).Month)
                           {
                               reportIncomeKST.SetParameterValue("date_report", (txt_date_start.Value.Day + " - " + script.GetMontThai(txt_date_start.Value.AddDays(1))));
                           }
                           else
                           {
                               reportIncomeKST.SetParameterValue("date_report", script.GetMontThai(txt_date_start.Value).Split(' ')[0] + " " + script.GetMontThai(txt_date_start.Value).Split(' ')[1] + " - " + script.GetMontThai(txt_date_start.Value.AddDays(1)));
                           }
                       */
                        if ((txt_date_start.Value.Month == date_end.AddDays(1).Month) && (txt_date_start.Value.Year == date_end.AddDays(1).Year))
                        {
                            reportIncomeKST.SetParameterValue("date_report", (txt_date_start.Value.Day + " - " + script.GetMontThai(date_end.AddDays(1))));
                        }
                        else if ((txt_date_start.Value.Month != date_end.AddDays(1).Month) && (txt_date_start.Value.Year == date_end.AddDays(1).Year))
                        {
                            reportIncomeKST.SetParameterValue("date_report", script.GetMontThai(txt_date_start.Value).Split(' ')[0] + " " + script.GetMontThai(txt_date_start.Value).Split(' ')[1] + " - " + script.GetMontThai(date_end.AddDays(1)));
                        }
                        else if ((txt_date_start.Value.Month != date_end.AddDays(1).Month) && (txt_date_start.Value.Year != date_end.AddDays(1).Year))
                        {
                            reportIncomeKST.SetParameterValue("date_report", script.GetMontThai(txt_date_start.Value).Split(' ')[0] + " " + script.GetMontThai(txt_date_start.Value).Split(' ')[1] + " " + script.GetMontThai(txt_date_start.Value).Split(' ')[2] + " - " + script.GetMontThai(date_end.AddDays(1)));
                        }
                        reportIncomeKST.SetParameterValue("date_send", script.GetMontThai(txt_date_start.Value.AddDays(1)));
                    }

                    popup = new PopupReport();
                    popup.cry_View.ReportSource = reportIncomeKST;
                    popup.Text = "ใบนำส่งเงินรายได้ค่าธรรมเนียมผ่านทางให้คณะกรรมการ ก.ส.ธ. (ธร.5)";
                    //popup.cry_View.Zoom(80);
                    popup.Show();
                    //cry_View.Visible = true;
                    break;
                case 3:
                    Pay_In_Slip pay_In_Slip = new Pay_In_Slip();
                    pay_In_Slip.SetDataSource(reportDB);
                    pay_In_Slip.SetParameterValue("Branch", txt_bank.Text);

                    popup = new PopupReport();
                    popup.cry_View.ReportSource = pay_In_Slip;
                    popup.Text = "ใบ Pay-In";
                    //popup.cry_View.Zoom(80);
                    if (print)
                    {
                        try
                        {
                            pay_In_Slip.PrintToPrinter(1, true, 0, 0);
                        }
                        catch
                        {
                            MessageBox.Show("พิมพ์ไม่สำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        popup.Show();
                        //cry_View.Visible = true;
                    }
                    break;
            }
            conn.Close();
        }

        private void txt_u2_Validated(object sender, EventArgs e)
        {
            if ((txt_u2.Text == txt_u1.Text || txt_u2.Text == txt_u3.Text) && txt_u2.Text != "")
            {
                MessageBox.Show("รหัสซ้ำ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_u2.Clear();
                txt_u2.Focus();
            }
        }

        private void txt_u3_Validated(object sender, EventArgs e)
        {
            if ((txt_u3.Text == txt_u1.Text || txt_u3.Text == txt_u2.Text) && txt_u3.Text != "")
            {
                MessageBox.Show("รหัสซ้ำ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_u3.Clear();
                txt_u3.Focus();
            }
        }

        private void txt_u1_Validated_1(object sender, EventArgs e)
        {
            if ((txt_u1.Text == txt_u2.Text || txt_u1.Text == txt_u3.Text) && txt_u1.Text != "")
            {
                MessageBox.Show("รหัสซ้ำ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_u1.Clear();
                txt_u1.Focus();
            }
        }

        private void btn_payin_Click(object sender, EventArgs e)
        {
            SaveHisReport();
            if (txt_u1.Text.Length >= 5 && cb_province.Text != "เลือก" && txt_bank.Text != "")
            {
                //string[] user_send = { txtx_main.Text, txt_u1.Text, txt_u2.Text, txt_u3.Text };
                GetReport(3, date_start_r2, date_end_r2, false);
            }
            else
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_u_30_Click(object sender, EventArgs e)
        {
            SaveHisReport();
            if (txt_u1.Text.Length >= 5 && txtx_main.Text.Length >= 5 && txt_u2.Text.Length >= 5 && txt_u3.Text.Length >= 5 && cb_province.Text != "เลือก")
            {
                string get = "tbl_income_user";
                //tbl_income_fine
                GetReportOver30Day(get, "ส่งเงินผู้ใช้ทางไม่รับเงินทอน", false, date_start_r2, date_end_r2);
            }
            else
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GetReportOver30Day(string get, string type_send, bool print, DateTimePicker txt_date_start, DateTimePicker txt_date_end)
        {
            string sql = "";
            DateTime date_around = date_start_r2.Value;
            DateTime date_aroundNext = date_start_r2.Value.AddDays(1);
            DateTime date_end = txt_date_end.Value;

            sql += "SELECT tbl_income_id,STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) AS date_job, CONCAT( tbl_income_in_time, ' - ', tbl_income_out_time, ' น.' ) AS time_job, tbl_status_around_aid AS around, tbl_income_cabinet AS cabinet, tbl_emp_name AS emp_name, " + get + " AS amount, tbl_cpoint_name AS cpoint FROM tbl_income JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id WHERE DATEDIFF( STR_TO_DATE('" + date_around.ToString("dd-MM-yyyy") + "', '%d-%c-%Y'), STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) ) = 30 AND ( " + get + " IS NOT NULL AND " + get + " <> '0' ) AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' ";
            if (rd_print2.Checked)
            {
                int max = (date_end_r2.Value - date_start_r2.Value).Days;
                for (int i = 1; i <= max; i++)
                {
                    date_around = date_around.AddDays(1);
                    date_aroundNext = date_aroundNext.AddDays(1);
                    sql += " UNION SELECT tbl_income_id,STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) AS date_job, CONCAT( tbl_income_in_time, ' - ', tbl_income_out_time, ' น.' ) AS time_job, tbl_status_around_aid AS around, tbl_income_cabinet AS cabinet, tbl_emp_name AS emp_name, " + get + " AS amount, tbl_cpoint_name AS cpoint FROM tbl_income JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id WHERE DATEDIFF( STR_TO_DATE('" + date_around.ToString("dd-MM-yyyy") + "', '%d-%c-%Y'), STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) ) = 30 AND ( " + get + " IS NOT NULL AND " + get + " <> '0' ) AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' ";
                }
            }
            sql += " Order by date_job,around,cabinet,time_job";
            ConnectDB contxt = new ConnectDB();
            MySqlConnection conn = new MySqlConnection();
            conn = new MySqlConnection(contxt.context());
            MySqlCommand cmd;
            conn.Open();
            script.Load_page();
            cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            MySqlDataAdapter adap = new MySqlDataAdapter();
            DataSet_Report reportDB = new DataSet_Report();

            adap.SelectCommand = cmd;
            reportDB.Clear();
            adap.Fill(reportDB, "Report_Send30Day");

            newReport_fine Report_fine = new newReport_fine();
            Report_fine.SetDataSource(reportDB);

            DateTime d_start = txt_date_start.Value.AddDays(-30);
            DateTime d_end = txt_date_end.Value.AddDays(-30);

            Report_fine.SetParameterValue("date_job", date_start_r2.Value.Date);
            Report_fine.SetParameterValue("user_print", mainForm.emp_control_id + " " + script.GetEmpName(mainForm.emp_control_id));
            Report_fine.SetParameterValue("province", cb_province.Text);
            Report_fine.SetParameterValue("type_send", type_send);
            Report_fine.SetParameterValue("user_send", script.getEmpName_Group(txt_u1.Text).Split('|')[0]);
            Report_fine.SetParameterValue("group_send", script.NotManager(txt_u1.Text));
            Report_fine.SetParameterValue("emp_pos", script.GetPosEmp(6));


            if (rd_print2.Checked)
            {
                /*  if (txt_date_start.Value.Month == date_end.Month)
                  {
                      Report_fine.SetParameterValue("date_report", (d_start.Day + " - " + script.GetMontThai(d_end)));
                  }
                  else
                  {
                      Report_fine.SetParameterValue("date_report", script.GetMontThai(d_start).Split(' ')[0] + " " + script.GetMontThai(d_start).Split(' ')[1] + " - " + script.GetMontThai(d_end));
                  } */
                if ((d_start.Month == d_end.Month) && (d_start.Year == d_end.Year))
                {
                    Report_fine.SetParameterValue("date_report", (d_start.Day + " - " + script.GetMontThai(d_end)));
                }
                else
                if ((d_start.Month != d_end.Month) && (d_start.Year == d_end.Year))
                {
                    Report_fine.SetParameterValue("date_report", script.GetMontThai(d_start).Split(' ')[0] + " " + script.GetMontThai(d_start).Split(' ')[1] + " - " + script.GetMontThai(d_end));
                    
                }
                else
                if ((d_start.Month != d_end.Month) && (d_start.Year != d_end.Year))
                {
                    Report_fine.SetParameterValue("date_report", script.GetMontThai(d_start).Split(' ')[0] + " " + script.GetMontThai(d_start).Split(' ')[1] + " " + script.GetMontThai(d_start).Split(' ')[2] + " - " + script.GetMontThai(d_end));
                }
                Report_fine.SetParameterValue("date_job", script.GetMontThai(txt_date_end.Value.AddDays(1))); 

            }
            else
            {
                Report_fine.SetParameterValue("date_report", (script.GetMontThai(d_start)));
                Report_fine.SetParameterValue("date_job", script.GetMontThai(txt_date_start.Value.AddDays(1)));
            }

            if (print)
            {
                try
                {
                    Report_fine.PrintToPrinter(1, true, 0, 0);
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
                popup.cry_View.ReportSource = Report_fine;
                popup.Text = type_send;
                //popup.cry_View.Zoom(80);
                popup.Show();
            }
        }

        private void GetReportOverDay(string get, string type_send, bool print)
        {
            string sql = "";
            DateTime date_around = date_start_r2.Value;
            DateTime date_aroundNext = date_start_r2.Value.AddDays(1);

            DateTime dStart = date_start_r2.Value;
            DateTime dEnd = date_end_r2.Value;

            sql += "SELECT `tbl_income_id`,STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) AS date_job, CONCAT( tbl_income_in_time, ' - ', tbl_income_out_time, ' น.' ) AS time_job, tbl_status_around_aid AS around, tbl_income_cabinet AS cabinet, tbl_emp_name AS emp_name, " + get + " AS amount, tbl_cpoint_name AS cpoint FROM tbl_income JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id WHERE tbl_status_around_aid = '2' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND ( " + get + " IS NOT NULL AND " + get + " <> '0' ) AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "'";
            sql += " UNION  SELECT `tbl_income_id`,STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) AS date_job, CONCAT( tbl_income_in_time, ' - ', tbl_income_out_time, ' น.' ) AS time_job, tbl_status_around_aid AS around, tbl_income_cabinet AS cabinet, tbl_emp_name AS emp_name, " + get + " AS amount, tbl_cpoint_name AS cpoint FROM tbl_income JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id WHERE tbl_status_around_aid = '3' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND ( " + get + " IS NOT NULL AND " + get + " <> '0' ) AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "'";
            sql += " UNION  SELECT `tbl_income_id`,STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) AS date_job, CONCAT( tbl_income_in_time, ' - ', tbl_income_out_time, ' น.' ) AS time_job, tbl_status_around_aid AS around, tbl_income_cabinet AS cabinet, tbl_emp_name AS emp_name, " + get + " AS amount, tbl_cpoint_name AS cpoint FROM tbl_income JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id WHERE tbl_status_around_aid = '1' AND tbl_status_around_date = '" + date_around.AddDays(1).ToString("dd-MM-yyyy") + "' AND ( " + get + " IS NOT NULL AND " + get + " <> '0' ) AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "'";
            if (rd_print2.Checked)
            {
                int max = (date_end_r2.Value - date_start_r2.Value).Days;
                for (int i = 1; i <= max; i++)
                {
                    date_around = date_around.AddDays(1);
                    date_aroundNext = date_aroundNext.AddDays(1);
                    sql += " UNION  SELECT `tbl_income_id`,STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) AS date_job, CONCAT( tbl_income_in_time, ' - ', tbl_income_out_time, ' น.' ) AS time_job, tbl_status_around_aid AS around, tbl_income_cabinet AS cabinet, tbl_emp_name AS emp_name, " + get + " AS amount, tbl_cpoint_name AS cpoint FROM tbl_income JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id WHERE tbl_status_around_aid = '2' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND ( " + get + " IS NOT NULL AND " + get + " <> '0' ) AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "'";
                    sql += " UNION  SELECT `tbl_income_id`,STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) AS date_job, CONCAT( tbl_income_in_time, ' - ', tbl_income_out_time, ' น.' ) AS time_job, tbl_status_around_aid AS around, tbl_income_cabinet AS cabinet, tbl_emp_name AS emp_name, " + get + " AS amount, tbl_cpoint_name AS cpoint FROM tbl_income JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id WHERE tbl_status_around_aid = '3' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND ( " + get + " IS NOT NULL AND " + get + " <> '0' ) AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "'";
                    sql += " UNION  SELECT `tbl_income_id`,STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) AS date_job, CONCAT( tbl_income_in_time, ' - ', tbl_income_out_time, ' น.' ) AS time_job, tbl_status_around_aid AS around, tbl_income_cabinet AS cabinet, tbl_emp_name AS emp_name, " + get + " AS amount, tbl_cpoint_name AS cpoint FROM tbl_income JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id WHERE tbl_status_around_aid = '1' AND tbl_status_around_date = '" + date_around.AddDays(1).ToString("dd-MM-yyyy") + "' AND ( " + get + " IS NOT NULL AND " + get + " <> '0' ) AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "'";

                }
            }
            sql += "ORDER BY date_job,around,cabinet,time_job";
            ConnectDB contxt = new ConnectDB();
            MySqlConnection conn = new MySqlConnection();
            conn = new MySqlConnection(contxt.context());
            MySqlCommand cmd;
            conn.Open();
            script.Load_page();
            cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            MySqlDataAdapter adap = new MySqlDataAdapter();
            DataSet_Report reportDB = new DataSet_Report();

            adap.SelectCommand = cmd;
            reportDB.Clear();
            adap.Fill(reportDB, "Report_Send30Day");

            newReport_fine Report_fine = new newReport_fine();
            Report_fine.SetDataSource(reportDB);


            Report_fine.SetParameterValue("user_print", mainForm.emp_control_id + " " + script.GetEmpName(mainForm.emp_control_id));
            Report_fine.SetParameterValue("province", cb_province.Text);
            Report_fine.SetParameterValue("type_send", type_send);
            Report_fine.SetParameterValue("user_send", script.getEmpName_Group(txt_u1.Text).Split('|')[0]);
            Report_fine.SetParameterValue("group_send", script.NotManager(txt_u1.Text));
            Report_fine.SetParameterValue("emp_pos", script.GetPosEmp(6));

            if (rd_print2.Checked)
            {
                /*  if ((dStart.Month == dEnd.Month) && (dStart.Year == dEnd.Year))
                  {
                      Report_fine.SetParameterValue("date_report", (dStart.Day + " - " + script.GetMontThai(dEnd.AddDays(1))));
                  }
                  else if ((dStart.Month != dEnd.Month) && (dStart.Year == dEnd.Year))
                  {
                      Report_fine.SetParameterValue("date_report", script.GetMontThai(dStart).Split(' ')[0] + " " + script.GetMontThai(dStart).Split(' ')[1] + " - " + script.GetMontThai(dEnd.AddDays(1)));
                  }
                  else if ((dStart.Month != dEnd.Month) && (dStart.Year != dEnd.Year))
                  {
                      Report_fine.SetParameterValue("date_report", script.GetMontThai(dStart).Split(' ')[0] + " " + script.GetMontThai(dStart).Split(' ')[1] + " " + script.GetMontThai(dStart).Split(' ')[2] + " - " + script.GetMontThai(dEnd.AddDays(1)));
                  }

                  Report_fine.SetParameterValue("date_job", script.GetMontThai(dEnd.AddDays(1)));
                  */
                if ((dStart.Month == dEnd.AddDays(1).Month) && (dStart.Year == dEnd.AddDays(1).Year))
                {
                    Report_fine.SetParameterValue("date_report", (dStart.Day + " - " + script.GetMontThai(dEnd.AddDays(1))));
                }
                else if ((dStart.Month != dEnd.AddDays(1).Month) && (dStart.Year == dEnd.AddDays(1).Year))
                {
                    Report_fine.SetParameterValue("date_report", script.GetMontThai(dStart).Split(' ')[0] + " " + script.GetMontThai(dStart).Split(' ')[1] + " - " + script.GetMontThai(dEnd.AddDays(1)));
                }
                else if ((dStart.Month != dEnd.AddDays(1).Month) && (dStart.Year != dEnd.AddDays(1).Year))
                {
                    Report_fine.SetParameterValue("date_report", script.GetMontThai(dStart).Split(' ')[0] + " " + script.GetMontThai(dStart).Split(' ')[1] + " " + script.GetMontThai(dStart).Split(' ')[2] + " - " + script.GetMontThai(dEnd.AddDays(1)));
                }

                Report_fine.SetParameterValue("date_job", script.GetMontThai(dEnd.AddDays(1)));

            }
            else
            {
                if ((dStart.Month == dEnd.AddDays(1).Month) && (dStart.Year == dEnd.AddDays(1).Year))
                {
                    Report_fine.SetParameterValue("date_report", (dStart.Day + " - " + script.GetMontThai(dEnd.AddDays(1))));
                }
                else if ((dStart.Month != dEnd.AddDays(1).Month) && (dStart.Year == dEnd.AddDays(1).Year))
                {
                    Report_fine.SetParameterValue("date_report", script.GetMontThai(dStart).Split(' ')[0] + " " + script.GetMontThai(dStart).Split(' ')[1] + " - " + script.GetMontThai(dEnd.AddDays(1)));
                }
                else if ((dStart.Month != dEnd.AddDays(1).Month) && (dStart.Year != dEnd.AddDays(1).Year))
                {
                    Report_fine.SetParameterValue("date_report", script.GetMontThai(dStart).Split(' ')[0] + " " + script.GetMontThai(dStart).Split(' ')[1] + " " + script.GetMontThai(dStart).Split(' ')[2] + " - " + script.GetMontThai(dEnd.AddDays(1)));
                }

                Report_fine.SetParameterValue("date_job", script.GetMontThai(dEnd.AddDays(1)));
            }
                /*  {
                      if (dStart.Month == dStart.AddDays(1).Month)
                      {
                          Report_fine.SetParameterValue("date_report", (dStart.Day + " - " + script.GetMontThai(dStart.AddDays(+1))));
                      }
                      else if ((dStart.Month != dEnd.Month) && (dStart.Year != dEnd.Year))
                      {
                          Report_fine.SetParameterValue("date_report", script.GetMontThai(dStart).Split(' ')[0] + " " + script.GetMontThai(dStart).Split(' ')[1] + " " + script.GetMontThai(dStart).Split(' ')[2] + " - " + script.GetMontThai(dEnd.AddDays(1)));
                      }
                      else if (dStart.Month != dStart.AddDays(1).Month)
                      {
                          Report_fine.SetParameterValue("date_report", script.GetMontThai(dStart).Split(' ')[0] + " " + script.GetMontThai(dStart).Split(' ')[1] + " - " + script.GetMontThai(dStart.AddDays(1)));
                      }

                      Report_fine.SetParameterValue("date_job", script.GetMontThai(dStart.AddDays(1)));
                  }*/

                if (print)
            {
                try
                {
                    Report_fine.PrintToPrinter(1, true, 0, 0);
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
                popup.cry_View.ReportSource = Report_fine;
                //MessageBox.Show(popup.cry_View.GetCurrentPageNumber().ToString());
                popup.Text = type_send;
                //popup.cry_View.Zoom(80);
                popup.Show();
            }

        }

        private void btn_f_30_Click(object sender, EventArgs e)
        {
            SaveHisReport();
            if (txt_u1.Text.Length >= 5 && txtx_main.Text.Length >= 5 && txt_u2.Text.Length >= 5 && txt_u3.Text.Length >= 5 && cb_province.Text != "เลือก")
            {
                string get = "tbl_income_fine";
                //tbl_income_fine
                GetReportOver30Day(get, "ส่งเงินค่าปรับบัตร Transit card", false, date_start_r2, date_end_r2);
            }
            else
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_u1.Text.Length >= 5 && txtx_main.Text.Length >= 5 && txt_u2.Text.Length >= 5 && txt_u3.Text.Length >= 5 && cb_province.Text != "เลือก")
            {
                DateTime date_around = date_start_r2.Value;
                DateTime date_aroundNext = date_start_r2.Value.AddDays(1);
                string sql_ts12 = "SELECT STR_TO_DATE((SELECT tbl_status_around_date FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '2' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY tbl_status_around_date),'%d-%c-%Y') AS date_report1, (SELECT COUNT(*) AS around1 FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '2' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' ) AS around1, (SELECT SUM(tbl_income_bank) AS sum_around1 FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '2' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' ) AS sum_around1, STR_TO_DATE((SELECT tbl_status_around_date FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '3' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY tbl_status_around_date),'%d-%c-%Y') AS date_report2, (SELECT COUNT(*) AS around1 FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '3' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' ) AS around2, (SELECT SUM(tbl_income_bank) AS sum_around2 FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '3' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' ) AS sum_around2, STR_TO_DATE((SELECT tbl_status_around_date FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '1' AND tbl_status_around_date = '" + date_aroundNext.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY tbl_status_around_date),'%d-%c-%Y') AS date_report3, (SELECT COUNT(*) AS around1 FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '1' AND tbl_status_around_date = '" + date_aroundNext.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' ) AS around3, (SELECT SUM(tbl_income_bank) AS sum_around3 FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '1' AND tbl_status_around_date = '" + date_aroundNext.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' ) AS sum_around3, (SELECT SUM(amount) FROM ( SELECT SUM(tbl_income_user) AS amount FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE DATEDIFF( STR_TO_DATE( '" + date_around.ToString("dd-MM-yyyy") + "', '%d-%c-%Y' ), STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) ) = 30 AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_status_around_cpoint_id` UNION (SELECT SUM(tbl_income_fine) AS amount FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE DATEDIFF( STR_TO_DATE( '" + date_around.ToString("dd-MM-yyyy") + "', '%d-%c-%Y' ), STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) ) = 30 AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_status_around_cpoint_id`) UNION (SELECT tbl_incom_other_amount AS amount FROM tbl_incom_other JOIN tbl_emp ON tbl_emp_id = tbl_incom_other_emp_id WHERE tbl_incom_other_list_incom_id = '4' AND tbl_incom_other_date_send = '" + date_around.AddDays(-1).ToString("dd-MM-yyyy") + "' AND tbl_incom_cpoint_id = '" + mainForm.cpoint_id + "') UNION (SELECT memo_amount AS amount FROM tbl_memo WHERE (memo_status IS NOT NULL) AND (memo_bag IS NOT NULL) AND (memo_strapes IS NOT NULL) AND memo_date_payment = '" + date_around.AddDays(-1).ToString("dd-MM-yyyy") + "' AND memo_cpoint_id = '" + mainForm.cpoint_id + "' )) AS ts4) AS sum_extra FROM DUAL";
                if (rd_print2.Checked)
                {
                    int max = (date_end_r2.Value - date_start_r2.Value).Days;
                    for (int i = 1; i <= max; i++)
                    {
                        date_around = date_around.AddDays(1);
                        date_aroundNext = date_aroundNext.AddDays(1);
                        sql_ts12 += " UNION SELECT STR_TO_DATE((SELECT tbl_status_around_date FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '2' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY tbl_status_around_date),'%d-%c-%Y') AS date_report1, (SELECT COUNT(*) AS around1 FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '2' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' ) AS around1, (SELECT SUM(tbl_income_bank) AS sum_around1 FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '2' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' ) AS sum_around1, STR_TO_DATE((SELECT tbl_status_around_date FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '3' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY tbl_status_around_date),'%d-%c-%Y') AS date_report2, (SELECT COUNT(*) AS around1 FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '3' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' ) AS around2, (SELECT SUM(tbl_income_bank) AS sum_around2 FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '3' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' ) AS sum_around2, STR_TO_DATE((SELECT tbl_status_around_date FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '1' AND tbl_status_around_date = '" + date_aroundNext.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY tbl_status_around_date),'%d-%c-%Y') AS date_report3, (SELECT COUNT(*) AS around1 FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '1' AND tbl_status_around_date = '" + date_aroundNext.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' ) AS around3, (SELECT SUM(tbl_income_bank) AS sum_around3 FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id WHERE tbl_status_around_aid = '1' AND tbl_status_around_date = '" + date_aroundNext.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "' ) AS sum_around3, (SELECT SUM(amount) FROM(SELECT SUM(tbl_income_user) AS amount FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE DATEDIFF(STR_TO_DATE('" + date_around.ToString("dd-MM-yyyy") + "', '%d-%c-%Y'), STR_TO_DATE(tbl_status_around_date, '%d-%c-%Y')) = 30 AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_status_around_cpoint_id` UNION(SELECT SUM(tbl_income_fine) AS amount FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE DATEDIFF(STR_TO_DATE('" + date_around.ToString("dd-MM-yyyy") + "', '%d-%c-%Y'), STR_TO_DATE(tbl_status_around_date, '%d-%c-%Y')) = 30 AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_status_around_cpoint_id`) UNION(SELECT tbl_incom_other_amount AS amount FROM tbl_incom_other JOIN tbl_emp ON tbl_emp_id = tbl_incom_other_emp_id WHERE tbl_incom_other_list_incom_id = '4' AND tbl_incom_other_date_send = '" + date_around.AddDays(-1).ToString("dd-MM-yyyy") + "' AND tbl_incom_cpoint_id = '" + mainForm.cpoint_id + "') UNION(SELECT memo_amount AS amount FROM tbl_memo WHERE(memo_status IS NOT NULL) AND(memo_bag IS NOT NULL) AND(memo_strapes IS NOT NULL) AND memo_date_payment = '" + date_around.AddDays(-1).ToString("dd-MM-yyyy") + "' AND memo_cpoint_id = '" + mainForm.cpoint_id + "')) AS ts4) AS sum_extra FROM DUAL";
                    }
                }
                ConnectDB contxt = new ConnectDB();
                MySqlConnection conn = new MySqlConnection();
                conn = new MySqlConnection(contxt.context());
                MySqlCommand cmd;
                conn.Open();
                script.Load_page();
                cmd = conn.CreateCommand();
                cmd.CommandText = sql_ts12;
                MySqlDataAdapter adap = new MySqlDataAdapter();
                DataSet_Report reportDB = new DataSet_Report();

                adap.SelectCommand = cmd;
                reportDB.Clear();
                adap.Fill(reportDB, "Report_TS12");

                ReportTS12 report = new ReportTS12();
                report.SetDataSource(reportDB);

                report.SetParameterValue("user_send1", script.getEmpName_Group(txt_u2.Text).Split('|')[0]);
                report.SetParameterValue("group_send1", script.getEmpName_Group(txt_u2.Text).Split('|')[1]);
                report.SetParameterValue("user_send2", script.getEmpName_Group(txt_u3.Text).Split('|')[0]);
                report.SetParameterValue("group_send2", script.getEmpName_Group(txt_u3.Text).Split('|')[1]);
                report.SetParameterValue("user_main", script.getEmpName_Group(txtx_main.Text).Split('|')[0]);
                report.SetParameterValue("group_main", script.getEmpName_Group(txtx_main.Text).Split('|')[1]);
                report.SetParameterValue("cpoint", script.GetCpoint(mainForm.cpoint_id));

                PopupReport popup = new PopupReport();
                popup = new PopupReport();
                popup.cry_View.ReportSource = report;
                popup.Text = "การส่งมอบรายการตรวจนับเงินสด ด่านฯ" + script.GetCpoint(mainForm.cpoint_id);
                //popup.cry_View.Zoom(80);
                popup.Show();
            }
            else
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveHisReport();
            if (txt_u1.Text.Length >= 5 && cb_province.Text != "เลือก")
            {
                string get = "tbl_income_over";
                //tbl_income_fine
                GetReportOverDay(get, "ส่งเงินเกินบัญชี", false);
            }
            else
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_send_bank_Click(object sender, EventArgs e)
        {
            SaveHisReport();
            GetSendBank(false);
        }

        public void GetSendBank(bool print)
        {
            if (txt_bag.Text != "" && txt_straps.Text != "" && label_u1.Text != "")
            {
                script.Load_page();
                MySqlDataAdapter adap = new MySqlDataAdapter();
                MySqlConnection conn = script.conn;
                MySqlCommand cmd;
                DataSet_Report reportDB = new DataSet_Report();
                PopupReport popup = new PopupReport();
                popup.Text = "รายงานการนำส่งรายได้ค่าธรรมเนียมผ่านทาง";
                string sql = "";

                DateTime date_around = date_start_r2.Value;
                DateTime date_aroundNext = date_start_r2.Value.AddDays(1);
                int max = (date_end_r2.Value - date_start_r2.Value).Days;

                if (rd_print2.Checked == false)
                {
                    sql += "SELECT tbl_status_around_aid, tbl_around_time, tbl_status_around_date, tbl_income_money_bag, tbl_income_straps AS tbl_income_straps, IF(tbl_income_emp_id IS NULL,'ถุงเงินพิเศษ',tbl_income_emp_id) AS tbl_income_emp_id, IF(tbl_emp_name IS NULL,CONCAT('*ปรับยอด (',(SELECT tbl_emp_name FROM tbl_status_around T2 JOIN tbl_emp ON tbl_emp_id = T2.tbl_status_around_emp_open_id WHERE T2.tbl_status_around_emp_open_id = T1.`tbl_status_around_emp_open_id` GROUP BY  tbl_status_around_emp_open_id ),') (รองฯ)'),tbl_emp_name) AS tbl_emp_name, tbl_income_cabinet, tbl_income_job, tbl_income_in_time, tbl_income_out_time, tbl_income_total, tbl_income_bank, tbl_income_user, tbl_income_fine, tbl_income_other, tbl_cpoint_name, STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) AS date_around FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around T1 ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id ";
                    sql += " WHERE tbl_status_around_aid = '2' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "'  AND tbl_income_bank <> 0";
                    //sql1 = "SELECT tbl_incom_other_around AS tbl_status_around_aid, '" + date_start_r1.Text + "' AS tbl_around_time, tbl_incom_other_date AS tbl_status_around_date, tbl_incom_other_bag AS tbl_income_money_bag, tbl_incom_other_straps AS tbl_income_straps, IF(tbl_incom_other_emp_id IS NOT NULL,'ถุงเงินพิเศษ',NULL) AS tbl_income_emp_id, IF(tbl_incom_other_emp_id IS NOT NULL,'*ผู้ใช้ทางและค่าปรับบัตรหายที่เกิน 30 วัน',NULL) AS tbl_emp_name, '' AS tbl_income_cabinet, '' AS tbl_income_job, '' AS tbl_income_in_time, '' AS tbl_income_out_time, " + sum_select + " AS tbl_income_total, " + sum_select + " AS tbl_income_bank, '0' AS tbl_income_user, '0' AS tbl_income_fine, '0' AS tbl_income_other, '" + script.GetCpoint(mainForm.cpoint_id) + "' AS tbl_cpoint_name, STR_TO_DATE( tbl_incom_other_date_send, '%e-%c-%Y' ) AS date_around FROM tbl_incom_other  WHERE tbl_incom_other_date_send ='" + date_start_r1.Text + "' AND (tbl_incom_other_list_incom_id = 2 OR tbl_incom_other_list_incom_id = 3) AND tbl_incom_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY tbl_incom_cpoint_sub_id";

                    sql += " UNION SELECT tbl_status_around_aid, tbl_around_time, tbl_status_around_date, tbl_income_money_bag, tbl_income_straps AS tbl_income_straps, IF(tbl_income_emp_id IS NULL,'ถุงเงินพิเศษ',tbl_income_emp_id) AS tbl_income_emp_id, IF(tbl_emp_name IS NULL,CONCAT('*ปรับยอด (',(SELECT tbl_emp_name FROM tbl_status_around T2 JOIN tbl_emp ON tbl_emp_id = T2.tbl_status_around_emp_open_id WHERE T2.tbl_status_around_emp_open_id = T1.`tbl_status_around_emp_open_id` GROUP BY  tbl_status_around_emp_open_id ),') (รองฯ)'),tbl_emp_name) AS tbl_emp_name, tbl_income_cabinet, tbl_income_job, tbl_income_in_time, tbl_income_out_time, tbl_income_total, tbl_income_bank, tbl_income_user, tbl_income_fine, tbl_income_other, tbl_cpoint_name, STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) AS date_around FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around T1 ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id ";
                    sql += " WHERE tbl_status_around_aid = '3' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "'  AND tbl_income_bank <> 0";

                    sql += " UNION SELECT tbl_status_around_aid, tbl_around_time, tbl_status_around_date, tbl_income_money_bag, tbl_income_straps AS tbl_income_straps, IF(tbl_income_emp_id IS NULL,'ถุงเงินพิเศษ',tbl_income_emp_id) AS tbl_income_emp_id, IF(tbl_emp_name IS NULL,CONCAT('*ปรับยอด (',(SELECT tbl_emp_name FROM tbl_status_around T2 JOIN tbl_emp ON tbl_emp_id = T2.tbl_status_around_emp_open_id WHERE T2.tbl_status_around_emp_open_id = T1.`tbl_status_around_emp_open_id` GROUP BY  tbl_status_around_emp_open_id ),') (รองฯ)'),tbl_emp_name) AS tbl_emp_name, tbl_income_cabinet, tbl_income_job, tbl_income_in_time, tbl_income_out_time, tbl_income_total, tbl_income_bank, tbl_income_user, tbl_income_fine, tbl_income_other, tbl_cpoint_name, STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) AS date_around FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around T1 ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id ";
                    sql += " WHERE tbl_status_around_aid = '1' AND tbl_status_around_date = '" + date_around.AddDays(1).ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "'  AND tbl_income_bank <> 0";

                }
                else if (rd_print2.Checked == true)
                {
                    for (int i = 0; i <= max; i++)
                    {

                        if (i != 0)
                        {
                            sql += " UNION ";
                        }
                        sql += "SELECT tbl_status_around_aid, tbl_around_time, tbl_status_around_date, tbl_income_money_bag, tbl_income_straps AS tbl_income_straps, IF(tbl_income_emp_id IS NULL,'ถุงเงินพิเศษ',tbl_income_emp_id) AS tbl_income_emp_id, IF(tbl_emp_name IS NULL,CONCAT('*ปรับยอด (',(SELECT tbl_emp_name FROM tbl_status_around T2 JOIN tbl_emp ON tbl_emp_id = T2.tbl_status_around_emp_open_id WHERE T2.tbl_status_around_emp_open_id = T1.`tbl_status_around_emp_open_id` GROUP BY  tbl_status_around_emp_open_id ),') (รองฯ)'),tbl_emp_name) AS tbl_emp_name, tbl_income_cabinet, tbl_income_job, tbl_income_in_time, tbl_income_out_time, tbl_income_total, tbl_income_bank, tbl_income_user, tbl_income_fine, tbl_income_other, tbl_cpoint_name, STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) AS date_around FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around T1 ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id ";
                        sql += " WHERE tbl_status_around_aid = '2' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "'  AND tbl_income_bank <> 0";
                        //sql1 = "SELECT tbl_incom_other_around AS tbl_status_around_aid, '" + date_start_r1.Text + "' AS tbl_around_time, tbl_incom_other_date AS tbl_status_around_date, tbl_incom_other_bag AS tbl_income_money_bag, tbl_incom_other_straps AS tbl_income_straps, IF(tbl_incom_other_emp_id IS NOT NULL,'ถุงเงินพิเศษ',NULL) AS tbl_income_emp_id, IF(tbl_incom_other_emp_id IS NOT NULL,'*ผู้ใช้ทางและค่าปรับบัตรหายที่เกิน 30 วัน',NULL) AS tbl_emp_name, '' AS tbl_income_cabinet, '' AS tbl_income_job, '' AS tbl_income_in_time, '' AS tbl_income_out_time, " + sum_select + " AS tbl_income_total, " + sum_select + " AS tbl_income_bank, '0' AS tbl_income_user, '0' AS tbl_income_fine, '0' AS tbl_income_other, '" + script.GetCpoint(mainForm.cpoint_id) + "' AS tbl_cpoint_name, STR_TO_DATE( tbl_incom_other_date_send, '%e-%c-%Y' ) AS date_around FROM tbl_incom_other  WHERE tbl_incom_other_date_send ='" + date_start_r1.Text + "' AND (tbl_incom_other_list_incom_id = 2 OR tbl_incom_other_list_incom_id = 3) AND tbl_incom_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY tbl_incom_cpoint_sub_id";

                        sql += " UNION SELECT tbl_status_around_aid, tbl_around_time, tbl_status_around_date, tbl_income_money_bag, tbl_income_straps AS tbl_income_straps, IF(tbl_income_emp_id IS NULL,'ถุงเงินพิเศษ',tbl_income_emp_id) AS tbl_income_emp_id, IF(tbl_emp_name IS NULL,CONCAT('*ปรับยอด (',(SELECT tbl_emp_name FROM tbl_status_around T2 JOIN tbl_emp ON tbl_emp_id = T2.tbl_status_around_emp_open_id WHERE T2.tbl_status_around_emp_open_id = T1.`tbl_status_around_emp_open_id` GROUP BY  tbl_status_around_emp_open_id ),') (รองฯ)'),tbl_emp_name) AS tbl_emp_name, tbl_income_cabinet, tbl_income_job, tbl_income_in_time, tbl_income_out_time, tbl_income_total, tbl_income_bank, tbl_income_user, tbl_income_fine, tbl_income_other, tbl_cpoint_name, STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) AS date_around FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around T1 ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id ";
                        sql += " WHERE tbl_status_around_aid = '3' AND tbl_status_around_date = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "'  AND tbl_income_bank <> 0";

                        sql += " UNION SELECT tbl_status_around_aid, tbl_around_time, tbl_status_around_date, tbl_income_money_bag, tbl_income_straps AS tbl_income_straps, IF(tbl_income_emp_id IS NULL,'ถุงเงินพิเศษ',tbl_income_emp_id) AS tbl_income_emp_id, IF(tbl_emp_name IS NULL,CONCAT('*ปรับยอด (',(SELECT tbl_emp_name FROM tbl_status_around T2 JOIN tbl_emp ON tbl_emp_id = T2.tbl_status_around_emp_open_id WHERE T2.tbl_status_around_emp_open_id = T1.`tbl_status_around_emp_open_id` GROUP BY  tbl_status_around_emp_open_id ),') (รองฯ)'),tbl_emp_name) AS tbl_emp_name, tbl_income_cabinet, tbl_income_job, tbl_income_in_time, tbl_income_out_time, tbl_income_total, tbl_income_bank, tbl_income_user, tbl_income_fine, tbl_income_other, tbl_cpoint_name, STR_TO_DATE( tbl_status_around_date, '%d-%c-%Y' ) AS date_around FROM tbl_income LEFT JOIN tbl_emp ON tbl_emp_id = tbl_income_emp_id JOIN tbl_status_around T1 ON tbl_income_around_id = tbl_status_around_id JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id JOIN tbl_around ON tbl_status_around_aid = tbl_around_id ";
                        sql += " WHERE tbl_status_around_aid = '1' AND tbl_status_around_date = '" + date_around.AddDays(1).ToString("dd-MM-yyyy") + "' AND tbl_cpoint_id = '" + mainForm.cpoint_id + "'  AND tbl_income_bank <> 0";

                        date_around = date_around.AddDays(1);
                        date_aroundNext = date_aroundNext.AddDays(1);
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

                double total = 0;

                if (rd_print2.Checked == true)
                {
                    date_around = date_start_r2.Value;
                    date_aroundNext = date_start_r2.Value.AddDays(1);
                    for (int i = 0; i <= max; i++)
                    {
                        string sql_30 = "";
                     sql_30 = "SELECT SUM(amount) AS amount FROM((SELECT SUM(tbl_income_user)+SUM(tbl_income_fine) AS amount FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE DATEDIFF(STR_TO_DATE('" + date_around.ToString("dd-MM-yyyy") + "', '%d-%c-%Y'), STR_TO_DATE(tbl_status_around_date, '%d-%c-%Y')) = 30 AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_status_around_cpoint_id`) UNION (SELECT SUM(tbl_incom_other_amount) AS amount FROM tbl_incom_other LEFT JOIN tbl_emp ON tbl_emp_id = tbl_incom_other_emp_id WHERE tbl_incom_other_date_send = '" + date_aroundNext.ToString("dd-MM-yyyy") + "' AND tbl_incom_cpoint_id = '" + mainForm.cpoint_id + "') UNION(SELECT SUM(memo_amount) AS amount FROM tbl_memo WHERE(memo_status IS NOT NULL) AND memo_date_payment = '" + date_around.ToString("dd-MM-yyyy") + "' AND memo_cpoint_id = '" + mainForm.cpoint_id + "')) TB";
                        MySqlDataReader rs = script.Select_SQL(sql_30);

                        if (rs.Read())
                        {
                            if (!rs.IsDBNull(0))
                            {
                                total += double.Parse(rs.GetString("amount"));
                            }
                        }
                        date_around = date_around.AddDays(1);
                        date_aroundNext = date_aroundNext.AddDays(1);
                    }
                }
                else
                {
                    string sql_30 = "";
                    sql_30 = "SELECT SUM(amount) AS amount FROM((SELECT SUM(tbl_income_user)+SUM(tbl_income_fine) AS amount FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_around` ON `tbl_status_around_aid` = `tbl_around_id` JOIN tbl_cpoint ON tbl_cpoint_id = tbl_status_around_cpoint_id WHERE DATEDIFF(STR_TO_DATE('" + date_around.ToString("dd-MM-yyyy") + "', '%d-%c-%Y'), STR_TO_DATE(tbl_status_around_date, '%d-%c-%Y')) = 30 AND tbl_status_around_cpoint_id = '" + mainForm.cpoint_id + "' GROUP BY `tbl_status_around_cpoint_id`) UNION (SELECT SUM(tbl_incom_other_amount) AS amount FROM tbl_incom_other LEFT JOIN tbl_emp ON tbl_emp_id = tbl_incom_other_emp_id WHERE tbl_incom_other_date_send = '" + date_around.ToString("dd-MM-yyyy") + "' AND tbl_incom_cpoint_id = '" + mainForm.cpoint_id + "') UNION(SELECT SUM(memo_amount) AS amount FROM tbl_memo WHERE(memo_status IS NOT NULL) AND memo_date_payment = '" + date_around.ToString("dd-MM-yyyy") + "' AND memo_cpoint_id = '" + mainForm.cpoint_id + "')) TB";
                    MySqlDataReader rs = script.Select_SQL(sql_30);

                    if (rs.Read())
                    {
                        if (!rs.IsDBNull(0))
                        {
                            total += double.Parse(rs.GetString("amount"));
                        }
                    }
                }
                ReportSendBank p_sendBank = new ReportSendBank();
                p_sendBank.SetDataSource(reportDB);
                p_sendBank.SetParameterValue("user_print", mainForm.emp_control_id + " " + script.GetEmpName(mainForm.emp_control_id));
                p_sendBank.SetParameterValue("date_job", date_start_r2.Value);
                if (txt_total.Text == "")
                {
                    p_sendBank.SetParameterValue("para_bag", txt_bag.Text.Trim());
                    p_sendBank.SetParameterValue("para_straps", txt_straps.Text.Trim());
                    p_sendBank.SetParameterValue("para_mg", script.GetEmpName(txt_u1.Text));
                    p_sendBank.SetParameterValue("para_total", total);
                }
                else
                {
                    p_sendBank.SetParameterValue("para_bag", txt_bag.Text.Trim());
                    p_sendBank.SetParameterValue("para_straps", txt_straps.Text.Trim());
                    p_sendBank.SetParameterValue("para_mg", script.GetEmpName(txt_u1.Text));
                    p_sendBank.SetParameterValue("para_total", double.Parse(txt_total.Text));
                }

                p_sendBank.SetParameterValue("sub_cpoint", true ? "" : mainForm.sub_cpoint);

                popup.cry_View.ReportSource = p_sendBank;

                if (print)
                {
                    try
                    {
                        p_sendBank.PrintToPrinter(1, true, 0, 0);
                    }
                    catch
                    {
                        MessageBox.Show("พิมพ์ไม่สำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    popup.Show();
                }
            }
            else
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txt_bag_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_straps_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_total_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void txt_total_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_total.Text, out value))
                txt_total.Text = String.Format("{0:N2}", value);
            else
                txt_total.Text = String.Empty;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveHisReport();
            if (label_u1.Text != "ไม่พบข้อมูล" && cb_province.Text != "เลือก")
            {
                string get = "tbl_income_over_sys";
                //tbl_income_fine
                GetReportOverDay(get, "ส่งเงินเกินระบบ", false);
            }
            else
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn__Click(object sender, EventArgs e)
        {
            SaveHisReport();
            if (txt_u1.Text.Length >= 5 && txtx_main.Text.Length >= 5 && txt_u2.Text.Length >= 5 && txt_u3.Text.Length >= 5 && txt_straps.Text != "")
            {
                if (MessageBox.Show("ยืนยันการพิมพ์เอกสารทั้งหมด ใช่หรือไม่ ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (MessageBox.Show("ตรวจสอบกระดาษที่เครื่องพิมพ์ว่ามีเพียงพอ ใช่หรือไม่", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        GetSendBank(true);
                        GetReport(3, date_start_r2, date_end_r2, true);

                        if (mainForm.line9 == "9") { GetReportOverDay("tbl_income_over", "ส่งเงินเกินบัญชี", true); un_sys = true; }
                        if (mainForm.line9 != "9") { GetReportOverDay("tbl_income_over_sys", "ส่งเงินเกินระบบ", true); }
                        if (mainForm.line9 != "9") { GetReportOver30Day("tbl_income_fine", "ส่งเงินค่าปรับบัตร Transit card", true, date_start_r2, date_end_r2); }
                        GetReportOver30Day("tbl_income_user", "ส่งเงินผู้ใช้ทางไม่รับเงินทอน", true, date_start_r2, date_end_r2);
                        GetReport(1, date_start_r2, date_end_r2, true);
                        MessageBox.Show("พิมพ์ทั้งหมดเรียบร้อยแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
            }
            else
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SaveHisReport();
            if (txt_u1.Text != "" && label_u1.Text != "ไม่พบข้อมูล")
            {
                if (rd_print2.Checked == false)
                {
                    OfficialReportForm officialReport = new OfficialReportForm(mainForm, date_start_r2.Value, date_end_r2.Value, txt_u1.Text);
                    officialReport.ShowDialog();
                }
                else
                {
                    OfficialReportForm officialReport = new OfficialReportForm(mainForm, date_start_r2.Value, date_end_r2.Value, txt_u1.Text);
                    officialReport.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("กรุณาใส่รหัสผู้นำส่งเงิน", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_straps.Text = "000000";
                txt_bag.Text = "0000";
                txt_bag.Enabled = false;
                txt_straps.Enabled = false;
            }
            else
            {
                txt_straps.Clear();
                txt_bag.Clear();
                txt_bag.Enabled = true;
                txt_straps.Enabled = true;
            }
        }

        private void btn_ts4_9_Click(object sender, EventArgs e)
        {
            SaveHisReport();
            if (txt_u1.Text.Length >= 5 && txtx_main.Text.Length >= 5 && txt_u2.Text.Length >= 5 && txt_u3.Text.Length >= 5 && cb_province.Text != "เลือก")
            {
                //string[] user_send = { txtx_main.Text, txt_u1.Text, txt_u2.Text, txt_u3.Text };
                un_sys = true;
                GetReport(1, date_start_r2, date_end_r2, false);
            }
            else
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*TS3Form tS3Form = new TS3Form();
            tS3Form.ShowDialog();*/
        }

        private void SaveHisReport()
        {
            string sql_check = "SELECT * FROM tbl_his_report WHERE his_cpoint = '" + mainForm.cpoint_id + "' AND his_cpoint_sub = '" + mainForm.sub_cpoint + "' AND his_s_date = '" + date_start_r2.Value.ToString("yyyy-MM-dd") + "'";
            string sql_action = "";
            string text = "";
            string values = "";
            MySqlDataReader rs = script.Select_SQL(sql_check);
            if (rs.Read())
            {
                values += "his_s_date = '" + date_start_r2.Value.ToString("yyyy-MM-dd") + "'";
                values += ", his_e_date = '" + date_end_r2.Value.ToString("yyyy-MM-dd") + "'";
                values += ", his_check_extra = '" + (checkBox1.Checked ? "1" : "0") + "'";
                values += ", his_bag_extra = '" + txt_bag.Text.Trim() + "'";
                values += ", his_straps = '" + txt_straps.Text.Trim() + "'";
                values += ", his_bank = '" + txt_bank.Text.Trim() + "'";
                values += ", his_note_num = '" + txt_no.Text + "'";
                values += ", his_user1 = '" + txt_u1.Text.Trim() + "'";
                values += ", his_user2 = '" + txtx_main.Text.Trim() + "'";
                values += ", his_user3 = '" + txt_u2.Text.Trim() + "'";
                values += ", his_user4 = '" + txt_u3.Text.Trim() + "'";
                values += ", his_cpoint = '" + mainForm.cpoint_id + "'";
                values += ", his_cpoint_sub = '" + mainForm.sub_cpoint + "'";

                sql_action = "UPDATE tbl_his_report SET " + values + " WHERE his_cpoint = '" + mainForm.cpoint_id + "' AND his_cpoint_sub = '" + mainForm.sub_cpoint + "' AND his_s_date = '" + date_start_r2.Value.ToString("yyyy-MM-dd") + "' ";
                script.InsertUpdae_SQL(sql_action);

                string update_straps_old = "INSERT INTO tbl_straps (tbl_straps_number,tbl_straps_bag,tbl_straps_emp_control,tbl_straps_status,tbl_straps_note,tbl_straps_date) VALUES ('" + txt_straps.Text + "','" + txt_bag.Text + "','" + mainForm.emp_control_id + "','0','สายรัดถุงเงินพิเศษ ผจด.',NOW())";
                script.InsertUpdae_SQL(update_straps_old);
            }
            else
            {
                text += "his_s_date,his_e_date,his_check_extra,his_bag_extra,his_straps,his_bank,his_note_num,his_user1,his_user2,his_user3,his_user4,his_cpoint,his_cpoint_sub";
                values += "'" + date_start_r2.Value.ToString("yyyy-MM-dd") + "',";
                values += "'" + date_end_r2.Value.ToString("yyyy-MM-dd") + "',";
                values += "'" + (checkBox1.Checked ? "1" : "0") + "',";
                values += "'" + txt_bag.Text.Trim() + "',";
                values += "'" + txt_straps.Text.Trim() + "',";
                values += "'" + txt_bank.Text.Trim() + "',";
                values += "'" + txt_no.Text + "',";
                values += "'" + txt_u1.Text.Trim() + "',";
                values += "'" + txtx_main.Text.Trim() + "',";
                values += "'" + txt_u2.Text.Trim() + "',";
                values += "'" + txt_u3.Text.Trim() + "',";
                values += "'" + mainForm.cpoint_id + "',";
                values += "'" + mainForm.sub_cpoint + "'";

                sql_action = "INSERT INTO tbl_his_report (" + text + ") VALUES (" + values + ")";
                script.InsertUpdae_SQL(sql_action);

                string update_straps_old = "INSERT INTO tbl_straps (tbl_straps_number,tbl_straps_bag,tbl_straps_emp_control,tbl_straps_status,tbl_straps_note,tbl_straps_date) VALUES ('" + txt_straps.Text + "','" + txt_bag.Text + "','" + mainForm.emp_control_id + "','0','สายรัดถุงเงินพิเศษ ผจด.',NOW())";
                script.InsertUpdae_SQL(update_straps_old);
            }
            rs.Close();
            script.conn.Close();

        }

        private void SelectHisReport()
        {
            try
            {
                string sql = "SELECT * FROM tbl_his_report WHERE his_cpoint = '" + mainForm.cpoint_id + "' AND his_cpoint_sub = '" + mainForm.sub_cpoint + "' AND his_s_date = '" + date_start_r2.Value.ToString("yyyy-MM-dd") + "'";
                MySqlDataReader rs = script.Select_SQL(sql);
                if (rs.Read())
                {
                    if (rs.GetString("his_check_extra") == "1") { checkBox1.Checked = true; } else { checkBox1.Checked = false; }
                    txt_straps.Text = rs.GetString("his_straps");
                    txt_bag.Text = rs.GetString("his_bag_extra");
                    txt_bank.Text = rs.GetString("his_bank");
                    txt_no.Text = rs.GetString("his_note_num");
                    txt_u1.Text = rs.GetString("his_user1");
                    txtx_main.Text = rs.GetString("his_user2");
                    txt_u2.Text = rs.GetString("his_user3");
                    txt_u3.Text = rs.GetString("his_user4");
                    script.getEmpName_Group(txt_u1.Text, label_u1);
                    script.getEmpName_Group(txtx_main.Text, label_main);
                    script.getEmpName_Group(txt_u2.Text, label_u2);
                    script.getEmpName_Group(txt_u3.Text, label_u3);
                }
                else
                {
                    checkBox1.Checked = false;
                    txt_straps.Text = "";
                    txt_bag.Text = "";
                    txt_bank.Text = "";
                    txt_no.Text = "";
                    txt_u1.Text = "";
                    txtx_main.Text = "";
                    txt_u2.Text = "";
                    txt_u3.Text = "";
                    label_u1.Text = "";
                    label_main.Text = "";
                    label_u2.Text = "";
                    label_u3.Text = "";
                }
                rs.Close();
                script.conn.Close();
            }
            catch { }
        }


    }
}
