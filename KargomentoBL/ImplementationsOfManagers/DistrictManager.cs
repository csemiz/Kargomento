using AutoMapper;
using KargomentoBL.InterfacesOfManagers;
using KargomentoDL.InterfacesOfRepo;
using KargomentoEL.Models;
using KargomentoEL.ViewModels;

namespace KargomentoBL.ImplementationsOfManagers
{
    public class DistrictManager : Manager<DistrictVM, District, int>, IDistrictManager
    {
        public DistrictManager(IDistrictRepo repo, IMapper mapper) : base(repo, mapper, "City")
        {

        }
    }
}
