using JournalWebApp.Data;

namespace JournalWebApp.Models
{
    public class NotesModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }

        // Methods

        /** Converts a instance of a Note to a NotesModel */
        public static NotesModel ToNotesModel(Note note)
        {
            return new NotesModel
            {
                Id = note.Id,
                CreationDate = note.CreationDate,
                Title = note.Title,
                Content = note.Content,
                IsActive = note.IsActive
            };
        }

        /** Converse an instance of NotesModel to a Note */
        public Note ToNote()
        {
            return new Note
            {
                Id = Id,
                CreationDate = CreationDate,
                Title = Title,
                Content = Content,
                IsActive = IsActive
            };
        }

    }
}
