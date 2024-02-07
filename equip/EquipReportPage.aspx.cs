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