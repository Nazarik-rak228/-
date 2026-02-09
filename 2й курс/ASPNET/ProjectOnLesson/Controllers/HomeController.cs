using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectOnLesson.Models;

namespace ProjectOnLesson.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index1()
        {
            return RedirectToAction("index1", "TestController2");
            return View();
        }

        public IActionResult Index21()
        {
            return RedirectToAction("Index3", "HomeController1");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
