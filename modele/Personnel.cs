namespace MediaTek86.modele
{
    public class Personnel
    {
        public int IdPersonnel { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public int IdService { get; set; }

        public Personnel(int id, string nom, string prenom, string tel, string mail, int idService)
        {
            IdPersonnel = id;
            Nom = nom;
            Prenom = prenom;
            Tel = tel;
            Mail = mail;
            IdService = idService;
        }
    }
}
