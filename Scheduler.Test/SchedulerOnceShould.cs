using FluentAssertions;
using System;
using Xunit;

namespace Scheduler.Test
{
    public class SchedulerOnceShould
    {
        [Fact]
        public void Calculate_Once_All_Dates_Are_Equal()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 1, 1),
                PeriodicityType = PeriodicityTypes.Once,
                EventDate = new DateTime(2000, 1, 1)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.DateTime.Should().Be(new DateTime(2000, 1, 1));
        }

        [Fact]
        public void Calculate_Once_Current_Date_Greather_Than_Event_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 1, 2),
                PeriodicityType = PeriodicityTypes.Once,
                EventDate = new DateTime(2000, 1, 1)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.Should().Be(null);
        }

        [Fact]
        public void Calculate_Once_Event_Date_Greather_Than_Current_Date()
        {
            SchedulerConfiguration configuration = new SchedulerConfiguration()
            {
                CurrentDate = new DateTime(2000, 1, 1),
                PeriodicityType = PeriodicityTypes.Once,
                EventDate = new DateTime(2000, 1, 2)
            };

            var Result = new Processor(configuration).GetNextExecution();

            Result.DateTime.Should().Be(new DateTime(2000, 1, 2));
        }
    }
}