﻿using Microsoft.AspNetCore.Mvc;
using Vivastreet.Data;
using Vivastreet.Models;

namespace Vivastreet.Controllers
{
    public class ConditionController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ConditionController(ApplicationDbContext db)
        {
            _db = db;
        }
    
        public IActionResult Index()
        {
            IEnumerable<Condition>? objList = _db.Conditions;
            return View(objList);
        }

        public IActionResult Create()
        {
            //IEnumerable<Category>? objList = _db.Categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Condition obj)
        {
            if (ModelState.IsValid)
            {
                _db.Conditions?.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);       

              
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Conditions?.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Condition obj)
        {
            if (ModelState.IsValid)
            {
                _db.Conditions?.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);


        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Conditions?.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Conditions?.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Conditions?.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

            return View(obj);


        }
    }
}
