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

        public static DateTime? AddDaysNullable(this DateTime date, double numberOfDays)
        {
            if (numberOfDays > (DateTime.MaxValue - date).TotalDays)
            {
                return null;
            }
            return date.AddDays(numberOfDays);
        }

        public static DateTime? AddDaysNullable(this DateTime date, int numberOfDays)
        {
            return ExtensionMethods.AddDaysNullable(date, Convert.ToDouble(numberOfDays));
        }
    }
}