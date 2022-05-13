using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace TIS
{
    public partial class AroundForm : Form
    {
        MenuForm mainForm = null;
        string cpoint_id;
        public AroundForm(Form callingForm,string cpoint)
        {
            mainForm = callingForm as MenuForm;
            InitializeComponent();
            cpoint_id = cpoint;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.Enabled = true;
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            next();
        }

        private void next()
        {
            if (txt_emp_id.Text != "")
            {
                string emp_id = null;
                string sql = "SELECT * FROM tbl_emp WHERE tbl_emp_id = '" + txt_emp_id.Text + "' AND (tbl_emp_group_id=3 OR tbl_emp_group_id=7 OR tbl_emp_group_id=4 OR tbl_emp_group_id=10 OR tbl_emp_group_id=11 OR tbl_emp_group_id > 10)";

                ConnectDB contxt = new ConnectDB();
                MySqlConnection conn = new MySqlConnection();
                conn = new MySqlConnection(contxt.context());
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MessageBox.Show(sql);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            emp_id = reader.GetString("tbl_emp_id");
                            AroundOpenForm form = new AroundOpenForm(emp_id, mainForm,cpoint_id);
                            form.ShowDialog();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบรหัส : " + txt_emp_id.Text + "  ในระบบ หรือรหัสนี้ไม่มีสิทธ์เปิดกะ","แจ้งเตือน",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        txt_emp_id.Clear();
                        txt_emp_id.Focus();
                    }
                    reader.Close();
                }
                catch
                {
                    //MessageBox.Show(e.ToString());
                }
                conn.Close();

            }
            else
            {
                MessageBox.Show("กรุณาใส่รหัสูผ้เปิดผลัด", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_emp_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                next();
            }
        }

        private void AroundForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                next();
            }
        }

        private void txt_emp_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            Script scriptCode = new Script();
            scriptCode.CheckNumber(e);
        }
    }
}
