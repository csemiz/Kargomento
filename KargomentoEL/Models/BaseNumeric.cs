using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoEL.Models
{
   
    
        public class BaseNumeric
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key] //PK
            [Column(Order = 1)]
            public int Id { get; set; }
            [Column(Order = 2)]
            public DateTime CreatedDate { get; set; }
            public bool IsRemoved { get; set; }
        }
    }

