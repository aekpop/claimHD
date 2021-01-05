using ClaimProject.Config;
using ClaimProject.Model;
using Microsoft.Reporting.WebForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimProject.Report
{
    public partial class report : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string gettoll = ""; string sendToll = ""; string thdate = ""; string amount = ""; string Headmas = "";
                string tranIDRef = Session["TranRepId"].ToString();
                string SenderN = Session["SenderTran"].ToString();
                string SendPos = Session["PosSender"].ToString();
                string copyHead = Session["CopyTran"].ToString();

                string sqlParameter = "SELECT toll_name FROM tbl_transfer " +
                                    " JOIN tbl_toll ON tbl_toll.toll_id = tbl_transfer.toll_send " +
                                    " WHERE trans_id = '" + tranIDRef + "'";
                MySqlDataReader param = function.MySqlSelect(sqlParameter);

                if (param.Read())
                {
                    sendToll = param.GetString("toll_name");
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
                    param.Close();
                }
                else
                {
                    Response.Redirect("/equip/EquipMain");
                }

                string sqlParameH = "SELECT * FROM tbl_transfer " +
                                " JOIN tbl_toll ON tbl_toll.toll_id = tbl_transfer.toll_recieve " +
                                " WHERE trans_id = '" + tranIDRef + "'";
                MySqlDataReader parame = function.MySqlSelect(sqlParameH);
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
                    else if (stat == "7")
                    {
                        Headmas = "ใบยืมครุภัณฑ์";
                    }
                    if (parame.GetString("toll_group") == "3")
                    {
                        gettoll = parame.GetString("toll_name");
                    }
                    else
                    {
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

                string sql = "SELECT equipment_nameth ,equipment_no,equipment_serial " +
                    " FROM tbl_transfer_action " +
                    " JOIN tbl_equipment ON tbl_equipment.equipment_id = tbl_transfer_action.trans_equip_id" +
                    " WHERE transfer_id = '" + tranIDRef + "'";
                MySqlDataAdapter da = function.MySqlSelectDataSet(sql);

                DataTable dt = function.GetTable(sql);

                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.ReportPath = Server.MapPath("reportEquipTran.rdlc");

                ReportParameter[] parameter = new ReportParameter[9];
                parameter[0] = new ReportParameter("Headmas", Headmas);
                parameter[1] = new ReportParameter("sendToll", sendToll);
                parameter[2] = new ReportParameter("gettoll", gettoll);
                parameter[3] = new ReportParameter("thdate", thdate);
                parameter[4] = new ReportParameter("SenderN", SenderN);
                parameter[5] = new ReportParameter("SendPos", SendPos);
                parameter[6] = new ReportParameter("copyHead", copyHead);
                parameter[7] = new ReportParameter("submitText", submit);
                parameter[8] = new ReportParameter("refNo", tranIDRef);

                reportViewer1.LocalReport.SetParameters(parameter);
                reportViewer1.LocalReport.Refresh();

                ReportDataSource dataSource = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(dataSource);

            }
        }
    }
}