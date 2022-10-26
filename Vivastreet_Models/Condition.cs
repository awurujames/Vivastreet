﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Vivastreet_Models
{
    public class Condition : BaseDomain
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        //public int AdvertisementId { get; set; }
        //[ForeignKey("AdvertisementId")]
        //public virtual Advertisement? Advertisement { get; set; }
    }

}
