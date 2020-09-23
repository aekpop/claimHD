using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClaimProject.Config;
using MySql.Data.MySqlClient;

namespace ClaimProject.Claim
{
    public partial class claimLine : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public string colortoll = "0";
        public string AnnexZZ = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/");
            }

            if (!this.IsPostBack)
            {
                function.getListItem(ddlClaimBudget, "SELECT cm_budget FROM tbl_cm_detail  GROUP BY cm_budget ORDER by cm_budget DESC", "cm_budget", "cm_budget");

                string sql = "";
                if (function.CheckLevel("Department", Session["UserPrivilegeId"].ToString()))
                {
                    sql = "SELECT * FROM tbl_cpoint ORDER BY cpoint_id";
                    function.getListItem(ddlClaimLine, sql, "cpoint_name", "cpoint_id");

                }
                else
                {
                    sql = "SELECT * FROM tbl_cpoint WHERE cpoint_id = '" + Session["UserCpoint"].ToString() + "'";
                    function.getListItem(ddlClaimLine, sql, "cpoint_name", "cpoint_id");

                }
                ddlClaimLine.Items.Insert(0, new ListItem("เลือกด่านฯ", "0"));
            }
        }

        public void Binddee()
        {
            string cpointt = ddlClaimLine.SelectedValue;
            colortoll = cpointt;
            AnnexZZ = ddlAnnex.SelectedValue;
            {
                if (lbBuild.Visible == true)
                {
                    string sqlchN = "SELECT COUNT(*) AS num FROM tbl_cm_detail cm JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                    " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                    " JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id " +
                    " WHERE cm.cm_detail_status_id='0'   AND c.cpoint_id = '" + cpointt + "' AND cm.cm_point LIKE '%" + ddlAnnex.SelectedValue + "%' " +
                    " AND cm.cm_budget = '" + ddlClaimBudget.SelectedValue + "' ORDER BY STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC";
                    string sql = "SELECT * FROM tbl_cm_detail cm JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id " +
                    " JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id " +
                    " JOIN tbl_location n ON cm.cm_detail_channel = n.locate_id " +
                    " WHERE cm.cm_detail_status_id='0'   AND c.cpoint_id = '" + cpointt + "' AND cm.cm_point LIKE '%" + ddlAnnex.SelectedValue + "%' " +
                    " AND cm.cm_budget = '" + ddlClaimBudget.SelectedValue + "' ORDER BY STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y') DESC";
                    MySqlDataReader chK = function.MySqlSelect(sqlchN);
                    if (chK.Read())
                    {
                        if (chK.GetInt32("num") != 0)
                        {
                            MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
                            System.Data.DataSet ds = new System.Data.DataSet();
                            da.Fill(ds);
                            gridClaimLine.DataSource = ds.Tables[0];
                            gridClaimLine.DataBind();
                        }
                        else
                        {
                            // สร้าง ตารางเสมือน Datatableพร้อม กำหนดฟิล
                            DataTable dtt = new DataTable();
                            dtt.Columns.Add(new DataColumn("cm_detail_id", typeof(string)));
                            dtt.Columns.Add(new DataColumn("cm_detail_sdate", typeof(string)));
                            dtt.Columns.Add(new DataColumn("cm_detail_stime", typeof(string)));
                            dtt.Columns.Add(new DataColumn("locate_name", typeof(string)));
                            dtt.Columns.Add(new DataColumn("device_name", typeof(string)));
                            dtt.Columns.Add(new DataColumn("cm_detail_problem", typeof(string)));
                            dtt.Columns.Add(new DataColumn("cm_detail_status_id", typeof(string)));
                            //สร้าง Row เสมือน Datarow เพื่อเป็นแถวของ Datatable
                            DataRow drr = null;
                            // สร้างแถวใหม่พร้อมกำหนดค่าลงไป
                            drr = dtt.NewRow();
                            drr["cm_detail_id"] = string.Empty;
                            drr["cm_detail_sdate"] = string.Empty;
                            drr["cm_detail_stime"] = string.Empty;
                            drr["locate_name"] = string.Empty;
                            drr["device_name"] = " ไม่มีอุปกรณ์เสียหาย ";
                            drr["cm_detail_problem"] = string.Empty;
                            drr["cm_detail_status_id"] = string.Empty;
                            dtt.Rows.Add(drr);
                            gridClaimLine.DataSource = dtt;
                            gridClaimLine.DataBind();
                        }
                    }


                }
                else
                {
                    string sqlchNN = "SELECT COUNT(*) AS num FROM tbl_claim cl JOIN  tbl_cpoint cp ON cl.claim_cpoint = cp.cpoint_id " +
                                     "JOIN tbl_device_damaged d ON d.claim_id = cl.claim_id JOIN tbl_claim_com t ON cl.claim_id = t.claim_id " +
                                     "JOIN tbl_device v ON v.device_id = d.device_id JOIN tbl_status s ON cl.claim_status = s.status_id " +
                    " WHERE cl.claim_status BETWEEN 1 AND 4 AND cp.cpoint_id = '" + cpointt + "'  " +
                    " AND cl.claim_budget_year = '" + ddlClaimBudget.SelectedValue + "' ORDER BY STR_TO_DATE(cl.claim_start_date, '%d-%m-%Y') DESC";
                    string sql = "SELECT * FROM tbl_claim cl JOIN  tbl_cpoint cp ON cl.claim_cpoint = cp.cpoint_id " +
                                     "JOIN tbl_device_damaged d ON d.claim_id = cl.claim_id JOIN tbl_claim_com t ON cl.claim_id = t.claim_id " +
                                     "JOIN tbl_device v ON v.device_id = d.device_id JOIN tbl_status s ON cl.claim_status = s.status_id " +
                    " WHERE cl.claim_status BETWEEN 1 AND 4 AND cp.cpoint_id = '" + cpointt + "'  " +
                    " AND cl.claim_budget_year = '" + ddlClaimBudget.SelectedValue + "' ORDER BY STR_TO_DATE(cl.claim_start_date, '%d-%m-%Y') DESC";
                    MySqlDataReader chKNN = function.MySqlSelect(sqlchNN);
                    if (chKNN.Read())
                    {
                        if (chKNN.GetInt32("num") != 0)
                        {

                            MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
                            System.Data.DataSet ds = new System.Data.DataSet();
                            da.Fill(ds);
                            gridClaimLine.DataSource = ds.Tables[0];
                            gridClaimLine.DataBind();
                        }
                        else
                        {
                            // สร้าง ตารางเสมือน Datatableพร้อม กำหนดฟิล
                            DataTable dtt = new DataTable();
                            dtt.Columns.Add(new DataColumn("cm_detail_id", typeof(string)));
                            dtt.Columns.Add(new DataColumn("cm_detail_sdate", typeof(string)));
                            dtt.Columns.Add(new DataColumn("cm_detail_stime", typeof(string)));
                            dtt.Columns.Add(new DataColumn("locate_name", typeof(string)));
                            dtt.Columns.Add(new DataColumn("device_name", typeof(string)));
                            dtt.Columns.Add(new DataColumn("cm_detail_problem", typeof(string)));
                            dtt.Columns.Add(new DataColumn("cm_detail_status_id", typeof(string)));
                            //สร้าง Row เสมือน Datarow เพื่อเป็นแถวของ Datatable
                            DataRow drr = null;
                            // สร้างแถวใหม่พร้อมกำหนดค่าลงไป
                            drr = dtt.NewRow();
                            drr["cm_detail_id"] = string.Empty;
                            drr["cm_detail_sdate"] = string.Empty;
                            drr["cm_detail_stime"] = string.Empty;
                            drr["locate_name"] = string.Empty;
                            drr["device_name"] = " ไม่มีอุปกรณ์เสียหาย ";
                            drr["cm_detail_problem"] = string.Empty;
                            drr["cm_detail_status_id"] = string.Empty;
                            dtt.Rows.Add(drr);
                            gridClaimLine.DataSource = dtt;
                            gridClaimLine.DataBind();
                        }
                    }
                }

            }
        }

        protected void ddlClaimLine_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Claim/DefaultClaim.aspx");
        }

        protected void btnrecm_Click(object sender, EventArgs e)
        {
            Binddee();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {

        }

        protected void printimg_Click(object sender, EventArgs e)
        {

        }

        protected void gridClaimLine_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbnoo = (Label)(e.Row.FindControl("lbnoo"));
            if (lbnoo != null)
            {
                lbnoo.Text = (gridClaimLine.Rows.Count + 1).ToString() + ".";
            }       
        }

        protected void gridClaimLine_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }
    }
}