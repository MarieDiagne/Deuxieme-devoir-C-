namespace GestionNotes.Entities
{
    public class Etudiant
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public Etudiant(int id, string nom, string prenom)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
        }

        public override string ToString()
        {
            return $"{Id} - {Prenom} {Nom}";
        }
    }
}
