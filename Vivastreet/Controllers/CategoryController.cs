using Microsoft.AspNetCore.Mvc;
using Vivastreet_DataAccess;
using Vivastreet.Models;
using Vivastreet_Models;
using Vivastreet.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Vivastreet_Utility;

namespace Vivastreet.Controllers
{
    //[Authorize(Roles = WC.AdminRole)]

    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _CatRepo;

        public CategoryController(ICategoryRepository CatRepo)
        {
            _CatRepo = CatRepo;
        }

        public IActionResult Index()
        {
            IEnumerable<Category>? objList = _CatRepo.GetAll();
            return View(objList);
        }

        public IActionResult Create()
        {
            //IEnumerable<Category>? objList = _db.Categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _CatRepo.Add(obj);
                _CatRepo.Save();
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
            var obj = _CatRepo.Find(id.GetValueOrDefault());

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _CatRepo.Update(obj);
                _CatRepo.Save();
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
            var obj = _CatRepo.Find(id.GetValueOrDefault());

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
            var obj = _CatRepo.Find(id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }

            _CatRepo.Remove(obj);
            _CatRepo.Save();
            return RedirectToAction("Index");

            return View(obj);


        }
    }
}
