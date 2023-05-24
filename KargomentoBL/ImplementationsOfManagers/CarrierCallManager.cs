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
using KargomentoDL.InterfacesOfRepo;
using KargomentoEL.Models;
using KargomentoEL.ViewModels;

namespace KargomentoBL.ImplementationsOfManagers
{
    public class CarrierCallManager : Manager<CarrierCallVM, CarrierCall, int>, ICarrierCallManager
    {
        public CarrierCallManager(ICarrierCallRepo repo, IMapper mapper) : base(repo, mapper, "Branch,Customer")
        {
        }
    }
}
