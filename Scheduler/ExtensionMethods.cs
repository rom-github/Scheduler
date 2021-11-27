using System;

namespace Scheduler
{
    public static class ExtensionMethods
    {
        public static DateTime? FirsDayOfWeek(this DateTime date)
        {
            if (date <= new DateTime(1, 1, 6))
            {
                return null;
            }
            return date.AddDays(-(int)date.DayOfWeek);
        }

        public static DateTime? AddSecondsNullable(this DateTime date, double numberOfSeconds)
        {
            if (numberOfSeconds > (DateTime.MaxValue - date).TotalSeconds)
            {
                return null;
            }
            return date.AddSeconds(numberOfSeconds);
        }

        public static DateTime? AddSecondsNullable(this DateTime date, int numberOfSeconds)
        {
            return ExtensionMethods.AddSecondsNullable(date, Convert.ToDouble(numberOfSeconds));
        }
    }
}