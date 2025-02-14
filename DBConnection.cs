using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
namespace MESInfoCenter
{
    internal class DBConnection
    {
        private static readonly string connectionString = "server=MLXGUMVWPAPP02;database=mesinfocenter;user=dilmaor;password=dilmaor123;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
