﻿using System;

namespace Scheduler
{
    public class SchedulerResult
    {
        public SchedulerResult(DateTime TheDateTime, string TheDescription)
        {
            this.DateTime = TheDateTime;
            this.Description = TheDescription;
        }

        public DateTime DateTime { get; private set; }
        public string Description { get; private set; }
    }
}
