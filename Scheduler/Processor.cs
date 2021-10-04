using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Scheduler
{
    public class Processor
    {
        private SchedulerConfiguration configuration;
        private Timer timer;

        public Processor(SchedulerConfiguration TheConfiguration)
        {
            this.configuration = TheConfiguration;
            this.timer = new Timer(1000);


            throw new ApplicationException("Hasta aquí hemos llegado... :)");

        }
    }
}
