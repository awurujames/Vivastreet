using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vivastreet.Models
{
    public class Material
    {
        public int Id { get; set; }
        [Required] 
        public string? Name { get; set; }
        [Required]
        public string? Type { get; set; }
        [Required]
        public string? Durability { get; set; }
        //public int AdvertisementId { get; set; }
        //[ForeignKey("AdvertisementId")]
        //public virtual Advertisement? Advertisement { get; set; }
    }
}
