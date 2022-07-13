﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
                item.SelectAge = _db.selectAges?.FirstOrDefault(u => u.Id == item.SelectAgeId);
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
                    Value = i.Id.ToString(), 
                    Text = i.Name.ToString(), 

                }),

                AgeSelectListItem = _db.selectAges.Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Age.ToString(),

                }),

                ConditionSelectListItems = _db.Conditions.Select(i => new SelectListItem
                {
                    Value =  i.Id.ToString(),
                    Text = i.Name

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
                    var sss = AdvertVM.Advertisement.MaterialId;

                    _db.Advertisements.Add(AdvertVM.Advertisement);
                }
                else
                {
                    //updating
                    var objFromDb = _db.Advertisements.AsNoTracking().FirstOrDefault(u => u.Id == AdvertVM.Advertisement.Id);

                    if (files.Count > 0)
                    {
                        string upload = webRootPath + WC.ImagePath;
                        string fileName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(files[0].FileName);

                        var oldFile = Path.Combine(upload, objFromDb.Image);

                        if (System.IO.File.Exists(oldFile))
                        {
                            System.IO.File.Delete(oldFile);
                        }

                        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }

                        AdvertVM.Advertisement.Image = fileName + extension;
                    }
                    else
                    {
                        AdvertVM.Advertisement.Image = objFromDb.Image;
                    }

                    _db.Advertisements.Update(AdvertVM.Advertisement);

                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            AdvertVM.CategorySelectListItems = _db.Categories.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });

            AdvertVM.MaterialSelectListItems = _db.Materials.Select(i => new SelectListItem
            {
                Value = i.Id.ToString(),
                Text = i.Name.ToString(),

            });

            AdvertVM.AgeSelectListItem = _db.selectAges.Select(i => new SelectListItem
            {
                Value = i.Id.ToString(),
                Text = i.Age.ToString(),

            });

            AdvertVM.ConditionSelectListItems = _db.Conditions.Select(i => new SelectListItem
            {
                Value = i.Id.ToString(),
                Text = i.Name

            });
            return View(AdvertVM);

        }
       
        //GET DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Advertisement? advertisement = _db.Advertisements.Include(u => u.Category).Include(u => u.Material).Include(u => u.Condition).Include(u => u.SelectAge).FirstOrDefault(u => u.Id == id); 
            

            if (advertisement == null)
            {
                return NotFound();
            }
            return View(advertisement);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Advertisements.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            string upload = _webHostEnvironment.WebRootPath + WC.ImagePath;
            var oldFile = Path.Combine(upload, obj.Image);

            if (System.IO.File.Exists(oldFile))
            {
                System.IO.File.Delete(oldFile);
            }

            _db.Advertisements.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }

    }
}
