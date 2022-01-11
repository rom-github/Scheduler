using FluentAssertions;
using System;
using Xunit;

namespace Scheduler.Test
{
    public class SchedulerRecurringDailyWithHoursShould
    {
        #region HOURS
        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Time_Every_1_Without_StartHou_Nor_EndHour()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 17, 13, 45, 0),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 15),
                TimeFrecuencyType = TimeFrecuencyTypes.Hour,
                TimeFrecuency = 1
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 17, 14, 0, 0));
            Assert.Equal("Occurs every day every hour between 00:00:00 and 23:59:59. Schedule will be used on 17/06/2000 14:00:00 starting on 15/06/2000", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Time_Every_1_Hours_CurrentDate_Between_StartHour_And_EndHour()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 17, 13, 45, 0),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 15),
                TimeFrecuencyType = TimeFrecuencyTypes.Hour,
                TimeFrecuency = 1,
                StartHour = new TimeSpan(10, 0, 0),
                EndHour = new TimeSpan(18, 0, 0)
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 17, 14, 0, 0));
            Assert.Equal("Occurs every day every hour between 10:00:00 and 18:00:00. Schedule will be used on 17/06/2000 14:00:00 starting on 15/06/2000", result.Value.Description);
        }

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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 17, 14, 0, 0));
            Assert.Equal("Occurs every day every 2 hours between 10:00:00 and 18:00:00. Schedule will be used on 17/06/2000 14:00:00 starting on 15/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 17, 10, 0, 0));
            Assert.Equal("Occurs every day every 2 hours between 10:00:00 and 18:00:00. Schedule will be used on 17/06/2000 10:00:00 starting on 15/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 18, 10, 0, 0));
            Assert.Equal("Occurs every day every 2 hours between 10:00:00 and 18:00:00. Schedule will be used on 18/06/2000 10:00:00 starting on 15/06/2000", result.Value.Description);
        }
        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Time_Every_2_Hours_CurrentDate_After_EndHour_And_Next_Date_Is_Null()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 17, 18, 0, 1),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 15),
                EndDate = new DateTime(2000, 6, 18, 6, 0, 0),
                TimeFrecuencyType = TimeFrecuencyTypes.Hour,
                TimeFrecuency = 2,
                StartHour = new TimeSpan(10, 0, 0),
                EndHour = new TimeSpan(18, 0, 0)
            };

            var result = Processor.GetNextExecution(configuration);

            result.Should().Be(null);
        }
        [Fact]
        internal void Calculate_Recurring_Daily_Every_5_Time_Every_2_Hours_CurrentDate_After_EndHour_And_Next_Date_Is_Null()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 17, 18, 0, 1),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 5,
                StartDate = new DateTime(2000, 6, 15),
                TimeFrecuencyType = TimeFrecuencyTypes.Hour,
                TimeFrecuency = 2,
                StartHour = new TimeSpan(10, 0, 0),
                EndHour = new TimeSpan(18, 0, 0)
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 20, 10, 0, 0));
            Assert.Equal("Occurs every 5 days every 2 hours between 10:00:00 and 18:00:00. Schedule will be used on 20/06/2000 10:00:00 starting on 15/06/2000", result.Value.Description);
        }
        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Time_Every_3_Hours_CurrentDate_Is_DateTimeMaxValue_And_Is_After_EndHour()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(9999, 12, 31, 19, 0, 0),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(9999, 12, 01),
                TimeFrecuencyType = TimeFrecuencyTypes.Hour,
                TimeFrecuency = 3,
                StartHour = new TimeSpan(10, 0, 0),
                EndHour = new TimeSpan(18, 0, 0)
            };

            var result = Processor.GetNextExecution(configuration);

            result.Should().Be(null);
        }
        [Fact]
        internal void Calculate_Recurring_Daily_Every_3_Time_Every_3_Hours_CurrentDate_Is_DateTimeMaxValue_And_Is_After_EndHour()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(9999, 12, 30, 19, 0, 0),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 5,
                StartDate = new DateTime(9999, 12, 20),
                TimeFrecuencyType = TimeFrecuencyTypes.Hour,
                TimeFrecuency = 3,
                StartHour = new TimeSpan(10, 0, 0),
                EndHour = new TimeSpan(18, 0, 0)
            };

            var result = Processor.GetNextExecution(configuration);

            result.Should().Be(null);
        }
        [Fact]
        internal void Calculate_Recurring_Weekly_Every_1_Time_Every_3_Hours_CurrentDate_Is_DateTimeMaxValue_And_Is_After_EndHour()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(9999, 12, 31, 19, 0, 0),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday },
                StartDate = new DateTime(9999, 12, 01),
                TimeFrecuencyType = TimeFrecuencyTypes.Hour,
                TimeFrecuency = 3,
                StartHour = new TimeSpan(10, 0, 0),
                EndHour = new TimeSpan(18, 0, 0)
            };

            var result = Processor.GetNextExecution(configuration);

            result.Should().Be(null);
        }
        #endregion

        #region MINUTES
        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Time_Every_30_Minutes_CurrentDate_Between_StartHour_And_EndHour()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 17, 13, 5, 0),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 15),
                TimeFrecuencyType = TimeFrecuencyTypes.Minute,
                TimeFrecuency = 30,
                StartHour = new TimeSpan(10, 0, 0),
                EndHour = new TimeSpan(18, 0, 0)
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 17, 13, 30, 0));
            Assert.Equal("Occurs every day every 30 minutes between 10:00:00 and 18:00:00. Schedule will be used on 17/06/2000 13:30:00 starting on 15/06/2000", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Time_Every_30_Minutes_CurrentDate_Before_StartHour()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 17, 09, 59, 59),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 15),
                TimeFrecuencyType = TimeFrecuencyTypes.Minute,
                TimeFrecuency = 30,
                StartHour = new TimeSpan(10, 0, 0),
                EndHour = new TimeSpan(18, 0, 0)
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 17, 10, 0, 0));
            Assert.Equal("Occurs every day every 30 minutes between 10:00:00 and 18:00:00. Schedule will be used on 17/06/2000 10:00:00 starting on 15/06/2000", result.Value.Description);
        }
        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Time_Every_30_Minutes_CurrentDate_After_EndHour()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 17, 18, 0, 1),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 15),
                TimeFrecuencyType = TimeFrecuencyTypes.Minute,
                TimeFrecuency = 30,
                StartHour = new TimeSpan(10, 0, 0),
                EndHour = new TimeSpan(18, 0, 0)
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 18, 10, 0, 0));
            Assert.Equal("Occurs every day every 30 minutes between 10:00:00 and 18:00:00. Schedule will be used on 18/06/2000 10:00:00 starting on 15/06/2000", result.Value.Description);
        }
        #endregion

        #region SECONDS
        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Time_Every_45_Seconds_CurrentDate_Between_StartHour_And_EndHour()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 17, 10, 1, 10),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 15),
                TimeFrecuencyType = TimeFrecuencyTypes.Second,
                TimeFrecuency = 45,
                StartHour = new TimeSpan(10, 0, 0),
                EndHour = new TimeSpan(18, 0, 0)
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 17, 10, 01, 30));
            Assert.Equal("Occurs every day every 45 seconds between 10:00:00 and 18:00:00. Schedule will be used on 17/06/2000 10:01:30 starting on 15/06/2000", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Time_Every_45_Seconds_CurrentDate_Before_StartHour()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 17, 09, 59, 59),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 15),
                TimeFrecuencyType = TimeFrecuencyTypes.Second,
                TimeFrecuency = 45,
                StartHour = new TimeSpan(10, 0, 0),
                EndHour = new TimeSpan(18, 0, 0)
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 17, 10, 0, 0));
            Assert.Equal("Occurs every day every 45 seconds between 10:00:00 and 18:00:00. Schedule will be used on 17/06/2000 10:00:00 starting on 15/06/2000", result.Value.Description);
        }
        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Time_Every_45_Seconds_CurrentDate_After_EndHour()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 17, 18, 0, 1),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 15),
                TimeFrecuencyType = TimeFrecuencyTypes.Second,
                TimeFrecuency = 45,
                StartHour = new TimeSpan(10, 0, 0),
                EndHour = new TimeSpan(18, 0, 0)
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 18, 10, 0, 0));
            Assert.Equal("Occurs every day every 45 seconds between 10:00:00 and 18:00:00. Schedule will be used on 18/06/2000 10:00:00 starting on 15/06/2000", result.Value.Description);
        }
        #endregion
    }
}