using System;

namespace Scheduler
{
    public struct Result
    {
        public Result(DateTime? dateTime, string description)
        {
            this.DateTime = dateTime;
            this.Description = description;
        }

        public DateTime? DateTime { get; private set; }
        public string Description { get; private set; }
    }
}