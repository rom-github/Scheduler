using FluentAssertions;
using System;
using Xunit;

namespace Scheduler.Test
{
    public class SchedulerOnceShould
    {
        [Fact]
        internal void Calculate_Once_All_Dates_Are_Equal()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 1, 1),
                PeriodicityMode = PeriodicityModes.Once,
                EventDate = new DateTime(2000, 1, 1)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 1, 1));
            Assert.Equal("Occurs once. Schedule will be used on 01/01/2000 starting on 01/01/2000", Result.Value.Description);
        }

        [Fact]
        internal void Calculate_Once_Current_Date_Greather_Than_Event_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 1, 2),
                PeriodicityMode = PeriodicityModes.Once,
                EventDate = new DateTime(2000, 1, 1)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Should().Be(null);
        }

        [Fact]
        internal void Calculate_Once_Event_Date_Greather_Than_Current_Date()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2000, 1, 1),
                PeriodicityMode = PeriodicityModes.Once,
                EventDate = new DateTime(2000, 1, 2)
            };

            var Result = Processor.GetNextExecution(configuration);

            Result.Value.DateTime.Should().Be(new DateTime(2000, 1, 2));
            Assert.Equal("Occurs once. Schedule will be used on 02/01/2000 starting on 02/01/2000", Result.Value.Description);
        }
    }
}