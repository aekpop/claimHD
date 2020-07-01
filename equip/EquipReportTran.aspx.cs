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
using System.Windows.Forms;

namespace ClaimProject.equip
{
    public partial class EquipReportTran : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string gettoll = ""; string sendToll = ""; string thdate = ""; string amount = ""; string Headmas = "";
            string tranIDRef = Session["TranRepId"].ToString();
            string sqlParameteree = "SELECT toll_name FROM tbl_transfer " +
                                " JOIN tbl_toll ON tbl_toll.toll_id = tbl_transfer.toll_send " +
                                " WHERE trans_id = '" + tranIDRef + "'";
            MySqlDataReader paramee = function.MySqlSelect(sqlParameteree);

            if (paramee.Read())
            {
                sendToll = paramee.GetString("toll_name");
                if (sendToll == "ฝ่ายบริหารฯ")
                {
                    sendToll = "ฝ่ายบริหารการจัดเก็บเงินค่าธรรมเนียม";
                }
                else if (sendToll == "กองทางหลวงพิเศษฯ")
                {
                    sendToll = "กองทางหลวงพิเศษระหว่างเมือง";
                }
                else if(sendToll == "ฝ่ายบำรุงรักษาทรัพย์สิน")
                {
                    sendToll = "ฝ่ายบำรุงรักษาทรัพย์สิน";
                }
                else
                {
                    sendToll = "ด่านฯ " + sendToll;
                }
                paramee.Close();
            }
            else
            {
                Response.Redirect("/equip/EquipMain");
            }
            string sqlParameter = "SELECT * FROM tbl_transfer " +
                                " JOIN tbl_toll ON tbl_toll.toll_id = tbl_transfer.toll_recieve " +
                                " WHERE trans_id = '" + tranIDRef + "'";
            MySqlDataReader parame = function.MySqlSelect(sqlParameter);
            if(parame.Read())
            {
                string stat = parame.GetString("trans_stat");
                if (stat == "1")
                {
                    Headmas = "ใบรับ - ส่งครุภัณฑ์";
                }
                else if(stat == "2" || stat == "6")
                {
                    Headmas = "ใบส่งคืนครุภัณฑ์";
                }
                else if(stat == "4")
                {
                    Headmas = "ใบส่งซ่อมครุภัณฑ์";
                }
                gettoll = parame.GetString("toll_name");
                if(gettoll == "ฝ่ายบริหารฯ")
                {
                    gettoll = "ฝ่ายบริหารการจัดเก็บเงินค่าธรรมเนียม";
                }
                else if(gettoll == "กองทางหลวงพิเศษฯ")
                {
                    gettoll = "กองทางหลวงพิเศษระหว่างเมือง";
                }
                else if (gettoll == "ฝ่ายบำรุงรักษาทรัพย์สิน")
                {
                    gettoll = "ฝ่ายบำรุงรักษาทรัพย์สิน";
                }
                else
                {
                    gettoll = "ด่านฯ " + gettoll;
                }
                thdate = function.ConvertDatelongThai(parame.GetString("date_send"));
                parame.Close();
            }
            else
            {
                Response.Redirect("/equip/EquipMain");
            }
            string sqlCount = "SELECT count(transfer_id) AS AA FROM tbl_transfer_action " +
                                " WHERE transfer_id = '" + tranIDRef + "'";
            MySqlDataReader countt = function.MySqlSelect(sqlCount);
            if(countt.Read())
            {
                amount = countt.GetInt32("AA").ToString();
                countt.Close();
            }
            else
            {
                Response.Redirect("/equip/EquipMain");
            }


            string submit = gettoll+" ได้รับอุปกรณ์ทั้งหมด "+amount+" รายการ ดังกล่าวข้างต้นถูกต้องครบถ้วนเรียบร้อยแล้ว";

            string tablelist = "SELECT equipment_nameth AS eqnameth,equipment_no AS eqnumber,equipment_serial AS eqserial " +
                    " FROM tbl_transfer_action " +
                    " JOIN tbl_equipment ON tbl_equipment.equipment_id = tbl_transfer_action.trans_equip_id" +
                    " WHERE transfer_id = '"+tranIDRef+ "'  ";
            MySqlDataAdapter da = function.MySqlSelectDataSet(tablelist);

            DataSetEquip dts = new DataSetEquip();
            da.Fill(dts, "tranAct");
            ReportDocument reptxx = new ReportDocument();

            reptxx.Load(MapPath("/equip/ReportTran.rpt"));
            reptxx.SetDataSource(dts);
            reptxx.SetParameterValue("RecieveToll", gettoll);
            reptxx.SetParameterValue("SenderToll", sendToll);
            reptxx.SetParameterValue("thDate", thdate);
            reptxx.SetParameterValue("refNo", tranIDRef);
            reptxx.SetParameterValue("submitText", submit);
            reptxx.SetParameterValue("HeadReport", Headmas);
            reptxx.SetParameterValue("copyHead", Session["CopyTran"]);
            reptxx.SetParameterValue("SenderN", Session["SenderTran"]);
            reptxx.SetParameterValue("SendPos", Session["PosSender"]);
            
            CRSEquipviewer.ReportSource = reptxx;
           /* rept.PrintToPrinter(1, true, 0, 0); 
             System.Drawing.Printing.PrintDocument pDoc = new System.Drawing.Printing.PrintDocument();
             CrystalDecisions.Shared.PrintLayoutSettings printLayout = new CrystalDecisions.Shared.PrintLayoutSettings();
             System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();

             //printerSettings.PrinterName = "Canon G4010 series on 10.6.3.189 (redirected 2)";

             System.Drawing.Printing.PageSettings pSettings = new System.Drawing.Printing.PageSettings(printerSettings);

             rept.PrintOptions.DissociatePageSizeAndPrinterPaperSize = true;
             rept.PrintOptions.PrinterDuplex = PrinterDuplex.Simplex;

             System.Drawing.Printing.PageSettings pageSettings = new System.Drawing.Printing.PageSettings(printerSettings);
             rept.PrintToPrinter(printerSettings,pSettings,false,printLayout);
             */

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


        protected void btnprint_Command(object sender, CommandEventArgs e)
        {
            string gettoll = ""; string sendToll = ""; string thdate = ""; string amount = ""; string Headmas = "";
            string tranIDRef = Session["TranRepId"].ToString();
            string sqlParameteree = "SELECT toll_name FROM tbl_transfer " +
                                " JOIN tbl_toll ON tbl_toll.toll_id = tbl_transfer.toll_send " +
                                " WHERE trans_id = '" + tranIDRef + "'";
            MySqlDataReader paramee = function.MySqlSelect(sqlParameteree);

            if (paramee.Read())
            {
                sendToll = paramee.GetString("toll_name");
                if (sendToll == "ฝ่ายบริหารฯ")
                {
                    sendToll = "ฝ่ายบริหารการจัดเก็บเงินค่าธรรมเนียม";
                }
                else if (sendToll == "กองทางหลวงพิเศษฯ")
                {
                    sendToll = "กองทางหลวงพิเศษระหว่างเมือง";
                }
                else if (sendToll == "ฝ่ายบำรุงรักษาทรัพย์สิน")
                {
                    sendToll = "ฝ่ายบำรุงรักษาทรัพย์สิน";
                }
                else
                {
                    sendToll = "ด่านฯ " + sendToll;
                }
                paramee.Close();
            }
            else
            {
                Response.Redirect("/equip/EquipMain");
            }
            string sqlParameter = "SELECT * FROM tbl_transfer " +
                                " JOIN tbl_toll ON tbl_toll.toll_id = tbl_transfer.toll_recieve " +
                                " WHERE trans_id = '" + tranIDRef + "'";
            MySqlDataReader parame = function.MySqlSelect(sqlParameter);
            if (parame.Read())
            {
                string stat = parame.GetString("trans_stat");
                if (stat == "1")
                {
                    Headmas = "ใบรับ - ส่งครุภัณฑ์";
                }
                else if (stat == "2" || stat == "6")
                {
                    Headmas = "ใบส่งคืนครุภัณฑ์";
                }
                else if (stat == "4")
                {
                    Headmas = "ใบส่งซ่อมครุภัณฑ์";
                }
                gettoll = parame.GetString("toll_name");
                if (gettoll == "ฝ่ายบริหารฯ")
                {
                    gettoll = "ฝ่ายบริหารการจัดเก็บเงินค่าธรรมเนียม";
                }
                else if (gettoll == "กองทางหลวงพิเศษฯ")
                {
                    gettoll = "กองทางหลวงพิเศษระหว่างเมือง";
                }
                else if (gettoll == "ฝ่ายบำรุงรักษาทรัพย์สิน")
                {
                    gettoll = "ฝ่ายบำรุงรักษาทรัพย์สิน";
                }
                else
                {
                    gettoll = "ด่านฯ " + gettoll;
                }
                thdate = function.ConvertDatelongThai(parame.GetString("date_send"));
                parame.Close();
            }
            else
            {
                Response.Redirect("/equip/EquipMain");
            }
            string sqlCount = "SELECT count(transfer_id) AS AA FROM tbl_transfer_action " +
                                " WHERE transfer_id = '" + tranIDRef + "'";
            MySqlDataReader countt = function.MySqlSelect(sqlCount);
            if (countt.Read())
            {
                amount = countt.GetInt32("AA").ToString();
                countt.Close();
            }
            else
            {
                Response.Redirect("/equip/EquipMain");
            }


            string submit = gettoll + " ได้รับอุปกรณ์ทั้งหมด " + amount + " รายการ ดังกล่าวข้างต้นถูกต้องครบถ้วนเรียบร้อยแล้ว";

            string tablelist = "SELECT equipment_nameth AS eqnameth,equipment_no AS eqnumber,equipment_serial AS eqserial " +
                    " FROM tbl_transfer_action " +
                    " JOIN tbl_equipment ON tbl_equipment.equipment_id = tbl_transfer_action.trans_equip_id" +
                    " WHERE transfer_id = '" + tranIDRef + "'  ";
            MySqlDataAdapter da = function.MySqlSelectDataSet(tablelist);

            DataSetEquip dts = new DataSetEquip();
            da.Fill(dts, "tranAct");
            ReportDocument reptxx = new ReportDocument();

            reptxx.Load(MapPath("/equip/ReportTran.rpt"));
            reptxx.SetDataSource(dts);
            reptxx.SetParameterValue("RecieveToll", gettoll);
            reptxx.SetParameterValue("SenderToll", sendToll);
            reptxx.SetParameterValue("thDate", thdate);
            reptxx.SetParameterValue("refNo", tranIDRef);
            reptxx.SetParameterValue("submitText", submit);
            reptxx.SetParameterValue("HeadReport", Headmas);
            reptxx.SetParameterValue("copyHead", Session["CopyTran"]);
            reptxx.SetParameterValue("SenderN", Session["SenderTran"]);
            reptxx.SetParameterValue("SendPos", Session["PosSender"]);

            CRSEquipviewer.ReportSource = reptxx;

            reptxx.PrintToPrinter(1, true, 0, 0);
        }
    }
}