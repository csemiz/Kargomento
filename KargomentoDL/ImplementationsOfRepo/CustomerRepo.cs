using KargomentoDL.InterfacesOfRepo;
using KargomentoEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoDL.ImplementationsOfRepo
{
    public class CustomerRepo : Repository<Customer, string>, ICustomerRepo
    {
        public CustomerRepo(MyContext context) : base(context)
        {
        }
    }
}
