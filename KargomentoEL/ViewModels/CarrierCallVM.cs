using KargomentoEL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoEL.ViewModels
{
    public class CarrierCallVM : BaseNumericVM
    {

        public string CustomerId { get; set; }


        public CustomerVM? Customer
        {
            get; set;
        }

        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string CustomerAddressDetails { get; set; }

        public int BranchId { get; set; }


        public BranchVM? Branch { get; set; }

    }
}
