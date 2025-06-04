using MediaTek86.bddmanager;
using System;
using System.Collections.Generic;
using MediaTek86.modele;
using MySql.Data.MySqlClient;

namespace MediaTek86.dal
{
    public static class AbsenceDAL
    {
        public static List<Absence> GetByPersonnel(int idPersonnel)
        {
            List<Absence> absences = new List<Absence>();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM absence WHERE idpersonnel = @id", BddManager.GetConnection());
            cmd.Parameters.AddWithValue("@id", idPersonnel);
            BddManager.OpenConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Absence absence = new Absence(
                    reader.GetInt32("idpersonnel"),
                    reader.GetDateTime("datedebut"),
                    reader.GetDateTime("datefin"),
                    reader.GetInt32("idmotif")
                );
                absences.Add(absence);
            }
            reader.Close();
            BddManager.CloseConnection();
            return absences;
        }

        public static void Add(Absence absence)
        {
            string query = "INSERT INTO absence (idpersonnel, datedebut, datefin, idmotif) VALUES (@id, @debut, @fin, @motif)";
            MySqlCommand cmd = new MySqlCommand(query, BddManager.GetConnection());
            cmd.Parameters.AddWithValue("@id", absence.IdPersonnel);
            cmd.Parameters.AddWithValue("@debut", absence.DateDebut);
            cmd.Parameters.AddWithValue("@fin", absence.DateFin);
            cmd.Parameters.AddWithValue("@motif", absence.IdMotif);
            BddManager.OpenConnection();
            cmd.ExecuteNonQuery();
            BddManager.CloseConnection();
        }

        public static void Update(Absence absence, DateTime ancienneDateDebut)
        {
            string query = "UPDATE absence SET datedebut=@debut, datefin=@fin, idmotif=@motif WHERE idpersonnel=@id AND datedebut=@ancienne";
            MySqlCommand cmd = new MySqlCommand(query, BddManager.GetConnection());
            cmd.Parameters.AddWithValue("@debut", absence.DateDebut);
            cmd.Parameters.AddWithValue("@fin", absence.DateFin);
            cmd.Parameters.AddWithValue("@motif", absence.IdMotif);
            cmd.Parameters.AddWithValue("@id", absence.IdPersonnel);
            cmd.Parameters.AddWithValue("@ancienne", ancienneDateDebut);
            BddManager.OpenConnection();
            cmd.ExecuteNonQuery();
            BddManager.CloseConnection();
        }

        public static void Delete(int idPersonnel, DateTime datedebut)
        {
            string query = "DELETE FROM absence WHERE idpersonnel=@id AND datedebut=@debut";
            MySqlCommand cmd = new MySqlCommand(query, BddManager.GetConnection());
            cmd.Parameters.AddWithValue("@id", idPersonnel);
            cmd.Parameters.AddWithValue("@debut", datedebut);
            BddManager.OpenConnection();
            cmd.ExecuteNonQuery();
            BddManager.CloseConnection();
        }
    }
}