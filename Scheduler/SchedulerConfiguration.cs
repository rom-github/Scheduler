using System;

namespace Scheduler
{
    public class SchedulerConfiguration
    {
        public DateTime CurrentDate { get; set; }

        public PeriodicityTypes PeriodicityType { get; set; }

        public DateTime? EventDate { get; set; }

        public PeriodicityModes? PeriodicityMode { get; set; }

        public int? Frecuency { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}