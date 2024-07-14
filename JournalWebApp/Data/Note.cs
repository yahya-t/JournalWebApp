namespace JournalWebApp.Data
{
    // Class to represent fields in the database
    public class Note
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
    }
}

