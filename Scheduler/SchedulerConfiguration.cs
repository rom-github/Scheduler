using System;

namespace Scheduler
{
    public class SchedulerConfiguration
    {
        public SchedulerConfiguration()
        {
        }

        public void SetOnce(DateTime TheCurrentDate, DateTime? TheDateTime)
        {
            this.PeriodicityType = PeriodicityTypes.Once;
            this.CurrentDate = TheCurrentDate;
            this.DateTime = TheDateTime;
        }

        public void SetRecurring(DateTime TheCurrentDate, PeriodicityModes TheOccurs, int TheEvery, DateTime TheStartDate, DateTime? TheEndDate)
        {
            this.CurrentDate = TheCurrentDate;
            this.PeriodicityType = PeriodicityTypes.Recurring;
            this.Occurs = TheOccurs;
            this.Every = TheEvery;
            this.StartDate = TheStartDate;
            this.EndDate = TheEndDate;
        }

        public DateTime CurrentDate { get; private set; }

        public PeriodicityTypes PeriodicityType { get; private set; }

        public DateTime? DateTime { get; private set; }

        public PeriodicityModes? Occurs { get; private set; }

        public int? Every { get; private set; }

        public DateTime? StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }
    }
}