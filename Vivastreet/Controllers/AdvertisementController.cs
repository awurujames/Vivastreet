using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vivastreet.Data;
using Vivastreet.Models;
using Vivastreet.Models.ViewModel;

namespace Vivastreet.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;   
        public AdvertisementController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
    
        public IActionResult Index()
        {
            IEnumerable<Advertisement>? objList = _db.Advertisements;
            foreach (var item in objList)
            {
                item.Category = _db.Categories?.FirstOrDefault(u => u.Id == item.CategoryId);
                item.Condition = _db.Conditions?.FirstOrDefault(u => u.Id == item.ConditionId);
                item.Material = _db.Materials?.FirstOrDefault(u => u.Id == item.MaterialId);
                item.SelectAge = _db.selectAges?.FirstOrDefault(u => u.Id == item.MaterialId);
            }
            return View(objList);
        }

        
        public IActionResult Upsert(int? id)
        {

            AdvertisementViewModel AdvertVM = new AdvertisementViewModel()
            {
                Advertisement = new Advertisement(),
                CategorySelectListItems = _db.Categories.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                }),

                MaterialSelectListItems = _db.Materials.Select(i => new SelectListItem
                {
                    Value = i.Name, 
                    Text = i.Id.ToString(), 

                }),

                AgeSelectListItem = _db.selectAges.Select(i => new SelectListItem
                {
                    //Value = i.Name,
                    Text = i.Id.ToString(),

                }),

                ConditionSelectListItems = _db.Conditions.Select(i => new SelectListItem
                {
                    Value = i.Name,
                    Text = i.Id.ToString(),

                })


            };



            //Advertisement advert = new Advertisement();
            if (id == null)
            {
                //create
                return View(AdvertVM);
            }
            else
            {
                //edit
                AdvertVM.Advertisement = _db.Advertisements.Find(id);
                if (AdvertVM == null)
                {
                    return NotFound();
                }
                return View(AdvertVM);
            }
                 
        }

        //Upsert - Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(AdvertisementViewModel AdvertVM)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;
                if (AdvertVM.Advertisement.Id == 0)
                {
                    //create
                    string upload = webRootPath + WC.ImagePath;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    using (var filesStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filesStream);
                    }

                    AdvertVM.Advertisement.Image = fileName + extension;

                    _db.Advertisements.Add(AdvertVM.Advertisement); 
                }
                else
                {

                }

                _db.SaveChanges();  
                return RedirectToAction("Index");
            }
            return View();       

              
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
           var obj =  _db.Categories?.Find(id);

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
                _db.Categories?.Update(obj);
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
            var obj = _db.Categories?.Find(id);

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
            var obj = _db.Categories?.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

                _db.Categories?.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

            return View(obj);


        }

    }
}
