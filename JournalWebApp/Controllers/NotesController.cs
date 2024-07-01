using JournalWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace JournalWebApp.Controllers
{
    public class NotesController : Controller
    {
        public List<NotesModel> Notes { get; set; }

        public NotesController()
        {
            Notes = SampleNotes();
        }

        public IActionResult Index()
        {
            return View(Notes);
        }

        // Return a sample list of notes
        private List<NotesModel> SampleNotes()
        {
            return new List<NotesModel>
            {
                new NotesModel
                {
                    Id = 1,
                    CreationDate = DateTime.Now,
                    Title = "This is an example of a note you can create!",
                    Content = "This is a web application designed for you to create notes and increase you productivity...",
                    IsActive = true
                },
                new NotesModel
                {
                    Id = 2,
                    CreationDate = DateTime.Now.AddDays(-1),
                    Title = "Another example note",
                    Content = "Notes can be deactivated if you don't need them, but you also don't want to delete them",
                    IsActive = false
                }
            };
        }

    }
}
