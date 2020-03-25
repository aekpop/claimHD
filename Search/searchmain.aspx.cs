using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using ClaimProject.Config;

namespace ClaimProject.Search
{
    public partial class searchmain : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public string alert = "";
        public string alertType = "";
        public string icon = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/");
            }
            if (!this.IsPostBack)
            {
                Session.Add("SearchCar", "");
            }
        }
        protected void btnSplateagain_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Search/searchmain.aspx");
        }

        protected void btnsPlate_Click(object sender, EventArgs e)
        {
            divSagain.Visible = true;
            divSearchplate.Visible = false;

            string searchCar = "SELECT * FROM tbl_search_plate WHERE ";
            if(txtSplate.Text == "")
            {
                if(txtSBrand.Text == "")
                {
                    if(txtSSeries.Text == "")
                    {
                        searchCar += " order by plate_id DESC ";
                        Session["SearchCar"] = searchCar.ToString();
                        DatabindSearch(Session["SearchCar"].ToString());
                    }
                    else
                    {
                        ResultPop("Error : กรุณาใส่ข้อความค้นหาอย่างน้อย 1 รายการ ", "error");
                    }
                }
                else
                {
                    if (txtSSeries.Text == "")
                    {
                        searchCar += "brand like '%"+txtSBrand.Text+ "%' order by plate_id DESC ";
                        Session["SearchCar"] = searchCar.ToString();
                    }
                    else
                    {
                        searchCar += "brand like '%" + txtSBrand.Text + "%' AND series like '%" + txtSSeries.Text + "%' order by plate_id DESC ";
                        Session["SearchCar"] = searchCar.ToString();
                    }
                    DatabindSearch(Session["SearchCar"].ToString());
                }
                
            }
            else
            {
                if (txtSBrand.Text == "")
                {
                    if (txtSSeries.Text == "")
                    {
                        searchCar += " license_no like '%"+txtSplate.Text+"%' order by plate_id DESC ";
                        Session["SearchCar"] = searchCar.ToString();
                    }
                    else
                    {
                        searchCar += " license_no like '%" + txtSplate.Text + "%' AND series like '%" + txtSSeries.Text + "%' order by plate_id DESC ";
                        Session["SearchCar"] = searchCar.ToString();
                    }
                    DatabindSearch(Session["SearchCar"].ToString());
                }
                else
                {
                    if (txtSSeries.Text == "")
                    {
                        searchCar += " license_no like '%" + txtSplate.Text + "%' AND brand like '%"+txtSBrand.Text+"%' order by plate_id DESC ";
                        Session["SearchCar"] = searchCar.ToString();
                    }
                    else
                    {
                        searchCar += " license_no like '%" + txtSplate.Text + "%' AND brand like '%" + txtSBrand.Text + "%' AND series like '%" + txtSSeries.Text + "%' order by plate_id DESC ";
                        Session["SearchCar"] = searchCar.ToString();
                    }
                    DatabindSearch(Session["SearchCar"].ToString());
                }
            }


        }
        void DatabindSearch (string qry)
        {
            MySqlDataAdapter da = function.MySqlSelectDataSet(qry);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            gridsearchcar.DataSource = ds.Tables[0];
            string ccount = (ds.Tables[0].Rows.Count).ToString();
            titlegridd.Text = "ผลการค้นหา เลขทะเบียน: " + txtSplate.Text + " | ยี่ห้อ: " + txtSBrand.Text + " | รุ่น: " + txtSSeries.Text + "  พบ " + ccount + " รายการ";
            titlegridd.Visible = true;
            gridsearchcar.DataBind();
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

        protected void gridsearchcar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbnumcar = (Label)(e.Row.FindControl("lbnumcar"));
            if (lbnumcar != null)
            {
                lbnumcar.Text = (gridsearchcar.Rows.Count + 1).ToString() + ".";
            }
        }
    }
}