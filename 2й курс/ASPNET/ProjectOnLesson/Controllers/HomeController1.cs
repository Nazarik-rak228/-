using Microsoft.AspNetCore.Mvc;

namespace ProjectOnLesson.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index1()
        {
            return View();
        }
    }
}
