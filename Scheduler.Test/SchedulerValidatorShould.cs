using System;
using Xunit;

namespace Scheduler.Test
{
    public class SchedulerValidatorShould
    {
        #region COMMON TESTS
        [Fact]
        internal void Throws_Exception_On_Null_Configuration()
        {
            Assert.Throws<ArgumentNullException>(() => Processor.GetNextExecution(null));
        }

        [Fact]
        internal void Throws_Exception_On_Null_Current_Date()
        {
            Assert.Throws<ArgumentNullException>(() => Processor.GetNextExecution(new Configuration()));
        }
        #endregion

        #region ONCE TESTS
        [Fact]
        internal void Throws_Exception_On_Once_Null_EventDate()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 1, 1),
                PeriodicityMode = PeriodicityModes.Once
            };

            Assert.Throws<ArgumentNullException>(() => Processor.GetNextExecution(configuration));
        }

        #endregion

        #region RECURRING TESTS
        [Fact]
        internal void Throws_Exception_On_Null_Periodicity_Mode()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 1, 1),
                PeriodicityMode = PeriodicityModes.Recurring
            };

            Assert.Throws<ArgumentNullException>(() => Processor.GetNextExecution(configuration));
        }

        [Fact]
        internal void Throws_Exception_On_Null_Frecuency()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 1, 1),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily
            };

            Assert.Throws<ArgumentNullException>(() => Processor.GetNextExecution(configuration));
        }

        [Fact]
        internal void Throws_Exception_On_Frecuency_Zero()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 1, 1),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 0
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => Processor.GetNextExecution(configuration));
        }

        [Fact]
        internal void Throws_Exception_On_Negative_Frecuency()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 1, 1),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = -1
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => Processor.GetNextExecution(configuration));
        }

        [Fact]
        internal void Throws_Exception_On_Null_Start_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 1, 1),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1
            };

            Assert.Throws<ArgumentNullException>(() => Processor.GetNextExecution(configuration));
        }

        [Fact]
        internal void Throws_Exception_On_Start_Date_Greather_Than_End_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 1, 1),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 6),
                EndDate = new DateTime(2000, 6, 5)
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => Processor.GetNextExecution(configuration));
        }

        [Fact]
        internal void Throws_Exception_On_TimeFrecuencyType_Null_And_TimeFrecuency_NotNull()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 10, 1),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 6),
                EndDate = new DateTime(2001, 6, 6),
                TimeFrecuency = 7
            };

            Assert.Throws<ArgumentException>(() => Processor.GetNextExecution(configuration));
        }

        [Fact]
        internal void Throws_Exception_On_TimeFrecuencyType_NotNull_And_TimeFrecuency_Null()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 10, 1),
                PeriodicityMode = PeriodicityModes.Recurring,
                DateFrecuencyType = DateFrecuencyTypes.Daily,
                DateFrecuency = 1,
                StartDate = new DateTime(2000, 6, 6),
                EndDate = new DateTime(2001, 6, 6),
                TimeFrecuencyType = TimeFrecuencyTypes.Hour
            };

            Assert.Throws<ArgumentException>(() => Processor.GetNextExecution(configuration));
        }


        #endregion









        //[Fact]
        //internal void Schedule_Calculate_Monthly_Fourth_Day_Every_Between_Limits_NoEndDate_Series()
        //{
        //    ScheduleConfiguration sc = new ScheduleConfiguration
        //    {
        //        ScheduleType = ScheduleType.Recurring,
        //        ScheduleEnable = true,
        //        Frecuency = Frecuency.Monthly,
        //        Language = "es-ES",
        //        CurrentDate = new DateTime(2020, 1, 1),

        //        MonthlyFrecuencyByPeriod = true,
        //        MonthlyPeriodThe = MonthlyPeriod.Fourth,
        //        MonthlyPeriodDay = MonthlyPeriodDay.Day,
        //        MonthlyPeriodEvery = 2,



        //        DailyFrecuencyOccursType = OccursType.Every,
        //        DailyFrecuencyOccursEveryType = OccursEveryType.Hours,
        //        DailyFrecuencyOccursEvery = 2,
        //        DailyFrecuencyStartingAt = new TimeSpan(2, 0, 0),
        //        DailyFrecuencyEndingAt = new TimeSpan(10, 0, 0),



        //        DurationStartDate = new DateTime(2020, 1, 1),
        //        DurationType = DurationType.NoEndDate
        //    };



        //    var result = sc.CalculateSerie(6);
        //    result.Count.Should().Be(6);



        //    result[0].Date.Should().Be(new DateTime(2020, 1, 4, 2, 0, 0));
        //    result[1].Date.Should().Be(new DateTime(2020, 1, 4, 4, 0, 0));
        //    result[2].Date.Should().Be(new DateTime(2020, 1, 4, 6, 0, 0));
        //    result[3].Date.Should().Be(new DateTime(2020, 1, 4, 8, 0, 0));
        //    result[4].Date.Should().Be(new DateTime(2020, 1, 4, 10, 0, 0));
        //    result[5].Date.Should().Be(new DateTime(2020, 3, 4, 2, 0, 0));
        //    result[5].Description.Should().Be(@"Ocurre cada 2 meses el cuarto dia de cada 2 meses en periodos de 2 horas entre las 2:00:00 y las 10:00:00");
        //}
    }
}