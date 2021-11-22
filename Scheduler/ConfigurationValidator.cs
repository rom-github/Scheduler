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
                throw new ArgumentNullException(Messages.Null_Configuration);
            }

            if (configuration.CurrentDate == null)
            {
                throw new ArgumentNullException(Messages.Null_CurrentDate);
            }
        }

        private void ValidateOnce(Configuration configuration)
        {
            if (configuration.EventDate == null)
            {
                throw new ArgumentNullException(Messages.Null_EventDate);
            }
        }

        private void ValidateRecurring(Configuration configuration)
        {

            if (configuration.PeriodicityMode == null)
            {
                throw new ArgumentNullException(Messages.Null_Periodicity_Mode);
            }

            if (configuration.Frecuency == null)
            {
                throw new ArgumentNullException(Messages.Null_Frecuency);
            }

            if (configuration.Frecuency < 1)
            {
                throw new ArgumentOutOfRangeException("Frecuency", configuration.Frecuency, Messages.Frecuency_Must_Be_Greater_Than_Zero);
            }

            if (configuration.StartDate == null)
            {
                throw new ArgumentNullException(Messages.Null_Start_Date);
            }

            if (configuration.EndDate.HasValue && configuration.EndDate.Value < configuration.StartDate.Value)
            {
                throw new ArgumentOutOfRangeException("EndDate", configuration.EndDate, Messages.End_Date_Must_Be_Greater_Than_Start_Date);
            }

            this.ValidateHoursConfiguration(configuration);
        }

        private void ValidateHoursConfiguration(Configuration configuration)
        {
            if (configuration.DailyFrecuencyType.HasValue && configuration.EveryDailyFrecuencyType.HasValue)
            {
                if (configuration.StartHour.HasValue == false)
                {
                    configuration.StartHour = new TimeSpan(0, 0, 0);
                }
                if (configuration.EndHour.HasValue == false)
                {
                    configuration.EndHour = new TimeSpan(23, 59, 59);
                }
            }
            else
            {
                if (configuration.DailyFrecuencyType.HasValue || configuration.EveryDailyFrecuencyType.HasValue)
                {
                    throw new ArgumentException(Messages.Incorrect_Hour_Configuration);
                }
            }
        }
    }
}