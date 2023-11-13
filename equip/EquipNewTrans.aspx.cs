using System;
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
    public partial class EquipNewTrans : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public string alerts = "";
        public string alertTypes = "";
        public string icons = "";
        public string replaceids = "";
        public string confirmGet = "";
        public string HitBack = "";
        public string Print = "";
        public int amountrow;
        public int wait; 
        public int norepair; 
        public int repairedd;
        public string no = "";
        public string ok = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/");
            }

            if (!this.IsPostBack)
            {
                string top = Session["TransID"].ToString();
                string equipNo = "";
                string tollStart = "";
                string chhh = Session["UserPrivilegeId"].ToString();
                string usercpo = Session["UserCpoint"].ToString();

                Session["TranRepId"] = "";

                if (usercpo == "0")
                {
                    //qry หมาบเลขครุภัณฑ์ เกินความจำเป็น? by aek
                    equipNo = "SELECT equipment_no,equipment_id FROM tbl_equipment ";
                    equipNo += "WHERE Estatus_id != '3' AND Estatus_id != '4' AND trans_complete = '0' AND toll_id = '9200' ";
                    equipNo += "Order By equipment_id ASC";
                    tollStart = "SELECT * FROM tbl_toll WHERE toll_id = '9200' ";
                    function.getListItem(ddlNewLocated, "SELECT * FROM tbl_location WHERE locate_group = '3' Order By locate_id ", "locate_name", "locate_id");
                }
                else
                {
                    tollStart = "SELECT * FROM tbl_toll WHERE cpoint_id = '" + Session["UserCpoint"].ToString() + "' ";
                    //qry หมาบเลขครุภัณฑ์ เกินความจำเป็น? by aek
                    equipNo = "SELECT equipment_no,equipment_id FROM tbl_equipment" ;
                    equipNo += " JOIN tbl_toll on tbl_toll.toll_id = tbl_equipment.toll_id ";
                    equipNo += " WHERE tbl_toll.cpoint_id = '" + Session["UserCpoint"].ToString() + "' AND Estatus_id != '3' AND Estatus_id != '4' AND trans_complete = '0' ";
                    function.getListItem(ddlNewLocated, "SELECT * FROM tbl_location WHERE locate_group != '3' Order By locate_id ", "locate_name", "locate_id");
                }
                txtSender.Text = Session["UserName"].ToString();
                string user = Session["UserName"].ToString();
                function.getListItem(DropDownList1, "SELECT * FROM tbl_toll Order by toll_id ASC ", "toll_name", "toll_id");
                function.getListItem(ddlPosition, "SELECT * FROM tbl_position WHERE position_group = '2' Order By position_id", "position_name", "position_id");
                function.getListItem(ddlposGet, "SELECT * FROM tbl_position WHERE position_group = '2' Order By position_id", "position_name", "position_name");
                function.getListItem(ddlStartEQ, tollStart, "toll_name", "toll_id");
                function.getListItem(txtEquipTrans, equipNo, "equipment_no", "equipment_id");
                txtEquipTrans.Items.Insert(0, new ListItem("", ""));
                function.getListItem(ddlreplace, equipNo, "equipment_no", "equipment_id");
                ddlreplace.Items.Insert(0, new ListItem("", ""));
                //string ucpoint = Session["UserCpoint"].ToString();
                LoadDataPaging();
                inputDDLSELECT();
                //AddTransDatabind("ADD");
            }
        }

        protected void inputDDLSELECT()
        {
            string EQDDL = "";
            if (Session["UserCpoint"].ToString() == "0")
            {
                EQDDL = "SELECT equipment_no,equipment_id FROM tbl_equipment WHERE Estatus_id != '3' AND Estatus_id != '4' AND trans_complete != '1' AND toll_id = '9200' AND equipment_chkUpdateLocate ='0' Order By equipment_id ASC";
            }
            else
            {
                EQDDL = "SELECT * FROM tbl_equipment" +
                       "  WHERE toll_id = '" + ddlStartEQ.SelectedValue + "' AND Estatus_id != '3' AND Estatus_id != '4' AND trans_complete != '1' AND equipment_chkUpdateLocate ='0' ";
            }
            function.getListItem(txtEquipTrans, EQDDL, "equipment_no", "equipment_id");
            txtEquipTrans.Items.Insert(0, new ListItem("", ""));
            function.getListItem(ddlreplace, EQDDL, "equipment_no", "equipment_id");
            ddlreplace.Items.Insert(0, new ListItem("", ""));
        }

        protected void LoadDataPaging()
        {
            string startvalue = "";
            string endvalue = "";
            if (Session["TransNew"].ToString() == "1")
            {
                function.getListItem(ddlTollEQ, "SELECT * FROM tbl_toll Order By toll_id ASC", "toll_name", "toll_id");
                function.getListItem(ddlStartEQ, "SELECT * FROM tbl_toll Order By toll_id ASC", "toll_name", "toll_id");
                function.getListItem(ddlTypeEQQ, "SELECT * FROM tbl_transfer_status Order By trans_stat_id", "trans_stat_name", "trans_stat_id");
                btnFistSubmit.Visible = false;
                string selectData = "SELECT * FROM tbl_transfer " +
                    " JOIN tbl_trans_complete ON tbl_trans_complete.complete_id = tbl_transfer.complete_stat  " +
                    " WHERE trans_id = '" + Session["TransID"].ToString() + "' ";
                MySqlDataReader redf = function.MySqlSelect(selectData);
                if (redf.Read())
                {
                    string completestatus = redf.GetString("complete_stat");
                    string transtatt = redf.GetString("trans_stat");
                    ddlTypeEQQ.SelectedValue = transtatt;
                    //string completestatus = redf.GetString("complete_stat");
                    refnoo.Text = " (เลขอ้างอิง : " + Session["TransID"].ToString() + " / สถานะ : ";
                    stathead.Text = redf.GetString("complete_name") + " ";
                    stathead.CssClass = "badge badge-" + redf.GetString("complete_badge");
                    endvalue = redf.GetInt32("toll_recieve").ToString();
                    startvalue = redf.GetInt32("toll_send").ToString();
                    ddlTollEQ.SelectedValue = endvalue;
                    ddlStartEQ.SelectedValue = startvalue;
                    txtDateSend.Text = redf.GetString("date_send");
                    txtactnote.Text = redf.GetString("trans_note");
                    txtSender.Text = redf.GetString("name_send");
                    ddlPosition.SelectedValue = redf.GetString("position_sender");
                    if (completestatus == "3" || completestatus == "4")
                    {
                        divtranthird.Visible = true;
                        //lbDateCF.Text = redf.GetString("date_recieve");
                        //lbTimeCF.Text = redf.GetString("time_recieve");
                        //lbNameCF.Text = redf.GetString("name_recieve");
                        if (redf.IsDBNull(20) || redf.IsDBNull(8) || redf.IsDBNull(9) || redf.IsDBNull(11) || redf.IsDBNull(26))
                        {
                            lbPositionCF.Text = "ไม่ระบุ";
                            lbDateCF.Text = "ไม่ระบุ";
                            lbTimeCF.Text = "ไม่ระบุ";
                            lbNameCF.Text = "ไม่ระบุ";
                            txtTimeSend.Text = "ไม่ระบุ";
                        }
                        else
                        {
                            lbPositionCF.Text = redf.GetString("position_getder");
                            lbDateCF.Text = redf.GetString("date_recieve");
                            lbTimeCF.Text = redf.GetString("time_recieve");
                            lbNameCF.Text = redf.GetString("name_recieve");
                            txtTimeSend.Text = redf.GetString("time_send");
                        }
                    }
                    else
                    {
                        lbDateCF.Text = "-";
                        lbTimeCF.Text = "-";
                        lbNameCF.Text = "-";
                        lbPositionCF.Text = "-";
                        txtTimeSend.Text = redf.GetString("time_send");
                    }

                    divtranSecond.Visible = true;
                    divSubmitFirst.Visible = false;
                    //string ucpoint = Session["UserCpoint"].ToString();
                    //string tollbvalue = ddlTollEQ.SelectedValue;
                    string tollbvalue = ddlStartEQ.SelectedValue;
                    string sameucpoint = "";

                    if (tollbvalue == "7010")
                    {
                        sameucpoint = "701";
                    }
                    else if (tollbvalue == "7020")
                    {
                        sameucpoint = "702";
                    }
                    else if (tollbvalue == "7031" || tollbvalue == "7032" || tollbvalue == "7033")
                    {
                        sameucpoint = "703";
                    }
                    else if (tollbvalue == "7041" || tollbvalue == "7042")
                    {
                        sameucpoint = "704";
                    }
                    else if (tollbvalue == "7051" || tollbvalue == "7052")
                    {
                        sameucpoint = "706";
                    }
                    else if (tollbvalue == "7061" || tollbvalue == "7062" || tollbvalue == "7063" || tollbvalue == "7064")
                    {
                        sameucpoint = "707";
                    }
                    else if (tollbvalue == "7071" || tollbvalue == "7072" || tollbvalue == "7073" || tollbvalue == "7074"
                        || tollbvalue == "7075" || tollbvalue == "7076")
                    {
                        sameucpoint = "708";
                    }
                    else if (tollbvalue == "7081" || tollbvalue == "7082" || tollbvalue == "7083" || tollbvalue == "7084")
                    {
                        sameucpoint = "709";
                    }
                    else if (tollbvalue == "7090")
                    {
                        sameucpoint = "710";
                    }
                    else if (tollbvalue == "9010")
                    {
                        sameucpoint = "902";
                    }
                    else if (tollbvalue == "9020")
                    {
                        sameucpoint = "903";
                    }
                    else if (tollbvalue == "9030")
                    {
                        sameucpoint = "904";
                    }
                    else if (tollbvalue == "9040")
                    {
                        sameucpoint = "905";
                    }
                    else if (tollbvalue == "9200")
                    {
                        sameucpoint = "920";
                    }
                    else if (tollbvalue == "7100")
                    {
                        sameucpoint = "711";
                    }
                    else if (tollbvalue == "7110")
                    {
                        sameucpoint = "712";
                    }
                    else if (tollbvalue == "7120")
                    {
                        sameucpoint = "713";
                    }
                    else
                    {
                        sameucpoint = "920";
                    }

                    if (ddlTypeEQQ.SelectedValue == "5") //ประเภททดแทน
                    {
                        divnormal.Visible = false;
                        divnewserial.Visible = true;
                        ddlTypeEQQ.BackColor = System.Drawing.ColorTranslator.FromHtml("#fffec2");
                        AddTransDatabind("replace");
                    }
                    else
                    {
                        divreplace.Visible = false;
                        divnormal.Visible = true;
                        divnewserial.Visible = false;
                        if (ddlTypeEQQ.SelectedValue == "4")
                        {
                            ddlTypeEQQ.BackColor = System.Drawing.ColorTranslator.FromHtml("#ede0ff");
                            //RepaireDatabind();
                            if (completestatus == "6" || completestatus == "3")
                            {
                                RepaireDatabind();
                            }
                            else
                            {
                                AddTransDatabind("ADD");
                            }
                        }
                        else
                        {
                            ddlTypeEQQ.BackColor = System.Drawing.ColorTranslator.FromHtml("#dbfff8");
                            AddTransDatabind("ADD");
                        }
                    }

                    if (completestatus == "2")
                    {
                        divhitback.Visible = false;
                        ddlTypeEQQ.Enabled = false;
                        divEndToll.Visible = true;
                        txtDateSend.Enabled = false;
                        txtTimeSend.Enabled = false;
                        txtactnote.Enabled = false;
                        txtSender.Enabled = false;
                        ddlPosition.Enabled = false;
                        divnewserial.Visible = false;
                        divnormal.Visible = false;
                        divreplace.Visible = false;
                        divsecond.Visible = false;
                        gridreplace.Enabled = false;
                        GridAddTran.Enabled = false;
                        DropDownList1.Enabled = false;
                        DropDownList1.SelectedValue = redf.GetString("toll_send");
                        ddlStartEQ.Enabled = false;
                        ddlTollEQ.Enabled = false;
                        if (Session["UserCpoint"].ToString() == "0")
                        {
                            if (Session["UserName"].ToString() == txtSender.Text)
                            {
                                btnEdit.Visible = true;
                                lbtnDelete.Visible = true;
                            }

                            if (Session["UserPrivilegeId"].ToString() == "5")
                            {
                                btnGet.Visible = true;
                                btnBackto.Visible = true;
                                //btnPrintNoteSup.Visible = false;
                            }
                            /**
                            else
                            {
                                if (!function.CheckLevel("Viewer", Session["UserPrivilegeId"].ToString()))
                                {
                                    divfirst.Visible = true;
                                }
                                else
                                {
                                    btnGet.Visible = true;
                                    btnBackto.Visible = true;
                                    divfirst.Visible = true;
                                    txtEquipTrans.Enabled = false;
                                    btnAddEQTran.Enabled = false;
                                    ddlreplace.Enabled = false;
                                    lbtnreplace.Enabled = false;
                                    btnEdit.Visible = false;
                                    lbtnDelete.Visible = false;
                                }                              
                            }
                            **/
                        }
                        else
                        {
                            divfirst.Visible = true;
                            if (Session["UserCpoint"].ToString() == sameucpoint) //ด่านฯผู้ใช้กับด่านผู้รับตรงกัน
                            {
                                btnGet.Visible = false;
                                btnBackto.Visible = false;
                                btnEdit.Visible = true;
                            }
                            else
                            {
                                txtEquipTrans.Enabled = false;
                                btnAddEQTran.Enabled = false;
                                ddlreplace.Enabled = false;
                                lbtnreplace.Enabled = false;
                                btnGet.Visible = true;
                                btnBackto.Visible = true;
                            }

                        }
                    }
                    else if (completestatus == "1")
                    {

                        txtTimeSend.Enabled = false;
                        divhitback.Visible = false;
                        divsecond.Visible = false;
                        //ddlStartEQ.Enabled = false;
                        ddlStartEQ.Enabled = false;
                        ddlTollEQ.Enabled = false;
                        if (Session["UserName"].ToString() == txtSender.Text)
                        {
                            GridAddTran.Enabled = true;
                            gridreplace.Enabled = true;
                            lbtnDelete.Visible = true;
                            btnPlanSheet.Visible = true;
                            divEndToll.Visible = true;
                            if (amountrow != 0)
                            {
                                if (ddlTypeEQQ.SelectedValue == "4")
                                {
                                    btnSendRepair.Visible = true;
                                }
                                else
                                {
                                    btnSecondSubmit.Visible = true;

                                }

                            }
                        }
                        else
                        {
                            GridAddTran.Enabled = false;
                            gridreplace.Enabled = false;
                            txtEquipTrans.Enabled = false;
                            btnAddEQTran.Enabled = false;
                            ddlreplace.Enabled = false;
                            lbtnreplace.Enabled = false;
                            divEndToll.Visible = true;
                            lbtnDelete.Visible = false;
                            btnSecondSubmit.Visible = false;
                            btnPlanSheet.Visible = false;
                        }
                        if (Session["UserPrivilegeId"].ToString() == "0")
                        {
                            lbtnDelete.Visible = true;
                        }
                    }
                    else if (completestatus == "4")
                    {
                        ddlStartEQ.Enabled = false;
                        ddlTollEQ.Enabled = false;

                        divsecond.Visible = false;
                        divhitback.Visible = true;
                        divEndToll.Visible = true;
                        string getHitNote = "Select logt_note FROM tbl_logtransfer WHERE logt_transID = '" + Session["TransID"].ToString() + "' " +
                            " AND trans_stat_id = '4' Order by logt_id DESC LIMIT 1";
                        MySqlDataReader note = function.MySqlSelect(getHitNote);
                        if (note.Read())
                        {
                            NoteHitback.Text = "เหตุผลการตีกลับเอกสาร : " + note.GetString("logt_note");
                            note.Close();
                        }
                        if (Session["UserName"].ToString() == txtSender.Text)
                        {
                            GridAddTran.Enabled = true;
                            gridreplace.Enabled = true;
                            lbtnDelete.Visible = true;
                            btnPlanSheet.Visible = true;
                            if (amountrow != 0)
                            {
                                btnSecondSubmit.Visible = true;
                            }
                            else
                            {
                                btnSecondSubmit.Visible = false;
                            }
                        }
                        else
                        {
                            //divfirst.Visible = false;
                            //ddlStartEQ.Visible = false;
                            GridAddTran.Enabled = false;
                            gridreplace.Enabled = false;
                            txtEquipTrans.Enabled = false;
                            btnAddEQTran.Enabled = false;
                            ddlreplace.Enabled = false;
                            lbtnreplace.Enabled = false;
                            lbtnDelete.Visible = false;
                            btnSecondSubmit.Visible = false;
                            btnPlanSheet.Visible = false;
                        }

                    }
                    else if (completestatus == "3")
                    {
                        GridAddTran.Enabled = false;
                        gridreplace.Enabled = false;
                        GridRepair.Enabled = false;
                        divhitback.Visible = false;
                        btnSecondSubmit.Visible = false;
                        btnEdit.Visible = false;
                        btnGet.Visible = false;
                        btnBackto.Visible = false;
                        lbtnDelete.Visible = false;
                        divreplace.Visible = false;
                        divnormal.Visible = false;
                        divnewserial.Visible = false;
                        ddlTypeEQQ.Enabled = false;
                        if (Session["UserName"].ToString() != txtSender.Text)
                        {
                            divfirst.Visible = true;
                            ddlStartEQ.Visible = true;
                        }
                        ddlStartEQ.Enabled = false;
                        if (ddlTypeEQQ.SelectedValue == "4")
                        {
                            //divcompany.Visible = true;
                            //ddlcompany.Enabled = false;
                        }
                        else
                        {
                            divEndToll.Visible = true;
                            ddlTollEQ.Enabled = false;
                        }
                        DropDownList1.Enabled = false;
                        txtDateSend.Enabled = false;
                        txtSender.Enabled = false;
                        ddlPosition.Enabled = false;

                    }
                    else if (completestatus == "6")
                    {
                        ddlStartEQ.Enabled = false;
                        ddlTollEQ.Enabled = false;
                        txtactnote.Enabled = false;
                        //divcompany.Visible = true;
                        DropDownList1.Enabled = false;
                        txtDateSend.Enabled = false;
                        txtSender.Enabled = false;
                        ddlPosition.Enabled = false;
                        btnRepaired.Visible = true;

                        GridAddTran.Enabled = false;
                        gridreplace.Enabled = false;
                        divhitback.Visible = false;
                        btnSecondSubmit.Visible = false;
                        btnEdit.Visible = true;
                        btnGet.Visible = false;
                        btnBackto.Visible = false;
                        lbtnDelete.Visible = false;
                        divreplace.Visible = false;
                        divnormal.Visible = false;
                        divnewserial.Visible = false;
                        ddlTypeEQQ.Enabled = false;
                    }
                    else if (completestatus == "7")
                    {
                        ddlTypeEQQ.Enabled = false;
                        ddlStartEQ.Enabled = false;
                        ddlTollEQ.Enabled = false;
                        txtactnote.Enabled = false;
                        DropDownList1.Enabled = false;
                        txtDateSend.Enabled = false;
                        txtSender.Enabled = false;
                        ddlPosition.Enabled = false;
                        divEndToll.Visible = true;
                        GridAddTran.Enabled = false;
                        gridreplace.Enabled = false;
                        btnAddEQTran.Enabled = false;
                        divnormal.Visible = false;
                        btnReturn.Visible = true;
                    }
                    redf.Close();
                }
            }
            else
            {
                string ucpo = Session["UserCpoint"].ToString();
                if (ucpo == "0")
                {

                    function.getListItem(ddlTypeEQQ, "SELECT * FROM tbl_transfer_status Order By trans_stat_id", "trans_stat_name", "trans_stat_id");
                    changeDropdown(ucpo);
                    ddlTollEQ.Enabled = true;
                }
                else //level_group
                {
                    function.getListItem(ddlTypeEQQ, "SELECT * FROM tbl_transfer_status WHERE group_stat = '1' Order By trans_stat_id", "trans_stat_name", "trans_stat_id");
                    changeDropdown(ucpo);

                    //ddlcompany.Enabled = false;
                }

                divEndToll.Visible = true;
                btnFistSubmit.Visible = true;
            }

            switch (Session["UserPrivilegeId"].ToString())
            {
                case "0"://admin
                    btnGet.Visible = true;
                    btnBackto.Visible = true;
                    lbtnDelete.Visible = true;
                    btnEdit.Visible = true;
                    break;
                case "1"://เทคโน

                    break;
                case "2"://คอม

                    //btnPrintNoteSup.Visible = true;
                    break;
                case "3"://รอง

                    //btnPrintNoteSup.Visible = true;
                    break;
                case "4"://สถิติ

                    //btnPrintNoteSup.Visible = false;
                    break;
                case "5"://ครุภัณฑ์
                    //btnGet.Visible = true;
                    //btnBackto.Visible = true;
                    //btnPrintNoteSup.Visible = false;
                    break;
                case "6"://viewer
                    btnEdit.Visible = false;
                    btnRepaired.Visible = false;
                    //btnPrintNoteSup.Visible = false;
                    break;
                default:
                    //btnPrintNoteSup.Visible = false;
                    break;
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

        protected void btnAddEQTran_Command(object sender, CommandEventArgs e)
        {
            string sqltranAct = "";
            string sqltran = "";
            string sqlUpEQ = "";
            string ThMonth = GetThaiMonth(txtDateSend.Text);
            if (txtEquipTrans.SelectedItem.ToString() != "")
            {
                string get = txtEquipTrans.SelectedItem.ToString();
                string checkEQnum = "Select trans_complete FROM tbl_equipment WHERE equipment_no = '" + get + "'";
                string hasno = "";
                MySqlDataReader chknum = function.MySqlSelect(checkEQnum);
                if (chknum.Read())
                {
                    hasno = chknum.GetString("trans_complete");
                    chknum.Close();
                    if (hasno == "0")
                    {
                        string sqlLocate = "select * FROM tbl_equipment WHERE equipment_no = '" + txtEquipTrans.SelectedItem.ToString() + "'";
                        MySqlDataReader ser = function.MySqlSelect(sqlLocate); //เช็ครหัสตู้ครุภัณฑ์
                        string locate_idd = "";
                        string eqidd = "";
                        string oldtoll = ""; string old_name = "";
                        string oldnameth = ""; string oldserial = ""; string oldtype = ""; string oldbrand = "";
                        string actNote = txtactnote.Text; string oldseries = ""; string oldno = ""; string user = ""; string oldStatus = "";
                        string completeStat = "";
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
                            if (ddlTypeEQQ.SelectedValue == "3" || ddlTypeEQQ.SelectedValue == "4")
                            {
                                completeStat = "1";
                            }
                            else { completeStat = "1"; }

                            if (ddlTypeEQQ.SelectedValue == "4")
                            {
                                sqlUpEQ = "UPDATE tbl_equipment SET Estatus_id='2',trans_complete = '" + completeStat + "' ,transfer_idnow = '" + Session["TransID"].ToString() + "',equipment_chkUpdateLocate = '0' WHERE equipment_id = '" + eqidd + "'";
                            }
                            else
                            {
                                sqlUpEQ = "UPDATE tbl_equipment SET trans_complete = '" + completeStat + "' ,transfer_idnow = '" + Session["TransID"].ToString() + "',equipment_chkUpdateLocate = '0' WHERE equipment_id = '" + eqidd + "'";
                            }

                            string today = DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss");
                            string sqx = "SELECT * FROM tbl_transfer WHERE trans_id = '" + Session["TransID"].ToString() + "'";
                            string datesss = GetThaiMonth(txtDateSend.Text);
                            MySqlDataReader rs = function.MySqlSelect(sqx);
                            if (!rs.Read())  //กรณียังไม่มีเลข Ref 
                            {
                                string toll_end = ddlTollEQ.SelectedValue;

                                sqltran = "INSERT INTO tbl_transfer (company_repair,thai_month,position_sender,trans_note,trans_id,trans_stat,date_send,time_send,user_send,name_send,toll_send,toll_recieve,complete_stat,trans_budget)" +
                                 "VALUES ('556','" + datesss + "','" + ddlPosition.SelectedValue + "','" + actNote + "','" + Session["TransID"].ToString() + "','" + ddlTypeEQQ.SelectedValue + "','" + txtDateSend.Text + "','" + today + "','" + Session["UserName"].ToString() + "'" +
                                 ",'" + txtSender.Text + "','" + ddlStartEQ.SelectedValue + "','" + toll_end + "','" + completeStat + "','" + function.getBudgetYear(txtDateSend.Text) + "')";

                                if (function.MySqlQuery(sqltran))
                                {
                                    sqltranAct = "INSERT INTO tbl_transfer_action " +
                                        "(tran_type,repair_action,old_status,transfer_id,trans_equip_id,old_locate,old_toll,old_name,old_nameth,old_serial,old_series" +
                                        ",old_type,old_no,old_person,old_brand,num_success,budget_y,month_y,date_y) " +
                                        " VALUES ('" + ddlTypeEQQ.SelectedValue + "','0','" + oldStatus + "','" + Session["TransID"].ToString() + "','" + eqidd + "','" + locate_idd + "'," +
                                        "'" + oldtoll + "','" + old_name + "','" + oldnameth + "','" + oldserial + "','" + oldseries + "'," +
                                        " '" + oldtype + "','" + oldno + "','" + user + "','" + oldbrand + "','no','" + function.getBudgetYear(txtDateSend.Text) + "','" + datesss + "','" + txtDateSend.Text + "')";
                                    if (function.MySqlQuery(sqltranAct))
                                    {
                                        if (ddlTypeEQQ.SelectedValue != "3" && ddlTypeEQQ.SelectedValue != "4")
                                        {
                                            if (function.MySqlQuery(sqlUpEQ))
                                            {
                                                Response.Redirect("/equip/EquipNewTrans");
                                                //AddTransDatabind("ADD");
                                                //Cleartxt();
                                                //AlertPop("success เพิ่มครุภัณฑ์แล้ว 1", "success");
                                            }
                                            else
                                            {
                                                AlertPop("ERROR final บันทึกข้อมูลล้มเหลว", "error");
                                            }
                                        }
                                        else
                                        {
                                            Response.Redirect("/equip/EquipNewTrans");
                                            //AddTransDatabind("ADD");
                                            //Cleartxt();
                                            //AlertPop("success เพิ่มครุภัณฑ์แล้ว 2", "success");
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
                                string toll_end = ddlTollEQ.SelectedValue;

                                sqltran = "INSERT INTO tbl_transfer (company_repair,thai_month,position_sender,trans_note,trans_id,trans_stat,date_send,time_send,user_send,name_send,toll_send,toll_recieve,complete_stat,trans_budget)" +
                                 "VALUES ('556','" + datesss + "','" + ddlPosition.SelectedValue + "','" + actNote + "','" + Session["TransID"].ToString() + "','" + ddlTypeEQQ.SelectedValue + "','" + txtDateSend.Text + "','" + today + "','" + Session["UserName"].ToString() + "'" +
                                 ",'" + txtSender.Text + "','" + ddlStartEQ.SelectedValue + "','" + toll_end + "','" + completeStat + "','" + function.getBudgetYear(txtDateSend.Text) + "')";

                                sqltranAct = "INSERT INTO tbl_transfer_action " +
                                        "(tran_type,repair_action,old_status,transfer_id,trans_equip_id,old_locate,old_toll,old_name,old_nameth,old_serial,old_series" +
                                        ",old_type,old_no,old_brand,num_success,budget_y,month_y,date_y) " +
                                        " VALUES ('" + ddlTypeEQQ.SelectedValue + "','0','" + oldStatus + "','" + Session["TransID"].ToString() + "','" + eqidd + "','" + locate_idd + "'," +
                                        "'" + oldtoll + "','" + old_name + "','" + oldnameth + "','" + oldserial + "','" + oldseries + "'," +
                                        " '" + oldtype + "','" + oldno + "','" + oldbrand + "','no','" + function.getBudgetYear(txtDateSend.Text) + "','" + datesss + "','" + txtDateSend.Text + "')";

                                if (function.MySqlQuery(sqltranAct))
                                {
                                    if (function.MySqlQuery(sqlUpEQ))
                                    {
                                        Response.Redirect("/equip/EquipNewTrans");
                                        //AddTransDatabind("ADD");
                                        //Cleartxt();
                                        //AlertPop("success เพิ่มครุภัณฑ์แล้ว 4", "success");
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

        protected void RepaireDatabind()
        {
            string pkref = Session["TransID"].ToString();
            string sqlGridRepair = "Select * FROM tbl_transfer_action WHERE transfer_id = '" + pkref + "' Order by trans_act_id ASC ";
            MySqlDataAdapter da = function.MySqlSelectDataSet(sqlGridRepair);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridRepair.DataSource = dt;
            amountrow = dt.Rows.Count;
            lbchkTotal.Text = amountrow.ToString();
            lbshowamount.Text = "จำนวน " + amountrow.ToString() + " รายการ";
            GridRepair.DataBind();
        }

        protected void AddTransDatabind(string whatgrid)
        {
            string TransRef = Session["TransID"].ToString();
            string sqlx = "SELECT * FROM tbl_transfer_action d  " +
                         " WHERE d.transfer_id = '" + TransRef + "' Order By d.trans_act_id ASC ";
            MySqlDataAdapter da = function.MySqlSelectDataSet(sqlx);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (whatgrid == "ADD")
            {
                GridAddTran.DataSource = dt;
                amountrow = dt.Rows.Count;
                lbshowamount.Text = "จำนวน " + amountrow.ToString() + " รายการ";
                GridAddTran.DataBind();
            }
            else
            {
                gridreplace.DataSource = dt;
                amountrow = dt.Rows.Count;
                lbshowamount.Text = "จำนวน " + amountrow.ToString() + " รายการ";
                gridreplace.DataBind();
            }
        }

        protected void GridAddTran_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string eqidede = "";
            string oldstatuss = "";
            string StatReturnNormal = "";
            string sql = "DELETE FROM tbl_transfer_action WHERE trans_act_id = '" + GridAddTran.DataKeys[e.RowIndex].Value + "'";
            string selectequipid = "select trans_equip_id,old_status FROM tbl_transfer_action WHERE trans_act_id = '" + GridAddTran.DataKeys[e.RowIndex].Value + "'";
            MySqlDataReader idid = function.MySqlSelect(selectequipid);
            if (idid.Read())
            {
                eqidede = idid.GetString("trans_equip_id");
                oldstatuss = idid.GetInt32("old_status").ToString();
                idid.Close();
                StatReturnNormal = "UPDATE tbl_equipment SET Estatus_id='" + oldstatuss + "',trans_complete = '0' ,transfer_idnow = '' ,equipment_chkUpdateLocate = '0' WHERE equipment_id = '" + eqidede + "'";
                if (function.MySqlQuery(StatReturnNormal))
                {
                    if (function.MySqlQuery(sql))
                    {
                        Response.Redirect("/equip/EquipNewTrans");
                    }
                    else
                    {
                        AlertPop("ระบบขัดข้อง ลบข้อมูลล้มเหลว ติดต่อเจ้าหน้าที่", "error");
                    }
                }
                else
                {
                    AlertPop("ระบบขัดข้อง Update ข้อมูลล้มเหลว ติดต่อเจ้าหน้าที่", "error");
                }
                function.Close();
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('" + script + "')", true);
                GridAddTran.EditIndex = -1;
                AddTransDatabind("ADD");
            }
            else
            {
                AlertPop("ระบบขัดข้อง ลบข้อมูลล้มเหลว ติดต่อเจ้าหน้าที่", "error");
            }

            //string script = "";

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

        protected void GridAddTran_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbRowNum = (Label)(e.Row.FindControl("lbRowNum"));
            if (lbRowNum != null)
            {
                lbRowNum.Text = (GridAddTran.Rows.Count + 1).ToString() + ".";
            }

            Label TextBox1 = (Label)(e.Row.FindControl("TextBox1"));
            if (TextBox1 != null)
            {

            }
        }

        protected void changeDropdown(string Ucpoint)
        {
            if (Ucpoint == "0")//ฝ่ายฯ
            {
                if (ddlTypeEQQ.SelectedValue == "4")
                {
                    function.getListItem(ddlTollEQ, "SELECT * FROM tbl_toll where toll_EQGroup = '9' Order By toll_id ASC", "toll_name", "toll_id");
                }
                else if (ddlTypeEQQ.SelectedValue == "7")
                {
                    function.getListItem(ddlTollEQ, "SELECT * FROM tbl_toll where in_outdepart = '1' Order By toll_id ASC", "toll_name", "toll_id");
                }
                else
                {
                    function.getListItem(ddlTollEQ, "SELECT * FROM tbl_toll Order By toll_id ASC", "toll_name", "toll_id");
                }
            }
            else //ด่านฯ
            {
                if (ddlTypeEQQ.SelectedValue == "4")
                {
                    function.getListItem(ddlTollEQ, "SELECT * FROM tbl_toll where toll_EQGroup = '9' ", "toll_name", "toll_id");
                    //function.getListItem(ddlTollEQ, "SELECT * FROM tbl_company WHERE company_status != '1' ORDER BY company_status ASC , company_status DESC ", "company_name", "company_id");
                }
                else
                {
                    function.getListItem(ddlTollEQ, "SELECT * FROM tbl_toll where toll_id = '9200' OR toll_id = '9400' ", "toll_name", "toll_id");
                }
            }

        }

        protected void ddlTypeEQQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            string levelcpoint = Session["UserCpoint"].ToString();

            /*if (ddlTypeEQQ.SelectedValue == "6")
            {
                divEndToll.Visible = true;
                ddlTollEQ.SelectedValue = "9300";
                divnormal.Visible = true;
                divnewserial.Visible = false;
                ddlTypeEQQ.BackColor = System.Drawing.ColorTranslator.FromHtml("#fffec2");
                ddlTollEQ.Enabled = true;
            }
            else if (ddlTypeEQQ.SelectedValue == "5")
            {
                divEndToll.Visible = true;
                divnormal.Visible = false;
                divnewserial.Visible = true;
                ddlTypeEQQ.BackColor = System.Drawing.ColorTranslator.FromHtml("#fffec2");
                ddlTollEQ.Enabled = true;
            }
            else if (ddlTypeEQQ.SelectedValue == "4")
            {
                divEndToll.Visible = true;
                divreplace.Visible = false;
                divnormal.Visible = true;
                divnewserial.Visible = false;
                ddlTypeEQQ.BackColor = System.Drawing.ColorTranslator.FromHtml("#ede0ff");
                divnormal.Style.Add("background-color", "#ede0ff");
                ddlTollEQ.Enabled = true;
                changeDropdown(levelcpoint);
            }
            else if (ddlTypeEQQ.SelectedValue == "2")
            {
                divEndToll.Visible = true;
                divreplace.Visible = false;
                divnormal.Visible = true;
                divnewserial.Visible = false;
                ddlTypeEQQ.BackColor = System.Drawing.ColorTranslator.FromHtml("#dbfff8");
                divnormal.Style.Add("background-color", "lightcyan");
                changeDropdown(levelcpoint);
            }
            else if (ddlTypeEQQ.SelectedValue == "7")
            {
                divEndToll.Visible = true;
                divreplace.Visible = false;
                divnormal.Visible = true;
                divnewserial.Visible = false;
                ddlTypeEQQ.BackColor = System.Drawing.ColorTranslator.FromHtml("#ede0ff");
                divnormal.Style.Add("background-color", "#ede0ff");
                ddlTollEQ.Enabled = true;
                changeDropdown(levelcpoint);
            }
            else
            {
                divEndToll.Visible = true;
                divreplace.Visible = false;
                divnormal.Visible = true;
                divnewserial.Visible = false;
                ddlTypeEQQ.BackColor = System.Drawing.ColorTranslator.FromHtml("#dbfff8");
                divnormal.Style.Add("background-color", "lightcyan");
                ddlTollEQ.Enabled = true;
            }
            */

            switch (ddlTypeEQQ.SelectedValue)
            {
                //case "1":
                    //
                //    break;
                case "2":
                    divEndToll.Visible = true;
                    divreplace.Visible = false;
                    divnormal.Visible = true;
                    divnewserial.Visible = false;
                    ddlTypeEQQ.BackColor = System.Drawing.ColorTranslator.FromHtml("#dbfff8");
                    divnormal.Style.Add("background-color", "lightcyan");
                    changeDropdown(levelcpoint);
                    break;
                //case "3":
                    //
                //    break;
                case "4":
                    divEndToll.Visible = true;
                    divreplace.Visible = false;
                    divnormal.Visible = true;
                    divnewserial.Visible = false;
                    ddlTypeEQQ.BackColor = System.Drawing.ColorTranslator.FromHtml("#ede0ff");
                    divnormal.Style.Add("background-color", "#ede0ff");
                    ddlTollEQ.Enabled = true;
                    changeDropdown(levelcpoint);
                    break;
                case "5":
                    divEndToll.Visible = true;
                    divnormal.Visible = false;
                    divnewserial.Visible = true;
                    ddlTypeEQQ.BackColor = System.Drawing.ColorTranslator.FromHtml("#fffec2");
                    ddlTollEQ.Enabled = true;
                    break;
                case "6":
                    divEndToll.Visible = true;
                    ddlTollEQ.SelectedValue = "9300";
                    divnormal.Visible = true;
                    divnewserial.Visible = false;
                    ddlTypeEQQ.BackColor = System.Drawing.ColorTranslator.FromHtml("#fffec2");
                    ddlTollEQ.Enabled = true;
                    break;
                case "7":
                    divEndToll.Visible = true;
                    divreplace.Visible = false;
                    divnormal.Visible = true;
                    divnewserial.Visible = false;
                    ddlTypeEQQ.BackColor = System.Drawing.ColorTranslator.FromHtml("#ede0ff");
                    divnormal.Style.Add("background-color", "#ede0ff");
                    ddlTollEQ.Enabled = true;
                    changeDropdown(levelcpoint);
                    break;
                default:
                    divEndToll.Visible = true;
                    divreplace.Visible = false;
                    divnormal.Visible = true;
                    divnewserial.Visible = false;
                    ddlTypeEQQ.BackColor = System.Drawing.ColorTranslator.FromHtml("#dbfff8");
                    divnormal.Style.Add("background-color", "lightcyan");
                    ddlTollEQ.Enabled = true;
                    break;
            }               
        }

        protected void lbtnreplace_Command(object sender, CommandEventArgs e)
        {
            replaceids = ddlreplace.SelectedValue.ToString();

            if (replaceids != "")
            {
                pkreplace.Text = replaceids; // แอดในโมดัลรอ
                string showmodal = "select * FROM tbl_equipment JOIN tbl_location ON tbl_location.locate_id = tbl_equipment.locate_id WHERE equipment_id = '" + replaceids + "'";
                MySqlDataReader sss = function.MySqlSelect(showmodal);
                if (sss.Read())
                {
                    txtreThai.Text = sss.GetString("equipment_nameth");
                    txtreEng.Text = sss.GetString("equipment_name");
                    lbreplaceeqide.Text = sss.GetString("equipment_no");
                    txtrebrand.Text = sss.GetString("equipment_brand");
                    txtreSeries.Text = sss.GetString("equipment_series");
                    txtReoldSerial.Text = sss.GetString("equipment_serial");
                    ddlReEoldLocate.Text = sss.GetString("locate_name");
                    txtRenewSerial.Text = txtNewSerial.Text;
                    sss.Close();
                    inputDDLSELECT();
                }
            }
            else
            {
                AlertPop("Error 4040 replace ติดต่อเจ้าหน้าที่", "error");
            }
        }

        string checkDupliForReplace(string newserialK)
        {
            int resultSS;
            int resultAA;
            string chkNewSerial = "SELECT COUNT(equipment_id) AS SSS FROM tbl_equipment WHERE equipment_serial = '" + newserialK + "' AND equipment_serial != '-' ";
            string chkNewInAction = "SELECT COUNT(trans_act_id) AS AAA FROM tbl_transfer_action WHERE new_serial='" + newserialK + "' ";
            MySqlDataReader ssss = function.MySqlSelect(chkNewSerial);

            if (ssss.Read())
            {
                resultSS = ssss.GetInt32("SSS");
                ssss.Close();
                MySqlDataReader aaaa = function.MySqlSelect(chkNewInAction);
                if (resultSS == 0)
                {
                    if (aaaa.Read())
                    {
                        resultAA = aaaa.GetInt32("AAA");
                        aaaa.Close();
                        if (resultAA == 0)
                        {
                            return "0";
                        }
                        else
                        {
                            return "1";
                        }
                    }
                    else
                    {
                        return "error";
                    }

                }
                else { return "1"; }
            }
            else
            {
                return "error";
            }
        }

        protected void gridreplace_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbnumreplace = (Label)(e.Row.FindControl("lbnumreplace"));
            if (lbnumreplace != null)
            {
                lbnumreplace.Text = (gridreplace.Rows.Count + 1).ToString() + ".";
            }
        }

        protected void gridreplace_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string eqideded = "";
            string StatReturnNormal = "";
            string sql = "DELETE FROM tbl_transfer_action WHERE trans_act_id = '" + gridreplace.DataKeys[e.RowIndex].Value + "'";
            //string script = "";
            string selectequipide = "select trans_equip_id FROM tbl_transfer_action WHERE trans_act_id = '" + gridreplace.DataKeys[e.RowIndex].Value + "'";
            MySqlDataReader idide = function.MySqlSelect(selectequipide);
            if (idide.Read())
            {
                eqideded = idide.GetString("trans_equip_id");
                idide.Close();
                StatReturnNormal = "UPDATE tbl_equipment SET trans_complete = '0' ,transfer_idnow = '' ,equipment_chkUpdateLocate = '0' WHERE equipment_id = '" + eqideded + "'";
                if (function.MySqlQuery(StatReturnNormal))
                {
                    if (function.MySqlQuery(sql))
                    {
                        Response.Redirect("/equip/EquipNewTrans");
                    }
                    else
                    {
                        AlertPop("Error Can't Delete Replace list! ติดต่อเจ้าหน้าที่", "error");
                    }
                }
                else
                {
                    AlertPop("ระบบขัดข้อง ลบข้อมูลล้มเหลว ติดต่อเจ้าหน้าที่", "error");
                }
                function.Close();
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('" + script + "')", true);
                GridAddTran.EditIndex = -1;
                AddTransDatabind("ADD");
            }
            function.MySqlQuery(sql);
            function.Close();
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('" + script + "')", true);
            gridreplace.EditIndex = -1;
            AddTransDatabind("replace");
        }

        protected void lbtnSubreplace_Command(object sender, CommandEventArgs e)
        {
            string InsertReplace = "Insert into tbl_transfer_action (tran_type,transfer_id,trans_equip_id,old_locate,old_toll,old_name" +
                ",old_nameth,old_no,old_serial,new_serial" +
                ",old_brand,old_series" +
                ",trans_act_note,new_locate,new_brand,new_series,num_success) values" +
                " ('" + ddlTypeEQQ.SelectedValue + "','" + Session["TransID"].ToString() + "','" + pkreplace.Text + "','" + ddlReEoldLocate.Text + "','" + ddlStartEQ.SelectedValue + "','" + txtreEng.Text + "'," +
                " '" + txtreThai.Text + "','" + lbreplaceeqide.Text + "','" + txtReoldSerial.Text + "','" + txtRenewSerial.Text + "'," +
                " '" + txtrebrand.Text + "','" + txtreSeries.Text + "'," +
                " '" + txtReNote.Text + "','" + ddlNewLocated.SelectedValue + "','" + txtNewbrandRe.Text + "','" + txtNewSeriesRe.Text + "','no')";
            string SqlEQupdate = "UPDATE tbl_equipment SET trans_complete='1' WHERE equipment_id = '" + pkreplace.Text + "' ";
            if (function.MySqlQuery(InsertReplace))
            {
                if (function.MySqlQuery(SqlEQupdate))
                {
                    Response.Redirect("/equip/EquipTranList");
                }
                else
                {
                    AlertPop("ERROR! Update-trans_complete ติดต่อเจ้าหน้าที่", "error");
                }
            }
            else
            {
                AlertPop("ระบบขัดข้อง ติดต่อเจ้าหน้าที่", "error");
            }
        }

        protected void chknewSEE_Command(object sender, CommandEventArgs e)
        {
            string getneSE = txtNewSerial.Text;
            if (getneSE != "")
            {
                string TorF = checkDupliForReplace(getneSE);
                if (TorF == "0")
                {
                    divreplace.Visible = true;
                    diviconchkAgain.Visible = true;
                    txtNewSerial.Enabled = false;
                    txtNewSerial.BackColor = System.Drawing.ColorTranslator.FromHtml("#bababa");

                    diviconchk.Visible = false;
                }
                else if (TorF == "1")
                {
                    AlertPop("เลขทะเบียนซ้ำ กรุณากรอกเลขทะเบียนใหม่!!", "error");
                }
                else
                {
                    AlertPop("ระบบเช็คเลขทะเบียนขัดข้อง ติดต่อเจ้าหน้าที่", "warning");
                }
            }
            else
            {
                AlertPop("กรุณาใส่เลขทะเบียนใหม่", "warning");
            }
        }

        protected void chkSEAgain_Click(object sender, EventArgs e)
        {
            diviconchkAgain.Visible = false;
            txtNewSerial.Text = "";
            ddlreplace.SelectedValue = "";
            divreplace.Visible = false;
            txtNewSerial.Enabled = true;
            diviconchk.Visible = true;
            txtNewSerial.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffcc");
        }

        protected void btnFistSubmit_Click(object sender, EventArgs e)
        {
            string completeStatf = "1";
            string SQLFirst = "";
            string dateSs = GetThaiMonth(txtDateSend.Text);
            string timenow = DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss");
            if (ddlTypeEQQ.SelectedValue == "4")
            {
                SQLFirst = "INSERT INTO tbl_transfer (toll_recieve,thai_month,position_sender,trans_note,trans_id,trans_stat,date_send,time_send,user_send,name_send,toll_send,company_repair,complete_stat,trans_budget)" +
                        "VALUES ('" + ddlTollEQ.SelectedValue + "','" + dateSs + "','" + ddlPosition.SelectedValue + "','" + txtactnote.Text + "','" + Session["TransID"].ToString() + "','" + ddlTypeEQQ.SelectedValue + "','" + txtDateSend.Text + "','" + timenow + "','" + Session["UserName"].ToString() + "'" +
                                ",'" + txtSender.Text + "','" + ddlStartEQ.SelectedValue + "','" + ddlTollEQ.SelectedValue + "','" + completeStatf + "','" + function.getBudgetYear(txtDateSend.Text) + "')";
            }
            else
            {
                SQLFirst = "INSERT INTO tbl_transfer (company_repair,thai_month,position_sender,trans_note,trans_id,trans_stat,date_send,time_send,user_send,name_send,toll_send,toll_recieve,complete_stat,trans_budget)" +
                        "VALUES ('556','" + dateSs + "','" + ddlPosition.SelectedValue + "','" + txtactnote.Text + "','" + Session["TransID"].ToString() + "','" + ddlTypeEQQ.SelectedValue + "','" + txtDateSend.Text + "','" + timenow + "','" + Session["UserName"].ToString() + "'" +
                                ",'" + txtSender.Text + "','" + ddlStartEQ.SelectedValue + "','" + ddlTollEQ.SelectedValue + "','" + completeStatf + "','" + function.getBudgetYear(txtDateSend.Text) + "')";
            }

            if (function.MySqlQuery(SQLFirst))
            {
                divtranSecond.Visible = true;
                divtranthird.Visible = true;
                Session["TransNew"] = "1";
                Response.Redirect("/equip/EquipNewTrans");
            }
            else
            {
                AlertPop("ระบบขัดข้อง ติดต่อเจ้าหน้าที่", "error");
            }
        }

        protected void btnSecondSubmit_Click(object sender, EventArgs e)
        {
            //if (Session["UserCpoint"].ToString() != "0" && ddlTollEQ.SelectedValue != "9200")
            if (Session["UserCpoint"].ToString() != "0" && ddlTollEQ.SelectedValue != "9200" && ddlTollEQ.SelectedValue != "9400")
            {
                AlertPop("Warning กรุณาเลือกปลายทางเป็นฝ่ายฯเท่านั้น!!", "warning");
            }
            else
            {
                string datenow = DateTime.Now.ToString("dd-MM-") + (int.Parse(DateTime.Now.ToString("yyyy")) + 543).ToString();
                string completeStatf = "";
                string typ = "";
                string SQLFirst = "";
                string timenow = DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss");
                string datesf = GetThaiMonth(txtDateSend.Text);
                if (ddlTypeEQQ.SelectedValue == "3" || ddlTypeEQQ.SelectedValue == "4")
                {
                    completeStatf = "2";
                }
                else if (ddlTypeEQQ.SelectedValue == "2")
                {
                    if (ddlTollEQ.SelectedValue == "9300" || ddlTollEQ.SelectedValue == "9400" || ddlTollEQ.SelectedValue == "9500")
                    {
                        /*completeStatf = "3";
                        SQLFirst = "update tbl_transfer SET trans_budget ='" + function.getBudgetYear(txtDateSend.Text) + "',trans_note = '" + txtactnote.Text + "' ,trans_id = '" + Session["TransID"].ToString() + "'," +
                        "thai_month='" + datesf + "',trans_stat='" + ddlTypeEQQ.SelectedValue + "',date_send='" + txtDateSend.Text + "',time_send='" + timenow + "'," +
                        "user_send = '" + Session["UserName"].ToString() + "',name_send ='" + txtSender.Text + "',toll_send ='" + ddlStartEQ.SelectedValue + "'," +
                        "toll_recieve ='" + ddlTollEQ.SelectedValue + "',complete_stat ='" + completeStatf + "',position_sender = '" + ddlPosition.SelectedValue + "' " +
                        " WHERE trans_id = '" + Session["TransID"].ToString() + "'";
                        completedd("2", SQLFirst);
                        typ = "com"; */
                        completeStatf = "2";
                    }
                    else
                    {
                        completeStatf = "2";
                    }
                }
                else if (ddlTypeEQQ.SelectedValue == "6")
                {
                    completeStatf = "3";
                    SQLFirst = "update tbl_transfer SET trans_budget ='" + function.getBudgetYear(txtDateSend.Text) + "',trans_note = '" + txtactnote.Text + "' ,trans_id = '" + Session["TransID"].ToString() + "'," +
                    "thai_month='" + datesf + "',trans_stat='" + ddlTypeEQQ.SelectedValue + "',date_send='" + txtDateSend.Text + "',time_send='" + timenow + "'," +
                    "user_send = '" + Session["UserName"].ToString() + "',name_send ='" + txtSender.Text + "',toll_send ='" + ddlStartEQ.SelectedValue + "'," +
                    "toll_recieve ='" + ddlTollEQ.SelectedValue + "',complete_stat ='" + completeStatf + "',position_sender = '" + ddlPosition.SelectedValue + "' " +
                    " WHERE trans_id = '" + Session["TransID"].ToString() + "'";
                    completedd("6", SQLFirst);
                    typ = "com";
                }
                else if (ddlTypeEQQ.SelectedValue == "1")
                {
                    if (ddlTollEQ.SelectedValue == "9300" || ddlTollEQ.SelectedValue == "9400" || ddlTollEQ.SelectedValue == "9500")
                    {
                        /*completeStatf = "3";
                        SQLFirst = "update tbl_transfer SET trans_budget ='" + function.getBudgetYear(txtDateSend.Text) + "',trans_note = '" + txtactnote.Text + "' ,trans_id = '" + Session["TransID"].ToString() + "'," +
                        "thai_month='" + datesf + "',trans_stat='" + ddlTypeEQQ.SelectedValue + "',date_send='" + txtDateSend.Text + "',time_send='" + timenow + "'," +
                        "user_send = '" + Session["UserName"].ToString() + "',name_send ='" + txtSender.Text + "',toll_send ='" + ddlStartEQ.SelectedValue + "'," +
                        "toll_recieve ='" + ddlTollEQ.SelectedValue + "',complete_stat ='" + completeStatf + "',position_sender = '" + ddlPosition.SelectedValue + "' " +
                        " WHERE trans_id = '" + Session["TransID"].ToString() + "'";
                        completedd("11", SQLFirst);
                        typ = "com"; */
                        completeStatf = "2";
                    }
                    else
                    {
                        completeStatf = "2";
                    }
                }
                else if (ddlTypeEQQ.SelectedValue == "7")
                {
                    completeStatf = "7";
                }

                SQLFirst = "update tbl_transfer SET trans_budget ='" + function.getBudgetYear(txtDateSend.Text) + "',trans_note = '" + txtactnote.Text + "' ,trans_id = '" + Session["TransID"].ToString() + "'," +
                    "thai_month='" + datesf + "',trans_stat='" + ddlTypeEQQ.SelectedValue + "',date_send='" + txtDateSend.Text + "',time_send='" + timenow + "'," +
                    "user_send = '" + Session["UserName"].ToString() + "',name_send ='" + txtSender.Text + "',toll_send ='" + ddlStartEQ.SelectedValue + "'," +
                    "toll_recieve ='" + ddlTollEQ.SelectedValue + "',complete_stat ='" + completeStatf + "',position_sender = '" + ddlPosition.SelectedValue + "' " +
                    " WHERE trans_id = '" + Session["TransID"].ToString() + "'";
                if (typ != "com")
                {
                    if (function.MySqlQuery(SQLFirst))
                    {
                        Session["LineTran"] = "\n" + ddlTypeEQQ.SelectedItem + " \n วันที่ : " + datenow + " \n หมายเลขอ้างอิง : " + Session["TransID"].ToString() + "\n ต้นทาง : " + ddlStartEQ.SelectedItem + "\n ปลายทาง : " + ddlTollEQ.SelectedItem + "" +
                            "\nผู้บันทึก : " + txtSender.Text;
                        //Session["alert"] = lbmdrefNo.Text;
                        btnPlanSheet.Visible = false;
                        btnSecondSubmit.Visible = false;
                        lbtnDelete.Visible = false;
                        lbmdrefNo.Text = Session["TransID"].ToString();

                        Print = "1";
                        //Response.Redirect("/equip/EquipTranList");                    
                        // SreviceLine.WebService_Server serviceLine = new SreviceLine.WebService_Server();
                        // serviceLine.MessageToServer("wDLRWPWgBvJRMEk69ebQVGumxOfiTKCgXoUwKeKPQyh", "ระบบได้รับข้อมูลแจ้งการ"+ ddlTypeEQQ.SelectedItem+ "ครุภัณฑ์  " +
                        //    " เมื่อวันที่ " + datenow + " \n หมายเลขอ้างอิง : " + Session["TransID"].ToString() + "\n ต้นทาง : " + ddlStartEQ.SelectedItem + "\n ปลายทาง : " + ddlTollEQ.SelectedItem + "  ", "", 1, 41);
                    }
                    else
                    {
                        AlertPop("การบันทึกล้มเหลว ติดต่อเจ้าหน้าที่", "error");
                    }
                }

            }


        }

        protected void btnEdit_Click(object sender, EventArgs e) // ดึงเรื่องกลับ
        {
            string sqlEdit = "UPDATE tbl_transfer SET complete_stat = '1' WHERE trans_id = '" + Session["TransID"].ToString() + "'";
            string checkStat = "select complete_stat FROM tbl_transfer WHERE trans_id = '" + Session["TransID"].ToString() + "'";
            string statnow = "";
            string timenowe = DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss");
            string loge = "Insert into tbl_logtransfer (trans_stat_id,logt_note,time_log,logt_transID,user_up) " +
                          "values ('1','','" + timenowe + "','" + Session["TransID"].ToString() + "','" + Session["UserName"].ToString() + "') ";
            MySqlDataReader edit = function.MySqlSelect(checkStat);

            if (edit.Read())
            {
                statnow = edit.GetString("complete_stat");
                edit.Close();

                for (int i = 0; i < 51; i++)
                {
                    string value = loopGetCommand();
                    if (statnow == "2")
                    {
                        if (function.MySqlQuery(sqlEdit))
                        {
                            if (value == "0")
                            {
                                if (function.MySqlQuery(loge))
                                {
                                    Session["alert"] = "ดึงเรื่องกลับ เรียบร้อยแล้ว";
                                    Response.Redirect("/equip/EquipTranList");
                                    break;
                                }
                                else
                                {
                                    Session["alert"] = "Error !!@#@#@!!";
                                    //Response.Redirect("/equip/EquipTranList");
                                    //break;
                                }
                            }
                            else if (value == "error")
                            {
                                AlertPop("การดึงกลับแก้ไขล้มเหลว กรุณาติดต่อปลายทาง", "error");
                                break;
                            }
                            else
                            {
                                AlertPop("Exception002 !!", "error");
                                break;
                            }
                        }
                    }
                    else if (statnow == "6")
                    {
                        if (function.MySqlQuery(sqlEdit))
                        {
                            if (value == "0")
                            {
                                if (function.MySqlQuery(loge))
                                {
                                    Session["alert"] = "ดึงเรื่องกลับ เรียบร้อยแล้ว";
                                    Response.Redirect("/equip/EquipTranList");
                                    break;
                                }
                                else
                                {
                                    Session["alert"] = "ดึงเรื่องกลับ เรียบร้อยแล้ว";
                                    Response.Redirect("/equip/EquipTranList");
                                    break;
                                }
                            }
                            else if (value == "error")
                            {
                                AlertPop("การดึงกลับแก้ไขล้มเหลว กรุณาติดต่อปลายทาง", "error");
                                break;
                            }
                            else
                            {
                                AlertPop("Exception003 !!", "error");
                                break;
                            }
                        }
                    }
                    else
                    {
                        AlertPop("Exception001 !!", "error");
                        break;
                    }
                }
            }
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            confirmGet = "1";
        }

        protected void btnBackto_Click(object sender, EventArgs e)
        {
            HitBack = "1";
        }

        protected void completedd(string tty, string sqlcv) //ส่งคืนกองกับส่งคืนฝ่ายบำรุงรักษาทรัพย์สิน
        {
            string datenow = DateTime.Now.ToString("dd-MM-") + (int.Parse(DateTime.Now.ToString("yyyy")) + 543).ToString();
            string timenow = DateTime.Now.ToString("HH.mm.ss");
            string timenowe = DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss");

            if (function.MySqlQuery(sqlcv))
            {
                for (int i = 0; i < 51; i++)
                {
                    string value = loopGetCommand();
                    if (value == "0")
                    {
                        if (tty == "11")
                        {
                            Session["LineTran"] = "\nโอนย้ายครุภัณฑ์ " +
                                                  "\nวันที่ : " + datenow + " " +
                                                  "\nหมายเลขอ้างอิง : " + Session["TransID"].ToString() + 
                                                  "\nต้นทาง : " + ddlStartEQ.SelectedItem + 
                                                  "\nปลายทาง : " + ddlTollEQ.SelectedItem + " ";
                        }
                        else
                        {
                            Session["LineTran"] = "\nส่งคืนครุภัณฑ์ " +
                                                  "\nวันที่ : " + datenow + 
                                                  "\nหมายเลขอ้างอิง : " + Session["TransID"].ToString() + 
                                                  "\nต้นทาง : " + ddlStartEQ.SelectedItem + 
                                                  "\nปลายทาง : " + ddlTollEQ.SelectedItem + " ";
                        }
                        Response.Redirect("/equip/EquipTranList");
                        break;
                    }
                    else if (value == "error")
                    {
                        AlertPop("Exception !! 004", "error");
                        break;
                    }
                    else
                    {
                        AlertPop("Exception !! 005", "error");
                        break;
                    }
                }
            }
            else
            {
                AlertPop("Exception !! 006", "error");
            }
        }

        protected void lbtnGet_Command(object sender, CommandEventArgs e)
        {
            string datenow = DateTime.Now.ToString("dd-MM-") + (int.Parse(DateTime.Now.ToString("yyyy")) + 543).ToString();
            string timenow = DateTime.Now.ToString("HH.mm.ss");
            string timenowe = DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss");
            string loge = "Insert into tbl_logtransfer (trans_stat_id,logt_note,time_log,logt_transID,user_up) " +
                          "values ('2','','" + timenowe + "','" + Session["TransID"].ToString() + "','" + Session["UserName"].ToString() + "') ";
            string sqlGet = "UPDATE tbl_transfer SET date_recieve='" + datenow + "'" +
                            ",time_recieve = '" + timenow + "'" +
                            ",user_recieve = '" + Session["UserName"].ToString() + "'" +
                            ",name_recieve = '" + Session["UserName"].ToString() + "'" +
                            ",complete_stat = '3' ,position_getder = '" + ddlposGet.SelectedItem + "'" +
                            " WHERE trans_id = '" + Session["TransID"].ToString() + "'";

            for (int i = 0; i < 51; i++)
            {
                string value = loopGetCommand();
                if (value == "0")
                {
                    if (function.MySqlQuery(sqlGet))
                    {
                        if (function.MySqlQuery(loge))
                        {
                            Session["LineTran"] = "\nตรวจรับครุภัณฑ์  " +
                            "\nวันที่ : " + datenow + " \n หมายเลขอ้างอิง : " + Session["TransID"].ToString() + "\n ต้นทาง : " + DropDownList1.SelectedItem + "\n ปลายทาง : " + ddlTollEQ.SelectedItem + "  ";
                            Session["alert"] = "อนุมัติรายการ เรียบร้อยแล้ว";
                            Response.Redirect("/equip/EquipTranGetList");
                            break;                             
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
            string EQIDloop = ""; 
            string newse = ""; 
            string newserie = ""; 
            string newbrand = "";
            string loopGetAct = "SELECT * FROM tbl_transfer_action " +
                                " WHERE transfer_id = '" + Session["TransID"].ToString() + "' " +
                                " AND num_success = 'no' " +
                                " ORDER BY trans_act_id DESC LIMIT 1";

            MySqlDataReader loo = function.MySqlSelect(loopGetAct);
            if (loo.Read())
            {
                EQIDloop = loo.GetString("trans_equip_id");

                if (EQIDloop != "") //ถ้ายังมีเหลือ
                {
                    string updateAct = "";
                    string updateequip = "";
                    if (ddlTypeEQQ.SelectedValue != "5" && ddlTypeEQQ.SelectedValue != "4" && ddlTypeEQQ.SelectedValue != "7")//ประเภท1,2,3
                    {
                        updateAct = "UPDATE tbl_transfer_action SET tran_type='" + ddlTypeEQQ.SelectedValue + "',new_toll = '" + ddlTollEQ.SelectedValue + "',num_success='yes' " +
                                    " WHERE trans_equip_id ='" + EQIDloop + "' AND transfer_id = '" + Session["TransID"].ToString() + "' ";
                        updateequip = "UPDATE tbl_equipment SET trans_complete = '0',toll_id='" + ddlTollEQ.SelectedValue + "',equipment_chkUpdateLocate = '1'" +
                                      " WHERE equipment_id ='" + EQIDloop + "' ";
                    }
                    else if (ddlTypeEQQ.SelectedValue == "4")
                    {
                        updateAct = "UPDATE tbl_transfer_action SET num_success='repair',tran_type='" + ddlTypeEQQ.SelectedValue + "' " +
                                    " WHERE trans_equip_id ='" + EQIDloop + "' AND transfer_id = '" + Session["TransID"].ToString() + "' ";
                    }
                    else if (ddlTypeEQQ.SelectedValue == "5")
                    {
                        newse = loo.GetString("new_serial");
                        newserie = loo.GetString("new_series");
                        newbrand = loo.GetString("new_brand");

                        updateAct = "UPDATE tbl_transfer_action SET tran_type='" + ddlTypeEQQ + "',new_toll = '" + ddlTollEQ.SelectedValue + "',num_success='yes' " +
                                    " WHERE trans_equip_id ='" + EQIDloop + "' AND transfer_id = '" + Session["TransID"].ToString() + "' ";
                        updateequip = "UPDATE tbl_equipment SET trans_complete = '0',toll_id='" + ddlTollEQ.SelectedValue + "' " +
                                      ",equipment_serial='" + newse + "',equipment_series='" + newserie + "',equipment_brand='" + newbrand + "',locate_id='555' " +
                                      " WHERE equipment_id ='" + EQIDloop + "' ";
                    }
                    else if (ddlTypeEQQ.SelectedValue == "6")
                    {
                        updateAct = "UPDATE tbl_transfer_action SET tran_type='" + ddlTypeEQQ.SelectedValue + "',new_toll = '" + ddlTollEQ.SelectedValue + "',num_success='yes' " +
                                    " WHERE trans_equip_id ='" + EQIDloop + "' AND transfer_id = '" + Session["TransID"].ToString() + "' ";
                        updateequip = "UPDATE tbl_equipment SET trans_complete = '0',toll_id='" + ddlTollEQ.SelectedValue + "' " +
                                      " WHERE equipment_id ='" + EQIDloop + "' ";
                    }
                    else if (ddlTypeEQQ.SelectedValue == "7")
                    {
                        updateAct = "UPDATE tbl_transfer_action SET tran_type='" + ddlTypeEQQ.SelectedValue + "',new_toll = '" + ddlTollEQ.SelectedValue + "',num_success='yes' " +
                                    " WHERE trans_equip_id ='" + EQIDloop + "' AND transfer_id = '" + Session["TransID"].ToString() + "' ";
                        updateequip = "UPDATE tbl_equipment SET trans_complete = '0' WHERE equipment_id ='" + EQIDloop + "' ";
                    }

                    if (function.MySqlQuery(updateAct))
                    {
                        if (ddlTypeEQQ.SelectedValue == "4")
                        {
                            loo.Close();
                            return "1";
                        }
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

        protected void lbtnBack_Command(object sender, CommandEventArgs e) //ตีกลับ
        {
            string datenow = DateTime.Now.ToString("dd-MM-") + (int.Parse(DateTime.Now.ToString("yyyy")) + 543).ToString();
            string timenow = DateTime.Now.ToString("HH.mm.ss");
            string timenowe = DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss");
            string sqlhitback = "Update tbl_transfer SET complete_stat='4'  ,date_recieve='" + datenow + "',time_recieve='" + timenow + "'" +
                                " ,user_recieve='" + Session["UserName"].ToString() + "',name_recieve='" + Session["UserName"].ToString() + "' " +
                                " WHERE trans_id = '" + Session["TransID"].ToString() + "' ";
            string loge = "Insert into tbl_logtransfer  (trans_stat_id,logt_note,time_log,logt_transID,user_up) " +
                          "values ('4','" + txtEditNote.Text + "','" + timenowe + "','" + Session["TransID"].ToString() + "','" + Session["UserName"].ToString() + "') ";

            if (function.MySqlQuery(sqlhitback))
            {
                for (int i = 0; i < 51; i++)
                {
                    string value = loopBackCommand();
                    if (value == "0")
                    {
                        if (function.MySqlQuery(loge))
                        {
                            Session["alert"] = "ไม่อนุมัติรายการ ส่งตีกลับไปยังต้นทางเรียบร้อยแล้ว";
                            Response.Redirect("/equip/EquipTranGetList");
                            break;
                        }
                        else
                        {
                            Session["alert"] = "ไม่อนุมัติรายการ ส่งตีกลับไปยังต้นทางเรียบร้อยแล้ว";
                            Response.Redirect("/equip/EquipTranGetList");
                            break;
                        }
                    }
                    else if (value == "error")
                    {
                        break;
                    }
                }
            }
            else
            {
                AlertPop("ตีกลับล้มเหลว ติดต่อเจ้าหน้าที่", "error");
            }
        }

        protected string loopBackCommand()
        {
            string EQIDloop = ""; 
            string newse = ""; 
            string newserie = ""; 
            string newbrand = "";
            string loopGetAct = "SELECT  *  FROM  tbl_transfer_action " +
                                " WHERE transfer_id = '" + Session["TransID"].ToString() + "'  AND num_success = 'no' ORDER BY  trans_act_id DESC  LIMIT 1";

            MySqlDataReader loo = function.MySqlSelect(loopGetAct);
            if (loo.Read())
            {
                EQIDloop = loo.GetString("trans_equip_id");

                if (EQIDloop != "") //ถ้ายังมีเหลือ
                {
                    string updateAct = "";
                    string updateequip = "";
                    if (ddlTypeEQQ.SelectedValue != "5" && ddlTypeEQQ.SelectedValue != "4" && ddlTypeEQQ.SelectedValue != "7")//ประเภท1,2,3
                    {
                        updateAct = "UPDATE tbl_transfer_action SET tran_type='" + ddlTypeEQQ.SelectedValue + "',new_toll = '" + ddlTollEQ.SelectedValue + "',num_success='yes' " +
                                    " WHERE trans_equip_id ='" + EQIDloop + "' AND transfer_id = '" + Session["TransID"].ToString() + "' ";
                        updateequip = "UPDATE tbl_equipment SET trans_complete = '0' " +
                                      " WHERE equipment_id ='" + EQIDloop + "' ";
                    }
                    else if (ddlTypeEQQ.SelectedValue == "4")
                    {
                        updateAct = "UPDATE tbl_transfer_action SET num_success='repair',tran_type='" + ddlTypeEQQ.SelectedValue + "' " +
                                    " WHERE trans_equip_id ='" + EQIDloop + "' AND transfer_id = '" + Session["TransID"].ToString() + "' ";
                    }
                    else if (ddlTypeEQQ.SelectedValue == "5")
                    {
                        newse = loo.GetString("new_serial");
                        newserie = loo.GetString("new_series");
                        newbrand = loo.GetString("new_brand");

                        updateAct = "UPDATE tbl_transfer_action SET tran_type='" + ddlTypeEQQ + "',new_toll = '" + ddlTollEQ.SelectedValue + "',num_success='yes' " +
                                    " WHERE trans_equip_id ='" + EQIDloop + "' AND transfer_id = '" + Session["TransID"].ToString() + "' ";
                        updateequip = "UPDATE tbl_equipment SET trans_complete = '0' " +
                                      ",equipment_serial='" + newse + "',equipment_series='" + newserie + "',equipment_brand='" + newbrand + "',locate_id='555' " +
                                      " WHERE equipment_id ='" + EQIDloop + "' ";
                    }
                    else if (ddlTypeEQQ.SelectedValue == "6")
                    {
                        updateAct = "UPDATE tbl_transfer_action SET tran_type='" + ddlTypeEQQ.SelectedValue + "',new_toll = '" + ddlTollEQ.SelectedValue + "',num_success='yes' " +
                                    " WHERE trans_equip_id ='" + EQIDloop + "' AND transfer_id = '" + Session["TransID"].ToString() + "' ";
                        updateequip = "UPDATE tbl_equipment SET trans_complete = '0' " +
                                      " WHERE equipment_id ='" + EQIDloop + "' ";
                    }
                    else if (ddlTypeEQQ.SelectedValue == "7")
                    {
                        updateAct = "UPDATE tbl_transfer_action SET tran_type='" + ddlTypeEQQ.SelectedValue + "',new_toll = '" + ddlTollEQ.SelectedValue + "',num_success='yes' " +
                                    " WHERE trans_equip_id ='" + EQIDloop + "' AND transfer_id = '" + Session["TransID"].ToString() + "' ";
                        updateequip = "UPDATE tbl_equipment SET trans_complete = '0' WHERE equipment_id ='" + EQIDloop + "' ";
                    }
                    else
                    {
                        AlertPop("Error Get000 ติดต่อเจ้าหน้าที่", "warning");
                    }

                    if (function.MySqlQuery(updateAct))
                    {
                        if (ddlTypeEQQ.SelectedValue == "4")
                        {
                            loo.Close();
                            return "1";
                        }
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

        protected void lbtnDelete_Command(object sender, CommandEventArgs e)
        {
            string deleteTrans = "DELETE from tbl_transfer  WHERE trans_id = '" + Session["TransID"].ToString() + "' ";
            string timenowe = DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss");
            string loge = "Insert into tbl_logtransfer (user_up,trans_stat_id,logt_note,time_log,logt_transID) " +
                          "values ('" + Session["UserName"].ToString() + "','5','','" + timenowe + "','" + Session["TransID"].ToString() + "') ";

            for (int i = 0; i < 51; i++)
            {
                string valueDelete = DeleteCommand();
                if (valueDelete == "0")
                {
                    if (function.MySqlQuery(deleteTrans))
                    {
                        if (function.MySqlQuery(loge))
                        {
                            //Response.Redirect("/equip/EquipTranList");
                            //AlertPop("ลบรายการสำเร็จ", "error");
                            Response.Write("<script language='javascript'>window.alert('ลบรายการสำเร็จ');window.location='EquipTranList.aspx';</script>");
                            break;
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('ลบรายการสำเร็จ');window.location='EquipTranList.aspx';</script>");
                            break;
                        }
                    }
                    else
                    {
                        AlertPop("Error Can't Update TranStat To 5 ติดต่อเจ้าหน้าที่", "warning");
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
                                     " WHERE transfer_id = '" + Session["TransID"].ToString() + "' ORDER BY trans_act_id DESC LIMIT 1";

            MySqlDataReader lop = function.MySqlSelect(loopDeleteActEQ);
            if (lop.Read())
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
            else
            {
                lop.Close();
                return "0";
            }
        }

        protected void btnPlanSheet_Click(object sender, EventArgs e)
        {
            if (Session["UserCpoint"].ToString() != "0" && ddlTollEQ.SelectedValue != "9200")
            {
                AlertPop("Warning กรุณาเลือกปลายทางเป็นฝ่ายฯเท่านั้น!!", "warning");
            }
            else
            {
                string dgg = GetThaiMonth(txtDateSend.Text);
                string upTrans = "UPDATE tbl_transfer SET thai_month='" + dgg + "' ,date_send='" + txtDateSend.Text + "' ,trans_stat ='" + ddlTypeEQQ.SelectedValue + "' ," +
                                 "toll_send='" + ddlStartEQ.SelectedValue + "', toll_recieve='" + ddlTollEQ.SelectedValue + "' ," +
                                 "trans_note='" + txtactnote.Text + "',position_sender='" + ddlPosition.SelectedValue + "' WHERE trans_id = '" + Session["TransID"].ToString() + "' ";

                if (function.MySqlQuery(upTrans))
                {
                    AlertPop("บันทึกสำเร็จ", "success");
                }
                else
                {
                    AlertPop("ERROR PlanSheet!! บันทึกข้อมูลล้มเหลว", "error");
                }
            }
        }

        protected void btnSendRepair_Click(object sender, EventArgs e)
        {
            string datenow = DateTime.Now.ToString("dd-MM-") + (int.Parse(DateTime.Now.ToString("yyyy")) + 543).ToString();
            string timenow = DateTime.Now.ToString("HH.mm.ss");
            string timenowe = DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss");
            string loge = "Insert into tbl_logtransfer (trans_stat_id,logt_note,time_log,logt_transID,user_up) " +
                          "values ('6','','" + timenowe + "','" + Session["TransID"].ToString() + "','" + Session["UserName"].ToString() + "') ";
            string datesf = GetThaiMonth(txtDateSend.Text);
            string sqlSendRepair = "UPDATE tbl_transfer SET complete_stat='6',toll_recieve='" + ddlTollEQ.SelectedValue + "'" +
                                   ",date_send='" + txtDateSend.Text + "',time_send='" + timenowe + "'," +
                                   "user_send = '" + Session["UserName"].ToString() + "',name_send ='" + txtSender.Text + "'," +
                                   "trans_budget ='" + function.getBudgetYear(txtDateSend.Text) + "',trans_note = '" + txtactnote.Text + "', " +
                                   "thai_month='" + datesf + "'   WHERE trans_id='" + Session["TransID"].ToString() + "'";

            for (int i = 0; i < 51; i++)
            {
                string value = loopGetCommand();
                if (value == "0")
                {
                    if (function.MySqlQuery(sqlSendRepair))
                    {
                        if (function.MySqlQuery(loge))
                        {
                            Session["LineTran"] = "\nส่งซ่อมครุภัณฑ์  " +
                                                  "\nวันที่ : " + datenow + " " +
                                                  "\nหมายเลขอ้างอิง : " + Session["TransID"].ToString() + 
                                                  "\nต้นทาง : " + ddlStartEQ.SelectedItem + 
                                                  "\nปลายทาง : " + ddlTollEQ.SelectedItem + " ";
                            Response.Redirect("/equip/EquipTranList");
                            break;
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

        public void GridRepair_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            RadioButton rbtWaitt = (RadioButton)e.Row.FindControl("rdtWait");
            RadioButton rbtNorepairee = (RadioButton)e.Row.FindControl("rdtNoRepair");
            RadioButton rbtRepairee = (RadioButton)e.Row.FindControl("rdtRepaired");
            Label repaireee = (Label)e.Row.FindControl("RepairStat");
            Label lbnumrepair = (Label)(e.Row.FindControl("lbnumrepair"));
            if (lbnumrepair != null)
            {
                lbnumrepair.Text = (GridRepair.Rows.Count + 1).ToString() + ".";
            }
            if (repaireee != null)
            {
                if (repaireee.Text == "0") { rbtWaitt.Checked = true; wait++; }
                else if (repaireee.Text == "1") { rbtNorepairee.Checked = true; norepair++; }
                else if (repaireee.Text == "2") { rbtRepairee.Checked = true; repairedd++; }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2eded");
                e.Row.Cells[7].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffd6d6");
                e.Row.Cells[8].BackColor = System.Drawing.ColorTranslator.FromHtml("#b7ebb7");
                e.Row.Cells[9].BackColor = System.Drawing.ColorTranslator.FromHtml("white");
                e.Row.Cells[9].ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
                e.Row.Cells[10].BackColor = System.Drawing.ColorTranslator.FromHtml("white");
                e.Row.Cells[10].ForeColor = System.Drawing.ColorTranslator.FromHtml("#fff4e6");
                e.Row.Cells[11].BackColor = System.Drawing.ColorTranslator.FromHtml("white");
                e.Row.Cells[11].ForeColor = System.Drawing.ColorTranslator.FromHtml("#fff4e6");
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#5e5c5c");
                e.Row.Cells[7].BackColor = System.Drawing.ColorTranslator.FromHtml("#8a1212");
                e.Row.Cells[8].BackColor = System.Drawing.ColorTranslator.FromHtml("#0b5c0b");
                e.Row.Cells[9].BackColor = System.Drawing.ColorTranslator.FromHtml("white");
                e.Row.Cells[10].BackColor = System.Drawing.ColorTranslator.FromHtml("white");
                e.Row.Cells[11].BackColor = System.Drawing.ColorTranslator.FromHtml("white");
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#5e5c5c");
                e.Row.Cells[7].BackColor = System.Drawing.ColorTranslator.FromHtml("#8a1212");
                e.Row.Cells[8].BackColor = System.Drawing.ColorTranslator.FromHtml("#0b5c0b");
                e.Row.Cells[9].BackColor = System.Drawing.ColorTranslator.FromHtml("white");
                e.Row.Cells[9].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffe8c9");
                e.Row.Cells[10].BackColor = System.Drawing.ColorTranslator.FromHtml("white");
                e.Row.Cells[10].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffe8c9");
                e.Row.Cells[11].BackColor = System.Drawing.ColorTranslator.FromHtml("white");
                e.Row.Cells[11].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffe8c9");
            }
            txtstatcount.Text = "[ รอซ่อม = " + wait + " / ซ่อมไม่ได้ = " + norepair + " / ซ่อมเรียบร้อย = " + repairedd + " ]";
            lbchkWait.Text = wait.ToString();
        }

        protected string CountRadio()
        {
            int nopm = 0;
            int pm = 0;
            int broke = 0;
            string allreturn = "";
            GridViewRow row = null;

            for (int i = 0; i < GridRepair.Rows.Count; i++)
            {
                row = GridRepair.Rows[i];
                bool NoTrue = ((RadioButton)row.FindControl("rdtWait")).Checked;
                bool YesTrue = ((RadioButton)row.FindControl("rdtRepaired")).Checked;
                bool BreakTrue = ((RadioButton)row.FindControl("rdtNoRepair")).Checked;
                if (NoTrue) { nopm++; }
                if (YesTrue) { pm++; }
                if (BreakTrue) { broke++; }
            }

            allreturn = nopm.ToString() + "-" + pm.ToString() + "-" + broke.ToString();
            return allreturn;
        }

        protected void rdtWait_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdio = (RadioButton)sender;
            GridViewRow rowrd = (GridViewRow)rdio.NamingContainer;
            int rIndex = rowrd.RowIndex;
            Label lb;
            rdio = (RadioButton)GridRepair.Rows[rIndex].FindControl("rdtWait");
            lb = (Label)GridRepair.Rows[rIndex].FindControl("RepairStat");

            if (rdio.Checked)
            {
                lb.Text = "0";
            }

            string[] countCheck;
            countCheck = CountRadio().Split('-');
            txtstatcount.Text = "[ รอซ่อม = " + countCheck[0] + " / ซ่อมไม่ได้ = " + countCheck[2] + " / ซ่อมเรียบร้อย = " + countCheck[1] + " ]";
            lbchkWait.Text = countCheck[0].ToString();
        }

        protected void rdtNoRepair_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdio = (RadioButton)sender;
            GridViewRow rowrd = (GridViewRow)rdio.NamingContainer;
            int rIndex = rowrd.RowIndex;
            Label lb;
            rdio = (RadioButton)GridRepair.Rows[rIndex].FindControl("rdtNoRepair");
            lb = (Label)GridRepair.Rows[rIndex].FindControl("RepairStat");

            if (rdio.Checked)
            {
                lb.Text = "1";
            }

            string[] countCheck;
            countCheck = CountRadio().Split('-');
            txtstatcount.Text = "[ รอซ่อม = " + countCheck[0] + " / ซ่อมไม่ได้ = " + countCheck[2] + " / ซ่อมเรียบร้อย = " + countCheck[1] + " ]";
            lbchkWait.Text = countCheck[0].ToString();
        }

        protected void rdtRepaired_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdio = (RadioButton)sender;
            GridViewRow rowrd = (GridViewRow)rdio.NamingContainer;
            int rIndex = rowrd.RowIndex;
            Label lb;
            rdio = (RadioButton)GridRepair.Rows[rIndex].FindControl("rdtRepaired");
            lb = (Label)GridRepair.Rows[rIndex].FindControl("RepairStat");

            if (rdio.Checked)
            {
                lb.Text = "2";
            }

            string[] countCheck;
            countCheck = CountRadio().Split('-');
            txtstatcount.Text = "[ รอซ่อม = " + countCheck[0] + " / ซ่อมไม่ได้ = " + countCheck[2] + " / ซ่อมเรียบร้อย = " + countCheck[1] + " ]";
            lbchkWait.Text = countCheck[0].ToString();
        }

        protected string loopUpdateRepair(string actionNum, string EQID)
        {
            string repairStat = ""; 
            string EStatus = ""; 
            string tranCom = ""; 
            string repairAct = "";            

            if (actionNum == "2")
            {
                repairStat = "repaired"; EStatus = "1"; tranCom = "0"; repairAct = "2";

            }
            else if (actionNum == "1")
            {
                repairStat = "NotRepair"; EStatus = "2"; tranCom = "0"; repairAct = "1";
            }
            else
            {
                repairStat = "repair"; EStatus = "2"; tranCom = "1"; repairAct = "0";
            }

            string tranAct = "UPDATE tbl_transfer_action SET repair_action='" + repairAct + "' ,num_success = '" + repairStat + "' WHERE trans_equip_id='" + EQID + "' " +
                             " AND transfer_id = '" + Session["TransID"].ToString() + "'";

            string equipmentt = "UPDATE tbl_equipment SET Estatus_id = '" + EStatus + "'" +
                                ",trans_complete = '" + tranCom + "' WHERE equipment_id = '" + EQID + "' ";

            if (function.MySqlQuery(tranAct))
            {
                if (function.MySqlQuery(equipmentt))
                {
                    return "success";
                }
                else
                {
                    return "error02";
                }
            }
            else
            {
                return "error01";
            }
        }

        protected void btnRepaired_Click(object sender, EventArgs e)
        {
            string chkerrorloop = "";
            for (int i = 0; i < GridRepair.Rows.Count; i++)
            {
                string equipIDD = ((Label)GridRepair.Rows[i].FindControl("EQIDf")).Text;
                string actionChk = ((Label)GridRepair.Rows[i].FindControl("RepairStat")).Text;
                string result = loopUpdateRepair(actionChk, equipIDD);

                if (result == "error01")
                {
                    AlertPop("Error01 ติดต่อเจ้าหน้าที่", "error");
                    chkerrorloop = "error";
                    break;
                }
                else if (result == "error02")
                {
                    AlertPop("Error02 ติดต่อเจ้าหน้าที่", "error");
                    chkerrorloop = "error";
                    break;
                }
            }

            string datenow = DateTime.Now.ToString("dd-MM-") + (int.Parse(DateTime.Now.ToString("yyyy")) + 543).ToString();
            string timenow = DateTime.Now.ToString("HH.mm.ss");
            string finishTranFers = "";
            if (chkerrorloop != "error")
            {
                if (lbchkWait.Text == "0")
                {
                    finishTranFers = "UPDATE tbl_transfer SET date_recieve='" + datenow + "',time_recieve='" + timenow + "'" +
                    ",user_recieve='" + Session["UserName"].ToString() + "',name_recieve='" + Session["UserName"].ToString() + "'" +
                    ",complete_stat ='3' WHERE trans_id='" + Session["TransID"].ToString() + "'";

                    if (function.MySqlQuery(finishTranFers))
                    {
                        Session["LineTran"] = "ระบบได้รับข้อมูล ตรวจรับส่งซ่อม  " +
                        "\n เมื่อวันที่ " + datenow + " \n หมายเลขอ้างอิง : " + Session["TransID"].ToString() + " \n จาก : " + ddlTollEQ.SelectedItem + "  ";
                        Response.Redirect("/equip/EquipTranList");
                    }
                    else
                    {
                        AlertPop("Error FinalGetRepair", "error");
                    }
                }
                else
                {
                    Response.Redirect("/equip/EquipTranList");
                }
            }
        }

        protected void ddlStartEQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputDDLSELECT();
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            string datenow = DateTime.Now.ToString("dd-MM-") + (int.Parse(DateTime.Now.ToString("yyyy")) + 543).ToString();
            string timenow = DateTime.Now.ToString("HH.mm.ss");
            string timenowe = DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss");
            string loge = "Insert into tbl_logtransfer   (trans_stat_id,logt_note,time_log,logt_transID,user_up) " +
                          "values ('7','','" + timenowe + "','" + Session["TransID"].ToString() + "','" + Session["UserName"].ToString() + "') ";
            string sqlGet = "UPDATE tbl_transfer SET  date_recieve='" + datenow + "',time_recieve='" + timenow + "'" +
                            ",user_recieve='" + Session["UserName"].ToString() + "',name_recieve='" + Session["UserName"].ToString() + "',complete_stat='3',position_getder='" + ddlposGet.SelectedItem + "'" +
                            " WHERE trans_id='" + Session["TransID"].ToString() + "'";

            for (int i = 0; i < 51; i++)
            {
                string value = loopGetCommand();

                if (value == "0")
                {
                    if (function.MySqlQuery(sqlGet))
                    {
                        if (function.MySqlQuery(loge))
                        {
                            Session["LineTran"] = "\nรับครุภัณฑ์(ยืม)  " +
                                                  "\nวันที่ " + datenow + " " +
                                                  "\nหมายเลขอ้างอิง : " + Session["TransID"].ToString() + 
                                                  "\nต้นทาง : " + DropDownList1.SelectedItem + 
                                                  "\nปลายทาง : " + ddlTollEQ.SelectedItem + "  ";
                            Response.Redirect("/equip/EquipTranList");
                            break;
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

        protected void lbtnPrint_Command(object sender, CommandEventArgs e)
        {
            Session["TranRepId"] = lbmdrefNo.Text;
            Session["CopyTran"] = "";
            Session["PrintdocuMent"] = "Yes";

            if (txtSenderName.Text == "")
            {
                Session["SenderTran"] = ".";
            }
            else
            {
                Session["SenderTran"] = txtSenderName.Text;
            }

            if (txtPosSender.Text == "")
            {
                Session["PosSender"] = "..";
            }
            else
            {
                Session["PosSender"] = txtPosSender.Text;
            }

            //ReportDocument rpt = new ReportDocument();

            if (Session["TranRepId"].ToString() != "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('/Report/report','_newtab') ;window.location='/equip/EquipTranList';", true);
            }
            else
            {
                AlertPop("Error Report05 ติดต่อเจ้าหน้าที่", "error");
            }
        }

        protected void lbtnCancel_Command(object sender, CommandEventArgs e)
        {
            Session["PrintdocuMent"] = "Yes";
            Redirect();
        }

        public void Redirect()
        {
            Response.Redirect("/equip/EquipTranList");
        }

        public void Cleartxt()
        {
            btnAddEQTran.Text = "";
        }
    }
}