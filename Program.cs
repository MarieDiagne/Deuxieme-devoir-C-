using GestionNotes.Repository;
using GestionNotes.Services;
using GestionNotes.Views;

namespace GestionNotes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var etudiantRepo = new EtudiantRepository();
            var noteRepo = new NoteRepository();

            var etudiantService = new EtudiantService(etudiantRepo, noteRepo);
            var noteService = new NoteService(noteRepo, etudiantRepo);

            var menu = new Menu(etudiantService, noteService);
            menu.Afficher();
        }
    }
}
