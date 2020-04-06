using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClaimProject.Config;
using MySql.Data.MySqlClient;
using System.Data;

namespace ClaimProject.equip
{
    public partial class EquipAddList : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public string alertType = "";
        public string icon = "";
        public string alert = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/");
            }
            if (!this.IsPostBack)
            {
                function.getListItem(ddlAddCompany, "SELECT * FROM tbl_company WHERE company_status='0' Order By company_id DESC ", "company_name", "company_id");
                function.getListItem(ddlAddStat, "SELECT * FROM tbl_equipment_status Order By status_id ", "status_name", "status_id");
               // function.getListItem(ddlAddLocatedd, "SELECT * FROM tbl_location Order By locate_id ", "locate_name", "locate_id");
                SetInitialRow();
               LoadPaging();
                
            }
        }
        protected void LoadPaging ()
        {
            string PrivCode = Session["UserPrivilegeId"].ToString();
            string userrrr = Session["User"].ToString();
            if (PrivCode == "0" || PrivCode == "1" || PrivCode == "5")
            {
                if (userrrr == "sawitree")
                {
                    string sawitree = "SELECT * FROM tbl_toll " +
                        "JOIN tbl_cpoint d ON d.cpoint_id = tbl_toll.cpoint_id WHERE user_depart = 'sawitree' Order by toll_id ASC ";
                    function.getListItem(ddlAddCpoint, sawitree, "toll_name", "toll_id");
                }
                else if (userrrr == "supaporn")
                {
                    string supaporn = " SELECT * FROM tbl_toll " +
                        "JOIN tbl_cpoint d ON d.cpoint_id = tbl_toll.cpoint_id WHERE user_depart = 'supaporn' Order by toll_id ASC ";
                    function.getListItem(ddlAddCpoint, supaporn, "toll_name", "toll_id");
                }
                else if (userrrr == "watcharee")
                {
                    string watcharee = "SELECT * FROM tbl_toll " +
                        "JOIN tbl_cpoint d ON d.cpoint_id = tbl_toll.cpoint_id WHERE user_depart = 'watcharee' Order by toll_id ASC ";
                    function.getListItem(ddlAddCpoint, watcharee, "toll_name", "toll_id");
                }
                else
                {
                    function.getListItem(ddlAddCpoint, "SELECT * FROM tbl_toll Order By toll_id ASC", "toll_name", "toll_id");
                }

            }
            else
            {
                string cpointToll = "SELECT * FROM tbl_toll " +
                                    "JOIN tbl_cpoint ON tbl_cpoint.cpoint_id = tbl_toll.cpoint_id " +
                                    "WHERE tbl_toll.cpoint_id = '" + Session["UserCpoint"].ToString() + "' Order By tbl_toll.toll_id ASC";
                function.getListItem(ddlAddCpoint, cpointToll, "toll_name", "toll_id");
            }
            if (Session["NewEQPKtype"].ToString() == "new")
            {
                statsave.Text = Session["NewEQPK"].ToString() +" (รายการใหม่ยังไม่บันทึก)";
                statsave.BackColor = System.Drawing.ColorTranslator.FromHtml("#dedede");
                
            }
            else if(Session["NewEQPKtype"].ToString() == "old")
            {
                
                ddlAddCpoint.Enabled = false;
                statsave.Text = Session["NewEQPK"].ToString() ;
                statsave.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffd9e7");
                string qdata = "select * from tbl_newequipment where NewEQ_id = '"+ Session["NewEQPK"].ToString() + "' ";
                MySqlDataReader rs = function.MySqlSelect(qdata);
                if(rs.Read())
                {
                    txtAddTH.Text = rs.GetString("AddNameth");
                    txtAddENG.Text = rs.GetString("AddNameEng");
                    txtAddBrand.Text = rs.GetString("AddBrand");
                    txtAddSeries.Text = rs.GetString("AddSeries");
                    txtAddContractNum.Text = rs.GetString("AddConNum");
                    string cpointtt = rs.GetInt32("AddCpoint").ToString();
                    ddlAddCpoint.SelectedValue = cpointtt;
                    txtAddDateGet.Text = rs.GetString("AddDateGet");
                    txtAddPrize.Text = rs.GetString("AddPrize");
                    txtAddUnit.Text = rs.GetString("AddUnit");
                    ddlAddCompany.SelectedValue = rs.GetInt32("AddCompany").ToString();
                    ddlAddStat.SelectedValue = rs.GetInt32("AddStat").ToString();

                    rs.Close();
                    string sqlAddedd = "Select * FROM tbl_neweq_list WHERE newEQ_idx = '" + Session["NewEQPK"].ToString() + "' Order by newlist_id ASC ";
                    MySqlDataAdapter da = function.MySqlSelectDataSet(sqlAddedd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridadded.DataSource = dt;
                    if(dt.Rows.Count.ToString() != "0")
                    {
                        deleteAll.Visible = true;
                    }
                    else
                    {
                        deleteAll.Visible = false;
                    }
                    resulttt.Text = "รายการครุภัณฑ์ที่เพิ่มเข้าระบบเรียบร้อย  " + dt.Rows.Count.ToString() + " รายการ";
                    gridadded.DataBind();
                }
                
            }
            
        }


        private void SetInitialRow()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dt.Rows.Add(dr);

            //dr = dt.NewRow();

            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;
            Gridview1.DataSource = dt;
            Gridview1.DataBind();

        }

        private void AddNewRowToGrid()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values

                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("TextBox2");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                        rowIndex++;

                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    checkRowNum.Text = dtCurrentTable.Rows.Count.ToString();
                    Gridview1.DataSource = dtCurrentTable;
                    Gridview1.DataBind();
                }

            }
            else
            {
                Response.Write("ViewState is null");
            }
            //Set Previous Data on Postbacks
            SetPreviousData();
        }
        
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("TextBox2");

                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        box2.Text = dt.Rows[i]["Column2"].ToString();

                        rowIndex++;
                    }
                }
            }

        }

        protected void btnNewrow_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        private void SaveAllRow ()
        {
            string TimeNoww = DateTime.Now.ToString("HH:mm");
            string DateNoww = DateTime.Now.ToString("dd-MM") + "-" + (DateTime.Now.Year + 543);
            string Num1 = ""; string Num2 = ""; string userr = ""; string SQLPMM = "";string newEQref = "";
            string eqaddList = "";
            int doOrnot = 0;

            if(txtAddTH.Text != "" && txtAddENG.Text != "" && txtAddBrand.Text != "" && txtAddSeries.Text != "")
            {
                if(txtAddContractNum.Text != "" && txtAddDateGet.Text != "" && txtAddPrize.Text != "" && txtAddUnit.Text != ""  )
                {
                    string EQPKTYPE = Session["NewEQPKtype"].ToString();
                    for (int i = 0; i < Gridview1.Rows.Count; i++)
                    {
                        Num1 = ((TextBox)Gridview1.Rows[i].FindControl("TextBox1")).Text;
                        Num2 = ((TextBox)Gridview1.Rows[i].FindControl("TextBox2")).Text;
                        string resultChk = CheckDupli(Num1, Num2);

                        if (resultChk == "ok")
                        {
                            if (i == (Gridview1.Rows.Count - 1)) //แถวสุดท้าย
                            {
                                if (Num1 == "")
                                {
                                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('รายการที่ " + (i + 1).ToString() + " ไม่ใส่เลขครุภัณฑ์!!')", true);
                                    //AlertPop("รายการที่ "+i.ToString()+" ไม่บันทึก!!", "Error");
                                }
                                else
                                {
                                    if (Num2 == "")
                                    {
                                        Num2 = "-";
                                    }
                                    
                                    if (EQPKTYPE == "new")
                                    {
                                        newEQref = "INSERT INTO tbl_newequipment " +
                                        "(NewEQ_id,NewEQ_Date,NewEQ_Time,NewEQ_User,NewEQ_Comment,AddNameth,AddNameEng,AddBrand,AddSeries,AddConNum," +
                                        "AddCpoint,AddDateGet,AddPrize,AddUnit,AddCompany,AddStat) VALUES" +
                                        " ('"+ Session["NewEQPK"].ToString() + "','" + DateNoww + "','" + TimeNoww + "','" + Session["User"].ToString() + "','-','" + txtAddTH.Text + "'" +
                                        ",'" + txtAddENG.Text + "','" + txtAddBrand.Text + "','" + txtAddSeries.Text + "','" + txtAddContractNum.Text + "'" +
                                        ",'" + ddlAddCpoint.SelectedValue + "','" + txtAddDateGet.Text + "','" + txtAddPrize.Text + "','" + txtAddUnit.Text + "'" +
                                        ",'" + ddlAddCompany.SelectedValue + "','" + ddlAddStat.SelectedValue + "')";
                                    }
                                    else if(EQPKTYPE == "old")
                                    {
                                        newEQref = "update tbl_newequipment SET " +
                                        "NewEQ_Date='"+ DateNoww + "',NewEQ_Time = '"+ TimeNoww + "',NewEQ_User= '"+ Session["User"].ToString() + "'" +
                                        ",NewEQ_Comment = '-',AddNameth='" + txtAddTH.Text + "',AddNameEng='"+ txtAddENG.Text + "',AddBrand='"+ txtAddBrand.Text + "'" +
                                        ",AddSeries='"+ txtAddSeries.Text + "',AddConNum='"+ txtAddContractNum.Text + "'," +
                                        "AddCpoint='"+ ddlAddCpoint.SelectedValue + "',AddDateGet='"+ txtAddDateGet.Text + "',AddPrize='"+ txtAddPrize.Text + "'" +
                                        ",AddUnit='"+ txtAddUnit.Text + "',AddCompany='"+ ddlAddCompany.SelectedValue + "',AddStat='"+ ddlAddStat.SelectedValue + "' " +
                                        " where NewEQ_id = '" + Session["NewEQPK"].ToString() + "'";
                                    }
                                    SQLPMM = "INSERT INTO tbl_equipment " +
                                        "(equipment_img,locate_id,equipment_name,equipment_nameth,equipment_no,equipment_serial,equipment_brand" +
                                        ",equipment_series,equipment_buy_date,equipment_price_unit,equipment_contract_no,equipment_unit" +
                                        ",toll_id,Estatus_id,company_id" +
                                        ",person_name,action_stat,user_update,time_update,date_update,trans_complete,equip_comment)"
                                      + " VALUES ('/equip/Upload/3c1d1f29ba4a7e19850b2fb498af3987.jpg','555','" + txtAddENG.Text + "','" + txtAddTH.Text + "','" + Num1 + "','" + Num2 + "','" + txtAddBrand.Text + "'" +
                                      "          ,'" + txtAddSeries.Text + "','" + txtAddDateGet.Text + "','" + txtAddPrize.Text + "','" + txtAddContractNum.Text + "'" +
                                      "          ,'" + txtAddUnit.Text + "','" + ddlAddCpoint.SelectedValue + "','" + ddlAddStat.SelectedValue + "'" +
                                      "          ,'" + ddlAddCompany.SelectedValue + "','-','0','" + Session["User"].ToString() + "'" +
                                      "          , '" + TimeNoww + "','" + DateNoww + "','0','-') ";
                                    
                                    eqaddList = "insert into tbl_neweq_list " +
                                        " (list_serial,newEQ_idx,Date_added,Time_added,list_number,list_thname,list_brand,list_series,list_contract,list_toll) " +
                                        "values ('"+Num2+"','"+ Session["NewEQPK"].ToString() + "','"+DateNoww+"','"+TimeNoww+"'," +
                                        "'"+Num1+"','"+ txtAddTH.Text + "','"+ txtAddBrand.Text + "','"+ txtAddSeries.Text + "','"+ txtAddContractNum.Text + "'," +
                                        " '"+ ddlAddCpoint.SelectedValue + "')";

                                    if (function.MySqlQuery(SQLPMM))
                                    {
                                        if(function.MySqlQuery(newEQref))
                                        {
                                            if(function.MySqlQuery(eqaddList))
                                            {
                                                Session["NewEQPKtype"] = "old";
                                                LoadPaging();
                                                break;
                                            }
                                            else
                                            {
                                                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('ErrorFinal ติดต่อเจ้าหน้าที่ ')", true);
                                                break;
                                            }
                                            
                                        }
                                        else
                                        {
                                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Error01 ติดต่อเจ้าหน้าที่ ')", true);
                                            break;
                                        }

                                    }
                                    else
                                    {
                                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('ErrorFirst ติดต่อเจ้าหน้าที่ ')", true);
                                        doOrnot = 0; break;
                                    }
                                }
                            }
                            else
                            {
                                if (Num1 == "")
                                {
                                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('รายการที่ " + (i + 1).ToString() + " ไม่ใส่หมายเลขครุภัณฑ์!!')", true);
                                    // AlertPop("รายการที่ "+i.ToString()+" ไม่ใส่หมายเลขครุภัณฑ์!!", "Error");
                                }
                                else
                                {
                                    SQLPMM = "INSERT INTO tbl_equipment " +
                                        "(equipment_img,locate_id,equipment_name,equipment_nameth,equipment_no,equipment_serial,equipment_brand" +
                                        ",equipment_series,equipment_buy_date,equipment_price_unit,equipment_contract_no,equipment_unit" +
                                        ",toll_id,Estatus_id,company_id" +
                                        ",person_name,action_stat,user_update,time_update,date_update,trans_complete,equip_comment)"
                                      + " VALUES ('/equip/Upload/3c1d1f29ba4a7e19850b2fb498af3987.jpg','555','" + txtAddENG.Text + "','" + txtAddTH.Text + "','" + Num1 + "','" + Num2 + "','" + txtAddBrand.Text + "'" +
                                      "          ,'" + txtAddSeries.Text + "','" + txtAddDateGet.Text + "','" + txtAddPrize.Text + "','" + txtAddContractNum.Text + "'" +
                                      "          ,'" + txtAddUnit.Text + "','" + ddlAddCpoint.SelectedValue.ToString() + "','" + ddlAddStat.SelectedValue.ToString() + "'" +
                                      "          ,'" + ddlAddCompany.SelectedValue.ToString() + "','-','0','" + Session["User"].ToString() + "'" +
                                      "          , '" + TimeNoww + "','" + DateNoww + "','0','-') ";
                                    if (EQPKTYPE == "new")
                                    {
                                        newEQref = "INSERT INTO tbl_newequipment " +
                                        "(NewEQ_Date,NewEQ_Time,NewEQ_User,NewEQ_Comment,AddNameth,AddNameEng,AddBrand,AddSeries,AddConNum," +
                                        "AddCpoint,AddDateGet,AddPrize,AddUnit,AddCompany,AddStat) VALUES" +
                                        " ('" + DateNoww + "','" + TimeNoww + "','" + Session["User"].ToString() + "','-','" + txtAddTH.Text + "'" +
                                        ",'" + txtAddENG.Text + "','" + txtAddBrand.Text + "','" + txtAddSeries.Text + "','" + txtAddContractNum.Text + "'" +
                                        ",'" + ddlAddCpoint.SelectedValue + "','" + txtAddDateGet.Text + "','" + txtAddPrize.Text + "','" + txtAddUnit.Text + "'" +
                                        ",'" + ddlAddCompany.SelectedValue + "','" + ddlAddStat.SelectedValue + "')";
                                    }
                                    else if (EQPKTYPE == "old")
                                    {
                                        newEQref = "update tbl_newequipment SET " +
                                        "NewEQ_Date='" + DateNoww + "',NewEQ_Time = '" + TimeNoww + "',NewEQ_User= '" + Session["User"].ToString() + "'" +
                                        ",NewEQ_Comment = '-',AddNameth='" + txtAddTH.Text + "',AddNameEng='" + txtAddENG.Text + "',AddBrand='" + txtAddBrand.Text + "'" +
                                        ",AddSeries='" + txtAddSeries.Text + "',AddConNum='" + txtAddContractNum.Text + "'," +
                                        "AddCpoint='" + ddlAddCpoint.SelectedValue + "',AddDateGet='" + txtAddDateGet.Text + "',AddPrize='" + txtAddPrize.Text + "'" +
                                        ",AddUnit='" + txtAddUnit.Text + "',AddCompany='" + ddlAddCompany.SelectedValue + "',AddStat='" + ddlAddStat.SelectedValue + "' " +
                                        " where NewEQ_id = '" + Session["NewEQPK"].ToString() + "'";
                                    }
                                    eqaddList = "insert into tbl_neweq_list " +
                                        " (list_serial,newEQ_idx,Date_added,Time_added,list_number,list_thname,list_brand,list_series,list_contract,list_toll) " +
                                        "values ('"+Num2+"','" + Session["NewEQPK"].ToString() + "','" + DateNoww + "','" + TimeNoww + "'," +
                                        "'" + Num1 + "','" + txtAddTH.Text + "','" + txtAddBrand.Text + "','" + txtAddSeries.Text + "','" + txtAddContractNum.ToString() + "'," +
                                        " '" + ddlAddCpoint.SelectedValue + "')";
                                    if (function.MySqlQuery(SQLPMM))
                                    {
                                        if(function.MySqlQuery(newEQref))
                                        {
                                            if(function.MySqlQuery(eqaddList))
                                            {
                                                
                                            }
                                            else
                                            {
                                                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('ErrorFinal2 ติดต่อเจ้าหน้าที่ ')", true);
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Error02 ติดต่อเจ้าหน้าที่ ')", true);
                                            break;
                                        }
                                    }
                                    else
                                    { doOrnot = 0; break; }
                                }
                            }
                        }
                        else if (resultChk == "no")
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('บันทึกล้มเหลว!! เลขครุภัณฑ์หรือเลขทะเบียนซ้ำ!!!')", true);
                            break;
                        }
                        else { ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('บันทึกล้มเหลว!! กรุณาติดต่อเจ้าหน้าที่ดูแลระบบ')", true); break; }

                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('บันทึกล้มเหลว ข้อมูลไม่ควรเว้นว่าง กรุณาใส่เครื่องหมาย - (แดท)')", true);
                    
                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('บันทึกล้มเหลว ข้อมูลไม่ควรเว้นว่าง กรุณาใส่เครื่องหมาย - (แดท)')", true);
                
            }
                
               /* if (doOrnot != 0) { Response.Redirect("/equip/EquipAddList"); }
                else { AlertPop("บันทึกข้อมูลล้มเหลว ติดต่อเจ้าหน้าที่", "error"); } */
            
        }
        protected string CheckDupli(string noEQ, string SerialEQ)
        {
            int resultNN;
            int resultSS;
            string chkNoEQ = "SELECT COUNT(equipment_id) AS NNN FROM tbl_equipment WHERE equipment_no = '" + noEQ + "' AND equipment_no != '-' ";

            string chkSeEQ = "SELECT COUNT(equipment_id) AS SSS FROM tbl_equipment WHERE equipment_serial = '" +SerialEQ+ "' AND equipment_serial != '-' ";
            MySqlDataReader nn = function.MySqlSelect(chkNoEQ);
            MySqlDataReader ss = function.MySqlSelect(chkSeEQ);

            if (nn.Read() )
            {
                resultNN = nn.GetInt32("NNN");
                nn.Close();
                if(ss.Read())
                {
                    resultSS = ss.GetInt32("SSS");
                    ss.Close();
                    if (resultNN == 0 && resultSS == 0)
                    {
                        return "ok";
                    }
                    else
                    {
                        return "no";
                    }
                }
                else
                {
                    return "error";
                }
                
            }
            else
            {
                return "error";
            }
        }
        void ClearData ()
        {
            divAdd.Visible = false;
            btnAgain.Visible = true;
        }

        public void AlertPop(string msg, string type)
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
            }
            alert = msg;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveAllRow();
        }

        protected void btnAgain_Click(object sender, EventArgs e)
        {
            Response.Redirect("/equip/EquipAddList.aspx");
        }

        protected void btnBackHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("/equip/EquipAddAll.aspx");
        }

        protected void lbtnDeleteRow_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox box1 = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("TextBox1");
                    TextBox box2 = (TextBox)Gridview1.Rows[i].Cells[2].FindControl("TextBox2");


                    dt.Rows[i]["Column1"] = box1.Text;
                    dt.Rows[i]["Column2"] = box2.Text;

                }
                if (dt.Rows.Count > 1)
                {

                    if (gvRow.RowIndex <= dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data and reset row number  
                        dt.Rows.Remove(dt.Rows[rowID]);
                        ResetRowID(dt);
                    }
                }

                //Store the current data in ViewState for future reference  
                ViewState["CurrentTable"] = dt;

                //Re bind the GridView for the updated data  
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
            }

            //Set Previous Data on Postbacks  
            SetPreviousData();
        }
        private void ResetRowID(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }



        protected void gridadded_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // + GridAddTran.DataKeys[e.RowIndex].Value + "'";
            //GridAddTran.DataKeys[e.RowIndex].Value + "'";
            string deleterow = "delete from tbl_neweq_list where newlist_id = '"+gridadded.DataKeys[e.RowIndex].Value+"' ";
            string getEQnum = "select list_number from tbl_neweq_list where newlist_id = '" + gridadded.DataKeys[e.RowIndex].Value + "' ";
            MySqlDataReader rd = function.MySqlSelect(getEQnum);
            if(rd.Read())
            {
                string EQQnum = rd.GetString("list_number");
                rd.Close();
                string deleteEQ = "Delete from tbl_equipment where equipment_no = '"+EQQnum+"'";
                if (function.MySqlQuery(deleteEQ))
                {
                    if (function.MySqlQuery(deleterow))
                    {

                        Response.Redirect("/equip/EquipAddList.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Can't Delete neweq_list ติดต่อเจ้าหน้าที่!!')", true);
                    }

                    gridadded.EditIndex = -1;
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('ลบรายการล้มเหลว!! ติดต่อเจ้าหน้าที่!!')", true);
                }
                
            }
            
        }

        protected void gridadded_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void deleteAll_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 30; i++)
            {
                string readhas = "select list_number from tbl_neweq_list where newlist_id = '" + Session["NewEQPK"].ToString() + "' " +
                            " Order by newlist_id DESC LIMIT 1";
                MySqlDataReader rss = function.MySqlSelect(readhas);
                if (rss.Read())
                {
                    string numGet = rss.GetString("list_number");
                    rss.Close();
                    string deleteEQ = "Delete from tbl_equipment where equipment_no = '"+numGet+"' ";
                    if(function.MySqlQuery(deleteEQ))
                    {
                        
                        
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Can't Delete EQ_num: "+numGet+" ติดต่อเจ้าหน้าที่!!')", true);
                        break;
                    }

                }
                else
                {
                    string deleteAddmain = "Delete from tbl_newequipment where NewEQ_id = '"+ Session["NewEQPK"].ToString() + "'  ";
                    if(function.MySqlQuery(deleteAddmain))
                    {
                        string deleteListEQ = "Delete from tbl_neweq_list where newEQ_idx = '" + Session["NewEQPK"].ToString() + "'";
                        if (function.MySqlQuery(deleteListEQ))
                        {
                            Response.Redirect("/equip/EquipAddAll.aspx");
                            break;
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Can't Delete neweq_list ติดต่อเจ้าหน้าที่!!')", true);
                            break;
                        }
                        
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Can't Delete newequipment ติดต่อเจ้าหน้าที่!!')", true);
                        break;
                    }
                    
                    
                }
            }


        }
    }
}