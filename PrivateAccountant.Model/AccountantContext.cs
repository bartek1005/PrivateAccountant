using PrivateAccountant.Model.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateAccountant.Model
{
    public class AccountantContext : DbContext
    {
        public AccountantContext() : base("name=PrivateAccountant")
        {
            //Database.SetInitializer<AccountantContext>(null);
            //Database.SetInitializer<AccountantContext>(new DropCreateDatabaseAlways<AccountantContext>());
            Database.SetInitializer<AccountantContext>(new AccountantDBInitializer());

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<TravelDetail> TravelDetails { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<TimesheetFile> TimesheetFiles { get; set; }
    }
}
