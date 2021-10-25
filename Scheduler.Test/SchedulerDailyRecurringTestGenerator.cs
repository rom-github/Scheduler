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
        static int everyVar = 3;

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("15/06/2000"),
                    EndDate = Convert.ToDateTime("15/06/2000"),
                    Expected = Convert.ToDateTime("15/06/2000")
            }
            },
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("15/06/2000"),
                    EndDate = null,
                    Expected = Convert.ToDateTime("15/06/2000") }
            },

            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("14/06/2000"),
                    EndDate = Convert.ToDateTime("15/06/2000"),
                    Expected = (DateTime?)null }
            },
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("14/06/2000"),
                    EndDate = null,
                    Expected = Convert.ToDateTime("17/06/2000") }
            },

            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("13/06/2000"),
                    EndDate = Convert.ToDateTime("15/06/2000"),
                    Expected = (DateTime?)null }
            },
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("13/06/2000"),
                    EndDate = null,
                    Expected = Convert.ToDateTime("16/06/2000") }
            },

            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("12/06/2000"),
                    EndDate = Convert.ToDateTime("15/06/2000"),
                    Expected = Convert.ToDateTime("15/06/2000") }
            },
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("12/06/2000"),
                    EndDate = null,
                    Expected = Convert.ToDateTime("15/06/2000") }
            },

            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("12/06/2000"),
                    EndDate = Convert.ToDateTime("15/06/2000"),
                    Expected = Convert.ToDateTime("15/06/2000") }
            },
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("12/06/2000"),
                    EndDate = null,
                    Expected = Convert.ToDateTime("15/06/2000") }
            },

            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("01/06/2000"),
                    EndDate = Convert.ToDateTime("12/06/2000"),
                    Expected = (DateTime?)null }
            },
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("01/06/2000"),
                    EndDate = null,
                    Expected = Convert.ToDateTime("16/06/2000")  }
            },

            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("21/06/2000"),
                    EndDate = Convert.ToDateTime("30/06/2000"),
                    Expected = Convert.ToDateTime("21/06/2000") }
            },
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("21/06/2000"),
                    EndDate = null,
                    Expected = Convert.ToDateTime("21/06/2000") }
            }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }
    public class SchedulerDailyEvery100RecurringTestGenerator : IEnumerable<object[]>
    {
        static int everyVar = 100;

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("14/06/2000"),
                    EndDate = Convert.ToDateTime("30/06/2000"),
                    Expected = (DateTime?)null
            }
            },
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("14/06/2000"),
                    EndDate = null,
                    Expected = Convert.ToDateTime("22/09/2000") }
            },

            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("31/07/1998"),
                    EndDate = Convert.ToDateTime("30/06/2000"),
                    Expected = Convert.ToDateTime("30/06/2000") }
            },
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("31/07/1998"),
                    EndDate = Convert.ToDateTime("30/06/2000"),
                    Expected = Convert.ToDateTime("30/06/2000") }
            },

            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("31/07/1998"),
                    EndDate = Convert.ToDateTime("30/06/2000"),
                    Expected = Convert.ToDateTime("30/06/2000") }
            },
            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("31/07/1998"),
                    EndDate = null,
                    Expected = Convert.ToDateTime("30/06/2000") }
            },

            new object[]
            { new TestRecurringConfig() {
                    CurrentDate= Convert.ToDateTime("15/06/2000"),
                    PeriodicityMode = PeriodicityModes.Daily,
                    Every = everyVar,
                    StartDate = Convert.ToDateTime("31/07/1998"),
                    EndDate = Convert.ToDateTime("29/06/2000"),
                    Expected = (DateTime?)null }
            }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }
}