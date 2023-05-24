using KargomentoEL.IdentityModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace KargomentoEL.Models
{
    [Table("EmployeeBranches")]
    public class EmployeeBranch : BaseNumeric
    {
        public string EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual AppUser Employee { get; set; }

        public int BranchId { get; set; }


        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        public decimal? WeeklyTotalWorkHour { get; set; }

        public decimal? Salary { get; set; }

    }
}
