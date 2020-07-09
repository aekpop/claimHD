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
    public partial class EquipTranGetout : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public string alerts = "";
        public string alertTypes = "";
        public string icons = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/");
            }
            if (!this.IsPostBack)
            {
                PagingData();
                ddlbinding();
            }
        }

        protected void PagingData ()
        {
            function.getListItem(ddlcompout, "SELECT * FROM tbl_toll WHERE toll_id = '9300' or toll_id = '9400' or toll_id = '9500' Order by toll_id ASC ", "toll_name", "toll_id");
            if(Session["TransOutNew"].ToString() != "0")//ไม่ใช่รายการใหม่
            {
                string completeStat = "";
                string selectData = "SELECT * FROM tbl_transfer " +
                    " JOIN tbl_trans_complete ON tbl_trans_complete.complete_id = tbl_transfer.complete_stat  " +
                    " WHERE trans_id = '" + Session["TransOutID"].ToString() + "' ";
                MySqlDataReader rGet = function.MySqlSelect(selectData);
                if(rGet.Read())
                {
                    ddlcompout.SelectedValue = rGet.GetInt32("toll_send").ToString();
                    ddlcompGet.SelectedValue = rGet.GetInt32("toll_recieve").ToString();
                    txtDateGet.Text = rGet.GetString("date_send");
                    completeStat = rGet.GetString("complete_stat");
                    if(completeStat != "1")//สถานะสำเร็จแล้ว
                    {
                        btnPlanSheet.Visible = false;
                        btnFinalSubmit.Visible = false;
                        div3.Visible = false;
                        divbtnNext.Visible = false;
                        ddlcompout.Enabled = false;
                    }
                    else
                    {
                        btnPlanSheet.Visible = true;
                        btnFinalSubmit.Visible = true;
                        div3.Visible = true;
                        divbtnNext.Visible = false;
                        btnDeleteALL.Visible = true;
                        ddlcompout.Enabled = false;
                    }
                }
                else
                {
                    Response.Redirect("/equip/EquipTranOutList");
                }

            }
            else
            {
                if (Session["UserCpoint"].ToString() == "0")
                {
                    function.getListItem(ddlcompGet, "SELECT * FROM tbl_toll WHERE toll_id = '9200' ", "toll_name", "toll_id");
                }
                else
                {
                    function.getListItem(ddlcompGet, "SELECT * FROM tbl_toll WHERE cpoint_id = '" + Session["UserCpoint"].ToString() + "' ", "toll_name", "toll_id");
                }
            }

            
        }
        protected void ddlbinding()
        {
            string selectmeter = ddlcompout.SelectedValue;
            string chkhas = "";
            
            if (selectmeter == "9300")
            {
                chkhas = "SELECT equipment_id FROM tbl_equipment WHERE Estatus_id != '3' AND Estatus_id != '4' AND trans_complete != '1' AND toll_id = '9300'";
                MySqlDataReader rGet1 = function.MySqlSelect(chkhas);
                if (rGet1.Read())
                {
                    function.getListItem(txtEquipGet, "SELECT equipment_no,equipment_id FROM tbl_equipment WHERE Estatus_id != '3' AND Estatus_id != '4' AND trans_complete != '1' AND toll_id = '9300' Order By equipment_id ASC"
                                    , "equipment_no", "equipment_id");
                    txtEquipGet.Items.Insert(0, new ListItem("", ""));
                    txtEquipGet.Enabled = true; btnAddGet.Visible = true;
                }
                else
                {
                    function.getListItem(txtEquipGet, "SELECT * FROM tbl_zetc where etc_group = 'eq'  ", "etc_name", "etc_id");
                    txtEquipGet.Enabled = false; btnAddGet.Visible = false;
                }
                
            }
            else if (selectmeter == "9400")
            {
                chkhas = "SELECT equipment_id FROM tbl_equipment WHERE Estatus_id != '3' AND Estatus_id != '4' AND trans_complete != '1' AND toll_id = '9400'";
                MySqlDataReader rGet2 = function.MySqlSelect(chkhas);
                if (rGet2.Read())
                {
                    function.getListItem(txtEquipGet, "SELECT equipment_no,equipment_id FROM tbl_equipment WHERE Estatus_id != '3' AND Estatus_id != '4' AND trans_complete != '1' AND toll_id = '9400' Order By equipment_id ASC"
                                    , "equipment_no", "equipment_id");
                    txtEquipGet.Items.Insert(0, new ListItem("", ""));
                    txtEquipGet.Enabled = true; btnAddGet.Visible = true;
                }
                else
                {
                    function.getListItem(txtEquipGet, "SELECT * FROM tbl_zetc where etc_group = 'eq'  ", "etc_name", "etc_id");
                    txtEquipGet.Enabled = false; btnAddGet.Visible = false;
                }
            }
            else if (selectmeter == "9500")
            {
                chkhas = "SELECT equipment_id FROM tbl_equipment WHERE Estatus_id != '3' AND Estatus_id != '4' AND trans_complete != '1' AND toll_id = '9500'";
                MySqlDataReader rGet3 = function.MySqlSelect(chkhas);
                if (rGet3.Read())
                {
                    function.getListItem(txtEquipGet, "SELECT equipment_no,equipment_id FROM tbl_equipment WHERE Estatus_id != '3' AND Estatus_id != '4' AND trans_complete != '1' AND toll_id = '9500' Order By equipment_id ASC"
                                    , "equipment_no", "equipment_id");
                    txtEquipGet.Items.Insert(0, new ListItem("", ""));
                    txtEquipGet.Enabled = true;
                    btnAddGet.Visible = true;
                }
                else
                {
                    function.getListItem(txtEquipGet, "SELECT * FROM tbl_zetc where etc_group = 'eq'  ", "etc_name", "etc_id");
                    txtEquipGet.Enabled = false;
                    btnAddGet.Visible = false;
                }
            }

            
        }
        protected void btnAddGet_Command(object sender, CommandEventArgs e)
        {
            string sqltranAct = "";
            string sqltran = "";
            string sqlUpEQ = "";
            string ThMonth = GetThaiMonth(txtDateGet.Text);
            if (txtEquipGet.SelectedItem.ToString() != "")
            {
                string get = txtEquipGet.SelectedItem.ToString();
                string checkEQnum = "Select trans_complete FROM tbl_equipment WHERE equipment_no = '" + get + "'";
                string hasno = "";
                MySqlDataReader chknum = function.MySqlSelect(checkEQnum);
                if (chknum.Read())
                {
                    hasno = chknum.GetString("trans_complete");
                    chknum.Close();
                    if (hasno == "0")
                    {
                        string sqlLocate = "select * FROM tbl_equipment WHERE equipment_no = '" + txtEquipGet.SelectedItem.ToString() + "'";
                        MySqlDataReader ser = function.MySqlSelect(sqlLocate); //เช็ครหัสตู้ครุภัณฑ์
                        string locate_idd = ""; string eqidd = ""; string oldtoll = ""; string old_name = "";
                        string oldnameth = ""; string oldserial = ""; string oldtype = ""; string oldbrand = "";
                        string actNote = "-"; string oldseries = ""; string oldno = ""; string user = ""; string oldStatus = "";
                        string completeStat = "1";
                        if (ser.Read())
                        {
                            oldno = ser.GetString("equipment_no");
                            locate_idd = ser.GetString("locate_id");
                            eqidd = ser.GetString("equipment_id");
                            oldtoll = ser.GetInt32("toll_id").ToString();
                            oldnameth = ser.GetString("equipment_nameth");
                            oldserial = ser.GetString("equipment_serial");
                            oldseries = ser.GetString("equipment_series");
                            oldbrand = ser.GetString("equipment_brand");
                            oldStatus = ser.GetInt32("Estatus_id").ToString();
                            try
                            {
                                old_name = ser.GetString("equipment_name");
                                oldtype = ser.GetString("equipment_type");
                                user = ser.GetString("person_name");
                            }
                            catch { }
                            

                            string today = DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss");
                            string sqx = "SELECT * FROM tbl_transfer WHERE trans_id = '" + Session["TransOutID"].ToString() + "'";
                            string datesss = GetThaiMonth(txtDateGet.Text);
                            MySqlDataReader rs = function.MySqlSelect(sqx);
                            if (!rs.Read())  //กรณียังไม่มีเลข Ref 
                            {
                                string toll_end = ddlcompGet.SelectedValue;

                                sqltran = "INSERT INTO tbl_transfer (company_repair,thai_month,position_sender,trans_note,trans_id,trans_stat,date_send,time_send,user_send,name_send,toll_send,toll_recieve,complete_stat,trans_budget)" +
                                 "VALUES ('556','" + datesss + "','-','" + actNote + "','" + Session["TransOutID"].ToString() + "','1','" + txtDateGet.Text + "','" + today + "','" + Session["UserName"].ToString() + "'" +
                                 ",'" + Session["UserName"].ToString() + "','" + ddlcompout.SelectedValue + "','" + toll_end + "','" + completeStat + "','" + function.getBudgetYear(txtDateGet.Text) + "')";

                                if (function.MySqlQuery(sqltran))
                                {
                                    sqltranAct = "INSERT INTO tbl_transfer_action " +
                                        "(tran_type,repair_action,old_status,transfer_id,trans_equip_id,old_locate,old_toll,old_name,old_nameth,old_serial,old_series" +
                                        ",old_type,old_no,old_person,old_brand,num_success,budget_y,month_y,date_y) " +
                                        " VALUES ('1','0','" + oldStatus + "','" + Session["TransOutID"].ToString() + "','" + eqidd + "','" + locate_idd + "'," +
                                        "'" + oldtoll + "','" + old_name + "','" + oldnameth + "','" + oldserial + "','" + oldseries + "'," +
                                        " '" + oldtype + "','" + oldno + "','" + user + "','" + oldbrand + "','no','" + function.getBudgetYear(txtDateGet.Text) + "','" + datesss + "','" + txtDateGet.Text + "')";
                                    if (function.MySqlQuery(sqltranAct))
                                    {
                                        sqlUpEQ += "update tbl_equipment trans_complete = '1' ,transfer_idnow = '" + Session["TransOutID"].ToString() + "' WHERE equipment_id = '" + eqidd + "'";
                                        if (function.MySqlQuery(sqlUpEQ))
                                       {
                                           Response.Redirect("/equip/EquipNewTrans");
                                       }
                                       else
                                       {
                                           AlertPop("ERROR final บันทึกข้อมูลล้มเหลว", "error");
                                       }
                                        

                                    }
                                    else
                                    {
                                        AlertPop("ERROR 4100 บันทึกข้อมูลล้มเหลว", "error");
                                    }
                                }
                                else
                                {
                                    AlertPop("ERROR 4500 บันทึกข้อมูลล้มเหลว", "error");
                                }

                            }
                            else
                            {
                                string toll_end = ddlcompGet.SelectedValue;

                                sqltran = "INSERT INTO tbl_transfer (company_repair,thai_month,position_sender,trans_note,trans_id,trans_stat,date_send,time_send,user_send,name_send,toll_send,toll_recieve,complete_stat,trans_budget)" +
                                 "VALUES ('556','" + datesss + "','-','" + actNote + "','" + Session["TransOutID"].ToString() + "','1','" + txtDateGet.Text + "','" + today + "','" + Session["UserName"].ToString() + "'" +
                                 ",'" + Session["UserName"].ToString() + "','" + ddlcompout.SelectedValue + "','" + toll_end + "','" + completeStat + "','" + function.getBudgetYear(txtDateGet.Text) + "')";

                                sqltranAct = "INSERT INTO tbl_transfer_action " +
                                        "(tran_type,repair_action,old_status,transfer_id,trans_equip_id,old_locate,old_toll,old_name,old_nameth,old_serial,old_series" +
                                        ",old_type,old_no,old_brand,num_success,budget_y,month_y,date_y) " +
                                        " VALUES ('1','0','" + oldStatus + "','" + Session["TransOutID"].ToString() + "','" + eqidd + "','" + locate_idd + "'," +
                                        "'" + oldtoll + "','" + old_name + "','" + oldnameth + "','" + oldserial + "','" + oldseries + "'," +
                                        " '" + oldtype + "','" + oldno + "','" + oldbrand + "','no','" + function.getBudgetYear(txtDateGet.Text) + "','" + datesss + "','" + txtDateGet.Text + "')";

                                if (function.MySqlQuery(sqltranAct))
                                {


                                    sqlUpEQ += "update tbl_equipment trans_complete = '1' ,transfer_idnow = '" + Session["TransOutID"].ToString() + "' WHERE equipment_id = '" + eqidd + "'";
                                    if (function.MySqlQuery(sqlUpEQ))
                                    {

                                        Response.Redirect("/equip/EquipNewTrans");

                                    }
                                    else
                                    {
                                        AlertPop("ERROR upMainEquipment!! บันทึกข้อมูลล้มเหลว", "error");
                                    }

                                }
                                else
                                {
                                    AlertPop("ERROR 4100 บันทึกข้อมูลล้มเหลว", "error");
                                }
                            }
                            ser.Close();
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('กรุณาใส่หมายเลขครุภัณฑ์!!')", true);
                        }
                    }
                    else
                    {
                        AlertPop("เลขครุภัณฑ์ถูกใช้แล้ว กรุณาเลือกใหม่!!", "warning");
                    }

                }
                else
                {
                    AlertPop("Error Check  ติดต่อเจ้าหน้าที่", "warning");
                }


            }
            else
            {
                AlertPop("กรุณาเลือกเลขครุภัณฑ์", "warning");
            }
        }

        protected void GridAddGet_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridAddGet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            string SQLFirst = "";
            string dateSs = GetThaiMonth(txtDateGet.Text);
            string timenow = DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss");
            string userrrname = Session["UserName"].ToString();
            SQLFirst = "INSERT INTO tbl_transfer (company_repair,thai_month,position_sender,trans_note,trans_id,trans_stat,date_send,time_send,user_send,name_send,toll_send,toll_recieve,complete_stat,trans_budget)" +
                            "VALUES ('556','"+dateSs+"','-','-','"+ Session["TransOutID"].ToString()+"','1','"+txtDateGet.Text+"'" +
                            ",'"+timenow+ "','"+ userrrname +"','"+userrrname+"','"+ ddlcompout.SelectedValue + "','" + ddlcompGet.SelectedValue + "','1','" + function.getBudgetYear(txtDateGet.Text) + "'  )";
           if (function.MySqlQuery(SQLFirst))
            {
                //Response.Redirect("/equip/EquipTranGetout");
                div3.Visible = true;
                divbtnNext.Visible = false;
                btnDeleteALL.Visible = true;
                ddlcompout.Enabled = false;
            }
            else
            {
                AlertPop("Error!! First submit :ระบบขัดข้อง ติดต่อเจ้าหน้าที่", "error");
            }
        }
        public string GetThaiMonth(string fulldate)
        {
            string[] subfuldate = fulldate.Split('-');
            string result = "";
            if (subfuldate[1] == "01") { result = "มกราคม"; }
            else if (subfuldate[1] == "02") { result = "กุมภาพันธ์"; }
            else if (subfuldate[1] == "03") { result = "มีนาคม"; }
            else if (subfuldate[1] == "04") { result = "เมษายน"; }
            else if (subfuldate[1] == "05") { result = "พฤษภาคม"; }
            else if (subfuldate[1] == "06") { result = "มิถุนายน"; }
            else if (subfuldate[1] == "07") { result = "กรกฎาคม"; }
            else if (subfuldate[1] == "08") { result = "สิงหาคม"; }
            else if (subfuldate[1] == "09") { result = "กันยายน"; }
            else if (subfuldate[1] == "10") { result = "ตุลาคม"; }
            else if (subfuldate[1] == "11") { result = "พฤศจิกายน"; }
            else if (subfuldate[1] == "12") { result = "ธันวาคม"; }
            return result;
        }
        public void AlertPop(string msg, string type)
        {
            switch (type)
            {
                case "success":
                    icons = "add_alert";
                    alertTypes = "success";
                    break;
                case "error":
                    icons = "error";
                    alertTypes = "danger";
                    break;
                case "warning":
                    icons = "warning";
                    alertTypes = "warning";
                    break;
            }
            //alertType = type;
            alerts = msg;
        }

        protected void btnFinalSubmit_Click(object sender, EventArgs e)
        {
            string equipUpdate = "";
            string TranferUpdate = "";

            string datenow = DateTime.Now.ToString("dd-MM-") + (int.Parse(DateTime.Now.ToString("yyyy")) + 543).ToString();
            string timenow = DateTime.Now.ToString("HH.mm.ss");
            string timenowe = DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss");
            string loge = "Insert into tbl_logtransfer   (trans_stat_id,logt_note,time_log,logt_transID,user_up) " +
                "values ('2','','" + timenowe + "','" + Session["TransID"].ToString() + "','" + Session["UserName"].ToString() + "') ";
            string sqlGet = "UPDATE tbl_transfer SET  date_recieve='" + datenow + "',time_recieve='" + timenow + "'" +
           ",user_recieve='" + Session["UserName"].ToString() + "',name_recieve='" + Session["UserName"].ToString() + "',complete_stat='3' " +
           " WHERE trans_id='" + Session["TransOutID"].ToString() + "'";

            for (int i = 0; i < 51; i++)
            {
                string value = loopGetCommand();
                if (value == "0")
                {
                    if (function.MySqlQuery(sqlGet))
                    {
                        if (function.MySqlQuery(loge))
                        {
                           /* Session["LineTran"] = "ระบบได้รับข้อมูลการตรวจรับครุภัณฑ์  " +
                                " เมื่อวันที่ " + datenow + " \n หมายเลขอ้างอิง : " + Session["TransID"].ToString() + "\n ต้นทาง : " + ddlcompout.SelectedItem + "\n ปลายทาง : " + ddlTollEQ.SelectedItem + "  ";
                            Response.Redirect("/equip/EquipTranGetList");
                            break;
                            /*  SreviceLine.WebService_Server serviceLine = new SreviceLine.WebService_Server();
                              serviceLine.MessageToServer("wDLRWPWgBvJRMEk69ebQVGumxOfiTKCgXoUwKeKPQyh", "ระบบได้รับข้อมูลการตรวจรับครุภัณฑ์  " +
                                  " เมื่อวันที่ "+datenow+ " \n หมายเลขอ้างอิง : "+ Session["TransID"].ToString() + "\n ต้นทาง : " + DropDownList1.SelectedItem + "\n ปลายทาง : " + ddlTollEQ.SelectedItem + "  ", "", 1, 41);
                              */

                        }
                        else
                        {
                            AlertPop("Error!! Can't update LogTrans", "warning");
                            break;
                        }
                    }
                    else
                    {
                        AlertPop("Error!! Can't updateTransfer", "warning");
                        break;
                    }
                }
                else if (value == "error")
                {
                    break;
                }

            }



        }
        protected string loopGetCommand()
        {
            string EQIDloop = ""; string newse = ""; string newserie = ""; string newbrand = "";
            string loopGetAct = "SELECT  *  FROM  tbl_transfer_action " +
                            " WHERE transfer_id = '" + Session["TransOutID"].ToString() + "'  AND num_success = 'no' ORDER BY  trans_act_id DESC  LIMIT 1";

            MySqlDataReader loo = function.MySqlSelect(loopGetAct);
            if (loo.Read())
            {
                EQIDloop = loo.GetString("trans_equip_id");

                if (EQIDloop != "") //ถ้ายังมีเหลือ
                {
                    string updateAct = "";
                    string updateequip = "";
                    
                    updateAct = "UPDATE tbl_transfer_action SET tran_type='1',new_toll = '" + ddlcompGet.SelectedValue + "',num_success='yes' " +
                                   " WHERE trans_equip_id ='" + EQIDloop + "' AND transfer_id = '" + Session["TransID"].ToString() + "' ";
                    updateequip = "UPDATE tbl_equipment SET trans_complete = '0',toll_id='" + ddlcompGet.SelectedValue + "' " +
                                   " WHERE equipment_id ='" + EQIDloop + "' ";
                    
                    if (function.MySqlQuery(updateAct))
                    {
                        
                        if (function.MySqlQuery(updateequip))
                        {
                            loo.Close();
                            return "1";
                        }
                        else
                        {
                            AlertPop("Error Get002 ติดต่อเจ้าหน้าที่", "warning");
                            loo.Close();
                            return "error";
                        }
                        
                    }
                    else
                    {
                        AlertPop("Error Get001 ติดต่อเจ้าหน้าที่", "warning");
                        loo.Close();
                        return "error";
                    }
                }
                else
                {
                    loo.Close();
                    return "0";
                }
                
            }
            else
            {
                loo.Close();
                //AlertPop("Error MysqlRead!! ติดต่อเจ้าหน้าที่", "error");
                return "0";
            }
    
        }

   
        protected void btnPlanSheet_Click(object sender, EventArgs e)
        {

        }

        protected void ddlcompout_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlbinding();
        }

        protected void btnDeleteALL_Click(object sender, EventArgs e)
        {
            string tranDelete = "delete FROM tbl_transfer WHERE trans_id = '"+ Session["TransOutID"].ToString() + "' ";
            for (int i = 0; i < 51; i++)
            {
                string valueDelete = DeleteCommand();
                if (valueDelete == "0")
                {
                    if (function.MySqlQuery(tranDelete))
                    {
                        
                        Response.Redirect("/equip/EquipTranOutList");
                        break;

                    }
                    else
                    {
                        AlertPop("Error Can't Delete ALL  ติดต่อเจ้าหน้าที่", "warning");
                        break;
                    }
                }
                else if (valueDelete == "error")
                {
                    break;
                }

            }
        }
        protected string DeleteCommand()
        {
            string loopDeleteActEQ = "SELECT  trans_equip_id,old_status  FROM  tbl_transfer_action " +
                " WHERE transfer_id = '" + Session["TransID"].ToString() + "'  ORDER BY  trans_act_id DESC  LIMIT 1";
            
            MySqlDataReader lop = function.MySqlSelect(loopDeleteActEQ);
            if (lop.Read()) //ถ้ามีคำนวณต่อ
            {
                string eqid = lop.GetInt32("trans_equip_id").ToString();
                string oldstat = lop.GetInt32("old_status").ToString();
                string deleteAct = "DELETE FROM tbl_transfer_action WHERE transfer_id = '" + Session["TransID"].ToString() + "' AND trans_equip_id = '" + eqid + "' ";
                string deleteEquip = "UPDATE tbl_equipment SET Estatus_id='" + oldstat + "',trans_complete = '0' WHERE equipment_id ='" + eqid + "'";
                if (function.MySqlQuery(deleteAct))
                {
                    if (function.MySqlQuery(deleteEquip))
                    {
                        lop.Close();
                        return "1";
                    }
                    else
                    {
                        AlertPop("Error Can't Change Equip Normal ติดต่อเจ้าหน้าที่", "warning");
                        lop.Close();
                        return "error";
                    }
                }
                else
                {
                    AlertPop("Error Can't Delete EQ From Act ติดต่อเจ้าหน้าที่", "warning");
                    lop.Close();
                    return "error";
                }
            }
            else //ไม่มีให้อัพเดทรายการลบแล้ว
            {
                lop.Close();
                return "0";
            }


        }

        protected void btnMainGetout_Click(object sender, EventArgs e)
        {
            Response.Redirect("/equip/EquipTranOutList");
        }
    }
}