using Microsoft.AspNetCore.Mvc;
using Vivastreet.Data;
using Vivastreet.Models;

namespace Vivastreet.Controllers
{
    public class MaterialController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MaterialController(ApplicationDbContext db)
        {
            _db = db;
        }
    
        public IActionResult Index()
        {
            IEnumerable<Material>? objList = _db.Materials;
            return View(objList);
        }

        public IActionResult Create()
        {
            //IEnumerable<Category>? objList = _db.Categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Material obj)
        {
            if (ModelState.IsValid)
            {
                _db.Materials?.Add(obj);
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
           var obj =  _db.Materials?.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Material obj)
        {
            if (ModelState.IsValid)
            {
                _db.Materials?.Update(obj);
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
            var obj = _db.Materials?.Find(id);

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
            var obj = _db.Materials?.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

                _db.Materials?.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

            return View(obj);
        }

    }
}
