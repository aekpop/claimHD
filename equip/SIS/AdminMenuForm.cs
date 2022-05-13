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
    public partial class AdminMenuForm : Form
    {
        Script script = new Script();
        AdminScript adminScript = new AdminScript();
        string codeEdit = "";
        public AdminMenuForm(string code)
        {
            codeEdit = code;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFile_1.ShowDialog() == DialogResult.OK)
            {
                StreamReader file = new StreamReader(openFile_1.FileName);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    string sql = "UPDATE `tbl_emp` SET `tbl_emp_group_id` = '" + data[1] + "' WHERE `tbl_emp_id` = '" + data[0] + "'";
                    if (!script.InsertUpdae_SQL(sql))
                    {
                        MessageBox.Show("ผิดพลาด"+ data[0], "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                MessageBox.Show("สำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminEditForm editForm = new AdminEditForm(codeEdit);
            editForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DefectiveFrom defective = new DefectiveFrom();
            defective.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CodeEditFrom codeEditFrom = new CodeEditFrom();
            codeEditFrom.ShowDialog();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            BagClearForm clearForm = new BagClearForm(codeEdit);
            clearForm.ShowDialog();
        }

        private void AdminMenuForm_Load(object sender, EventArgs e)
        {
            if (codeEdit != "")
            {
                button5.Visible = false;
                button1.Visible = false;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
