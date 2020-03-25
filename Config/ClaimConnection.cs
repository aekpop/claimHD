using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ClaimProject.Config
{
    public class ClaimConnection
    {
        private MySqlConnection conn;

        public MySqlConnection Conn { get => conn; set => conn = value; }

        //charset=tis620 claimtwo
        string strConnString = "Server=10.6.3.201;User Id=adminclaim; Password=admin25;charset=utf8; Database=db_claim; Pooling=false";
        //string strConnString = "Server=10.6.3.201;User Id=claimtwo; Password=123456789;charset=utf8; Database=db_claim; Pooling=false";
        //string strConnString = "Server=10.6.3.213;User Id=heaven; Password=admin1234;charset=utf8; Database=db_claim; Pooling=false";  
        //string strConnString = "Server=localhost;User Id=root; Password=admin25;charset=utf8; Database=db_claim; Pooling=false";  //Test

        public ClaimConnection()
        {
            Conn = new MySqlConnection(strConnString);
        }

        public void Open()
        {
            
            if (Conn != null && Conn.State == ConnectionState.Closed)//to check if conn is already open or not
            {
                Conn.Open();
            }
            else
            {
                Conn.Close();
                conn.Close();
                Conn.Open();
            }
        }

        public void Close()
        {
            Conn.Close();
            conn.Close();
        }
    }

}