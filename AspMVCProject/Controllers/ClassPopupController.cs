﻿using AspMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult AddClass([FromBody] TheClass theClass)
        {
            _db.classes.Add(theClass);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var theClass = _db.classes.Where(x => x.id == id).Include(s => s.students).FirstOrDefault();
            return PartialView("_pvDetailsClass", theClass);
        }

        public IActionResult Edit(int id)
        {
            var theClass = _db.classes.Where(x => x.id == id).Include(s => s.students).FirstOrDefault();
            return PartialView("_pvEditClass", theClass);
        }

        [HttpPost]
        public IActionResult Edit(TheClass mdl)
        {
            List<TheClassStudent> students = _db.students.Where(x => x.theClassId == mdl.id).ToList();
            _db.students.RemoveRange(students);
            _db.SaveChanges();

            _db.classes.Update(mdl);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var theClass = _db.classes.Where(x => x.id == id).Include(s => s.students).FirstOrDefault();
            return PartialView("_pvDeleteClass", theClass);
        }

        [HttpPost]
        public IActionResult Delete(TheClass mdl)
        {
            _db.Attach(mdl);
            _db.Entry(mdl).State = EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
