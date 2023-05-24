using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoEL.ViewModels
{
    public class CustomerVM :BaseNonNumericVM
    {
   
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Surname { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Email { get; set; }
    }
}
