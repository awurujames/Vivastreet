using System.ComponentModel.DataAnnotations;

namespace Vivastreet_Models
{
    public class City
    {
        public int Id { get; set; }
        public string Abuja { get; set; }
        public string Lagos { get; set; }
        [Display(Name = "Port Harcourt")]
        public string PortHarcourt { get; set; }
        public string Kano { get; set; }
        public string Benin { get; set; }
    }
}
