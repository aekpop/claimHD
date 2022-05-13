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
    public partial class PreviousMemo : Form
    {
        Script script = new Script();
        public PreviousMemo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                script.GetReportTollNotPay(date_memo.Value,textBox1.Text,textBox1.Text);
            }
        }

        private void PreviousMemo_Load(object sender, EventArgs e)
        {
            date_memo.CustomFormat = "dd-MM-yyyy";
        }

        private void date_memo_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
