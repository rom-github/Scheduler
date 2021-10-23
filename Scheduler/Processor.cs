using System;

namespace Scheduler
{
    public class Processor
    {
        private SchedulerConfiguration configuration;


        public Processor(SchedulerConfiguration configuration)
        {
            this.configuration = configuration;
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
            if (this.configuration.DateTime.Value.Date < this.configuration.CurrentDate.Date)
            {
                return null;
            }

            return new SchedulerResult(this.configuration.DateTime.Value, this.GetDescription(this.configuration.DateTime.Value, this.configuration.DateTime.Value));
        }

        private SchedulerResult CalculateNextExecutionRecurring()
        {
            if (this.configuration.StartDate >= this.configuration.CurrentDate)
            {
                return new SchedulerResult(this.configuration.StartDate.Value, this.GetDescription(this.configuration.StartDate.Value, this.configuration.StartDate.Value));
            }

            DateTime? TheNextDate = null;
            switch (this.configuration.Occurs.Value)
            {
                case PeriodicityModes.Daily:
                    TheNextDate = GetDailyCalculation(this.configuration.StartDate.Value, this.configuration.CurrentDate, this.configuration.Every.Value);
                    break;

                case PeriodicityModes.Weekly:
                    TheNextDate = GetWeeklyCalculation(this.configuration.StartDate.Value, this.configuration.CurrentDate, this.configuration.Every.Value);
                    break;

                case PeriodicityModes.Monthly:
                    TheNextDate = GetMonthlyCalculation(this.configuration.StartDate.Value, this.configuration.CurrentDate, this.configuration.Every.Value);
                    break;

                case PeriodicityModes.Yearly:
                    TheNextDate = GetYearlyCalculation(this.configuration.StartDate.Value, this.configuration.CurrentDate, this.configuration.Every.Value);
                    break;
            }

            if (TheNextDate > this.configuration.EndDate)
            {
                TheNextDate = null;
            }

            return TheNextDate == null ? null : new SchedulerResult(TheNextDate.Value, this.GetDescription(this.configuration.StartDate.Value, TheNextDate.Value));
        }

        private DateTime? GetDailyCalculation(DateTime StartDate, DateTime CurrentDate, int Every)
        {
            return this.GetGeneralCalculation(StartDate, CurrentDate, Every);
            // Realizo el cálculo como si Every siempre fuera 1 y después llamo a GetTotalNumberOfDays
            //DateTime TheNextDate = CurrentDate.AddDays(1);
            //double TotalDays = this.GetTotalNumberOfDays(StartDate, TheNextDate, Every);
            //return StartDate.AddDays(TotalDays);
        }

        private DateTime? GetWeeklyCalculation(DateTime StartDate, DateTime CurrentDate, int Every)
        {
            return this.GetGeneralCalculation(StartDate, CurrentDate, Every * 7);
            //// Realizo el cálculo como si Every siempre fuera 1 y después llamo a GetTotalNumberOfDays
            //DayOfWeek StartDayOfWeek = StartDate.DayOfWeek;
            //DayOfWeek CurrentDayOfWeek = CurrentDate.DayOfWeek;

            //int DaysToAdd = StartDayOfWeek <= CurrentDayOfWeek
            //    ? 7 - (CurrentDayOfWeek - StartDayOfWeek)
            //    : StartDayOfWeek - CurrentDayOfWeek;

            //DateTime TheNextDate = CurrentDate.AddDays(DaysToAdd);
            //double TotalDays = this.GetTotalNumberOfDays(StartDate, TheNextDate, (Every * 7));
            //return StartDate.AddDays(TotalDays);
        }

        private DateTime? GetMonthlyCalculation(DateTime StartDate, DateTime CurrentDate, int Every)
        {
            // Realizo el cálculo como si Every siempre fuera 1 y después llamo a GetTotalNumberOfDays
            DateTime TheNextDate = new DateTime(CurrentDate.Year, CurrentDate.Month, StartDate.Day);
            TheNextDate = TheNextDate.AddMonths(1);
            double TotalDays = this.GetTotalNumberOfDays(StartDate, TheNextDate, (Every * 30));
            return StartDate.AddDays(TotalDays);
        }

        private DateTime? GetYearlyCalculation(DateTime StartDate, DateTime CurrentDate, int Every)
        {
            // Realizo el cálculo como si Every siempre fuera 1 y después llamo a GetTotalNumberOfDays
            DateTime TheNextDate = new DateTime(CurrentDate.Year, StartDate.Month, StartDate.Day);
            TheNextDate = TheNextDate.AddYears(1);
            double TotalDays = this.GetTotalNumberOfDays(StartDate, TheNextDate, (Every * 365));
            return StartDate.AddDays(TotalDays);
        }

        private double GetTotalNumberOfDays(DateTime StartDate, DateTime NextDateEvery1, int DaysOfAPeriod)
        {
            double DaysDiff = Math.Truncate((NextDateEvery1.Date - StartDate.Date).TotalDays);
            double NumberOfPeriods = Math.Truncate(DaysDiff / DaysOfAPeriod);

            NumberOfPeriods = DaysDiff % DaysOfAPeriod == 0 ? NumberOfPeriods : NumberOfPeriods + 1;

            return NumberOfPeriods * DaysOfAPeriod;
        }

        private string GetDescription(DateTime StartDate, DateTime NextDate)
        {
            string ScheduleText = $"Schedule will be used on { NextDate.ToShortDateString() } starting on { StartDate.ToShortDateString() }";

            if (this.configuration.PeriodicityType == PeriodicityTypes.Once)
            {
                return "Occurs once. " + ScheduleText;
            }

            string Type = this.configuration.PeriodicityType == PeriodicityTypes.Once ? "once" : "every " + this.configuration.Every.ToString().Trim();

            string EveryType = this.configuration.Occurs.Value.ToString().ToLower().Substring(0, this.configuration.Occurs.Value.ToString().Length - 2);
            if (EveryType == "dai")
            {
                EveryType = "day";
            }

            if (this.configuration.Every > 1)
            {
                EveryType = this.configuration.Every.ToString().Trim() + " " + EveryType + "s";
            }
            return "Occurs every " + EveryType + ". " + ScheduleText;
        }


        private DateTime GetGeneralCalculation(DateTime StartDate, DateTime CurrentDate, int Every)
        {
            double CompletePeriodsFromStartToCurrent = (CurrentDate.Date - StartDate.Date).TotalDays / Every;

            if (CompletePeriodsFromStartToCurrent < 1)
            {
                return StartDate.AddDays(Every);
            }

            DateTime LastExecution = StartDate.AddDays(Math.Truncate(CompletePeriodsFromStartToCurrent) * Every);
            return LastExecution == CurrentDate
                ? CurrentDate
                : LastExecution.AddDays(Every);
        }
    }
}