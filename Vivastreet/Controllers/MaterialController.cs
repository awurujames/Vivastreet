using Microsoft.AspNetCore.Mvc;
using Vivastreet_DataAccess;
using Vivastreet.Models;
using Vivastreet_Models;
using Vivastreet.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Vivastreet_Utility;

namespace Vivastreet.Controllers
{
    [Authorize(Roles = WC.AdminRole)]

    public class MaterialController : Controller
    {
        private readonly IMaterialRepository _matRepo;

        public MaterialController(IMaterialRepository matRepo)
        {
            _matRepo = matRepo;
        }
    
        public IActionResult Index()
        {
            IEnumerable<Material>? objList = _matRepo.GetAll();
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
                _matRepo.Add(obj);
                _matRepo.Save();
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
           var obj = _matRepo.Find(id.GetValueOrDefault());

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
                _matRepo.Update(obj);
                _matRepo.Save();
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
            var obj = _matRepo.Find(id.GetValueOrDefault());

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
            var obj = _matRepo.Find(id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }

            _matRepo.Remove(obj);
            _matRepo.Save();
            return RedirectToAction("Index");

            return View(obj);
        }

    }
}
