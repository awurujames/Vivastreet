using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Vivastreet.Data;
using Vivastreet.Models;
using Vivastreet.Models.ViewModel;

namespace Vivastreet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Advertisements = _db.Advertisements.Include(u => u.Category).Include(u => u.Material).Include(u => u.Condition).Include(u => u.SelectAge).Include(u => u.Rates),
                Categories = _db.Categories,
                Materials = _db.Materials,
                Conditions = _db.Conditions,
                SelectAges = _db.selectAges,
                Cities = _db.Citys

            };
            return View(homeVM);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}