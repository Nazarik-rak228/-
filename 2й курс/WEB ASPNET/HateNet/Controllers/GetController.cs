using Microsoft.AspNetCore.Mvc;

namespace HateNet.Controllers
{
    public class GetController : Controller
    {
        public IActionResult Index2(string firstname)
        {
            ViewBag.Firstname = firstname;
            ViewBag.Name = "Alina";
            return View();
        }
        
    }
}
