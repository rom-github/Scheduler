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
        }


        #endregion

        #region CALCULATE MONDAY-WENSDAY-FRIDAY --> DIFFERENT CurrentDay WITHOUT EndDate

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
        }

        #endregion





        //[Fact]
        //public void Calculate_Recurring_Weekly_MoWeFr_Every_1_All_Dates_Are_Monday_Without_End_Date()
        //{
        //    Configuration configuration = new Configuration()
        //    {
        //        CurrentDate = new DateTime(2021, 11, 1),
        //        PeriodicityType = PeriodicityTypes.Recurring,
        //        PeriodicityMode = PeriodicityModes.Weekly,
        //        Frecuency = 1,
        //        StartDate = new DateTime(2021, 11, 1),
        //        DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday }
        //    };

        //    var Result = new Processor(configuration).GetNextExecution();

        //    Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 1));
        //}

        //[Fact]
        //public void Calculate_Recurring_Weekly_TuThSa_Every_1_All_Dates_Are_Monday_Without_End_Date()
        //{
        //    Configuration configuration = new Configuration()
        //    {
        //        CurrentDate = new DateTime(2021, 11, 1),
        //        PeriodicityType = PeriodicityTypes.Recurring,
        //        PeriodicityMode = PeriodicityModes.Weekly,
        //        Frecuency = 1,
        //        StartDate = new DateTime(2021, 11, 1),
        //        DaysOfWeek = new DayOfWeek[] { DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday }
        //    };

        //    var Result = new Processor(configuration).GetNextExecution();

        //    Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 2));
        //}


        //[Fact]
        //public void Calculate_Recurring_Weekly_Every_1_All_Dates_Are_Equal_With_End_Date()
        //{
        //    Configuration configuration = new Configuration()
        //    {
        //        CurrentDate = new DateTime(2021, 11, 1),
        //        PeriodicityType = PeriodicityTypes.Recurring,
        //        PeriodicityMode = PeriodicityModes.Weekly,
        //        Frecuency = 1,
        //        StartDate = new DateTime(2021, 11, 1),
        //        EndDate = new DateTime(2021, 11, 1),
        //    };

        //    var Result = new Processor(configuration).GetNextExecution();

        //    Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 1));
        //}

        //[Fact]
        //public void Calculate_Recurring_Weekly_Every_1_Starts_Tomorrow_Without_End_Date()
        //{
        //    Configuration configuration = new Configuration()
        //    {
        //        CurrentDate = new DateTime(2021, 11, 1),
        //        PeriodicityType = PeriodicityTypes.Recurring,
        //        PeriodicityMode = PeriodicityModes.Weekly,
        //        Frecuency = 1,
        //        StartDate = new DateTime(2021, 11, 16)
        //    };

        //    var Result = new Processor(configuration).GetNextExecution();

        //    Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 16));
        //}

        //[Fact]
        //public void Calculate_Recurring_Weekly_Every_1_Starts_Tomorrow_With_End_Date()
        //{
        //    Configuration configuration = new Configuration()
        //    {
        //        CurrentDate = new DateTime(2021, 11, 1),
        //        PeriodicityType = PeriodicityTypes.Recurring,
        //        PeriodicityMode = PeriodicityModes.Weekly,
        //        Frecuency = 1,
        //        StartDate = new DateTime(2021, 11, 16),
        //        EndDate = new DateTime(2021, 11, 17),
        //    };

        //    var Result = new Processor(configuration).GetNextExecution();

        //    Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 16));
        //}

        //[Fact]
        //public void Calculate_Recurring_Weekly_Every_1_Starts_Yesterday_Without_End_Date()
        //{
        //    Configuration configuration = new Configuration()
        //    {
        //        CurrentDate = new DateTime(2021, 11, 1),
        //        PeriodicityType = PeriodicityTypes.Recurring,
        //        PeriodicityMode = PeriodicityModes.Weekly,
        //        Frecuency = 1,
        //        StartDate = new DateTime(2021, 11, 14)
        //    };

        //    var Result = new Processor(configuration).GetNextExecution();

        //    Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 21));
        //}

        //[Fact]
        //public void Calculate_Recurring_Weekly_Every_1_Starts_Yesterday_With_End_Date_Today()
        //{
        //    Configuration configuration = new Configuration()
        //    {
        //        CurrentDate = new DateTime(2021, 11, 1),
        //        PeriodicityType = PeriodicityTypes.Recurring,
        //        PeriodicityMode = PeriodicityModes.Weekly,
        //        Frecuency = 1,
        //        StartDate = new DateTime(2021, 11, 14),
        //        EndDate = new DateTime(2021, 11, 1)
        //    };

        //    var Result = new Processor(configuration).GetNextExecution();

        //    Result.Should().Be(null);
        //}

        //[Fact]
        //public void Calculate_Recurring_Weekly_Every_1_Starts_Yesterday_With_End_Date_On_The_Next_Event_Date()
        //{
        //    Configuration configuration = new Configuration()
        //    {
        //        CurrentDate = new DateTime(2021, 11, 1),
        //        PeriodicityType = PeriodicityTypes.Recurring,
        //        PeriodicityMode = PeriodicityModes.Weekly,
        //        Frecuency = 1,
        //        StartDate = new DateTime(2021, 11, 14),
        //        EndDate = new DateTime(2021, 11, 21)
        //    };

        //    var Result = new Processor(configuration).GetNextExecution();

        //    Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 21));
        //}

        //[Fact]
        //public void Calculate_Recurring_Weekly_Every_1_Starts_Several_Days_Before_Yesterday_Without_End_Date()
        //{
        //    Configuration configuration = new Configuration()
        //    {
        //        CurrentDate = new DateTime(2021, 11, 1),
        //        PeriodicityType = PeriodicityTypes.Recurring,
        //        PeriodicityMode = PeriodicityModes.Weekly,
        //        Frecuency = 1,
        //        StartDate = new DateTime(2021, 11, 12)
        //    };

        //    var Result = new Processor(configuration).GetNextExecution();

        //    Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 19));
        //}

        //[Fact]
        //public void Calculate_Recurring_Weekly_Every_1_Starts_Several_Days_Before_Yesterday_With_End_Date_Yesterday()
        //{
        //    Configuration configuration = new Configuration()
        //    {
        //        CurrentDate = new DateTime(2021, 11, 1),
        //        PeriodicityType = PeriodicityTypes.Recurring,
        //        PeriodicityMode = PeriodicityModes.Weekly,
        //        Frecuency = 1,
        //        StartDate = new DateTime(2021, 11, 12),
        //        EndDate = new DateTime(2021, 11, 14),
        //    };

        //    var Result = new Processor(configuration).GetNextExecution();

        //    Result.Should().Be(null);
        //}



        //#region Frecuency 3
        //[Fact]
        //public void Calculate_Recurring_Weekly_Every_3_Starts_Tomorrow_Without_End_Date()
        //{
        //    Configuration configuration = new Configuration()
        //    {
        //        CurrentDate = new DateTime(2021, 11, 6),
        //        PeriodicityType = PeriodicityTypes.Recurring,
        //        PeriodicityMode = PeriodicityModes.Weekly,
        //        Frecuency = 3,
        //        StartDate = new DateTime(2021, 11, 7)
        //    };

        //    var Result = new Processor(configuration).GetNextExecution();

        //    Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 7));
        //}

        //[Fact]
        //public void Calculate_Recurring_Weekly_Every_3_Starts_Today_Without_End_Date()
        //{
        //    Configuration configuration = new Configuration()
        //    {
        //        CurrentDate = new DateTime(2021, 11, 7),
        //        PeriodicityType = PeriodicityTypes.Recurring,
        //        PeriodicityMode = PeriodicityModes.Weekly,
        //        Frecuency = 3,
        //        StartDate = new DateTime(2021, 11, 7)
        //    };

        //    var Result = new Processor(configuration).GetNextExecution();

        //    Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 7));
        //}

        //[Fact]
        //public void Calculate_Recurring_Weekly_Every_3_Starts_Yesterday_Without_End_Date_Today()
        //{
        //    Configuration configuration = new Configuration()
        //    {
        //        CurrentDate = new DateTime(2021, 11, 8),
        //        PeriodicityType = PeriodicityTypes.Recurring,
        //        PeriodicityMode = PeriodicityModes.Weekly,
        //        Frecuency = 3,
        //        StartDate = new DateTime(2021, 11, 7)
        //    };

        //    var Result = new Processor(configuration).GetNextExecution();

        //    Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 28));
        //}

        //[Fact]
        //public void Calculate_Recurring_Weekly_Every_3_Starts_Yesterday_With_End_Date_Before_Next_Event_Date()
        //{
        //    Configuration configuration = new Configuration()
        //    {
        //        CurrentDate = new DateTime(2021, 11, 8),
        //        PeriodicityType = PeriodicityTypes.Recurring,
        //        PeriodicityMode = PeriodicityModes.Weekly,
        //        Frecuency = 3,
        //        StartDate = new DateTime(2021, 11, 7),
        //        EndDate = new DateTime(2021, 11, 27)
        //    };

        //    var Result = new Processor(configuration).GetNextExecution();

        //    Result.Should().Be(null);
        //}

        //[Fact]
        //public void Calculate_Recurring_Weekly_Every_3_Starts_Yesterday_With_End_Date_The_Next_Event_Day()
        //{
        //    Configuration configuration = new Configuration()
        //    {
        //        CurrentDate = new DateTime(2021, 11, 8),
        //        PeriodicityType = PeriodicityTypes.Recurring,
        //        PeriodicityMode = PeriodicityModes.Weekly,
        //        Frecuency = 3,
        //        StartDate = new DateTime(2021, 11, 7),
        //        EndDate = new DateTime(2021, 11, 28)
        //    };

        //    var Result = new Processor(configuration).GetNextExecution();

        //    Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 28));
        //}

        //[Fact]
        //public void Calculate_Recurring_Weekly_Every_3_Starts_Yesterday_With_End_Date_After_Next_Event_date()
        //{
        //    Configuration configuration = new Configuration()
        //    {
        //        CurrentDate = new DateTime(2021, 11, 8),
        //        PeriodicityType = PeriodicityTypes.Recurring,
        //        PeriodicityMode = PeriodicityModes.Weekly,
        //        Frecuency = 3,
        //        StartDate = new DateTime(2021, 11, 7),
        //        EndDate = new DateTime(2021, 11, 29)
        //    };

        //    var Result = new Processor(configuration).GetNextExecution();

        //    Result.Value.DateTime.Should().Be(new DateTime(2021, 11, 28));
        //}
        //#endregion
    }
}