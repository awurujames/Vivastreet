using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivastreet_Models
{
    public class BaseDomain
    {

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
    }
}
