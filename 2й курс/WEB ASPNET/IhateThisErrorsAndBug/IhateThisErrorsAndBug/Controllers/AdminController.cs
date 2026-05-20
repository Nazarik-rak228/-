using IhateThisErrorsAndBug.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IhateThisErrorsAndBug.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly WebAppContext _webAppContext;

        public AdminController(WebAppContext webAppContext)
        {
            _webAppContext = webAppContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        // все для продукта-----------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> Products()
        {
            return View(await _webAppContext.Products.ToListAsync());
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product, IFormFile ImageFile)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateProduct");   
            } 
            if(ImageFile != null && ImageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await ImageFile.CopyToAsync(memoryStream);
                    product.ImageData = memoryStream.ToArray();
                }
                product.ImageMimeType = ImageFile.ContentType;
            }
            _webAppContext.Products.Add(product);
            await _webAppContext.SaveChangesAsync();
            return RedirectToAction("Products");
                   
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {

            var product = await _webAppContext.Products
                .FirstOrDefaultAsync(x => x.ProductId == id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product, IFormFile ImageFile)
        {
            if (!ModelState.IsValid)
            {
                return View("EditProduct");
            }
            var oldProduct = await _webAppContext.Products.FirstOrDefaultAsync(p => p.ProductId == product.ProductId);

            if (oldProduct == null)
            {
                return NotFound();
            }

            oldProduct.ProductName = product.ProductName;
            oldProduct.Price = product.Price;
            oldProduct.CategoryId = product.CategoryId;
            oldProduct.Discription = product.Discription;

            if (ImageFile != null && ImageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await ImageFile.CopyToAsync(memoryStream);

                    oldProduct.ImageData = memoryStream.ToArray();
                }

                oldProduct.ImageMimeType = ImageFile.ContentType;
            }


            await _webAppContext.SaveChangesAsync();
            return RedirectToAction("Products");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _webAppContext.Products
                .FirstOrDefaultAsync(x => x.ProductId == id);

            if (product != null)
            {
                _webAppContext.Products.Remove(product);
                await _webAppContext.SaveChangesAsync();
            }

            return RedirectToAction("Products");
        }

// для категории -------------------------------------------------------------------------------------------------------------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            return View(await _webAppContext.Categories.ToListAsync());
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateCategory");
            }
            _webAppContext.Categories.Add(category);
            await _webAppContext.SaveChangesAsync();
            return RedirectToAction("Categories");
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            var category = await _webAppContext.Categories
                .FirstOrDefaultAsync(x => x.CategoryId == id);

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View("EditCategory");
            }
            _webAppContext.Categories.Update(category);
            await _webAppContext.SaveChangesAsync();
            return RedirectToAction("Categories");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _webAppContext.Categories
                .FirstOrDefaultAsync(x => x.CategoryId == id);

            if (category != null)
            {
                _webAppContext.Categories.Remove(category);
                await _webAppContext.SaveChangesAsync();
            }

            return RedirectToAction("Categories");
        }
 // пользователи---------------------------------------------------------------------------------------------------------------------------------
 
        [HttpGet]
        public async Task<IActionResult> Users()
        {
            return View(await _webAppContext.Users.ToListAsync());
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateUser");
            }

            _webAppContext.Users.Add(user);
            await _webAppContext.SaveChangesAsync();
            return RedirectToAction("Users");
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(int id)
        {
            var user = await _webAppContext.Users
                .FirstOrDefaultAsync(x => x.UserId == id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("EditUser");
            }
            _webAppContext.Users.Update(user);
            await _webAppContext.SaveChangesAsync();
            return RedirectToAction("Users");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _webAppContext.Users
                .FirstOrDefaultAsync(x => x.UserId == id);

            if (user != null)
            {
                _webAppContext.Users.Remove(user);
                await _webAppContext.SaveChangesAsync();
            }

            return RedirectToAction("Users");
        }

// заказы-------------------------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            return View(await _webAppContext.Orders.ToListAsync());
        }
        [HttpGet]
        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateOrder");
            }
            _webAppContext.Orders.Add(order);
            await _webAppContext.SaveChangesAsync();
            return RedirectToAction("Orders");
        }

        [HttpGet]
        public async Task<IActionResult> EditOrder(int id)
        {
            var order = await _webAppContext.Orders
                .FirstOrDefaultAsync(x => x.OrderId == id);

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> EditOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View("EditOrder");
            }
            _webAppContext.Orders.Update(order);
            await _webAppContext.SaveChangesAsync();
            return RedirectToAction("Orders");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _webAppContext.Orders
                .FirstOrDefaultAsync(x => x.OrderId == id);

            if (order != null)
            {
                _webAppContext.Orders.Remove(order);
                await _webAppContext.SaveChangesAsync();
            }

            return RedirectToAction("Orders");
        }

        //роли ---------------------------------------------------------------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> Roles()
        {
            return View(await _webAppContext.Roles.ToListAsync());
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateRole");
            }
            _webAppContext.Roles.Add(role);
            await _webAppContext.SaveChangesAsync();
            return RedirectToAction("Roles");
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(int id)
        {
            var role = await _webAppContext.Roles
                .FirstOrDefaultAsync(x => x.RoleId == id);

            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return View("EditRole");
            }
            _webAppContext.Roles.Update(role);
            await _webAppContext.SaveChangesAsync();
            return RedirectToAction("Roles");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _webAppContext.Roles
                .FirstOrDefaultAsync(x => x.RoleId == id);

            if (role != null)
            {
                _webAppContext.Roles.Remove(role);
                await _webAppContext.SaveChangesAsync();
            }

            return RedirectToAction("Roles");
        }
        // корзина 

        [HttpGet]
        public async Task<IActionResult> Carts()
        {
            return View(await _webAppContext.Carts.ToListAsync());
        }

        [HttpGet]
        public IActionResult CreateCart()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart(Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateCart");
            }
            _webAppContext.Carts.Add(cart);
            await _webAppContext.SaveChangesAsync();
            return RedirectToAction("Carts");
        }

        [HttpGet]
        public async Task<IActionResult> EditCart(int id)
        {
            var cart = await _webAppContext.Carts
                .FirstOrDefaultAsync(x => x.CartId == id);

            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> EditCart(Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return View("EditCart");
            }
            _webAppContext.Carts.Update(cart);
            await _webAppContext.SaveChangesAsync();
            return RedirectToAction("Carts");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var cart = await _webAppContext.Carts
                .FirstOrDefaultAsync(x => x.CartId == id);

            if (cart != null)
            {
                _webAppContext.Carts.Remove(cart);
                await _webAppContext.SaveChangesAsync();
            }

            return RedirectToAction("Carts");
        }


        // предметы корзины, но, разве это в юриздикции админа?

        [HttpGet]
        public async Task<IActionResult> CartItems()
        {
            return View(await _webAppContext.CartItems.ToListAsync());
        }

        [HttpGet]
        public IActionResult CreateCartItem()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCartItem(CartItem item)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateCartItem");
            }
            _webAppContext.CartItems.Add(item);
            await _webAppContext.SaveChangesAsync();
            return RedirectToAction("CartItems");
        }

        [HttpGet]
        public async Task<IActionResult> EditCartItem(int id)
        {
            var item = await _webAppContext.CartItems
                .FirstOrDefaultAsync(x => x.CartItemId == id);

            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> EditCartItem(CartItem item)
        {
            if (!ModelState.IsValid)
            {
                return View("EditCartItem");
            }
            _webAppContext.CartItems.Update(item);
            await _webAppContext.SaveChangesAsync();
            return RedirectToAction("CartItems");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            var item = await _webAppContext.CartItems
                .FirstOrDefaultAsync(x => x.CartItemId == id);

            if (item != null)
            {
                _webAppContext.CartItems.Remove(item);
                await _webAppContext.SaveChangesAsync();
            }

            return RedirectToAction("CartItems");
        }


        // тот же самый вопрос, это точно надо, или в реале неправельно так делать?

        [HttpGet]
        public async Task<IActionResult> OrderItems()
        {
            return View(await _webAppContext.OrderItems.ToListAsync());
        }

        [HttpGet]
        public IActionResult CreateOrderItem()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderItem(OrderItem item)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateOrderItem");
            }
            _webAppContext.OrderItems.Add(item);
            await _webAppContext.SaveChangesAsync();
            return RedirectToAction("OrderItems");
        }

        [HttpGet]
        public async Task<IActionResult> EditOrderItem(int id)
        {
            var item = await _webAppContext.OrderItems
                .FirstOrDefaultAsync(x => x.OrderItemId == id);

            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> EditOrderItem(OrderItem item)
        {
            if (!ModelState.IsValid)
            {
                return View("EditOrderItem");
            }
            _webAppContext.OrderItems.Update(item);
            await _webAppContext.SaveChangesAsync();
            return RedirectToAction("OrderItems");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var item = await _webAppContext.OrderItems
                .FirstOrDefaultAsync(x => x.OrderItemId == id);

            if (item != null)
            {
                _webAppContext.OrderItems.Remove(item);
                await _webAppContext.SaveChangesAsync();
            }

            return RedirectToAction("OrderItems");
        }
    }
}