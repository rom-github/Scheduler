using System;
using System.Collections;
using System.Collections.Generic;

namespace Scheduler.Test
{
    public class TestSchedulerOnceGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {Convert.ToDateTime("15/06/2000"), Convert.ToDateTime("15/06/2000"), Convert.ToDateTime("15/06/2000")},
            new object[] {Convert.ToDateTime("14/06/2000"), Convert.ToDateTime("15/06/2000"), Convert.ToDateTime("15/06/2000")},
            new object[] {Convert.ToDateTime("15/06/2000"), Convert.ToDateTime("14/06/2000"), (DateTime?)null},

            new object[] {DateTime.MinValue, DateTime.MinValue, DateTime.MinValue},
            new object[] {DateTime.MaxValue, DateTime.MaxValue, DateTime.MaxValue},

            new object[] {DateTime.MinValue, DateTime.MaxValue, DateTime.MaxValue},
            new object[] {DateTime.MaxValue, DateTime.MinValue, (DateTime?)null }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }
}