using AspMVCProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspMVCProject.Controllers
{
    public class ClassPopupController : Controller
    {
        public ClassPopupController(AppDbContext context, IConfiguration configuration)
        {
            _db = context;
            _conf = configuration;
        }

        private readonly AppDbContext _db;
        private readonly IConfiguration _conf;

        public IActionResult Index()
        {
            List<TheClass> classes = _db.classes.ToList();
            return View(classes);
        }

        public IActionResult AddClass()
        {
            TheClass theClass = new TheClass();
            theClass.students.Add(new TheClassStudent());
            return PartialView("_pvAddClass", theClass);
        }

        [HttpPost]
        public IActionResult AddClass(TheClass theClass)
        {
            _db.classes.Add(theClass);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
