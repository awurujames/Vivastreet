using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vivastreet_DataAccess;
using Vivastreet_Models;
using Vivastreet_Utility;

namespace Vivastreet.Controllers
{
    [Authorize(Roles = WC.AdminRole)]

    public class SelectAgeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SelectAgeController(ApplicationDbContext db)
        {
            _db = db;
        }
    
        public IActionResult Index()
        {
            IEnumerable<SelectAge>? objList = _db.selectAges;
            return View(objList);
        }

        public IActionResult Create()
        {
            //IEnumerable<Category>? objList = _db.Categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SelectAge obj)
        {
            if (ModelState.IsValid)
            {
                _db.selectAges?.Add(obj);
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
           var obj =  _db.selectAges?.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SelectAge obj)
        {
            if (ModelState.IsValid)
            {
                _db.selectAges?.Update(obj);
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
            var obj = _db.selectAges?.Find(id);

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
            var obj = _db.selectAges?.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

                _db.selectAges?.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

            return View(obj);


        }

    }
}
