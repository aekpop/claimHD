using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace TIS
{
    public partial class AdminEditForm : Form
    {
        AdminScript script = new AdminScript();
        Script GetScript = new Script();
        string cpoint = "";
        string codeEdit = "";
        //double total_tmp = 0;
        double chang_tmp = 0;
        double fine_tmp = 0;
        double bank_tmp = 0;
        public AdminEditForm(string code)
        {
            codeEdit = code;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Split('-').Length == 2)
            {
                string sql = "SELECT * FROM tbl_income i JOIN tbl_status_around a ON i.tbl_income_around_id = a.tbl_status_around_id WHERE tbl_income_id = '" + textBox1.Text.Split('-')[1].Trim() + "' limit 1";
                cpoint = textBox1.Text.Split('-')[0];
                MySqlDataReader rs = script.Select_SQL(sql, script.getConn(cpoint, groupbox1));
                GetData(rs);
            }
            else
            {
                MessageBox.Show("รูปแบบไม่ถูกต้อง", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetData(MySqlDataReader rscall)
        {
            MySqlDataReader rs = rscall;
            if (rs.Read())
            {
                lb_income_id.Text = rs.GetString("tbl_income_id");
                income_around_id.Text = rs.GetString("tbl_income_around_id");
                lb_emp_control.Text = "รองฯ : " + rs.GetString("tbl_status_around_emp_open_id");
                lb_around.Text = "ผลัดที่ : " + rs.GetString("tbl_status_around_aid");
                lb_date.Text = "วันที่ : " + rs.GetString("tbl_status_around_date");

                try { txt_emp_id.Text = rs.GetString("tbl_income_emp_id"); } catch { txt_emp_id.Text = null; }
                try { txt_cb.Text = rs.GetString("tbl_income_cabinet"); } catch { txt_cb.Text = null; }
                try { txt_start.Text = rs.GetString("tbl_income_in_time"); } catch { txt_start.Text = null; }
                try { txt_end.Text = rs.GetString("tbl_income_out_time"); } catch { txt_end.Text = null; }
                try { txt_bag.Text = rs.GetString("tbl_income_money_bag"); } catch { txt_bag.Text = null; }
                try { txt_job.Text = rs.GetString("tbl_income_job"); } catch { txt_job.Text = null; }
                try { txt_straps.Text = rs.GetString("tbl_income_straps"); } catch { txt_straps.Text = null; }

                try { txt_bank.Text = rs.GetDouble("tbl_income_bank").ToString("#,##0.00"); } catch { txt_bank.Text = null; }
                try { txt_total.Text = rs.GetDouble("tbl_income_total").ToString("#,##0.00"); } catch { txt_total.Text = null; }

                try { txt_user.Text = rs.GetString("tbl_income_user"); } catch { txt_user.Text = null; }
                try { txt_fine.Text = rs.GetString("tbl_income_fine"); } catch { txt_fine.Text = null; }

                try { txt_over_ts2.Text = rs.GetString("tbl_income_over") != null ? rs.GetString("tbl_income_over") : ""; } catch { txt_over_ts2.Text = null; }
                try { txt_over_sys.Text = rs.GetString("tbl_income_over_sys") != null ? rs.GetString("tbl_income_over_sys") : ""; } catch { txt_over_sys.Text = null; }

                try { txt_other_ts2.Text = rs.GetString("tbl_income_other_ts2") != null ? rs.GetString("tbl_income_other_ts2") : ""; } catch { txt_other_ts2.Text = null; }
                try { txt_other_sys.Text = rs.GetString("tbl_income_other") != null ? rs.GetString("tbl_income_other") : ""; } catch { txt_other_sys.Text = null; }

                groupbox1.Enabled = true;
                btn_confirm.Enabled = true;
                txt_emp_name.Text = GetScript.GetEmpName(txt_emp_id.Text);
                lb_emp_control.Text += "  " + GetScript.GetEmpName(lb_emp_control.Text.Split(':')[1].Trim());
                lb_around.Text = GetScript.GetAroundName(lb_around.Text.Split(':')[1].Trim());
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูล", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                groupbox1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (combo_cpoint.Text != "เลือกด่านฯ")
            {
                string sql = "SELECT * FROM tbl_income i JOIN tbl_status_around a ON i.tbl_income_around_id = a.tbl_status_around_id WHERE a.tbl_status_around_date = '" + date_value_s.Text + "' AND (i.tbl_income_emp_id Like '%" + txt_emp_s.Text + "%' OR i.tbl_income_emp_id is null) AND (i.tbl_income_cabinet Like '%" + txt_cb_s.Text + "%' OR i.tbl_income_cabinet is null) AND i.tbl_income_money_bag Like'%" + txt_bag_s.Text + "%' ";
                if (txt_straps_s.Text != "")
                {
                    sql += "AND i.tbl_income_straps LIKE '%" + txt_straps_s.Text + "%'";
                }
                cpoint = (combo_cpoint.SelectedItem as ComboboxItem).Value.ToString();
                MySqlDataReader rs = script.Select_SQL(sql, script.getConn(cpoint, groupbox1));
                GetData(rs);
            }
            else
            {
                MessageBox.Show("กรุณาเลือกด่านฯ", "",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                combo_cpoint.Focus();
            }
        }



        private void txt_emp_send_KeyPress(object sender, KeyPressEventArgs e)
        {
            GetScript.CheckNumber(e);
        }

        private void txt_ts2_KeyPress(object sender, KeyPressEventArgs e)
        {
            GetScript.CheckNumber(e);
        }

        private void txt_sys_KeyPress(object sender, KeyPressEventArgs e)
        {
            GetScript.CheckNumber(e);
        }
        private void CalculateIncome()
        {
            try
            {
                bank_tmp = double.Parse(txt_bank.Text == "" ? "0" : txt_bank.Text);
                CalculateTotal();


            }
            catch { }
        }
        private void CalculateTotal()
        {
            try
            {
               // bank_tmp = double.Parse(txt_bank.Text);

               // txt_bank.Text = bank_tmp.ToString("#,##0.00");
                txt_total.Text = (double.Parse(txt_fine.Text) + double.Parse(txt_user.Text) + double.Parse(txt_bank.Text)).ToString("#,##0.00");
            }
            catch { }
        }

        private void txt_user_KeyUp_2(object sender, KeyEventArgs e)
        {
            try
            {
                
                CalculateIncome();
            }
            catch { }
        }
        private void txt_bank_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                CalculateIncome();
            }
            catch { }
        }
        private void txt_bank_KeyPress(object sender, KeyPressEventArgs e)
        {
            CalculateIncome();
        }

        private void txt_total_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void txt_fine_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {
                CalculateIncome();
            }
            catch { }
        }

        private void txt_total_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                CalculateIncome();
            }
            catch { }
        }
        private void txt_user_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                CalculateIncome();
            }
            catch { }
        }

        private void txt_user_KeyPress(object sender, KeyPressEventArgs e)
        {
            GetScript.CheckNumber(e);
        }

        private void txt_fine_KeyPress(object sender, KeyPressEventArgs e)
        {
            GetScript.CheckNumber(e);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void AdminEditForm_Load(object sender, EventArgs e)
        {
            getCombobox(combo_cpoint);
            date_value_s.CustomFormat = "dd-MM-yyyy";
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
        private void txt_emp_id_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_emp_id.Text.Length > 1)
            {
                GetScript.GetEmpName(txt_emp_id.Text);
                txt_emp_name.Text = GetScript.GetEmpName(txt_emp_id.Text);
            }
        }

        private void txt_emp_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            GetScript.CheckNumber(e);
        }

        private void txt_over_ts2_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_over_ts2.Text, out value))
                txt_over_ts2.Text = String.Format("{0:N2}", value);
            else
                txt_over_ts2.Text = String.Empty;
        }

        private void txt_over_sys_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_over_sys.Text, out value))
                txt_over_sys.Text = String.Format("{0:N2}", value);
            else
                txt_over_sys.Text = String.Empty;
        }

        private void txt_other_ts2_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_other_ts2.Text, out value))
                txt_other_ts2.Text = String.Format("{0:N2}", value);
            else
                txt_other_ts2.Text = String.Empty;
        }

        private void txt_other_sys_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_other_sys.Text, out value))
                txt_other_sys.Text = String.Format("{0:N2}", value);
            else
                txt_other_sys.Text = String.Empty;
        }

        private void txt_user_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_user.Text, out value))
                txt_user.Text = String.Format("{0:N2}", value);
            else
                txt_user.Text = String.Empty;
        }

        private void txt_fine_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_fine.Text, out value))
                txt_fine.Text = String.Format("{0:N2}", value);
            else
                txt_fine.Text = String.Empty;
        }

        private void txt_bank_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_bank.Text, out value))
                txt_bank.Text = String.Format("{0:N2}", value);
            else
                txt_bank.Text = String.Empty;
        }

        private void txt_total_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(txt_total.Text, out value))
                txt_total.Text = String.Format("{0:N2}", value);
            else
                txt_total.Text = String.Empty;
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ยืนยันบันทึกข้อมูลใช้หรือไม่", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string insert_sql = "UPDATE tbl_income SET tbl_income_money_bag ='" + txt_bag.Text + "'";
                if (txt_straps.Text != "") { insert_sql += ",tbl_income_straps ='" + txt_straps.Text + "'"; }
                if (txt_emp_id.Text != "") { insert_sql += ",tbl_income_emp_id ='" + txt_emp_id.Text + "'"; }
                if (txt_cb.Text != "") { insert_sql += ",tbl_income_cabinet ='" + txt_cb.Text + "'"; }
                if (txt_job.Text != "") { insert_sql += ",tbl_income_job ='" + txt_job.Text + "'"; }

                if (txt_start.Text != "  :") { insert_sql += ",tbl_income_in_time ='" + txt_start.Text + "'"; }
                if (txt_end.Text != "  :") { insert_sql += ",tbl_income_out_time ='" + txt_end.Text + "'"; }

                if (txt_total.Text != "") { insert_sql += ",tbl_income_total ='" + double.Parse(txt_total.Text) + "'"; }
                if (txt_bank.Text != "") { insert_sql += ",tbl_income_bank ='" + double.Parse(txt_bank.Text) + "'"; }
                if (txt_user.Text != "") { insert_sql += ",tbl_income_user ='" + double.Parse(txt_user.Text) + "',tbl_income_user_tmp ='" + double.Parse(txt_user.Text) + "'"; }
                if (txt_fine.Text != "") { insert_sql += ",tbl_income_fine ='" + double.Parse(txt_fine.Text) + "',tbl_income_fine_tmp ='" + double.Parse(txt_fine.Text) + "'"; }
                if (txt_over_ts2.Text != "") { insert_sql += ",tbl_income_over ='" + double.Parse(txt_over_ts2.Text) + "'"; }
                if (txt_over_sys.Text != "") { insert_sql += ",tbl_income_over_sys ='" + double.Parse(txt_over_sys.Text) + "'"; }
                if (txt_other_ts2.Text != "") { insert_sql += ",tbl_income_other_ts2 ='" + double.Parse(txt_other_ts2.Text) + "'"; }
                if (txt_other_sys.Text != "") { insert_sql += ",tbl_income_other ='" + double.Parse(txt_other_sys.Text) + "' "; }
                insert_sql += " WHERE tbl_income_id = '" + lb_income_id.Text + "'";

                if (codeEdit != "")
                {
                    script.InsertUpdaeCodeEdit("UPDATE tbl_code_edit SET tbl_code_status='1',tbl_code_date= NOW() where tbl_code_name = '" + codeEdit + "'");
                }

                if (script.InsertUpdae_SQL(insert_sql, script.getConn(cpoint, groupbox1)))
                {

                    MySqlDataReader rs = GetScript.Select_SQL("SELECT * FROM tbl_income WHERE tbl_income_around_id = '" + income_around_id.Text.Trim() + "' AND tbl_income_emp_id IS NULL");
                    if (!rs.Read())
                    {
                        rs.Close();
                        script.CloseCon();

                        if (txt_other_ts2.Text != "" && txt_other_sys.Text != "" && txt_other_ts2.Text != "0" && txt_other_sys.Text != "0")
                        {
                            AddBagForm addBag = new AddBagForm(income_around_id.Text);
                            addBag.ShowDialog();
                        }
                    }
                    rs.Close();
                    script.CloseCon();


                    rs = script.Select_SQL("SELECT SUM(tbl_income_other_ts2) + SUM(tbl_income_other) AS sum FROM tbl_income WHERE tbl_income_around_id = '" + income_around_id.Text.Trim() + "'", script.getConn(cpoint, groupbox1));
                    if (rs.Read() && !rs.IsDBNull(0))
                    {
                        string update_income_edit = "UPDATE tbl_income SET tbl_income_bank='" + rs.GetString("sum") + "' ,tbl_income_total = '" + rs.GetString("sum") + "' WHERE tbl_income_around_id = '" + income_around_id.Text.Trim() + "' AND tbl_income_emp_id IS NULL";

                        if (script.InsertUpdae_SQL(update_income_edit, script.getConn(cpoint, groupbox1)))
                        {
                            MessageBox.Show("บันทึกข้อมูล สำเร็จ!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            rs.Close();
                            script.CloseCon();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("บันทึกข้อมูลสำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            rs.Close();
                            script.CloseCon();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("บันทึกข้อมูลสำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rs.Close();
                        script.CloseCon();
                        this.Close();
                    }
                }
            }
        }

        private void txt_other_ts2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void txt_cb_s_Validating(object sender, CancelEventArgs e)
        {
            if (txt_cb_s.Text.Length <= 1)
            {
                txt_cb_s.Text = "0" + (txt_cb_s.Text == "" ? "0" : txt_cb_s.Text);
            }
        }

        private void txt_cb_Validating(object sender, CancelEventArgs e)
        {
            if (txt_cb.Text.Length <= 1)
            {
                txt_cb.Text = "0" + (txt_cb.Text == "" ? "0" : txt_cb.Text);
            }
        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {
            CalculateIncome();

        }
        private void txt_bank_TextChanged(object sender, EventArgs e)
        {
            CalculateIncome();

        }
        private void txt_user_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {
               // chang_tmp  = double.Parse(txt_user.Text);
                CalculateIncome();

            }
            catch { }
        }

        private void txt_fine_TextChanged(object sender, EventArgs e)
        {
            CalculateIncome();
        }

        private void txt_bank_TextChanged_1(object sender, EventArgs e)
        {
            CalculateIncome();
        }
    }
}
