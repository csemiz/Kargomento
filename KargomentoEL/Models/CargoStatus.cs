using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoEL.Models
{
    [Table("CargoStatus")]

    public class CargoStatus:BaseNumeric
    {
        
      
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string StatusName { get; set; }
 
        [StringLength(100)]
        public string? StatusDescription { get; set; }

    }
   
}
