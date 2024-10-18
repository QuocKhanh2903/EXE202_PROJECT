using ArtFold.Data;
using ArtFold.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace ArtFold.Controllers
{
    public class CartsController : Controller
    {
        public readonly ArtFoldDbContext _context;
        private readonly UserManager<User> _userManager;

        public CartsController(ArtFoldDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }


            var cart = await _context.Carts
                                .Include(c => c.CartProducts)
                                .ThenInclude(cp => cp.Product)
                                .FirstOrDefaultAsync(c => c.UserID == user.Id);

            return View(cart);
        }

        public async Task<IActionResult> AddToCart(Guid productId, int quantity)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { success = false, message = "Please login to add items to the cart." });
            }

            var cart = _context.Carts.FirstOrDefault(c => c.UserID == user.Id);
            if (cart == null)
            {
                return Json(new { success = false, message = "Cart not found." });
            }

            var cartProduct = _context.CartProducts.FirstOrDefault(cp => cp.CartID == cart.CartID && cp.ProductID == productId);
            if (cartProduct != null)
            {
                cartProduct.ProductCartQuantity += quantity;
            }
            else
            {
                cartProduct = new CartProduct
                {
                    CartID = cart.CartID,
                    ProductID = productId,
                    ProductCartQuantity = quantity
                };
                _context.CartProducts.Add(cartProduct);
            }

            await _context.SaveChangesAsync();

            //var cartSession = _context.Carts
            //                .Include(c => c.CartProducts)
            //                .ThenInclude(cp => cp.Product)
            //                .Where(c => c.UserID == user.Id)
            //                .Select(c => new
            //                {
            //                    cartID = c.CartID,
            //                    CartProducts = c.CartProducts.Select(cp => new
            //                    {
            //                        cp.ProductID,
            //                        cp.Product.Name,
            //                        cp.ProductCartQuantity,
            //                        cp.Product.Price
            //                    }).ToList()
            //                })
            //                .FirstOrDefault();

            //HttpContext.Session.SetString("Cart", Newtonsoft.Json.JsonConvert.SerializeObject(cartSession));


            return Json(new { success = true});
        }

        public async Task<IActionResult> UpdateProductCartQuantity(Guid productId, int newQuantity)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { success = false, message = "Please login to update the cart." });
            }

            var cart = await _context.Carts
                .Include(c => c.CartProducts)
                .ThenInclude(cp => cp.Product)  
                .FirstOrDefaultAsync(c => c.UserID == user.Id);

            if (cart == null)
            {
                return Json(new { success = false, message = "Cart not found." });
            }

            var cartProduct = cart.CartProducts.FirstOrDefault(cp => cp.ProductID == productId);
            if (cartProduct == null)
            {
                return Json(new { success = false, message = "Product not found in the cart." });
            }


            cartProduct.ProductCartQuantity = newQuantity;


            await _context.SaveChangesAsync();

            var productTotal = cartProduct.Product.Price * cartProduct.ProductCartQuantity;

            return Json(new { success = true, productTotal = productTotal.ToString("N0").Replace(",", ".") + " đ" });
        }

        public async Task<IActionResult> DeleteProductCart(Guid productId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { success = false, message = "Please login to update the cart." });
            }

            var cart = await _context.Carts
                .Include(c => c.CartProducts)
                .ThenInclude(cp => cp.Product)
                .FirstOrDefaultAsync(c => c.UserID == user.Id);

            if (cart == null)
            {
                return Json(new { success = false, message = "Cart not found." });
            }

            var cartProduct = cart.CartProducts.FirstOrDefault(cp => cp.ProductID == productId);

            if (cartProduct == null)
            {
                return Json(new { success = false, message = "Product not found in the cart." });
            }

            _context.CartProducts.Remove(cartProduct);

            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        [HttpGet]
        public async Task<IActionResult> GetCartItemCount()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { count = 0 });
            }

            var cart = await _context.Carts
                .Include(c => c.CartProducts)
                .FirstOrDefaultAsync(c => c.UserID == user.Id);

            

            if (cart == null)
            {
                return Json(new { cartItemCount = 0 });
            }

            var cartItemCount = cart.CartProducts.Count;

            return Json(new { count = cartItemCount });
        }
    }

}

