using PrivateAccountant.Model;
using PrivateAccountant.Model.Classes;
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
            using (var context = new AccountantContext())
            {
                context.Database.Log = Console.WriteLine;
                var timesheet = AddNewTimesheet();
                context.Timesheets.Add(timesheet);
                context.SaveChanges();

            }
            Console.ReadKey();
        }


        public static Timesheet AddNewTimesheet()
        {
            var work = new Work();
            work.WorkStartDateTime = DateTime.Parse("2019-11-26 07:15");
            work.WorkEndDateTime = DateTime.Parse("2019-11-26 21:30");
            work.BreakStartDateTime = DateTime.Parse("2019-11-26 12:45");
            work.BreakEndDateTime = DateTime.Parse("2019-11-26 13:30");

            var timesheet = new Timesheet();
            timesheet.Work.Add(work);
            timesheet.Date = DateTime.Parse("2019-11-26");
            timesheet.IsHoliday = false;
            timesheet.CalculateTimesheetProperties();

            return timesheet;

        }
    }
}
