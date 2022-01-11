using FluentAssertions;
using System;
using Xunit;

namespace Scheduler.Test
{
    public class SchedulerRecurringWeeklyDaysShould
    {
        #region CALCULATE EVERY SINGLE DAY OF THE WEEK --> StartDay = CurrentDate = DayOfWeek WITHOUT EndDate

        [Fact]
        internal void Calculate_Recurring_Weekly_Sunday_Every_1_All_Dates_Are_Sunday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 10, 31),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 31),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 10, 31));
            Assert.Equal("Occurs every week on sunday. Schedule will be used on 31/10/2021 starting on 31/10/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Monday_Every_1_All_Dates_Are_Monday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 1),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 11, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 1));
            Assert.Equal("Occurs every week on monday. Schedule will be used on 01/11/2021 starting on 01/11/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Tuesday_Every_1_All_Dates_Are_Tuesday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 2),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 11, 2),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Tuesday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 2));
            Assert.Equal("Occurs every week on tuesday. Schedule will be used on 02/11/2021 starting on 02/11/2021", result.Value.Description);
        }


        [Fact]
        internal void Calculate_Recurring_Weekly_Wednesday_Every_1_All_Dates_Are_Wednesday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 3),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 11, 3),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Wednesday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 3));
            Assert.Equal("Occurs every week on wednesday. Schedule will be used on 03/11/2021 starting on 03/11/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Thursday_Every_1_All_Dates_Are_Thursday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 4),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 11, 4),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Thursday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 4));
            Assert.Equal("Occurs every week on thursday. Schedule will be used on 04/11/2021 starting on 04/11/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Friday_Every_1_All_Dates_Are_Friday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 5),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 11, 5),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Friday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 5));
            Assert.Equal("Occurs every week on friday. Schedule will be used on 05/11/2021 starting on 05/11/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Saturday_Every_1_All_Dates_Are_Saturday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 6),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 11, 6),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Saturday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 6));
            Assert.Equal("Occurs every week on saturday. Schedule will be used on 06/11/2021 starting on 06/11/2021", result.Value.Description);
        }

        #endregion

        #region CALCULATE EVERY SINGLE DAY OF THE WEEK --> StartDay = CurrentDate BUT DIFFERENT DayOfWeek WITHOUT EndDate

        [Fact]
        internal void Calculate_Recurring_Weekly_Monday_Every_1_All_Dates_Are_Sunday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 10, 31),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 31),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 1));
            Assert.Equal("Occurs every week on monday. Schedule will be used on 01/11/2021 starting on 31/10/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Tuesday_Every_1_All_Dates_Are_Sunday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 10, 31),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 31),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Tuesday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 2));
            Assert.Equal("Occurs every week on tuesday. Schedule will be used on 02/11/2021 starting on 31/10/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Wednesday_Every_1_All_Dates_Are_Sunday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 10, 31),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 31),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Wednesday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 3));
            Assert.Equal("Occurs every week on wednesday. Schedule will be used on 03/11/2021 starting on 31/10/2021", result.Value.Description);
        }


        [Fact]
        internal void Calculate_Recurring_Weekly_Thursday_Every_1_All_Dates_Are_Sunday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 10, 31),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 31),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Thursday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 4));
            Assert.Equal("Occurs every week on thursday. Schedule will be used on 04/11/2021 starting on 31/10/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Friday_Every_1_All_Dates_Are_Sunday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 10, 31),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 31),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Friday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 5));
            Assert.Equal("Occurs every week on friday. Schedule will be used on 05/11/2021 starting on 31/10/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Saturday_Every_1_All_Dates_Are_Sunday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 10, 31),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 31),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Saturday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 6));
            Assert.Equal("Occurs every week on saturday. Schedule will be used on 06/11/2021 starting on 31/10/2021", result.Value.Description);
        }


        #endregion

        #region CALCULATE MONDAY-WENSDAY-FRIDAY --> DIFFERENT CurrentDate WITHOUT EndDate

        [Fact]
        internal void Calculate_Recurring_Weekly_MonWenFri_Every_1_CurrentDate_Is_Sunday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 10, 31),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 1));
            Assert.Equal("Occurs every week on monday, wednesday and friday. Schedule will be used on 01/11/2021 starting on 01/10/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_MonWenFri_Every_1_CurrentDate_Is_Monday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 1),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 1));
            Assert.Equal("Occurs every week on monday, wednesday and friday. Schedule will be used on 01/11/2021 starting on 01/10/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_MonWenFri_Every_1_CurrentDate_Is_Tuesday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 2),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 3));
            Assert.Equal("Occurs every week on monday, wednesday and friday. Schedule will be used on 03/11/2021 starting on 01/10/2021", result.Value.Description);
        }


        [Fact]
        internal void Calculate_Recurring_Weekly_MonWenFri_Every_1_CurrentDate_Is_Wednesday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 3),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 3));
            Assert.Equal("Occurs every week on monday, wednesday and friday. Schedule will be used on 03/11/2021 starting on 01/10/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_MonWenFri_Every_1_CurrentDate_Is_Thursday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 4),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 5));
            Assert.Equal("Occurs every week on monday, wednesday and friday. Schedule will be used on 05/11/2021 starting on 01/10/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_MonWenFri_Every_1_CurrentDate_Is_Friday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 5),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 5));
            Assert.Equal("Occurs every week on monday, wednesday and friday. Schedule will be used on 05/11/2021 starting on 01/10/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_MonWenFri_Every_1_CurrentDate_Is_Saturday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 6),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 8));
            Assert.Equal("Occurs every week on monday, wednesday and friday. Schedule will be used on 08/11/2021 starting on 01/10/2021", result.Value.Description);
        }

        #endregion

        #region CALCULATE SUNDAY-TUESDAY-THURSDAY-SATURDAY --> DIFFERENT CurrentDate WITHOUT EndDate

        [Fact]
        internal void Calculate_Recurring_Weekly_SunTueThrSat_Every_1_CurrentDate_Is_Sunday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 10, 31),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 10, 31));
            Assert.Equal("Occurs every week on sunday, tuesday, thursday and saturday. Schedule will be used on 31/10/2021 starting on 01/10/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_SunTueThrSat_Every_1_CurrentDate_Is_Monday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 1),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 2));
            Assert.Equal("Occurs every week on sunday, tuesday, thursday and saturday. Schedule will be used on 02/11/2021 starting on 01/10/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_SunTueThrSat_Every_1_CurrentDate_Is_Tuesday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 2),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 2));
            Assert.Equal("Occurs every week on sunday, tuesday, thursday and saturday. Schedule will be used on 02/11/2021 starting on 01/10/2021", result.Value.Description);
        }


        [Fact]
        internal void Calculate_Recurring_Weekly_SunTueThrSat_Every_1_CurrentDate_Is_Wednesday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 3),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 4));
            Assert.Equal("Occurs every week on sunday, tuesday, thursday and saturday. Schedule will be used on 04/11/2021 starting on 01/10/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_SunTueThrSat_Every_1_CurrentDate_Is_Thursday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 4),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 4));
            Assert.Equal("Occurs every week on sunday, tuesday, thursday and saturday. Schedule will be used on 04/11/2021 starting on 01/10/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_SunTueThrSat_Every_1_CurrentDate_Is_Friday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 5),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 6));
            Assert.Equal("Occurs every week on sunday, tuesday, thursday and saturday. Schedule will be used on 06/11/2021 starting on 01/10/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_SunTueThrSat_Every_1_CurrentDate_Is_Saturday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 6),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 6));
            Assert.Equal("Occurs every week on sunday, tuesday, thursday and saturday. Schedule will be used on 06/11/2021 starting on 01/10/2021", result.Value.Description);
        }

        #endregion

        #region CALCULATE EVERY 3 SUNDAY-TUESDAY-THURSDAY-SATURDAY

        [Fact]
        internal void Calculate_Recurring_Weekly_SunTueThrSat_Every_3_CurrentDate_Is_Before_Next_Event_Week_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 8, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 3,
                StartDate = new DateTime(2021, 8, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 8, 22));
            Assert.Equal("Occurs every 3 weeks on sunday, tuesday, thursday and saturday. Schedule will be used on 22/08/2021 starting on 01/08/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_SunTueThrSat_Every_3_CurrentDate_Is_Before_Next_Event_Week_With_End_Date_Before_Next_Event_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 8, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 3,
                StartDate = new DateTime(2021, 8, 1),
                EndDate = new DateTime(2021, 8, 16),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Should().Be(null);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_SunTueThrSat_Every_3_CurrentDate_Is_Before_Next_Event_Week_With_End_Date_Equal_Next_Event_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 8, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 3,
                StartDate = new DateTime(2021, 8, 1),
                EndDate = new DateTime(2021, 8, 22),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 8, 22));
            Assert.Equal("Occurs every 3 weeks on sunday, tuesday, thursday and saturday. Schedule will be used on 22/08/2021 starting on 01/08/2021", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_SunTueThrSat_Every_3_CurrentDate_Is_Before_Next_Event_Week_With_End_Date_After_Next_Event_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 8, 15),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 3,
                StartDate = new DateTime(2021, 8, 1),
                EndDate = new DateTime(2021, 8, 23),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 8, 22));
            Assert.Equal("Occurs every 3 weeks on sunday, tuesday, thursday and saturday. Schedule will be used on 22/08/2021 starting on 01/08/2021", result.Value.Description);
        }
        #endregion

        #region CALCULATE EVERY 1 SUNDAY-WEDNESDAY
        [Fact]
        internal void Calculate_Recurring_Weekly_SunWed_Every_1_CurrentDate_Is_Before_Next_Event_Week_And_Next_Event_Week_Is_Next_Week()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 27),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(2021, 8, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Wednesday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2021, 11, 28));
            Assert.Equal("Occurs every week on sunday and wednesday. Schedule will be used on 28/11/2021 starting on 01/08/2021", result.Value.Description);
        }
        #endregion

        #region CALCULATE EXTREME CASES WITH DateTime.MaxValue
        [Fact]
        internal void Calculate_Recurring_Weekly_TueFri_Every_3_All_Dates_Are_Saturday_Close_To_MaxDate()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(9999, 12, 18),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 3,
                StartDate = new DateTime(9999, 12, 18),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Tuesday, DayOfWeek.Friday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Should().Be(null);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_TueFri_Every_2_All_Dates_Are_Saturday_Close_To_MaxDate()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(9999, 12, 18),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 2,
                StartDate = new DateTime(9999, 12, 18),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Tuesday, DayOfWeek.Friday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(9999, 12, 28));
            Assert.Equal("Occurs every 2 weeks on tuesday and friday. Schedule will be used on 28/12/9999 starting on 18/12/9999", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_TueFri_Every_2_Starting_On_Saturday_CurrentDate_Is_Next_Monday()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(9999, 12, 19),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 2,
                StartDate = new DateTime(9999, 12, 18),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Tuesday, DayOfWeek.Friday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(9999, 12, 28));
            Assert.Equal("Occurs every 2 weeks on tuesday and friday. Schedule will be used on 28/12/9999 starting on 18/12/9999", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_TueFri_Every_22_All_Dates_Are_Close_To_MaxDate()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(9999, 12, 19),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 22,
                StartDate = new DateTime(9999, 12, 18),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Tuesday, DayOfWeek.Friday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Should().Be(null);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Sat_Every_1_All_Dates_Are_Close_To_MaxDate()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(9999, 12, 28),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(9999, 12, 28),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Saturday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Should().Be(null);
        }
        #endregion

        #region CALCULATE EXTREME CASES WITH DateTime.MinValue
        [Fact]
        internal void Calculate_Recurring_Weekly_TueFri_Every_1_All_Dates_Are_DateTime_MinValue()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(1, 1, 1),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(1, 1, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Tuesday, DayOfWeek.Friday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(1, 1, 2));
            Assert.Equal("Occurs every week on tuesday and friday. Schedule will be used on 02/01/0001 starting on 01/01/0001", result.Value.Description);
        }

        [Fact]
        internal void Calculate_Recurring_Weekly_Sun_Every_1_All_Dates_Are_DateTime_MinValue()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(1, 1, 1),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Weekly,
                DateFrecuency = 1,
                StartDate = new DateTime(1, 1, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday }
            };

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(1, 1, 7));
            Assert.Equal("Occurs every week on sunday. Schedule will be used on 07/01/0001 starting on 01/01/0001", result.Value.Description);
        }

       #endregion
    }
}