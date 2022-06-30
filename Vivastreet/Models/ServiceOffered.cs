using System.ComponentModel.DataAnnotations.Schema;

namespace Vivastreet.Models
{
    public class ServiceOffered
    {
        public int Id { get; set; }
        public bool SelectAll { get; set; }
        public bool Delivery { get; set; }
        public bool Pickup { get; set; }
        public bool Instalation { get; set; }
        public int AdvertisementId { get; set; }
        [ForeignKey("AdvertisementId")]
        public virtual Advertisement? Advertisement { get; set; }
    }
}
