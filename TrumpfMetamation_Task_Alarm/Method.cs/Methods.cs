using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrumpfMetamation_Task_Alarm.Method
{
    public class Methods
    {
        public static string HoursMinute(int hours, int minutes)
        {
            if (hours < 0 || hours > 23)
                throw new ArgumentOutOfRangeException(nameof(hours), "Hours must be between 0 and 23.");
            if (minutes < 0 || minutes > 59)
                throw new ArgumentOutOfRangeException(nameof(minutes), "Minutes must be between 0 and 59.");
            return $"{hours:00}:{minutes:00}";
        }

    }
}

