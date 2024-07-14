using JournalWebApp.Data;
using JournalWebApp.Models;
using JournalWebApp.Repository;

namespace JournalWebApp.Logic
{
    public class NotesLogic : INotesLogic
    {
        // INotesRepository instance
        private readonly INotesRepository _repo;

        // Constructor
        public NotesLogic(INotesRepository repo)
        {
            _repo = repo;
        }

        // Interface implementation
        public async Task<List<NotesModel>> GetAllNotesAsync()
        {
            var notes = await _repo.GetAllNotesAsync();
            return notes.Select(NotesModel.ToNotesModel).ToList();
        }

        public async Task<NotesModel> GetNoteByIdAsync(int id)
        {
            var note = await _repo.GetNoteByIdAsync(id);
            return note == null ? null : NotesModel.ToNotesModel(note);
        }

        public async Task AddNoteAsync(NotesModel note)
        {
            var newNote = note.ToNote();
            await _repo.AddNoteAsync(newNote);
        }

        public async Task UpdateNoteAsync(NotesModel note)
        {
            var updateNote = note.ToNote();
            await _repo.UpdateNoteAsync(updateNote);
        }
        public async Task DeleteNoteAsync(int id)
        {
            await _repo.DeleteNoteAsync(id);
        }
    }
}
