using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClaimProject.Model;
using ClaimProject.Config;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Drawing.Printing;
using CrystalDecisions.Shared;

namespace ClaimProject.equip
{
    public partial class EquipReportPage : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        protected void Page_Load(object sender, EventArgs e)
        {

                string sqlreport = Session["sqlreEQ"].ToString();
                string tolltitle = Session["tolleq"].ToString() ;
                string descriptt = Session["describe"].ToString();
                MySqlDataAdapter da = function.MySqlSelectDataSet(sqlreport);

                DataSetEquip dts = new DataSetEquip();
                da.Fill(dts, "EquipRe");
               
                ReportDocument rept = new ReportDocument();
                rept.Load(MapPath("/equip/EquipReport.rpt"));
                rept.SetDataSource(dts);
                CRSEquipviewer.ReportSource = rept;

        }
        string GetDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                    return printer;
            }
            return string.Empty;
        }

    }
}