using System;

namespace Scheduler
{
    public class SchedulerConfiguration
    {
        public SchedulerConfiguration()
        {
        }

        public void SetOnce(DateTime currentDate, DateTime dateTime)
        {
            this.PeriodicityType = PeriodicityTypes.Once;
            this.CurrentDate = currentDate;
            this.DateTime = dateTime;
        }

        public void SetRecurring(DateTime currentDate, PeriodicityModes occurs, int every, DateTime startDate, DateTime? endDate)
        {
            if (every < 1)
            {
                throw new ArgumentOutOfRangeException("every", every, "Every must be greater than zero.");
            }

            if (endDate.HasValue && endDate.Value < startDate)
            {
                throw new ArgumentOutOfRangeException("endDate", endDate, "End date must be greater than start date or null.");
            }


            this.PeriodicityType = PeriodicityTypes.Recurring;
            this.CurrentDate = currentDate;
            this.Occurs = occurs;
            this.Every = every;
            this.StartDate = startDate;
            this.EndDate = endDate;
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