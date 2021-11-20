using System;

namespace Scheduler
{
    public static class ExtensionMethods
    {
        public static DateTime FirsDayOfWeek(this DateTime date)
        {
            if (date <= new DateTime(1, 1, 6))
            {
                return new DateTime(1, 1, 1);
            }
            return date.AddDays(-(int)date.DayOfWeek);
        }
    }
}
