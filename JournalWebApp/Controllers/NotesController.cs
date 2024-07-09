using JournalWebApp.Logic;
using JournalWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace JournalWebApp.Controllers
{
    public class NotesController : Controller
    {
        public readonly INotesLogic _logic;

        public NotesController(INotesLogic logic)
        {
            _logic = logic;
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
            return note == null ? NotFound() : View(note);
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
                await _logic.AddNoteAsync(note);
                return RedirectToAction("Index");
            }
            return View(note);
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null) return View("NotFound");

            var note = await _logic.GetNoteByIdAsync(id);
            return note == null ? View("Not Found") : View(note);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,CreationDate,Title,Content,IsActive")] int id, NotesModel note)
        {
            if (id != note.Id) return View("Not Found");

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
            if (id == null) return View("NotFound");

            var note = await _logic.GetNoteByIdAsync(id);
            return note == null ? View("Not Found") : View(note);
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
