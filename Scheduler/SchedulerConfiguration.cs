using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class SchedulerConfiguration
    {
        public PeriodicityTypes PeriodicityType { get; private set; }
        public DateTime InitialDateTime { get; private set; }
        public PeriodicityModes PeriodicityMode { get; private set; }
        public int Frecuency { get; private set; }
        public DateTime FinnalDateTime { get; private set; }
    }
}
