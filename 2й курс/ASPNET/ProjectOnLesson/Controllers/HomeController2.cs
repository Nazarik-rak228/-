using Microsoft.AspNetCore.Mvc;

namespace ProjectOnLesson.Controllers
{
    public class HomeController2 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
