using KargomentoDL.InterfacesOfRepo;
using KargomentoEL.Models;

namespace KargomentoDL.ImplementationsOfRepo
{
    public class CragoPayRulesRepo : Repository<CargoPayRules, int>, ICargoPayRulesRepo
    {
        public CragoPayRulesRepo(MyContext context) : base(context)
        {

        }
    }
}
