using Microsoft.AspNetCore.Mvc;

namespace JournalWebApp.Controllers
{
    public class NotesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
