using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoEL.Models
{
    [Table("Districts")]

    public class District : BaseNumeric
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")] //CityId'ye yazdığım int değerinin City tablosunda karşılığı olmak zorunda
        public virtual City City { get; set; } // CityId propertysi Foregin KEy olacağı için burada City Tablosuyla ilişkisi kuruldu.

        //DİPNOT: İlişkiler burada kurulacağı gibi MYCONTEXT classı içindeki OnModelCreating metodu ezilerek (override) kurulabilir.


    }
}
