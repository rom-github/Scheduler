using System;
using System.Linq;

namespace Scheduler
{
    public class Processor
    {
        private const int DaysInAWeek = 7;
        private const int SecondsInADay = 86400;
        private const int SecondsInAWeek = 604800;
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
                    nextDate = GetWeeklyCalculation();
                    break;

                    //case PeriodicityModes.Monthly:
                    //    NextDate = GetMonthlyCalculation(this.configuration.StartDate.Value, this.configuration.CurrentDate, this.configuration.Frecuency.Value);
                    //    break;

                    //case PeriodicityModes.Yearly:
                    //    NextDate = GetYearlyCalculation(this.configuration.StartDate.Value, this.configuration.CurrentDate, this.configuration.Frecuency.Value);
                    //    break;
            }

            if (nextDate.HasValue == false || nextDate > this.configuration.EndDate)
            {
                return null;
            }

            nextDate = this.SetEventHour(nextDate.Value);

            return new Result(nextDate.Value, this.GetDescription(this.configuration.StartDate.Value, nextDate.Value));
        }

        private DateTime? GetDailyCalculation(DateTime startDate, DateTime currentDate, int frecuency)
        {
            return startDate >= currentDate
                ? startDate
                : this.GetGeneralCalculation(startDate, currentDate, frecuency);
        }

        private DateTime? GetWeeklyCalculation()
        {
            DateTime? eventDate = this.GetDailyCalculation(this.configuration.StartDate.Value, this.configuration.CurrentDate.Value, this.configuration.Frecuency.Value * Processor.DaysInAWeek);

            if (this.configuration.DaysOfWeek != null && this.configuration.DaysOfWeek.Length > 0)
            {
                return GetWeeklyDaysCalculation(eventDate);
            }

            return eventDate;
        }

        private DateTime? GetWeeklyDaysCalculation(DateTime? eventDate)
        {
            DateTime? firstDayOfWeekStartDate = this.configuration.StartDate.Value.FirsDayOfWeek();
            DateTime? firstDayOfWeekCurrentDay = this.configuration.CurrentDate.Value.FirsDayOfWeek();

            DateTime? firstDayOfWeekEventDate = null;
            if (firstDayOfWeekStartDate.HasValue && firstDayOfWeekCurrentDay.HasValue)
            {
                firstDayOfWeekEventDate = this.GetDailyCalculation(firstDayOfWeekStartDate.Value, firstDayOfWeekCurrentDay.Value, this.configuration.Frecuency.Value * Processor.DaysInAWeek);
            }

            if (eventDate.HasValue)
            {
                if (firstDayOfWeekEventDate.HasValue && firstDayOfWeekCurrentDay.HasValue &&
                    firstDayOfWeekEventDate.Value == firstDayOfWeekCurrentDay.Value)
                {
                    return this.configuration.CurrentDate.Value.DayOfWeek <= this.configuration.DaysOfWeek.Max()
                        ? GetNextEventDateInAWeek(this.configuration.CurrentDate.Value.FirsDayOfWeek())
                        : GetNextEventDateInAWeek(firstDayOfWeekCurrentDay.Value.AddDaysNullable(this.configuration.Frecuency.Value * Processor.DaysInAWeek));
                }
                else
                {
                    firstDayOfWeekEventDate = eventDate.Value.FirsDayOfWeek().HasValue
                        ? eventDate.Value.FirsDayOfWeek().Value
                        : new DateTime(1, 1, 1);

                    return GetNextEventDateInAWeek(firstDayOfWeekEventDate);
                }
            }
            else
            {
                return firstDayOfWeekEventDate.HasValue
                    ? GetNextEventDateInAWeek(firstDayOfWeekEventDate)
                    : null;
            }
        }

        private DateTime? GetNextEventDateInAWeek(DateTime? firstDayOfWeekEventDate)
        {
            while (firstDayOfWeekEventDate.HasValue &&
                (this.configuration.DaysOfWeek.Contains(firstDayOfWeekEventDate.Value.DayOfWeek) == false ||
                firstDayOfWeekEventDate < this.configuration.CurrentDate.Value))

            {
                firstDayOfWeekEventDate = firstDayOfWeekEventDate.Value.AddDaysNullable(1);
            }

            return firstDayOfWeekEventDate;
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


        private DateTime? GetGeneralCalculation(DateTime startDate, DateTime currentDate, int Frecuency)
        {
            double CompletePeriodsFromStartToCurrent = (currentDate.Date - startDate.Date).TotalDays / Frecuency;

            DateTime LastExecution = startDate.AddDays(Math.Truncate(CompletePeriodsFromStartToCurrent) * Frecuency);
            return LastExecution == currentDate
                ? currentDate
                : LastExecution.AddDaysNullable(Frecuency);
        }

        //private DateTime? GetGeneralCalculation(DateTime startHour, DateTime currentHour, int Frecuency)
        //{
        //    double CompletePeriodsFromStartToCurrent = (currentHour.TimeOfDay - startHour.TimeOfDay).TotalHours / Frecuency;

        //    TimeSpan LastExecution = startHour.AddDays(Math.Truncate(CompletePeriodsFromStartToCurrent) * Frecuency);
        //    return LastExecution == currentDate
        //        ? currentDate
        //        : LastExecution.AddDaysNullable(Frecuency);
        //}

        private DateTime SetEventHour(DateTime eventDateTime)
        {
            //if (this.configuration.CurrentDate.Value.Date < eventDateTime ||
            //    this.configuration.CurrentDate.Value.TimeOfDay < this.configuration.StartHour.Value)
            //{
            //    return eventDateTime.AddSeconds(this.configuration.StartHour.Value.TotalSeconds);
            //}


            //switch (this.configuration.DailyFrecuencyType.Value)
            //{
            //    case DailyFrecuencyTypes.Hour:
            //        break;
            //    case DailyFrecuencyTypes.Minute:
            //        break;
            //    case DailyFrecuencyTypes.Second:
            //        break;
            //    default:
            //        return eventDateTime;
            //}




            return eventDateTime;
        }

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
    }
}