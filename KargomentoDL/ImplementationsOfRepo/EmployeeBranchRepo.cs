using KargomentoDL.InterfacesOfRepo;
using KargomentoEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoDL.ImplementationsOfRepo
{
    public class EmployeeBranchRepo : Repository<EmployeeBranch, int>, IEmployeeBranchRepo
    {
        public EmployeeBranchRepo(MyContext context) : base(context)
        {
        }
    }
}
