using System;
using ClaimProject.Config;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Web.UI.HtmlControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO;
//test
namespace ClaimProject.equip
{
    public partial class EquipAddAll : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/");
            }
            if (!this.IsPostBack)
            {
                Session["NewEQPK"] = "";
                Session["NewEQPKtype"] = "";
                LoadPaging();
            }
        }

        protected void LoadPaging()
        {
            string gridload = "select * from tbl_newequipment " +
                " join tbl_toll on tbl_toll.toll_id = tbl_newequipment.AddCpoint " +
                " join tbl_user on tbl_user.username =  tbl_newequipment.NewEQ_User " +
                " where NewEQ_User = '" + Session["User"].ToString() + "' order by NewEQ_Date DESC";
            MySqlDataAdapter da = function.MySqlSelectDataSet(gridload);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            GridAddAll.DataSource = ds.Tables[0];
            GridAddAll.DataBind();

            string username = Session["User"].ToString();
            string EQsearch = "SELECT * FROM tbl_toll WHERE ";
            if (username == "sawitree")
            {
                EQsearch += " toll_EQGroup = '1' Order By toll_id ASC ";
                function.getListItem(ddlserchToll, EQsearch, "toll_name", "toll_id");

            }
            else if (username == "supaporn")
            {
                EQsearch += " toll_EQGroup = '2' Order By toll_id ASC ";
                function.getListItem(ddlserchToll, EQsearch, "toll_name", "toll_id");
            }
            else if (username == "watcharee")
            {
                EQsearch += " toll_EQGroup = '3' Order By toll_id ASC ";
                function.getListItem(ddlserchToll, EQsearch, "toll_name", "toll_id");
            }
            else
            {
                function.getListItem(ddlserchToll, "SELECT * FROM tbl_toll Order By toll_id ASC", "toll_name", "toll_id");
            }

            ddlserchToll.Items.Insert(0, new ListItem("ทุกด่าน", "0"));

        }

        protected void GridAddAll_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            LinkButton lbtneditAdd = (LinkButton)(e.Row.FindControl("lbtneditAdd"));
            if (lbtneditAdd != null)
            {
                lbtneditAdd.CommandName = (string)DataBinder.Eval(e.Row.DataItem, "NewEQ_id").ToString();
            }

        }
        protected void lbtneditAdd_Command(object sender, CommandEventArgs e)
        {
            Session["NewEQPK"] = e.CommandName;
            Session["NewEQPKtype"] = "old";
            Response.Redirect("/equip/EquipAddList.aspx");
        }

        protected void btnsearchAdd_Click(object sender, EventArgs e)
        {
            string searchbtn = "select * from tbl_newequipment " +
                " join tbl_toll on tbl_toll.toll_id = tbl_newequipment.AddCpoint " +
                " join tbl_user on tbl_user.username =  tbl_newequipment.NewEQ_User ";
            if(txtDatestart.Text != "")//เลือกวันที่
            {
                
                    if(ddlserchToll.SelectedValue != "0")//เลือกด่าน
                    {
                        searchbtn += " where NewEQ_Date like '%"+ txtDatestart.Text + "%'" +
                            "AND  AddCpoint ='"+ ddlserchToll.SelectedValue + "' ";
                    }
                    else//เลือกด่านทั้งหมด
                    {
                        searchbtn += " where  NewEQ_Date like '%" + txtDatestart.Text + "%' ";
                    }

                
            }
            else //ไม่เลือกวันที่
            {

                    if (ddlserchToll.SelectedValue != "0")//เลือกด่าน
                    {
                        searchbtn += " where AddCpoint ='" + ddlserchToll.SelectedValue + "' ";
                    }
                    else//เลือกด่านทั้งหมด
                    {
                        
                    }
                
            }
            
            if (Session["User"].ToString() != "watcharee" && Session["User"].ToString() != "supaporn" && Session["User"].ToString() != "sawitree")
            {
                searchbtn += " order by NewEQ_Date DESC";
            }
            else
            {
                searchbtn += " AND NewEQ_User = '" + Session["User"].ToString() + "' order by NewEQ_Date DESC ";
            }

            MySqlDataAdapter da = function.MySqlSelectDataSet(searchbtn);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            GridAddAll.DataSource = ds.Tables[0];
            GridAddAll.DataBind();
            //(ds.Tables[0].Rows.Count).ToString()
            lbamountEQ.Text = "พบ " + (ds.Tables[0].Rows.Count).ToString() + " รายการ" ;
        }

        protected void btnSagain_Click(object sender, EventArgs e)
        {

        }

        protected void btnBackHomeADDEQ_Click(object sender, EventArgs e)
        {
            Response.Redirect("/equip/EquipMain.aspx");
        }

        protected void btnCreatenew_Click(object sender, EventArgs e)
        {
            string pkCode = "";
            string cpoint = Session["UserCpoint"].ToString();
            if (cpoint.Length < 3)
            {
                cpoint = "50" + cpoint;
            }

            while (pkCode == "")
            {
                pkCode = function.GenAddNewEQPK(int.Parse(cpoint));
            }

            if (pkCode != "")
            {
                Session["NewEQPK"] = pkCode;
                Session["NewEQPKtype"] = "new";
                Response.Redirect("/equip/EquipAddList.aspx");
            }

        }
    }
}