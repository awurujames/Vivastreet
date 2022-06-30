using System.ComponentModel.DataAnnotations;

namespace Vivastreet.Models
{
    public class Advertisement  
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Title { get; set; }
        public int? PostCode { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        public string? Image { get; set; }
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Show phone number on advert ")]
        public bool ShowPhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        [Display(Name = "Premier Banner")]
        public bool PremierBanner { get; set; }

        [Display(Name = "Advert of the week")]
        public bool AddvertOTheWeek { get; set; }

        [Display(Name = "Classic Advert")]
        public bool ClassicAdvert { get; set; }
        public ICollection<Category>? Categories { get; set; }
        public ICollection<Condition>? Conditions { get; set; }
        public ICollection<Material>? Materials { get; set; }
        public ICollection<SelectAge>? Advertisements { get; set; }
        public ICollection<Language>? Languages { get; set; }
        public ICollection<Rate>? Rates { get; set; }
        public ICollection<ServiceOffered>? ServiceOffereds { get; set; }



    }
}
