using System;
using System.Collections;
using System.Collections.Generic;

namespace Scheduler.Test
{
    public class SchedulerDailyEvery1RecurringTestGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = 1,
                    StartDate = Convert.ToDateTime("15/06/2000"),
                    EndDate = Convert.ToDateTime("15/06/2000"),
                    Expected = Convert.ToDateTime("15/06/2000") }
            },
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = 1,
                    StartDate = Convert.ToDateTime("15/06/2000"),
                    EndDate = null,
                    Expected = Convert.ToDateTime("15/06/2000") }
            },

            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = 1,
                    StartDate = Convert.ToDateTime("16/06/2000"),
                    EndDate = Convert.ToDateTime("17/06/2000"),
                    Expected = Convert.ToDateTime("16/06/2000") }
            },
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = 1,
                    StartDate = Convert.ToDateTime("16/06/2000"),
                    EndDate = null,
                    Expected = Convert.ToDateTime("16/06/2000") }
            },

            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = 1,
                    StartDate = Convert.ToDateTime("14/06/2000"),
                    EndDate = Convert.ToDateTime("16/06/2000"),
                    Expected = Convert.ToDateTime("15/06/2000") }
            },
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = 1,
                    StartDate = Convert.ToDateTime("14/06/2000"),
                    EndDate = null,
                    Expected = Convert.ToDateTime("15/06/2000") }
            },

            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = 1,
                    StartDate = Convert.ToDateTime("12/06/2000"),
                    EndDate = Convert.ToDateTime("14/06/2000"),
                    Expected = (DateTime?)null }
            },
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = 1,
                    StartDate = Convert.ToDateTime("12/06/2000"),
                    EndDate = null,
                    Expected = Convert.ToDateTime("15/06/2000") }
            }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }

    public class SchedulerDailyEvery3RecurringTestGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = 1,
                    StartDate = Convert.ToDateTime("15/06/2000"),
                    EndDate = Convert.ToDateTime("15/06/2000"),
                    Expected = Convert.ToDateTime("15/06/2000") }
            },
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = 1,
                    StartDate = Convert.ToDateTime("15/06/2000"),
                    EndDate = null,
                    Expected = Convert.ToDateTime("15/06/2000") }
            },

            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = 1,
                    StartDate = Convert.ToDateTime("16/06/2000"),
                    EndDate = Convert.ToDateTime("17/06/2000"),
                    Expected = Convert.ToDateTime("16/06/2000") }
            },
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = 1,
                    StartDate = Convert.ToDateTime("16/06/2000"),
                    EndDate = null,
                    Expected = Convert.ToDateTime("16/06/2000") }
            },

            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = 1,
                    StartDate = Convert.ToDateTime("14/06/2000"),
                    EndDate = Convert.ToDateTime("16/06/2000"),
                    Expected = Convert.ToDateTime("15/06/2000") }
            },
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = 1,
                    StartDate = Convert.ToDateTime("14/06/2000"),
                    EndDate = null,
                    Expected = Convert.ToDateTime("15/06/2000") }
            },

            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = 1,
                    StartDate = Convert.ToDateTime("12/06/2000"),
                    EndDate = Convert.ToDateTime("14/06/2000"),
                    Expected = (DateTime?)null }
            },
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = 1,
                    StartDate = Convert.ToDateTime("12/06/2000"),
                    EndDate = null,
                    Expected = Convert.ToDateTime("15/06/2000") }
            }














            //new object[]
            //{ new TestRecurringConfig() {
            //        CurrentDate= Convert.ToDateTime("15/06/2000"),
            //        PeriodicityMode = PeriodicityModes.Daily,
            //        Every = 3,
            //        StartDate = Convert.ToDateTime("15/06/2000"),
            //        EndDate = Convert.ToDateTime("15/06/2000"),
            //        Expected = Convert.ToDateTime("15/06/2000") }
            //},
            //new object[]
            //{ new TestRecurringConfig() {
            //        CurrentDate= Convert.ToDateTime("15/06/2000"),
            //        PeriodicityMode = PeriodicityModes.Daily,
            //        Every = 3,
            //        StartDate = Convert.ToDateTime("14/06/2000"),
            //        EndDate = Convert.ToDateTime("15/06/2000"),
            //        Expected = (DateTime?)null }
            //}
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }



    //public class TestSchedulerRecurringGenerator : IEnumerable<object[]>
    //{
    //    private readonly List<object[]> _data = new List<object[]>
    //    {


    //        //new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("15/06/2000"), Convert.ToDateTime("15/06/2000"), (DateTime?)null},
    //        //new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("15/06/2000"), null, Convert.ToDateTime("18/06/2000")},

    //        //new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("16/06/2000"), Convert.ToDateTime("17/06/2000"), (DateTime?)null},
    //        //new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("16/06/2000"), null, Convert.ToDateTime("18/06/2000")},

    //        //new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("16/06/2000"), Convert.ToDateTime("17/06/2000"), (DateTime?)null}
    //    };

    //    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return _data.GetEnumerator();
    //    }
    //}
    //public class TestSchedulerRecurringGenerator2 : IEnumerable<object[]>
    //{
    //    private readonly List<object[]> _data = new List<object[]>
    //    {
    //        new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("15/06/2000"), Convert.ToDateTime("15/06/2000"), (DateTime?)null},
    //        new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("15/06/2000"), null, Convert.ToDateTime("18/06/2000")},

    //        new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("16/06/2000"), Convert.ToDateTime("17/06/2000"), (DateTime?)null},
    //        new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("16/06/2000"), null, Convert.ToDateTime("18/06/2000")},

    //        new object[] {Convert.ToDateTime("15/06/2000"), PeriodicityModes.Daily, 3, Convert.ToDateTime("16/06/2000"), Convert.ToDateTime("17/06/2000"), (DateTime?)null}
    //    };

    //    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return _data.GetEnumerator();
    //    }
    //}
}