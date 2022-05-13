using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TIS
{
    class ConnectDB
    {
        public string context()
        {
            string file_con = "conf.setting";
            FileInfo DirInfo = new FileInfo(file_con);
            string text = "";
            if (DirInfo.Exists)
            {
                //MySqlConnection conn = new MySqlConnection();
                text = File.ReadAllText(@file_con);
                //conn = new MySqlConnection(context);
            }
            return text;
        }
    }
}
