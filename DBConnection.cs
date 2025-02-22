using MySqlConnector;
namespace MESInfoCenter
{
    internal class DBConnection
    {
        private static readonly string connectionString = "server=server;database=database;user=user;password=password;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
