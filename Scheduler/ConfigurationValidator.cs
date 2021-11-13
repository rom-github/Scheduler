using Scheduler.Resources;
using System;

namespace Scheduler
{
    public class ConfigurationValidator
    {
        public void Validate(Configuration configuration)
        {
            this.ValidateCommon(configuration);

            if (configuration.PeriodicityType == PeriodicityTypes.Once)
            {
                this.ValidateOnce(configuration);
            }

            if (configuration.PeriodicityType == PeriodicityTypes.Recurring)
            {
                this.ValidateRecurring(configuration);
            }
        }

        private void ValidateCommon(Configuration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(ExceptionsTexts.NullConfiguration);
            }

            if (configuration.CurrentDate == null)
            {
                throw new ArgumentNullException(ExceptionsTexts.NullCurrentDate);
            }
        }

        private void ValidateOnce(Configuration configuration)
        {
            if (configuration.EventDate == null)
            {
                throw new ArgumentNullException(ExceptionsTexts.NullEventDate);
            }
        }

        private void ValidateRecurring(Configuration configuration)
        {

            if (configuration.PeriodicityMode == null)
            {
                throw new ArgumentNullException(ExceptionsTexts.NullPeriodicityMode);
            }

            if (configuration.Frecuency == null)
            {
                throw new ArgumentNullException(ExceptionsTexts.NullFrecuency);
            }

            if (configuration.Frecuency < 1)
            {
                throw new ArgumentOutOfRangeException("Frecuency", configuration.Frecuency, ExceptionsTexts.FrecuencyMustBeGreaterThanZero);
            }

            if (configuration.StartDate == null)
            {
                throw new ArgumentNullException(ExceptionsTexts.NullStartDate);
            }

            if (configuration.EndDate.HasValue && configuration.EndDate.Value < configuration.StartDate.Value)
            {
                throw new ArgumentOutOfRangeException("EndDate", configuration.EndDate, ExceptionsTexts.EndDateMustBeGreaterThanStartDate);
            }
        }
    }
}