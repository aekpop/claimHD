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
    public partial class AddBagForm : Form
    {
        string income_id = "";
        Script script = new Script();
        public AddBagForm(string inc_id)
        {
            income_id = inc_id;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "ยืนยัน")
            {
                string sql_insert = "INSERT INTO tbl_income (tbl_income_money_bag,tbl_income_straps,tbl_income_around_id,tbl_income_status_job) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + income_id + "','1')";
                script.InsertUpdae_SQL(sql_insert);
                this.Close();
            }
            else
            {
                button1.Text = "ยืนยัน";
                groupBox1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
    }
}
