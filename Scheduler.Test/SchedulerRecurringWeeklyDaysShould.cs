using FluentAssertions;
using System;
using Xunit;

namespace Scheduler.Test
{
    public class SchedulerRecurringWeeklyDaysShould
    {
        #region CALCULATE EVERY SINGLE DAY OF THE WEEK --> StartDay = CurrentDate = DayOfWeek WITHOUT EndDate

        [Fact]
        public void Calculate_Recurring_Weekly_Sunday_Every_1_All_Dates_Are_Sunday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 10, 31),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 31),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 10, 31));
            Assert.Equal("Occurs every week. Schedule will be used on 31/10/2021 starting on 31/10/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Monday_Every_1_All_Dates_Are_Monday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 1),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 11, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 1));
            Assert.Equal("Occurs every week. Schedule will be used on 01/11/2021 starting on 01/11/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Tuesday_Every_1_All_Dates_Are_Tuesday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 2),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 11, 2),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Tuesday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 2));
            Assert.Equal("Occurs every week. Schedule will be used on 02/11/2021 starting on 02/11/2021", Result.Value.Description);
        }


        [Fact]
        public void Calculate_Recurring_Weekly_Wednesday_Every_1_All_Dates_Are_Wednesday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 3),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 11, 3),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Wednesday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 3));
            Assert.Equal("Occurs every week. Schedule will be used on 03/11/2021 starting on 03/11/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Thursday_Every_1_All_Dates_Are_Thursday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 4),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 11, 4),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Thursday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 4));
            Assert.Equal("Occurs every week. Schedule will be used on 04/11/2021 starting on 04/11/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Friday_Every_1_All_Dates_Are_Friday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 5),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 11, 5),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Friday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 5));
            Assert.Equal("Occurs every week. Schedule will be used on 05/11/2021 starting on 05/11/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Saturday_Every_1_All_Dates_Are_Saturday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 6),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 11, 6),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Saturday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 6));
            Assert.Equal("Occurs every week. Schedule will be used on 06/11/2021 starting on 06/11/2021", Result.Value.Description);
        }

        #endregion

        #region CALCULATE EVERY SINGLE DAY OF THE WEEK --> StartDay = CurrentDate BUT DIFFERENT DayOfWeek WITHOUT EndDate

        [Fact]
        public void Calculate_Recurring_Weekly_Monday_Every_1_All_Dates_Are_Sunday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 10, 31),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 31),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 1));
            Assert.Equal("Occurs every week. Schedule will be used on 01/11/2021 starting on 31/10/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Tuesday_Every_1_All_Dates_Are_Sunday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 10, 31),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 31),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Tuesday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 2));
            Assert.Equal("Occurs every week. Schedule will be used on 02/11/2021 starting on 31/10/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Wednesday_Every_1_All_Dates_Are_Sunday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 10, 31),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 31),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Wednesday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 3));
            Assert.Equal("Occurs every week. Schedule will be used on 03/11/2021 starting on 31/10/2021", Result.Value.Description);
        }


        [Fact]
        public void Calculate_Recurring_Weekly_Thursday_Every_1_All_Dates_Are_Sunday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 10, 31),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 31),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Thursday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 4));
            Assert.Equal("Occurs every week. Schedule will be used on 04/11/2021 starting on 31/10/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Friday_Every_1_All_Dates_Are_Sunday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 10, 31),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 31),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Friday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 5));
            Assert.Equal("Occurs every week. Schedule will be used on 05/11/2021 starting on 31/10/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Saturday_Every_1_All_Dates_Are_Sunday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 10, 31),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 31),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Saturday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 6));
            Assert.Equal("Occurs every week. Schedule will be used on 06/11/2021 starting on 31/10/2021", Result.Value.Description);
        }


        #endregion

        #region CALCULATE MONDAY-WENSDAY-FRIDAY --> DIFFERENT CurrentDate WITHOUT EndDate

        [Fact]
        public void Calculate_Recurring_Weekly_MonWenFri_Every_1_CurrentDate_Is_Sunday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 10, 31),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 1));
            Assert.Equal("Occurs every week. Schedule will be used on 01/11/2021 starting on 01/10/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_MonWenFri_Every_1_CurrentDate_Is_Monday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 1),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 1));
            Assert.Equal("Occurs every week. Schedule will be used on 01/11/2021 starting on 01/10/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_MonWenFri_Every_1_CurrentDate_Is_Tuesday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 2),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 3));
            Assert.Equal("Occurs every week. Schedule will be used on 03/11/2021 starting on 01/10/2021", Result.Value.Description);
        }


        [Fact]
        public void Calculate_Recurring_Weekly_MonWenFri_Every_1_CurrentDate_Is_Wednesday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 3),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 3));
            Assert.Equal("Occurs every week. Schedule will be used on 03/11/2021 starting on 01/10/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_MonWenFri_Every_1_CurrentDate_Is_Thursday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 4),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 5));
            Assert.Equal("Occurs every week. Schedule will be used on 05/11/2021 starting on 01/10/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_MonWenFri_Every_1_CurrentDate_Is_Friday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 5),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 5));
            Assert.Equal("Occurs every week. Schedule will be used on 05/11/2021 starting on 01/10/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_MonWenFri_Every_1_CurrentDate_Is_Saturday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 6),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 8));
            Assert.Equal("Occurs every week. Schedule will be used on 08/11/2021 starting on 01/10/2021", Result.Value.Description);
        }

        #endregion

        #region CALCULATE SUNDAY-TUESDAY-THURSDAY-SATURDAY --> DIFFERENT CurrentDate WITHOUT EndDate

        [Fact]
        public void Calculate_Recurring_Weekly_SunTueThrSat_Every_1_CurrentDate_Is_Sunday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 10, 31),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 10, 31));
            Assert.Equal("Occurs every week. Schedule will be used on 31/10/2021 starting on 01/10/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_SunTueThrSat_Every_1_CurrentDate_Is_Monday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 1),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 2));
            Assert.Equal("Occurs every week. Schedule will be used on 02/11/2021 starting on 01/10/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_SunTueThrSat_Every_1_CurrentDate_Is_Tuesday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 2),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 2));
            Assert.Equal("Occurs every week. Schedule will be used on 02/11/2021 starting on 01/10/2021", Result.Value.Description);
        }


        [Fact]
        public void Calculate_Recurring_Weekly_SunTueThrSat_Every_1_CurrentDate_Is_Wednesday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 3),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 4));
            Assert.Equal("Occurs every week. Schedule will be used on 04/11/2021 starting on 01/10/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_SunTueThrSat_Every_1_CurrentDate_Is_Thursday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 4),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 4));
            Assert.Equal("Occurs every week. Schedule will be used on 04/11/2021 starting on 01/10/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_SunTueThrSat_Every_1_CurrentDate_Is_Friday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 5),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 6));
            Assert.Equal("Occurs every week. Schedule will be used on 06/11/2021 starting on 01/10/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_SunTueThrSat_Every_1_CurrentDate_Is_Saturday_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 11, 6),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(2021, 10, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 6));
            Assert.Equal("Occurs every week. Schedule will be used on 06/11/2021 starting on 01/10/2021", Result.Value.Description);
        }

        #endregion

        #region CALCULATE EVERY 3 SUNDAY-TUESDAY-THURSDAY-SATURDAY

        [Fact]
        public void Calculate_Recurring_Weekly_SunTueThrSat_Every_3_CurrentDate_Is_Before_Next_Event_Week_Without_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 8, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 3,
                StartDate = new DateTime(2021, 8, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 8, 22));
            Assert.Equal("Occurs every 3 weeks. Schedule will be used on 22/08/2021 starting on 01/08/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_SunTueThrSat_Every_3_CurrentDate_Is_Before_Next_Event_Week_With_End_Date_Before_Next_Event_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 8, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 3,
                StartDate = new DateTime(2021, 8, 1),
                EndDate = new DateTime(2021, 8, 16),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Should().Be(null);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_SunTueThrSat_Every_3_CurrentDate_Is_Before_Next_Event_Week_With_End_Date_Equal_Next_Event_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 8, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 3,
                StartDate = new DateTime(2021, 8, 1),
                EndDate = new DateTime(2021, 8, 22),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 8, 22));
            Assert.Equal("Occurs every 3 weeks. Schedule will be used on 22/08/2021 starting on 01/08/2021", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_SunTueThrSat_Every_3_CurrentDate_Is_Before_Next_Event_Week_With_End_Date_After_Next_Event_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2021, 8, 15),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 3,
                StartDate = new DateTime(2021, 8, 1),
                EndDate = new DateTime(2021, 8, 23),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(2021, 8, 22));
            Assert.Equal("Occurs every 3 weeks. Schedule will be used on 22/08/2021 starting on 01/08/2021", Result.Value.Description);
        }
        #endregion

        #region CALCULATE EXTREME CASES WITH DateTime.MaxValue
        [Fact]
        public void Calculate_Recurring_Weekly_TueFri_Every_3_All_Dates_Are_Saturday_Close_To_MaxDate()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(9999, 12, 18),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 3,
                StartDate = new DateTime(9999, 12, 18),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Tuesday, DayOfWeek.Friday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Should().Be(null);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_TueFri_Every_2_All_Dates_Are_Saturday_Close_To_MaxDate()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(9999, 12, 18),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 2,
                StartDate = new DateTime(9999, 12, 18),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Tuesday, DayOfWeek.Friday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(9999, 12, 28));
            Assert.Equal("Occurs every 2 weeks. Schedule will be used on 28/12/9999 starting on 18/12/9999", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_TueFri_Every_2_Starting_On_Saturday_CurrentDate_Is_Next_Monday()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(9999, 12, 19),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 2,
                StartDate = new DateTime(9999, 12, 18),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Tuesday, DayOfWeek.Friday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(9999, 12, 28));
            Assert.Equal("Occurs every 2 weeks. Schedule will be used on 28/12/9999 starting on 18/12/9999", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_TueFri_Every_22_All_Dates_Are_Close_To_MaxDate()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(9999, 12, 19),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 22,
                StartDate = new DateTime(9999, 12, 18),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Tuesday, DayOfWeek.Friday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Should().Be(null);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Sat_Every_1_All_Dates_Are_Close_To_MaxDate()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(9999, 12, 28),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(9999, 12, 28),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Saturday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Should().Be(null);
        }
        #endregion

        #region CALCULATE EXTREME CASES WITH DateTime.MinValue
        [Fact]
        public void Calculate_Recurring_Weekly_TueFri_Every_1_All_Dates_Are_DateTime_MinValue()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(1, 1, 1),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(1, 1, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Tuesday, DayOfWeek.Friday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(1, 1, 2));
            Assert.Equal("Occurs every week. Schedule will be used on 02/01/0001 starting on 01/01/0001", Result.Value.Description);
        }

        [Fact]
        public void Calculate_Recurring_Weekly_Sun_Every_1_All_Dates_Are_DateTime_MinValue()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(1, 1, 1),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Weekly,
                Frecuency = 1,
                StartDate = new DateTime(1, 1, 1),
                DaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday }
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Value.DateTime.Should().Be(new DateTime(1, 1, 7));
            Assert.Equal("Occurs every week. Schedule will be used on 07/01/0001 starting on 01/01/0001", Result.Value.Description);
        }

       #endregion
    }
}