using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateAccountant.Model.Classes
{
    public abstract class Job
    {
        public Job()
        {
            StartDateTime = new DateTime(1753, 1, 1);
            EndDateTime = new DateTime(1753, 1, 1);
            BreakStartDateTime = null;
            BreakEndDateTime = null;
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsHoliday { get; set; }
        public bool IsWeekendDay { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime? BreakStartDateTime { get; set; }
        public DateTime? BreakEndDateTime { get; set; }
        public double Hours { get; set; }
        public double DayHours { get; set; }
        public double NightHours { get; set; }
        public double BreakHours { get; set; }
        public double DayBreakHours { get; set; }
        public double NightBreakHours { get; set; }
        public double Overtimes { get; set; }
        public double DayOvertimes { get; set; }
        public double NightOvertimes { get; set; }
        public double TotalOvertimes { get; set; }


        private void IsWeekend()
        {
            if (Date.DayOfWeek == DayOfWeek.Saturday || Date.DayOfWeek == DayOfWeek.Sunday)
                IsWeekendDay = true;
            else
                IsWeekendDay = false;
        }
        private void GetHours()
        {
            double workDuration = 0;
            double breakDuration = 0;

            if (BreakStartDateTime != null && BreakEndDateTime != null)
            {
                DateTime breakStart = (DateTime)BreakStartDateTime;
                DateTime breakEnd = (DateTime)BreakEndDateTime;
                breakDuration += (breakEnd - breakStart).TotalMinutes / 60.0;
            }

            workDuration += (EndDateTime - StartDateTime).GetDifferenceBetweenTwoDates();

            BreakHours = breakDuration;
            Hours = workDuration - breakDuration;

            GetNightHours();
            GetDayHours();
        }
        private void GetNightHours()
        {

            double nightBreakDuration = 0;
            double nightHours = 0;

            #region work
            if (StartDateTime.Day == EndDateTime.Day)
            {
                if (StartDateTime.Hour < 6)
                {
                    if (EndDateTime.Hour < 6)
                        nightHours += (EndDateTime - StartDateTime).GetDifferenceBetweenTwoDates();
                    else
                        nightHours += (6 - StartDateTime.Hour) - (0 - StartDateTime.Minute) / 60.0;
                }
                else if (StartDateTime.Hour >= 6 && StartDateTime.Hour < 22)
                {
                    if (EndDateTime.Hour >= 22)
                        nightHours += (EndDateTime.Hour - 22) - (0 - EndDateTime.Minute) / 60.0;
                    else
                        nightHours += 0;
                }
                else
                    nightHours += (EndDateTime - StartDateTime).GetDifferenceBetweenTwoDates();
            }

            else
            {
                if (StartDateTime.Hour < 6)
                {
                    if (EndDateTime.Hour < 6)
                        nightHours += (6 - StartDateTime.Hour) - (0 - StartDateTime.Minute) / 60.0
                             + 2
                             + (6 - EndDateTime.Hour) - (0 - EndDateTime.Minute) / 60.0;
                    else
                        nightHours += (6 - StartDateTime.Hour) - (0 - StartDateTime.Minute) / 60.0
                            + (EndDateTime.Hour - 22) - (0 - EndDateTime.Minute) / 60.0;
                }
                else if (StartDateTime.Hour >= 6 && StartDateTime.Hour < 22)
                {
                    if (EndDateTime.Hour < 6)
                        nightHours += 2 + EndDateTime.Hour + EndDateTime.Minute / 60.0;
                    else
                        nightHours += 2 + 6;
                }
                else
                {
                    if (EndDateTime.Hour < 6)
                        nightHours += (StartDateTime.Hour - 22) - (0 - StartDateTime.Minute) / 60.0
                            + (6 - EndDateTime.Hour) - (0 - EndDateTime.Minute) / 60.0;
                    else
                        nightHours += (StartDateTime.Hour - 22) - (0 - StartDateTime.Minute) / 60.0
                            + 6;
                }
            }
            #endregion
            #region break
            if (BreakStartDateTime != null && BreakEndDateTime != null)
            {
                DateTime breakStart = (DateTime)BreakStartDateTime;
                DateTime breakEnd = (DateTime)BreakEndDateTime;
                if (breakStart.Day == breakEnd.Day)
                {
                    if (breakStart.Hour < 6)
                    {
                        if (breakEnd.Hour < 6)
                            nightBreakDuration += (breakEnd - breakStart).GetDifferenceBetweenTwoDates();
                        else
                            nightBreakDuration += (6 - breakStart.Hour) - (0 - breakStart.Minute) / 60.0;
                    }
                    else if (breakStart.Hour >= 6 && breakStart.Hour < 22)
                    {
                        if (breakEnd.Hour >= 22)
                            nightBreakDuration += (breakEnd.Hour - 22) - (0 - breakEnd.Minute) / 60.0;
                        else
                            nightBreakDuration += 0;
                    }
                    else
                        nightBreakDuration += (breakEnd - breakStart).GetDifferenceBetweenTwoDates();
                }


                else
                {
                    if (breakStart.Hour < 6)
                    {
                        if (breakEnd.Hour < 6)
                            nightBreakDuration += (6 - breakStart.Hour) - (0 - breakStart.Minute) / 60.0
                                 + 2
                                 + (6 - breakEnd.Hour) - (0 - breakEnd.Minute) / 60.0;
                        else
                            nightBreakDuration += (6 - breakStart.Hour) - (0 - breakStart.Minute) / 60.0
                                + (breakEnd.Hour - 22) - (0 - breakEnd.Minute) / 60.0;
                    }
                    else if (breakStart.Hour >= 6 && breakStart.Hour < 22)
                    {
                        if (breakEnd.Hour < 6)
                            nightBreakDuration += 2 + (6 - breakEnd.Hour) - (0 - breakEnd.Minute) / 60.0;
                        else
                            nightBreakDuration += 2 + 6;
                    }
                    else
                    {
                        if (breakEnd.Hour < 6)
                            nightBreakDuration += (breakStart.Hour - 22) - (0 - breakStart.Minute) / 60.0
                                + (6 - breakEnd.Hour) - (0 - breakEnd.Minute) / 60.0;
                        else
                            nightBreakDuration += (breakStart.Hour - 22) - (0 - breakStart.Minute) / 60.0
                                + 6;
                    }
                }
            }
            else
                nightBreakDuration = 0;
            #endregion

            NightBreakHours = nightBreakDuration;
            NightHours = nightHours;

        }
        private void GetDayHours()
        {
            DayHours = Hours - NightHours;
            DayBreakHours = BreakHours - NightBreakHours;
        }
        private void GetOvertimes()
        {
            if (IsHoliday || IsWeekendDay)
                Overtimes = Hours;
            else
            {
                if (Hours > 8)
                    Overtimes = Hours - 8;
                else
                    Overtimes = 0;
            }

            GetDayOvertimes();
            GetNightOvertimes();

        }
        private void GetDayOvertimes()
        {
            if (IsWeekendDay || IsHoliday)
                DayOvertimes = DayHours;
            else
                DayOvertimes = Math.Max(DayHours - 8,0);
        }
        private void GetNightOvertimes()
        {
            if (IsWeekendDay || IsHoliday)
                NightOvertimes = NightHours;
            else
            {
                if (DayHours >= 8)
                    NightOvertimes = Math.Max(NightHours, 0);
                else
                    NightOvertimes = Math.Max(DayHours + NightHours - 8, 0);
            }
        }

        private void GetTotalOvertimes()
        {
            double coefficient = (IsHoliday || Date.DayOfWeek == DayOfWeek.Sunday) ? 2 : 1.5;
            TotalOvertimes = DayOvertimes * coefficient + NightOvertimes * 2;
        }

        public void CalculateProperties()
        {
            if(BreakStartDateTime !=null && BreakEndDateTime == null)
            {
                EndDateTime = (DateTime)BreakStartDateTime;
                BreakStartDateTime = null;
                BreakEndDateTime = null;
            }
            Date = StartDateTime.Date;
            IsHoliday = Date == new DateTime(2019, 11, 11) ? true : false;
            IsWeekend();
            GetHours();
            GetOvertimes();
            GetTotalOvertimes();
        }
    }

}
