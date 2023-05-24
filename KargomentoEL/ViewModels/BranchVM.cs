using KargomentoEL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoEL.ViewModels
{
    public class BranchVM:BaseNumericVM
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int DistrictId { get; set; }
        public  DistrictVM? District { get; set; }

    }
}
