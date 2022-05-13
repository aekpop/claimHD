using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TIS
{
    public partial class GetEmpConfirmForm : Form
    {
        public string emp_id { get; set; }
        public bool checkValue { get; set; }

        Script script = new Script();
        public GetEmpConfirmForm()
        {
            InitializeComponent();
        }

        private void GetEmpConfirmForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_emp_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                next();
            }
        }

        private void txt_emp_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            script.CheckNumber(e);
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            next();
        }

        private void txt_emp_id_TextChanged(object sender, EventArgs e)
        {

        }
         private void next()
        {
            if (txt_emp_id.Text != "")
            {
                string sql = "SELECT * FROM tbl_emp WHERE tbl_emp_id = '" + txt_emp_id.Text + "' AND (tbl_emp_group_id=3 OR tbl_emp_group_id=7 OR tbl_emp_group_id=4 OR tbl_emp_group_id=10 OR tbl_emp_group_id=11)";
                MySqlDataReader rs = script.Select_SQL(sql);
                if (rs.Read())
                {
                    emp_id = rs.GetString("tbl_emp_id");
                    checkValue = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัส : " + txt_emp_id.Text + "  ในระบบ หรือรหัสนี้ไม่มีสิทธ์บันทึก", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    emp_id = null;
                    checkValue = false;
                    this.Close();
                }
                rs.Close();
                script.conn.Close();
            }
        }
    }
}
