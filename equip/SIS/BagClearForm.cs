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
    public partial class BagClearForm : Form
    {
        Script script = new Script();
        AdminScript adminScript = new AdminScript();
        string codeEdit = "";
        string cpoint = "";
        public BagClearForm(string code)
        {
            codeEdit = code;
            InitializeComponent();
        }

        private void BagClearForm_Load(object sender, EventArgs e)
        {
            getCombobox(txtCpoint);
            button1.Enabled = false;
            ListBoxEmp.Enabled = false;
            if (codeEdit!="")
            {
                //MessageBox.Show(File.ReadAllText(script.file_cpoint).Split('|')[0]);
                cpoint = File.ReadAllText(script.file_cpoint).Split('|')[0];
                button2_Click(null, null);
                groupBox1.Enabled = false;
            }
        }

        void getCombobox(ComboBox box)
        {
            box.Items.Clear();
            string sql = "SELECT * FROM tbl_cpoint WHERE tbl_cpoint_id <> '700' AND tbl_cpoint_id <> '705' AND tbl_cpoint_id <> '901' ORDER BY tbl_cpoint_id";
            MySqlDataReader reader = script.Select_SQL(sql);
            while (reader.Read())
            {
                box.Items.Add(new ComboboxItem(reader.GetString("tbl_cpoint_name"), reader.GetString("tbl_cpoint_id")));
            }
            reader.Close();
            script.conn.Close();
        }

        private void txtCpoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tbl_income JOIN tbl_emp ON tbl_income_emp_id=tbl_emp_id WHERE tbl_income_around_id IS NULL";
            //MessageBox.Show(txtCpoint.SelectedItem.ToString());
            if (codeEdit == "")
            {
                cpoint = (txtCpoint.SelectedItem as ComboboxItem).Value.ToString();
            }
            MySqlDataReader rs = adminScript.Select_SQL(sql, adminScript.getConn(cpoint, groupBox1));
            ListBoxEmp.Items.Clear();
            int i = 0;
            while (rs.Read())
            {
                ListBoxEmp.Items.Insert(i,new ComboboxItem("ถุงเงิน : "+ rs.GetString("tbl_income_money_bag") +" ชื่อ-สกุล : "+rs.GetString("tbl_emp_name"), rs.GetString("tbl_income_id")));
                i++;
            }
            rs.Close();
            adminScript.CloseCon();
            button1.Enabled = true;
            ListBoxEmp.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("ยืนยันลบข้อมูลการเบิกถุงเงิน","",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    for (int i = 0; i < ListBoxEmp.CheckedItems.Count; i++)
                    {
                        //MessageBox.Show((ListBoxEmp.CheckedItems[i] as ComboboxItem).Value.ToString());
                        string sql = "DELETE FROM tbl_income WHERE tbl_income_id = '" + (ListBoxEmp.CheckedItems[i] as ComboboxItem).Value.ToString() + "'";
                        adminScript.InsertUpdae_SQL(sql, adminScript.getConn(cpoint, groupBox1));
                    }

                    if (codeEdit != "")
                    {
                        adminScript.InsertUpdaeCodeEdit("UPDATE tbl_code_edit SET tbl_code_status='1',tbl_code_date= NOW() where tbl_code_name = '" + codeEdit + "'");
                    }
                    MessageBox.Show("ลบข้อมูลการเบิกถุงเงินเรียบร้อยแล้ว","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    button2_Click(null, null);
                }
                catch
                {
                    MessageBox.Show("ลบข้อมูลการเบิกถุงเงิน ล้มเหลว!!!!!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
