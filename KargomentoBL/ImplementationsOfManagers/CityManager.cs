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


namespace KargomentoBL.ImplementationsOfManagers
{
    public class CityManager : Manager<CityVM, City, int>, ICityManager
    {
        public CityManager(ICityRepo repo, IMapper mapper) : base(repo, mapper,null)
        {
        }
    }
}
