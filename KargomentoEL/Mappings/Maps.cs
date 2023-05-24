using AutoMapper;
using KargomentoEL.Models;
using KargomentoEL.ViewModels;

namespace KargomentoEL.Mappings;

public class Maps : Profile
{
    public Maps()
    {
        //Automapper ile modellerimiz ile vmlerimizi birleştirdik.
        CreateMap<Branch, BranchVM>().ReverseMap();
        CreateMap<Cargo, CargoVM>().ReverseMap();
        CreateMap<CargoPayRules, CargoPayRulesVM>().ReverseMap();
        CreateMap<CargoPayTypes, CargoPayTypesVM>().ReverseMap();
        CreateMap<CargoStatus, CargoStatusVM>().ReverseMap();
        CreateMap<CargoStatusProcess, CargoStatusProcessVM>().ReverseMap();
        CreateMap<CarrierCall, CarrierCallVM>().ReverseMap();
        CreateMap<City, CityVM>().ReverseMap();
        CreateMap<Customer, CustomerVM>().ReverseMap();
        CreateMap<District, DistrictVM>().ReverseMap();
        CreateMap<EmployeeBranch, EmployeeBranchVM>().ReverseMap();
        
    }
}