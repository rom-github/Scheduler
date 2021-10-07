using System;
using System.Collections.Generic;

namespace Scheduler
{
    public class Processor
    {
        private SchedulerConfiguration configuration;


        public Processor(SchedulerConfiguration TheConfiguration)
        {
            this.configuration = TheConfiguration;
        }


        public SchedulerResult GetNextExecution()
        {
            if (this.configuration.PeriodicityType == PeriodicityTypes.Once)
            {
                return this.CalculateNextExecutionOnce();
            }
            return this.CalculateNextExecutionRecurring();
        }

        private SchedulerResult CalculateNextExecutionOnce()
        {
            if (this.configuration.DateTime < this.configuration.CurrentDate)
            {
                return null;
            }

            return new SchedulerResult(this.configuration.DateTime.Value, string.Empty);
        }

        private SchedulerResult CalculateNextExecutionRecurring()
        {
            if (this.configuration.StartDate >= this.configuration.CurrentDate)
            {
                return new SchedulerResult(this.configuration.StartDate.Value, string.Empty);
            }

            TimeSpan DiffDate = this.configuration.CurrentDate.Date - this.configuration.StartDate.Value.Date;

            double Units = 0;
            double MyEvery;
            switch (this.configuration.Occurs.Value)
            {
                case PeriodicityModes.Daily:
                    MyEvery = this.configuration.Every.Value;
                    break;
                case PeriodicityModes.Weekly:
                    DayOfWeek TheDayOfWeek = this.configuration.StartDate.Value.DayOfWeek;
                    DateTime MyDate = this.configuration.CurrentDate.
                    MyEvery = this.configuration.Every.Value * 7;
                    break;
                case PeriodicityModes.Monthly:
                    MyEvery = this.configuration.Every.Value * 30;
                    break;
                case PeriodicityModes.Yearly:
                    break;
                default:
                    throw new ApplicationException("Configuración no implementada.");
            }

            if (Units % this.configuration.Every == 0)
            {
                return new SchedulerResult(this.configuration.CurrentDate, string.Empty);
            }

            Double AddUnits = this.configuration.Every.Value - (Units % this.configuration.Every.Value);

            DateTime NextDate = DateTime.MaxValue;
            switch (this.configuration.Occurs.Value)
            {
                case PeriodicityModes.Daily:
                    NextDate = this.configuration.CurrentDate.AddDays(AddUnits);
                    break;
                case PeriodicityModes.Weekly:
                    break;
                case PeriodicityModes.Monthly:
                    break;
                case PeriodicityModes.Yearly:
                    break;
                default:
                    throw new ApplicationException("Configuración no implementada.");
            }

            return new SchedulerResult(NextDate, string.Empty);
        }
    }
}