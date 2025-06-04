using MediaTek86.bddmanager;
using MediaTek86.modele;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace MediaTek86.dal
{
    public static class ServiceDAL
    {
        public static List<Service> GetAll()
        {
            List<Service> services = new List<Service>();
            string query = "SELECT * FROM service";
            MySqlCommand cmd = new MySqlCommand(query, BddManager.GetConnection());
            BddManager.OpenConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                services.Add(new Service(
                    reader.GetInt32("idservice"),
                    reader.GetString("nom")
                ));
            }
            reader.Close();
            BddManager.CloseConnection();
            return services;
        }
    }
}
