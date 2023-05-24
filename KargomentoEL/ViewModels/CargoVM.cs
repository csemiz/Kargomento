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
    public class CargoVM:BaseNonNumericVM
    {

        [StringLength(16, MinimumLength = 16)]
        public override string Id { get; set; }

        public int SenderBranchId { get; set; }

        public  BranchVM? SenderBranch { get; set; }

        public int ReceiverBranchId { get; set; }


        public  BranchVM? ReceiverBranch { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8)]
        public string ReceiverAddressDetails { get; set; }

        public string SenderId { get; set; }

 
        public  CustomerVM? Sender { get; set; }

        public string ReceiverId { get; set; }

        public  CustomerVM? Receiver { get; set; }

        public string? SenderAddressDetails { get; set; }

        [Required]
        public decimal Size { get; set; }

        public int CargoPayTypeId { get; set; }


        public  CargoPayTypesVM? CargoPayTypes { get; set; }

        [Required]
        public decimal Price { get; set; }

        public List<CargoStatusProcessVM>? CargoStatusProcess { get; set; }
    }
}
