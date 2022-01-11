using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    public static class Processor
    {
        private const int SecondsInAMinute = 60;
        private const int SecondsInAnHour = Processor.SecondsInAMinute * 60;
        private const int SecondsInADay = Processor.SecondsInAnHour * 24;
        private const int DaysInAWeek = 7;
        private const int SecondsInAWeek = Processor.SecondsInADay * Processor.DaysInAWeek;

        public static Result? GetNextExecution(Configuration configuration)
        {
            ConfigurationValidator.Validate(configuration);

            if (configuration.PeriodicityMode == PeriodicityModes.Once)
            {
                return Processor.CalculateNextExecutionOnce(configuration);
            }
            return Processor.CalculateNextExecutionRecurring(configuration);
        }
        public static Result?[] GetSeveralEvents(Configuration configuration, int repetitionsNumber)
        {
            ConfigurationValidator.Validate(configuration);

            List<Result?> ResultList = new List<Result?>();
            if (configuration.PeriodicityMode == PeriodicityModes.Once)
            {
                repetitionsNumber = 1;
            }

            Result? auxResult;
            int i = 0;
            while (i < repetitionsNumber)
            {
                auxResult = Processor.GetNextExecution(configuration);
                ResultList.Add(auxResult);

                if (auxResult == null) { break; }

                if (auxResult.HasValue && auxResult.Value.DateTime.HasValue)
                {
                    configuration.CurrentDate = configuration.TimeFrecuencyType.HasValue
                        ? auxResult.Value.DateTime.Value.AddSeconds(1)
                        : auxResult.Value.DateTime.Value.AddDays(1);
                }
                i++;
            }
            return ResultList.ToArray();
        }

        private static Result? CalculateNextExecutionOnce(Configuration configuration)
        {
            if (configuration.EventDate.Value.Date < configuration.CurrentDate.Value.Date)
            {
                return null;
            }

            return new Result(configuration.EventDate.Value, Processor.GetDescription(configuration, configuration.EventDate.Value, configuration.EventDate.Value));
        }

        private static Result? CalculateNextExecutionRecurring(Configuration configuration)
        {
            if (configuration.StartDate.Value >= configuration.CurrentDate.Value
                &&
                (configuration.DateFrecuencyType != DateFrecuencyTypes.Weekly || configuration.DaysOfWeek == null))
            {
                return new Result(configuration.StartDate.Value, Processor.GetDescription(configuration, configuration.StartDate.Value, configuration.StartDate.Value));
            }

            DateTime? nextEventDate = Processor.GetNextEventDate(configuration, configuration.CurrentDate.Value);

            if (nextEventDate.HasValue == false)
            {
                return null;
            }

            nextEventDate = Processor.SetEventHour(configuration, nextEventDate.Value);


            if (nextEventDate.HasValue == false || nextEventDate > configuration.EndDate)
            {
                return null;
            }

            return new Result(nextEventDate.Value, Processor.GetDescription(configuration, configuration.StartDate.Value, nextEventDate.Value));
        }

        private static DateTime? GetNextEventDate(Configuration configuration, DateTime currentDateTime)
        {

            DateTime? nextDate = null;
            switch (configuration.DateFrecuencyType.Value)
            {
                case DateFrecuencyTypes.Daily:
                    nextDate = Processor.GetDailyCalculation(configuration.StartDate.Value.Date, currentDateTime.Date, configuration.DateFrecuency.Value);
                    break;

                case DateFrecuencyTypes.Weekly:
                    nextDate = Processor.GetWeeklyCalculation(configuration);
                    break;
            }

            return nextDate;
        }

        private static DateTime? GetDailyCalculation(DateTime startDate, DateTime currentDate, int frecuency)
        {
            return startDate >= currentDate
                ? startDate
                : Processor.GetGeneralCalculation(startDate, currentDate, frecuency * Processor.SecondsInADay);
        }

        private static DateTime? GetWeeklyCalculation(Configuration configuration)
        {
            DateTime? eventDate = Processor.GetDailyCalculation(configuration.StartDate.Value.Date, configuration.CurrentDate.Value.Date, configuration.DateFrecuency.Value * Processor.DaysInAWeek);

            if (configuration.DaysOfWeek != null && configuration.DaysOfWeek.Length > 0)
            {
                return Processor.GetWeeklyDaysCalculation(configuration, eventDate);
            }

            return eventDate;
        }

        private static DateTime? GetWeeklyDaysCalculation(Configuration configuration, DateTime? eventDate)
        {
            DateTime? firstDayOfWeekStartDate = configuration.StartDate.Value.FirsDayOfWeek();
            DateTime? firstDayOfWeekCurrentDay = configuration.CurrentDate.Value.FirsDayOfWeek();

            DateTime? firstDayOfWeekEventDate = null;
            if (firstDayOfWeekStartDate.HasValue && firstDayOfWeekCurrentDay.HasValue)
            {
                firstDayOfWeekEventDate = Processor.GetDailyCalculation(firstDayOfWeekStartDate.Value.Date, firstDayOfWeekCurrentDay.Value.Date, configuration.DateFrecuency.Value * Processor.DaysInAWeek);
            }

            if (eventDate.HasValue)
            {
                if (firstDayOfWeekEventDate.HasValue && firstDayOfWeekCurrentDay.HasValue &&
                    firstDayOfWeekEventDate.Value == firstDayOfWeekCurrentDay.Value)
                {
                    return configuration.CurrentDate.Value.DayOfWeek <= configuration.DaysOfWeek.Max()
                        ? Processor.GetNextEventDateInAWeek(configuration, configuration.CurrentDate.Value.FirsDayOfWeek())
                        : Processor.GetNextEventDateInAWeek(configuration, firstDayOfWeekCurrentDay.Value.AddSecondsNullable(configuration.DateFrecuency.Value * Processor.SecondsInAWeek));
                }
                else
                {
                    firstDayOfWeekEventDate = eventDate.Value.FirsDayOfWeek().HasValue
                        ? eventDate.Value.FirsDayOfWeek().Value
                        : new DateTime(1, 1, 1);

                    return Processor.GetNextEventDateInAWeek(configuration, firstDayOfWeekEventDate);
                }
            }
            else
            {
                return firstDayOfWeekEventDate.HasValue
                    ? Processor.GetNextEventDateInAWeek(configuration, firstDayOfWeekEventDate)
                    : null;
            }
        }

        private static DateTime? GetNextEventDateInAWeek(Configuration configuration, DateTime? firstDayOfWeekEventDate)
        {
            while (true)
            {
                if (firstDayOfWeekEventDate.HasValue == false) { break; }

                if (configuration.DaysOfWeek.Contains(firstDayOfWeekEventDate.Value.DayOfWeek))
                {
                    if (firstDayOfWeekEventDate >= configuration.CurrentDate.Value) { break; }
                }

                firstDayOfWeekEventDate = firstDayOfWeekEventDate.Value.AddSecondsNullable(Processor.SecondsInADay);
            }

            return firstDayOfWeekEventDate;
        }

        private static DateTime? GetGeneralCalculation(DateTime startDate, DateTime currentDate, int frecuencyInSeconds)
        {
            double CompletePeriodsFromStartToCurrent = (currentDate - startDate).TotalSeconds / frecuencyInSeconds;

            DateTime LastExecution = startDate.AddSeconds(Math.Truncate(CompletePeriodsFromStartToCurrent) * frecuencyInSeconds);
            return LastExecution == currentDate
                ? currentDate
                : LastExecution.AddSecondsNullable(frecuencyInSeconds);
        }

        private static DateTime? SetEventHour(Configuration configuration, DateTime eventDateTime)
        {
            if (configuration.TimeFrecuencyType.HasValue == false)
            {
                return eventDateTime;
            }

            if (configuration.CurrentDate.Value.Date < eventDateTime ||
                configuration.CurrentDate.Value.TimeOfDay < configuration.StartHour.Value)
            {
                return eventDateTime.AddSeconds(configuration.StartHour.Value.TotalSeconds);
            }

            DateTime newEventDateTime = Processor.CalculateEventHour(configuration, eventDateTime);
            DateTime MaxHour = eventDateTime.AddSeconds(configuration.EndHour.Value.TotalSeconds);

            if (newEventDateTime > MaxHour)
            {
                if (MaxHour.Date == DateTime.MaxValue.Date)
                {
                    return null;
                }

                DateTime? nextEventDate = Processor.GetNextEventDate(configuration, MaxHour.Date.AddDays(1));
                if (nextEventDate.HasValue == false)
                {
                    return null;
                }
                return nextEventDate.Value.AddSeconds(configuration.StartHour.Value.TotalSeconds);
            }
            return newEventDateTime;
        }

        private static DateTime CalculateEventHour(Configuration configuration, DateTime eventDateTime)
        {
            int FrecuencyInSeconds;
            switch (configuration.TimeFrecuencyType.Value)
            {
                case TimeFrecuencyTypes.Hour:
                    FrecuencyInSeconds = configuration.TimeFrecuency.Value * Processor.SecondsInAnHour;
                    break;

                case TimeFrecuencyTypes.Minute:
                    FrecuencyInSeconds = configuration.TimeFrecuency.Value * Processor.SecondsInAMinute;
                    break;

                default:
                    FrecuencyInSeconds = configuration.TimeFrecuency.Value;
                    break;
            }

            return Processor.GetGeneralCalculation(eventDateTime.AddSeconds(configuration.StartHour.Value.TotalSeconds), configuration.CurrentDate.Value, FrecuencyInSeconds).Value;
        }

        #region TEXTS GENERATION
        private static string GetDescription(Configuration configuration, DateTime startDate, DateTime nextDate)
        {
            string EventHourText = configuration.TimeFrecuencyType.HasValue
                ? $" {nextDate.TimeOfDay.ToString()}"
                : string.Empty;


            string ScheduleText = $"Schedule will be used on {nextDate.ToShortDateString()}{EventHourText} starting on {startDate.ToShortDateString()}";

            if (configuration.PeriodicityMode == PeriodicityModes.Once)
            {
                return $"Occurs once. {ScheduleText}";
            }

            return new StringBuilder("Occurs every ")
                .Append(Processor.GetDateTypeDescription(configuration.DateFrecuencyType, configuration.DateFrecuency))
                .Append(Processor.GetDaysOfWeekDescription(configuration.DateFrecuencyType, configuration.DaysOfWeek))
                .Append(Processor.GetTimeFrecuencyDescription(configuration))
                .Append($". {ScheduleText}").ToString();
        }

        private static string GetDateTypeDescription(DateFrecuencyTypes? dateFrecuencyType, int? dateFrecuency)
        {
            string Text = dateFrecuencyType.Value.ToString().ToLower().Substring(0, dateFrecuencyType.Value.ToString().Length - 2);
            if (Text == "dai")
            {
                Text = "day";
            }

            return dateFrecuency > 1
                ? $"{dateFrecuency.ToString().Trim()} {Text}s"
                : Text;
        }

        private static string GetDaysOfWeekDescription(DateFrecuencyTypes? dateFrecuencyType, DayOfWeek[] daysOfWeek)
        {
            StringBuilder Text = new StringBuilder();
            if (dateFrecuencyType == DateFrecuencyTypes.Weekly &&
                daysOfWeek != null && daysOfWeek.Length > 0)
            {
                for (int i = 0; i < daysOfWeek.Length; i++)
                {
                    if (i == 0)
                    {
                        Text.Append(" on ");
                    }
                    else
                    {
                        Text.Append(i == daysOfWeek.Length - 1
                            ? " and "
                            : ", ");
                    }
                    Text.Append(daysOfWeek[i].ToString().ToLower());
                }
            }
            return Text.ToString();
        }

        private static string GetTimeFrecuencyDescription(Configuration configuration)
        {
            if (configuration.TimeFrecuencyType.HasValue == false)
            {
                return string.Empty;
            }

            string plural;
            string numberFrecuency;
            if (configuration.TimeFrecuency == 1)
            {
                plural = 
                    numberFrecuency = string.Empty;
            }
            else
            {
                plural = "s";
                numberFrecuency = $"{configuration.TimeFrecuency.ToString().Trim()} ";
            }

            return new StringBuilder($" every {numberFrecuency}{configuration.TimeFrecuencyType.ToString().ToLower()}{plural}")
                .Append($" between {configuration.StartHour.Value.ToString()} and {configuration.EndHour.Value.ToString()}").ToString();
        }
        #endregion
    }
}