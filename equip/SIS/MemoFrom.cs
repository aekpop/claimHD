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
    public partial class MemoFrom : Form
    {
        public MemoFrom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NotPayForm notPayForm = new NotPayForm();
            notPayForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PaymentForm payment = new PaymentForm();
            payment.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EscapePaymenyForm escapePaymeny = new EscapePaymenyForm();
            escapePaymeny.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PreviousMemo previous = new PreviousMemo();
            previous.ShowDialog();
        }
    }
}
