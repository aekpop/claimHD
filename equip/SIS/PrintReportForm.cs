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
    public partial class PrintReportForm : Form
    {
        MenuForm menuForm = null;
        public PrintReportForm(Form callForm)
        {
            menuForm = callForm as MenuForm;
            InitializeComponent();
        }

        private void PrintReportForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_r1_Click(object sender, EventArgs e)
        {
            ReportIncomForm reportIncomForm = new ReportIncomForm(menuForm);
            reportIncomForm.ShowDialog();
        }

        private void btn_r2_Click(object sender, EventArgs e)
        {
            ReportDailyForm reportDailyForm = new ReportDailyForm(menuForm);
            reportDailyForm.ShowDialog();
        }

        private void btn_r3_Click(object sender, EventArgs e)
        {
            /*ReportOver30Form reportOver30 = new ReportOver30Form(menuForm);
            reportOver30.ShowDialog();
            ImportPrevious import = new ImportPrevious(menuForm);
            import.ShowDialog();*/
        }

        private void btn_r4_Click(object sender, EventArgs e)
        {
            /*ReportExtraForm reportExtra = new ReportExtraForm(menuForm);
            reportExtra.ShowDialog();*/
        }

        private void PrintReportForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void groupBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void btn_r1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
    }
}
