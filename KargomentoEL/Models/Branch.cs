using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoEL.Models
{
    [Table("Branches")]
    public class Branch : BaseNumeric
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int DistrictId { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

    }
}
