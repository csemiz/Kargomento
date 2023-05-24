using KargomentoEL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoEL.ViewModels
{
    public class DistrictVM :BaseNumericVM
    {


        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        public int CityId { get; set; }

        
        public  CityVM City { get; set; } // CityId propertysi Foregin KEy olacağı için burada City Tablosuyla ilişkisi kuruldu.

    }
}
