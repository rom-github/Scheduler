using System;

namespace Scheduler
{
    public static class ConfigurationValidator
    {
        public static void Validate(Configuration configuration)
        {
            ConfigurationValidator.ValidateCommon(configuration);

            if (configuration.PeriodicityMode == PeriodicityModes.Once)
            {
                ConfigurationValidator.ValidateOnce(configuration);
            }

            if (configuration.PeriodicityMode == PeriodicityModes.Recurring)
            {
                ConfigurationValidator.ValidateRecurring(configuration);
            }
        }

        private static void ValidateCommon(Configuration configuration)
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

        private static void ValidateOnce(Configuration configuration)
        {
            if (configuration.EventDate == null)
            {
                throw new ArgumentNullException(Messages.Null_EventDate);
            }
        }

        private static void ValidateRecurring(Configuration configuration)
        {

            if (configuration.DateFrecuencyType == null)
            {
                throw new ArgumentNullException(Messages.Null_Periodicity_Mode);
            }

            if (configuration.DateFrecuency == null)
            {
                throw new ArgumentNullException(Messages.Null_Frecuency);
            }

            if (configuration.DateFrecuency < 1)
            {
                throw new ArgumentOutOfRangeException("Frecuency", configuration.DateFrecuency, Messages.Frecuency_Must_Be_Greater_Than_Zero);
            }

            if (configuration.StartDate == null)
            {
                throw new ArgumentNullException(Messages.Null_Start_Date);
            }

            if (configuration.EndDate.HasValue && configuration.EndDate.Value < configuration.StartDate.Value)
            {
                throw new ArgumentOutOfRangeException("EndDate", configuration.EndDate, Messages.End_Date_Must_Be_Greater_Than_Start_Date);
            }

            ConfigurationValidator.ValidateHoursConfiguration(configuration);
        }

        private static void ValidateHoursConfiguration(Configuration configuration)
        {
            if (configuration.TimeFrecuencyType.HasValue && configuration.TimeFrecuency.HasValue)
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
                if (configuration.TimeFrecuencyType.HasValue || configuration.TimeFrecuency.HasValue)
                {
                    throw new ArgumentException(Messages.Incorrect_Hour_Configuration);
                }
            }
        }
    }
}