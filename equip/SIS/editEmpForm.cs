using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIS
{
    public partial class editEmpForm : Form
    {
        AdminScript script = new AdminScript();
        public editEmpForm()
        {
            InitializeComponent();
        }

        private void editEmpForm_Load(object sender, EventArgs e)
        {
            
        }

        void getCombobox(ComboBox box)
        {
            box.Items.Clear();
            string sql = "SELECT * FROM tbl_emp_group  ORDER BY tbl_emp_group_id";
            MySqlDataReader reader = script.Select_SQL(sql);
            while (reader.Read())
            {
                box.Items.Add(new ComboboxItem(reader.GetString("tbl_emp_group_name"), reader.GetString("tbl_emp_group_id")));
            }
            reader.Close();
            script.conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            if (textBox1.Text.Trim().Length >=5 && textBox1.Text.Trim().Length <=6)
            {
                MySqlDataReader rs = script.Select_SQL("Select * from tbl_emp e join tbl_emp_group g on g.tbl_emp_group_id = e.tbl_emp_group_id where e.tbl_emp_id = '" + textBox1.Text.Trim()+"'");
                if (rs.Read())
                {
                    groupBox2.Enabled = true;
                    getCombobox(comboBox1);
                    label3.Text = rs.GetString("tbl_emp_id");
                    textBox2.Text = rs.GetString("tbl_emp_name");
                    comboBox1.Text = rs.GetString("tbl_emp_group_name");
                    //(comboBox1.SelectedItem as ComboboxItem).Value.ToString() = rs.GetString("tbl_emp_group_id");
                }
                else
                {
                    groupBox2.Enabled = false;
                    label3.Text = "ไม่พบข้อมูล";
                    textBox2.Text = "ไม่พบข้อมูล";
                    comboBox1.Text = "ไม่พบข้อมูล";
                }
            }
            else
            {
                MessageBox.Show("ใส่รหัสพนักงานไม่ถูกต้อง ลองใหม่อีกครั้ง");
                groupBox2.Enabled = false;
                label3.Text = "ไม่พบข้อมูล";
                textBox2.Text = "ไม่พบข้อมูล";
                comboBox1.Text = "ไม่พบข้อมูล";
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ยืนยันที่จะแก้ไขข้อมูล?", "ยืนยัน?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (textBox2.Text != "" && comboBox1.Text != "")
                {
                    string sql = "UPDATE tbl_emp SET tbl_emp_name = '" + textBox2.Text.Trim() + "',tbl_emp_group_id='" + (comboBox1.SelectedItem as ComboboxItem).Value.ToString() + "' WHERE tbl_emp_id = '" + label3.Text.Trim() + "'";
                    if (script.InsertUpdae_SQL(sql))
                    {
                        MessageBox.Show("แก้ไขข้อมูลสำเร็จ");
                        button3.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("!!!Error : แก้ไขข้อมูล ล้มเหลว ลองใหม่อีกครั้ง", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("ใส่ข้อมูลให้ถูกต้อง", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ยืนยันที่จะส่งข้อมูลไปที่ด่านฯ?", "ยืนยัน?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string data = "";
                string name = "";
                MySqlDataReader rs = script.Select_SQL("SELECT * FROM tbl_cpoint where tbl_cpoint_status = '0' order by tbl_cpoint_id");
                int i = 1;
                while (rs.Read())
                {
                    if (i == 1)
                    {
                        data += rs.GetString("tbl_cpoint_id");
                        name += rs.GetString("tbl_cpoint_name");
                    }
                    else
                    {
                        data += "," + rs.GetString("tbl_cpoint_id");
                        name += "," + rs.GetString("tbl_cpoint_name");
                    }
                    i++;
                }
                rs.Close();
                script.conn.Close();
                string sql = "UPDATE tbl_emp SET tbl_emp_name = '" + textBox2.Text.Trim() + "',tbl_emp_group_id='" + (comboBox1.SelectedItem as ComboboxItem).Value.ToString() + "' WHERE tbl_emp_id = '" + label3.Text.Trim() + "'";
                string[] cpoint = data.Split(',');
                string[] cpointName = name.Split(',');
                for (i = 0; i < cpoint.Length; i++)
                {
                    MySqlConnection conn = script.getConn(cpoint[i]);
                    if (script.InsertUpdae_SQL(sql, conn))
                    {
                        MessageBox.Show("ส่งข้อมูลไปด่านฯ " + cpointName[i] + " สำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("!!!Error : ส่งข้อมูลไปด่านฯ " + cpointName[i] + " ล้มเหลว กรุณาตรวสอบกานเชื่อมต่อ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conn.Close();
                }
            }
        }
    }
}
