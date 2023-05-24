using KargomentoDL.InterfacesOfRepo;
using KargomentoEL.Models;

namespace KargomentoDL.ImplementationsOfRepo;

public class CarrierCallRepo:Repository<CarrierCall,int>,ICarrierCallRepo
{
    
    public CarrierCallRepo(MyContext context) : base(context)
    {
    }
}