using KargomentoDL.InterfacesOfRepo;
using KargomentoEL.Models;

namespace KargomentoDL.ImplementationsOfRepo;

public class CargoRepo:Repository<Cargo,string>,ICargoRepo
{
        public CargoRepo(MyContext context) : base(context)
        {
        }
}