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
    public partial class EmpOverMoneyForm : Form
    {
        MenuForm mainForm = null;
        Script script = new Script();
        string emp_id = "";
        string emp_name = "";
        string income_bank = "";
        string income_id = "";
        public EmpOverMoneyForm(Form callForm,string eID,string eName,string iBank,string iID)
        {
            mainForm = callForm as MenuForm;
            emp_id = eID;
            emp_name = eName;
            income_bank = iBank;
            income_id = iID;
            InitializeComponent();
        }

        private void EmpOverMoneyForm_Load(object sender, EventArgs e)
        {
            txt_emp_name.Text = emp_name;
            txt_emp_id.Text = emp_id;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if(txt_over.Text != "")
            {

                string sql = "UPDATE tbl_income SET tbl_income_over='"+ double.Parse(txt_over.Text.Trim()) + "' WHERE tbl_income_id = '"+income_id+"'";
                if (script.InsertUpdae_SQL(sql))
                {
                    MessageBox.Show("บันทึกข้อมูลสำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("กรุณาใส่จำนวนเงินเกินบัญชี", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_over_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_over.Text, out value))
                txt_over.Text = String.Format("{0:N2}", value);
            else
                txt_over.Text = String.Empty;
        }
    }
}
