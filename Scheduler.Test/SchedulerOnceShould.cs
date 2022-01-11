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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 1, 1));
            Assert.Equal("Occurs once. Schedule will be used on 01/01/2000 starting on 01/01/2000", result.Value.Description);
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

            var result = Processor.GetNextExecution(configuration);

            result.Should().Be(null);
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

            var result = Processor.GetNextExecution(configuration);

            result.Value.DateTime.Should().Be(new DateTime(2000, 1, 2));
            Assert.Equal("Occurs once. Schedule will be used on 02/01/2000 starting on 02/01/2000", result.Value.Description);
        }


        #region Several Events

        [Fact]
        internal void Calculate_Once_Common_Case_Testing_Several_Events()
        {
            Configuration configuration = new Configuration()
            {
                CurrentDate = new DateTime(2022, 02, 02),
                PeriodicityMode = PeriodicityModes.Once,
                EventDate = new DateTime(2024, 04, 04)
            };

            var result = Processor.GetSeveralEvents(configuration, 12);

            result.Length.Should().Be(1);
            result[0].Value.DateTime.Value.Should().Be(new DateTime(2024, 04, 04));
        }
        #endregion
    }
}