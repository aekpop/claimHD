using ClaimProject.Config;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimProject.Techno
{
    public partial class TechnoReport : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public string sql = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/");
            }
            if (!this.IsPostBack)
            {
                int Month = Int32.Parse(DateTime.Now.ToString("MM")) -1;

                ddlselectReport.Items.Insert(0, new ListItem("เลือก", "0"));
                ddlselectReport.Items.Insert(1, new ListItem("รายงานอุบัติเหตุจำแนกตามด่านฯ", "1"));
                ddlselectReport.Items.Insert(2, new ListItem("รายงานอุบัติเหตุจำแนกตามอุปกรณ์", "2"));
                ddlselectReport.Items.Insert(3, new ListItem("ตารางสรุปสถานะอุบัติเหตุ", "3"));

                var month = new CultureInfo("th-TH").DateTimeFormat.MonthNames;
                //month = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
                for (int i = 0; i < month.Length - 1 ; i++)
                {
                    ddlMonth.Items.Add(new ListItem(month[i], i.ToString()));
                }
                ddlMonth.SelectedValue = Month.ToString();

                function.getListItem(ddlbudget, "SELECT claim_budget_year FROM tbl_claim c WHERE c.claim_delete = '0' GROUP BY claim_budget_year ORDER by claim_budget_year DESC", "claim_budget_year", "claim_budget_year");

            }
        }

        void Result()
        {
            if(ddlselectReport.SelectedValue == "1" || ddlselectReport.SelectedValue == "2")
            {
                sql = "SELECT f.`cpoint_name`,COUNT(cpoint_name) as CpointAmount, e.`device_name` , COUNT(device_name) as deviceAmount , device_initials , COUNT(device_initials) as initials " +
                "FROM tbl_claim c INNER JOIN tbl_device_damaged d ON c.claim_id = d.claim_id RIGHT JOIN tbl_device e ON d.`device_id` " +
                "= e.`device_id` JOIN tbl_cpoint f ON f.`cpoint_id` = c.`claim_cpoint` WHERE claim_delete = '0' AND(claim_month = '" + ddlMonth.SelectedItem + "' " +
                "AND c.`claim_budget_year` = '" + ddlbudget.SelectedValue + "') GROUP BY claim_cpoint, d.device_id ORDER BY claim_cpoint ";

            }
            else if (ddlselectReport.SelectedValue == "3")
            {
                sql = "SELECT ci.claim_auto_id AS ID, cp.cpoint_name AS toll , cc.claim_detail_cb_claim AS channel , c.claim_equipment AS cname , cc.`claim_detail_license_plate` AS plate, cc.`claim_detail_province` AS prov,c.`claim_start_date` AS sdate, c.`claim_cpoint_note` AS snum, cd.`claim_doc_date` AS docdate ,cd.claim_doc_num AS docnum , cd.techno_doc_date AS redate ,cd.techno_doc_num AS renum ,cd.Estimate_date AS esdate ,cd.Estimate_num AS esnum ,cd.appoint_date AS apdate ,cd.appoint_num AS apnum " +
                    " FROM `tbl_claim` c LEFT JOIN `tbl_claim_doc` cd ON c.`claim_id` = cd.`claim_doc_id` LEFT JOIN `tbl_claim_com` cc ON c.`claim_id` = cc.`claim_id` LEFT JOIN `tbl_cpoint` cp ON c.`claim_cpoint` = cp.`cpoint_id`" +
                    " LEFT JOIN tbl_claim_auto_id ci ON c.`claim_id` = ci.claim_id WHERE (c.claim_month = '" + ddlMonth.SelectedItem + "' AND c.`claim_budget_year` = '" + ddlbudget.SelectedValue + "') AND c.claim_delete = '0' " +
                    " ORDER BY STR_TO_DATE(claim_cpoint_date, '%d-%m-%Y') ASC";
            }
        }

        protected void ddlselectReport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnResultReport_Command(object sender, CommandEventArgs e)
        {
            Result();
            Session.Add("SqlResult", sql);
            Session.Add("Month", ddlMonth.SelectedItem);
            Session.Add("Budget", ddlbudget.SelectedItem);

            if(ddlselectReport.SelectedValue == "1")
            {
                Session.Add("report", 1);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('/Report/reportMonthlyClaim','_newtab');", true);
            }
            else if(ddlselectReport.SelectedValue == "2")
            {
                Session.Add("report", 2);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('/Report/reportMonthlyClaim','_newtab');", true);
            }
            else if (ddlselectReport.SelectedValue == "3")
            {
                Session.Add("report", 3);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('/Report/reportIndexMatrixClaim','_newtab');", true);
            }

        }
    }
}