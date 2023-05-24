using KargomentoEL.IdentityModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace KargomentoEL.Models
{
    [Table("CargoStatusProcesses")]
    public class CargoStatusProcess:BaseNumeric
    {
        public string CargoId { get; set; }

        [ForeignKey("CargoId")]
        public virtual Cargo Cargo { get; set; }


        public int CargoStatusId { get; set; }

        [ForeignKey("CargoStatusId")]
        public virtual CargoStatus CargoStatus { get; set; }

        public string EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual AppUser AppUser { get; set; }

    }
}
