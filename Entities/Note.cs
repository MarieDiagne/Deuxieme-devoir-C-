namespace GestionNotes.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public Etudiant Etudiant { get; set; }
        public Matiere Matiere { get; set; }
        public double Valeur { get; set; }

        public Note(int id, Etudiant etudiant, Matiere matiere, double valeur)
        {
            Id = id;
            Etudiant = etudiant;
            Matiere = matiere;
            Valeur = valeur;
        }

        public string Appreciation()
        {
            if (Valeur >= 16) return "Excellent";
            if (Valeur >= 14) return "Très bien";
            if (Valeur >= 12) return "Bien";
            if (Valeur >= 10) return "Passable";
            return "Insuffisant";
        }

        public override string ToString()
        {
            return $"{Matiere.Libelle} : {Valeur}/20 ({Appreciation()})";
        }
    }
}
