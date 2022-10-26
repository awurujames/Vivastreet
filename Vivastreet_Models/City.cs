using System.ComponentModel.DataAnnotations;

namespace Vivastreet_Models
{
    public class City : BaseDomain
    {
        public int Id { get; set; }
        [Display(Name = "City Name")]
        public string? CityName { get; set; }
        public virtual Advertisement? Advertisement { get; set; }

    }
}
