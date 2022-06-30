using System.ComponentModel.DataAnnotations.Schema;

namespace Vivastreet.Models
{
    public class SelectAge
    {
        public int Id { get; set; }
        public int Age { get; set; }

        public int AdvertisementId { get; set; }
        [ForeignKey("AdvertisementId")]
        public virtual Advertisement? Advertisement { get; set; }

    }
}