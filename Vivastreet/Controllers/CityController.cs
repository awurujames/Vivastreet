using Microsoft.AspNetCore.Mvc;
using Vivastreet_DataAccess;
using Vivastreet.Models;
using Vivastreet_Models;
using Vivastreet.Repository.IRepository;

namespace Vivastreet.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityRepository _CityRepo;

        public CityController(ICityRepository CityRepo)
        {
            _CityRepo = CityRepo;
        }

        public IActionResult Index()
        {
            IEnumerable<City>? objList = _CityRepo.GetAll();
            return View(objList);
        }

        public IActionResult Create()
        {
            //IEnumerable<Category>? objList = _db.Categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(City obj)
        {
            if (ModelState.IsValid)
            {
                _CityRepo.Add(obj);
                _CityRepo.Save();
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
            var obj = _CityRepo.Find(id.GetValueOrDefault());

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(City obj)
        {
            if (ModelState.IsValid)
            {
                _CityRepo.Update(obj);
                _CityRepo.Save();
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
            var obj = _CityRepo.Find(id.GetValueOrDefault());

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
            var obj = _CityRepo.Find(id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }

            _CityRepo.Remove(obj);
            _CityRepo.Save();
            return RedirectToAction("Index");

            return View(obj);


        }
    }
}
