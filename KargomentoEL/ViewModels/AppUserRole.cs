using KargomentoEL.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoEL.ViewModels
{
    public class AppUserRole
    {
        public AppUser User { get; set; }
        public AppRole? Role { get; set; }
        public string RoleId { get; set; }
        public  string? RoleName { get; set; }
        public string? BranchName { get; set; }
        //public aspnetuserrole ? AppUserRole { get; set; }
    }
}
