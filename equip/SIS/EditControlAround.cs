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

namespace TIS
{
    public partial class EditControlAround : Form
    {
        int around_open_id;
        Script script = new Script();
        public EditControlAround(int around_id)
        {
            around_open_id = around_id;
            InitializeComponent();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
          

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
           
        }

        private void txt_emp_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_next_Click(null, null);
            }
        }

        private void txt_emp_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script scriptCode = new Script();
            scriptCode.CheckNumber(e);
        }

        private void btn_back_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_next_Click_1(object sender, EventArgs e)
        {
            ConnectDB contxt = new ConnectDB();
            MySqlConnection conn = new MySqlConnection();
            conn = new MySqlConnection(contxt.context());
            MySqlCommand cmd;
            string sql = "SELECT * FROM tbl_emp WHERE tbl_emp_id = '" + txt_emp_id.Text + "' AND (tbl_emp_group_id=3 OR tbl_emp_group_id=7 OR tbl_emp_group_id=4 OR tbl_emp_group_id=10 OR tbl_emp_group_id=11 OR tbl_emp_group_id > 10)";
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        reader.Close();
                        string sql_update = "UPDATE tbl_status_around SET tbl_status_around_emp_open_id = '" + txt_emp_id.Text.Trim() + "' WHERE tbl_status_around_id = '" + around_open_id + "'";
                        if (script.InsertUpdae_SQL(sql_update))
                        {
                            sql = "SELECT * FROM tbl_status_around WHERE tbl_status_around_id = '" + around_open_id + "'";
                            cmd = new MySqlCommand(sql, conn);
                            //MessageBox.Show(sql);
                            reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                string straps = File.ReadAllText(script.file_around).Split('|')[3];
                                StreamWriter file = new StreamWriter(script.file_around);
                                file.WriteLine(txt_emp_id.Text.Trim() + "|" + reader.GetString("tbl_status_around_aid") + "|" + reader.GetString("tbl_status_around_date") + "|" + straps + "|");
                                file.Close();
                                MessageBox.Show("เรียบร้อย", "ผลลัพธ์", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Application.Restart();
                            }
                            else
                            {
                                MessageBox.Show("Error : ล้มเหลว", "ผลลัพธ์", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            reader.Close();

                        }
                        else
                        {
                            MessageBox.Show("Error : ล้มเหลว", "ผลลัพธ์", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัส : " + txt_emp_id.Text + "  ในระบบ หรือรหัสนี้ไม่มีสิทธ์เปิดกะ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_emp_id.Clear();
                    txt_emp_id.Focus();
                }
                conn.Close();
            }
            catch
            {
                //MessageBox.Show(e.ToString());
                conn.Close();
            }
        }
    }
}
