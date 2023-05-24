using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KargomentoEL.Models
{
    [Table("CarrierCalls")]
    public class CarrierCall:BaseNumeric
    {
        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [Required]
        [StringLength(150,MinimumLength =5)]
        public string CustomerAddressDetails { get; set; }

        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        
    }
}
