using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESInfoCenter
{
    internal class DBConnection
    {
        private static readonly string connectionString = "server=localhost;database=testdb;user=root;password=tucontraseña;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
