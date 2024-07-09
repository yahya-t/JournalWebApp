using JournalWebApp.Data;

namespace JournalWebApp.Repository
{
    public interface INotesRepository
    {
        Task<List<Note>> GetAllNotesAsync();
        Task<Note> GetNoteByIdAsync(int id);
        Task<Note> AddNoteAsync(Note note);
        Task UpdateNoteAsync(Note note);
        Task DeleteNoteAsync(int id);
    }
}
