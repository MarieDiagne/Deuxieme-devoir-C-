using GestionNotes.Entities;
using GestionNotes.Repository;
using System;

namespace GestionNotes.Services
{
    public class NoteService
    {
        private NoteRepository repoNote;
        private EtudiantRepository repoEtudiant;

        public NoteService(NoteRepository nRepo, EtudiantRepository eRepo)
        {
            repoNote = nRepo;
            repoEtudiant = eRepo;
        }

        public void AjouterNote()
        {
            Console.Write("ID Étudiant : ");
            int id = LireEntier();
            var etudiant = repoEtudiant.TrouverParId(id);

            if (etudiant == null)
            {
                Console.WriteLine("⚠️ Étudiant introuvable !");
                return;
            }

            Console.Write("Nom de la matière : ");
            string libelle = LireTexte();
            var matiere = new Matiere(1, libelle);

            Console.Write("Note (0-20) : ");
            double valeur = LireDouble();

            repoNote.Ajouter(etudiant, matiere, valeur);
            Console.WriteLine("✅ Note ajoutée !");
        }

        private string LireTexte()
        {
            string? texte;
            do
            {
                texte = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(texte));
            return texte;
        }

        private int LireEntier()
        {
            int n;
            while (!int.TryParse(Console.ReadLine(), out n))
                Console.Write("Veuillez entrer un nombre valide : ");
            return n;
        }

        private double LireDouble()
        {
            double n;
            while (!double.TryParse(Console.ReadLine(), out n) || n < 0 || n > 20)
                Console.Write("Veuillez entrer une note entre 0 et 20 : ");
            return n;
        }
    }
}
