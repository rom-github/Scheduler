using FluentAssertions;
using System;
using Xunit;

namespace Scheduler.Test
{
    public class SchedulerRecurringWeeklyShould
    {
        #region Frecuency 1
        [Fact]
        public void Calculate_Recurring_Weekly_Every_1_All_Dates_Are_Equal_Without_End_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2000, 6, 15)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.DateTime.Should().Be(new DateTime(2000, 6, 15));
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Every_1_All_Dates_Are_Equal_With_End_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2000, 6, 15),
                EndDate = new DateTime(2000, 6, 15),
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.DateTime.Should().Be(new DateTime(2000, 6, 15));
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Every_1_Starts_Tomorrow_Without_End_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2000, 6, 16)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.DateTime.Should().Be(new DateTime(2000, 6, 16));
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Every_1_Starts_Tomorrow_With_End_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2000, 6, 16),
                EndDate = new DateTime(2000, 6, 17),
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.DateTime.Should().Be(new DateTime(2000, 6, 16));
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Every_1_Starts_Yesterday_Without_End_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2000, 6, 14)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.DateTime.Should().Be(new DateTime(2000, 6, 21));
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Every_1_Starts_Yesterday_With_End_Date_Today()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2000, 6, 14),
                EndDate = new DateTime(2000, 6, 15)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Should().Be(null);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Every_1_Starts_Yesterday_With_End_Date_On_The_Next_Event_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2000, 6, 14),
                EndDate = new DateTime(2000, 6, 21)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.DateTime.Should().Be(new DateTime(2000, 6, 21));
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Every_1_Starts_Several_Days_Before_Yesterday_Without_End_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2000, 6, 12)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.DateTime.Should().Be(new DateTime(2000, 6, 19));
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Every_1_Starts_Several_Days_Before_Yesterday_With_End_Date_Yesterday()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2000, 6, 12),
                EndDate = new DateTime(2000, 6, 14),
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Should().Be(null);
        }
        #endregion



        #region Frecuency 3
        [Fact]
        public void Calculate_Recurring_Weekly_Every_3_All_Dates_Are_Equal_Without_End_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 3,
                StartDate = new DateTime(2000, 6, 15)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.DateTime.Should().Be(new DateTime(2000, 6, 15));
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Every_3_All_Dates_Are_Equal_With_End_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 3,
                StartDate = new DateTime(2000, 6, 15),
                EndDate = new DateTime(2000, 6, 15)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.DateTime.Should().Be(new DateTime(2000, 6, 15));
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Every_3_Starts_Yesterday_Without_End_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 3,
                StartDate = new DateTime(2000, 6, 14)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.DateTime.Should().Be(new DateTime(2000, 6, 17));
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Every_3_Starts_Yesterday_With_End_Date_Today()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 3,
                StartDate = new DateTime(2000, 6, 14),
                EndDate = new DateTime(2000, 6, 15)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Should().Be(null);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Every_3_Starts_Yesterday_Minus_1_Without_End_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 3,
                StartDate = new DateTime(2000, 6, 13)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.DateTime.Should().Be(new DateTime(2000, 6, 16));
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Every_3_Starts_Yesterday_Minus_1_With_End_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 3,
                StartDate = new DateTime(2000, 6, 13),
                EndDate = new DateTime(2000, 6, 15)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Should().Be(null);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Every_3_Starts_Yesterday_Minus_2_Without_End_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 3,
                StartDate = new DateTime(2000, 6, 12)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.DateTime.Should().Be(new DateTime(2000, 6, 15));
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Every_3_Starts_Yesterday_Minus_2_With_End_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 3,
                StartDate = new DateTime(2000, 6, 12),
                EndDate = new DateTime(2000, 6, 15)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.DateTime.Should().Be(new DateTime(2000, 6, 15));
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Every_3_Starts_Too_Long_Ago_Without_End_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 3,
                StartDate = new DateTime(2000, 6, 1)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.DateTime.Should().Be(new DateTime(2000, 6, 16));
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Every_3_Starts_Too_Long_Ago_With_End_Date_Yesterday_Minus2()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 3,
                StartDate = new DateTime(2000, 6, 1),
                EndDate = new DateTime(2000, 6, 12)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Should().Be(null);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Every_3_Starts_In_The_Future_Without_End_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 3,
                StartDate = new DateTime(2000, 6, 21)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.DateTime.Should().Be(new DateTime(2000, 6, 21));
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Every_3_Starts_In_The_Future_With_End_Date_In_The_Future()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 3,
                StartDate = new DateTime(2000, 6, 21),
                EndDate = new DateTime(2000, 6, 30)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.DateTime.Should().Be(new DateTime(2000, 6, 21));
        }
        #endregion

    }
}