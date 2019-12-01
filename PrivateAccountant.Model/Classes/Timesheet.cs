using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateAccountant.Model.Classes
{
    public class Timesheet
    {
        public Timesheet()
        {
            Company = new Company();
            Project = new Project();
            Work = new List<Work>();
            Travel = new Travel();
        }

        #region Properties
        public int Id { get; set; }
        public Company Company { get; set; }
        public Project Project { get; set; }
        public List<Work> Work { get; set; }
        public Travel Travel { get; set; }
        public DateTime Date { get; set; }
        public double WorkHours { get; set; }
        public double TravelHours { get; set; }
        public double BreakHours { get; set; }
        public bool IsHoliday { get; set; }
        public bool IsWeekendDay { get; set; }
        public double Overtimes { get; set; }
        public double Coefficient { get; set; }
        public double FinalOvertimes { get; set; }

        #endregion

        #region Methods
        private bool IsWeekend(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return true;
            else
                return false;
        }

        private double GetOvertimesCoefficient(bool isHoliday, bool isWeekendDay)
        {
            double coefficient = Informations.DEFAULT_OVERTIMES_COEFFICIENT;

            if (isHoliday || isWeekendDay)
                coefficient = Informations.HOLIDAY_WEEKEND_OVERTIMES_COEFFICIENT;

            return coefficient;
        }
        private double GetWorkHours(List<Work> worksList)
        {
            double workDuration = 0;
            double breakDuration = 0;
            foreach (var item in worksList)
            {
                breakDuration += (item.BreakEndDateTime - item.BreakStartDateTime).TotalMinutes / 60.0;
                workDuration += (item.WorkEndDateTime - item.WorkStartDateTime).GetDifferenceBetweenTwoDates();
            }

            return workDuration - breakDuration;
        }

        private double GetBreakHours(List<Work> worksList)
        {
            double breakDuration = 0;
            foreach (var item in worksList)
            {
                breakDuration += (item.BreakEndDateTime - item.BreakStartDateTime).TotalMinutes / 60.0;
            }
            return breakDuration;
        }

        private double GetOvertimes()
        {
            if (WorkHours > 8)
                return WorkHours - 8;
            else
                return 0;
        }
        private double GetFinalOvertimes(double overtimes, double coefficient)
        {
            return overtimes * coefficient;
        }
        public void CalculateTimesheetProperties()
        {
            this.IsWeekendDay = IsWeekend(this.Date);
            WorkHours = GetWorkHours(Work);
            BreakHours = GetBreakHours(Work);
            this.Overtimes = GetOvertimes();
            this.Coefficient = GetOvertimesCoefficient(this.IsHoliday, this.IsWeekendDay);
            this.FinalOvertimes = GetFinalOvertimes(this.Overtimes, this.Coefficient);
        }


        #endregion

    }
}
