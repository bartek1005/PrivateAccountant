using PrivateAccountant.DAL;
using PrivateAccountant.Model;
using PrivateAccountant.Model.Classes;
using PrivateAccountant.Model.PDFReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateAccountant
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dat = DateTime.Parse("06/mag/2019", System.Globalization.CultureInfo.GetCultureInfo("it-IT"));
            string path = "C:\\Users\\Kawik.B\\Documents\\Timesheets";
            Repository repo = new Repository();
            var files = Directory.GetFiles(path);
            //var works = repo.InsertWorks();
            //var travels = repo.InsertTravels();
            //var timesheets = repo.GetTimesheets(works, travels);
            PDFReader pDFReader = new PDFReader();
            pDFReader.ReadAcroFieldsFromPDF(files);

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
