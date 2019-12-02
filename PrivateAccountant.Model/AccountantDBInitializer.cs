using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PrivateAccountant.Model.Classes;

namespace PrivateAccountant.Model
{
    public class AccountantDBInitializer : DropCreateDatabaseAlways<AccountantContext>
    {
        protected override void Seed(AccountantContext context)
        {
            List<Company> companyList = new List<Company>();
            companyList.Add(new Company("E80"));
            companyList.Add(new Company("GP"));

            Project project = new Project();
            project.Company = companyList.Where(c => c.CompanyName.Equals("gp", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            project.Country = "USA";

            context.Companies.AddRange(companyList);
            context.Projects.Add(project);
            context.SaveChanges();

            base.Seed(context); 
        }
    }
}
