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

                var works = GenerateWorks();
                var travels = GenerateTravels();
                var timesheetsList = new List<Timesheet>();

                context.Works.AddRange(works);
                context.Travels.AddRange(travels);
                foreach (var item in works)
                {
                    context.Timesheets.Add(new Timesheet(item));
                }
                foreach (var item in travels)
                {
                    context.Timesheets.Add(new Timesheet(item));
                }
                context.SaveChanges();

            }
            Console.ReadKey();
        }



        public static Timesheet AddNewTimesheets()
        {


            var work = new Work();
            work.StartDateTime = DateTime.Parse("2019-11-26 07:15");
            work.EndDateTime = DateTime.Parse("2019-11-26 21:30");
            work.BreakStartDateTime = DateTime.Parse("2019-11-26 12:45");
            work.BreakEndDateTime = DateTime.Parse("2019-11-26 13:30");
            work.CalculateProperties();

            var work1 = new Work();
            work1.StartDateTime = DateTime.Parse("2019-11-29 07:00");
            work1.EndDateTime = DateTime.Parse("2019-11-29 23:00");
            work1.BreakStartDateTime = DateTime.Parse("2019-11-29 17:00");
            work1.BreakEndDateTime = DateTime.Parse("2019-11-29 20:00");
            work1.CalculateProperties();

            var timesheet = new Timesheet(work);
            timesheet.IsHoliday = false;

            return timesheet;
        }

        public static IList<Work> GenerateWorks()
        {
            Work work1 = new Work()
            {
                StartDateTime = new DateTime(2019, 11, 11, 8, 30, 0),
                EndDateTime = new DateTime(2019, 11, 12, 0, 0, 0),
                BreakStartDateTime = new DateTime(2019, 11, 11, 12, 30, 0),
                BreakEndDateTime = new DateTime(2019, 11, 11, 13, 30, 0)
            };
            Work work2 = new Work()
            {
                StartDateTime = new DateTime(2019, 11, 12, 8, 30, 0),
                EndDateTime = new DateTime(2019, 11, 13, 1, 0, 0),
                BreakStartDateTime = new DateTime(2019, 11, 12, 12, 30, 0),
                BreakEndDateTime = new DateTime(2019, 11, 12, 13, 30, 0)
            };
            Work work3 = new Work()
            {
                StartDateTime = new DateTime(2019, 11, 13, 8, 30, 0),
                EndDateTime = new DateTime(2019, 11, 14, 0, 0, 0),
                BreakStartDateTime = new DateTime(2019, 11, 13, 12, 30, 0),
                BreakEndDateTime = new DateTime(2019, 11, 13, 13, 30, 0)
            };
            Work work4 = new Work()
            {
                StartDateTime = new DateTime(2019, 11, 14, 8, 30, 0),
                EndDateTime = new DateTime(2019, 11, 14, 20, 0, 0),
                BreakStartDateTime = new DateTime(2019, 11, 14, 12, 30, 0),
                BreakEndDateTime = new DateTime(2019, 11, 14, 13, 30, 0)
            };
            Work work5 = new Work()
            {
                StartDateTime = new DateTime(2019, 11, 19, 9, 0, 0),
                EndDateTime = new DateTime(2019, 11, 19, 19, 0, 0),
                BreakStartDateTime = new DateTime(2019, 11, 19, 13, 0, 0),
                BreakEndDateTime = new DateTime(2019, 11, 19, 14, 0, 0)
            };
            Work work6 = new Work()
            {
                StartDateTime = new DateTime(2019, 11, 20, 7, 0, 0),
                EndDateTime = new DateTime(2019, 11, 20, 19, 15, 0),
                BreakStartDateTime = new DateTime(2019, 11, 20, 13, 0, 0),
                BreakEndDateTime = new DateTime(2019, 11, 20, 14, 0, 0)
            };
            Work work7 = new Work()
            {
                StartDateTime = new DateTime(2019, 11, 21, 7, 0, 0),
                EndDateTime = new DateTime(2019, 11, 21, 20, 0, 0),
                BreakStartDateTime = new DateTime(2019, 11, 21, 13, 0, 0),
                BreakEndDateTime = new DateTime(2019, 11, 21, 14, 0, 0)
            };
            Work work8 = new Work()
            {
                StartDateTime = new DateTime(2019, 11, 22, 7, 0, 0),
                EndDateTime = new DateTime(2019, 11, 22, 20, 0, 0),
                BreakStartDateTime = new DateTime(2019, 11, 22, 13, 0, 0),
                BreakEndDateTime = new DateTime(2019, 11, 22, 14, 0, 0)
            };
            Work work9 = new Work()
            {
                StartDateTime = new DateTime(2019, 11, 23, 8, 0, 0),
                EndDateTime = new DateTime(2019, 11, 23, 14, 0, 0),

            };
            Work work10 = new Work()
            {
                StartDateTime = new DateTime(2019, 11, 25, 7, 0, 0),
                EndDateTime = new DateTime(2019, 11, 25, 20, 0, 0),
                BreakStartDateTime = new DateTime(2019, 11, 25, 13, 0, 0),
                BreakEndDateTime = new DateTime(2019, 11, 25, 14, 0, 0)
            };
            Work work11 = new Work()
            {
                StartDateTime = new DateTime(2019, 11, 26, 7, 0, 0),
                EndDateTime = new DateTime(2019, 11, 26, 21, 15, 0),
                BreakStartDateTime = new DateTime(2019, 11, 26, 13, 0, 0),
                BreakEndDateTime = new DateTime(2019, 11, 26, 14, 0, 0)
            };
            Work work12 = new Work()
            {
                StartDateTime = new DateTime(2019, 11, 27, 7, 0, 0),
                EndDateTime = new DateTime(2019, 11, 27, 19, 30, 0),
                BreakStartDateTime = new DateTime(2019, 11, 27, 13, 0, 0),
                BreakEndDateTime = new DateTime(2019, 11, 27, 14, 0, 0)
            };
            Work work13 = new Work()
            {
                StartDateTime = new DateTime(2019, 11, 28, 7, 0, 0),
                EndDateTime = new DateTime(2019, 11, 28, 18, 30, 0),
                BreakStartDateTime = new DateTime(2019, 11, 28, 13, 0, 0),
                BreakEndDateTime = new DateTime(2019, 11, 28, 14, 0, 0)
            };
            Work work14 = new Work()
            {
                StartDateTime = new DateTime(2019, 11, 29, 7, 0, 0),
                EndDateTime = new DateTime(2019, 11, 29, 23, 0, 0),
                BreakStartDateTime = new DateTime(2019, 11, 29, 17, 0, 0),
                BreakEndDateTime = new DateTime(2019, 11, 29, 20, 0, 0)
            };
            Work work15 = new Work()
            {
                StartDateTime = new DateTime(2019, 11, 30, 8, 0, 0),
                EndDateTime = new DateTime(2019, 11, 30, 13, 0, 0),
            };
            IList<Work> workList = new List<Work> { work1, work2, work3, work4, work5, work6, work7, work8, work9, work10, work11, work12, work13, work14, work15 };
            foreach (var item in workList)
            {
                item.CalculateProperties();
            }
            return workList;
        }
        public static IList<Travel> GenerateTravels()
        {
            Travel t1 = new Travel()
            {
                StartDateTime = new DateTime(2019, 11, 10, 15, 0, 0),
                EndDateTime = new DateTime(2019, 11, 11, 0, 0, 0)
            };
            Travel t2 = new Travel()
            {
                StartDateTime = new DateTime(2019, 11, 15, 8, 30, 0),
                EndDateTime = new DateTime(2019, 11, 15, 18, 0, 0)
            };
            Travel t3 = new Travel()
            {
                StartDateTime = new DateTime(2019, 11, 18, 11, 0, 0),
                EndDateTime = new DateTime(2019, 11, 19, 9, 0, 0)
            };
            IList<Travel> travels = new List<Travel> { t1, t2, t3 };
            foreach (var item in travels)
            {
                item.CalculateProperties();
            }
            return travels;
        }
    }
}
