using AspMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspMVCProject.Controllers
{
    public class ProductsController : Controller
    {
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["CurrentFilter"] = searchString;

            var products = from p in _context.products
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(n => n.name);
                    break;
                case "Date":
                    products = products.OrderBy(n => n.createdDate);
                    break;
                case "date_desc":
                    products = products.OrderByDescending(n => n.createdDate);
                    break;
                case "Price":
                    products = products.OrderBy(n => n.price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(n => n.price);
                    break;
                default:
                    products = products.OrderBy(n => n.name);
                    break;
            }


            var  productList = await products.ToListAsync();
            return View(productList);
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
