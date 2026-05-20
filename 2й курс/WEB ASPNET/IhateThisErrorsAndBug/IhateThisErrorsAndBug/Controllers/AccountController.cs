using IhateThisErrorsAndBug.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IhateThisErrorsAndBug.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly WebAppContext _context;

        public AccountController(WebAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(string username, string password)
        {
            if(_context.Users.Any(u=> u.Username == username))
            
                {
                ModelState.AddModelError("", "Пользователь с таким именем уже есть!");
                return View();
                }

            string hash = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new User { Username = username, PasswordHash = hash, RoleId = 2, IsActive = true};
            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();


            return RedirectToAction("Login");
        }




        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null) {
                ModelState.AddModelError("", "Пользователь не найден!");
                return View();
            }
            if (!user.IsActive)
            {
                ModelState.AddModelError("", "Пользователь в бане!");
                return View();
            }
            bool isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            if (!isValid) {
                ModelState.AddModelError("", "Неверный пороль!");
                return View();
            }

            string role = user.RoleId switch { 1 => "Admin",
                _ => "User"
            };
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            if (role == "Admin")
            {
                return RedirectToAction("Index", "Admin");
            }
            else {
                return RedirectToAction("main", "Main");
            }





        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        
        [HttpGet]


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
