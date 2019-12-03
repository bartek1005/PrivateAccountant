using PrivateAccountant.DAL;
using PrivateAccountant.Model;
using PrivateAccountant.Model.Classes;
using PrivateAccountant.Model.PDFReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateAccountant
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repo = new Repository();
            //var works = repo.InsertWorks();
            //var travels = repo.InsertTravels();
            //var timesheets = repo.GetTimesheets(works, travels);
            PDFReader pDFReader = new PDFReader();
            pDFReader.ReadAcroFieldsFromPDF();

            using (var context = new AccountantContext())
            {
                
                context.Database.Log = Console.WriteLine;
                context.Works.AddRange(pDFReader.KeyValueWorks.Values);
                context.Travels.AddRange(pDFReader.KeyValueTravels.Values);
                context.Timesheets.AddRange(repo.GetTimesheets(pDFReader.KeyValueWorks.Values, pDFReader.KeyValueTravels.Values));
                context.SaveChanges();

            }
            Console.ReadLine();
        }
    }
}
