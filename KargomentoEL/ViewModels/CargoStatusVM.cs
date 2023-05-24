using KargomentoEL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoEL.ViewModels
{
    public class CargoStatusVM: BaseNumeric
    {

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string StatusName { get; set; }

        [StringLength(100)]
        public string? StatusDescription { get; set; }
    }
}
