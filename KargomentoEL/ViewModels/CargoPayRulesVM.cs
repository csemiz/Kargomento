using KargomentoEL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoEL.ViewModels
{
    public class CargoPayRulesVM: BaseNumeric
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string PayRulesName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string PayRulesDescription { get; set; }
    }
}
