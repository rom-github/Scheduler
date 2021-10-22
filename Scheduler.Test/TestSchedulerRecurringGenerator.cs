using System;
using System.Collections;
using System.Collections.Generic;

namespace Scheduler.Test
{
    public class TestSchedulerRecurringGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 1, Convert.ToDateTime("15/06/2000"), Convert.ToDateTime("15/06/2000"), Convert.ToDateTime("15/06/2000")},
            new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 1, Convert.ToDateTime("15/06/2000"), null, Convert.ToDateTime("15/06/2000")},

            new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 1, Convert.ToDateTime("16/06/2000"), Convert.ToDateTime("17/06/2000"), Convert.ToDateTime("16/06/2000")},
            new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 1, Convert.ToDateTime("16/06/2000"), null, Convert.ToDateTime("16/06/2000")},

            new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 1, Convert.ToDateTime("14/06/2000"), Convert.ToDateTime("16/06/2000"), Convert.ToDateTime("15/06/2000")},
            new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 1, Convert.ToDateTime("14/06/2000"), null, Convert.ToDateTime("15/06/2000")}


            //new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("15/06/2000"), Convert.ToDateTime("15/06/2000"), (DateTime?)null},
            //new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("15/06/2000"), null, Convert.ToDateTime("18/06/2000")},

            //new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("16/06/2000"), Convert.ToDateTime("17/06/2000"), (DateTime?)null},
            //new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("16/06/2000"), null, Convert.ToDateTime("18/06/2000")},

            //new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("16/06/2000"), Convert.ToDateTime("17/06/2000"), (DateTime?)null}
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }
    public class TestSchedulerRecurringGenerator2 : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("15/06/2000"), Convert.ToDateTime("15/06/2000"), (DateTime?)null},
            new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("15/06/2000"), null, Convert.ToDateTime("18/06/2000")},

            new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("16/06/2000"), Convert.ToDateTime("17/06/2000"), (DateTime?)null},
            new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("16/06/2000"), null, Convert.ToDateTime("18/06/2000")},

            new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("16/06/2000"), Convert.ToDateTime("17/06/2000"), (DateTime?)null}
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }
}