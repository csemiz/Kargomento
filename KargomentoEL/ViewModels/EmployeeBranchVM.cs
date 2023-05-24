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
    public class EmployeeBranchVM:BaseNumericVM
    {

        public string EmployeeId { get; set; }


        public  AppUser? Employee { get; set; }

        public int BranchId { get; set; }


        public  BranchVM? Branch { get; set; }

        public decimal? WeeklyTotalWorkHour { get; set; }

        public decimal? Salary { get; set; }


    }
}
