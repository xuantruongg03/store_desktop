using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace DTO_StoreComputer
{
    internal class DBConnect
    {
        protected string connectionString = ConfigurationManager.ConnectionStrings["stringConnect"].ConnectionString.ToString();
        
    }
}
