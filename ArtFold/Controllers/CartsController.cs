using ArtFold.Data;
using Microsoft.AspNetCore.Mvc;

namespace ArtFold.Controllers
{
    public class CartsController : Controller
    {
        public readonly ArtFoldDbContext _context;

        public CartsController(ArtFoldDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
