using System;
using System.Linq;

namespace Scheduler
{
    public class Processor
    {
        private Configuration configuration;

        public Processor(Configuration configuration)
        {
            this.configuration = configuration;
        }

        public Result? GetNextExecution()
        {
            new ConfigurationValidator().Validate(this.configuration);

            if (this.configuration.PeriodicityType == PeriodicityTypes.Once)
            {
                return this.CalculateNextExecutionOnce();
            }
            return this.CalculateNextExecutionRecurring();
        }

        private Result? CalculateNextExecutionOnce()
        {
            if (this.configuration.EventDate.Value.Date < this.configuration.CurrentDate.Value.Date)
            {
                return null;
            }

            return new Result(this.configuration.EventDate.Value, this.GetDescription(this.configuration.EventDate.Value, this.configuration.EventDate.Value));
        }

        private Result? CalculateNextExecutionRecurring()
        {
            if (this.configuration.StartDate.Value >= this.configuration.CurrentDate.Value
                &&
                (this.configuration.PeriodicityMode != PeriodicityModes.Weekly || this.configuration.DaysOfWeek == null))
            {
                return new Result(this.configuration.StartDate.Value, this.GetDescription(this.configuration.StartDate.Value, this.configuration.StartDate.Value));
            }

            DateTime? nextDate = null;
            switch (this.configuration.PeriodicityMode.Value)
            {
                case PeriodicityModes.Daily:
                    nextDate = GetDailyCalculation(this.configuration.StartDate.Value, this.configuration.CurrentDate.Value, this.configuration.Frecuency.Value);
                    break;

                case PeriodicityModes.Weekly:
                    nextDate = GetWeeklyCalculation(this.configuration.StartDate.Value, this.configuration.CurrentDate.Value, this.configuration.Frecuency.Value);
                    break;

                //case PeriodicityModes.Monthly:
                //    NextDate = GetMonthlyCalculation(this.configuration.StartDate.Value, this.configuration.CurrentDate, this.configuration.Frecuency.Value);
                //    break;

                //case PeriodicityModes.Yearly:
                //    NextDate = GetYearlyCalculation(this.configuration.StartDate.Value, this.configuration.CurrentDate, this.configuration.Frecuency.Value);
                //    break;
            }

            if (nextDate > this.configuration.EndDate)
            {
                nextDate = null;
            }

            if (nextDate == null)
            {
                return null;
            }

            return new Result(nextDate.Value, this.GetDescription(this.configuration.StartDate.Value, nextDate.Value));
        }

        private DateTime? GetDailyCalculation(DateTime startDate, DateTime currentDate, int frecuency)
        {
            if (this.configuration.StartDate.Value >= this.configuration.CurrentDate.Value)
            {
                return this.configuration.StartDate.Value;
            }

            return this.GetGeneralCalculation(startDate, currentDate, frecuency);
        }

        private DateTime? GetWeeklyCalculation(DateTime startDate, DateTime currentDate, int Frecuency)
        {
            DateTime? eventDate = GetDailyCalculation(startDate, currentDate, Frecuency * 7);

            if (eventDate.HasValue == false || this.configuration.DaysOfWeek == null || this.configuration.DaysOfWeek.Length == 0)
            {
                return eventDate;
            }

            DateTime? firstDayOfWeekEventDate = eventDate.Value.AddDays(-(int)eventDate.Value.DayOfWeek);

            //if (firstDayOfWeekEventDate > this.configuration.CurrentDate.Value)
            //{
            //    firstDayOfWeekEventDate = this.configuration.CurrentDate.Value;
            //}

            for (DateTime i = firstDayOfWeekEventDate.Value; i < firstDayOfWeekEventDate.Value.AddDays(13); i = i.AddDays(1))
            {
                if (this.configuration.DaysOfWeek.Contains<DayOfWeek>(i.DayOfWeek) && i >= this.configuration.CurrentDate.Value)
                {
                    return i;
                }
            }
            return null;
        }

        //private DateTime? GetMonthlyCalculation(DateTime StartDate, DateTime CurrentDate, int Frecuency)
        //{
        //    // Realizo el cálculo como si Frecuency siempre fuera 1 y después llamo a GetTotalNumberOfDays
        //    DateTime NextDate = new DateTime(CurrentDate.Year, CurrentDate.Month, StartDate.Day);
        //    NextDate = NextDate.AddMonths(1);
        //    double TotalDays = this.GetTotalNumberOfDays(StartDate, NextDate, (Frecuency * 30));
        //    return StartDate.AddDays(TotalDays);
        //}

        //private DateTime? GetYearlyCalculation(DateTime StartDate, DateTime CurrentDate, int Frecuency)
        //{
        //    // Realizo el cálculo como si Frecuency siempre fuera 1 y después llamo a GetTotalNumberOfDays
        //    DateTime NextDate = new DateTime(CurrentDate.Year, StartDate.Month, StartDate.Day);
        //    NextDate = NextDate.AddYears(1);
        //    double TotalDays = this.GetTotalNumberOfDays(StartDate, NextDate, (Frecuency * 365));
        //    return StartDate.AddDays(TotalDays);
        //}

        //private double GetTotalNumberOfDays(DateTime StartDate, DateTime NextDateEvery1, int DaysOfAPeriod)
        //{
        //    double DaysDiff = Math.Truncate((NextDateEvery1.Date - StartDate.Date).TotalDays);
        //    double NumberOfPeriods = Math.Truncate(DaysDiff / DaysOfAPeriod);

        //    NumberOfPeriods = DaysDiff % DaysOfAPeriod == 0 ? NumberOfPeriods : NumberOfPeriods + 1;

        //    return NumberOfPeriods * DaysOfAPeriod;
        //}

        private string GetDescription(DateTime startDate, DateTime nextDate)
        {
            string ScheduleText = $"Schedule will be used on { nextDate.ToShortDateString() } starting on { startDate.ToShortDateString() }";

            if (this.configuration.PeriodicityType == PeriodicityTypes.Once)
            {
                return "Occurs once. " + ScheduleText;
            }

            string EveryType = this.configuration.PeriodicityMode.Value.ToString().ToLower().Substring(0, this.configuration.PeriodicityMode.Value.ToString().Length - 2);
            if (EveryType == "dai")
            {
                EveryType = "day";
            }

            if (this.configuration.Frecuency > 1)
            {
                EveryType = this.configuration.Frecuency.ToString().Trim() + " " + EveryType + "s";
            }
            return "Occurs every " + EveryType + ". " + ScheduleText;
        }


        private DateTime? GetGeneralCalculation(DateTime startDate, DateTime currentDate, int Frecuency)
        {
            double CompletePeriodsFromStartToCurrent = (currentDate.Date - startDate.Date).TotalDays / Frecuency;

            try
            {
                if (CompletePeriodsFromStartToCurrent < 1)
                {
                    return startDate.AddDays(Frecuency);
                }

                DateTime LastExecution = startDate.AddDays(Math.Truncate(CompletePeriodsFromStartToCurrent) * Frecuency);
                return LastExecution == currentDate
                    ? currentDate
                    : LastExecution.AddDays(Frecuency);
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }
    }
}