using System.ComponentModel.DataAnnotations.Schema;

namespace Vivastreet.Models
{
    public class ServiceOffered
    {
        public bool SelectAll { get; set; }
        public bool Delivery { get; set; }
        public bool Pickup { get; set; }
        public bool Instalation { get; set; }
        public virtual Advertisement? Advertisement { get; set; }
    }
}
