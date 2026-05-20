using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using powtorBD.Models;
using System.Drawing;

namespace powtorBD.Controllers
{
    public class Controller1 : Controller
    {
        private readonly OrderZakaziContext _orderZakaziContext;

        public Controller1(OrderZakaziContext orderZakaziContext)
        {
            _orderZakaziContext = orderZakaziContext;

        }
        [HttpGet]
        public async Task<IActionResult>Index()
        {
            var color = await _orderZakaziContext.Colours.ToListAsync();
            return View(color);

        }


        public async Task<IActionResult> Create()
        {

            return View();
        }

        //(string name, string description  )
        [HttpPost]
        [ValidateAntiForgeryToken] // от поддельных щапросов
        public async Task<IActionResult> Create(Colour colour)
        {
            if (!ModelState.IsValid) //проверяет не валидность формы 
            {
                return View();
            }
            _orderZakaziContext.Colours.Add(colour);
            await _orderZakaziContext.SaveChangesAsync();
            return RedirectToAction("Index", "Controller1");


        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id )
        {
            if(id == null)
            {
                return NotFound();

            }
            var color = await _orderZakaziContext.Colours.FindAsync(id.Value);
            return View(color);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // от поддельных щапросов
        public async Task<ActionResult>Edit(int id, Colour colour)
        {
            if (id != colour.IdColour)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid) //проверяет не валидность формы 
            {
                return View();
            }
            _orderZakaziContext.Colours.Update(colour);
            await _orderZakaziContext.SaveChangesAsync();
            return RedirectToAction("Index", "Controller1");
        }
        [HttpGet]
        public async Task<ActionResult> Remove(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var color = await _orderZakaziContext.Colours.FirstOrDefaultAsync(c=>c.IdColour ==c.IdColour);
            if(color == null)
            {
                return NotFound();
            }

            return View(color);

        }
        [HttpPost]

        public async Task<ActionResult> Remove(int id)
        {
            var color = await _orderZakaziContext.Colours.FindAsync(id);
            if(color ==null)
            {
                return NotFound();
            }
            _orderZakaziContext.Colours.Remove(color);
            await _orderZakaziContext.SaveChangesAsync();
            return RedirectToAction("Index", "Controller1");

        }
    }   
}
