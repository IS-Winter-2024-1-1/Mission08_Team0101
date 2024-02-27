using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0101.Models;
using System.Diagnostics;

namespace Mission08_Team0101.Controllers
{
    public class HomeController : Controller
    {
        private TaskApplicationContext _context;

        public HomeController(TaskApplicationContext x)
        {
            _context = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddToDo()
        {
            // Load the Categories table into the ViewBag (for the dropdown).
            ViewBag.categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddToDo(Models.Task entry)
        {
            _context.Tasks.Add(entry);
            _context.SaveChanges();

            // Load the GetToKnow page.
            return View("Index");
        }

    }
}
