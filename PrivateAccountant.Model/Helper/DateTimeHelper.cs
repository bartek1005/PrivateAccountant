using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateAccountant.Model
{

    public static class DateTimeHelper
    {
        public static double GetDifferenceBetweenTwoDates(this TimeSpan timeSpan)
        {
            return timeSpan.TotalMinutes / 60.0;
        }
    }
}
