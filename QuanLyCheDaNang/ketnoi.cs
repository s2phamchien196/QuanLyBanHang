using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace QuanLyCheDaNang
{
   
    class ketnoi
    {

      public static SqlConnection con = new SqlConnection(@"Data Source=TULAISME-PC\SQLEXPRESS;Initial Catalog=QuanLyCheDaNang;Integrated Security=True");
        //public static SqlConnection con = new SqlConnection(@"Data Source=MINHCHIEN\SQLEXPRESS;Initial Catalog=QuanlyCheDaNang;Integrated Security=True");
        //public static SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\QuanlyCheDaNang.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        
        public static SqlCommand Cmdsql;
        public static void connect()
        {
            if(con.State == System.Data.ConnectionState.Closed)
                con.Open();
        }
        public static void disconnect()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
        }
        public static void truyvan(string sql)
        {
            Cmdsql = new SqlCommand(sql, con);
        }
    }
}
