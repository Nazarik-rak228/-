using Microsoft.AspNetCore.Mvc;

namespace ProjectOnLesson.Controllers
{
    public class TestController : Controller
    {
        public IActionResult TestView()
        {
            return View("TestView");
        }
    }
}
