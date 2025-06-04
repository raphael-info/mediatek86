namespace MediaTek86.modele
{
    public class Service
    {
        public int IdService { get; set; }
        public string Nom { get; set; }

        public Service(int idService, string nom)
        {
            IdService = idService;
            Nom = nom;
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}
