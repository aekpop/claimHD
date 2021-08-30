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
    public partial class reportQuantationCostapp : System.Web.UI.Page
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
                string Qua = Session["Quantation"].ToString();
                string Per1 = Session["Person1"].ToString();
                string Per2 = Session["Person2"].ToString();
                string Per3 = Session["Person3"].ToString();
                string Headmes = "";


                MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
                if(Session["HeadmesProject"] != null)
                {
                     Headmes = Session["HeadmesProject"].ToString();
                }
                else
                {
                     Headmes = "-";
                }

                
                string Project = function.GetSelectValue("tbl_quotations q JOIN tbl_company c ON q.quotations_company_id = c.company_id LEFT JOIN tbl_device d ON q.quotations_device_id = d.device_id", "quotations_id ='"+ Qua + "'", "device_ref_Project");
                string device = function.GetSelectValue("tbl_quotations q JOIN tbl_company c ON q.quotations_company_id = c.company_id LEFT JOIN tbl_device d ON q.quotations_device_id = d.device_id", "quotations_id ='" + Qua + "'", "device_name");
                string price = double.Parse(function.GetSelectValue("tbl_quotations q JOIN tbl_company c ON q.quotations_company_id = c.company_id LEFT JOIN tbl_device d ON q.quotations_device_id = d.device_id", "quotations_id ='" + Qua + "'", "device_ref_Price")).ToString("#,###,###.00");

                DataTable dt = function.GetTable(sql);

                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.ReportPath = Server.MapPath("reportCostAppraisal.rdlc");

                ReportParameter[] parameter = new ReportParameter[7];
                parameter[0] = new ReportParameter("Headmas", Headmes);
                parameter[1] = new ReportParameter("ProjectRefer", Project);
                parameter[2] = new ReportParameter("device", device);
                parameter[3] = new ReportParameter("price", price);
                parameter[4] = new ReportParameter("Person1", "(" +Per1 +")");
                parameter[5] = new ReportParameter("Person2", "("+ Per2 +")");
                parameter[6] = new ReportParameter("Person3", "("+ Per3 +")");

                reportViewer1.LocalReport.SetParameters(parameter);
                reportViewer1.LocalReport.Refresh();

                ReportDataSource dataSource = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(dataSource);
            }
        }
    }
}