using KargomentoDL.InterfacesOfRepo;
using KargomentoEL.Models;

namespace KargomentoDL.ImplementationsOfRepo
{
    public class CragoPayTypesRepo : Repository<CargoPayTypes, int>, ICargoPayTypesRepo
    {
        public CragoPayTypesRepo(MyContext context) : base(context)
        {

        }
    }
}
