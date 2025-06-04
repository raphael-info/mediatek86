using System;

namespace MediaTek86.modele
{
    public class Absence
    {
        public int IdPersonnel { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int IdMotif { get; set; }

        public Absence(int idPersonnel, DateTime dateDebut, DateTime dateFin, int idMotif)
        {
            IdPersonnel = idPersonnel;
            DateDebut = dateDebut;
            DateFin = dateFin;
            IdMotif = idMotif;
        }
    }
}