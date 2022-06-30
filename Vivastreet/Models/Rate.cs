using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vivastreet.Models
{
    public class Rate
    {
        public int Id { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Delivery rate must be greater than 0")]
        public decimal? Delivery { get; set; }
        [Display(Name = "Local PickUp")]
        [Range(1, int.MaxValue, ErrorMessage = "Pick up rate must be greater than 0")]
        public decimal? LocalPickUp { get; set; }
        public virtual Advertisement? Advertisement { get; set; }
    }
}
