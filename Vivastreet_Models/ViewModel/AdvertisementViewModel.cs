//using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Vivastreet_Models.ViewModel
{
    public class AdvertisementViewModel
    {
        public Advertisement? Advertisement { get; set; }
        public IEnumerable<SelectListItem>? CategorySelectListItems { get; set; } 
        public IEnumerable<SelectListItem>? MaterialSelectListItems { get; set; }
        public IEnumerable<SelectListItem>? AgeSelectListItem { get; set; }
        public IEnumerable<SelectListItem>? ConditionSelectListItems { get; set; }
            
    }
}
