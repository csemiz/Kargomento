using KargomentoEL.IdentityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KargomentoEL.Models
{
    [Table("Cargos")]
    public class Cargo : BaseNonNumeric
    {
        [StringLength(16, MinimumLength =16)]
        [Key] //PK
        [Column(Order = 1)]
        public override string Id { get; set; }
        public int SenderBranchId { get; set; }

        [ForeignKey("SenderBranchId")]
        public virtual Branch SenderBranch { get; set; }

        public int ReceiverBranchId { get; set; }

        [ForeignKey("ReceiverBranchId")]
        public virtual Branch ReceiverBranch { get; set; }

        [Required]
        [StringLength(100,MinimumLength = 8)]
        public string ReceiverAddressDetails { get; set; }

        public string SenderId { get; set; }

        [ForeignKey("SenderId")]
        public virtual Customer Sender { get; set; }

        public string ReceiverId { get; set; }

        [ForeignKey("ReceiverId")]
        public virtual Customer Receiver { get; set; }

        public string? SenderAddressDetails { get; set; }

        [Required]
        public decimal Size { get; set; }

        public int CargoPayTypeId { get; set; }

        [ForeignKey("CargoPayTypeId")]
        public virtual CargoPayTypes CargoPayTypes { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
