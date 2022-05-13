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
    public partial class ProgressDlg : Form
    {
        // Update Progress Number
       /* public string Message
        {
            //set { this.progressStatus.Text = value; }
        }*/

        // Update Progress Status
        public int ProgressValue
        {
            set { this.progressStatus.Value = value; }
        }

        // Stop Event
        public EventHandler stopProgress;

        public ProgressDlg()
        {
            InitializeComponent();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            if (stopProgress != null)
            {
                stopProgress(sender, e);
            }
        }

        private void ProgressDlg_Load(object sender, EventArgs e)
        {

        }
    }
}
