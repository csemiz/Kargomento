using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoEL.IdentityModels
{
    public class AppRole  : IdentityRole
    {
        [StringLength(50, MinimumLength = 2)]
        public override string Name { get; set; }
    }
}
