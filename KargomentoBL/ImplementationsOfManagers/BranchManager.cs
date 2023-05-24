using AutoMapper;
using KargomentoBL.InterfacesOfManagers;
using KargomentoDL.InterfacesOfRepo;
using KargomentoEL.Models;
using KargomentoEL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoBL.ImplementationsOfManagers
{
    public class BranchManager : Manager<BranchVM, Branch, int>, IBranchManager
    {
        public BranchManager(IBranchRepo repo, IMapper mapper)
            : base(repo, mapper, "District")
        {
        }
    }
}
