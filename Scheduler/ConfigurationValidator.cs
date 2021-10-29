﻿using Scheduler.Resources;
using System;

namespace Scheduler
{
    public class ConfigurationValidator
    {
        public void Validate(SchedulerConfiguration Configuration)
        {
            this.ValidateCommon(Configuration);

            if (Configuration.PeriodicityType == PeriodicityTypes.Once)
            {
                this.ValidateOnce(Configuration);
            }

            if (Configuration.PeriodicityType == PeriodicityTypes.Recurring)
            {
                this.ValidateRecurring(Configuration);
            }
        }

        private void ValidateCommon(SchedulerConfiguration Configuration)
        {
            if (Configuration == null)
            {
                throw new ArgumentNullException(ExceptionsTexts.NullConfiguration);
            }

            if (Configuration.CurrentDate == null)
            {
                throw new ArgumentNullException(ExceptionsTexts.NullCurrentDate);
            }
        }

        private void ValidateOnce(SchedulerConfiguration Configuration)
        {
            if (Configuration.EventDate == null)
            {
                throw new ArgumentNullException(ExceptionsTexts.NullEventDate);
            }
        }

        private void ValidateRecurring(SchedulerConfiguration Configuration)
        {

            if (Configuration.PeriodicityMode == null)
            {
                throw new ArgumentNullException(ExceptionsTexts.NullPeriodicityMode);
            }

            if (Configuration.Frecuency == null)
            {
                throw new ArgumentNullException(ExceptionsTexts.NullFrecuency);
            }

            if (Configuration.Frecuency < 1)
            {
                throw new ArgumentOutOfRangeException("Frecuency", Configuration.Frecuency, ExceptionsTexts.FrecuencyMustBeGreaterThanZero);
            }

            if (Configuration.StartDate == null)
            {
                throw new ArgumentNullException(ExceptionsTexts.NullStartDate);
            }

            if (Configuration.EndDate.HasValue && Configuration.EndDate.Value < Configuration.StartDate)
            {
                throw new ArgumentOutOfRangeException("EndDate", Configuration.EndDate, ExceptionsTexts.EndDateMustBeGreaterThanStartDate);
            }
        }
    }
}