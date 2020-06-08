using System;
using ClaimProject.Config;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace ClaimProject.equip
{
    public partial class EquipTranOutList : System.Web.UI.Page
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
                function.getListItem(ddlsearchType, "select * from tbl_toll where in_outdepart ='1' order by toll_id ASC", "toll_name", "toll_id");
                PagingLoad();
            }

        }


        protected void PagingLoad()
        {
            string bindGrid = "SELECT * FROM tbl_transfer " +
                         " JOIN tbl_transfer_status on tbl_transfer.trans_stat = tbl_transfer_status.trans_stat_id" +
                         " JOIN tbl_toll on tbl_toll.toll_id = tbl_transfer.toll_send " +
                         " JOIN tbl_trans_complete on tbl_trans_complete.complete_id = tbl_transfer.complete_stat ";
            string reff = txtRefTran.Text; string comp = ddlsearchType.SelectedValue;
            string dateGet = txtDateget.Text;

            if (Session["UserCpoint"].ToString() == "0")
            {
                bindGrid += " WHERE (toll_recieve = '9200' OR toll_recieve = '9300' OR toll_recieve = '9400' OR toll_recieve = '9500')  ";
            }
            else
            {
                if (Session["UserCpoint"].ToString() == "701")
                {
                    bindGrid += "WHERE toll_recieve ='7010'  ";
                }
                else if (Session["UserCpoint"].ToString() == "702")
                {
                    bindGrid += "WHERE toll_recieve ='7020'   ";
                }
                else if (Session["UserCpoint"].ToString() == "703")
                {
                    bindGrid += "WHERE (toll_recieve ='7031' or toll_recieve ='7032' or toll_recieve ='7033' ) ";
                }
                else if (Session["UserCpoint"].ToString() == "704")
                {
                    bindGrid += "WHERE (toll_recieve ='7041' or toll_recieve ='7042' ) ";
                }
                else if (Session["UserCpoint"].ToString() == "706")
                {
                    bindGrid += "WHERE (toll_recieve ='7051' or toll_recieve ='7052' ) ";
                }
                else if (Session["UserCpoint"].ToString() == "707")
                {
                    bindGrid += "WHERE ( toll_recieve ='7061' or toll_recieve ='7062' " +
                        "or toll_recieve ='7063' or toll_recieve ='7064' )";
                }
                else if (Session["UserCpoint"].ToString() == "708")
                {
                    bindGrid += "WHERE (toll_recieve ='7071' or toll_recieve ='7072' " +
                        "or toll_recieve ='7073' or toll_recieve ='7074' or toll_recieve ='7075' " +
                        "or toll_recieve ='7076' ) ";
                }
                else if (Session["UserCpoint"].ToString() == "709")
                {
                    bindGrid += "WHERE (toll_recieve ='7081' or toll_recieve ='7082' " +
                        "or toll_recieve ='7083' or toll_recieve ='7084' )";
                }
                else if (Session["UserCpoint"].ToString() == "710")
                {
                    bindGrid += "WHERE toll_recieve ='7090'  ";
                }
                else if (Session["UserCpoint"].ToString() == "711")
                {
                    bindGrid += "WHERE toll_recieve ='7100'  ";
                }
                else if (Session["UserCpoint"].ToString() == "712")
                {
                    bindGrid += "WHERE toll_recieve ='7110'  ";
                }
                else if (Session["UserCpoint"].ToString() == "713")
                {
                    bindGrid += "WHERE toll_recieve ='7120'  ";
                }
                else if (Session["UserCpoint"].ToString() == "902")
                {
                    bindGrid += "WHERE toll_recieve ='9010'  ";
                }
                else if (Session["UserCpoint"].ToString() == "903")
                {
                    bindGrid += "WHERE toll_recieve ='9020'  ";
                }
                else if (Session["UserCpoint"].ToString() == "904")
                {
                    bindGrid += "WHERE toll_recieve ='9030'  ";
                }
                else if (Session["UserCpoint"].ToString() == "905")
                {
                    bindGrid += "WHERE toll_recieve ='9040'  ";
                }

            }



            if (reff != "")
            {
                if(dateGet != "")
                {
                    if (comp != "")
                    {
                        bindGrid += " AND in_outdepart='1' AND toll_send = '" + comp+ "' AND trans_id like '%"+reff+ "%' AND date_send = '"+dateGet+ "' order by date_send DESC ";
                    }
                    else
                    {
                        bindGrid += " AND in_outdepart='1' AND  trans_id like '%" + reff + "%' AND date_send = '" + dateGet + "' order by date_send DESC ";
                    }
                }
                else
                {
                    if (comp != "")
                    {
                        bindGrid += " AND in_outdepart='1' AND toll_send = '" + comp + "' AND trans_id like '%" + reff + "%' order by date_send DESC ";
                    }
                    else
                    {
                        bindGrid += " AND in_outdepart='1' AND  trans_id like '%" + reff + "%'  order by date_send DESC ";
                    }
                }
            }
            else
            {
                if (dateGet != "")
                {
                    if (comp != "")
                    {
                        bindGrid += " AND in_outdepart='1' AND toll_send = '" + comp + "'  AND date_send = '" + dateGet + "' order by date_send DESC ";
                    }
                    else
                    {
                        bindGrid += " AND in_outdepart='1' AND  date_send = '" + dateGet + "' order by date_send DESC ";
                    }
                }
                else
                {
                    if (comp != "")
                    {
                        bindGrid += " AND in_outdepart='1' AND toll_send = '" + comp + "'   order by date_send DESC ";
                    }
                    else
                    {
                        bindGrid += " AND in_outdepart='1'   order by date_send DESC ";
                    }
                }
            }


            MySqlDataAdapter da = function.MySqlSelectDataSet(bindGrid);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            gridOutget.DataSource = ds.Tables[0];
            lbresult.Text = "พบ "+(ds.Tables[0].Rows.Count).ToString() + " รายการ";
        }
        protected void gridOutget_RowDataBound(object sender, GridViewRowEventArgs e)
        {


        }

        protected void btnMainEQQ_Click(object sender, EventArgs e)
        {
            Response.Redirect("/equip/EquipMain.aspx");
        }

        protected void btnnewGetOut_Click(object sender, EventArgs e)
        {
            string pkCode = "";
            string cpoint = Session["UserCpoint"].ToString();
            if (cpoint.Length < 3)
            {
                cpoint = "10" + cpoint;
            }

            while (pkCode == "")
            {
                pkCode = function.GenTransferPK(int.Parse(cpoint));
            }

            if (pkCode != "")
            {
                Session["TransOutID"] = pkCode;
                Session["TransOutNew"] = "0";
                Response.Redirect("/equip/EquipTranGetout");
            }

            
        }

        protected void lbtnSearchGet_Command(object sender, CommandEventArgs e)
        {


        }

        protected void lbtntrans_Command(object sender, CommandEventArgs e)
        {


        }
    }
}