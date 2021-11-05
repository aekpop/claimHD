using ClaimProject.Config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimProject.CM
{
    public partial class CMSurveyForm : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public string EditModal = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/");
            }

            if (!this.IsPostBack)
            {
                
                BindData("");
            }
        }

        void BindData(string key)
        {
            string sql = "";
            string sqlPlus = "";
            if (Session["UserCpoint"].ToString() != "0")
            {
                sqlPlus = "AND c.cpoint_id = '" + Session["UserCpoint"].ToString() + "'";
            }
            try
            {
                sql = "SELECT * FROM tbl_cm_detail cm JOIN tbl_device d ON cm.cm_detail_driver_id = d.device_id JOIN tbl_cpoint c ON cm.cm_cpoint = c.cpoint_id JOIN tbl_location l ON cm.cm_detail_channel = l.locate_id WHERE cm.cm_detail_status_id='1' " + sqlPlus + " ORDER BY STR_TO_DATE(cm.cm_detail_sdate, '%d-%m-%Y'), cm.cm_detail_stime, cm_detail_status_id ASC";
                MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds);
                CMGridView.DataSource = ds.Tables[0];
                CMGridView.DataBind();
                if (ds.Tables[0].Rows.Count == 0) { DivCMGridView.Visible = false; } else { DivCMGridView.Visible = true; }
                //lbCMNull.Text = "พบข้อมูลจำนวน " + ds.Tables[0].Rows.Count + " แถว";
                function.Close();
            }
            catch (Exception e) { e.ToString(); }
            function.Close();
        }

        protected void CMGridView_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    if (btnTimeEditCM.Text != "") { btnTimeEditCM.Text += " น."; }
                }
            }

            LinkButton btnStatusUpdate = (LinkButton)(e.Row.FindControl("btnStatusUpdate"));
            if (btnStatusUpdate != null)
            {
                btnStatusUpdate.CommandName = (string)DataBinder.Eval(e.Row.DataItem, "cm_detail_id").ToString();
            }

            LinkButton btnCancel = (LinkButton)(e.Row.FindControl("btnCancel"));
            if (btnCancel != null)
            {
                btnCancel.CommandName = (string)DataBinder.Eval(e.Row.DataItem, "cm_detail_id").ToString();
            }

            LinkButton lbref = (LinkButton)(e.Row.FindControl("lbref"));
            if (lbref != null)
            {
                lbref.CommandName = DataBinder.Eval(e.Row.DataItem, "cm_detail_id").ToString();
            }

            LinkButton lbCpoint = (LinkButton)(e.Row.FindControl("lbCpoint"));
            if (lbCpoint != null)
            {
                lbCpoint.CommandName = DataBinder.Eval(e.Row.DataItem, "cm_detail_id").ToString();
            }

            LinkButton lbChannel = (LinkButton)(e.Row.FindControl("lbChannel"));
            if (lbChannel != null)
            {
                lbChannel.CommandName = DataBinder.Eval(e.Row.DataItem, "cm_detail_id").ToString();
            }

            LinkButton lbDeviceName = (LinkButton)(e.Row.FindControl("lbDeviceName"));
            if (lbDeviceName != null)
            {
                lbDeviceName.CommandName = DataBinder.Eval(e.Row.DataItem, "cm_detail_id").ToString();
            }

            LinkButton lbtnStatusUpdateModal = (LinkButton)(e.Row.FindControl("lbtnStatusUpdateModal"));
            if (lbtnStatusUpdateModal != null)
            {
                lbtnStatusUpdateModal.CommandName = (string)DataBinder.Eval(e.Row.DataItem, "cm_detail_id").ToString();
            }
        }

        protected void btnStatusUpdate_Command(object sender, CommandEventArgs e)
        {
            string sql = "UPDATE tbl_cm_detail SET cm_detail_status_id = '2' WHERE cm_detail_id = '" + e.CommandName + "'";
            if (function.MySqlQuery(sql))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('อนุมัติข้อมูลสำเร็จ')", true);
                BindData("");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('ล้มเหลวเกิดข้อผิดพลาด')", true);
            }
            function.Close();
        }

        protected void btnCancel_Command(object sender, CommandEventArgs e)
        {
            //string sql = "UPDATE tbl_cm_detail SET cm_detail_edate='',cm_detail_etime='',cm_detail_method ='',cm_detail_status_id = '0' WHERE cm_detail_id = '" + e.CommandName + "'";
            string sql = "UPDATE tbl_cm_detail SET cm_detail_status_id = '0' ,cm_detail_ejdate = '' ,cm_detail_ejtime = '' ,cm_user_endjob = '' ,cm_detail_Service_img = '' " +
                " ,cm_detail_edate = '' ,cm_detail_etime = '' ,cm_detail_eimg = '' ,cm_detail_method = '' WHERE cm_detail_id = '" + e.CommandName + "'";
            if (function.MySqlQuery(sql))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('บันทึกข้อมูลสำเร็จ')", true);
                BindData("");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('ล้มเหลวเกิดข้อผิดพลาด')", true);
            }
            function.Close();

        }

        protected void lbref_Command(object sender, CommandEventArgs e)
        {
            string imgS = "";
            string imgE = "";
            string imgSer = "";
            string lbchkservice = "";
            EditModal = e.CommandName;
            pkeq.Text = EditModal;

            string sqlEdit = "SELECT * FROM tbl_cm_detail c JOIN tbl_device d ON c.cm_detail_driver_id = d.device_id " +
                " JOIN tbl_cpoint e ON c.cm_cpoint = e.cpoint_id JOIN tbl_location f ON c.cm_detail_channel = f.locate_id " +
                " JOIN tbl_user g ON c.cm_user = g.username WHERE cm_detail_id = '"+ pkeq.Text + "' ";

            MySqlDataReader rt = function.MySqlSelect(sqlEdit);
            if(rt.Read())
            {
                if(!rt.IsDBNull(22))
                {
                    imgSer = rt.GetString("cm_detail_Service_img");
                }
                else
                {
                    imgSer = " ";
                }
                imgS = rt.GetString("cm_detail_simg");
                imgE = rt.GetString("cm_detail_eimg");
                ImgEditEQ.ImageUrl = "~" + imgS;
                ImgEditEQE.ImageUrl = "~" + imgE;
                ImgImageDocSer.ImageUrl = "~" + imgSer;
                if(rt.GetString("cm_detail_Chknoservice") == "1")
                {
                    lbchkservice = "แก้ไขเบื้องต้น";
                }                
                lbrefRecheck.Text = rt.GetString("cm_detail_id") + " (" + lbchkservice +") ";
                lbCpointRecheck.Text = rt.GetString("cpoint_name");
                lbPointRecheck.Text = rt.GetString("cm_point");
                lbChannelRecheck.Text = rt.GetString("locate_name");
                lbdeviceRecheck.Text = rt.GetString("device_name");
                lbProblemRecheck.Text = rt.GetString("cm_detail_problem");
                lbMethodRecheck.Text = rt.GetString("cm_detail_method");
                lbNodeRecheck.Text = rt.GetString("cm_detail_note");
                lbDatesRecheck.Text = rt.GetString("cm_detail_sdate");
                lbTimesRecheck.Text = rt.GetString("cm_detail_stime") + " น.";
                lbDateERecheck.Text = rt.GetString("cm_detail_edate");
                lbTimeERecheck.Text = rt.GetString("cm_detail_etime") + " น.";
                lbDateEJRecheck.Text = rt.GetString("cm_detail_ejdate");
                lbTimeEJRecheck.Text = rt.GetString("cm_detail_ejtime") + " น.";
                lbUserRecheck.Text = rt.GetString("name");
                lbUserEJRecheck.Text = rt.GetString("cm_user_endjob");
            }
            rt.Close();
        }

        protected void lbtnStatusUpdateModal_Command(object sender, CommandEventArgs e)
        {
            string sql = "";
            string Chknoservice = "SELECT cm_detail_id,cm_detail_Chknoservice FROM tbl_cm_detail WHERE cm_detail_id = '" + pkeq.Text + "'";
            MySqlDataReader rt = function.MySqlSelect(Chknoservice);
            if (rt.Read())
            {
                string Chk = rt.GetString("cm_detail_Chknoservice");
                if (Chk == "1")
                {
                     sql = "UPDATE tbl_cm_detail SET cm_detail_status_id = '3' WHERE cm_detail_id = '" + pkeq.Text + "'";
                }
                else
                {
                     sql = "UPDATE tbl_cm_detail SET cm_detail_status_id = '2' WHERE cm_detail_id = '" + pkeq.Text + "'";
                }
            }
            rt.Close();

            /*string sql = "UPDATE tbl_cm_detail SET cm_detail_status_id = '2' WHERE cm_detail_id = '" + pkeq.Text + "'";*/
            if (function.MySqlQuery(sql))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('บันทึกข้อมูลสำเร็จ')", true);
                BindData("");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('ล้มเหลวเกิดข้อผิดพลาด')", true);
            }
            function.Close();
        }

        protected void btnCancelModal_Command(object sender, CommandEventArgs e)
        {
            //string sql = "UPDATE tbl_cm_detail SET cm_detail_edate='',cm_detail_etime='',cm_detail_method ='',cm_detail_status_id = '0' WHERE cm_detail_id = '" + pkeq.Text + "'";
            string sql = "UPDATE tbl_cm_detail SET cm_detail_status_id = '0' ,cm_detail_ejdate = '' ,cm_detail_ejtime = '' ,cm_user_endjob = '' " +
                ",cm_detail_Service_img = '' ,cm_detail_edate = '' ,cm_detail_etime = '' ,cm_detail_eimg = '' ,cm_detail_method= '' WHERE cm_detail_id = '" + pkeq.Text + "'";
            if (function.MySqlQuery(sql))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('บันทึกข้อมูลสำเร็จ')", true);
                BindData("");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('ล้มเหลวเกิดข้อผิดพลาด')", true);
            }
            function.Close();
        }

    }
}