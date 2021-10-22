using System;
using Xunit;

namespace Scheduler.Test
{
    public class SchedulerValidatorShould
    {
        [Theory]
        [ClassData(typeof(TestSchedulerOnceGenerator))]
        public void ValidateDateOnce(DateTime currentDate, DateTime date, DateTime? expected)
        {
            //Arrange
            SchedulerConfiguration config = new SchedulerConfiguration();
            config.SetOnce(currentDate, date);
            Processor Processor = new Processor(config);

            //Fact
            SchedulerResult schedulerResult = Processor.GetNextExecution();

            //Assert
            if (expected == null)
            {
                Assert.Null(schedulerResult);
            }
            else
            {
                Assert.Equal(schedulerResult.DateTime, expected);
            }
        }

        [Theory]
        [ClassData(typeof(TestSchedulerRecurringGenerator))]
        [ClassData(typeof(TestSchedulerRecurringGenerator2))]
        public void ValidateDateRecurring(DateTime currentDate, PeriodicityModes ocurrs, int every, DateTime startDate, DateTime endDate, DateTime? expected)
        {
            //Arrange
            SchedulerConfiguration config = new SchedulerConfiguration();
            config.SetRecurring(currentDate, ocurrs, every, startDate, endDate);
            Processor Processor = new Processor(config);

            //Fact
            SchedulerResult schedulerResult = Processor.GetNextExecution();

            //Assert
            if (expected == null)
            {
                Assert.Null(schedulerResult);
            }
            else
            {
                Assert.Equal(schedulerResult.DateTime, expected);
            }
        }

        [Fact]
        public void ThrowsExceptionAssertionsOnEveryZero()
        {
            SchedulerConfiguration config = new SchedulerConfiguration();

            Assert.Throws<ArgumentOutOfRangeException>("every", () => config.SetRecurring(DateTime.MinValue, PeriodicityModes.Daily, 0, DateTime.MinValue, null));
        }

        [Fact]
        public void ThrowsExceptionAssertionsOnNegativeEvery()
        {
            SchedulerConfiguration config = new SchedulerConfiguration();

            Assert.Throws<ArgumentOutOfRangeException>("every", () => config.SetRecurring(DateTime.MinValue, PeriodicityModes.Daily, -1, DateTime.MinValue, null));
        }

        [Fact]
        public void ThrowsExceptionAssertionsOnStartDateGreatherThanEndDate()
        {
            SchedulerConfiguration config = new SchedulerConfiguration();

            Assert.Throws<ArgumentOutOfRangeException>("endDate", () => config.SetRecurring(DateTime.MinValue, PeriodicityModes.Daily, 1, DateTime.MaxValue, DateTime.MaxValue.AddDays(-1)));
        }
    }
}
