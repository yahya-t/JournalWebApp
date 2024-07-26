using JournalWebApp.Logic;
using JournalWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace JournalWebApp.Controllers
{
    public class NotesController : Controller
    {
        private readonly INotesLogic _logic;
        private readonly ILogger<NotesController> _logger;

        public NotesController(INotesLogic logic, ILogger<NotesController> logger)
        {
            _logic = logic;
            _logger = logger;
        }

        // GET: Index
        public async Task<IActionResult> Index()
        {
            var notes = await _logic.GetAllNotesAsync();
            return View(notes);
        }

        // GET: Details
        public async Task<IActionResult> Details(int id)
        {
            var note = await _logic.GetNoteByIdAsync(id);
            if (note == null)
            {
                _logger.LogInformation("Details not found for ID {id}", id);
                return View("NotFound");
            }
            return View(note);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreationDate,Title,Content,IsActive")] NotesModel note)
        {
            if (ModelState.IsValid)
            {
                note.CreationDate = DateTime.Now;
                await _logic.AddNoteAsync(note);
                return RedirectToAction("Index");
            }
            return View(note);
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                _logger.LogInformation("No ID was passed");
                return View("NotFound");
            }

            var note = await _logic.GetNoteByIdAsync(id);

            if (note == null)
            {
                _logger.LogInformation("Edit details not found for id {id}", id);
                return View("NotFound");
            }

            return View(note);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,CreationDate,Title,Content,IsActive")] int id, NotesModel note)
        {
            if (id != note.Id) return View("NotFound");

            if (ModelState.IsValid)
            {
                await _logic.UpdateNoteAsync(note);
                return RedirectToAction("Index");
            }
            return View(note);
        }

        // GET: Delete
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                _logger.LogInformation("Delete details not found for id {id}", id);
                return View("NotFound");
            }

            var note = await _logic.GetNoteByIdAsync(id);
            if (note == null)
            {
                _logger.LogInformation("Delete Details not found for id {id}", id);
                return View("NotFound");
            }
            return View(note);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _logic.DeleteNoteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
