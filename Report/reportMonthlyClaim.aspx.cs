using ClaimProject.Config;
using Microsoft.Reporting.WebForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimProject.Report
{
    public partial class reportMonthlyClaim : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/");
            }
            if (!this.IsPostBack)
            {
                string sql = Session["SqlResult"].ToString();
                string Month = Session["Month"].ToString();
                string Budget = Session["Budget"].ToString();
                string Report = Session["report"].ToString();

                MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
                DataTable dt = function.GetTable(sql);

                reportViewer1.ProcessingMode = ProcessingMode.Local;
                if(Report == "1")
                {
                    reportViewer1.LocalReport.ReportPath = Server.MapPath("reportMonthlyClaim.rdlc");
                }
                else if(Report == "2")
                {
                    reportViewer1.LocalReport.ReportPath = Server.MapPath("reportMonthlyMatrixClaim.rdlc");
                }
                

                ReportParameter[] parameter = new ReportParameter[2];
                parameter[0] = new ReportParameter("Budget", Budget);
                parameter[1] = new ReportParameter("Month", Month);

                reportViewer1.LocalReport.SetParameters(parameter);
                reportViewer1.LocalReport.Refresh();

                ReportDataSource dataSource = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(dataSource);
            }

        }
    }
}