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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every day. Schedule will be used on 15/06/2000 starting on 15/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every day. Schedule will be used on 15/06/2000 starting on 15/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 16));
            Assert.Equal("Occurs every day. Schedule will be used on 16/06/2000 starting on 16/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 16));
            Assert.Equal("Occurs every day. Schedule will be used on 16/06/2000 starting on 16/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every day. Schedule will be used on 15/06/2000 starting on 14/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every day. Schedule will be used on 15/06/2000 starting on 14/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every day. Schedule will be used on 15/06/2000 starting on 14/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every day. Schedule will be used on 15/06/2000 starting on 12/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Should().Be(null);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every 3 days. Schedule will be used on 15/06/2000 starting on 15/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every 3 days. Schedule will be used on 15/06/2000 starting on 15/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 17));
            Assert.Equal("Occurs every 3 days. Schedule will be used on 17/06/2000 starting on 14/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Should().Be(null);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 16));
            Assert.Equal("Occurs every 3 days. Schedule will be used on 16/06/2000 starting on 13/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Should().Be(null);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every 3 days. Schedule will be used on 15/06/2000 starting on 12/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 15));
            Assert.Equal("Occurs every 3 days. Schedule will be used on 15/06/2000 starting on 12/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 16));
            Assert.Equal("Occurs every 3 days. Schedule will be used on 16/06/2000 starting on 01/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Should().Be(null);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 21));
            Assert.Equal("Occurs every 3 days. Schedule will be used on 21/06/2000 starting on 21/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 21));
            Assert.Equal("Occurs every 3 days. Schedule will be used on 21/06/2000 starting on 21/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Should().Be(null);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 9, 22));
            Assert.Equal("Occurs every 100 days. Schedule will be used on 22/09/2000 starting on 14/06/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Should().Be(null);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 30));
            Assert.Equal("Occurs every 100 days. Schedule will be used on 30/06/2000 starting on 31/07/1998", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 6, 30));
            Assert.Equal("Occurs every 100 days. Schedule will be used on 30/06/2000 starting on 31/07/1998", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Should().Be(null);
        }
        #endregion

        #region Several Events

        [Fact]
        internal void Calculate_Recurring_Daily_Every_365_Starts_In_A_Non_Lip_Year_12_Results_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(1999, 02, 02),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 365,
                StartDate = new DateTime(1998, 03, 01)
            };

            var result = Processor.GetSeveralEvents(configuration, 12);

            result.Length.Should().Be(12);
            result[0].Value.DateTime.Value.Should().Be(new DateTime(1999, 3, 1));
            result[1].Value.DateTime.Value.Should().Be(new DateTime(2000, 2, 29));
            result[2].Value.DateTime.Value.Should().Be(new DateTime(2001, 2, 28));
            result[3].Value.DateTime.Value.Should().Be(new DateTime(2002, 2, 28));
            result[4].Value.DateTime.Value.Should().Be(new DateTime(2003, 2, 28));
            result[5].Value.DateTime.Value.Should().Be(new DateTime(2004, 2, 28));
            result[6].Value.DateTime.Value.Should().Be(new DateTime(2005, 2, 27));
            result[7].Value.DateTime.Value.Should().Be(new DateTime(2006, 2, 27));
            result[8].Value.DateTime.Value.Should().Be(new DateTime(2007, 2, 27));
            result[9].Value.DateTime.Value.Should().Be(new DateTime(2008, 2, 27));
            result[10].Value.DateTime.Value.Should().Be(new DateTime(2009, 2, 26));
            result[11].Value.DateTime.Value.Should().Be(new DateTime(2010, 2, 26));
        }


        [Fact]
        internal void Calculate_Recurring_Daily_Every_365_Starts_In_A_Non_Lip_Year_12_Results_With_End_Date_Before_12_Event()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(1999, 02, 02),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 365,
                StartDate = new DateTime(1998, 03, 01),
                EndDate = new DateTime(2005, 06, 06)
            };

            var result = Processor.GetSeveralEvents(configuration, 12);

            result.Length.Should().Be(8);
            result[0].Value.DateTime.Value.Should().Be(new DateTime(1999, 3, 1));
            result[1].Value.DateTime.Value.Should().Be(new DateTime(2000, 2, 29));
            result[2].Value.DateTime.Value.Should().Be(new DateTime(2001, 2, 28));
            result[3].Value.DateTime.Value.Should().Be(new DateTime(2002, 2, 28));
            result[4].Value.DateTime.Value.Should().Be(new DateTime(2003, 2, 28));
            result[5].Value.DateTime.Value.Should().Be(new DateTime(2004, 2, 28));
            result[6].Value.DateTime.Value.Should().Be(new DateTime(2005, 2, 27));
            result[7].Should().Be(null);
        }
        #endregion
    }
}