
using System.Web.Mvc;

namespace Vivastreet_Models.ViewModel
{
    public  class HomeVM
    {
       public IEnumerable<Advertisement>? Advertisements { get; set; }
        // public IEnumerable<Category>? Categories { get; set; }
        // public IEnumerable<Material>? Materials { get; set; }
        // public IEnumerable<City>? Cities { get; set; }
        // public  IEnumerable<Rate>? Rates { get; set; }
        // public  IEnumerable<SelectAge>? SelectAges { get; set; }
        // public IEnumerable<Condition>? Conditions { get; set; }
        // public IEnumerable<ServiceOffered>? ServiceOffered { get; set; }

        // public Advertisement? Advertisement { get; set; }

        public IEnumerable<SelectListItem>? CategorySelectListItems { get; set; }
        public IEnumerable<SelectListItem>? MaterialSelectListItems { get; set; }
        public IEnumerable<SelectListItem>? AgeSelectListItem { get; set; }
        public IEnumerable<SelectListItem>? ConditionSelectListItems { get; set; }
        public IEnumerable<SelectListItem>? RateSelectListItems { get; set; }

    }
}
