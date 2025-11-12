using GestionNotes.Entities;
using GestionNotes.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionNotes.Services
{
    public class EtudiantService
    {
        private EtudiantRepository repoEtudiant;
        private NoteRepository repoNote;

        public EtudiantService(EtudiantRepository eRepo, NoteRepository nRepo)
        {
            repoEtudiant = eRepo;
            repoNote = nRepo;
        }

        public Etudiant AjouterEtudiant()
        {
            Console.Write("Nom : ");
            string nom = LireTexte();
            Console.Write("Prénom : ");
            string prenom = LireTexte();

            var e = repoEtudiant.Ajouter(nom, prenom);
            Console.WriteLine("✅ Étudiant ajouté avec succès !");
            return e;
        }

        public void AfficherEtudiants()
        {
            var liste = repoEtudiant.Lister();
            if (liste.Count == 0)
            {
                Console.WriteLine("⚠️ Aucun étudiant enregistré.");
                return;
            }
            foreach (var e in liste)
                Console.WriteLine(e);
        }

        public void SupprimerEtudiant()
        {
            Console.Write("ID de l'étudiant à supprimer : ");
            int id = LireEntier();
            if (repoEtudiant.Supprimer(id))
                Console.WriteLine("✅ Étudiant supprimé !");
            else
                Console.WriteLine("⚠️ Étudiant introuvable !");
        }

        public void AfficherNotesEtudiant()
        {
            Console.Write("ID de l'étudiant : ");
            int id = LireEntier();
            var etudiant = repoEtudiant.TrouverParId(id);
            if (etudiant == null)
            {
                Console.WriteLine("⚠️ Étudiant introuvable !");
                return;
            }

            var notes = repoNote.ListerParEtudiant(etudiant);
            if (notes.Count == 0)
            {
                Console.WriteLine("Aucune note trouvée.");
                return;
            }

            Console.WriteLine($"Notes de {etudiant.Prenom} {etudiant.Nom} :");
            foreach (var n in notes)
                Console.WriteLine($" - {n}");
        }

        public void MeilleurEtudiant()
        {
            var etudiants = repoEtudiant.Lister();
            if (etudiants.Count == 0)
            {
                Console.WriteLine("Aucun étudiant enregistré.");
                return;
            }

            var moyennes = etudiants
                .Select(e => new
                {
                    Etudiant = e,
                    Moyenne = CalculerMoyenne(e)
                })
                .Where(x => x.Moyenne > 0)
                .ToList();

            if (moyennes.Count == 0)
            {
                Console.WriteLine("Aucune note enregistrée.");
                return;
            }

            var meilleur = moyennes.OrderByDescending(x => x.Moyenne).First();
            Console.WriteLine($"🏆 Meilleur étudiant : {meilleur.Etudiant.Prenom} {meilleur.Etudiant.Nom} ({meilleur.Moyenne:F2}/20)");
        }

        public void MoyenneClasse()
        {
            var notes = repoNote.Lister();
            if (notes.Count == 0)
            {
                Console.WriteLine("Aucune note enregistrée.");
                return;
            }

            double moyenne = notes.Average(n => n.Valeur);
            Console.WriteLine($"📊 Moyenne générale de la classe : {moyenne:F2}/20");
        }

        private double CalculerMoyenne(Etudiant e)
        {
            var notes = repoNote.ListerParEtudiant(e);
            if (notes.Count == 0) return 0;
            return notes.Average(n => n.Valeur);
        }

        // --- Contrôles de saisie ---
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
    }
}
