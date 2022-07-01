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
        public bool French { get; set; }
        public bool Italian { get; set; }
        public bool Spanish { get; set; }
        public bool German { get; set; }
        public bool Chinese { get; set; }
        public bool Russian { get; set; }
        public bool Other { get; set; }
        public bool English { get; set; }
        public bool Portugese { get; set; }
        public bool IsDeliveryService { get; set; }
        public string? DeliveryServiceFee { get; set; }
        public string? PickUpServiceFee { get; set; }
        public bool IsPickUpService { get; set; }
        public bool IsInstallationService { get; set; }
        public string? InstallationServiceFee { get; set; }
        public int Age { get; set; }
        public Category Category { get; set; }
        public Condition Condition { get; set; }
        public Material Material { get; set; }
        public ICollection<Rate>? Rates { get; set; }
    }
}
