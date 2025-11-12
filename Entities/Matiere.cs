namespace GestionNotes.Entities
{
    public class Matiere
    {
        public int Id { get; set; }
        public string Libelle { get; set; }

        public Matiere(int id, string libelle)
        {
            Id = id;
            Libelle = libelle;
        }

        public override string ToString()
        {
            return $"{Id} - {Libelle}";
        }
    }
}
