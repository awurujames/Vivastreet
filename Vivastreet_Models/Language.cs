﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Vivastreet_Models
{
    public class Language : BaseDomain
    {
        public int Id { get; set; }
        public bool English { get; set; }
        public bool Italian { get; set; }
        public bool Russian { get; set; }
        public bool Spanish { get; set; }
        public bool German { get; set; }
        public bool Chinese { get; set; }
        public bool French { get; set; }
        public bool Portugese { get; set; }
        public bool Other { get; set; }
        //public int AdvertisementId { get; set; }
        //[ForeignKey("AdvertisementId")]
        //public virtual Advertisement? Advertisement { get; set; }
    }
}
