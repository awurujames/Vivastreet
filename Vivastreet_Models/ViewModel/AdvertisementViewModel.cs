//using System.Web.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Vivastreet_Models.ViewModel
{
    public class AdvertisementViewModel 
    {
        public Advertisement? Advertisement { get; set; }
        public Image? ImageCol { get; set; }
        public IEnumerable<SelectListItem>? CategorySelectListItems { get; set; } 
        public IEnumerable<SelectListItem>? MaterialSelectListItems { get; set; }
        public IEnumerable<SelectListItem>? AgeSelectListItem { get; set; }
        public IEnumerable<SelectListItem>? ConditionSelectListItems { get; set; }
        public IEnumerable<SelectListItem>? CitySelectListItems { get; set; }

        public IFormFileCollection Files { get; set; }
    }
}
