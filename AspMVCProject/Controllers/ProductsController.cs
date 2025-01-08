using Microsoft.AspNetCore.Mvc;

namespace AspMVCProject.Controllers
{
    public class ProductsController : Controller
    {
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;

        public IActionResult Index()
        {
            var products = _context.products.ToList();
            return View(products);
        }
    }
}
