using System;

namespace PrivateAccountant.Model.Classes
{
    public class Work
    {
        public int Id { get; set; }
        public Timesheet Timesheet { get; set; }
        public DateTime WorkStartDateTime { get; set; }
        public DateTime WorkEndDateTime { get; set; }
        public DateTime BreakStartDateTime { get; set; }
        public DateTime BreakEndDateTime { get; set; }
        public double WorkHours { get; set; }
    }
}