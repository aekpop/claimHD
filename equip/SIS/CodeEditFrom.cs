using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace TIS
{
    public partial class CodeEditFrom : Form
    {
        AdminScript adminScript = new AdminScript();
        public CodeEditFrom()
        {
            InitializeComponent();
        }

        private void CodeEditFrom_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection();
            conn = new MySqlConnection(adminScript.strCon);
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT tbl_code_name AS 'รหัสแก้ไขงาน' FROM tbl_code_edit WHERE tbl_code_status IS NULL", conn);
            conn.Open();
            da.Fill(ds, "tbl_code_edit");
            conn.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tbl_code_edit";
            //dataGridView1.data adminScript.GetCodeEdit("SELECT tbl_code_name FROM tbl_code_edit WHERE tbl_code_status IS NULL");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ยืนยัน", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string code = adminScript.RandomString(6);
                int i = 0;
                while (i < 10)
                {
                    string sql = "SELECT tbl_code_name FROM tbl_code_edit WHERE tbl_code_name='" + code + "'";
                    MySqlDataReader rs = adminScript.GetCodeEdit(sql);
                    if (!rs.Read())
                    {
                        adminScript.InsertUpdaeCodeEdit("Insert into tbl_code_edit (tbl_code_name) Values ('" + code + "')");
                        i++;
                    }
                    else
                    {
                        code = adminScript.RandomString(6);
                    }

                }
                if (i == 10)
                {
                    MessageBox.Show("เรียบร้อย");
                    this.Close();
                }
            }
        }
    }
}
