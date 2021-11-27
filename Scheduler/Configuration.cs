using System;

namespace Scheduler
{
    public class Configuration
    {
        public DateTime? CurrentDate { get; set; }

        public PeriodicityModes PeriodicityMode { get; set; }

        public DateTime? EventDate { get; set; }

        public DateFrecuencyTypes? DateFrecuencyType { get; set; }

        public int? DateFrecuency { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public TimeFrecuencyTypes? TimeFrecuencyType { get; set; }
        
        public int? TimeFrecuency { get; set; }

        public TimeSpan? StartHour { get; set; }

        public TimeSpan? EndHour { get; set; }

        public DayOfWeek[] DaysOfWeek;
    }
}