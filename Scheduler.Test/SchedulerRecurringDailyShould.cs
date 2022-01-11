using FluentAssertions;
using System;
using Xunit;

namespace Scheduler.Test
{
    public class SchedulerRecurringDailyShould
    {
        #region Frecuency 1
        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_All_Dates_Are_Equal_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 15)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every day. Schedule will be used on 15/06/2000 starting on 15/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_All_Dates_Are_Equal_With_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 15),
                EndDate = new DateTime(2000, 6, 15),
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every day. Schedule will be used on 15/06/2000 starting on 15/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Starts_Tomorrow_With_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 16),
                EndDate = new DateTime(2000, 6, 17),
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 16));
            Assert.Equal("Occurs every day. Schedule will be used on 16/06/2000 starting on 16/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Starts_Tomorrow_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 16)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 16));
            Assert.Equal("Occurs every day. Schedule will be used on 16/06/2000 starting on 16/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Starts_Yesterday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 14)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every day. Schedule will be used on 15/06/2000 starting on 14/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Starts_Yesterday_With_End_Date_Today()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 14),
                EndDate = new DateTime(2000, 6, 15)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every day. Schedule will be used on 15/06/2000 starting on 14/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Starts_Yesterday_With_End_Date_Tomorrow()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 14),
                EndDate = new DateTime(2000, 6, 16)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every day. Schedule will be used on 15/06/2000 starting on 14/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Starts_Several_Days_Before_Yesterday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 12)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every day. Schedule will be used on 15/06/2000 starting on 12/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_1_Starts_Several_Days_Before_Yesterday_With_End_Date_Yesterday()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 12),
                EndDate = new DateTime(2000, 6, 14),
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Should().Be(null);
        }
        #endregion


        #region Frecuency 3
        [Fact]
        internal void Calculate_Recurring_Daily_Every_3_All_Dates_Are_Equal_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 3,
                StartDate = new DateTime(2000, 6, 15)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every 3 days. Schedule will be used on 15/06/2000 starting on 15/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_3_All_Dates_Are_Equal_With_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 3,
                StartDate = new DateTime(2000, 6, 15),
                EndDate = new DateTime(2000, 6, 15)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every 3 days. Schedule will be used on 15/06/2000 starting on 15/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_3_Starts_Yesterday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 3,
                StartDate = new DateTime(2000, 6, 14)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 17));
            Assert.Equal("Occurs every 3 days. Schedule will be used on 17/06/2000 starting on 14/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_3_Starts_Yesterday_With_End_Date_Today()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 3,
                StartDate = new DateTime(2000, 6, 14),
                EndDate = new DateTime(2000, 6, 15)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Should().Be(null);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_3_Starts_Yesterday_Minus_1_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 3,
                StartDate = new DateTime(2000, 6, 13)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 16));
            Assert.Equal("Occurs every 3 days. Schedule will be used on 16/06/2000 starting on 13/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_3_Starts_Yesterday_Minus_1_With_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 3,
                StartDate = new DateTime(2000, 6, 13),
                EndDate = new DateTime(2000, 6, 15)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Should().Be(null);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_3_Starts_Yesterday_Minus_2_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 3,
                StartDate = new DateTime(2000, 6, 12)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every 3 days. Schedule will be used on 15/06/2000 starting on 12/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_3_Starts_Yesterday_Minus_2_With_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 3,
                StartDate = new DateTime(2000, 6, 12),
                EndDate = new DateTime(2000, 6, 15)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every 3 days. Schedule will be used on 15/06/2000 starting on 12/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_3_Starts_Too_Long_Ago_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 3,
                StartDate = new DateTime(2000, 6, 1)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 16));
            Assert.Equal("Occurs every 3 days. Schedule will be used on 16/06/2000 starting on 01/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_3_Starts_Too_Long_Ago_With_End_Date_Yesterday_Minus2()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 3,
                StartDate = new DateTime(2000, 6, 1),
                EndDate = new DateTime(2000, 6, 12)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Should().Be(null);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_3_Starts_In_The_Future_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 3,
                StartDate = new DateTime(2000, 6, 21)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 21));
            Assert.Equal("Occurs every 3 days. Schedule will be used on 21/06/2000 starting on 21/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_3_Starts_In_The_Future_With_End_Date_In_The_Future()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 3,
                StartDate = new DateTime(2000, 6, 21),
                EndDate = new DateTime(2000, 6, 30)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 21));
            Assert.Equal("Occurs every 3 days. Schedule will be used on 21/06/2000 starting on 21/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_3_Starts_Yesterday_Without_End_Date_CurrentDate_MaxValue()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = DateTime.MaxValue,
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 3,
                StartDate = DateTime.MaxValue.AddDays(-1)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Should().Be(null);
        }
        #endregion


        #region Frecuency 100

        [Fact]
        internal void Calculate_Recurring_Daily_Every_100_Starts_Yesterday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 100,
                StartDate = new DateTime(2000, 6, 14)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 9, 22));
            Assert.Equal("Occurs every 100 days. Schedule will be used on 22/09/2000 starting on 14/06/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_100_Starts_Yesterday_With_End_Date_Tomorrow_Plus_15()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 100,
                StartDate = new DateTime(2000, 6, 14),
                EndDate = new DateTime(2000, 6, 30)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Should().Be(null);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_100_Starts_2_Years_Ago_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 100,
                StartDate = new DateTime(1998, 7, 31)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 30));
            Assert.Equal("Occurs every 100 days. Schedule will be used on 30/06/2000 starting on 31/07/1998", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_100_Starts_2_Years_Ago_Ends_On_The_Next_Event_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 100,
                StartDate = new DateTime(1998, 7, 31),
                EndDate = new DateTime(2000, 6, 30)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 6, 30));
            Assert.Equal("Occurs every 100 days. Schedule will be used on 30/06/2000 starting on 31/07/1998", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Daily_Every_100_Starts_2_Years_Ago_Ends_The_Day_Before_Next_Event_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 6, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 100,
                StartDate = new DateTime(1998, 7, 31),
                EndDate = new DateTime(2000, 6, 29)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Should().Be(null);
        }
        #endregion
    }
}