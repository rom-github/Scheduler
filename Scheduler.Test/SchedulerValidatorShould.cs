using System;
using Xunit;

namespace Scheduler.Test
{
    public class SchedulerValidatorShould
    {
        [Theory]
        [ClassData(typeof(SchedulerOnceTestGenerator))]
        public void ValidateOnce(DateTime currentDate, DateTime date, DateTime? expected)
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
        [ClassData(typeof(SchedulerDailyEvery1RecurringTestGenerator))]
        [ClassData(typeof(SchedulerDailyEvery3RecurringTestGenerator))]
        [ClassData(typeof(SchedulerDailyEvery100RecurringTestGenerator))]
        public void ValidateRecurring(TestRecurringConfig config)
        {
            //Arrange
            SchedulerConfiguration schedulerConfig = new SchedulerConfiguration();
            schedulerConfig.SetRecurring(config.CurrentDate, config.PeriodicityMode, config.Every, config.StartDate, config.EndDate);
            Processor Processor = new Processor(schedulerConfig);

            //Fact
            SchedulerResult schedulerResult = Processor.GetNextExecution();

            //Assert
            if (config.Expected.HasValue)
            {
                Assert.Equal(schedulerResult.DateTime, config.Expected);
            }
            else
            {
                Assert.Null(schedulerResult);
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