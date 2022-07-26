using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Vivastreet_DataAccess;
using Vivastreet.Models;
using Vivastreet_Models.ViewModel;
using Vivastreet_Models;
using Vivastreet.Repository.IRepository;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using Vivastreet.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Vivastreet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       private readonly ApplicationDbContext _db;
        private readonly IAdvertisementRepository _advertRepo;
        private readonly ICategoryRepository _catRepo;
        private readonly IConditionRepository _ConRepo;
        private readonly ICityRepository _cityRepo;
        private readonly IMaterialRepository _matRepo;
        private readonly IRateRepository _rateRepo;
        private readonly IAgeRepository _ageRepo;

        public HomeController(ILogger<HomeController> logger, IAdvertisementRepository advertRepo, 
            ICategoryRepository catRepo, IConditionRepository ConRepo, ICityRepository cityRepo,
            IMaterialRepository matRepo, IRateRepository rateRepo, IAgeRepository ageRepo, ApplicationDbContext db)
        {

            _logger = logger;
            _advertRepo = advertRepo;
            _catRepo = catRepo;
            _ConRepo = ConRepo;
            _cityRepo = cityRepo;
            _matRepo = matRepo;
            _db = db;
            _rateRepo = rateRepo;
            _ageRepo = ageRepo;
        }

        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel()
            {
                //Advertisements = _advertRepo.GetAll(includeProperties: "Advertisement, Condition, Material, SelectAge, City"),
                Advertisements = _db.Advertisements.Include(u => u.Category).Include(u => u.Material).Include(u => u.Condition)
                .Include(u => u.SelectAge).Include(u => u.City).Include(u => u.Rates).ToList(),
                //Categories = _catRepo.GetAll(),
                //Materials = _matRepo.GetAll(),
                //Conditions = _ConRepo.GetAll(),
                //Cities = _cityRepo.GetAll(),



                CategorySelectListItems = _catRepo.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                }),

                MaterialSelectListItems = _matRepo.GetAll().Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name.ToString(),

                }),

                AgeSelectListItem = _ageRepo.GetAll().Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Age.ToString(),

                }),

                ConditionSelectListItems = _ConRepo.GetAll().Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name

                }),

                CitySelectListItems = _cityRepo.GetAll().Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.CityName.ToString(),

                }),

                RateSelectListItems = _rateRepo.GetAll().Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name

                }),


            };
            return View(homeVM);
        }




        //public IActionResult HomeDropDown(int? id)
        //{

        //    HomeVM homeVM = new HomeVM()
        //    {
        //        Advertisement = new Advertisement(),
        //        CategorySelectListItems = _catRepo.GetAll().Select(i => new SelectListItem
        //        {
        //            Text = i.Name,
        //            Value = i.Id.ToString(),
        //        }),

        //        MaterialSelectListItems = _matRepo.GetAll().Select(i => new SelectListItem
        //        {
        //            Value = i.Id.ToString(),
        //            Text = i.Name.ToString(),

        //        }),

        //        AgeSelectListItem = _ConRepo.GetAll().Select(i => new SelectListItem
        //        {
        //            Value = i.Id.ToString(),
        //            Text = i.Name.ToString(),

        //        }),

        //        ConditionSelectListItems = _ConRepo.GetAll().Select(i => new SelectListItem
        //        {
        //            Value = i.Id.ToString(),
        //            Text = i.Name

        //        }),
                
        //    };
        //    return(IActionResult)View(homeVM);

        //}




        public IActionResult Details(int id)
        {
            DetailsVM detailsVM = new DetailsVM()
            {
                Advertisementz = _db.Advertisements.Include(u => u.Category).Include(u => u.Material).Include(u => u.Condition).Include(u => u.SelectAge).Include(u => u.Rates).Where(u => u.Id == id).FirstOrDefault()
               // Advertisementz = _advertRepo.FirstOrDefault(u => u.Id == id, includeProperties: "Category, Material, Condition, SelectAge, Rate"),

            };
            return(IActionResult)View(detailsVM);   
            
        }
        
        

    }
}