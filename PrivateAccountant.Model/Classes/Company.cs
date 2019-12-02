using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateAccountant.Model
{
    public class Company
    {
        public Company()
        {

        }
        public Company(string companyName)
        {
            CompanyName = companyName;
        }
        public int Id { get; set; }
        public string CompanyName { get; set; }
    }
}
