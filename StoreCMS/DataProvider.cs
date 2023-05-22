using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace StoreCMS
{
    static class DataProvider
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["stringConnect"].ConnectionString.ToString();
        public static MySqlConnection conn;
        public static MySqlDataAdapter da;
        public static MySqlCommand cmd;
        public static void openConnect()
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
        }

        public static void closeConnect()
        {
            conn.Close();
        }
        public static DataTable getData (string sql)
        {
            DataTable dt = new DataTable();
            da = new MySqlDataAdapter(sql, conn);
            da.Fill(dt);

            //Giải phóng bộ nhớ
            da.Dispose();
            return dt;
        }
        public static bool exeScalar(string sql)
        {
            cmd = new MySqlCommand(sql, conn);
            int i = (int)(long)cmd.ExecuteScalar();
            return i > 0;
        }
        public static void update(string sql, string[] name = null, object[] value = null)
        {
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Clear();
            if(value != null)
            {
                for (int i = 0; i < value.Length; i++)
                {
                    cmd.Parameters.AddWithValue(name[i], value[i]);
                } 
            }
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        public static void executeNonQuery(string sql)
        {
            
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            
        }
    }


}
