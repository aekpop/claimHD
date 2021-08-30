using ClaimProject.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using System.Configuration;
using System.Drawing;

namespace ClaimProject.ReportView
{
    public partial class Default : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        public string claim_id = "";
        public int Nowmonth = int.Parse(DateTime.Now.ToString("MM"));
        public int Nowyear = int.Parse((DateTime.Now.Year + 543).ToString());
        public int ChkAmountClaim = 0 ;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!this.IsPostBack)
            {
                //chkday.Text = GetThaiMonth(DateTime.Now.ToString("dd-MM-yyyy"));
                //GridViewAllbyBudget
                rbtBudget.Checked = true;
                rbtBudget_CheckedChanged(null, null);
                string getCpointName = "SELECT * FROM tbl_cpoint WHERE cpoint_login='1'  Order by cpoint_id ASC";
                function.getListItem(txtStation, getCpointName, "cpoint_name", "cpoint_id");
                //เพิ่มไอเทมให้เลือกในดรอบดาว  (ตำแหน่ง , สร้างใหม่(ชื่ออะไร,values))
                txtStation.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                function.getListItem(txtBudgetYear, "SELECT claim_budget_year FROM tbl_claim  GROUP BY claim_budget_year ORDER BY claim_budget_year DESC", "claim_budget_year", "claim_budget_year");
                
            }
            ShowAnnex();
        }

        public void bindAllClaim(string sss, string yyy ,string begin ,string end)
        {

            MySqlDataAdapter AllClaim = function.MySqlSelectDataSet(sss);
            DataTable dt = new DataTable();
            AllClaim.Fill(dt);
            GridViewAllbyBudget.DataSource = dt;
            GridViewAllbyBudget.DataBind();
            ChkAmountClaim = dt.Rows.Count;
            if(begin == "" && end == "")
            {
                GridViewAllbyBudget.Visible = true;
                lbTable1.Text = "ตารางแสดงจำนวนอุบัติเหตุทั้งหมด ปีงบประมาณ " + yyy;
                lbChart1.Text = "กราฟแสดงข้อมูลจำนวนอุบัติเหตุ ปีงบประมาณ " + yyy;
                devicelb.Text = "ตารางแสดงรายการอุปกรณ์ที่เสียหาย ปีงบประมาณ " + yyy;
                devicelb.Visible = true;
                lbTable1.Visible = true;
            }
            else
            {
                string since = function.ConvertDateShortThai(begin);
                string last = function.ConvertDateShortThai(end);
                GridViewAllbyBudget.Visible = true;
                lbTable1.Text = "ตารางแสดงข้อมูลอุบัติเหตุทั้งหมด ( " +since+ " - "+last+" )";
                lbChart1.Text = "กราฟแสดงข้อมูลจำนวนอุบัติเหตุ ( " + since + " - " + last + " )";
                devicelb.Text = "ตารางแสดงรายการอุปกรณ์ที่เสียหาย ( " + since + " - " + last + " )";
                devicelb.Visible = true;
                lbTable1.Visible = true;
            }

        }
        public void bindDevice(string sss)
        {
            MySqlDataAdapter AllClaim = function.MySqlSelectDataSet(sss);
            DataTable dt = new DataTable();

            AllClaim.Fill(dt);
            DeviceGridview.DataSource = dt;
            DeviceGridview.DataBind();
        }

        public void bindDetail(string ssss, string yyyy, int numx,string begin,string end)
        {
            MySqlDataAdapter AllClaim = function.MySqlSelectDataSet(ssss);
            DataTable dt = new DataTable();
            //ตารางเรียกทุกด่านฯ
            if(numx == 1 && begin == "" && end == "")
            {
                AllClaim.Fill(dt);
                GridViewthing.DataSource = dt;
                GridViewthing.DataBind();
                GridViewthing.Visible = true;
                lbTable2.Text = "ตารางแสดงข้อมูลจำนวนอุบัติเหตุของช่องทางแต่ละด่านฯ ปีงบประมาณ " + yyyy;
                lbChart1.Text = "กราฟแสดงข้อมูลจำนวนอุบัติเหตุ ปีงบประมาณ " + yyyy;
                lbTable2.Visible = true;
            }
            //ตารางเรียกด่านเดียว ช่วง งบประมาณ
            else if (numx != 1 && begin == "" && end == "") 
            {
                AllClaim.Fill(dt);
                GridViewEn2.DataSource = dt;
                GridViewEn2.DataBind();
                GridViewEn2.Visible = true;
                lbTable2.Text = "ตารางแสดงข้อมูลความถี่การชำรุดของอุปกรณ์แต่ละช่องทาง ปีงบประมาณ " + yyyy;
                lbChart1.Text = "กราฟแสดงข้อมูลจำนวนอุบัติเหตุ ปีงบประมาณ " + yyyy;
                lbTable2.Visible = true;
            }
            //เรียกทุกด่าน แต่เลือกเป็นช่วงเวลา
            else if(numx == 1 && begin != "" && end != "") 
            {
                string since = function.ConvertDateShortThai(begin);
                string last = function.ConvertDateShortThai(end);
                AllClaim.Fill(dt);
                GridViewthing.DataSource = dt;
                GridViewthing.DataBind();
                GridViewthing.Visible = true;
                lbTable2.Text = "ตารางแสดงข้อมูลความถี่การชำรุดของอุปกรณ์แต่ละช่องทาง ("+since+" - "+last+") " ;
                lbChart1.Text = "กราฟแสดงข้อมูลจำนวนอุบัติเหตุ (" + since + " - " + last + ") ";
                lbTable2.Visible = true;
            }
            //เรียกด่านเดียว ช่วงวันที่
            else
            {
                string since = function.ConvertDateShortThai(begin);
                string last = function.ConvertDateShortThai(end);
                AllClaim.Fill(dt);
                GridViewEn2.DataSource = dt;
                GridViewEn2.DataBind();
                GridViewEn2.Visible = true;
                lbTable2.Text = "ตารางแสดงข้อมูลความถี่การชำรุดของอุปกรณ์แต่ละช่องทาง (" + since + " - " + last + ") ";
                lbChart1.Text = "กราฟแสดงข้อมูลจำนวนอุบัติเหตุ (" + since + " - " + last + ") ";
                lbTable2.Visible = true;
            }
                    
        }

        public void bindDetail2(string ssss,int num)
        {
            MySqlDataAdapter AllClaim = function.MySqlSelectDataSet(ssss);
            DataTable dt = new DataTable();

            if(num == 1)
            {
                AllClaim.Fill(dt);
                GridViewThingX.DataSource = dt;
                GridViewThingX.DataBind();
                GridViewThingX.Visible = true;
            }
            else
            {
                AllClaim.Fill(dt);
                GridViewEx2.DataSource = dt;
                GridViewEx2.DataBind();
                GridViewEx2.Visible = true;
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
        public void GenerateChart(string sql,string cpoint)
        {
            int nowBudget = int.Parse(function.getBudgetYear("01-"+ DateTime.Now.ToString("MM")+"-"+(DateTime.Now.Year + 543).ToString()));
            string cpointss = txtStation.SelectedValue;
            string budgetss = txtBudgetYear.Text;
            string MonthFullList = "ตุลาคม-มกราคม-กุมภาพันธ์-มีนาคม-เมษายน-พฤษภาคม-มิถุนายน-กรกฎาคม-สิงหาคม-กันยายน-ตุลาคม-พฤศจิกายน-ธันวาคม";
            string[] MonthList = MonthFullList.Split('-');
            string ChartQuery = " select IFNULL(c.claim_month,'ตุลาคม') AS monthx,COUNT(c.claim_id)AS Total  FROM tbl_claim c "
                                + " WHERE c.claim_month = 'ตุลาคม' AND c.claim_delete = '0' AND c.claim_status != 6 AND" 
                                + " c.claim_budget_year = '" + budgetss + "' AND c.claim_cpoint ='"+cpointss+"' "
                                + " UNION  select IFNULL(c.claim_month,'พฤศจิกายน') AS monthx, COUNT(c.claim_id)AS Total  FROM tbl_claim c "
                                + " WHERE c.claim_month = 'พฤศจิกายน' AND c.claim_delete = '0' AND c.claim_status != 6 AND " 
                                + " c.claim_budget_year = '" + budgetss + "' AND c.claim_cpoint ='" +cpointss + "' "
                                + " UNION  select IFNULL(c.claim_month,'ธันวาคม') AS monthx, COUNT(c.claim_id)AS Total  FROM tbl_claim c "
                                + " WHERE c.claim_month = 'ธันวาคม' AND c.claim_delete = '0' AND c.claim_status != 6 AND " 
                                + " c.claim_budget_year = '" + budgetss + "' AND c.claim_cpoint ='" + cpointss + "' ";
            string ChartQ = ChartQuery
                          + " UNION select IFNULL(c.claim_month, 'มกราคม') AS monthx, COUNT(c.claim_id)AS Total  FROM tbl_claim c "
                          + " WHERE c.claim_month = 'มกราคม' AND c.claim_delete = '0' AND c.claim_status != 6 AND"
                          + " c.claim_budget_year = '" + budgetss + "' AND c.claim_cpoint ='" + cpointss + "' "
                          + " UNION select IFNULL(c.claim_month, 'กุมภาพันธ์') AS monthx, COUNT(c.claim_id)AS Total  FROM tbl_claim c "
                          + " WHERE c.claim_month = 'กุมภาพันธ์' AND c.claim_delete = '0' AND c.claim_status != 6 AND"
                          + " c.claim_budget_year = '" + budgetss + "' AND c.claim_cpoint ='" + cpointss + "' "
                          + " UNION select IFNULL(c.claim_month, 'มีนาคม') AS monthx, COUNT(c.claim_id)AS Total  FROM tbl_claim c "
                          + " WHERE c.claim_month = 'มีนาคม' AND c.claim_delete = '0' AND c.claim_status != 6 AND"
                          + " c.claim_budget_year = '" + budgetss + "' AND c.claim_cpoint ='" + cpointss + "' "
                          + " UNION select IFNULL(c.claim_month, 'เมษายน') AS monthx, COUNT(c.claim_id)AS Total  FROM tbl_claim c "
                          + " WHERE c.claim_month = 'เมษายน' AND c.claim_delete = '0' AND c.claim_status != 6 AND"
                          + " c.claim_budget_year = '" + budgetss + "' AND c.claim_cpoint ='" + cpointss + "' "
                          + " UNION select IFNULL(c.claim_month, 'พฤษภาคม') AS monthx, COUNT(c.claim_id)AS Total  FROM tbl_claim c "
                          + " WHERE c.claim_month = 'พฤษภาคม' AND c.claim_delete = '0' AND c.claim_status != 6 AND"
                          + " c.claim_budget_year = '" + budgetss + "' AND c.claim_cpoint ='" + cpointss + "' "
                          + " UNION select IFNULL(c.claim_month, 'มิถุนายน') AS monthx, COUNT(c.claim_id)AS Total  FROM tbl_claim c "
                          + " WHERE c.claim_month = 'มิถุนายน' AND c.claim_delete = '0' AND c.claim_status != 6 AND"
                          + " c.claim_budget_year = '" + budgetss + "' AND c.claim_cpoint ='" + cpointss + "' "
                          + " UNION select IFNULL(c.claim_month, 'กรกฎาคม') AS monthx, COUNT(c.claim_id)AS Total  FROM tbl_claim c "
                          + " WHERE c.claim_month = 'กรกฎาคม' AND c.claim_delete = '0' AND c.claim_status != 6 AND"
                          + " c.claim_budget_year = '" + budgetss + "' AND c.claim_cpoint ='" + cpointss + "' "
                          + " UNION select IFNULL(c.claim_month, 'สิงหาคม') AS monthx, COUNT(c.claim_id)AS Total  FROM tbl_claim c "
                          + " WHERE c.claim_month = 'สิงหาคม' AND c.claim_delete = '0' AND c.claim_status != 6 AND"
                          + " c.claim_budget_year = '" + budgetss + "' AND c.claim_cpoint ='" + cpointss + "' "
                          + " UNION select IFNULL(c.claim_month, 'กันยายน') AS monthx, COUNT(c.claim_id)AS Total  FROM tbl_claim c "
                          + " WHERE c.claim_month = 'กันยายน' AND c.claim_delete = '0' AND c.claim_status != 6 AND"
                          + " c.claim_budget_year = '" + budgetss + "' AND c.claim_cpoint ='" + cpointss + "' ";

            if (cpoint == "1")
            {
                MySqlDataAdapter da = function.MySqlSelectDataSet(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                lbChart1.Visible = true;
                Chart1.DataSource = ds.Tables[0];
                if (ChkAmountClaim < 6)
                {
                    Chart1.Width = 780;
                    Chart1.Height = 250;
                }
                else
                {
                    Chart1.Width = 790;
                    Chart1.Height = 590;
                }
                Chart1.Series["Series1"].ChartType = SeriesChartType.Bar;
                //Chart1.Series["Series1"].ChartType = SeriesChartType.Line;
                Chart1.Series["Series1"].Color = Color.DarkOrange;
                Chart1.Series["Series1"].LabelForeColor = Color.Black;
                Chart1.Series["Series1"].IsValueShownAsLabel = true;
                Chart1.Series["Series1"].XValueMember = "cpoint";
                Chart1.Series["Series1"].YValueMembers = "Total";
                Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                Chart1.ChartAreas["ChartArea1"].BackColor = Color.LightGoldenrodYellow;
                Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false; 
                //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                Chart1.DataBind();

            }
            else
            {
                string QueryXX = "";
               
                            if(Nowmonth < 10 )
                            {
                                for(int i = 1 ; i <= Nowmonth ; i++ )
                                {
                                    ChartQuery += " UNION  select IFNULL(c.claim_month,'"+MonthList[i]+"') AS monthx, COUNT(c.claim_id)AS Total  FROM tbl_claim c "
                                                    + " WHERE c.claim_month = '" + MonthList[i] + "' AND c.claim_delete = '0' AND c.claim_status != 6 AND "
                                                    + " c.claim_budget_year = '" + budgetss + "' AND c.claim_cpoint ='" + cpointss + "' ";
                                }
                            }
                            else if(Nowmonth > 10)
                            {
                                ChartQuery = " select IFNULL(c.claim_month,'ตุลาคม') AS monthx, COUNT(c.claim_id)AS Total  FROM tbl_claim c "
                                            + " WHERE c.claim_month = 'ตุลาคม' AND c.claim_delete = '0' AND c.claim_status != 6 AND"
                                            + " c.claim_budget_year = '" + budgetss + "' AND c.claim_cpoint ='" + cpointss + "' ";
                                for (int i = 1; i <= Nowmonth; i++)
                                {
                                    ChartQuery += " UNION  select IFNULL(c.claim_month,'" + MonthList[i] + "') AS monthx, COUNT(c.claim_id)AS Total  FROM tbl_claim c "
                                                    + " WHERE c.claim_month = '" + MonthList[i] + "' AND c.claim_delete = '0' AND c.claim_status != 6 AND "
                                                    + " c.claim_budget_year = '" + budgetss + "' AND c.claim_cpoint ='" + cpointss + "' ";
                                }
                            }
                            else
                            {
                                ChartQuery = " select IFNULL(c.claim_month,'ตุลาคม') AS monthx,COUNT(c.claim_id)AS Total  FROM tbl_claim c "
                                            + " WHERE c.claim_month = 'ตุลาคม' AND c.claim_delete = '0' AND c.claim_status != 6 AND"
                                            + " c.claim_budget_year = '" + budgetss + "' AND c.claim_cpoint ='" + cpointss + "' ";
                            }

                if (nowBudget == int.Parse(budgetss))
                {
                    QueryXX = ChartQuery;
                }
                else { QueryXX = ChartQ; }
                MySqlDataAdapter da = function.MySqlSelectDataSet(QueryXX);
                DataSet ds = new DataSet();
                da.Fill(ds);
                lbChart1.Visible = true;
                Chart1.DataSource = ds.Tables[0];
                if(ChkAmountClaim < 6)
                {
                    Chart1.Width = 780 ;
                    Chart1.Height = 250 ;
                }
                else
                {
                    Chart1.Width = 790;
                    Chart1.Height = 590;
                }
                Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                //Chart1.Series["Series1"].ChartType = SeriesChartType.Line;
                Chart1.Series["Series1"].Color = Color.DarkOrange;
                Chart1.Series["Series1"].LabelForeColor = Color.Black;
                Chart1.Series["Series1"].IsValueShownAsLabel = true;
                Chart1.Series["Series1"].XValueMember = "monthx";
                Chart1.Series["Series1"].YValueMembers = "Total";
                Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                Chart1.ChartAreas["ChartArea1"].BackColor = Color.LightGoldenrodYellow;
                Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                Chart1.ChartAreas["ChartArea1"].AxisY.Title = "จำนวน";
                Chart1.DataBind();
            }
        }

        decimal ClaimSum = 0;
        int sum = 0;
        protected void GridViewAllbyBudget_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label NumCpoint = (Label)(e.Row.FindControl("NumCpoint"));
            if (NumCpoint != null)
            {
                NumCpoint.Text = (GridViewAllbyBudget.Rows.Count + 1).ToString() + ".";
            }
            

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ClaimSum = ClaimSum + Convert.ToDecimal(e.Row.Cells[2].Text);
                sum = sum + Convert.ToInt32(e.Row.Cells[2].Text);
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "<b>รวม</b>";
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].Text = ClaimSum.ToString("0");
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
               
            }



        }

        private bool ChanelCheck(string point)
        {
            return true;
        }
        

        protected void btnResult_Click(object sender, EventArgs e)
        {
            btnNewSearch.Visible = true;
            btnResult.Visible = false;
            headdiv.Visible = false;
            if (txtStation.SelectedValue == "")
            {
                GridViewEn2.Visible = false;
                GridViewEx2.Visible = false;
                GridViewthing.Visible = true;
                GridViewThingX.Visible = true;
                GridViewEx.Visible = true;
            }
            else
            {
                GridViewEn2.Visible = true;
                GridViewEx2.Visible = true;
                GridViewthing.Visible = false;
                GridViewThingX.Visible = false;
                GridViewEx.Visible = false;
            }

            string Budget = txtBudgetYear.Text;
            string StartD = txtStartDate.Text;
            string EndD = txtEndDate.Text;
            string beginx = "";
            string endx = "";
            //เตรียมคำสั่งไว้สำหรับคิวรี่
            string sql_query = "";
            string sql_query_out = "";
            string sql_device = "";
            string whereAreU = "";
            string BudgetOrRange = "";
            if(rbtBudget.Checked == true)
            {
                whereAreU = " c.claim_budget_year='"+Budget+ "' AND c.claim_delete = '0' AND c.claim_status != 6 ";
                BudgetOrRange = "budget";
            }
            else if(rbtDuration.Checked == true)
            {
                whereAreU = " (STR_TO_DATE(c.claim_start_date,'%d-%m-%Y') " +
                                " BETWEEN STR_TO_DATE('"+ StartD +"','%d-%m-%Y') " +
                                " AND STR_TO_DATE('"+EndD+ "','%d-%m-%Y')) AND c.claim_delete = '0' AND c.claim_status != 6 ";

                beginx = StartD;
                endx = EndD;
                BudgetOrRange = "range";
            }

           
            if (txtStation.SelectedValue == "") //กรณีเลือกทุกด่าน
            {

                sql_query = " SELECT cpoint_name AS 'cpoint' "
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN01' OR d.claim_detail_cb_claim = 'I01' THEN d.claim_detail_id END) 'EN01'"
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN02' OR d.claim_detail_cb_claim = 'I02' THEN d.claim_detail_id END) 'EN02'"
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN03' OR d.claim_detail_cb_claim = 'I03' THEN d.claim_detail_id END) 'EN03'"
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN04' OR d.claim_detail_cb_claim = 'I04' THEN d.claim_detail_id END) 'EN04'"
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN05' OR d.claim_detail_cb_claim = 'I05' THEN d.claim_detail_id END) 'EN05'"
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN06' OR d.claim_detail_cb_claim = 'I06' THEN d.claim_detail_id END) 'EN06'"
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN07' OR d.claim_detail_cb_claim = 'I07' THEN d.claim_detail_id END) 'EN07'"
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN08' OR d.claim_detail_cb_claim = 'I08' THEN d.claim_detail_id END) 'EN08'"
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN09' OR d.claim_detail_cb_claim = 'I09' THEN d.claim_detail_id END) 'EN09'"
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN10' OR d.claim_detail_cb_claim = 'I10' THEN d.claim_detail_id END) 'EN10'"
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN11' OR d.claim_detail_cb_claim = 'I11' THEN d.claim_detail_id END) 'EN11'"
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN12' OR d.claim_detail_cb_claim = 'I12' THEN d.claim_detail_id END) 'EN12'"
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN13' OR d.claim_detail_cb_claim = 'I13' THEN d.claim_detail_id END) 'EN13'"
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN14' OR d.claim_detail_cb_claim = 'I14' THEN d.claim_detail_id END) 'EN14'"
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN15' OR d.claim_detail_cb_claim = 'I15' THEN d.claim_detail_id END) 'EN15'"
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN16' OR d.claim_detail_cb_claim = 'I16' THEN d.claim_detail_id END) 'EN16'"
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN17' OR d.claim_detail_cb_claim = 'I17' THEN d.claim_detail_id END) 'EN17'"
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN18' OR d.claim_detail_cb_claim = 'I18' THEN d.claim_detail_id END) 'EN18'"
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN19' OR d.claim_detail_cb_claim = 'I19' THEN d.claim_detail_id END) 'EN19'"
                        + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN20' OR d.claim_detail_cb_claim = 'I20' THEN d.claim_detail_id END) 'EN20'"
                        + ", (COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN01' OR d.claim_detail_cb_claim = 'I01' THEN d.claim_detail_id END)"
                            + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN02' OR d.claim_detail_cb_claim = 'I02' THEN d.claim_detail_id END)"
                            + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN03' OR d.claim_detail_cb_claim = 'I03' THEN d.claim_detail_id END)"
                            + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN04' OR d.claim_detail_cb_claim = 'I04' THEN d.claim_detail_id END)"
                            + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN05' OR d.claim_detail_cb_claim = 'I05' THEN d.claim_detail_id END)"
                            + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN06' OR d.claim_detail_cb_claim = 'I06' THEN d.claim_detail_id END)"
                            + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN07' OR d.claim_detail_cb_claim = 'I07' THEN d.claim_detail_id END)"
                            + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN08' OR d.claim_detail_cb_claim = 'I08' THEN d.claim_detail_id END)"
                            + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN09' OR d.claim_detail_cb_claim = 'I09' THEN d.claim_detail_id END)"
                            + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN10' OR d.claim_detail_cb_claim = 'I10' THEN d.claim_detail_id END)"
                            + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN11' OR d.claim_detail_cb_claim = 'I11' THEN d.claim_detail_id END)"
                            + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN12' OR d.claim_detail_cb_claim = 'I12' THEN d.claim_detail_id END)"
                            + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN13' OR d.claim_detail_cb_claim = 'I13' THEN d.claim_detail_id END)"
                            + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN14' OR d.claim_detail_cb_claim = 'I14' THEN d.claim_detail_id END)"
                            + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN15' OR d.claim_detail_cb_claim = 'I15' THEN d.claim_detail_id END)"
                            + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN16' OR d.claim_detail_cb_claim = 'I16' THEN d.claim_detail_id END)"
                            + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN17' OR d.claim_detail_cb_claim = 'I17' THEN d.claim_detail_id END)"
                            + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN18' OR d.claim_detail_cb_claim = 'I18' THEN d.claim_detail_id END)"
                            + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN19' OR d.claim_detail_cb_claim = 'I19' THEN d.claim_detail_id END)"
                            + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN20' OR d.claim_detail_cb_claim = 'I20' THEN d.claim_detail_id END))AS 'total' "

                + " FROM tbl_claim c "
                + " JOIN tbl_claim_com d ON c.claim_id = d.claim_id "
                + " JOIN tbl_cpoint t ON c.claim_cpoint = t.cpoint_id "
                + " WHERE "+ whereAreU
                + " GROUP BY c.claim_cpoint ";


                    sql_query_out = " SELECT "
                    + "cpoint_name As 'cpoint'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX01' OR d.claim_detail_cb_claim = 'O01' THEN d.claim_detail_id END) 'EX01'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX02' OR d.claim_detail_cb_claim = 'O02' THEN d.claim_detail_id END) 'EX02'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX03' OR d.claim_detail_cb_claim = 'O03' THEN d.claim_detail_id END) 'EX03'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX04' OR d.claim_detail_cb_claim = 'O04' THEN d.claim_detail_id END) 'EX04'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX05' OR d.claim_detail_cb_claim = 'O05' THEN d.claim_detail_id END) 'EX05'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX06' OR d.claim_detail_cb_claim = 'O06' THEN d.claim_detail_id END) 'EX06'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX07' OR d.claim_detail_cb_claim = 'O07' THEN d.claim_detail_id END) 'EX07'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX08' OR d.claim_detail_cb_claim = 'O08' THEN d.claim_detail_id END) 'EX08'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX09' OR d.claim_detail_cb_claim = 'O09' THEN d.claim_detail_id END) 'EX09'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX10' OR d.claim_detail_cb_claim = 'O10' THEN d.claim_detail_id END) 'EX10'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX11' OR d.claim_detail_cb_claim = 'O11' THEN d.claim_detail_id END) 'EX11'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX12' OR d.claim_detail_cb_claim = 'O12' THEN d.claim_detail_id END) 'EX12'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX13' OR d.claim_detail_cb_claim = 'O13' THEN d.claim_detail_id END) 'EX13'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX14' OR d.claim_detail_cb_claim = 'O14' THEN d.claim_detail_id END) 'EX14'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX15' OR d.claim_detail_cb_claim = 'O15' THEN d.claim_detail_id END) 'EX15'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX16' OR d.claim_detail_cb_claim = 'O16' THEN d.claim_detail_id END) 'EX16'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX17' OR d.claim_detail_cb_claim = 'O17' THEN d.claim_detail_id END) 'EX17'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX18' OR d.claim_detail_cb_claim = 'O18' THEN d.claim_detail_id END) 'EX18'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX19' OR d.claim_detail_cb_claim = 'O19' THEN d.claim_detail_id END) 'EX19'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX20' OR d.claim_detail_cb_claim = 'O20' THEN d.claim_detail_id END) 'EX20'"
                     


                    + " FROM tbl_claim c "
                    + " JOIN tbl_claim_com d ON c.claim_id = d.claim_id "
                    + " JOIN tbl_cpoint t ON c.claim_cpoint = t.cpoint_id "
                    + " WHERE " + whereAreU
                    + " GROUP BY c.claim_cpoint ";

                
                string overall = "SELECT cpoint_name AS 'cpoint' ,COUNT(c.claim_id) AS Total "
                                    + " FROM tbl_claim c "
                                    + " JOIN tbl_cpoint t ON c.claim_cpoint = t.cpoint_id "
                                    + " WHERE "+whereAreU+ "  GROUP BY c.claim_cpoint  Order BY Total ";

                string overallTable = "SELECT cpoint_name AS 'cpoint' ,COUNT(c.claim_id) AS Total "
                                    + " FROM tbl_claim c "
                                    + " JOIN tbl_cpoint t ON c.claim_cpoint = t.cpoint_id "
                                    + " WHERE " + whereAreU + "  GROUP BY c.claim_cpoint  Order BY Total DESC";

                sql_device = "SELECT tbl_device.device_name AS 'devicename' ,COUNT(e.device_id)AS 'amount'"
                                + " FROM tbl_claim c "
                                + " JOIN tbl_claim_com d ON d.claim_id = c.claim_id"
                                + " JOIN tbl_device_damaged e ON d.claim_id = e.claim_id"
                                + " JOIN tbl_device ON e.device_id = tbl_device.device_id"
                                + " JOIN tbl_cpoint ON c.claim_cpoint = tbl_cpoint.cpoint_id"
                                + " WHERE" + whereAreU
                                + " AND  e.device_damaged_delete = 0"
                                + " GROUP BY tbl_device.device_name ORDER BY amount DESC";
              
                bindAllClaim(overallTable, Budget,beginx ,endx);
                bindDevice(sql_device);
                bindDetail(sql_query, Budget,1,beginx,endx);
                bindDetail2(sql_query_out,1);
               GenerateChart(overall,"1"); 
                
            }
            else if (txtStation.SelectedValue != "") //กรณีเลือกรายด่าน!!!
            {

                     sql_query = "SELECT tbl_device.device_name As 'devicename' "

                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN01' OR d.claim_detail_cb_claim = 'I01' THEN d.claim_detail_id END) 'EN01'"
                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN02' OR d.claim_detail_cb_claim = 'I02' THEN d.claim_detail_id END) 'EN02'"
                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN03' OR d.claim_detail_cb_claim = 'I03' THEN d.claim_detail_id END) 'EN03'"
                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN04' OR d.claim_detail_cb_claim = 'I04' THEN d.claim_detail_id END) 'EN04'"
                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN05' OR d.claim_detail_cb_claim = 'I05' THEN d.claim_detail_id END) 'EN05'"
                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN06' OR d.claim_detail_cb_claim = 'I06' THEN d.claim_detail_id END) 'EN06'"
                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN07' OR d.claim_detail_cb_claim = 'I07' THEN d.claim_detail_id END) 'EN07'"
                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN08' OR d.claim_detail_cb_claim = 'I08' THEN d.claim_detail_id END) 'EN08'"
                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN09' OR d.claim_detail_cb_claim = 'I09' THEN d.claim_detail_id END) 'EN09'"
                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN10' OR d.claim_detail_cb_claim = 'I10' THEN d.claim_detail_id END) 'EN10'"
                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN11' OR d.claim_detail_cb_claim = 'I11' THEN d.claim_detail_id END) 'EN11'"
                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN12' OR d.claim_detail_cb_claim = 'I12' THEN d.claim_detail_id END) 'EN12'"
                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN13' OR d.claim_detail_cb_claim = 'I13' THEN d.claim_detail_id END) 'EN13'"
                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN14' OR d.claim_detail_cb_claim = 'I14' THEN d.claim_detail_id END) 'EN14'"
                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN15' OR d.claim_detail_cb_claim = 'I15' THEN d.claim_detail_id END) 'EN15'"
                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN16' OR d.claim_detail_cb_claim = 'I16' THEN d.claim_detail_id END) 'EN16'"
                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN17' OR d.claim_detail_cb_claim = 'I17' THEN d.claim_detail_id END) 'EN17'"
                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN18' OR d.claim_detail_cb_claim = 'I18' THEN d.claim_detail_id END) 'EN18'"
                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN19' OR d.claim_detail_cb_claim = 'I19' THEN d.claim_detail_id END) 'EN19'"
                    + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN20' OR d.claim_detail_cb_claim = 'I20' THEN d.claim_detail_id END) 'EN20'"
                    
                            + " FROM tbl_claim c"
                            + " JOIN tbl_claim_com d ON d.claim_id = c.claim_id"
                            + " JOIN tbl_device_damaged e ON d.claim_id = e.claim_id"
                            + " JOIN tbl_device ON e.device_id = tbl_device.device_id"
                            + " JOIN tbl_cpoint ON c.claim_cpoint = tbl_cpoint.cpoint_id"
                            + " WHERE "+whereAreU+ " AND (SUBSTR(claim_detail_cb_claim,1,2)='EN' OR SUBSTR(claim_detail_cb_claim,1,1)='I') "
                            + " AND c.claim_cpoint = '" + txtStation.SelectedValue + "' AND e.device_damaged_delete = 0"
                            + " GROUP BY tbl_device.device_name  ORDER BY tbl_device.device_name ";


                    sql_query_out = "SELECT tbl_device.device_name As 'devicename' "

                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX01' OR d.claim_detail_cb_claim = 'O01' THEN d.claim_detail_id END) 'EX01'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX02' OR d.claim_detail_cb_claim = 'O02' THEN d.claim_detail_id END) 'EX02'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX03' OR d.claim_detail_cb_claim = 'O03' THEN d.claim_detail_id END) 'EX03'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX04' OR d.claim_detail_cb_claim = 'O04' THEN d.claim_detail_id END) 'EX04'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX05' OR d.claim_detail_cb_claim = 'O05' THEN d.claim_detail_id END) 'EX05'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX06' OR d.claim_detail_cb_claim = 'O06' THEN d.claim_detail_id END) 'EX06'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX07' OR d.claim_detail_cb_claim = 'O07' THEN d.claim_detail_id END) 'EX07'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX08' OR d.claim_detail_cb_claim = 'O08' THEN d.claim_detail_id END) 'EX08'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX09' OR d.claim_detail_cb_claim = 'O09' THEN d.claim_detail_id END) 'EX09'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX10' OR d.claim_detail_cb_claim = 'O10' THEN d.claim_detail_id END) 'EX10'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX11' OR d.claim_detail_cb_claim = 'O11' THEN d.claim_detail_id END) 'EX11'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX12' OR d.claim_detail_cb_claim = 'O12' THEN d.claim_detail_id END) 'EX12'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX13' OR d.claim_detail_cb_claim = 'O13' THEN d.claim_detail_id END) 'EX13'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX14' OR d.claim_detail_cb_claim = 'O14' THEN d.claim_detail_id END) 'EX14'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX15' OR d.claim_detail_cb_claim = 'O15' THEN d.claim_detail_id END) 'EX15'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX16' OR d.claim_detail_cb_claim = 'O16' THEN d.claim_detail_id END) 'EX16'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX17' OR d.claim_detail_cb_claim = 'O17' THEN d.claim_detail_id END) 'EX17'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX18' OR d.claim_detail_cb_claim = 'O18' THEN d.claim_detail_id END) 'EX18'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX19' OR d.claim_detail_cb_claim = 'O19' THEN d.claim_detail_id END) 'EX19'"
                     + ", COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX20' OR d.claim_detail_cb_claim = 'O20' THEN d.claim_detail_id END) 'EX20'"
                     + ",(COUNT(CASE WHEN d.claim_detail_cb_claim = 'EN01' OR d.claim_detail_cb_claim = 'I01' THEN d.claim_detail_id END)"
                    + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX02' OR d.claim_detail_cb_claim = 'O02' THEN d.claim_detail_id END)"
                    + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX03' OR d.claim_detail_cb_claim = 'O03' THEN d.claim_detail_id END)"
                    + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX04' OR d.claim_detail_cb_claim = 'O04' THEN d.claim_detail_id END)"
                    + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX05' OR d.claim_detail_cb_claim = 'O05' THEN d.claim_detail_id END)"
                    + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX06' OR d.claim_detail_cb_claim = 'O06' THEN d.claim_detail_id END)"
                    + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX07' OR d.claim_detail_cb_claim = 'O07' THEN d.claim_detail_id END)"
                    + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX08' OR d.claim_detail_cb_claim = 'O08' THEN d.claim_detail_id END)"
                    + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX09' OR d.claim_detail_cb_claim = 'O09' THEN d.claim_detail_id END)"
                    + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX10' OR d.claim_detail_cb_claim = 'O10' THEN d.claim_detail_id END)"
                    + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX11' OR d.claim_detail_cb_claim = 'O11' THEN d.claim_detail_id END)"
                    + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX12' OR d.claim_detail_cb_claim = 'O12' THEN d.claim_detail_id END)"
                    + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX13' OR d.claim_detail_cb_claim = 'O13' THEN d.claim_detail_id END)"
                    + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX14' OR d.claim_detail_cb_claim = 'O14' THEN d.claim_detail_id END)"
                    + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX15' OR d.claim_detail_cb_claim = 'O15' THEN d.claim_detail_id END)"
                    + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX16' OR d.claim_detail_cb_claim = 'O16' THEN d.claim_detail_id END)"
                    + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX17' OR d.claim_detail_cb_claim = 'O17' THEN d.claim_detail_id END)"
                    + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX18' OR d.claim_detail_cb_claim = 'O18' THEN d.claim_detail_id END)"
                    + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX19' OR d.claim_detail_cb_claim = 'O19' THEN d.claim_detail_id END)"
                    + "+ COUNT(CASE WHEN d.claim_detail_cb_claim = 'EX20' OR d.claim_detail_cb_claim = 'O20' THEN d.claim_detail_id END)) AS 'total' "
                            + " FROM tbl_claim c"
                            + " JOIN tbl_claim_com d ON d.claim_id = c.claim_id"
                            + " JOIN tbl_device_damaged e ON d.claim_id = e.claim_id"
                            + " JOIN tbl_device ON e.device_id = tbl_device.device_id"
                            + " JOIN tbl_cpoint ON c.claim_cpoint = tbl_cpoint.cpoint_id"
                            + " WHERE "+whereAreU+ " AND (SUBSTR(claim_detail_cb_claim,1,2)='EX' OR SUBSTR(claim_detail_cb_claim,1,1)='O') "
                            + " AND c.claim_cpoint = '" + txtStation.SelectedValue + "' AND e.device_damaged_delete = 0"
                            + " GROUP BY tbl_device.device_name  ORDER BY tbl_device.device_name ";

                string overall = "SELECT cpoint_name AS 'cpoint' ,COUNT(c.claim_id) AS Total "
                                  + " FROM tbl_claim c "
                                  + " JOIN tbl_cpoint t ON c.claim_cpoint = t.cpoint_id "
                                  + " WHERE " + whereAreU + " AND cpoint_id='" + txtStation.SelectedValue +"'";
                
                sql_device = "SELECT tbl_device.device_name AS 'devicename' ,COUNT(e.device_id)AS 'amount'"
                                + " FROM tbl_claim c "
                                + " JOIN tbl_claim_com d ON d.claim_id = c.claim_id"
                                + " JOIN tbl_device_damaged e ON d.claim_id = e.claim_id"
                                + " JOIN tbl_device ON e.device_id = tbl_device.device_id"
                                + " JOIN tbl_cpoint ON c.claim_cpoint = tbl_cpoint.cpoint_id"
                                + " WHERE" + whereAreU + " AND cpoint_id='" + txtStation.SelectedValue + "'"
                                + " AND  e.device_damaged_delete = 0"
                                + " GROUP BY tbl_device.device_name ORDER BY amount DESC";

                bindAllClaim(overall, Budget, beginx, endx);
                bindDevice(sql_device);
                bindDetail(sql_query, Budget,2,beginx,endx);
                bindDetail2(sql_query_out,2);
               if(BudgetOrRange == "budget") { GenerateChart(overall, "2"); }

            }
            

        }

        decimal en1toen1 = 0; decimal en1toen2 = 0; decimal en1toen3 = 0; decimal en1toen4 = 0; decimal en1toen5 = 0;
        decimal en1toen6 = 0; decimal en1toen7 = 0; decimal en1toen8 = 0; decimal en1toen9 = 0; decimal en1toen10 = 0;
        decimal en1toen11 = 0; decimal en1toen12 = 0; decimal en1toen13 = 0; decimal en1toen14 = 0; decimal en1toen15 = 0;
        decimal en1toen16 = 0; decimal en1toen17 = 0; decimal en1toen18 = 0; decimal en1toen19 = 0; decimal en1toen20 = 0;
        protected void GridViewthing_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label NumEn1 = (Label)(e.Row.FindControl("NumEn1"));
            if (NumEn1 != null)
            {
                NumEn1.Text = (GridViewthing.Rows.Count + 1).ToString() + ".";
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                en1toen1 = en1toen1 + Convert.ToDecimal(e.Row.Cells[2].Text); en1toen2 = en1toen2 + Convert.ToDecimal(e.Row.Cells[3].Text);
                en1toen3 = en1toen3 + Convert.ToDecimal(e.Row.Cells[4].Text); en1toen4 = en1toen4 + Convert.ToDecimal(e.Row.Cells[5].Text);
                en1toen5 = en1toen5 + Convert.ToDecimal(e.Row.Cells[6].Text); en1toen6 = en1toen6 + Convert.ToDecimal(e.Row.Cells[7].Text);
                en1toen7 = en1toen7 + Convert.ToDecimal(e.Row.Cells[8].Text); en1toen8 = en1toen8 + Convert.ToDecimal(e.Row.Cells[9].Text);
                en1toen9 = en1toen9 + Convert.ToDecimal(e.Row.Cells[10].Text); en1toen10 = en1toen10 + Convert.ToDecimal(e.Row.Cells[11].Text);
                en1toen11 = en1toen11 + Convert.ToDecimal(e.Row.Cells[12].Text); en1toen12 = en1toen12 + Convert.ToDecimal(e.Row.Cells[13].Text);
                en1toen13 = en1toen13 + Convert.ToDecimal(e.Row.Cells[14].Text); en1toen14 = en1toen14 + Convert.ToDecimal(e.Row.Cells[15].Text);
                en1toen15 = en1toen15 + Convert.ToDecimal(e.Row.Cells[16].Text); en1toen16 = en1toen16 + Convert.ToDecimal(e.Row.Cells[17].Text);
                en1toen17 = en1toen17 + Convert.ToDecimal(e.Row.Cells[18].Text); en1toen18 = en1toen18 + Convert.ToDecimal(e.Row.Cells[19].Text);
                en1toen19 = en1toen19 + Convert.ToDecimal(e.Row.Cells[20].Text); en1toen20 = en1toen20 + Convert.ToDecimal(e.Row.Cells[21].Text);                               
                e.Row.Cells[22].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[22].BackColor = System.Drawing.ColorTranslator.FromHtml("#c12626");
                e.Row.Cells[22].ForeColor = System.Drawing.Color.White; e.Row.Cells[22].Font.Bold = true;
                e.Row.Cells[1].Font.Size = 15;

                //e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ff8787");
                if (e.Row.Cells[2].Text != "0") { e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[2].Font.Bold = true ; }
                if (e.Row.Cells[3].Text != "0") { e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[3].Font.Bold = true; }
                if (e.Row.Cells[4].Text != "0") { e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[4].Font.Bold = true; }
                if (e.Row.Cells[5].Text != "0") { e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[5].Font.Bold = true; }
                if (e.Row.Cells[6].Text != "0") { e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[6].Font.Bold = true; }
                if (e.Row.Cells[7].Text != "0") { e.Row.Cells[7].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[7].Font.Bold = true; }
                if (e.Row.Cells[8].Text != "0") { e.Row.Cells[8].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[8].Font.Bold = true; }
                if (e.Row.Cells[9].Text != "0") { e.Row.Cells[9].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[9].Font.Bold = true; }
                if (e.Row.Cells[10].Text != "0") { e.Row.Cells[10].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[10].Font.Bold = true; }
                if (e.Row.Cells[11].Text != "0") { e.Row.Cells[11].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[11].Font.Bold = true; }
                if (e.Row.Cells[12].Text != "0") { e.Row.Cells[12].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[12].Font.Bold = true; }
                if (e.Row.Cells[13].Text != "0") { e.Row.Cells[13].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[13].Font.Bold = true; }
                if (e.Row.Cells[14].Text != "0") { e.Row.Cells[14].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[14].Font.Bold = true; }
                if (e.Row.Cells[15].Text != "0") { e.Row.Cells[15].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[15].Font.Bold = true; }
                if (e.Row.Cells[16].Text != "0") { e.Row.Cells[16].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[16].Font.Bold = true; }
                if (e.Row.Cells[17].Text != "0") { e.Row.Cells[17].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[17].Font.Bold = true; }
                if (e.Row.Cells[18].Text != "0") { e.Row.Cells[18].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[18].Font.Bold = true; }
                if (e.Row.Cells[19].Text != "0") { e.Row.Cells[19].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[19].Font.Bold = true; }
                if (e.Row.Cells[20].Text != "0") { e.Row.Cells[20].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[20].Font.Bold = true; }
                if (e.Row.Cells[21].Text != "0") { e.Row.Cells[21].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc"); e.Row.Cells[21].Font.Bold = true; }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "<b>รวม</b>";
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Cells[22].Text = en1total.ToString("0");
                e.Row.Cells[2].Text = en1toen1.ToString("0"); e.Row.Cells[3].Text = en1toen2.ToString("0");
                e.Row.Cells[4].Text = en1toen3.ToString("0"); e.Row.Cells[5].Text = en1toen4.ToString("0"); e.Row.Cells[6].Text = en1toen5.ToString("0");
                e.Row.Cells[7].Text = en1toen6.ToString("0"); e.Row.Cells[8].Text = en1toen7.ToString("0"); e.Row.Cells[9].Text = en1toen8.ToString("0");
                e.Row.Cells[10].Text = en1toen9.ToString("0"); e.Row.Cells[11].Text = en1toen10.ToString("0"); e.Row.Cells[12].Text = en1toen11.ToString("0");
                e.Row.Cells[13].Text = en1toen12.ToString("0"); e.Row.Cells[14].Text = en1toen13.ToString("0"); e.Row.Cells[15].Text = en1toen14.ToString("0");
                e.Row.Cells[16].Text = en1toen15.ToString("0"); e.Row.Cells[17].Text = en1toen16.ToString("0"); e.Row.Cells[18].Text = en1toen17.ToString("0");
                e.Row.Cells[19].Text = en1toen18.ToString("0"); e.Row.Cells[20].Text = en1toen19.ToString("0"); e.Row.Cells[21].Text = en1toen20.ToString("0");
                e.Row.Cells[22].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[21].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[20].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[19].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[18].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[17].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[16].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[14].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[13].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[12].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[22].Text = (en1toen1 + en1toen2 + en1toen3 + en1toen4 + en1toen5 + en1toen6 + en1toen7 + en1toen8 + en1toen9 + en1toen10
                    + en1toen11 + en1toen12 + en1toen13 + en1toen14 + en1toen15 + en1toen16 + en1toen17 + en1toen18 + en1toen19 + en1toen20).ToString();

            }
            
            Label FinalEn1 = (Label)(e.Row.FindControl("FinalEn1"));
            if (FinalEn1 != null)
            {
                FinalEn1.Text = (double.Parse(DataBinder.Eval(e.Row.DataItem, "EN01").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN02").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN03").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN04").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN05").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN06").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN07").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN08").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN09").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN10").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN11").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN12").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN13").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN14").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN15").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN16").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN17").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN18").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN19").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN20").ToString())).ToString();
            }
        }
        decimal ex1total = 0;
        decimal ex1toen1 = 0; decimal ex1toen2 = 0; decimal ex1toen3 = 0; decimal ex1toen4 = 0; decimal ex1toen5 = 0;
        decimal ex1toen6 = 0; decimal ex1toen7 = 0; decimal ex1toen8 = 0; decimal ex1toen9 = 0; decimal ex1toen10 = 0;
        decimal ex1toen11 = 0; decimal ex1toen12 = 0; decimal ex1toen13 = 0; decimal ex1toen14 = 0; decimal ex1toen15 = 0;
        decimal ex1toen16 = 0; decimal ex1toen17 = 0; decimal ex1toen18 = 0; decimal ex1toen19 = 0; decimal ex1toen20 = 0;
        protected void GridViewEx_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label NumEx = (Label)(e.Row.FindControl("NumEx"));
            if (NumEx != null)
            {
                NumEx.Text = (GridViewEx.Rows.Count + 1).ToString() + ".";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ex1total = ex1total + Convert.ToDecimal(e.Row.Cells[22].Text);
                ex1toen1 = ex1toen1 + Convert.ToDecimal(e.Row.Cells[2].Text); ex1toen2 = ex1toen2 + Convert.ToDecimal(e.Row.Cells[3].Text);
                ex1toen3 = en1toen3 + Convert.ToDecimal(e.Row.Cells[4].Text); ex1toen4 = ex1toen4 + Convert.ToDecimal(e.Row.Cells[5].Text);
                ex1toen5 = ex1toen5 + Convert.ToDecimal(e.Row.Cells[6].Text); ex1toen6 = ex1toen6 + Convert.ToDecimal(e.Row.Cells[7].Text);
                ex1toen7 = ex1toen7 + Convert.ToDecimal(e.Row.Cells[8].Text); ex1toen8 = ex1toen8 + Convert.ToDecimal(e.Row.Cells[9].Text);
                ex1toen9 = ex1toen9 + Convert.ToDecimal(e.Row.Cells[10].Text); ex1toen10 = ex1toen10 + Convert.ToDecimal(e.Row.Cells[11].Text);
                ex1toen11 = ex1toen11 + Convert.ToDecimal(e.Row.Cells[12].Text); ex1toen12 = ex1toen12 + Convert.ToDecimal(e.Row.Cells[13].Text);
                ex1toen13 = ex1toen13 + Convert.ToDecimal(e.Row.Cells[14].Text); ex1toen14 = ex1toen14 + Convert.ToDecimal(e.Row.Cells[15].Text);
                ex1toen15 = ex1toen15 + Convert.ToDecimal(e.Row.Cells[16].Text); ex1toen16 = ex1toen16 + Convert.ToDecimal(e.Row.Cells[17].Text);
                ex1toen17 = ex1toen17 + Convert.ToDecimal(e.Row.Cells[18].Text); ex1toen18 = ex1toen18 + Convert.ToDecimal(e.Row.Cells[19].Text);
                ex1toen19 = ex1toen19 + Convert.ToDecimal(e.Row.Cells[20].Text); ex1toen20 = ex1toen20 + Convert.ToDecimal(e.Row.Cells[21].Text);
                e.Row.Cells[22].HorizontalAlign = HorizontalAlign.Center;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "<b>รวม</b>";
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[22].Text = ex1total.ToString("0"); e.Row.Cells[2].Text = ex1toen1.ToString("0"); e.Row.Cells[3].Text = ex1toen2.ToString("0");
                e.Row.Cells[4].Text = ex1toen3.ToString("0"); e.Row.Cells[5].Text = ex1toen4.ToString("0"); e.Row.Cells[6].Text = ex1toen5.ToString("0");
                e.Row.Cells[7].Text = ex1toen6.ToString("0"); e.Row.Cells[8].Text = ex1toen7.ToString("0"); e.Row.Cells[9].Text = ex1toen8.ToString("0");
                e.Row.Cells[10].Text = ex1toen9.ToString("0"); e.Row.Cells[11].Text = ex1toen10.ToString("0"); e.Row.Cells[12].Text = ex1toen11.ToString("0");
                e.Row.Cells[13].Text = ex1toen12.ToString("0"); e.Row.Cells[14].Text = ex1toen13.ToString("0"); e.Row.Cells[15].Text = ex1toen14.ToString("0");
                e.Row.Cells[16].Text = ex1toen15.ToString("0"); e.Row.Cells[17].Text = ex1toen16.ToString("0"); e.Row.Cells[18].Text = ex1toen17.ToString("0");
                e.Row.Cells[19].Text = ex1toen18.ToString("0"); e.Row.Cells[20].Text = ex1toen19.ToString("0"); e.Row.Cells[21].Text = ex1toen20.ToString("0");
                e.Row.Cells[22].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[21].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[20].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[19].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[18].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[17].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[16].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[14].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[13].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[12].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;

            }
            if (e.Row.Cells[2].Text == "0") { e.Row.Cells[2].Text = "-"; }
            if (e.Row.Cells[3].Text == "0") { e.Row.Cells[3].Text = "-"; }
            if (e.Row.Cells[4].Text == "0") { e.Row.Cells[4].Text = "-"; }
            if (e.Row.Cells[5].Text == "0") { e.Row.Cells[5].Text = "-"; }
            if (e.Row.Cells[6].Text == "0") { e.Row.Cells[6].Text = "-"; }
            if (e.Row.Cells[7].Text == "0") { e.Row.Cells[7].Text = "-"; }
            if (e.Row.Cells[8].Text == "0") { e.Row.Cells[8].Text = "-"; }
            if (e.Row.Cells[9].Text == "0") { e.Row.Cells[9].Text = "-"; }
            if (e.Row.Cells[10].Text == "0") { e.Row.Cells[10].Text = "-"; }
            if (e.Row.Cells[11].Text == "0") { e.Row.Cells[11].Text = "-"; }
            if (e.Row.Cells[12].Text == "0") { e.Row.Cells[12].Text = "-"; }
            if (e.Row.Cells[13].Text == "0") { e.Row.Cells[13].Text = "-"; }
            if (e.Row.Cells[14].Text == "0") { e.Row.Cells[14].Text = "-"; }
            if (e.Row.Cells[15].Text == "0") { e.Row.Cells[15].Text = "-"; }
            if (e.Row.Cells[16].Text == "0") { e.Row.Cells[16].Text = "-"; }
            if (e.Row.Cells[17].Text == "0") { e.Row.Cells[17].Text = "-"; }
            if (e.Row.Cells[18].Text == "0") { e.Row.Cells[18].Text = "-"; }
            if (e.Row.Cells[19].Text == "0") { e.Row.Cells[19].Text = "-"; }
            if (e.Row.Cells[20].Text == "0") { e.Row.Cells[20].Text = "-"; }
            if (e.Row.Cells[21].Text == "0") { e.Row.Cells[21].Text = "-"; }
        }

        protected void rbtBudget_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtBudget.Checked == true)
            {
                lbBudget.Visible = true;
                lbStartDate.Visible = false;
                lbEndDate.Visible = false;
                txtStartDate.Visible = false;
                txtEndDate.Visible = false;
                txtBudgetYear.Visible = true;
                btnResult.Visible = true;
            }
            else if (rbtDuration.Checked == true)
            {
                lbStartDate.Visible = true;
                lbEndDate.Visible = true;
                lbBudget.Visible = false;
                txtBudgetYear.Visible = false;
                txtStartDate.Visible = true;
                txtEndDate.Visible = true;
                btnResult.Visible = true;
            }
        }

        protected void rbtDuration_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtBudget.Checked == true)
            {
                lbBudget.Visible = true;
                lbStartDate.Visible = false;
                lbEndDate.Visible = false;
                txtStartDate.Visible = false;
                txtEndDate.Visible = false;
                txtBudgetYear.Visible = true;
                btnResult.Visible = true;
                
            }
            else if (rbtDuration.Checked == true)
            {
                lbStartDate.Visible = true;
                lbEndDate.Visible = true;
                lbBudget.Visible = false;
                txtBudgetYear.Visible = false;
                txtStartDate.Visible = true;
                txtEndDate.Visible = true;
                btnResult.Visible = true;
            }
        }

        protected void GridViewAllbyBudget_RowCreated(object sender, GridViewRowEventArgs e)
        {
        }

        protected void GridViewthing_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridViewEx_RowCreated(object sender, GridViewRowEventArgs e)
        {
           
        }

        protected void GridViewEn2_RowCreated(object sender, GridViewRowEventArgs e)
        {
          
            
        }

        protected void GridViewEx2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
        }
        decimal Devicetotal = 0;
        protected void DeviceGridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label NumDevice = (Label)(e.Row.FindControl("NumDevice"));
            if (NumDevice != null)
            {
                NumDevice.Text = (DeviceGridview.Rows.Count + 1).ToString()+".";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Devicetotal = Devicetotal + Convert.ToDecimal(e.Row.Cells[2].Text);

                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
            }


            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "<b>รวม</b>";
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].Text = Devicetotal.ToString("0");
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
            }
        }
        
        decimal en2toen1 = 0; decimal en2toen2 = 0; decimal en2toen3 = 0; decimal en2toen4 = 0; decimal en2toen5 = 0;
        decimal en2toen6 = 0; decimal en2toen7 = 0; decimal en2toen8 = 0; decimal en2toen9 = 0; decimal en2toen10 = 0;
        decimal en2toen11 = 0; decimal en2toen12 = 0; decimal en2toen13 = 0; decimal en2toen14 = 0; decimal en2toen15 = 0;
        decimal en2toen16 = 0; decimal en2toen17 = 0; decimal en2toen18 = 0; decimal en2toen19 = 0; decimal en2toen20 = 0;
        protected void GridViewEn2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            Label NumEn2 = (Label)(e.Row.FindControl("NumEn2"));
            if (NumEn2 != null)
            {
                NumEn2.Text = (GridViewEn2.Rows.Count + 1).ToString() + ".";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                en2toen1 = en2toen1 + Convert.ToDecimal(e.Row.Cells[2].Text); en2toen2 = en2toen2 + Convert.ToDecimal(e.Row.Cells[3].Text);
                en2toen3 = en2toen3 + Convert.ToDecimal(e.Row.Cells[4].Text); en2toen4 = en2toen4 + Convert.ToDecimal(e.Row.Cells[5].Text);
                en2toen5 = en2toen5 + Convert.ToDecimal(e.Row.Cells[6].Text); en2toen6 = en2toen6 + Convert.ToDecimal(e.Row.Cells[7].Text);
                en2toen7 = en2toen7 + Convert.ToDecimal(e.Row.Cells[8].Text); en2toen8 = en2toen8 + Convert.ToDecimal(e.Row.Cells[9].Text);
                en2toen9 = en2toen9 + Convert.ToDecimal(e.Row.Cells[10].Text); en2toen10 = en2toen10 + Convert.ToDecimal(e.Row.Cells[11].Text);
                en2toen11 = en2toen11 + Convert.ToDecimal(e.Row.Cells[12].Text); en2toen12 = en2toen12 + Convert.ToDecimal(e.Row.Cells[13].Text);
                en2toen13 = en2toen13 + Convert.ToDecimal(e.Row.Cells[14].Text); en2toen14 = en2toen14 + Convert.ToDecimal(e.Row.Cells[15].Text);
                en2toen15 = en2toen15 + Convert.ToDecimal(e.Row.Cells[16].Text); en2toen16 = en2toen16 + Convert.ToDecimal(e.Row.Cells[17].Text);
                en2toen17 = en2toen17 + Convert.ToDecimal(e.Row.Cells[18].Text); en2toen18 = en2toen18 + Convert.ToDecimal(e.Row.Cells[19].Text);
                en2toen19 = en2toen19 + Convert.ToDecimal(e.Row.Cells[20].Text); en2toen20 = en2toen20 + Convert.ToDecimal(e.Row.Cells[21].Text);
                e.Row.Cells[22].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[22].BackColor = System.Drawing.ColorTranslator.FromHtml("#394cf9");
                e.Row.Cells[22].ForeColor = System.Drawing.Color.White; e.Row.Cells[22].Font.Bold = true;
                e.Row.Cells[1].Font.Size = 15;

                if (e.Row.Cells[2].Text != "0") { e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[2].Font.Bold = true; }
                if (e.Row.Cells[3].Text != "0") { e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[3].Font.Bold = true; }
                if (e.Row.Cells[4].Text != "0") { e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[4].Font.Bold = true; }
                if (e.Row.Cells[5].Text != "0") { e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[5].Font.Bold = true; }
                if (e.Row.Cells[6].Text != "0") { e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[6].Font.Bold = true; }
                if (e.Row.Cells[7].Text != "0") { e.Row.Cells[7].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[7].Font.Bold = true; }
                if (e.Row.Cells[8].Text != "0") { e.Row.Cells[8].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[8].Font.Bold = true; }
                if (e.Row.Cells[9].Text != "0") { e.Row.Cells[9].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[9].Font.Bold = true; }
                if (e.Row.Cells[10].Text != "0") { e.Row.Cells[10].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[10].Font.Bold = true; }
                if (e.Row.Cells[11].Text != "0") { e.Row.Cells[11].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[11].Font.Bold = true; }
                if (e.Row.Cells[12].Text != "0") { e.Row.Cells[12].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[12].Font.Bold = true; }
                if (e.Row.Cells[13].Text != "0") { e.Row.Cells[13].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[13].Font.Bold = true; }
                if (e.Row.Cells[14].Text != "0") { e.Row.Cells[14].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[14].Font.Bold = true; }
                if (e.Row.Cells[15].Text != "0") { e.Row.Cells[15].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[15].Font.Bold = true; }
                if (e.Row.Cells[16].Text != "0") { e.Row.Cells[16].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[16].Font.Bold = true; }
                if (e.Row.Cells[17].Text != "0") { e.Row.Cells[17].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[17].Font.Bold = true; }
                if (e.Row.Cells[18].Text != "0") { e.Row.Cells[18].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[18].Font.Bold = true; }
                if (e.Row.Cells[19].Text != "0") { e.Row.Cells[19].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[19].Font.Bold = true; }
                if (e.Row.Cells[20].Text != "0") { e.Row.Cells[20].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[20].Font.Bold = true; }
                if (e.Row.Cells[21].Text != "0") { e.Row.Cells[21].BackColor = System.Drawing.ColorTranslator.FromHtml("#99a9fc"); e.Row.Cells[21].Font.Bold = true; }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "<b>รวม</b>";
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].Text = en2toen1.ToString("0"); e.Row.Cells[3].Text = en2toen2.ToString("0");
                e.Row.Cells[4].Text = en2toen3.ToString("0"); e.Row.Cells[5].Text = en2toen4.ToString("0"); e.Row.Cells[6].Text = en2toen5.ToString("0");
                e.Row.Cells[7].Text = en2toen6.ToString("0"); e.Row.Cells[8].Text = en2toen7.ToString("0"); e.Row.Cells[9].Text = en2toen8.ToString("0");
                e.Row.Cells[10].Text = en2toen9.ToString("0"); e.Row.Cells[11].Text = en2toen10.ToString("0"); e.Row.Cells[12].Text = en2toen11.ToString("0");
                e.Row.Cells[13].Text = en2toen12.ToString("0"); e.Row.Cells[14].Text = en2toen13.ToString("0"); e.Row.Cells[15].Text = en2toen14.ToString("0");
                e.Row.Cells[16].Text = en2toen15.ToString("0"); e.Row.Cells[17].Text = en2toen16.ToString("0"); e.Row.Cells[18].Text = en2toen17.ToString("0");
                e.Row.Cells[19].Text = en2toen18.ToString("0"); e.Row.Cells[20].Text = en2toen19.ToString("0"); e.Row.Cells[21].Text = en2toen20.ToString("0");
                e.Row.Cells[22].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[21].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[20].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[19].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[18].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[17].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[16].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[14].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[13].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[12].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[22].Text = (en2toen1 + en2toen2 + en2toen3 + en2toen4 + en2toen5 + en2toen6 + en2toen7 + en2toen8 + en2toen9 + en2toen10
                     + en2toen11 + en2toen12 + en2toen13 + en2toen14 + en2toen15 + en2toen16 + en2toen17 + en2toen18 + en2toen19 + en2toen20).ToString();

            }
            Label FinalEn2 = (Label)(e.Row.FindControl("FinalEn2"));
            if (FinalEn2 != null)
            {
                FinalEn2.Text = (double.Parse(DataBinder.Eval(e.Row.DataItem, "EN01").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN02").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN03").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN04").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN05").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN06").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN07").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN08").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN09").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN10").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN11").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN12").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN13").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN14").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN15").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN16").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN17").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN18").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN19").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EN20").ToString())).ToString();
            }
        }
        
        decimal ex2toen1 = 0; decimal ex2toen2 = 0; decimal ex2toen3 = 0; decimal ex2toen4 = 0; decimal ex2toen5 = 0;
        decimal ex2toen6 = 0; decimal ex2toen7 = 0; decimal ex2toen8 = 0; decimal ex2toen9 = 0; decimal ex2toen10 = 0;
        decimal ex2toen11 = 0; decimal ex2toen12 = 0; decimal ex2toen13 = 0; decimal ex2toen14 = 0; decimal ex2toen15 = 0;
        decimal ex2toen16 = 0; decimal ex2toen17 = 0; decimal ex2toen18 = 0; decimal ex2toen19 = 0; decimal ex2toen20 = 0;
        protected void GridViewEx2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label NumEx2 = (Label)(e.Row.FindControl("NumEx2"));
            if (NumEx2 != null)
            {
                NumEx2.Text = (GridViewEx2.Rows.Count + 1).ToString() + ".";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ex2toen1 = ex2toen1 + Convert.ToDecimal(e.Row.Cells[2].Text); ex2toen2 = ex2toen2 + Convert.ToDecimal(e.Row.Cells[3].Text);
                ex2toen3 = ex2toen3 + Convert.ToDecimal(e.Row.Cells[4].Text); ex2toen4 = ex2toen4 + Convert.ToDecimal(e.Row.Cells[5].Text);
                ex2toen5 = ex2toen5 + Convert.ToDecimal(e.Row.Cells[6].Text); ex2toen6 = ex2toen6 + Convert.ToDecimal(e.Row.Cells[7].Text);
                ex2toen7 = ex2toen7 + Convert.ToDecimal(e.Row.Cells[8].Text); ex2toen8 = ex2toen8 + Convert.ToDecimal(e.Row.Cells[9].Text);
                ex2toen9 = ex2toen9 + Convert.ToDecimal(e.Row.Cells[10].Text); ex2toen10 = ex2toen10 + Convert.ToDecimal(e.Row.Cells[11].Text);
                ex2toen11 = ex2toen11 + Convert.ToDecimal(e.Row.Cells[12].Text); ex2toen12 = ex2toen12 + Convert.ToDecimal(e.Row.Cells[13].Text);
                ex2toen13 = ex2toen13 + Convert.ToDecimal(e.Row.Cells[14].Text); ex2toen14 = ex2toen14 + Convert.ToDecimal(e.Row.Cells[15].Text);
                ex2toen15 = ex2toen15 + Convert.ToDecimal(e.Row.Cells[16].Text); ex2toen16 = ex2toen16 + Convert.ToDecimal(e.Row.Cells[17].Text);
                ex2toen17 = ex2toen17 + Convert.ToDecimal(e.Row.Cells[18].Text); ex2toen18 = ex2toen18 + Convert.ToDecimal(e.Row.Cells[19].Text);
                ex2toen19 = ex2toen19 + Convert.ToDecimal(e.Row.Cells[20].Text); ex2toen20 = ex2toen20 + Convert.ToDecimal(e.Row.Cells[21].Text);
                e.Row.Cells[22].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[22].BackColor = System.Drawing.ColorTranslator.FromHtml("#0087a8");
                e.Row.Cells[22].ForeColor = System.Drawing.Color.White; e.Row.Cells[22].Font.Bold = true;
                e.Row.Cells[1].Font.Size = 15;

                if (e.Row.Cells[2].Text != "0") { e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[2].Font.Bold = true; }
                if (e.Row.Cells[3].Text != "0") { e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[3].Font.Bold = true; }
                if (e.Row.Cells[4].Text != "0") { e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[4].Font.Bold = true; }
                if (e.Row.Cells[5].Text != "0") { e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[5].Font.Bold = true; }
                if (e.Row.Cells[6].Text != "0") { e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[6].Font.Bold = true; }
                if (e.Row.Cells[7].Text != "0") { e.Row.Cells[7].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[7].Font.Bold = true; }
                if (e.Row.Cells[8].Text != "0") { e.Row.Cells[8].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[8].Font.Bold = true; }
                if (e.Row.Cells[9].Text != "0") { e.Row.Cells[9].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[9].Font.Bold = true; }
                if (e.Row.Cells[10].Text != "0") { e.Row.Cells[10].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[10].Font.Bold = true; }
                if (e.Row.Cells[11].Text != "0") { e.Row.Cells[11].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[11].Font.Bold = true; }
                if (e.Row.Cells[12].Text != "0") { e.Row.Cells[12].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[12].Font.Bold = true; }
                if (e.Row.Cells[13].Text != "0") { e.Row.Cells[13].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[13].Font.Bold = true; }
                if (e.Row.Cells[14].Text != "0") { e.Row.Cells[14].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[14].Font.Bold = true; }
                if (e.Row.Cells[15].Text != "0") { e.Row.Cells[15].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[15].Font.Bold = true; }
                if (e.Row.Cells[16].Text != "0") { e.Row.Cells[16].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[16].Font.Bold = true; }
                if (e.Row.Cells[17].Text != "0") { e.Row.Cells[17].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[17].Font.Bold = true; }
                if (e.Row.Cells[18].Text != "0") { e.Row.Cells[18].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[18].Font.Bold = true; }
                if (e.Row.Cells[19].Text != "0") { e.Row.Cells[19].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[19].Font.Bold = true; }
                if (e.Row.Cells[20].Text != "0") { e.Row.Cells[20].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[20].Font.Bold = true; }
                if (e.Row.Cells[21].Text != "0") { e.Row.Cells[21].BackColor = System.Drawing.ColorTranslator.FromHtml("#8cd1e2"); e.Row.Cells[21].Font.Bold = true; }

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "<b>รวม</b>";
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].Text = ex2toen1.ToString("0"); e.Row.Cells[3].Text = ex2toen2.ToString("0");
                e.Row.Cells[4].Text = ex2toen3.ToString("0"); e.Row.Cells[5].Text = ex2toen4.ToString("0"); e.Row.Cells[6].Text = ex2toen5.ToString("0");
                e.Row.Cells[7].Text = ex2toen6.ToString("0"); e.Row.Cells[8].Text = ex2toen7.ToString("0"); e.Row.Cells[9].Text = ex2toen8.ToString("0");
                e.Row.Cells[10].Text = ex2toen9.ToString("0"); e.Row.Cells[11].Text = ex2toen10.ToString("0"); e.Row.Cells[12].Text = ex2toen11.ToString("0");
                e.Row.Cells[13].Text = ex2toen12.ToString("0"); e.Row.Cells[14].Text = ex2toen13.ToString("0"); e.Row.Cells[15].Text = ex2toen14.ToString("0");
                e.Row.Cells[16].Text = ex2toen15.ToString("0"); e.Row.Cells[17].Text = ex2toen16.ToString("0"); e.Row.Cells[18].Text = ex2toen17.ToString("0");
                e.Row.Cells[19].Text = ex2toen18.ToString("0"); e.Row.Cells[20].Text = ex2toen19.ToString("0"); e.Row.Cells[21].Text = ex2toen20.ToString("0");
                e.Row.Cells[22].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[21].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[20].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[19].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[18].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[17].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[16].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[14].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[13].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[12].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[22].Text = (ex2toen1 + ex2toen2 + ex2toen3 + ex2toen4 + ex2toen5 + ex2toen6 + ex2toen7 + ex2toen8 + ex2toen9 + ex2toen10
                      + ex2toen11 + ex2toen12 + ex2toen13 + ex2toen14 + ex2toen15 + ex2toen16 + ex2toen17 + ex2toen18 + ex2toen19 + ex2toen20).ToString();
            }
            Label FinalEx2 = (Label)(e.Row.FindControl("FinalEx2"));
            if (FinalEx2 != null)
            {
                FinalEx2.Text = (double.Parse(DataBinder.Eval(e.Row.DataItem, "EX01").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX02").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX03").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX04").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX05").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX06").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX07").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX08").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX09").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX10").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX11").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX12").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX13").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX14").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX15").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX16").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX17").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX18").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX19").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX20").ToString())).ToString();
            }
        }
        
        decimal exAtoen1 = 0; decimal exAtoen2 = 0; decimal exAtoen3 = 0; decimal exAtoen4 = 0; decimal exAtoen5 = 0;
        decimal exAtoen6 = 0; decimal exAtoen7 = 0; decimal exAtoen8 = 0; decimal exAtoen9 = 0; decimal exAtoen10 = 0;
        decimal exAtoen11 = 0; decimal exAtoen12 = 0; decimal exAtoen13 = 0; decimal exAtoen14 = 0; decimal exAtoen15 = 0;
        decimal exAtoen16 = 0; decimal exAtoen17 = 0; decimal exAtoen18 = 0; decimal exAtoen19 = 0; decimal exAtoen20 = 0;
        protected void GridViewThingX_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label NumThingX = (Label)(e.Row.FindControl("NumThingX"));
            if (NumThingX != null)
            {
                NumThingX.Text = (GridViewThingX.Rows.Count + 1).ToString() + ".";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                exAtoen1 = exAtoen1 + Convert.ToDecimal(e.Row.Cells[2].Text); exAtoen2 = exAtoen2 + Convert.ToDecimal(e.Row.Cells[3].Text);
                exAtoen3 = exAtoen3 + Convert.ToDecimal(e.Row.Cells[4].Text); exAtoen4 = exAtoen4 + Convert.ToDecimal(e.Row.Cells[5].Text);
                exAtoen5 = exAtoen5 + Convert.ToDecimal(e.Row.Cells[6].Text); exAtoen6 = exAtoen6 + Convert.ToDecimal(e.Row.Cells[7].Text);
                exAtoen7 = exAtoen7 + Convert.ToDecimal(e.Row.Cells[8].Text); exAtoen8 = exAtoen8 + Convert.ToDecimal(e.Row.Cells[9].Text);
                exAtoen9 = exAtoen9 + Convert.ToDecimal(e.Row.Cells[10].Text); exAtoen10 = exAtoen10 + Convert.ToDecimal(e.Row.Cells[11].Text);
                exAtoen11 = exAtoen11 + Convert.ToDecimal(e.Row.Cells[12].Text); exAtoen12 = exAtoen12 + Convert.ToDecimal(e.Row.Cells[13].Text);
                exAtoen13 = exAtoen13 + Convert.ToDecimal(e.Row.Cells[14].Text); exAtoen14 = exAtoen14 + Convert.ToDecimal(e.Row.Cells[15].Text);
                exAtoen15 = exAtoen15 + Convert.ToDecimal(e.Row.Cells[16].Text); exAtoen16 = exAtoen16 + Convert.ToDecimal(e.Row.Cells[17].Text);
                exAtoen17 = exAtoen17 + Convert.ToDecimal(e.Row.Cells[18].Text); exAtoen18 = exAtoen18 + Convert.ToDecimal(e.Row.Cells[19].Text);
                exAtoen19 = exAtoen19 + Convert.ToDecimal(e.Row.Cells[20].Text); exAtoen20 = exAtoen20 + Convert.ToDecimal(e.Row.Cells[21].Text);
                e.Row.Cells[22].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[22].BackColor = System.Drawing.ColorTranslator.FromHtml("#19931f");
                e.Row.Cells[22].ForeColor = System.Drawing.Color.White; e.Row.Cells[22].Font.Bold = true;
                e.Row.Cells[1].Font.Size = 15;


                if (e.Row.Cells[2].Text != "0") { e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[2].Font.Bold = true; }
                if (e.Row.Cells[3].Text != "0") { e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[3].Font.Bold = true; }
                if (e.Row.Cells[4].Text != "0") { e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[4].Font.Bold = true; }
                if (e.Row.Cells[5].Text != "0") { e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[5].Font.Bold = true; }
                if (e.Row.Cells[6].Text != "0") { e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[6].Font.Bold = true; }
                if (e.Row.Cells[7].Text != "0") { e.Row.Cells[7].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[7].Font.Bold = true; }
                if (e.Row.Cells[8].Text != "0") { e.Row.Cells[8].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[8].Font.Bold = true; }
                if (e.Row.Cells[9].Text != "0") { e.Row.Cells[9].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[9].Font.Bold = true; }
                if (e.Row.Cells[10].Text != "0") { e.Row.Cells[10].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[10].Font.Bold = true; }
                if (e.Row.Cells[11].Text != "0") { e.Row.Cells[11].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[11].Font.Bold = true; }
                if (e.Row.Cells[12].Text != "0") { e.Row.Cells[12].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[12].Font.Bold = true; }
                if (e.Row.Cells[13].Text != "0") { e.Row.Cells[13].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[13].Font.Bold = true; }
                if (e.Row.Cells[14].Text != "0") { e.Row.Cells[14].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[14].Font.Bold = true; }
                if (e.Row.Cells[15].Text != "0") { e.Row.Cells[15].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[15].Font.Bold = true; }
                if (e.Row.Cells[16].Text != "0") { e.Row.Cells[16].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[16].Font.Bold = true; }
                if (e.Row.Cells[17].Text != "0") { e.Row.Cells[17].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[17].Font.Bold = true; }
                if (e.Row.Cells[18].Text != "0") { e.Row.Cells[18].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[18].Font.Bold = true; }
                if (e.Row.Cells[19].Text != "0") { e.Row.Cells[19].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[19].Font.Bold = true; }
                if (e.Row.Cells[20].Text != "0") { e.Row.Cells[20].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[20].Font.Bold = true; }
                if (e.Row.Cells[21].Text != "0") { e.Row.Cells[21].BackColor = System.Drawing.ColorTranslator.FromHtml("#b0fcb9"); e.Row.Cells[21].Font.Bold = true; }


            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "<b>รวม</b>";
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].Text = exAtoen1.ToString("0"); e.Row.Cells[3].Text = exAtoen2.ToString("0");
                e.Row.Cells[4].Text = exAtoen3.ToString("0"); e.Row.Cells[5].Text = exAtoen4.ToString("0"); e.Row.Cells[6].Text = exAtoen5.ToString("0");
                e.Row.Cells[7].Text = exAtoen6.ToString("0"); e.Row.Cells[8].Text = exAtoen7.ToString("0"); e.Row.Cells[9].Text = exAtoen8.ToString("0");
                e.Row.Cells[10].Text = exAtoen9.ToString("0"); e.Row.Cells[11].Text = exAtoen10.ToString("0"); e.Row.Cells[12].Text = exAtoen11.ToString("0");
                e.Row.Cells[13].Text = exAtoen12.ToString("0"); e.Row.Cells[14].Text = exAtoen13.ToString("0"); e.Row.Cells[15].Text = exAtoen14.ToString("0");
                e.Row.Cells[16].Text = exAtoen15.ToString("0"); e.Row.Cells[17].Text = exAtoen16.ToString("0"); e.Row.Cells[18].Text = exAtoen17.ToString("0");
                e.Row.Cells[19].Text = exAtoen18.ToString("0"); e.Row.Cells[20].Text = exAtoen19.ToString("0"); e.Row.Cells[21].Text = exAtoen20.ToString("0");
                e.Row.Cells[22].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[21].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[20].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[19].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[18].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[17].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[16].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[14].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[13].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[12].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center; e.Row.Cells[22].Text = (exAtoen1 + exAtoen2 + exAtoen3 + exAtoen4 + exAtoen5 + exAtoen6 + exAtoen7 + exAtoen8 + exAtoen9 + exAtoen10
                     + exAtoen11 + exAtoen12 + exAtoen13 + exAtoen14 + exAtoen15 + exAtoen16 + exAtoen17 + exAtoen18 + exAtoen19 + exAtoen20).ToString();

            }
            Label FinalEx1 = (Label)(e.Row.FindControl("FinalEx1"));
            if (FinalEx1 != null)
            {
                FinalEx1.Text = (double.Parse(DataBinder.Eval(e.Row.DataItem, "EX01").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX02").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX03").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX04").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX05").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX06").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX07").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX08").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX09").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX10").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX11").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX12").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX13").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX14").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX15").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX16").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX17").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX18").ToString())
                    + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX19").ToString()) + double.Parse(DataBinder.Eval(e.Row.DataItem, "EX20").ToString())).ToString();
            }

        }

        protected void GridViewThingX_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnNewSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ReportView/Default.aspx");
            btnNewSearch.Visible = false;
        }
        protected void ShowAnnex()
        {
            string annexx = "";
            if (txtStation.SelectedValue == "701")
            {
                annexx += "SELECT * FROM tbl_annex  ORDER BY Annex_id ASC";
                divAnexx.Visible = false;
            }
            else if(txtStation.SelectedValue == "702")
            {
                annexx += " SELECT * FROM tbl_annex  ORDER BY Annex_id ASC";
                divAnexx.Visible = false;
            }
            else if (txtStation.SelectedValue == "703")
            {
                annexx += " SELECT * FROM tbl_annex WHERE Annex_id <= 3 ORDER BY Annex_id ASC";
                function.getListItem(ddlAnexSta, annexx, "Annex_name", "Annex_id");
                ddlAnexSta.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                divAnexx.Visible = true;
            }
            else if (txtStation.SelectedValue == "704")
            {
                annexx += " SELECT * FROM tbl_annex WHERE Annex_id <= 2 ORDER BY Annex_id ASC";
                function.getListItem(ddlAnexSta, annexx, "Annex_name", "Annex_id");
                ddlAnexSta.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                divAnexx.Visible = true;
            }
            else if (txtStation.SelectedValue == "706")
            {
                annexx += " SELECT * FROM tbl_annex WHERE Annex_id <= 2 ORDER BY Annex_id ASC";
                function.getListItem(ddlAnexSta, annexx, "Annex_name", "Annex_id");
                ddlAnexSta.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                divAnexx.Visible = true;
            }
            else if (txtStation.SelectedValue == "707")
            {
                annexx += " SELECT * FROM tbl_annex WHERE Annex_id <= 4 ORDER BY Annex_id ASC";
                function.getListItem(ddlAnexSta, annexx, "Annex_name", "Annex_id");
                ddlAnexSta.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                divAnexx.Visible = true;
            }
            else if (txtStation.SelectedValue == "708")
            {
                annexx += " SELECT * FROM tbl_annex WHERE Annex_id <= 6 ORDER BY Annex_id ASC";
                function.getListItem(ddlAnexSta, annexx, "Annex_name", "Annex_id");
                ddlAnexSta.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                divAnexx.Visible = true;
            }
            else if (txtStation.SelectedValue == "709")
            {
                annexx += " SELECT * FROM tbl_annex WHERE Annex_id <= 4 ORDER BY Annex_id ASC";
                function.getListItem(ddlAnexSta, annexx, "Annex_name", "Annex_id");
                ddlAnexSta.Items.Insert(0, new ListItem("ทั้งหมด", ""));
                divAnexx.Visible = true;
            }
            else if (txtStation.SelectedValue == "710")
            {
                annexx += " SELECT * FROM tbl_annex  ORDER BY Annex_id ASC";
                divAnexx.Visible = false;
            }
            else if (txtStation.SelectedValue == "902")
            {
                annexx += " SELECT * FROM tbl_annex  ORDER BY Annex_id ASC";
                divAnexx.Visible = false;
            }
            else if (txtStation.SelectedValue == "903")
            {
                annexx += " SELECT * FROM tbl_annex  ORDER BY Annex_id ASC";
                divAnexx.Visible = false;
            }
            else if (txtStation.SelectedValue == "904")
            {
                annexx += " SELECT * FROM tbl_annex  ORDER BY Annex_id ASC";
                divAnexx.Visible = false;
            }
            else if (txtStation.SelectedValue == "905")
            {
                annexx += " SELECT * FROM tbl_annex  ORDER BY Annex_id ASC";
                divAnexx.Visible = false;
            }

        }

        protected void txtStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowAnnex();
        }
    }
}