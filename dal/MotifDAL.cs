using MediaTek86.bddmanager;
using System.Collections.Generic;
using MediaTek86.modele;
using MySql.Data.MySqlClient;

namespace MediaTek86.dal
{
    public static class MotifDAL
    {
        public static List<Motif> GetAll()
        {
            List<Motif> motifs = new List<Motif>();
            string query = "SELECT * FROM motif";
            MySqlCommand cmd = new MySqlCommand(query, BddManager.GetConnection());
            BddManager.OpenConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                motifs.Add(new Motif(reader.GetInt32("idmotif"), reader.GetString("libelle")));
            }
            reader.Close();
            BddManager.CloseConnection();
            return motifs;
        }
    }
}