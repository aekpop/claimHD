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
    public partial class reportCM : System.Web.UI.Page
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
                string sql = Session["sqlReport"].ToString();
                MySqlDataAdapter da = function.MySqlSelectDataSet(sql);

                DataTable dt = function.GetTable(sql);

                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.ReportPath = Server.MapPath("reportCM.rdlc");

                ReportParameter[] parameter = new ReportParameter[1];
                parameter[0] = new ReportParameter("Headmas", "สรุปรายงานแจ้งซ่อม");

                reportViewer1.LocalReport.SetParameters(parameter);
                reportViewer1.LocalReport.Refresh();

                ReportDataSource dataSource = new ReportDataSource("DataSetCM", dt);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(dataSource);
            }
        }
    }
}