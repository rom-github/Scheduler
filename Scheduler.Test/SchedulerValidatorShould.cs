using FluentAssertions;
using System;
using Xunit;

namespace Scheduler.Test
{
    public class SchedulerValidatorShould
    {
        #region COMMON TESTS
        [Fact]
        public void Throws_Exception_On_Null_Configuration()
        {
            Processor Processor = new Processor(null);

            Assert.Throws<ArgumentNullException>(() => Processor.GetNextExecution());
        }

        [Fact]
        public void Throws_Exception_On_Null_Current_Date()
        {
            Processor Processor = new Processor(new SchedulerConfiguration());

            Assert.Throws<ArgumentNullException>(() => Processor.GetNextExecution());
        }
        #endregion

        #region ONCE TESTS
        [Fact]
        public void Throws_Exception_On_Once_Null_EventDate()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 1, 1),
                PeriodicityType = PeriodicityTypes.Once
            };

            Processor Processor = new Processor(configuration);

            Assert.Throws<ArgumentNullException>(() => Processor.GetNextExecution());
        }

        #endregion

        #region RECURRING TESTS
        [Fact]
        public void Throws_Exception_On_Null_Periodicity_Mode()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 1, 1),
                PeriodicityType = PeriodicityTypes.Recurring
            };

            Processor Processor = new Processor(configuration);

            Assert.Throws<ArgumentNullException>(() => Processor.GetNextExecution());
        }

        [Fact]
        public void Throws_Exception_On_Null_Frecuency()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 1, 1),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Daily
            };

            Processor Processor = new Processor(configuration);

            Assert.Throws<ArgumentNullException>(() => Processor.GetNextExecution());
        }

        [Fact]
        public void Throws_Exception_On_Frecuency_Zero()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 1, 1),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Daily,
                Frecuency = 0
            };

            Processor Processor = new Processor(configuration);

            Assert.Throws<ArgumentOutOfRangeException>(() => Processor.GetNextExecution());
        }

        [Fact]
        public void Throws_Exception_On_Negative_Frecuency()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 1, 1),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Daily,
                Frecuency = -1
            };

            Processor Processor = new Processor(configuration);

            Assert.Throws<ArgumentOutOfRangeException>(() => Processor.GetNextExecution());
        }

        [Fact]
        public void Throws_Exception_On_Null_Start_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 1, 1),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Daily,
                Frecuency = 1
            };

            Processor Processor = new Processor(configuration);

            Assert.Throws<ArgumentNullException>(() => Processor.GetNextExecution());
        }

        [Fact]
        public void Throws_Exception_On_Start_Date_Greather_Than_End_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 1, 1),
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Daily,
                Frecuency = 1,
                StartDate = new DateTime(2000, 6, 6),
                EndDate = new DateTime(2000, 6, 5)
            };

            Processor Processor = new Processor(configuration);

            Assert.Throws<ArgumentOutOfRangeException>(() => Processor.GetNextExecution());
        }
        #endregion









        //[Fact]
        //public void Schedule_Calculate_Monthly_Fourth_Day_Every_Between_Limits_NoEndDate_Series()
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