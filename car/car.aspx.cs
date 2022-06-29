using ClaimProject.Config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimProject.car
{
    public partial class car : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserPrivilegeId"] == null) { Response.Redirect("/"); }
            if (Session["UserPrivilegeId"].ToString() != "0" && Session["UserPrivilegeId"].ToString() != "1")
            {
                Response.Redirect("/");
            }
            if (!this.IsPostBack)
            {
                BindData("");
                //function.getListItem(txtGroup, "SELECT * FROM tbl_drive_group WHERE driver_group_delete <> 1", "drive_group_name", "drive_group_id");
                //txtGroup.Items.Insert(0, new ListItem("เลือก", ""));
            }
        }
        void BindData(string key)
        {
            string sql = "";
            try
            {
                sql = "SELECT * FROM tbl_brandcar  WHERE brandcar_delete <> 1 AND brandcar_name LIKE '%" + key + "%' ORDER BY brandcar_name ASC";
                MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds);
                CarGridView.DataSource = ds.Tables[0];
                CarGridView.DataBind();
                lbCarNull.Text = "พบข้อมูลจำนวน " + ds.Tables[0].Rows.Count + " แถว";
            }
            catch { }
        }
        protected void CarGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList txtECarGroup = (DropDownList)e.Row.FindControl("txtECarGroup");
                if ((txtECarGroup != null))
                {
                    function.getListItem(txtECarGroup, "SELECT * FROM tbl_drive_group WHERE driver_group_delete <> 1", "drive_group_name", "drive_group_id");
                    txtECarGroup.SelectedIndex = txtECarGroup.Items.IndexOf(txtECarGroup.Items.FindByValue((string)DataBinder.Eval(e.Row.DataItem, "drive_group_id").ToString()));
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    ((LinkButton)e.Row.Cells[4].Controls[0]).OnClientClick = "return confirm('ต้องการลบข้อมูลใช่หรือไม่');";
                }
                catch { }
            }
        }


        protected void btnCarAdd_Click(object sender, EventArgs e)
        {
            //if (txtCarName.Text != "" && txtGroup.SelectedValue != "" && txtSchedule.Text != "")
            //{
            string sql = "INSERT INTO tbl_brandcar (brandcar_name,brandcar_delete) VALUES ('" + txtCarName.Text.Trim() + "','0')";
            string script = "";
            if (function.MySqlQuery(sql))
            {
                script = "บันทึกข้อมูลสำเร็จ";
            }
            else
            {
                script = "Error : บันทึกข้อมูลล้มเหลว";
            }
            function.Close();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('" + script + "')", true);
            CarGridView.EditIndex = -1;
            BindData(txtCarName.Text);
            txtCarName.Text = "";
            //}
            //else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('เพิ่มล้มเหลว < br /> -กรุณาใส่ข้อมูลให้ครบถ้วน')", true);
            }
            ClearData();
        }

        protected void CarGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            CarGridView.EditIndex = e.NewEditIndex;
            BindData(txtSearch.Text);
        }

        protected void CarGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            CarGridView.EditIndex = -1;
            BindData(txtSearch.Text);
        }

        protected void CarGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtECar = (TextBox)CarGridView.Rows[e.RowIndex].FindControl("txtECar");

            string sql = "UPDATE tbl_brandcar SET brandcar_name='" + txtECar.Text + "' WHERE brandcar_id = '" + CarGridView.DataKeys[e.RowIndex].Value + "'";
            string script = "";
            if (function.MySqlQuery(sql))
            {
                script = "แก้ไขข้อมูลสำเร็จ";
            }
            else
            {
                script = "Error : แก้ไขข้อมูลล้มเหลว";
            }
            function.Close();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('" + script + "')", true);
            CarGridView.EditIndex = -1;
            BindData(txtSearch.Text);
            txtSearch.Text = "";
        }

        protected void CarGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sql = "UPDATE tbl_brandcar SET brandcar_delete='1' WHERE brandcar_id = '" + CarGridView.DataKeys[e.RowIndex].Value + "'";
            string script = "";
            if (function.MySqlQuery(sql))
            {
                script = "ลบข้อมูลสำเร็จ";
            }
            else
            {
                script = "Error : ลบข้อมูลล้มเหลว";
            }
            function.Close();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('" + script + "')", true);
            CarGridView.EditIndex = -1;
            BindData(txtSearch.Text);
            txtSearch.Text = "";
        }

        void ClearData()
        {
            txtCarName.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData(txtSearch.Text);
        }
    }

}