using KargomentoDL.InterfacesOfRepo;
using KargomentoEL.Models;

namespace KargomentoDL.ImplementationsOfRepo;

public class CargoStatusProcessRepo:Repository<CargoStatusProcess,int>,ICargoStatusProcessRepo
{
    public CargoStatusProcessRepo(MyContext context) : base(context)
    {
    }
}