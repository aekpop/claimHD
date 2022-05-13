using MySql.Data.MySqlClient;
using System;
using System.Text;
using System.Windows.Forms;

namespace TIS
{
    class AdminScript
    {
        ConnectDB dbcon = new ConnectDB();
        Script script = new Script();
        //public string strCon = "server=localhost;database=tis_main;uid=admintis;pwd=admin25;charset=utf8;";//test
       public string strCon = "server=192.168.101.91;database=tis_main;uid=admintis;pwd=admin25;charset=utf8;";
       //public string strCon = "server=10.6.3.201;database=tis_main;uid=admintis;pwd=admin25;charset=utf8;";
        public MySqlConnection conn = null;
        public MySqlConnection getConn(string checkPoint, GroupBox cpoint)
        {
            try
            {
                string strConn = "SELECT * FROM tbl_cpoint WHERE tbl_cpoint_id = '" + checkPoint + "'";
                MySqlDataReader rs = script.Select_SQL(strConn);
                if (rs.Read())
                {
                    //MessageBox.Show(strConn);
                    string conn = "server=" + rs.GetString("tbl_cpoint_host") + ";database=" + rs.GetString("tbl_cpoint_database") + ";uid=" + rs.GetString("tbl_cpoint_user") + ";pwd=" + rs.GetString("tbl_cpoint_pass") + ";charset=utf8;";
                    cpoint.Text = "รายการ ด่านฯ" + rs.GetString("tbl_cpoint_name");
                    return new MySqlConnection(conn);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                MessageBox.Show("ไม่พบข้อมูล");
                return null;
            }

        }

        public MySqlConnection getConn(string checkPoint)
        {
            try
            {
                string strConn = "SELECT * FROM tbl_cpoint WHERE tbl_cpoint_id = '" + checkPoint + "'";
                MySqlDataReader rs = script.Select_SQL(strConn);
                if (rs.Read())
                {
                    //MessageBox.Show(strConn);
                    string conn = "server=" + rs.GetString("tbl_cpoint_host") + ";database=" + rs.GetString("tbl_cpoint_database") + ";uid=" + rs.GetString("tbl_cpoint_user") + ";pwd=" + rs.GetString("tbl_cpoint_pass") + ";charset=utf8;";
                    rs.Close();
                    script.conn.Close();
                    return new MySqlConnection(conn);
                }
                else
                {
                    rs.Close();
                    script.conn.Close();
                    return null;
                }
            }
            catch
            {
                MessageBox.Show("ไม่พบข้อมูล");
                script.conn.Close();
                return null;
            }

        }
        public void CloseCon()
        {
            try
            {
                conn.Close();
            }
            catch { }
        }
        public MySqlDataReader Select_SQL(string sql, MySqlConnection conn)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Close();
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                //conn.Close();
                return reader;
            }
            catch
            {
                MessageBox.Show("มีปัญหาการเชื่อมต่อฐานข้อมูล");
                conn.Close();
            }
            return null;
        }

        public MySqlDataAdapter Select_SQLDataAdapter(string sql, MySqlConnection conn)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Close();
                conn.Open();
                MySqlDataAdapter reader = new MySqlDataAdapter(cmd);
                conn.Close();
                return reader;
            }
            catch(Exception e)
            {
                MessageBox.Show("มีปัญหาการเชื่อมต่อฐานข้อมูล"+e.ToString());
                conn.Close();
            }
            return null;
        }

        public MySqlDataReader Select_SQL(string sql)
        {
            conn = new MySqlConnection(strCon);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Close();
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                //conn.Close();
                return reader;
            }
            catch { conn.Close(); }
            return null;
        }

        public bool InsertUpdae_SQL(string sql, MySqlConnection conn)
        {
            //conn.Close();
            
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = sql;
            try
            {
                conn.Open();
                if (comm.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    //MessageBox.Show("มีปัญหาการเชื่อมต่อ");
                    conn.Close();
                    return false;
                }
            }
            catch
            {
                conn.Close();
                MessageBox.Show("มีปัญหาในการเชื่อมต่อฐานข้อมูล");
                return false;
            }
        }

        public bool InsertUpdae_SQL(string sql)
        {
            conn = new MySqlConnection(strCon);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = sql;
            try
            {
                if (comm.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    //MessageBox.Show("มีปัญหาการเชื่อมต่อ");
                    conn.Close();
                    return false;
                }
            }
            catch
            {
                conn.Close();
                MessageBox.Show("มีปัญหาในการเชื่อมต่อฐานข้อมูล");
                return false;
            }
        }

        public string RandomString(int Size)
        {
            string input = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < Size; i++)
            {
                ch = input[random.Next(0, input.Length)];
                builder.Append(ch);
            }
            return builder.ToString();
        }

        public MySqlDataReader GetCodeEdit(string sql)
        {
            conn = new MySqlConnection(strCon);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Close();
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                //conn.Close();
                return reader;
            }
            catch { conn.Close(); }
            return null;
        }

        public bool InsertUpdaeCodeEdit(string sql)
        {
            conn = new MySqlConnection(strCon);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = sql;
            try
            {
                if (comm.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    //MessageBox.Show("มีปัญหาการเชื่อมต่อ");
                    conn.Close();
                    return false;
                }
            }
            catch
            {
                conn.Close();
                MessageBox.Show("มีปัญหาในการเชื่อมต่อฐานข้อมูล");
                return false;
            }
        }


    }
}
