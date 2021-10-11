using ClaimProject.Config;
using ClaimProject.Model;
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
    public partial class reportEquipmentDetails : System.Web.UI.Page
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
                string sqlreport = Session["sqlreEQ"].ToString();
                MySqlDataAdapter da = function.MySqlSelectDataSet(sqlreport);
                DataTable dt = function.GetTable(sqlreport);
          
                DataSetEquip dts = new DataSetEquip();
                da.Fill(dts, "EquipRe");

                this.reportViewer1.LocalReport.EnableExternalImages = true;
                // get absolute path to Project folder
                string path = new Uri(Server.MapPath("~")).AbsoluteUri;
                // set above path to report parameter
                var parameter = new ReportParameter[1];
                parameter[0] = new ReportParameter("ImagePath", path); // adjust parameter name here
                

                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.ReportPath = Server.MapPath("reportEquipmentDetails.rdlc");

                reportViewer1.LocalReport.SetParameters(parameter);
                reportViewer1.LocalReport.Refresh();
                ReportDataSource dataSource = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(dataSource);
            }
        }
    }
}