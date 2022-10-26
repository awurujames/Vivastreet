using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList;
using Vivastreet_Models;

namespace Vivastreet.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Advertisement>? Advertisements { get; set; }
        public IPagedList<Advertisement>? Advertisementss { get; set; }

        public IEnumerable<SelectListItem>? CategorySelectListItems { get; set; }
        public IEnumerable<SelectListItem>? MaterialSelectListItems { get; set; }
        public IEnumerable<SelectListItem>? AgeSelectListItem { get; set; }
        public IEnumerable<SelectListItem>? ConditionSelectListItems { get; set; }
        public IEnumerable<SelectListItem>? CitySelectListItems { get; set; }
        public IEnumerable<SelectListItem>? RateSelectListItems { get; set; }

        public Advertisement? PremierBanner { get; set; }
        public Advertisement? AdvertOfTheWeek { get; set; }



        //public IEnumerable<Category>? Categories { get; set; }
        //public IEnumerable<Material>? Materials { get; set; }
        //public IEnumerable<City>? Cities { get; set; }
        //public IEnumerable<Rate>? Rates { get; set; }
        //public IEnumerable<SelectAge>? SelectAges { get; set; }
        //public IEnumerable<Condition>? Conditions { get; set; }
        //public IEnumerable<ServiceOffered>? ServiceOffered { get; set; }


        public Advertisement? Advertisement { get; set; }
        public int? SelectAgeMinId { get; set; }
        public int? SelectAgeMaxId { get; set; }
        public int? CategoryId { get; set; }
        public int? ConditionId { get; set; }
        public int? RateMinId { get; set; }
        public int? RateMaxId { get; set; }
        public int? CityId { get; set; }
        public int? pageNumber { get; set; }
    }
}
