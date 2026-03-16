using IhateThisErrorsAndBug.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IhateThisErrorsAndBug.Controllers
{
    public class MainController : Controller
    {
        private readonly WebAppContext _webAppContext;
        public MainController(WebAppContext webAppContext)
        {
            _webAppContext = webAppContext;
        }
        [HttpGet]
        public async Task<IActionResult> main() { 
            var product = await _webAppContext.Products.ToListAsync();
            var categories = await _webAppContext.Categories.ToListAsync();
            ViewBag.Categories = categories;
            return View(product);
        }
        [HttpGet]
        public async Task<IActionResult> cart()
        {
            int userId = 3; 

            var cart = await _webAppContext.Carts.FirstOrDefaultAsync(c => c.UserId == userId);

            List<CartItem> cartItems = new List<CartItem>();
            List<Product> products = new List<Product>();

            if (cart != null)
            {
                cartItems = await _webAppContext.CartItems.Where(ci => ci.CartId == cart.CartId).ToListAsync();

                var productIds = cartItems.Select(ci => ci.ProductId).ToList();
                products = await _webAppContext.Products.Where(p => productIds.Contains(p.ProductId)).ToListAsync();
            }

            ViewBag.Cart = cart;
            ViewBag.CartItems = cartItems;
            ViewBag.Products = products;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add(int productId)
        {
            int userId = 3; 

            var cart = await _webAppContext.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null)
            {
                cart = new Cart { UserId = userId, CreatedDate = DateTime.Now };
                _webAppContext.Carts.Add(cart);
                await _webAppContext.SaveChangesAsync();
            }

            var cartItem = await _webAppContext.CartItems
                .FirstOrDefaultAsync(ci => ci.CartId == cart.CartId && ci.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity += 1;
            }
            else
            {
                _webAppContext.CartItems.Add(new CartItem
                {
                    CartId = cart.CartId,
                    ProductId = productId,
                    Quantity = 1
                });
            }

            await _webAppContext.SaveChangesAsync();
            return RedirectToAction("cart"); 
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int cartItemId)
        {
            var item = await _webAppContext.CartItems.FirstOrDefaultAsync(ci => ci.CartItemId == cartItemId);
            if (item != null)
            {
                _webAppContext.CartItems.Remove(item);
                await _webAppContext.SaveChangesAsync();
            }
            return RedirectToAction("cart");
        }


        [HttpGet]
        public async Task<IActionResult> ChangeQuantity(int cartItemId, int delta)
        {
            var item = await _webAppContext.CartItems.FirstOrDefaultAsync(ci => ci.CartItemId == cartItemId);
            if (item != null)
            {
                item.Quantity += delta;
                if (item.Quantity <= 0)
                {
                    _webAppContext.CartItems.Remove(item);
                }
                await _webAppContext.SaveChangesAsync();
            }
            return RedirectToAction("cart");
        }
    }
}

