using System.ComponentModel.DataAnnotations.Schema;

namespace Vivastreet.Models
{
    public class Category
    {
        public int Id { get; set; }


        public string? Name { get; set; }
        public int DisplayOder { get; set; }
        public int AdvertisementId { get; set; }

        [ForeignKey("AdvertisementId")]
        public virtual Advertisement? Advertisement { get; set; }
    }
}
