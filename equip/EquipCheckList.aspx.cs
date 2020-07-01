﻿using System;
using ClaimProject.Config;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
namespace ClaimProject.equip
{
    public partial class EquipCheckList : System.Web.UI.Page
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
                Session.Add("CheckTran", "");
                LoadPaging();
            }
        }

        protected void LoadPaging()
        {
            //ddlsearchType   ddlsearchStat
            function.getListItem(ddlsearchType, "select * from tbl_transfer_status order by trans_stat_id ASC", "trans_stat_name", "trans_stat_id");
            function.getListItem(ddlsearchStat, "select * from tbl_trans_complete where complete_id != '1' AND complete_id != '4' AND complete_id != '5' order by complete_id ASC ", "complete_name", "complete_id");
            string who = Session["User"].ToString();
            if(who == "watcharee")
            {
                function.getListItem(ddlsearchEndToll, "select * from tbl_cpoint where eq_gr = '3' and eq_gr = '0' order by cpoint_id ASC ", "cpoint_name", "cpoint_id");
                
            }
            else if(who == "sawitree")
            {
                function.getListItem(ddlsearchEndToll, "select * from tbl_cpoint where eq_gr = '1' and eq_gr = '0' order by cpoint_id ASC ", "cpoint_name", "cpoint_id");
            }
            else if(who == "supaporn")
            {
                function.getListItem(ddlsearchEndToll, "select * from tbl_cpoint where eq_gr = '2' and eq_gr = '0' order by cpoint_id ASC ", "cpoint_name", "cpoint_id");
            }
            else //อื่นๆในฝ่าย
            {
                function.getListItem(ddlsearchEndToll, "select * from tbl_cpoint  order by cpoint_id ASC ", "cpoint_name", "cpoint_id");
            }
            ddlsearchEndToll.Items.Insert(0, new ListItem("ทั้งหมด", "0"));
            ddlsearchStat.Items.Insert(0, new ListItem("ทั้งหมด", "0"));
            ddlsearchType.Items.Insert(0, new ListItem("ทั้งหมด", "0"));
            showannex();
            bindSearch();
        }

        protected void bindSearch ()
        {
            string annexValue = ddlannex.SelectedValue;
            string cpointValue = ddlsearchEndToll.SelectedValue;
            string StatusValue = ddlsearchStat.SelectedValue;
            string typeValue = ddlsearchType.SelectedValue;
            string RefText = txtRefTran.Text;
            string tollid = "";
            string whos = Session["User"].ToString();
            if (typeValue == "0")//ทุกประเภท
            {
                if (RefText == "") //ไม่ระบุเลขอ้างอิง
                {
                    if (cpointValue == "0")//ทุกด่าน
                    {
                        if (StatusValue == "0")//ทุกสถานะเอกสาร
                        {
                            if (annexValue == "0")//เลือกทุกอาคาร
                            {
                                if(whos != "watcharee" && whos != "sawitree" && whos != "supaporn")
                                {
                                    tollid = "where complete_stat != '1' order by complete_stat ASC";
                                }
                                else
                                {
                                    tollid += " where " + finalwhere(annexValue, cpointValue);
                                }
                                
                            }
                            else  //เลือกอาคาร
                            {
                                if (whos != "watcharee" && whos != "sawitree" && whos != "supaporn")
                                {
                                    tollid = " where toll_send = '"+annexValue+ "'  order by complete_stat ASC";
                                }
                                    tollid += " where "+ finalwhere(annexValue, cpointValue);
                            }

                        }
                        else //เลือกสถานะเอกสาร
                        {
                            tollid += " WHERE complete_stat = '"+StatusValue+"' ";
                            if (annexValue == "0")//เลือกทุกด่านฯ
                            {
                                tollid +=  finalwhere(annexValue, cpointValue);
                            }
                            else  //เลือกอาคาร
                            {
                                tollid +=  finalwhere(annexValue, cpointValue);
                            }
                        }
                    }
                    else //เลือกด่านฯ
                    {
                        if (StatusValue == "0")//ทุกสถานะเอกสาร
                        {
                            if (annexValue == "0")//เลือกทุกด่านฯ
                            {
                                tollid += " where " + finalwhere(annexValue, cpointValue);
                            }
                            else  //เลือกอาคาร
                            {
                                tollid += " where " + finalwhere(annexValue, cpointValue);
                            }

                        }
                        else //เลือกสถานะเอกสาร
                        {
                            tollid += " WHERE complete_stat = '" + StatusValue + "' AND ";
                            if (annexValue == "0")//เลือกทุกด่านฯ
                            {
                                tollid += finalwhere(annexValue, cpointValue);
                            }
                            else  //เลือกอาคาร
                            {
                                tollid += finalwhere(annexValue, cpointValue);
                            }
                        }
                    }
                    
                }
                else  //ระบุเลขอ้างอิง
                {
                    tollid += "where trans_id Like '%" + RefText + "%' AND ";
                    if (cpointValue == "0")//ทุกด่าน
                    {
                        if (StatusValue == "0")//ทุกสถานะเอกสาร
                        {
                            if (annexValue == "0")//เลือกทุกด่านฯ
                            {
                                tollid +=  finalwhere(annexValue, cpointValue);
                            }
                            else  //เลือกอาคาร
                            {
                                tollid +=  finalwhere(annexValue, cpointValue);
                            }

                        }
                        else //เลือกสถานะเอกสาร
                        {
                            tollid += " complete_stat = '" + StatusValue + "' AND ";
                            
                            tollid += finalwhere(annexValue, cpointValue);
                            
                        }
                    }
                    else //เลือกด่านฯ
                    {
                        if (StatusValue == "0")//ทุกสถานะเอกสาร
                        {
                                tollid +=  finalwhere(annexValue, cpointValue);
                        }
                        else //เลือกสถานะเอกสาร
                        {
                            tollid += "  complete_stat = '" + StatusValue + "' AND ";
                            
                            tollid += finalwhere(annexValue, cpointValue);
                            
                        }
                    }
                }
            }
            else //เลือกประเภทโอนย้าย
            {
                tollid += " where trans_stat= '"+typeValue+"' AND ";
                if (RefText == "") //ไม่ระบุเลขอ้างอิง
                {
                    if (cpointValue == "0")//ทุกด่าน
                    {
                        if (StatusValue == "0")//ทุกสถานะเอกสาร
                        {
                            
                            tollid +=  finalwhere(annexValue, cpointValue);

                        }
                        else //เลือกสถานะเอกสาร
                        {
                            tollid += "  complete_stat = '" + StatusValue + "' AND ";
                            tollid += finalwhere(annexValue, cpointValue);
                            
                        }
                    }
                    else //เลือกด่านฯ
                    {
                        if (StatusValue == "0")//ทุกสถานะเอกสาร
                        {
                            if (annexValue == "0")//เลือกทุกด่านฯ
                            {
                                tollid +=  finalwhere(annexValue, cpointValue);
                            }
                            else  //เลือกอาคาร
                            {
                                tollid +=  finalwhere(annexValue, cpointValue);
                            }

                        }
                        else //เลือกสถานะเอกสาร
                        {
                            tollid += " complete_stat = '" + StatusValue + "' AND ";
                            tollid += finalwhere(annexValue, cpointValue);
                        }
                    }

                }
                else
                {
                    tollid += " trans_id Like '%" + RefText + "%' AND ";
                    if (cpointValue == "0")//ทุกด่าน
                    {
                        if (StatusValue == "0")//ทุกสถานะเอกสาร
                        {
                           tollid += finalwhere(annexValue, cpointValue);
                        }
                        else //เลือกสถานะเอกสาร
                        {
                            tollid += " complete_stat = '" + StatusValue + "' AND ";
                            tollid += finalwhere(annexValue, cpointValue);
                        }
                    }
                    else //เลือกด่านฯ
                    {
                        if (StatusValue == "0")//ทุกสถานะเอกสาร
                        {
                             tollid += finalwhere(annexValue, cpointValue);
                        }
                        else //เลือกสถานะเอกสาร
                        {
                            tollid += " complete_stat = '" + StatusValue + "' AND ";
                            tollid += finalwhere(annexValue, cpointValue);
                        }
                    }
                }
            }

            //must join toll
            string qrytable = "select * from tbl_transfer" +
                            " join tbl_toll  on  tbl_toll.toll_id = tbl_transfer.toll_send" +
                            " join tbl_trans_complete on tbl_trans_complete.complete_id =  tbl_transfer.complete_stat" +
                            " join tbl_transfer_status on tbl_transfer_status.trans_stat_id = tbl_transfer.trans_stat " + tollid;
            MySqlDataAdapter da = function.MySqlSelectDataSet(qrytable);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            gridTranlist.DataSource = ds.Tables[0];
            //int countt = ds.Tables[0].Rows.Count;
            gridTranlist.DataBind();

        }
        protected string finalwhere (string annex,string cpoint)
        {
            string valueReturn = "";
            if(cpoint == "0")//ทุกด่านฯ
            {
                string who = Session["User"].ToString();
                //แยกยูสเซอร์
                
                if (who == "watcharee")
                { valueReturn += " toll_EQGroup = '3' AND toll_EQGroup = '9' AND complete_stat != '1'  order by complete_stat ASC "; }

                else if (who == "sawitree")
                { valueReturn += " toll_EQGroup = '1' AND toll_EQGroup = '9' AND complete_stat != '1'  order by complete_stat ASC "; }

                else if (who == "supaporn")
                { valueReturn += " toll_EQGroup = '2' AND toll_EQGroup = '9' AND complete_stat != '1'  order by complete_stat ASC "; }

                else
                {
                    valueReturn += " complete_stat != '1'  order by complete_stat ASC ";
                }
                         
                
                
            }
            else //เลือกด่าน
            {
                if (annex == "0")//ทุกอาคาร
                {

                    if (cpoint == "701") { valueReturn = "  toll_send = '7010' AND complete_stat != '1' order by complete_stat ASC "; }
                    else if (cpoint == "702") { valueReturn = "  toll_send = '7020' AND complete_stat != '1' order by complete_stat ASC "; }
                    else if (cpoint == "703") { valueReturn = "  cpoint_id = '703' AND complete_stat != '1'   order by complete_stat ASC "; }
                    else if (cpoint == "704") { valueReturn = "  cpoint_id = '704' AND complete_stat != '1' order by complete_stat ASC "; }
                    else if (cpoint == "706") { valueReturn = "  cpoint_id = '706' AND complete_stat != '1'  order by complete_stat ASC "; }
                    else if (cpoint == "707") { valueReturn = "  cpoint_id = '707' AND complete_stat != '1'  order by complete_stat ASC "; }
                    else if (cpoint == "708") { valueReturn = "  cpoint_id = '708' AND complete_stat != '1'  order by complete_stat ASC "; }
                    else if (cpoint == "709") { valueReturn = "  cpoint_id = '709' AND complete_stat != '1'  order by complete_stat ASC "; }
                    else if (cpoint == "710") { valueReturn = "  cpoint_id = '710' AND complete_stat != '1' order by complete_stat ASC "; }
                    else if (cpoint == "711") { valueReturn = "  cpoint_id = '711' AND complete_stat != '1' order by complete_stat ASC "; }
                    else if (cpoint == "712") { valueReturn = "  cpoint_id = '712' AND complete_stat != '1' order by complete_stat ASC "; }
                    else if (cpoint == "713") { valueReturn = "  cpoint_id = '713' AND complete_stat != '1' order by complete_stat ASC "; }
                    else if (cpoint == "902") { valueReturn = "  cpoint_id = '902' AND complete_stat != '1' order by complete_stat ASC "; }
                    else if (cpoint == "903") { valueReturn = "  cpoint_id = '903' AND complete_stat != '1' order by complete_stat ASC "; }
                    else if (cpoint == "904") { valueReturn = "  cpoint_id = '904' AND complete_stat != '1' order by complete_stat ASC "; }
                    else if (cpoint == "905") { valueReturn = "  cpoint_id = '905' AND complete_stat != '1' order by complete_stat ASC "; }
                    else { valueReturn = "  toll_send = '0' "; }


                }
                else//เลือกอาคาร
                {
                    valueReturn = "  toll_send = '"+annex+"' AND complete_stat != '1' order by complete_stat ASC ";

                }
            }

            return valueReturn;
        }
        protected void btnMainEQQ_Click(object sender, EventArgs e)
        {
            Response.Redirect("/equip/EquipMain");
        }

        protected void lbtntrans_Command(object sender, CommandEventArgs e)
        {
            Session["CheckTran"] = e.CommandName;
            Response.Redirect("/equip/EquipCheck");
        }

        protected void ddlsearchEndToll_SelectedIndexChanged(object sender, EventArgs e)
        {
            showannex();
        }

        protected void lbtnSearchSend_Command(object sender, CommandEventArgs e)
        {
            bindSearch();
        }

        protected void gridTranlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton lbtntrans = (LinkButton)(e.Row.FindControl("lbtntrans"));
            if (lbtntrans != null)
            {
                lbtntrans.CommandName = (string)DataBinder.Eval(e.Row.DataItem, "trans_id");
            }

            Label lbEndtrans = (Label)(e.Row.FindControl("lbEndtrans"));
            if (lbEndtrans != null)
            {
                string gettollname = "SELECT toll_name from tbl_toll where toll_id = '" + lbEndtrans.Text + "' ";
                MySqlDataReader namee = function.MySqlSelect(gettollname);
                if (namee.Read())
                {
                    lbEndtrans.Text = namee.GetString("toll_name");
                }
                else { lbEndtrans.Text = "ยังไม่ระบุ"; }
            }

            Label lbstat = (Label)(e.Row.FindControl("lbstat"));
            if (lbstat != null)
            {
                lbstat.CssClass = "badge badge-" + (string)DataBinder.Eval(e.Row.DataItem, "complete_badge");
                lbtntrans.CssClass = (string)DataBinder.Eval(e.Row.DataItem, "complete_link");

            }
        }
        protected void showannex ()
        {
            string idcpoint = ddlsearchEndToll.SelectedValue;
            if (idcpoint != "0")
            {
                
                if (idcpoint == "701")
                {
                    divannex.Visible = false;
                    function.getListItem(ddlannex, "select * from tbl_toll where cpoint_id = '701' order by toll_id ASC ", "toll_name", "toll_id");
                }
                else if(idcpoint == "702")
                {
                    divannex.Visible = false;
                    function.getListItem(ddlannex, "select * from tbl_toll where cpoint_id = '702' order by toll_id ASC ", "toll_name", "toll_id");
                }
                else if (idcpoint == "703")
                {
                    divannex.Visible = true;
                    function.getListItem(ddlannex, "select * from tbl_toll where cpoint_id = '703' order by toll_id ASC ", "toll_name", "toll_id");
                    ddlannex.Items.Insert(0, new ListItem("ทั้งหมด", "0"));
                }
                else if (idcpoint == "704")
                {
                    divannex.Visible = true;
                    function.getListItem(ddlannex, "select * from tbl_toll where cpoint_id = '704' order by toll_id ASC ", "toll_name", "toll_id");
                    ddlannex.Items.Insert(0, new ListItem("ทั้งหมด", "0"));
                }
                else if (idcpoint == "706")
                {
                    divannex.Visible = true;
                    function.getListItem(ddlannex, "select * from tbl_toll where cpoint_id = '706' order by toll_id ASC ", "toll_name", "toll_id");
                    ddlannex.Items.Insert(0, new ListItem("ทั้งหมด", "0"));
                }
                else if (idcpoint == "707")
                {
                    divannex.Visible = true;
                    function.getListItem(ddlannex, "select * from tbl_toll where cpoint_id = '707' order by toll_id ASC ", "toll_name", "toll_id");
                    ddlannex.Items.Insert(0, new ListItem("ทั้งหมด", "0"));
                }
                else if (idcpoint == "708")
                {
                    divannex.Visible = true;
                    function.getListItem(ddlannex, "select * from tbl_toll where cpoint_id = '708' order by toll_id ASC ", "toll_name", "toll_id");
                    ddlannex.Items.Insert(0, new ListItem("ทั้งหมด", "0"));
                }
                else if (idcpoint == "709")
                {
                    divannex.Visible = true;
                    function.getListItem(ddlannex, "select * from tbl_toll where cpoint_id = '709' order by toll_id ASC ", "toll_name", "toll_id");
                    ddlannex.Items.Insert(0, new ListItem("ทั้งหมด", "0"));
                }
                else if (idcpoint == "710")
                {
                    divannex.Visible = false;
                    function.getListItem(ddlannex, "select * from tbl_toll where cpoint_id = '710' order by toll_id ASC ", "toll_name", "toll_id");
                }
                else if (idcpoint == "711")
                {
                    divannex.Visible = false;
                    function.getListItem(ddlannex, "select * from tbl_toll where cpoint_id = '711' order by toll_id ASC ", "toll_name", "toll_id");
                }
                else if (idcpoint == "712")
                {
                    divannex.Visible = false;
                    function.getListItem(ddlannex, "select * from tbl_toll where cpoint_id = '712' order by toll_id ASC ", "toll_name", "toll_id");
                }
                else if (idcpoint == "713")
                {
                    divannex.Visible = false;
                    function.getListItem(ddlannex, "select * from tbl_toll where cpoint_id = '713' order by toll_id ASC ", "toll_name", "toll_id");
                }
                else if (idcpoint == "902")
                {
                    divannex.Visible = false;
                    function.getListItem(ddlannex, "select * from tbl_toll where cpoint_id = '902' order by toll_id ASC ", "toll_name", "toll_id");
                }
                else if (idcpoint == "903")
                {
                    divannex.Visible = false;
                    function.getListItem(ddlannex, "select * from tbl_toll where cpoint_id = '903' order by toll_id ASC ", "toll_name", "toll_id");
                }
                else if (idcpoint == "904")
                {
                    divannex.Visible = false;
                    function.getListItem(ddlannex, "select * from tbl_toll where cpoint_id = '904' order by toll_id ASC ", "toll_name", "toll_id");
                }
                else if (idcpoint == "905")
                {
                    divannex.Visible = false;
                    function.getListItem(ddlannex, "select * from tbl_toll where cpoint_id = '905' order by toll_id ASC ", "toll_name", "toll_id");
                }
                

            }
            else
            {
                divannex.Visible = false;
                function.getListItem(ddlannex, "select * from tbl_toll  order by toll_id ASC ", "toll_name", "toll_id");
                ddlannex.Items.Insert(0, new ListItem("ทั้งหมด", "0"));
            }

        }
    }
}