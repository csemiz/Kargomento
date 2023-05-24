using AutoMapper;
using KargomentoBL.InterfacesOfManagers;
using KargomentoDL.InterfacesOfRepo;
using KargomentoEL.Models;
using KargomentoEL.ViewModels;

namespace KargomentoBL.ImplementationsOfManagers
{
    public class EmployeeBranchManager : Manager<EmployeeBranchVM, EmployeeBranch, int>
        ,IEmployeeBranchManager
    {
        public EmployeeBranchManager(IEmployeeBranchRepo repo, IMapper mapper) : base(repo, mapper, "Branch,Employee")
        {
        }
    }
}
            