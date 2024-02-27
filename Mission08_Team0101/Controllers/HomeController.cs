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

            // Redirect to the Quadrants view so the user can see what they just submitted.
            return View("Index");
        }




        [HttpGet]
        public IActionResult Quadrants()
        {
            ViewBag.categoryMappings = new Dictionary<string, string>();

            // Load data from the Categories table into the dictionary, such that the categoryIDs are the keys, and the categoryNames are the values.
            // This will make it easier to display categoryNames in the view, since the Tasks records will only have categoryID.
            foreach (Category c in _context.Categories.OrderBy(x => x.CategoryId).ToList())
            {
                ViewBag.categoryMappings[c.CategoryId.ToString()] = c.CategoryName;
            }

            // Grab the Tasks table and pass it into the view.
            List<Models.Task> tasks = _context.Tasks.ToList();

            return View(tasks);
        }

        [HttpPost]
        public IActionResult Quadrants(int id) // This is functionally the Delete endpoint. 
        {
            // Grab the record we want to delete using the TaskId.
            Models.Task toDelete = _context.Tasks.First(x => x.TaskId == id);

            // NUKE IT!
            _context.Tasks.Remove(toDelete);
            _context.SaveChanges();

            // Redirect to the data page.
            return RedirectToAction("Quadrants");
        }





        [HttpGet]
        public IActionResult Edit(int id)
        // This view is essentially a duplicate of the AddToDo view, with the fields pre-loaded with the 
        // values from the record to be edited.
        {
            // Load the Categories table into the ViewBag (for the dropdown).
            ViewBag.categories = _context.Categories.OrderBy(x => x.CategoryId).ToList();

            // Load the Task the user wants to edit into the ViewBag, so the view can have its input fields pre-populated with the existing data.
            ViewBag.nowEditing = _context.Tasks.Where(x => x.TaskId == id).ToList()[0];

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Models.Task updatedTask)
        {
            _context.Update(updatedTask);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }   





    }
}
