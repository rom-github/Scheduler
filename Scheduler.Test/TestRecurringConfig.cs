using System;

namespace Scheduler.Test
{
    public class TestRecurringConfig
    {
        public DateTime CurrentDate { get; set; }
        public PeriodicityModes PeriodicityMode { get; set; }
        public int Every { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Expected { get; set; }
    }
}
