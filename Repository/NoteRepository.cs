using GestionNotes.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GestionNotes.Repository
{
    public class NoteRepository
    {
        private List<Note> notes = new List<Note>();
        private int compteur = 1;

        public Note Ajouter(Etudiant etudiant, Matiere matiere, double valeur)
        {
            var n = new Note(compteur++, etudiant, matiere, valeur);
            notes.Add(n);
            return n;
        }

        public List<Note> ListerParEtudiant(Etudiant etudiant)
        {
            return notes.Where(n => n.Etudiant.Id == etudiant.Id).ToList();
        }

        public List<Note> Lister()
        {
            return notes;
        }
    }
}
