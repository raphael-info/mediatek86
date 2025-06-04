using MediaTek86.modele;
using MediaTek86.bddmanager;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace MediaTek86.dal
{
    public class PersonnelDAL
    {
        public static List<Personnel> GetAll()
        {
            List<Personnel> personnelList = new List<Personnel>();
            string query = "SELECT * FROM personnel";
            MySqlCommand cmd = new MySqlCommand(query, BddManager.GetConnection());
            BddManager.OpenConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                personnelList.Add(new Personnel(
                    reader.GetInt32("idpersonnel"),
                    reader.GetString("nom"),
                    reader.GetString("prenom"),
                    reader.GetString("tel"),
                    reader.GetString("mail"),
                    reader.GetInt32("idservice")
                ));
            }
            reader.Close();
            BddManager.CloseConnection();
            return personnelList;
        }

        public static void Add(Personnel personnel)
        {
            string query = "INSERT INTO personnel(nom, prenom, tel, mail, idservice) VALUES (@nom, @prenom, @tel, @mail, @idservice)";
            MySqlCommand cmd = new MySqlCommand(query, BddManager.GetConnection());
            cmd.Parameters.AddWithValue("@nom", personnel.Nom);
            cmd.Parameters.AddWithValue("@prenom", personnel.Prenom);
            cmd.Parameters.AddWithValue("@tel", personnel.Tel);
            cmd.Parameters.AddWithValue("@mail", personnel.Mail);
            cmd.Parameters.AddWithValue("@idservice", personnel.IdService);
            BddManager.OpenConnection();
            cmd.ExecuteNonQuery();
            BddManager.CloseConnection();
        }

        public static void Update(Personnel personnel)
        {
            string query = "UPDATE personnel SET nom=@nom, prenom=@prenom, tel=@tel, mail=@mail, idservice=@idservice WHERE idpersonnel=@id";
            MySqlCommand cmd = new MySqlCommand(query, BddManager.GetConnection());
            cmd.Parameters.AddWithValue("@nom", personnel.Nom);
            cmd.Parameters.AddWithValue("@prenom", personnel.Prenom);
            cmd.Parameters.AddWithValue("@tel", personnel.Tel);
            cmd.Parameters.AddWithValue("@mail", personnel.Mail);
            cmd.Parameters.AddWithValue("@idservice", personnel.IdService);
            cmd.Parameters.AddWithValue("@id", personnel.IdPersonnel);
            BddManager.OpenConnection();
            cmd.ExecuteNonQuery();
            BddManager.CloseConnection();
        }

        public static void Delete(int id)
        {
            string query = "DELETE FROM personnel WHERE idpersonnel=@id";
            MySqlCommand cmd = new MySqlCommand(query, BddManager.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);
            BddManager.OpenConnection();
            cmd.ExecuteNonQuery();
            BddManager.CloseConnection();
        }
    }
}
