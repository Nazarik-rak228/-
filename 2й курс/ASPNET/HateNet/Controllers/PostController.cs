
using Microsoft.AspNetCore.Mvc;

namespace HateNet.Controllers
{
    public class PostController : Controller
    {
        [HttpGet]
        public IActionResult IndexX()
        {
            return View();
        }
        [HttpPost]
        public IActionResult IndexX(string num1, string num2, string num3)
        {
            int num1i = Convert.ToInt32(num1);
            int num2i = Convert.ToInt32(num2);
            int num3i = Convert.ToInt32(num3);
            int sum = num1i + num2i + num3i;
            ViewBag.sum = sum;
            return View("indexX");
        }
    }
}
