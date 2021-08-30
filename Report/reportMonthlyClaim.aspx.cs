using ClaimProject.Config;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
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
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.ReportPath = Server.MapPath("reportMonthlyClaim.rdlc");

            }

        }
    }
}