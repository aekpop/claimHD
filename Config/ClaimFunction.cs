﻿using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;

namespace ClaimProject.Config
{
    public class ClaimFunction
    {

        //ClaimConnection conn = new ClaimConnection();
        public MySqlConnection conn;
        //charset=tis620
        string strConnString = "Server=10.6.3.201;User Id=adminclaim; Password=admin25;charset=utf8; Database=db_claim; Pooling=false"; //main server
        //string strConnString = "Server=10.6.3.202;User Id=adminclaim; Password=admin25;charset=utf8; Database=db_claim; Pooling=false"; //database server
        //string strConnString = "Server=192.168.101.91;User Id=adminclaim; Password=admin25;charset=utf8; Database=db_claim; Pooling=false";
        //string strConnString = "Server=localhost;User Id=root; Password=admin25;charset=utf8; Database=db_claim; Pooling=false";
        public string icons = "";
        public string alerts = "";
        public string alertTypes = "";
        public string messageLine = "";

        internal void getListItem(HtmlGenericControl ddlCMBudget, string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
         
        public void getListItem(DropDownList list, string sql, string text, string value)
        {
            using (var reader = MySqlSelect(sql))
            {
                if (reader.HasRows)
                {
                    list.DataSource = reader;
                    list.DataValueField = value;
                    list.DataTextField = text;
                    list.DataBind();
                }
                reader.Close();
                conn.Close();
            }
        }

        public void Close()
        {
            conn.Close();
        }

        public string GetLevel(int level)
        {
            string[] readText = File.ReadAllLines(HostingEnvironment.MapPath("/Config/") + "LevelList.txt");
            foreach (string s in readText)
            {
                if (int.Parse(s.Split(',')[0]) == level) { return s.Split(',')[1]; }
            }
            return "";
        }

        public void GetListLevel(DropDownList list, int level)
        {
            string[] readText = File.ReadAllLines(HostingEnvironment.MapPath("/Config/") + "LevelList.txt");
            foreach (string s in readText)
            {
                if (level == 0)
                {
                    list.Items.Add(new ListItem(s.Split(',')[1], s.Split(',')[0]));
                }
                else
                {
                    if (s.Split(',')[0] != "0")
                    {
                        list.Items.Add(new ListItem(s.Split(',')[1], s.Split(',')[0]));
                    }
                }

            }
        }
         public MySqlDataReader MySqlSelect(string sql)
         {
             conn = new MySqlConnection(strConnString);
             MySqlCommand cmd = conn.CreateCommand();
             cmd.CommandText = sql;
             conn.Open();
             MySqlDataReader result = cmd.ExecuteReader();
             return result;
         }

        public DataTable MySqlSelectDataTable(string sql)
        {
            conn = new MySqlConnection(strConnString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable GetTable(string query)
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand(query);

            conn = new MySqlConnection(strConnString);
            conn.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            conn.Close();
            return dt;

        }

        public MySqlDataAdapter MySqlSelectDataSet(string sql)
        {
            conn = new MySqlConnection(strConnString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            try
            {
                //Conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                conn.Close();
                return da;
            }
            catch 
            {
                conn.Close();
                return null;
            }
        }

        public bool MySqlQuery(string sql)
        {
            conn = new MySqlConnection(strConnString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch
            {
                conn.Close();
                return false;
            }
        }

        public string ConvertDateShortThai(string dateThai)
        {
            try
            {
                string[] subDate = dateThai.Split('-');
                switch (subDate[1])
                {
                    case "01":
                        subDate[1] = "ม.ค.";
                        break;
                    case "02":
                        subDate[1] = "ก.พ.";
                        break;
                    case "03":
                        subDate[1] = "มี.ค.";
                        break;
                    case "04":
                        subDate[1] = "เม.ย.";
                        break;
                    case "05":
                        subDate[1] = "พ.ค.";
                        break;
                    case "06":
                        subDate[1] = "มิ.ย.";
                        break;
                    case "07":
                        subDate[1] = "ก.ค.";
                        break;
                    case "08":
                        subDate[1] = "ส.ค.";
                        break;
                    case "09":
                        subDate[1] = "ก.ย.";
                        break;
                    case "10":
                        subDate[1] = "ต.ค.";
                        break;
                    case "11":
                        subDate[1] = "พ.ย.";
                        break;
                    case "12":
                        subDate[1] = "ธ.ค.";
                        break;
                    case "00":
                        return "ปัจจุบัน";
                }
                return int.Parse(subDate[0]) + " " + subDate[1] + " " + subDate[2].Substring(2,2);
            }
            catch
            {
                return "";
            }
        }

        public string ConvertDatelongThai(string dateThai)
        {
            try
            {
                string[] subDate = dateThai.Split('-');
                switch (subDate[1])
                {
                    case "01":
                        subDate[1] = "มกราคม";
                        break;
                    case "02":
                        subDate[1] = "กุมภาพันธ์";
                        break;
                    case "03":
                        subDate[1] = "มีนาคม";
                        break;
                    case "04":
                        subDate[1] = "เมษายน";
                        break;
                    case "05":
                        subDate[1] = "พฤษภาคม";
                        break;
                    case "06":
                        subDate[1] = "มิถุนายน";
                        break;
                    case "07":
                        subDate[1] = "กรกฎาคม";
                        break;
                    case "08":
                        subDate[1] = "สิงหาคม";
                        break;
                    case "09":
                        subDate[1] = "กันยายน";
                        break;
                    case "10":
                        subDate[1] = "ตุลาคม";
                        break;
                    case "11":
                        subDate[1] = "พฤศจิกายน";
                        break;
                    case "12":
                        subDate[1] = "ธันวาคม";
                        break;
                    case "00":
                        return "ปัจจุบัน";
                }
                return int.Parse(subDate[0]) + " " + subDate[1] + " " + subDate[2];
            }
            catch
            {
                return "";
            }
        }

        public string ShortText(string text)
        {
            string textShort = "";
            if (text.Length > 50)
            {
                textShort = text.Substring(0, 47) + "...";
            }
            else
            {
                textShort = text;
            }

            return textShort;
        }
        public string ShortTextCom(string text)
        {
            string textShort = "";
            if (text.Length > 36)
            {
                textShort = text.Substring(0, 33) + "...";
            }
            else
            {
                textShort = text;
            }

            return textShort;
        }

        public string GetSelectValue(string table, string condition, string value)
        {
            string sql = "select * from " + table + " where " + condition;
            string values = "";
            MySqlDataReader rs = MySqlSelect(sql);
            if (rs.Read())
            {
                values = rs.GetString(value);
            }
            rs.Close();
            conn.Close();
            return values;
        }

        public void GetList(DropDownList list, string txtlist)
        {
            string[] readText = File.ReadAllLines(HostingEnvironment.MapPath("/Config/") + txtlist + ".txt");
            foreach (string s in readText)
            {
                list.Items.Add(new ListItem(s.Trim(), s.Trim()));
            }
        }
        public string GenAddNewEQPK(int cpoint)
        {
            string pk = cpoint.ToString();
            long code = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss")) + new Random().Next(100000000, 999999999);
            while (code.ToString().Length > 10)
            {
                code = code / cpoint;
            }

            if (code.ToString().Length != 10)
            {
                switch (code.ToString().Length)
                {
                    case 1:
                        code = long.Parse(code.ToString() + new Random().Next(100000000, 999999999));
                        break;
                    case 2:
                        code = long.Parse(code.ToString() + new Random().Next(10000000, 99999999));
                        break;
                    case 3:
                        code = long.Parse(code.ToString() + new Random().Next(1000000, 9999999));
                        break;
                    case 4:
                        code = long.Parse(code.ToString() + new Random().Next(100000, 999999));
                        break;
                    case 5:
                        code = long.Parse(code.ToString() + new Random().Next(10000, 99999));
                        break;
                    case 6:
                        code = long.Parse(code.ToString() + new Random().Next(1000, 9999));
                        break;
                    case 7:
                        code = long.Parse(code.ToString() + new Random().Next(100, 999));
                        break;
                    case 8:
                        code = long.Parse(code.ToString() + new Random().Next(10, 99));
                        break;
                    case 9:
                        code = long.Parse(code.ToString() + new Random().Next(1, 9));
                        break;
                }
            }
            pk += code.ToString();
            int codeSub = 0;
            for (int i = 0; i < pk.Length; i++)
            {
                codeSub = codeSub + int.Parse(pk.Substring(i, 1));
            }
            try
            {
                pk += codeSub.ToString().Substring(0, 2);
            }
            catch
            {
                pk += new Random().Next(10, 99);
            }

            string sql = "";
            sql = "SELECT NewEQ_id FROM tbl_newequipment WHERE NewEQ_id = '" + pk + "'";

            while (MySqlSelect(sql).Read())
            {
                return "";
            }
            conn.Close();
            return pk;
        }

        public string GenTransferPK(int cpoint)
        {
            string pk = cpoint.ToString();
            long code = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss")) + new Random().Next(100000000, 999999999);
            while (code.ToString().Length > 10)
            {
                code = code / cpoint;
            }
            
            if (code.ToString().Length != 10)
            {
                switch (code.ToString().Length)
                {
                    case 1:
                        code = long.Parse(code.ToString() + new Random().Next(100000000, 999999999));
                        break;
                    case 2:
                        code = long.Parse(code.ToString() + new Random().Next(10000000, 99999999));
                        break;
                    case 3:
                        code = long.Parse(code.ToString() + new Random().Next(1000000, 9999999));
                        break;
                    case 4:
                        code = long.Parse(code.ToString() + new Random().Next(100000, 999999));
                        break;
                    case 5:
                        code = long.Parse(code.ToString() + new Random().Next(10000, 99999));
                        break;
                    case 6:
                        code = long.Parse(code.ToString() + new Random().Next(1000, 9999));
                        break;
                    case 7:
                        code = long.Parse(code.ToString() + new Random().Next(100, 999));
                        break;
                    case 8:
                        code = long.Parse(code.ToString() + new Random().Next(10, 99));
                        break;
                    case 9:
                        code = long.Parse(code.ToString() + new Random().Next(1, 9));
                        break;
                }
            }
            pk += code.ToString();
            int codeSub = 0;
            for (int i = 0; i < pk.Length; i++)
            {
                codeSub = codeSub + int.Parse(pk.Substring(i, 1));
            }
            try
            {
                pk += codeSub.ToString().Substring(0, 2);
            }
            catch
            {
                pk += new Random().Next(10, 99);
            }

            string sql = "";
            sql = "SELECT trans_act_id FROM tbl_transfer_action WHERE trans_act_id = '" + pk + "'";

            while (MySqlSelect(sql).Read())
            {
                return "";
            }
            conn.Close();
            return pk;
        }

        public string GeneratorPK(int cpoint)
        {
            string pk = cpoint.ToString();
            long code = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss")) + new Random().Next(100000000, 999999999);
            while (code.ToString().Length > 10)
            {
                code = code / cpoint;
            }

            if (code.ToString().Length != 10)
            {
                switch (code.ToString().Length)
                {
                    case 1:
                        code = long.Parse(code.ToString() + new Random().Next(100000000, 999999999));
                        break;
                    case 2:
                        code = long.Parse(code.ToString() + new Random().Next(10000000, 99999999));
                        break;
                    case 3:
                        code = long.Parse(code.ToString() + new Random().Next(1000000, 9999999));
                        break;
                    case 4:
                        code = long.Parse(code.ToString() + new Random().Next(100000, 999999));
                        break;
                    case 5:
                        code = long.Parse(code.ToString() + new Random().Next(10000, 99999));
                        break;
                    case 6:
                        code = long.Parse(code.ToString() + new Random().Next(1000, 9999));
                        break;
                    case 7:
                        code = long.Parse(code.ToString() + new Random().Next(100, 999));
                        break;
                    case 8:
                        code = long.Parse(code.ToString() + new Random().Next(10, 99));
                        break;
                    case 9:
                        code = long.Parse(code.ToString() + new Random().Next(1, 9));
                        break;
                }
            }
            pk += code.ToString();
            int codeSub = 0;
            for (int i = 0; i < pk.Length; i++)
            {
                codeSub = codeSub + int.Parse(pk.Substring(i, 1));
            }
            try
            {
                pk += codeSub.ToString().Substring(0, 2);
            }
            catch
            {
                pk += new Random().Next(10, 99);
            }

            string sql = "";
            sql = "SELECT claim_id FROM tbl_claim WHERE claim_id = '" + pk + "'";

            while (MySqlSelect(sql).Read())
            {
                return "";
            }
            conn.Close();
            return pk;
        }

        public string getMd5Hash(string input)
        { // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create(); // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes // and create a string.
            StringBuilder sBuilder = new StringBuilder(); // Loop through each byte of the hashed data // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public DateTime ConvertDateTime(string date)
        {
            string[] dSplit = date.Split('-');
            DateTime dateTime = DateTime.ParseExact(dSplit[0] + "-" + dSplit[1] + "-" + (int.Parse(dSplit[2]) - 543), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            return dateTime;
        }
        public DateTime ConvertDateTimeEB(string date)
        {
            string[] dSplit = date.Split('-');
            DateTime dateTime = DateTime.ParseExact(dSplit[0] + "-" + dSplit[1] + "-" + (int.Parse(dSplit[2]) + 543), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            return dateTime;
        }

        public string ConvertDateTime(string date, int addDay)
        {
            string[] dSplit = date.Split('-');
            DateTime dateTime = DateTime.ParseExact(dSplit[0] + "-" + dSplit[1] + "-" + (int.Parse(dSplit[2]) - 543), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            return dateTime.AddDays(addDay).ToString("dd-MM") + "-" + (dateTime.AddDays(addDay).Year + 543);
        }

        public string getBudgetYear(string date) //14-10-2562
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
          //  string chk = (Int32.Parse(dateTime.Year)).ToString();
            if (dateTime.Month < 10)
            {
                return (dateTime.Year).ToString();
            }
            else
            {
                return (dateTime.Year + 1).ToString();
            }
        }

        public bool CheckLevel(string allow, string level)
        {
            switch (allow)
            {
                case "Department":
                    if (level == "0" || level == "1" || level == "4" || level == "5")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "Techno":
                    if (level == "0" || level == "1")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "Admin":
                    if (level == "0")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default: return false;
            }
        }
        public void Set_Max_Connection()
        {
            try
            {
                string sql = "SET global max_connections = 1000000";
                conn = new MySqlConnection(strConnString);
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = sql;
                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch { conn.Close(); }
        }

        public string GetStatusCM(string status)
        {
            switch (status)
            {
                case "0": return "รอการแก้ไข"; 
                case "1": return "รอการตรวจสอบ"; 
                case "2": return "ใช้งานได้ปกติ";
                case "3": return "แก้ไขเบื้องต้น";
                case "9": return "ลบแล้ว";
                default: return "";
            }
        }
        /*public void MessageLine(string token, string msg)
        {
            // https://notify-bot.line.me/my/ เข้าเว็บ
            var request = (HttpWebRequest)WebRequest.Create("https://notify-api.line.me/api/notify");
            var postData = string.Format("message={0}", msg);
            var data = Encoding.UTF8.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            request.Headers.Add("Authorization", "Bearer " + token);

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        }*/

        public class StatCM
        {            
            public int cm_cpoint { get; set; }
            public int cm_point { get; set; }
            public int cm_budget { get; set; }
            public int cm_detail_status_id { get; set; }
            public int cm_detail_driver_id { get; set; }
        }

        public static String GetIP()
        {
            String ip =
                HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return ip;
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
        public void GetListQuantations(DropDownList list, int level)
        {
            string[] readText = File.ReadAllLines(HostingEnvironment.MapPath("/Config/") + "Quantation.txt");
            foreach (string s in readText)
            {
                if (level == 0)
                {
                    list.Items.Add(new ListItem(s.Split(',')[1], s.Split(',')[0]));
                }
                else
                {
                    if (s.Split(',')[0] != "0")
                    {
                        list.Items.Add(new ListItem(s.Split(',')[1], s.Split(',')[0]));
                    }
                }

            }
        }

        public class DataPoint
        {
            public DataPoint(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }

            //Explicitly setting the name to be used while serializing to JSON.
            [DataMember(Name = "x")]
            public Nullable<double> X = null;

            //Explicitly setting the name to be used while serializing to JSON.
            [DataMember(Name = "y")]
            public Nullable<double> Y = null;
        }

        public void LineNotify(string lineToken, string message, string pictureUrl, int stickerPackageID, int stickerID)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("https://notify-api.line.me/api/notify");
                var postData = string.Format("message={0}", message);
                var data = Encoding.UTF8.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.Headers.Add("Authorization", "Bearer " + lineToken);

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                //using (var stream = request.GetRequestStream()) stream.Write(data, 0, data.Length);

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void LineTran(string sysname, string messageLine)
        {
            string token = "";
            string sqlLine = "SELECT * FROM tbl_token WHERE Sys_name = '" + sysname + "' ";

            MySqlDataReader da = MySqlSelect(sqlLine);
            if (da.Read())
            {
                token = da.GetString("token");
            }

            if (messageLine != "")
            {
                SreviceLine.WebService_Server serviceLine = new SreviceLine.WebService_Server();
                try
                {
                    serviceLine.MessageToServer(token, messageLine, "", 1, 41);
                    messageLine = "";
                }
                catch (Exception)
                {

                }

            }
        }
    }
}