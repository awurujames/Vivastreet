using System.ComponentModel.DataAnnotations.Schema;

namespace Vivastreet_Models
{
    public class SelectAge : BaseDomain
    {
        public int Id { get; set; }
        public int Age { get; set; }

        //public int AdvertisementId { get; set; }
        //[ForeignKey("AdvertisementId")]
        //public virtual Advertisement? Advertisement { get; set; }

    }
}