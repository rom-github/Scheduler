using System;
using System.Collections.Generic;

namespace Scheduler
{
    public class Processor
    {
        private SchedulerConfiguration configuration;
        private SchedulerResult schedulerResult;


        public Processor(SchedulerConfiguration TheConfiguration)
        {
            this.configuration = TheConfiguration;
            this.schedulerResults = new List<SchedulerResult>();
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

            TimeSpan DiffDate = this.configuration.CurrentDate - this.configuration.StartDate.Value;

            double Units = 0;
            switch (this.configuration.Occurs.Value)
            {
                case PeriodicityModes.Daily:
                    Units = DiffDate.TotalDays;
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