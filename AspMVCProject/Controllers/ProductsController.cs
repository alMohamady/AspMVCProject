using AspMVCProject.Models;
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

        public IActionResult AddItem()
        {
            Product product = new Product();
            return PartialView("_ProductsPv", product);
        }

        [HttpPost]
        public IActionResult AddItem(Product pro)
        {
            _context.products.Add(pro);
            _context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }

        public IActionResult EditItem(int id)
        {
            var pro = _context.products.Where(x => x.id == id).FirstOrDefault();
            return PartialView("_EditProductPv", pro);
        }

        [HttpPost]
        public IActionResult EditItem(Product pro)
        {
            _context.products.Update(pro);
            _context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }

        public IActionResult RemoveItem(int id)
        {
            var pro = _context.products.Where(x => x.id == id).FirstOrDefault();
            return PartialView("_RemoveProduct", pro);
        }

        [HttpPost]
        public IActionResult RemoveItem(Product pro)
        {
            _context.products.Remove(pro);
            _context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }

    }
}
