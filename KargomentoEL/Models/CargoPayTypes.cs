using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoEL.Models
{
    public class CargoPayTypes:BaseNumeric
    {
       
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string PayTypesName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string PayTypesDescription { get; set; }
    }
}
