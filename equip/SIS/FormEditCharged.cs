using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TIS
{
    public partial class FormEditCharged : Form
    {
        Script script = new Script();
        MenuForm mainForm = null;
        public string Line_1 = "";
        public string Line_2 = "";
        public string Line_3 = "";
        public string Line_4 = "";
        public string[] data = null;
        public FormEditCharged(Form callingForm)
        {
            InitializeComponent();
            mainForm = callingForm as MenuForm;
            //mainForm.Enabled = false;
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void ClearData()
        {
           //cb_emp_name.Items.Clear();
           cb_emp_name.Enabled = false;
            txt_t3_1.Enabled = false;
            txt_t3_2.Enabled = false;
           // txt_t3_3.Enabled = false;
            txt_t3_4.Enabled = false;
        }
        private void date_value_ValueChanged(object sender, EventArgs e)
        {
           // date_value.CustomFormat = "dd-MM-yyyy";
             DateTime d1 = DateTime.ParseExact(date_value.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);

           
            
            cb_emp_name.Enabled = true;
            GetEmp();
           

        }
        private void GetEmp()
        {
            ClearData();
            DateTime date_aroundNext = date_value.Value.AddDays(-1);
            if (cb_emp_name.Text != "เลือก")
            {
                cb_emp_name.Items.Clear();
                
                string date_select = date_value.Text;
                string sql = "SELECT * FROM tbl_incom_other where tbl_incom_other_date_send = '" + date_aroundNext.ToString("dd-MM-yyyy") + "' ";
                //MessageBox.Show(sql);
                ConnectDB contxt = new ConnectDB();
                MySqlConnection conn = new MySqlConnection();
                conn = new MySqlConnection(contxt.context());
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    //cb_emp_name.SelectedIndex = 0;
                    int i = 0;
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            if (i == 0)
                            {
                                cb_emp_name.Text = "เลือกพนักงานที่ทำรายการ";
                                //txt_job.Text = "เลือกงาน";
                            }
                            cb_emp_name.Items.Add(reader.GetString("tbl_incom_other_id") + " : " + reader.GetString("tbl_incom_other_rec"));
                            // cb_emp_name.Items.Add(reader.GetString("tbl_incom_other_rec") );
                            //txt_job.Items.Add(reader.GetString("tbl_income_job"));
                            cb_emp_name.Enabled = true;
                            //txt_job.Enabled = true;
                        }
                        i++;
                    }
                    if (i == 0)
                    {
                        cb_emp_name.Items.Clear();
                        cb_emp_name.Enabled = false;
                    }

                    reader.Close();
                }
                catch
                {

                }
                conn.Close();
            }
        }

        private void FormEditCharged_Load(object sender, EventArgs e)
        {
           


            //   date_value.CustomFormat = "dd-MM-yyyy";


            string cpoint = File.ReadAllText(script.file_cpoint).Split('|')[0];
            date_value.CustomFormat = "dd-MM-yyyy";
            
            ClearData();
            GetEmp();
        }

        private void cb_emp_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearData();
            DateTime date_aroundNext = date_value.Value.AddDays(-1);
            data = cb_emp_name.SelectedItem.ToString().Split(':');
           // string sql = "SELECT * FROM tbl_incom_other where tbl_incom_other_date_send = '" + date_select + "' ";
            string sql = "SELECT * FROM tbl_incom_other WHERE  tbl_incom_other_id = '" + data[0].Trim() + "'  AND tbl_incom_other_date_send = '" + date_aroundNext.ToString("dd-MM-yyyy") + "'";
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

                          Line_1 = reader.GetString("tbl_incom_other_rec");
                          Line_2 = reader.GetString("tbl_incom_other_note");
                          Line_3 = reader.GetString("tbl_incom_other_amount");
                          Line_4 = reader.GetString("tbl_incom_other_id");
                    txt_t3_1.Text = Line_1;
                    txt_t3_2.Text = Line_2;
                    //txt_t3_3.Enabled = false;
                    txt_t3_4.Text = Line_3;

                    txt_t3_1.Enabled = true;
                    txt_t3_2.Enabled = true;
                    txt_t3_4.Enabled = true;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            conn.Close();
        }

        private void txt_t3_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            ConnectDB contxt = new ConnectDB();
            MySqlConnection conn = new MySqlConnection();
            conn = new MySqlConnection(contxt.context());
            MySqlCommand comm = conn.CreateCommand();

            if (txt_t3_1.Text != "")
            {
                if (Int32.Parse(txt_t3_4.Text) >= 0)
                {
                    conn.Open();
                    string sql = "UPDATE tbl_incom_other SET  tbl_incom_other_rec = '" + txt_t3_1.Text + "',tbl_incom_other_note = '" + txt_t3_2.Text + "', tbl_incom_other_amount = '" + txt_t3_4.Text + "' WHERE tbl_incom_other_id = '" + Line_4 + "'";
                    comm.CommandText = sql;
                    comm.ExecuteNonQuery();
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "ผลลัพธ์", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
   
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ตรวจสอบข้อมูลอีกครั้ง!!!!!!!....", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void bn_d_Click(object sender, EventArgs e)
        {
            ConnectDB contxt = new ConnectDB();
            MySqlConnection conn = new MySqlConnection();
            conn = new MySqlConnection(contxt.context());
            MySqlCommand comm = conn.CreateCommand();

            if (txt_t3_1.Text != "")
            {
                if (Int32.Parse(txt_t3_4.Text) >= 0)
                {
                    conn.Open();
                    string sql = "DELETE FROM tbl_incom_other WHERE tbl_incom_other_id =  '" + Line_4 + "'";
                    comm.CommandText = sql;
                    comm.ExecuteNonQuery();
                    MessageBox.Show("ลบข้อมูลเรียบร้อย", "ผลลัพธ์", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("ตรวจสอบข้อมูลอีกครั้ง!!!!!!!....", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
