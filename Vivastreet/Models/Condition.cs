using System.ComponentModel.DataAnnotations.Schema;

namespace Vivastreet.Models
{
    public class Condition
    {
        public string? Perfect { get; set; }
        public string? Good { get; set; }
        public string? Fair { get; set; }

        public int AdvertisementId { get; set; }
        [ForeignKey("AdvertisementId")]
        public virtual Advertisement? Advertisement { get; set; }
    }

}
