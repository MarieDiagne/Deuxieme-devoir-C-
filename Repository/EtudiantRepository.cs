using GestionNotes.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GestionNotes.Repository
{
    public class EtudiantRepository
    {
        private List<Etudiant> etudiants = new List<Etudiant>();
        private int compteur = 1;

        public Etudiant Ajouter(string nom, string prenom)
        {
            var e = new Etudiant(compteur++, nom, prenom);
            etudiants.Add(e);
            return e;
        }

        public List<Etudiant> Lister()
        {
            return etudiants;
        }

        public Etudiant? TrouverParId(int id)
        {
            return etudiants.FirstOrDefault(e => e.Id == id);
        }

        public bool Supprimer(int id)
        {
            var e = TrouverParId(id);
            if (e != null)
            {
                etudiants.Remove(e);
                return true;
            }
            return false;
        }
    }
}
