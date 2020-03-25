using ClaimProject.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimProject.CM
{
    public partial class DefaultCM : System.Web.UI.Page
    {
        ClaimFunction function = new ClaimFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["user"] == null)
            {
                Response.Redirect("/");
            }
            if (!this.IsPostBack)
            {
               /* string actYear = "";
                string actMonth = "";
                string TimeToChangeStat = "";
                if (DateTime.Today.Month.ToString() == "1")
                {
                    actYear = (int.Parse(DateTime.Today.Year.ToString()) + 542).ToString();
                    actMonth = "12";
                    TimeToChangeStat = "01-" + actMonth + "-" + actYear;
                }
                else
                {
                    actYear = (int.Parse(DateTime.Today.Year.ToString()) + 543).ToString();
                    actMonth = (int.Parse(DateTime.Today.Month.ToString()) - 1).ToString();
                    TimeToChangeStat = "01-" + actMonth + "-" + actYear;
                }

                string UpdatePMSQL = "UPDATE tbl_pm_detail c SET pm_status_id = '5' "
                                + " WHERE c.pm_status_id = '1' AND STR_TO_DATE(SUBSTR(c.pm_contract_date,4,7),'%m-%Y') "
                                + " BETWEEN STR_TO_DATE(SUBSTR('"+TimeToChangeStat+"',4,7),'%m-%Y') AND STR_TO_DATE(SUBSTR('"+TimeToChangeStat+"',4,7),'%m-%Y') ";
                function.MySqlQuery(UpdatePMSQL);*/
            }

            if (function.CheckLevel("Department", Session["UserPrivilegeId"].ToString()))
            {
                Div6.Visible = true; 

            }
            else
            {
                Div6.Visible = false;
                divpm.Visible = false;
                divpm2.Visible = false;
                Div3.Visible = false;
                //Div2.Visible = false;
            }

            

        }
    }
}