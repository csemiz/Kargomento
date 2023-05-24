using KargomentoDL.InterfacesOfRepo;
using KargomentoEL.Models;

namespace KargomentoDL.ImplementationsOfRepo;

public class CargoStatusRepo:Repository<CargoStatus,int>,ICargoStatusRepo
{
   
    public CargoStatusRepo(MyContext context) : base(context)
    {
    }
}