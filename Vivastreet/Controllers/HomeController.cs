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
using Microsoft.AspNetCore.Authorization;
using Vivastreet_Utility;
using PagedList;

namespace Vivastreet.Controllers
{
    // [Authorize(Roles = WC.AdminRole)]

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

        public IActionResult Index(HomeViewModel model, int pg = 1)
        {
            const int pageSize = 6;
            if (pg < 1)
                pg = 1;

            HomeViewModel homeVM = new HomeViewModel()
            {
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


            var filtered = _db.Advertisements.Include(u => u.Category).Include(u => u.Material).Include(u => u.Condition)
                .Include(u => u.SelectAge).Include(u => u.City).Include(u => u.Rates)
                .Where(x => x.AdvertisementType == AdvertType.ClassicAdvert.ToString()).AsQueryable();

            homeVM.AdvertOfTheWeek = _db.Advertisements.Include(u => u.Category).Include(u => u.Material).Include(u => u.Condition)
                .Include(u => u.SelectAge).Include(u => u.City).Include(u => u.Rates).
                Where(x => x.AdvertisementType == AdvertType.AdvertOfTheWeek.ToString()).OrderByDescending(x => x.DateCreated).LastOrDefault();   

            homeVM.PremierBanner = _db.Advertisements.Include(u => u.Category).Include(u => u.Material).Include(u => u.Condition)
                .Include(u => u.SelectAge).Include(u => u.City).Include(u => u.Rates)
                .Where(x => x.AdvertisementType == AdvertType.PremierBanner.ToString()).OrderByDescending(x => x.DateCreated).LastOrDefault();

            //Filter criteria
            var catId = model.CategoryId;
            var conId = model.ConditionId;
            var rateminId = model.RateMinId;
            var ratemaxId = model.RateMaxId;
            var ageminId = model.SelectAgeMinId;
            var agemaxId = model.SelectAgeMaxId;
            var cityId = model.CityId;

            if (catId.HasValue)
            {
                filtered = filtered.Where(i => i.CategoryId == catId.Value);
            }

            if (conId.HasValue)
            {
                filtered = filtered.Where(i => i.ConditionId == conId.Value);
            }

            if (cityId.HasValue)
            {
                filtered = filtered.Where(i => i.MaterialId == cityId.Value);
            }

            if (rateminId.HasValue)
            {
                if (ratemaxId.HasValue)
                {
                    filtered = filtered.Where(i => i.RateId == rateminId.Value || i.RateId == ratemaxId.Value);
                }
                else
                {
                    filtered = filtered.Where(i => i.RateId == rateminId.Value);
                }

            }

            if (ageminId.HasValue)
            {
                if (agemaxId.HasValue)
                {
                    filtered = filtered.Where(i => i.SelectAgeId == ageminId.Value || i.SelectAgeId == agemaxId.Value);
                }
                else
                {
                    filtered = filtered.Where(i => i.SelectAgeId == ageminId.Value);
                }

            }


            homeVM.Advertisements = filtered.ToList();
            homeVM.Advertisementss = filtered.ToList().ToPagedList(homeVM.pageNumber ?? 1, 3);

            int recsCount = homeVM.Advertisements.Count();

            var pagerr = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = homeVM.Advertisements.Skip(recSkip).Take(pagerr.PageSize).ToList();

            homeVM.Advertisements = data;
            var ss = homeVM.Advertisements.Count();
            this.ViewBag.Pager = pagerr;

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
                Advertisementz = _db.Advertisements.Include(u => u.Category).Include(u => u.Material).Include(u => u.Condition).Include(u => u.SelectAge).Include(u => u.Rates).Where(u => u.Id == id).FirstOrDefault(),
                // Advertisementz = _advertRepo.FirstOrDefault(u => u.Id == id, includeProperties: "Category, Material, Condition, SelectAge, Rate"),

            };

            var advert = _db.Advertisements.FirstOrDefault(x => x.Id == id);
            return (IActionResult)View(detailsVM);
            
        }



    }
}