using JournalWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JournalWebApp.Data
{
    public class DataContext : DbContext
    {
        // Constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // Set of Notes
        public DbSet<Note> Notes { get; set; }

        // Seed preset data to database
        public void SeedInitialData()
        {
            if (Notes == null)
            {
                Notes.Add(new Note
                {
                    Id = 1,
                    CreationDate = DateTime.Now,
                    Title = "This is an example of a note you can create!",
                    Content = "This is a web application designed for you to create notes and increase you productivity...",
                    IsActive = true
                });
                Notes.Add(new Note
                {
                    Id = 2,
                    CreationDate = DateTime.Now.AddDays(-1),
                    Title = "Another example note",
                    Content = "Notes can be deactivated if you don't need them, but you also don't want to delete them",
                    IsActive = false
                });
                SaveChanges();
            }
        }

    }
}
