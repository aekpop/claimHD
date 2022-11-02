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
    public partial class reportIndexMatrixClaim : System.Web.UI.Page
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
                //string Month = Session["Month"].ToString();
                //string Budget = Session["Budget"].ToString();
                //string Report = Session["report"].ToString();

                MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
                DataTable dt = function.GetTable(sql);

                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("reportIndexMatrixClaim.rdlc");


                //ReportParameter[] parameter = new ReportParameter[2];
                //parameter[0] = new ReportParameter("Budget", Budget);
                //parameter[1] = new ReportParameter("Month", Month);

                //ReportViewer1.LocalReport.SetParameters(parameter);
                ReportViewer1.LocalReport.Refresh();

                ReportDataSource dataSource = new ReportDataSource("DataSet1", dt);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(dataSource);
            }
        }
    }
}