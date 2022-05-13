using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TIS.Properties;
using System.Globalization;
using System.Threading;
using MySql.Data.MySqlClient;

namespace TIS
{
    public partial class MenuForm : Form
    {
        public bool aroundStatus = false;
        public bool bagStatus = false;
        public string cpoint_id;
        public string sub_cpoint;
        public string emp_control_id = "";
        public string around_num = "";
        public int around = 0;
        int day = 30;
        public string line9 = "7";
        Script script = new Script();
        public MenuForm()
        {
            InitializeComponent();
        }
        public void MenuForm_Load(object sender, EventArgs e)
        {
            label2.Text = "ฝ่ายบริหารจัดเก็บเงินค่าธรรมเนียม กองทางหลวงพิเศษระหว่างเมือง\r\n";
            label2.Text += "Application : " + Application.ProductName;
            label2.Text += "\r\nVersion : " + Application.ProductVersion;
            script.Set_Max_Connection();
            FileInfo DirInfo = new FileInfo(script.file_conf);
            if (!DirInfo.Exists)
            {
                MessageBox.Show("ไม่พบการเชื่อมต่อฐานข้อมูล กรุณา 'ตั้งค่า' ", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //server=localhost;database=testDB;uid=root;pwd=abc123;
                //this.Close();
                btn_around.Enabled = false;
                btn_bag.Enabled = false;
                btn_send.Enabled = false;
                btn_edit.Enabled = false;
                button1.Enabled = false;
                btn_refund.Enabled = false;
                btn_memo.Enabled = false;
                btn_report.Enabled = false;
                btn_setting.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                try
                {
                    /*FileInfo DirInfo1 = new FileInfo(script.file_around);
                    if (!DirInfo1.Exists)
                    {
                        btn_around.Image = Properties.Resources.success;
                        btn_around.Text = "เปิดกะ";
                        aroundStatus = true;
                    }
                    else
                    {
                        btn_around.Image = Properties.Resources.error;
                        btn_around.Text = "ปิดกะ";
                        aroundStatus = false;
                    }*/

                    FileInfo DirInfo2 = new FileInfo(script.file_cpoint);
                    FileInfo DirInfo3 = new FileInfo(script.file_Straps);
                    bool cpoint_file = false;
                    if (DirInfo2.Exists && DirInfo3.Exists)
                    {
                        cpoint_file = true;
                        string[] cpoint = File.ReadAllText(@script.file_cpoint).Split('|');
                        string sql = "SELECT * FROM tbl_cpoint WHERE tbl_cpoint_id =  '" + cpoint[0] + "'";
                        ConnectDB contxt = new ConnectDB();
                        MySqlConnection conn = new MySqlConnection();
                        conn = new MySqlConnection(contxt.context());
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        //conn.Close();
                        conn.Open();
                        MySqlDataReader reader = cmd.ExecuteReader();
                        try
                        {
                            if (reader.Read())
                            {
                                if (!reader.IsDBNull(0))
                                {
                                    line9 = File.ReadAllText(script.file_cpoint).Split('|')[3];
                                    lb_cpoint.Text = cpoint[0] + "  ด่าน" + reader.GetString("tbl_cpoint_name") + " " + (line9 != "9" ? cpoint[1] : "") + "   ";
                                    cpoint_id = cpoint[0];
                                    sub_cpoint = cpoint[1];
                                    lb_time.ForeColor = ColorTranslator.FromHtml(reader.GetString("tbl_cpoint_color"));
                                    groupBox1.ForeColor = ColorTranslator.FromHtml(reader.GetString("tbl_cpoint_color"));
                                    lb_cpoint.ForeColor = ColorTranslator.FromHtml(reader.GetString("tbl_cpoint_color"));
                                    group_around.ForeColor = ColorTranslator.FromHtml(reader.GetString("tbl_cpoint_color"));
                                    lb_emp_name.ForeColor = ColorTranslator.FromHtml(reader.GetString("tbl_cpoint_color"));
                                    label_date.ForeColor = ColorTranslator.FromHtml(reader.GetString("tbl_cpoint_color"));
                                    lb_group.ForeColor = ColorTranslator.FromHtml(reader.GetString("tbl_cpoint_color"));
                                }
                            }
                            else
                            {
                                lb_cpoint.Text = "ไม่พบข้อมูลด่าน";
                                btn_around.Enabled = false;
                            }
                            reader.Close();
                        }
                        catch
                        {

                        }
                        conn.Close();
                    }
                    else
                    {
                        btn_around.Enabled = false;
                        btn_bag.Enabled = false;
                        btn_send.Enabled = false;
                        btn_edit.Enabled = false;
                        btn_report.Enabled = false;
                        btn_refund.Enabled = false;
                        btn_memo.Enabled = false;
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        btn_setting.Enabled = false;

                    }

                    if (cpoint_file)
                    {
                        if (File.ReadAllText(@script.file_cpoint).Split('|')[2] != "1")
                        {
                            /*if (aroundStatus)
                            {
                                btn_bag.Enabled = false;
                                btn_send.Enabled = false;
                                btn_edit.Enabled = false;
                                button1.Enabled = false;
                                group_around.Visible = false;
                                button2.Enabled = false;
                                button3.Enabled = false;
                                btn_report.Enabled = false;
                            }
                            else
                            {*/

                            Script script = new Script();
                            try
                            {
                                string[] around = File.ReadAllText(script.file_around).Split('|');
                                around_num = around[1];
                                //string emp_control = script.Select_SQL();
                                emp_control_id = around[0];
                            }
                            catch { }
                            //around_num = around[1];
                            string sql = "SELECT * FROM tbl_status_around JOIN tbl_emp e ON tbl_status_around_emp_open_id = tbl_emp_id JOIN tbl_emp_group g ON e.tbl_emp_group_id = g.tbl_emp_group_id WHERE tbl_status_around_close = '0' AND tbl_status_around_cpoint_id = '" + cpoint_id + "' AND tbl_status_around_cpoint_sub_id = '" + sub_cpoint + "'";
                            ConnectDB contxt = new ConnectDB();
                            MySqlConnection conn = new MySqlConnection();
                            conn = new MySqlConnection(contxt.context());
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            conn.Open();
                            MySqlDataReader reader = cmd.ExecuteReader();
                            try
                            {
                                if (reader.Read())
                                {
                                    if (!reader.IsDBNull(0))
                                    {
                                        label_date.Text = script.GetMontThai(script.DateTimeParse(reader.GetString("tbl_status_around_date")));
                                        lb_emp_name.Text = reader.GetString("tbl_emp_name");
                                        lb_around_id.Text = reader.GetString("tbl_status_around_id");
                                        label_date.Text += "  " + script.GetAroundName(reader.GetString("tbl_status_around_aid"));
                                        lb_group.Text = reader.GetString("tbl_emp_group_name");
                                        around = int.Parse(reader.GetString("tbl_status_around_aid"));

                                        //string[] aid = File.ReadAllText(@"around.txt").Split('|');
                                        string sql_check_straps = "SELECT * FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_emp` ON `tbl_emp_id` = `tbl_income_emp_id` WHERE tbl_status_around_close = '0' AND tbl_status_around_cpoint_id = '" + cpoint_id + "' AND tbl_status_around_cpoint_sub_id = '" + sub_cpoint + "'";
                                        cmd = new MySqlCommand(sql_check_straps, conn);
                                        reader.Close();
                                        reader = cmd.ExecuteReader();

                                        if (reader.Read())
                                        {
                                            btn_send.Enabled = true;
                                            sql_check_straps = "SELECT * FROM `tbl_income` JOIN `tbl_status_around` ON `tbl_income_around_id` = `tbl_status_around_id` JOIN `tbl_emp` ON `tbl_emp_id` = `tbl_income_emp_id` WHERE tbl_status_around_close = '0' AND tbl_status_around_cpoint_id = '" + cpoint_id + "' AND tbl_status_around_cpoint_sub_id = '" + sub_cpoint + "' AND tbl_income_bank IS NOT NULL AND tbl_income_status_backmaney ='1' ORDER BY tbl_income_id DESC ";
                                            reader.Close();
                                            reader = script.Select_SQL(sql_check_straps);
                                            if (reader.Read())
                                            {
                                                button2.Enabled = true;
                                                btn_edit.Enabled = true;
                                            }
                                            else
                                            {
                                                button2.Enabled = false;
                                                btn_edit.Enabled = false;
                                            }
                                        }
                                        else
                                        {
                                            button2.Enabled = false;
                                            btn_send.Enabled = false;
                                            btn_edit.Enabled = false;
                                        }
                                        conn.Close();
                                        group_around.Visible = true;
                                        btn_around.Image = Resources.error;
                                        btn_around.Text = "ปิดกะ";
                                        aroundStatus = false;

                                        if (around == 2)
                                        {
                                            button1.Enabled = true;
                                        }
                                        else
                                        {
                                            button1.Enabled = false;
                                        }
                                    }


                                }
                                else
                                {
                                    //lb_cpoint.Text = "ไม่พบข้อมูลด่าน";
                                    group_around.Visible = false;
                                    btn_around.Image = Resources.success;
                                    btn_around.Text = "เปิดกะ";
                                    aroundStatus = true;

                                    btn_around.Enabled = true;
                                    btn_bag.Enabled = false;
                                    btn_send.Enabled = false;
                                    btn_edit.Enabled = false;
                                    btn_report.Enabled = false;
                                    btn_refund.Enabled = false;
                                    btn_memo.Enabled = false;
                                    button1.Enabled = false;
                                    button2.Enabled = false;
                                    button3.Enabled = false;
                                    btn_setting.Enabled = false;
                                }

                            }
                            catch
                            {

                            }
                            conn.Close();
                            // }
                            //button1.Enabled = false;
                        }
                        else
                        {
                            btn_around.Enabled = false;
                            btn_bag.Enabled = false;
                            btn_send.Enabled = false;
                            btn_edit.Enabled = false;
                            btn_report.Enabled = true;
                            btn_refund.Enabled = false;
                            btn_memo.Enabled = false;
                            button1.Enabled = true;
                            button2.Enabled = false;
                            button3.Enabled = false;
                            btn_setting.Enabled = false;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("มีปัญหาการเชื่อมต่อฐานข้อมูล กรุุณาปิด/เปิดโปรแกรมใหม่ "+e.ToString(), "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show("Error:" + err.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }

        }

        private void btn_around_Click(object sender, EventArgs e)
        {
            check_conn();
            if (btn_around.Text == "เปิดกะ")
            {
                string around = "";
                if (DateTime.Now.TimeOfDay >= DateTime.ParseExact("06:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay && DateTime.Now.TimeOfDay < DateTime.ParseExact("14:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay)
                {
                    around = "2";
                }
                if (DateTime.Now.TimeOfDay >= DateTime.ParseExact("14:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay && DateTime.Now.TimeOfDay < DateTime.ParseExact("22:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay)
                {
                    around = "3";
                }
                if ((DateTime.Now.TimeOfDay >= DateTime.ParseExact("22:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay && DateTime.Now.TimeOfDay < DateTime.ParseExact("23:59:59", "HH:mm:ss", CultureInfo.InvariantCulture).TimeOfDay))
                {
                    around = "1";
                    //MessageBox.Show(around);
                }
                if ((DateTime.Now.TimeOfDay >= DateTime.ParseExact("00:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay && DateTime.Now.TimeOfDay < DateTime.ParseExact("06:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay))
                {
                    around = "1";
                    //MessageBox.Show(around);
                }

                //IndexForm formMain = new IndexForm();
                string check_around_open = "SELECT* FROM tbl_status_around WHERE tbl_status_around_aid = '" + around + "' AND `tbl_status_around_date` = '" + script.GetDateAround(int.Parse(around)).ToString("dd-MM-yyyy") + "' AND `tbl_status_around_cpoint_id` = '" + cpoint_id + "' AND `tbl_status_around_cpoint_sub_id` = '" + sub_cpoint + "' ";
                MySqlDataReader rs = script.Select_SQL(check_around_open);
                if (rs.Read())
                {
                    MessageBox.Show("ขณะนี้เวลา " + DateTime.Now.ToString("HH:mm") + " น. มีข้อมูลเปิดกะที่ " + around + " ด่าน" + script.GetCpoint(cpoint_id) + " " + sub_cpoint + " ในระบบแล้ว ไม่อนุญาติให้มีการเปิดกะซ้ำ", "เปิดกะ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    AroundForm form = new AroundForm(this, cpoint_id);
                    form.ShowDialog();
                }
            }
            else
            {
                string around = "";
                if (DateTime.Now.TimeOfDay >= DateTime.ParseExact("06:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay && DateTime.Now.TimeOfDay < DateTime.ParseExact("14:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay)
                {
                    around = "2";
                }
                if (DateTime.Now.TimeOfDay >= DateTime.ParseExact("14:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay && DateTime.Now.TimeOfDay < DateTime.ParseExact("22:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay)
                {
                    around = "3";
                }
                if ((DateTime.Now.TimeOfDay >= DateTime.ParseExact("22:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay && DateTime.Now.TimeOfDay < DateTime.ParseExact("00:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay) || (DateTime.Now.TimeOfDay >= DateTime.ParseExact("00:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay && DateTime.Now.TimeOfDay < DateTime.ParseExact("06:00", "HH:mm", CultureInfo.InvariantCulture).TimeOfDay))
                {
                    around = "1";
                }

                if (around_num != around)
                {
                    string sql = "SELECT * FROM tbl_income JOIN tbl_status_around ON tbl_income_around_id = tbl_status_around_id WHERE tbl_status_around_emp_open_id = '" + emp_control_id + "' AND tbl_income_status_job = '0' AND tbl_status_around_cpoint_sub_id = '"+ sub_cpoint + "'";
                    MySqlDataReader rs = script.Select_SQL(sql);
                    if (!rs.Read())
                    {
                        rs.Close();
                        string date = DateTime.Now.ToString("dd-MM-yyyy");
                        bool check_status = true;
                        string sql_check = "SELECT * FROM tbl_incom_other WHERE tbl_incom_other_date_send ='" + date + "' AND (tbl_incom_other_list_incom_id = 3 OR tbl_incom_other_list_incom_id = 2)";
                        MySqlDataReader reader = script.Select_SQL(sql_check);
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                check_status = false;
                            }
                        }
                        reader.Close();
                        script.conn.Close();
                        if (check_status)
                        {
                            ConfirmCloseAroundForm confirmClose = new ConfirmCloseAroundForm();
                            confirmClose.ShowDialog();
                            if (confirmClose.comfirmClose)
                            {
                                AroundCloseForm closeAround = new AroundCloseForm(this);
                                closeAround.ShowDialog();
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("ยังมีพนักงานปฏิบัติงานอยู่ไม่สามารถปิดกะได้", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else
                {
                    MessageBox.Show("ขณะนี้เวลา " + DateTime.Now.ToString("HH:mm") + " น. ไม่สามารถปิดกะได้ เนื่องจาก อยุ่ในช่วงเวลาทำงาน"/*+around+"  "+around_num*/, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void btn_bag_Click(object sender, EventArgs e)
        {
            check_conn();
            MoneybagForm getBagForm = new MoneybagForm(this, cpoint_id , sub_cpoint);
            getBagForm.ShowDialog();
            //this.Enabled = false;
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            check_conn();
            EmpSendMoneyForm sendForm = new EmpSendMoneyForm(this);
            sendForm.ShowDialog();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            check_conn();
            EmpToEditMoneyForm editMoneyForm = new EmpToEditMoneyForm(this);
            editMoneyForm.ShowDialog();
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            //check_conn();
            ConfirmSubmit confirm = new ConfirmSubmit(this);
            confirm.ShowDialog();
            if (confirm.ReturnForm)
            {
                SettingForm form = new SettingForm(this);
                form.ShowDialog();
                //this.Enabled = false;
            }
        }

        private void timer_show_Tick(object sender, EventArgs e)
        {
            lb_time.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            check_conn();
            /*ReportViweForm reportViweForm = new ReportViweForm(this);
            reportViweForm.ShowDialog();*/
            PrintReportForm printReport = new PrintReportForm(this);
            printReport.ShowDialog();
        }

        private void btn_refund_Click(object sender, EventArgs e)
        {
            check_conn();
            RefunForm refunForm = new RefunForm(this);
            refunForm.ShowDialog();
        }

        private void check_conn()
        {
            FileInfo DirInfo = new FileInfo(script.file_conf);
            if (!DirInfo.Exists)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChargedForm chargedForm = new ChargedForm(this);
            chargedForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            EditStrapsEmpForm editStraps = new EditStrapsEmpForm(this);
            editStraps.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BagNextTimeForm bagNextTime = new BagNextTimeForm();
            bagNextTime.ShowDialog();
        }

        private void MenuForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void btn_around_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Shift)
            {
                //Show the form
                if (btn_setting.Enabled)
                {
                    btn_setting.Enabled = false;
                }
                else
                {
                    btn_setting.Enabled = true;
                    // btn_setting.Visible = true;
                    btn_setting_Click(null, null);
                }

            }
            if (e.KeyCode == Keys.P && e.Modifiers == Keys.Shift)
            {
                if (btn_report.Enabled)
                {
                    btn_report.Enabled = true;
                }
                else
                {
                    btn_report.Enabled = true;
                    // btn_setting.Visible = true;
                    //btn_setting_Click(null, null);
                }

            }
        }

        private void btn_memo_Click(object sender, EventArgs e)
        {
            MemoFrom memo = new MemoFrom();
            memo.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Interaction.InputBox("ใส่หมายเลขสายรัดเริ่มต้น", "เปลี่ยนหมายเลขสายรัดเริ่มต้น", File.ReadAllText(script.file_around).Split('|')[3],-1,6);
        }

        private void btn_edit_jon_Click(object sender, EventArgs e)
        {
            EditJobForm editJob = new EditJobForm(this);
            editJob.ShowDialog();
        }

        private void btn_edit_jon_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            btn_around_PreviewKeyDown_1(sender, e);
        }

        private void btn_memo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            btn_around_PreviewKeyDown_1(sender, e);
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://192.168.101.91:90/webboard/viewforum.php?f=3&sid=5760233e446e6b3eede6893ac6359e23");
        }

        private void button4_Click(object sender, EventArgs e)
        {
              EditControlAround editAround = new EditControlAround(int.Parse(lb_around_id.Text));
               editAround.ShowDialog();
            
        }
    }
}
