using GestionNotes.Services;
using System;

namespace GestionNotes.Views
{
    public class Menu
    {
        private EtudiantService etudiantService;
        private NoteService noteService;

        public Menu(EtudiantService eService, NoteService nService)
        {
            etudiantService = eService;
            noteService = nService;
        }

        public void Afficher()
        {
            int choix;
            do
            {
                Console.WriteLine("\n=== MENU GESTION DE NOTES ===");
                Console.WriteLine("1. Ajouter un étudiant");
                Console.WriteLine("2. Afficher les étudiants");
                Console.WriteLine("3. Ajouter une note à un étudiant");
                Console.WriteLine("4. Afficher les notes d’un étudiant avec appréciation");
                Console.WriteLine("5. Supprimer un étudiant");
                Console.WriteLine("6. Afficher le meilleur étudiant");
                Console.WriteLine("7. Afficher la moyenne de la classe");
                Console.WriteLine("8. Quitter");
                Console.Write("Votre choix : ");

                choix = LireEntier();

                switch (choix)
                {
                    case 1: etudiantService.AjouterEtudiant(); break;
                    case 2: etudiantService.AfficherEtudiants(); break;
                    case 3: noteService.AjouterNote(); break;
                    case 4: etudiantService.AfficherNotesEtudiant(); break;
                    case 5: etudiantService.SupprimerEtudiant(); break;
                    case 6: etudiantService.MeilleurEtudiant(); break;
                    case 7: etudiantService.MoyenneClasse(); break;
                    case 8: Console.WriteLine("👋 Au revoir !"); break;
                    default: Console.WriteLine("❌ Choix invalide."); break;
                }

            } while (choix != 8);
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
