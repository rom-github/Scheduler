using System;

namespace Scheduler
{
    public class SchedulerResult
    {
        public SchedulerResult(int TheExecutionNumber, DateTime TheDateTime, string TheDescription)
        {
            this.ExecutionNumber = TheExecutionNumber;
            this.DateTime = TheDateTime;
            this.Description = TheDescription;
        }

        public int ExecutionNumber { get; private set; }
        public DateTime DateTime { get; private set; }
        public string Description { get; private set; }

        public string TextResult
        {
            get
            {
                return this.DateTime.ToShortDateString() + " " + this.DateTime.ToShortTimeString() + " " + this.Description;
            }
        }
    }
}
