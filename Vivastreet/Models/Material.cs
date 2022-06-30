using System.ComponentModel.DataAnnotations.Schema;

namespace Vivastreet.Models
{
    public class Material
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Durability { get; set; }
        public int AdvertisementId { get; set; }
        [ForeignKey("AdvertisementId")]
        public virtual Advertisement? Advertisement { get; set; }
    }
}
