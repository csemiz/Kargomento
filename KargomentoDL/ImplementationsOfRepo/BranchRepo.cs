using KargomentoDL.InterfacesOfRepo;
using KargomentoEL.Models;

namespace KargomentoDL.ImplementationsOfRepo
{
    public class BranchRepo : Repository<Branch, int>, IBranchRepo
    {
        public BranchRepo(MyContext context) : base(context)
        {

        }
    }
}
