﻿using ClaimProject.Config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimProject
{
    public partial class _Default : Page
    {
        ClaimFunction function = new ClaimFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                if (!function.CheckLevel("Department",Session["UserPrivilegeId"].ToString()))
                {
                    if(Session["UserPrivilegeId"].ToString() == "5")
                    {
                        Response.Redirect("/equip/EquipMain");
                    }
                    else
                    {
                        Response.Redirect("/Claim/DefaultClaim");
                    }

                }
                else
                {
                    if (Session["UserPrivilegeId"].ToString() == "4")
                    {
                        Response.Redirect("/Claim/DefaultClaim");
                    }                    
                }
            }

            if (!this.IsPostBack)
            {
                string date = DateTime.Now.ToString("dd-MM") + "-" + (DateTime.Now.Year + 543);
                function.getListItem(txtYear, "SELECT claim_budget_year FROM tbl_claim c WHERE c.claim_delete = '0' GROUP BY claim_budget_year ORDER by claim_budget_year DESC", "claim_budget_year", "claim_budget_year");
                try { txtYear.SelectedValue = function.getBudgetYear(date); } catch { }
                getBind(txtYear.SelectedValue);
            }
        }

        private void getStatusAmount(Label label, int status, string year)
        {
            string sql = "SELECT COUNT(*) AS count_num FROM tbl_claim c " +
                         " JOIN tbl_cpoint ON claim_cpoint = cpoint_id " +
                         " JOIN tbl_status ON status_id = claim_status " +
                         "  LEFT JOIN tbl_user ON username = claim_user_start_claim " +
                         " JOIN tbl_status_detail sd ON sd.detail_claim_id = c.claim_id AND sd.detail_status_id = c.claim_status WHERE claim_delete = '0' AND c.claim_status = '" + status + "' AND c.claim_budget_year = '" + year + "'";
            MySqlDataReader rs = function.MySqlSelect(sql);
            if (rs.Read())
            {
                label.Text = rs.GetString("count_num");
            }
            else
            {
                label.Text = "0";
            }
            rs.Close();
            function.Close();
            function.conn.Close();
        }

        private void getBind(string year)
        {
            getStatusAmount(lbAlert, 1, year);
            getStatusAmount(lbQuote, 3, year);
            getStatusAmount(lbSend, 2, year);
            getStatusAmount(lbRepair, 4, year);
            getStatusAmount(lbSuccess, 5, year);
            getStatusAmount(lbReport, 6, year);
        }

        protected void txtYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            getBind(txtYear.SelectedItem.Text);
        }

        protected void btnDetailAlert_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Techno/TechnoFormView?s=1&y=" + txtYear.SelectedValue);
        }

        protected void btnDetailQute_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Techno/TechnoFormView?s=3&y=" + txtYear.SelectedValue);
        }

        protected void btnSendto_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Techno/TechnoFormView?s=2&y=" + txtYear.SelectedValue);
        }

        protected void btnWait_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Techno/TechnoFormView?s=4&y=" + txtYear.SelectedValue);
        }

        protected void btnSuccessJob_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Techno/TechnoFormView?s=5&y=" + txtYear.SelectedValue);
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Techno/TechnoFormView?s=6&y=" + txtYear.SelectedValue);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SreviceLine.WebService_Server serviceLine = new SreviceLine.WebService_Server();
            serviceLine.MessageToServer(DropDownList1.SelectedValue, TextBox1.Text /*+ DropDownList1.SelectedValue.ToString()*/, TextBox2.Text.Trim(), 1,430);
            TextBox1.Text = "";
            TextBox2.Text = "";

            //function.LineNotify(DropDownList1.SelectedValue, TextBox1.Text.Trim(), TextBox2.Text.Trim(),1,430);
            //TextBox1.Text = "";
            //TextBox2.Text = "";
        }

        protected void btnSearch_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("/Techno/TechnoFormView?r=" + txtsearch.Text);
        }
    }
}