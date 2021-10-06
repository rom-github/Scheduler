using System;
using System.Collections.Generic;

namespace Scheduler
{
    public class Processor
    {
        private SchedulerConfiguration configuration;
        private List<SchedulerResult> schedulerResults;

        
        public Processor(SchedulerConfiguration TheConfiguration)
        {
            this.configuration = TheConfiguration;
            this.schedulerResults = new List<SchedulerResult>();
        }


        public string GetNextExecution()
        {
            if (this.schedulerResults.Count == 0)
            {
                if (this.configuration.PeriodicityType == PeriodicityTypes.Once)
                {
                    this.CalculateFirstExecutionOnce();
                }

                if (this.configuration.PeriodicityType == PeriodicityTypes.Recurring)
                {
                    this.CalculateFirstExecutionRecurring();
                }
            }
            else
            {
                if (this.configuration.PeriodicityType == PeriodicityTypes.Recurring)
                {
                    this.CalculateNextExecutionRecurring();
                }
            }

            return this.schedulerResults == null || this.schedulerResults.Count == 0 ? string.Empty : this.schedulerResults[this.schedulerResults.Count - 1].TextResult;
        }

        private void CalculateFirstExecutionOnce()
        {
            if (this.configuration.DateTime < this.configuration.CurrentDate)
            {
                this.schedulerResults.Clear();
            }

            this.schedulerResults.Add(new SchedulerResult(1, this.configuration.DateTime.Value, string.Empty));
        }

        private void CalculateFirstExecutionRecurring()
        {
            if (this.configuration.StartDate >= this.configuration.CurrentDate)
            {
                this.schedulerResults.Add(new SchedulerResult(1, this.configuration.StartDate.Value, string.Empty));
                return;
            }

            TimeSpan DiffDate = this.configuration.CurrentDate - this.configuration.StartDate.Value;
            double Units = 0;
            switch (this.configuration.Occurs.Value)
            {
                case PeriodicityModes.Secondly:
                    Units = DiffDate.TotalSeconds;
                    break;
                case PeriodicityModes.Minutely:
                    Units = DiffDate.TotalMinutes;
                    break;
                case PeriodicityModes.Hourly:
                    Units = DiffDate.TotalHours;
                    break;
                case PeriodicityModes.Daily:
                    Units = DiffDate.TotalDays;
                    break;
                case PeriodicityModes.Weekly:
                    break;
                case PeriodicityModes.Monthly:
                    Units = DiffDate.TotalSeconds;
                    break;
                case PeriodicityModes.Yearly:
                    Units = DiffDate.TotalSeconds;
                    break;
                default:
                    break;
            }

            if (Units % this.configuration.Every == 0)
            {
                this.schedulerResults.Add(new SchedulerResult(1, this.configuration.CurrentDate, string.Empty));
                return;
            }

            Double AddUnits = this.configuration.Every.Value - (Units % this.configuration.Every.Value);

            DateTime NextDate = DateTime.MaxValue;
            switch (this.configuration.Occurs.Value)
            {
                case PeriodicityModes.Secondly:
                    NextDate = this.configuration.CurrentDate.AddSeconds(AddUnits);
                    break;
                case PeriodicityModes.Minutely:
                    NextDate = this.configuration.CurrentDate.AddMinutes(AddUnits);
                    break;
                case PeriodicityModes.Hourly:
                    NextDate = this.configuration.CurrentDate.AddHours(AddUnits);
                    break;
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
                    break;
            }

            this.schedulerResults.Add(new SchedulerResult(1, NextDate, string.Empty));
        }

        private void CalculateNextExecutionRecurring()
        {
            SchedulerResult LastResult = this.schedulerResults[this.schedulerResults.Count - 1];
        }

    }
}