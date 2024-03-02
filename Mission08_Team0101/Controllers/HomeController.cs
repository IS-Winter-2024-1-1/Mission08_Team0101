using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0101.Models;
using System.Diagnostics;

namespace Mission08_Team0101.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddToDo()
        {
            // Load the Categories table into the ViewBag (for the dropdown).
            ViewBag.categories = _repo.Categories.OrderBy(x => x.CategoryName).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddToDo(Models.Task entry)
        {
            _repo.AddTask(entry);

            // Redirect to the Quadrants view so the user can see what they just submitted.
            return View("Index");
        }




        [HttpGet]
        public IActionResult Quadrants()
        {
            ViewBag.categoryMappings = new Dictionary<string, string>();

            // Load data from the Categories table into the dictionary, such that the categoryIDs are the keys, and the categoryNames are the values.
            // This will make it easier to display categoryNames in the view, since the Tasks records will only have categoryID.
            foreach (Category c in _repo.Categories.OrderBy(x => x.CategoryId))
            {
                ViewBag.categoryMappings[c.CategoryId.ToString()] = c.CategoryName;
            }

            // Grab the Tasks table and pass it into the view.
            List<Models.Task> tasks = _repo.Tasks;

            return View(tasks);
        }

        [HttpPost]
        public IActionResult Quadrants(int TaskId) // This is functionally the Delete endpoint. 
        {
            // Grab the record we want to delete using the TaskId.
            Models.Task toDelete = _repo.Tasks.First(x => x.TaskId == TaskId);

            // NUKE IT!
            _repo.RemoveTask(toDelete);

            // Redirect to the data page.
            return RedirectToAction("Quadrants");
        }





        [HttpGet]
        public IActionResult Edit(int id)
        // This view is essentially a duplicate of the AddToDo view, with the fields pre-loaded with the 
        // values from the record to be edited.
        {
            // Load the Categories table into the ViewBag (for the dropdown).
            ViewBag.categories = _repo.Categories.OrderBy(x => x.CategoryId).ToList();

            Models.Task task = _repo.Tasks.Single(x => x.TaskId == id);

            return View("AddToDo", task);
        }

        [HttpPost]
        public IActionResult Edit(Models.Task updatedTask)
        {
            _repo.UpdateTask(updatedTask);

            return RedirectToAction("Quadrants");
        }   





    }
}
