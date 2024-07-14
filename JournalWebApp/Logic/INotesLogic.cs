using JournalWebApp.Data;
using JournalWebApp.Models;

namespace JournalWebApp.Logic
{
    // Mirrors the repository interface, but allows implementation of additional business logic
    // Uses NotesModel instead of Note as NoteModel also applies business logic 
    public interface INotesLogic
    {
        Task<List<NotesModel>> GetAllNotesAsync();
        Task<NotesModel> GetNoteByIdAsync(int id);
        Task AddNoteAsync(NotesModel note);
        Task UpdateNoteAsync(NotesModel note);
        Task DeleteNoteAsync(int id);
    }
}
