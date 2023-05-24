using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoEL.Models
{
    [Table("CargoPayRules")]

    public class CargoPayRules:BaseNumeric
    {

     
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string PayRulesName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string PayRulesDescription { get; set; }

    }
}
