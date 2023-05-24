using KargomentoEL.IdentityModels;
using KargomentoEL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoDL
{
    public class MyContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public MyContext(DbContextOptions<MyContext> options)
           : base(options)
        {

        }

        public DbSet<Branch> Branch { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<CargoPayRules> CargoPayRules { get; set; }
        public DbSet<CargoPayTypes> CargoPayTypes { get; set; }
        public DbSet<CargoStatus> CargoStatus { get; set; }
        public DbSet<CargoStatusProcess> CargoStatusProcess { get; set; }
        public DbSet<CarrierCall> CarrierCall { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<EmployeeBranch> EmployeeBranch { get; set; }

        
    }
}
