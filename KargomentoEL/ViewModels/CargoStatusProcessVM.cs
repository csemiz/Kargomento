using KargomentoEL.IdentityModels;
using KargomentoEL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoEL.ViewModels
{
    public class CargoStatusProcessVM: BaseNumeric
    {


        public string CargoId { get; set; }
        public Cargo? Cargo { get; set; }
        public int CargoStatusId { get; set; }
        public CargoStatusVM? CargoStatus { get; set; }
        public string EmployeeId { get; set; }
        public AppUser? AppUser { get; set; }

    }
}
