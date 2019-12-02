using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateAccountant.Model.Classes
{
    public class Timesheet
    {
        public Timesheet(Work work)
        {
            Work = work;
            Date = work.Date;
            IsHoliday = work.IsHoliday;
            IsWeekendDay = work.IsWeekendDay;
            TotalWorkOvertimes = work.TotalOvertimes;
            TotalOvertimes = TotalWorkOvertimes;
        }
        public Timesheet(Travel travel)
        {
            Travel = travel;
            Date = travel.Date;
            IsHoliday = travel.IsHoliday;
            IsWeekendDay = travel.IsWeekendDay;
            TotalTravelOvertimes = travel.TotalOvertimes;
            TotalOvertimes = TotalTravelOvertimes;
        }
        public Timesheet(Work work, Travel travel)
        {
            Work = work;
            Travel = travel;
            Date = work.Date;
            IsHoliday = work.IsHoliday;
            IsWeekendDay = work.IsWeekendDay;
            TotalWorkOvertimes = work.TotalOvertimes;
            TotalTravelOvertimes = travel.TotalOvertimes;
            TotalOvertimes = TotalWorkOvertimes + TotalTravelOvertimes;
        }

        #region Properties
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Work Work { get; set; }
        public Travel Travel { get; set; }
        public bool IsHoliday { get; set; }
        public bool IsWeekendDay { get; set; }
        public double TotalWorkOvertimes { get; set; }
        public double TotalTravelOvertimes { get; set; }
        public double TotalOvertimes { get; set; }

        #endregion

        #region Methods
        

        #endregion

    }
}
