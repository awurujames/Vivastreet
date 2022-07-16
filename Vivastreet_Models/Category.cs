using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vivastreet_Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]  
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Display Order")]
        [Range(1, int.MaxValue, ErrorMessage = "Display Order greater than 0")]
        public int DisplayOder { get; set; }
        //public int AdvertisementId { get; set; }

        //[ForeignKey("AdvertisementId")]
        //public virtual Advertisement? Advertisement { get; set; }
    }
}
