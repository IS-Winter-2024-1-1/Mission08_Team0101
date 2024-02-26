using Microsoft.AspNetCore.Mvc;
using Mission08_Team0101.Models;
using System.Diagnostics;

namespace Mission08_Team0101.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
