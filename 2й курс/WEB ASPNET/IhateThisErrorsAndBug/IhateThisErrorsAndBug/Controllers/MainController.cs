using IhateThisErrorsAndBug.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace IhateThisErrorsAndBug.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        private readonly WebAppContext _webAppContext;
        public MainController(WebAppContext webAppContext)
        {
            _webAppContext = webAppContext;
        }
        [HttpGet]
        public async Task<IActionResult> main(string searchTerm, int? categoryId, string sortBy, int page = 1) {
            int pageSize = 6;

            var product = _webAppContext.Products.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm)) {
                product = product.Where(p => p.ProductName.Contains(searchTerm));
            }
            if (categoryId != null) {
                product = product.Where(p => p.CategoryId == categoryId);
            }
            product = sortBy switch
            {
                "Price_asc" => product.OrderBy(p => p.Price),
                "Price_desc" => product.OrderByDescending(p => p.Price),
                "Name_asc" => product.OrderBy(p => p.ProductName),
                "Name_desc" => product.OrderByDescending(p => p.ProductName),
                _ => product.OrderBy(p => p.ProductId)
            };
            int total = await product.CountAsync();
            var item =await product.Skip(page-1).Take(pageSize).ToListAsync();


            var categories = await _webAppContext.Categories.ToListAsync();
            ViewBag.searchTerm = searchTerm;
            ViewBag.categoryId = categoryId;
            ViewBag.sortBy = sortBy;
            ViewBag.page = page;
            ViewBag.total = (int)Math.Ceiling(total/(double)pageSize);
            ViewBag.Categories = categories;

            return View(item);
        }
        [HttpGet]
        public async Task<IActionResult> cart()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

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
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

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
                var product = await _webAppContext.Products.FindAsync(productId);
                if (product == null) return NotFound();
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
        [HttpGet]
        public async Task<IActionResult> GetImage(int productId)
        {
            var product = await _webAppContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);

            if (product != null && product.ImageData != null)
            {
                return File(product.ImageData, product.ImageMimeType);
            }
            
            var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "photo", "no.png");
            var imageBytes = await System.IO.File.ReadAllBytesAsync(path);
            return File(imageBytes, "image/png");
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var cart = await _webAppContext.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null) return RedirectToAction("cart");
            var cartItems = await _webAppContext.CartItems.Where(ci => ci.CartId == cart.CartId).ToListAsync();
            if (!cartItems.Any()) return RedirectToAction("cart");
            var productIds = cartItems.Select(ci => ci.ProductId).ToList();
            var products = await _webAppContext.Products.Where(p => productIds.Contains(p.ProductId)).ToDictionaryAsync(p => p.ProductId);


            decimal totalAmount = cartItems.Sum(ci => products[ci.ProductId].Price * ci.Quantity);
            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                TotalAmount = totalAmount
            };
            _webAppContext.Orders.Add(order);
            await _webAppContext.SaveChangesAsync();


            foreach (var item in cartItems)
            {
                var product = products[item.ProductId];
                _webAppContext.OrderItems.Add(new OrderItem
                {
                    OrderId = order.OrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    PriceAtPurchase = product.Price 
                });
            }

            _webAppContext.CartItems.RemoveRange(cartItems);
            await _webAppContext.SaveChangesAsync();

            return RedirectToAction("MyOrders");
        }
        [HttpGet]
       
        public async Task<IActionResult> MyOrders()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var orders = await _webAppContext.Orders.Where(o => o.UserId == userId).OrderByDescending(o => o.OrderDate).ToListAsync();

            var orderIds = orders.Select(o => o.OrderId).ToList();
            var orderItems = await _webAppContext.OrderItems.Where(oi => orderIds.Contains(oi.OrderId)).ToListAsync();
            var productIds = orderItems.Select(oi => oi.ProductId).Distinct().ToList();
            var products = await _webAppContext.Products.Where(p => productIds.Contains(p.ProductId)).ToListAsync();

            ViewBag.Orders = orders;
            ViewBag.Items = orderItems;
            ViewBag.Products = products;

            return View();
        }


    }
}

