using System;

namespace Scheduler
{
    public class Configuration
    {
        public DateTime? CurrentDate { get; set; }

        public PeriodicityTypes PeriodicityType { get; set; }

        public DateTime? EventDate { get; set; }

        public PeriodicityModes? PeriodicityMode { get; set; }

        public int? Frecuency { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DailyFrecuencyTypes? DailyFrecuencyType { get; set; }
        
        public int? EveryDailyFrecuencyType { get; set; }

        public TimeSpan? StartHour { get; set; }

        public TimeSpan? EndHour { get; set; }

        public DayOfWeek[] DaysOfWeek;
    }
}