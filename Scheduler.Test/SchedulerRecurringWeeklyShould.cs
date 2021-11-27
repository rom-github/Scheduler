using FluentAssertions;
using System;
using Xunit;

namespace Scheduler.Test
{
    public class SchedulerRecurringWeeklyShould
    {
        #region Frecuency 1
        [Fact]
        internal void Calculate_Recurring_Weekly_Every_1_All_Dates_Are_Equal_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 15)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every week. Schedule will be used on 15/06/2000 starting on 15/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Every_1_All_Dates_Are_Equal_With_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 15),
                EndDate = new DateTime(2000, 6, 15),
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every week. Schedule will be used on 15/06/2000 starting on 15/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Every_1_Starts_Tomorrow_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 16)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 16));
            Assert.Equal("Occurs every week. Schedule will be used on 16/06/2000 starting on 16/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Every_1_Starts_Tomorrow_With_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 16),
                EndDate = new DateTime(2000, 6, 17),
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 16));
            Assert.Equal("Occurs every week. Schedule will be used on 16/06/2000 starting on 16/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Every_1_Starts_Yesterday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 14)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 21));
            Assert.Equal("Occurs every week. Schedule will be used on 21/06/2000 starting on 14/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Every_1_Starts_Yesterday_With_End_Date_Today()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 14),
                EndDate = new DateTime(2000, 6, 15)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Should().Be(null);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Every_1_Starts_Yesterday_With_End_Date_On_The_Next_Event_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 14),
                EndDate = new DateTime(2000, 6, 21)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 21));
            Assert.Equal("Occurs every week. Schedule will be used on 21/06/2000 starting on 14/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Every_1_Starts_Several_Days_Before_Yesterday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 12)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 19));
            Assert.Equal("Occurs every week. Schedule will be used on 19/06/2000 starting on 12/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Every_1_Starts_Several_Days_Before_Yesterday_With_End_Date_Yesterday()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 12),
                EndDate = new DateTime(2000, 6, 14),
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Should().Be(null);
        }
        #endregion

        #region Frecuency 3
        [Fact]
        internal void Calculate_Recurring_Weekly_Every_3_Starts_Tomorrow_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 6),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 3,
                StartDate = new DateTime(2000, 6, 7)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 7));
            Assert.Equal("Occurs every 3 weeks. Schedule will be used on 07/06/2000 starting on 07/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Every_3_Starts_Today_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 7),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 3,
                StartDate = new DateTime(2000, 6, 7)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 7));
            Assert.Equal("Occurs every 3 weeks. Schedule will be used on 07/06/2000 starting on 07/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Every_3_Starts_Yesterday_Without_End_Date_Today()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 8),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 3,
                StartDate = new DateTime(2000, 6, 7)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 28));
            Assert.Equal("Occurs every 3 weeks. Schedule will be used on 28/06/2000 starting on 07/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Every_3_Starts_Yesterday_With_End_Date_Before_Next_Event_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 8),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 3,
                StartDate = new DateTime(2000, 6, 7),
                EndDate = new DateTime(2000, 6, 27)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Should().Be(null);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Every_3_Starts_Yesterday_With_End_Date_The_Next_Event_Day()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 8),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 3,
                StartDate = new DateTime(2000, 6, 7),
                EndDate = new DateTime(2000, 6, 28)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 28));
            Assert.Equal("Occurs every 3 weeks. Schedule will be used on 28/06/2000 starting on 07/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Every_3_Starts_Yesterday_With_End_Date_After_Next_Event_date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 8),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 3,
                StartDate = new DateTime(2000, 6, 7),
                EndDate = new DateTime(2000, 6, 29)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 28));
            Assert.Equal("Occurs every 3 weeks. Schedule will be used on 28/06/2000 starting on 07/06/2000", Result.Value.Description);
        }
        #endregion
    }
}