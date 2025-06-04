
using MySql.Data.MySqlClient;
using System;

namespace MediaTek86.bddmanager
{
    public class BddManager
    {
        private static MySqlConnection connection;
        private static string connectionString = "server=localhost;port=3307;user=mediatek;password=admin123;database=mediatek86";

        public static MySqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new MySqlConnection(connectionString);
            }
            return connection;
        }

        public static void OpenConnection()
        {
            if (connection == null)
            {
                connection = new MySqlConnection(connectionString);
            }

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public static void CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
