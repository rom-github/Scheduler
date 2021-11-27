using FluentAssertions;
using System;
using Xunit;

namespace Scheduler.Test
{
    public class SchedulerRecurringDailyWithHoursShould
    {
        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Time_Every_2_Hours_CurrentDate_Between_StartHour_And_EndHour()
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
            Assert.Equal("Occurs every day every 2 hours between 10:00:00 and 18:00:00. Schedule will be used on 17/06/2000 14:00:00 starting on 15/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Time_Every_2_Hours_CurrentDate_Before_StartHour()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 17, 09, 59, 59),
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

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 17, 10, 0, 0));
            Assert.Equal("Occurs every day every 2 hours between 10:00:00 and 18:00:00. Schedule will be used on 17/06/2000 10:00:00 starting on 15/06/2000", Result.Value.Description);
        }
        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Time_Every_2_Hours_CurrentDate_After_EndHour()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 17, 18, 0, 1),
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
            Assert.Equal("Occurs every day every 2 hours between 10:00:00 and 18:00:00. Schedule will be used on 18/06/2000 10:00:00 starting on 15/06/2000", Result.Value.Description);
        }
    }
}