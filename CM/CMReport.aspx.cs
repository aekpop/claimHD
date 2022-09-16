using ClaimProject.Config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimProject.CM
{
    public partial class CMReport : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public string cm_id = "";
        public string alert = "";
        public string alertType = "";
        public string icon = "";
        public string EditModal = "";
        public string Fname = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/");
            }

            //if (txtETime.Text == "") { txtETime.Text = DateTime.Now.ToString("HH.mm"); }

            if (!this.IsPostBack)
            {
                string sqlCh = "";

                function.getListItem(ddlCMBudget, "SELECT cm_budget FROM tbl_cm_detail  GROUP BY cm_budget ORDER by cm_budget DESC", "cm_budget", "cm_budget");
                ddlCMBudget.Items.Insert(0, new ListItem("ทั้งหมด", ""));

                sqlCh = "SELECT * FROM tbl_location where locate_group = '1' ORDER BY locate_id";
                function.getListItem(txtSearchChannel, sqlCh, "locate_name", "locate_id");
                txtSearchChannel.Items.Insert(0, new ListItem("ทั้งหมด", ""));

                txtCMStatus.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                txtCMStatus.Items.Insert(1, new ListItem("รอการแก้ไข", "0"));
                txtCMStatus.Items.Insert(2, new ListItem("รอการตรวจสอบ", "1"));
                txtCMStatus.Items.Insert(3, new ListItem("ใช้งานได้ปกติ", "2"));
                txtCMStatus.Items.Insert(4, new ListItem("แก้ไขเบื้องต้น", "3"));

                string sql = "";
                if (function.CheckLevel("Department", Session["UserPrivilegeId"].ToString()))
                {
                    sql = "SELECT * FROM tbl_cpoint ORDER BY cpoint_id";
                    function.getListItem(txtCpointSearch, sql, "cpoint_name", "cpoint_id");
                    txtCpointSearch.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                }
                else
                {
                    sql = "SELECT * FROM tbl_cpoint WHERE cpoint_id = '" + Session["UserCpoint"].ToString() + "'";
                    function.getListItem(txtCpointSearch, sql, "cpoint_name", "cpoint_id");
                    //txtCpointSearch.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                }

                string sql_Device = "SELECT * FROM tbl_device ORDER BY device_name";
                function.getListItem(txtDeviceDamage, sql_Device, "device_name", "device_id");
                txtDeviceDamage.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                string sqlRespon = "SELECT * FROM tbl_drive_group";
                function.getListItem(ddlResponsible, sqlRespon, "drive_group_agency", "drive_group_id");
                ddlResponsible.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                BindData();
            }
        }
        void BindData()
        {
            string sql = "";
            string checkCpoint = txtCpointSearch.SelectedValue;
            string checkPoint = txtPoint.Text;
            string CMStatus = txtCMStatus.SelectedValue;
            string checkBudget = ddlCMBudget.SelectedValue;
            string dataS = txtDateStart.Text;
            string dateE = txtDateEnd.Text;
            string consta = "";
            string channel = txtSearchChannel.SelectedValue;
            string deviceDamage = txtDeviceDamage.SelectedValue;
            string Responsible = ddlResponsible.SelectedValue;

            if (CheckAllDay.Checked)
            {
                if (channel == "")
                {
                    if (deviceDamage == "")
                    {
                        if (Responsible == "") //all query
                        {
                            consta = " ";
                        }
                        else
                        {
                            consta = " AND dg.drive_group_id = '" + Responsible + "' ";
                        }
                    }
                    else
                    {
                        if (Responsible == "")
                        {
                            consta = " AND d.device_id = '" + deviceDamage + "' ";
                        }
                        else
                        {
                            consta = " AND d.device_id = '" + deviceDamage + "' AND dg.drive_group_id = '" + Responsible + "' ";
                        }
                    }

                }
                else
                {
                    if (deviceDamage == "")
                    {
                        if (Responsible == "")
                        {
                            consta = " AND cm_detail_channel = '" + channel + "' ";
                        }
                        else
                        {
                            consta = " AND cm_detail_channel = '" + channel + "' AND dg.drive_group_id = '" + Responsible + "' ";
                        }

                    }
                    else
                    {
                        if (Responsible == "")
                        {
                            consta = " AND cm_detail_channel = '" + channel + "' AND d.device_id = '" + deviceDamage + "' ";
                        }
                        else
                        {
                            consta = " AND cm_detail_channel = '" + channel + "' AND d.device_id = '" + deviceDamage + "' AND dg.drive_group_id = '" + Responsible + "' ";
                        }

                    }

                }
            }
            else
            {
                if (channel == "")
                {
                    if (deviceDamage == "")
                    {
                        if (Responsible == "")
                        {
                            consta = " AND STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') BETWEEN  STR_TO_DATE( '" + dataS + "','%d-%m-%Y') AND STR_TO_DATE('" + dateE + "' ,'%d-%m-%Y') ";
                        }
                        else
                        {
                            consta = " AND STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') BETWEEN  STR_TO_DATE( '" + dataS + "','%d-%m-%Y') AND STR_TO_DATE('" + dateE + "' ,'%d-%m-%Y') " +
                                     "AND dg.drive_group_id = '" + Responsible + "' ";
                        }

                    }
                    else
                    {
                        if (Responsible == "")
                        {
                            consta = " AND STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') BETWEEN  STR_TO_DATE( '" + dataS + "','%d-%m-%Y') AND STR_TO_DATE('" + dateE + "' ,'%d-%m-%Y') " +
                                 " AND d.device_id = '" + deviceDamage + "' ";
                        }
                        else
                        {
                            consta = " AND STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') BETWEEN  STR_TO_DATE( '" + dataS + "','%d-%m-%Y') AND STR_TO_DATE('" + dateE + "' ,'%d-%m-%Y') " +
                                 " AND d.device_id = '" + deviceDamage + "' AND dg.drive_group_id = '" + Responsible + "' ";
                        }

                    }
                }
                else
                {
                    if (deviceDamage == "")
                    {
                        if (Responsible == "")
                        {
                            consta = " AND STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') BETWEEN  STR_TO_DATE( '" + dataS + "','%d-%m-%Y') AND STR_TO_DATE('" + dateE + "' ,'%d-%m-%Y') " +
                            "AND cm_detail_channel = '" + channel + "' ";
                        }
                        else
                        {
                            consta = " AND STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') BETWEEN  STR_TO_DATE( '" + dataS + "','%d-%m-%Y') AND STR_TO_DATE('" + dateE + "' ,'%d-%m-%Y') " +
                            "AND cm_detail_channel = '" + channel + "' AND dg.drive_group_id = '" + Responsible + "' ";
                        }

                    }
                    else
                    {
                        if (Responsible == "")
                        {
                            consta = " AND STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') BETWEEN  STR_TO_DATE( '" + dataS + "','%d-%m-%Y') AND STR_TO_DATE('" + dateE + "' ,'%d-%m-%Y') " +
                                 " AND cm_detail_channel = '" + channel + "' AND d.device_id = '" + deviceDamage + "' ";
                        }
                        else
                        {
                            consta = " AND STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') BETWEEN  STR_TO_DATE( '" + dataS + "','%d-%m-%Y') AND STR_TO_DATE('" + dateE + "' ,'%d-%m-%Y') " +
                                 " AND cm_detail_channel = '" + channel + "' AND d.device_id = '" + deviceDamage + "' AND dg.drive_group_id = '" + Responsible + "' ";
                        }

                    }
                }
            }
            sql += "SELECT * FROM tbl_cm_detail cm " +
            " JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
            " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
            " JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id " +
            " JOIN tbl_drive_group dg ON d.davice_group = dg.drive_group_id " +
            " JOIN tbl_cm_status ss ON cm.cm_detail_status_id = ss.cm_stat_id ";

            if (checkBudget != "")
            {
                if (checkCpoint == "")
                {
                    if (checkPoint == "")
                    {
                        if (CMStatus == "")
                        {
                            sql += " WHERE cm.cm_budget = '" + ddlCMBudget.SelectedValue + "' " + consta + " " +
                            " AND cm.cm_detail_status_id != 9 " + // รอปรับ sql ใหม่
                            " ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC, cm.cm_detail_stime, cm_detail_status_id ASC";
                        }
                        else
                        {

                            sql += " WHERE cm.cm_budget = '" + ddlCMBudget.SelectedValue + "' " + consta + " " +
                                   " AND cm_detail_status_id = '" + CMStatus + "' ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC, " +
                                   "cm.cm_detail_stime, cm_detail_status_id ASC";

                        }
                    }
                    else
                    {
                        if (CMStatus == "")
                        {
                            sql += " WHERE cm.cm_budget = '" + ddlCMBudget.SelectedValue + "' AND cm.cm_point = '" + checkPoint + "' " + consta + " " +
                            " AND cm.cm_detail_status_id != 9 " + // รอปรับ sql ใหม่
                            " ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC, cm.cm_detail_stime, cm_detail_status_id ASC";
                        }
                        else
                        {

                            sql += " WHERE cm.cm_budget = '" + ddlCMBudget.SelectedValue + "' AND cm.cm_point = '" + checkPoint + "' " + consta + " " +
                                   " AND cm_detail_status_id = '" + CMStatus + "' ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC, cm.cm_detail_stime, cm_detail_status_id ASC";

                        }
                    }
                }
                else
                {
                    if (CMStatus == "")
                    {
                        sql += " WHERE cm.cm_cpoint = '" + checkCpoint + "' " +
                        " AND cm.cm_budget = '" + ddlCMBudget.SelectedValue + "' " + consta + " " +
                        " AND cm.cm_detail_status_id != 9 " + // รอปรับ sql ใหม่
                        " ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC, cm.cm_detail_stime, cm_detail_status_id ASC";
                    }
                    else
                    {

                        sql += " WHERE cm.cm_cpoint = '" + checkCpoint + "' " +
                               " AND cm.cm_budget = '" + ddlCMBudget.SelectedValue + "' " + consta + " " +
                               " AND cm_detail_status_id = '" + CMStatus + "' ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC, cm.cm_detail_stime, cm_detail_status_id ASC";

                    }
                }
            }
            else
            {
                if (checkCpoint == "") //ไม่เลือก ปีงบ
                {
                    if (checkPoint == "")
                    {
                        if (CMStatus == "")
                        {
                            sql += " Where d.`davice_delete` = 0 " + consta + " " +
                            " AND cm.cm_detail_status_id != 9 " + // รอปรับ sql ใหม่
                            " ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC, cm.cm_detail_stime, cm_detail_status_id ASC";
                        }
                        else
                        {

                            sql += " Where d.`davice_delete` = 0 " + consta + " " +
                                    " AND cm_detail_status_id = '" + CMStatus + "' ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC, cm.cm_detail_stime, cm_detail_status_id ASC";

                        }
                    }
                    else
                    {
                        if (CMStatus == "")
                        {
                            sql += " Where cm.cm_point = '" + checkPoint + "' " + consta + " " +
                            " AND cm.cm_detail_status_id != 9 " + // รอปรับ sql ใหม่
                            " ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y')DESC, cm.cm_detail_stime, cm_detail_status_id ASC";
                        }
                        else
                        {

                            sql += " Where cm.cm_point = '" + checkPoint + "' " + consta + " " +
                                    " AND cm_detail_status_id = '" + CMStatus + "' ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC, cm.cm_detail_stime, cm_detail_status_id ASC";

                        }
                    }


                }
                else
                {
                    if (checkPoint == "")
                    {
                        if (CMStatus == "")
                        {
                            sql += " WHERE cm.cm_cpoint = '" + checkCpoint + "' " + consta + " " +
                            " AND cm.cm_detail_status_id != 9 " + // รอปรับ sql ใหม่
                            " ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC, cm.cm_detail_stime, cm_detail_status_id ASC";
                        }
                        else
                        {

                            sql += " WHERE cm.cm_cpoint = '" + checkCpoint + "' " + consta + " " +
                       " AND cm_detail_status_id = '" + CMStatus + "' ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC, cm.cm_detail_stime, cm_detail_status_id ASC";


                        }
                    }
                    else
                    {
                        if (CMStatus == "")
                        {
                            sql += " WHERE cm.cm_cpoint = '" + checkCpoint + "' " +
                            " AND cm.cm_point = '" + checkPoint + "' " + consta + " " +
                            " AND cm.cm_detail_status_id != 9 " + // รอปรับ sql ใหม่
                            " ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC, cm.cm_detail_stime, cm_detail_status_id ASC";
                        }
                        else
                        {

                            sql += " WHERE cm.cm_cpoint = '" + checkCpoint + "' " +
                                    " AND cm.cm_point = '" + checkPoint + "' " + consta + " " +
                                    " AND cm_detail_status_id = '" + CMStatus + "' ORDER BY cm_cpoint,cm_point,STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC, cm.cm_detail_stime, cm_detail_status_id ASC";

                        }
                    }

                }
            }



            MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            if (ds.Tables[0].Rows.Count == 0) { GridView1.Visible = false; } else { GridView1.Visible = true; }
            lbCMNull.Text = "พบข้อมูลจำนวน " + ds.Tables[0].Rows.Count + " แถว";

            Session.Add("sqlReport", sql);

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "CM" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView1.GridLines = GridLines.Both;
            GridView1.HeaderStyle.Font.Bold = true;
            GridView1.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }

        protected void btnResult_Click(object sender, EventArgs e)
        {

        }

        protected void btnCoverReport_Click(object sender, EventArgs e)
        {

        }

        protected void ltnAllPM_Command(object sender, CommandEventArgs e)
        {

        }

        protected void ltnNum2_Command(object sender, CommandEventArgs e)
        {

        }

        protected void ltnNum3_Command(object sender, CommandEventArgs e)
        {

        }

        protected void ltnNum4_Command(object sender, CommandEventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbSDate = (Label)(e.Row.FindControl("lbSDate"));
            if (lbSDate != null)
            {
                lbSDate.Text = function.ConvertDateShortThai((string)DataBinder.Eval(e.Row.DataItem, "cm_detail_sdate"));
            }

            Label lbStatus = (Label)(e.Row.FindControl("lbStatus"));
            if (lbStatus != null)
            {
                lbStatus.Text = function.GetStatusCM(DataBinder.Eval(e.Row.DataItem, "cm_detail_status_id").ToString());
                if (lbStatus.Text == "รอการแก้ไข")
                {
                    lbStatus.CssClass = "badge badge-danger";
                    lbStatus.Text = "แจ้งซ่อม";
                }
                else if (lbStatus.Text == "รอการตรวจสอบ")
                {
                    lbStatus.CssClass = "badge badge-warning";
                    lbStatus.Text = "ตรวจสอบ";
                }
                else if (lbStatus.Text == "แก้ไขเบื้องต้น")
                {
                    lbStatus.CssClass = "badge badge-info";
                }
                else if (lbStatus.Text == "ใช้งานได้ปกติ")
                {
                    lbStatus.CssClass = "badge badge-success";
                    lbStatus.Text = "ซ่อมแล้ว";
                }

            }

            Label btnDateEditCM = (Label)(e.Row.FindControl("btnDateEditCM"));
            if (btnDateEditCM != null)
            {
                if (!DataBinder.Eval(e.Row.DataItem, "cm_detail_edate").Equals(DBNull.Value))
                {
                    btnDateEditCM.Text = function.ConvertDateShortThai((string)DataBinder.Eval(e.Row.DataItem, "cm_detail_edate"));
                }
            }

            Label btnTimeEditCM = (Label)(e.Row.FindControl("btnTimeEditCM"));
            if (btnTimeEditCM != null)
            {
                if (!DataBinder.Eval(e.Row.DataItem, "cm_detail_etime").Equals(DBNull.Value))
                {
                    btnTimeEditCM.Text = (string)DataBinder.Eval(e.Row.DataItem, "cm_detail_etime");
                    if (btnTimeEditCM.Text != "") { btnTimeEditCM.Text += ""; }
                }
            }

            //if (function.CheckLevel("Department", Session["UserPrivilegeId"].ToString()))
            //{
            Label lbDay = (Label)(e.Row.FindControl("lbDay"));
            if (lbDay != null)
            {
                string[] data = DataBinder.Eval(e.Row.DataItem, "cm_detail_sdate").ToString().Split('-');
                string[] times = DataBinder.Eval(e.Row.DataItem, "cm_detail_stime").ToString().Split('.', ':');
                DateTime dateStart = DateTime.ParseExact(data[0] + "-" + data[1] + "-" + (int.Parse(data[2]) - 543) + " " + times[0] + ":" + times[1], "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
                DateDifference differnce = new DateDifference(dateStart);



                if (lbStatus.Text != "ใช้งานได้ปกติ")
                {
                    if (differnce.ToString() == "")
                    {
                        lbDay.CssClass = "badge badge-danger";
                        lbDay.Text = "NEW!!";
                    }
                    else
                    {
                        if (differnce.Month > 1)
                        {
                            lbDay.Text = differnce.ToString();
                            lbDay.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            lbDay.Text = differnce.ToString();
                        }

                    }
                }
                else
                {
                    //ยังไม่สำเร็จ
                    string[] dateE = DataBinder.Eval(e.Row.DataItem, "cm_detail_edate").ToString().Split('-');
                    string[] timeE = DataBinder.Eval(e.Row.DataItem, "cm_detail_etime").ToString().Split('.', ':');
                    DateTime dateEnd = DateTime.ParseExact(dateE[0] + "-" + dateE[1] + "-" + (int.Parse(dateE[2]) - 543) + " " + times[0] + ":" + times[1], "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
                    DateDifference diffComp = new DateDifference(dateStart, dateEnd);
                    lbDay.Text = diffComp.ToString();
                    lbDay.ForeColor = System.Drawing.Color.Green;
                }
            }
            //}


            LinkButton lbDeviceName = (LinkButton)(e.Row.FindControl("lbDeviceName"));
            if (lbDeviceName != null)
            {
                lbDeviceName.CommandName = DataBinder.Eval(e.Row.DataItem, "cm_detail_id").ToString();
                lbDeviceName.Text = function.ShortTextCom(DataBinder.Eval(e.Row.DataItem, "device_name").ToString());
                //lbDeviceName.ToolTip = DataBinder.Eval(e.Row.DataItem, "device_name").ToString();
            }

            Label lbProblem = (Label)(e.Row.FindControl("lbProblem"));
            if (lbProblem != null)
            {
                //lbProblem.Text = function.ShortTextCom(DataBinder.Eval(e.Row.DataItem, "cm_detail_problem").ToString());
                //lbProblem.ToolTip = DataBinder.Eval(e.Row.DataItem, "cm_detail_problem").ToString();
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnSearchEdit_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void CheckAllDay_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckAllDay.Checked)
            {
                txtDateStart.Visible = false;
                txtDateEnd.Visible = false;
                //lbCheckSometime.Visible = false;
                lbDayS.Visible = false;
                lbDayE.Visible = false;
            }
            else
            {
                txtDateStart.Visible = true;
                txtDateEnd.Visible = true;
                //lbCheckSometime.Visible = true;
                lbDayS.Visible = true;
                lbDayE.Visible = true;
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }

        protected void lbDeviceName_Command(object sender, CommandEventArgs e)
        {
            if (function.CheckLevel("Techno", Session["UserPrivilegeId"].ToString()))
            {
                lbDates.Visible = true;
                lbDatesRecheck.Visible = true;
                //lbTimes.Visible = true;
                lbTimesRecheck.Visible = true;
                lbStatusH.Visible = true;
                lbStatusRecheck.Visible = true;
            }

            string imgS = "/CM/Upload/NoImageAvailable.jpg";
            string imgE = "/CM/Upload/NoImageAvailable.jpg";
            string imgSer = "/CM/Upload/NoImageAvailable.jpg";
            string chkSerVForm = "0";

            EditModal = e.CommandName;
            pkeq.Text = EditModal;

            string sqlEdit = "SELECT * FROM tbl_cm_detail c JOIN tbl_device d ON c.cm_detail_driver_id = d.device_id " +
                " JOIN tbl_cpoint e ON c.cm_cpoint = e.cpoint_id JOIN tbl_location f ON c.cm_detail_channel = f.locate_id " +
                " JOIN tbl_user g ON c.cm_user = g.username WHERE cm_detail_id = '" + pkeq.Text + "' ";

            MySqlDataReader rt = function.MySqlSelect(sqlEdit);

            if (rt.Read())
            {
                //if(!rt.IsDBNull(11) && !rt.IsDBNull(14) && !rt.IsDBNull(19) && !rt.IsDBNull(20) && !rt.IsDBNull(21) && !rt.IsDBNull(22))
                string Chk = rt.GetString("cm_detail_status_id");

                if (Chk == "0")
                {
                    if (function.CheckLevel("Techno", Session["UserPrivilegeId"].ToString()))
                    {
                        btnReverb.Visible = false;
                    }
                    lbMethodRecheck.Text = "-";
                    lbDateERecheck.Text = "-";
                    lbTimeERecheck.Text = "-";
                    lbDateEJRecheck.Text = "-";
                    lbTimeEJRecheck.Text = "-";
                    lbUserEJRecheck.Text = "-";
                    lbNodeRecheck.Text = " - ";
                }
                else if (Chk == "1")
                {
                    if (function.CheckLevel("Techno", Session["UserPrivilegeId"].ToString()))
                    {
                        btnReverb.Visible = false;
                    }
                    imgE = rt.GetString("cm_detail_eimg");
                    lbMethodRecheck.Text = rt.GetString("cm_detail_method");
                    lbDateERecheck.Text = rt.GetString("cm_detail_edate");
                    lbTimeERecheck.Text = rt.GetString("cm_detail_etime");
                    lbDateEJRecheck.Text = rt.GetString("cm_detail_ejdate");
                    lbTimeEJRecheck.Text = rt.GetString("cm_detail_ejtime");
                    lbUserEJRecheck.Text = rt.GetString("cm_user_endjob");
                    lbNodeRecheck.Text = rt.GetString("cm_detail_note");
                    if (!rt.IsDBNull(22))
                    {
                        imgSer = rt.GetString("cm_detail_Service_img");
                        chkSerVForm = "1";
                    }
                    else
                    {
                        imgSer = " ";
                    }

                }
                else if (Chk == "2" || Chk == "3")
                {
                    if (function.CheckLevel("Techno", Session["UserPrivilegeId"].ToString()))
                    {
                        btnReverb.Visible = true;
                    }
                    imgE = rt.GetString("cm_detail_eimg");
                    lbMethodRecheck.Text = rt.GetString("cm_detail_method");
                    lbDateERecheck.Text = rt.GetString("cm_detail_edate");
                    lbTimeERecheck.Text = rt.GetString("cm_detail_etime");
                    lbDateEJRecheck.Text = rt.GetString("cm_detail_ejdate");
                    lbTimeEJRecheck.Text = rt.GetString("cm_detail_ejtime");
                    lbUserEJRecheck.Text = rt.GetString("cm_user_endjob");
                    lbNodeRecheck.Text = rt.GetString("cm_detail_note");
                    if (!rt.IsDBNull(22))
                    {
                        imgSer = rt.GetString("cm_detail_Service_img");
                        chkSerVForm = "1";
                    }
                    else
                    {
                        imgSer = " ";
                    }
                }
            }

            imgS = rt.GetString("cm_detail_simg");
            ImgEditEQ.ImageUrl = "~" + imgS;
            ImgEditEQE.ImageUrl = "~" + imgE;
            //ImgImageDocSer.ImageUrl = "~" + imgSer;
            Imgfilename.Text = imgSer;
            if (rt.GetString("cm_detail_status_id") == "0")
            {
                lbStatusRecheck.ForeColor = Color.DarkRed;
            }
            else if (rt.GetString("cm_detail_status_id") == "1")
            {
                lbStatusRecheck.ForeColor = Color.DarkOrange;
            }
            else if (rt.GetString("cm_detail_status_id") == "2")
            {
                lbStatusRecheck.ForeColor = Color.DarkGreen;
            }
            else if (rt.GetString("cm_detail_status_id") == "3")
            {
                lbStatusRecheck.ForeColor = Color.LightSkyBlue;
            }
            lbStatusRecheck.Text = function.GetStatusCM(rt.GetString("cm_detail_status_id").ToString());
            lbrefRecheck.Text = rt.GetString("cm_detail_id");
            lbCpointRecheck.Text = rt.GetString("cpoint_name");
            if(rt.GetString("cpoint_name") == "")
            {
                lbPointRecheck.Text = "";
            }
            else
            {
                lbPointRecheck.Text = " " + rt.GetString("cm_point");
            }
            lbChannelRecheck.Text = rt.GetString("locate_name");
            //lbdeviceRecheck.Text = rt.GetString("device_name");
            lbdeviceRecheck.Text = rt.GetString("device_initials");
            lbProblemRecheck.Text = rt.GetString("cm_detail_problem");
            lbDatesRecheck.Text = rt.GetString("cm_detail_sdate");
            lbTimesRecheck.Text = rt.GetString("cm_detail_stime");
            lbUserRecheck.Text = rt.GetString("name");

            Fname = "~" + imgSer;
            if(chkSerVForm == "0")
            {
                lbServiceForm.Text = "ไม่มี";
                lbServiceForm.ForeColor = Color.Red;
            }
            else
            {
                lbServiceForm.Text = "มี";
                lbServiceForm.ForeColor = Color.Green;
            }

            rt.Close();
        }

        protected void btnReverb_Command(object sender, CommandEventArgs e)
        {
            string TimeNoww = DateTime.Now.ToString("HH:mm");
            string DateNoww = DateTime.Now.ToString("dd-MM") + "-" + (DateTime.Now.Year + 543);
            string sqlReverb = " UPDATE tbl_cm_detail SET cm_detail_status_id = 1 WHERE cm_detail_id = '" + pkeq.Text + "' ";
            if (function.MySqlQuery(sqlReverb))
            {
                string filePath = "D:/log/CM/Update_log";
                StringBuilder sb = new StringBuilder();
                sb.Append("\r\n" + DateNoww + "," + TimeNoww + "," + Session["User"].ToString() + "," + pkeq.Text + ",Reverb_Success");

                // flush every 20 seconds as you do it
                File.AppendAllText(filePath + "_" + DateNoww + ".txt", sb.ToString());
                sb.Clear();
                ResultPop("ย้อนกลับสำเร็จ", "success");
                DataBind();
            }
            else
            {
                ResultPop("ล้มเหลว", "error");
            }
        }

        public void ResultPop(string msg, string type)
        {
            switch (type)
            {
                case "success":
                    icon = "add_alert";
                    alertType = "success";
                    break;
                case "error":
                    icon = "error";
                    alertType = "danger";
                    break;
                case "warning":
                    icon = "warning";
                    alertType = "warning";
                    break;
            }
            //alertType = type;
            alert = msg;
        }

        protected void btnReport_Command(object sender, CommandEventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('/Report/reportCM','_newtab');", true);
        }

        protected void ImgImageDocSer_Click(object sender, EventArgs e)
        {
            Fname = Imgfilename.Text;
            DownLoad( Fname );
        }

        public void DownLoad(string FName)
        {
            try
            {
                string strURL = FName;
                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("Content-Disposition", "attachment;filename=\"Download.jpg\"");
                byte[] data = req.DownloadData(Server.MapPath(strURL));
                response.BinaryWrite(data);
                response.End();
            }
            catch
            {

            }
        }
    }

}
