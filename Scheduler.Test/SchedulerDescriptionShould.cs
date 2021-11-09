using FluentAssertions;
using System;
using System.Reflection;
using Xunit;

namespace Scheduler.Test
{
    public class SchedulerDescriptionShould
    {
        [Fact]
        public void Verify_Description_Once()
        {
            Configuration testConfiguration = new Configuration()
            {
                PeriodicityType = PeriodicityTypes.Once
            };

            var ProcessorAssembly = Assembly.GetAssembly(typeof(Processor));
            var ProcessorType = ProcessorAssembly.GetType("Scheduler.Processor");
            var GetDescriptionMethod = ProcessorType.GetMethod("GetDescription", BindingFlags.Instance | BindingFlags.NonPublic);
            var ConfigurationConstructor = ProcessorType.GetConstructor(new[] { typeof(Configuration) });
            dynamic ConfigurationObject = ConfigurationConstructor.Invoke(new object[] { testConfiguration });

            var Text = GetDescriptionMethod.Invoke(ConfigurationObject, new object[] { new DateTime(2000, 1, 1), new DateTime(2000, 2, 2) });

            Assert.Equal("Occurs once. Schedule will be used on 02/02/2000 starting on 01/01/2000", Text);
        }

        [Fact]
        public void Verify_Description_Recurring_Daily_Frecuency_1()
        {
            Configuration testConfiguration = new Configuration()
            {
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Daily,
                Frecuency = 1
            };

            var ProcessorAssembly = Assembly.GetAssembly(typeof(Processor));
            var ProcessorType = ProcessorAssembly.GetType("Scheduler.Processor");
            var GetDescriptionMethod = ProcessorType.GetMethod("GetDescription", BindingFlags.Instance | BindingFlags.NonPublic);
            var ConfigurationConstructor = ProcessorType.GetConstructor(new[] { typeof(Configuration) });
            dynamic ConfigurationObject = ConfigurationConstructor.Invoke(new object[] { testConfiguration });

            var Text = GetDescriptionMethod.Invoke(ConfigurationObject, new object[] { new DateTime(2000, 1, 1), new DateTime(2000, 2, 2) });

            Assert.Equal("Occurs every day. Schedule will be used on 02/02/2000 starting on 01/01/2000", Text);
        }

        [Fact]
        public void Verify_Description_Recurring_Daily_Frecuency_Greather_Than_1()
        {
            Configuration testConfiguration = new Configuration()
            {
                PeriodicityType = PeriodicityTypes.Recurring,
                PeriodicityMode = PeriodicityModes.Daily,
                Frecuency = 3
            };

            var ProcessorAssembly = Assembly.GetAssembly(typeof(Processor));
            var ProcessorType = ProcessorAssembly.GetType("Scheduler.Processor");
            var GetDescriptionMethod = ProcessorType.GetMethod("GetDescription", BindingFlags.Instance | BindingFlags.NonPublic);
            var ConfigurationConstructor = ProcessorType.GetConstructor(new[] { typeof(Configuration) });
            dynamic ConfigurationObject = ConfigurationConstructor.Invoke(new object[] { testConfiguration });

            var Text = GetDescriptionMethod.Invoke(ConfigurationObject, new object[] { new DateTime(2000, 1, 1), new DateTime(2000, 2, 2) });

            Assert.Equal("Occurs every 3 days. Schedule will be used on 02/02/2000 starting on 01/01/2000", Text);
        }
    }
}