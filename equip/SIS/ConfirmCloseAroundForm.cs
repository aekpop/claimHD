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
    public partial class ConfirmCloseAroundForm : Form
    {
        public bool comfirmClose = false;
        Script scriptCode = new Script();
        public ConfirmCloseAroundForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comfirmClose = true;
            this.Close();
        }

        private void ConfirmCloseAroundForm_Load(object sender, EventArgs e)
        {
            dataGridView1 = scriptCode.GetDataGridViewStatus(dataGridView1);
        }
    }
}
