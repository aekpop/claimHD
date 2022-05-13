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
    public partial class EditStrapsForm : Form
    {
        SendMoneyForm moneyForm = null;
        string bag_num = "";
        string emp_operate = "";
        string emp_contorl = "";
        Script script = new Script();
        TextBox txt_straps_call = null;
        public EditStrapsForm(Form callingForm, string bag, string emp, string emp_con, TextBox straps)
        {
            moneyForm = callingForm as SendMoneyForm;
            txt_straps_call = straps as TextBox;
            bag_num = bag;
            emp_operate = emp;
            emp_contorl = emp_con;
            InitializeComponent();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (txt_straps.Text != "" && combo_note.Text != "" && txt_straps_next.Text != "")
            {
                if (MessageBox.Show("ยืนยันเปลี่ยนสายรัด ใช่หรือไม่", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (script.InsertUpdae_SQL("INSERT INTO tbl_straps (tbl_straps_number,tbl_straps_status,tbl_straps_bag,tbl_straps_emp_operate,tbl_straps_emp_control,tbl_straps_note,tbl_straps_date) VALUES ('"+txt_straps.Text+"','1','" + bag_num + "','" + emp_operate + "','" + emp_contorl + "' ,'" + combo_note.Text+" / "+txt_straps_note.Text + "',NOW())"))
                    {
                        MessageBox.Show("เปลียนสายรัดจาก เลข "+ txt_straps.Text + " เป็น เลข "+ txt_straps_next.Text + " เรียบร้อยแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_straps_call.Text = txt_straps_next.Text;
                        script.SaveImages(DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + "_" + emp_operate + "_" + txt_straps.Text + "_เปลี่ยนสายรัด.jpg", moneyForm.mainForm.cpoint_id);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void EditStrapsForm_Load(object sender, EventArgs e)
        {
            txt_straps.Text = script.GetStraps(emp_contorl);

            txt_straps_next.Text = script.NextStraps(int.Parse(txt_straps.Text) +1);
        }

        private void txt_straps_next_KeyUp(object sender, KeyEventArgs e)
        {
            if (!script.CheckDupStraps(txt_straps_next.Text))
            {
                txt_straps_next.Clear();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.E && e.Modifiers == Keys.Control)
            {
                txt_straps_next.ReadOnly = false;
            }
        }

        private void combo_note_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        //---------------------------------------------
    }
}
