using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateAccountant.Model
{
    public class Salary
    {
        public Salary()
        {
            Company = new Company();
        }
        public int Id { get; set; }
        public Company Company { get; set; }
        public DateTime Period { get; set; }
        public double GrossSalary { get; set; }
        public double NetSalary { get; set; }
        public double Taxes { get { return this.GrossSalary - this.NetSalary; } }
    }
}
