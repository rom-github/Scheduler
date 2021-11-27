using FluentAssertions;
using System;
using Xunit;

namespace Scheduler.Test
{
    public class SchedulerRecurringDailyWithHoursShould
    {
        #region Frecuency 1
        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_All_Dates_Are_Equal_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 17, 13, 0, 0),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 15),
                TimeFrecuencyType = TimeFrecuencyTypes.Hour,
                TimeFrecuency = 2,
                StartHour = new TimeSpan(10, 0, 0),
                EndHour = new TimeSpan(18, 0, 0)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 17, 14, 0, 0));
            Assert.Equal("Occurs every day. Schedule will be used on 17/06/2000 starting on 15/06/2000", Result.Value.Description);
        }
        #endregion
    }
}