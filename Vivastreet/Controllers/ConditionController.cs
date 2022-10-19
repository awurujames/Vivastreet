using Microsoft.AspNetCore.Mvc;
using Vivastreet_DataAccess;
using Vivastreet.Models;
using Vivastreet_Models;
using Vivastreet.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Vivastreet_Utility;

namespace Vivastreet.Controllers
{
   // [Authorize(Roles = WC.AdminRole)]

    public class ConditionController : Controller
    {
        private readonly IConditionRepository _ConRepo;

        public ConditionController(IConditionRepository ConRepo)
        {
            _ConRepo = ConRepo;
        }
    
        public IActionResult Index()
        {
            IEnumerable<Condition>? objList = _ConRepo.GetAll();
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
                _ConRepo.Add(obj);
                _ConRepo.Save();
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
            var obj = _ConRepo.Find(id.GetValueOrDefault());

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
                _ConRepo.Update(obj);
                _ConRepo.Save();
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
            var obj = _ConRepo.Find(id.GetValueOrDefault());

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
            var obj = _ConRepo.Find(id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }

            _ConRepo.Remove(obj);
            _ConRepo.Save();
            return RedirectToAction("Index");

            return View(obj);


        }
    }
}
