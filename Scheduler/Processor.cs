using System;
using System.Linq;

namespace Scheduler
{
    public class Processor
    {
        private const int SecondsInAMinute = 60;
        private const int SecondsInAnHour = Processor.SecondsInAMinute * 60;
        private const int SecondsInADay = Processor.SecondsInAnHour * 24;
        private const int DaysInAWeek = 7;
        private const int SecondsInAWeek = Processor.SecondsInADay * Processor.DaysInAWeek;
        private Configuration configuration;

        public Processor(Configuration configuration)
        {
            this.configuration = configuration;
        }

        public Result? GetNextExecution()
        {
            new ConfigurationValidator().Validate(this.configuration);

            if (this.configuration.PeriodicityMode == PeriodicityModes.Once)
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
                (this.configuration.DateFrecuencyType != DateFrecuencyTypes.Weekly || this.configuration.DaysOfWeek == null))
            {
                return new Result(this.configuration.StartDate.Value, this.GetDescription(this.configuration.StartDate.Value, this.configuration.StartDate.Value));
            }

            DateTime? nextDate = null;
            switch (this.configuration.DateFrecuencyType.Value)
            {
                case DateFrecuencyTypes.Daily:
                    nextDate = GetDailyCalculation(this.configuration.StartDate.Value.Date, this.configuration.CurrentDate.Value.Date, this.configuration.DateFrecuency.Value);
                    break;

                case DateFrecuencyTypes.Weekly:
                    nextDate = GetWeeklyCalculation();
                    break;
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
                : this.GetGeneralCalculation(startDate, currentDate, frecuency * Processor.SecondsInADay);
        }

        private DateTime? GetWeeklyCalculation()
        {
            DateTime? eventDate = this.GetDailyCalculation(this.configuration.StartDate.Value.Date, this.configuration.CurrentDate.Value.Date, this.configuration.DateFrecuency.Value * Processor.DaysInAWeek);

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
                firstDayOfWeekEventDate = this.GetDailyCalculation(firstDayOfWeekStartDate.Value.Date, firstDayOfWeekCurrentDay.Value.Date, this.configuration.DateFrecuency.Value * Processor.DaysInAWeek);
            }

            if (eventDate.HasValue)
            {
                if (firstDayOfWeekEventDate.HasValue && firstDayOfWeekCurrentDay.HasValue &&
                    firstDayOfWeekEventDate.Value == firstDayOfWeekCurrentDay.Value)
                {
                    return this.configuration.CurrentDate.Value.DayOfWeek <= this.configuration.DaysOfWeek.Max()
                        ? GetNextEventDateInAWeek(this.configuration.CurrentDate.Value.FirsDayOfWeek())
                        : GetNextEventDateInAWeek(firstDayOfWeekCurrentDay.Value.AddSecondsNullable(this.configuration.DateFrecuency.Value * Processor.SecondsInAWeek));
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
                firstDayOfWeekEventDate = firstDayOfWeekEventDate.Value.AddSecondsNullable(Processor.SecondsInADay);
            }

            return firstDayOfWeekEventDate;
        }

        private DateTime? GetGeneralCalculation(DateTime startDate, DateTime currentDate, int frecuencyInSeconds)
        {
            double CompletePeriodsFromStartToCurrent = (currentDate - startDate).TotalSeconds / frecuencyInSeconds;

            DateTime LastExecution = startDate.AddSeconds(Math.Truncate(CompletePeriodsFromStartToCurrent) * frecuencyInSeconds);
            return LastExecution == currentDate
                ? currentDate
                : LastExecution.AddSecondsNullable(frecuencyInSeconds);
        }

        private DateTime SetEventHour(DateTime eventDateTime)
        {
            if (this.configuration.TimeFrecuencyType.HasValue == false)
            {
                return eventDateTime;
            }

            if (this.configuration.CurrentDate.Value.Date < eventDateTime ||
                this.configuration.CurrentDate.Value.TimeOfDay < this.configuration.StartHour.Value)
            {
                return eventDateTime.AddSeconds(this.configuration.StartHour.Value.TotalSeconds);
            }

            int FrecuencyInSeconds;
            switch (this.configuration.TimeFrecuencyType.Value)
            {
                case TimeFrecuencyTypes.Hour:
                    FrecuencyInSeconds = this.configuration.TimeFrecuency.Value * Processor.SecondsInAnHour;
                    break;

                case TimeFrecuencyTypes.Minute:
                    FrecuencyInSeconds = this.configuration.TimeFrecuency.Value * Processor.SecondsInAMinute;
                    break;

                default:
                    FrecuencyInSeconds = this.configuration.TimeFrecuency.Value;
                    break;
            }

            eventDateTime =  this.GetGeneralCalculation(eventDateTime.AddSeconds(this.configuration.StartHour.Value.TotalSeconds), this.configuration.CurrentDate.Value, FrecuencyInSeconds).Value;
            DateTime MaxHour = eventDateTime.AddSeconds(this.configuration.EndHour.Value.TotalSeconds);

            if (eventDateTime > MaxHour)
            {

            }
        }

        private string GetDescription(DateTime startDate, DateTime nextDate)
        {
            string EventHourText = this.configuration.TimeFrecuencyType.HasValue
                ? " " + nextDate.TimeOfDay.ToString()
                : string.Empty;


            string ScheduleText = $"Schedule will be used on { nextDate.ToShortDateString() + EventHourText } starting on { startDate.ToShortDateString() }";

            if (this.configuration.PeriodicityMode == PeriodicityModes.Once)
            {
                return "Occurs once. " + ScheduleText;
            }

            return "Occurs every " +
                this.GetDateTypeDescription() +
                this.GetDaysOfWeekDescription() +
                this.GetTimeFrecuencyDescription() +
                ". " + ScheduleText;
        }

        private string GetDateTypeDescription()
        {
            string Text = this.configuration.DateFrecuencyType.Value.ToString().ToLower().Substring(0, this.configuration.DateFrecuencyType.Value.ToString().Length - 2);
            if (Text == "dai")
            {
                Text = "day";
            }

            return this.configuration.DateFrecuency > 1
                ? this.configuration.DateFrecuency.ToString().Trim() + " " + Text + "s"
                : Text;
        }

        private string GetDaysOfWeekDescription()
        {
            string Text = string.Empty;
            if (this.configuration.DateFrecuencyType == DateFrecuencyTypes.Weekly &&
                this.configuration.DaysOfWeek != null && this.configuration.DaysOfWeek.Length > 0)
            {
                for (int i = 0; i < this.configuration.DaysOfWeek.Length; i++)
                {
                    if (i == 0)
                    {
                        Text += " on ";
                    }
                    else
                    {
                        Text += i == this.configuration.DaysOfWeek.Length - 1
                            ? " and "
                            : ", ";
                    }
                    Text += this.configuration.DaysOfWeek[i].ToString().ToLower();
                }
            }
            return Text;
        }

        private string GetTimeFrecuencyDescription()
        {
            if (this.configuration.TimeFrecuencyType.HasValue == false)
            {
                return string.Empty;
            }

            string Plural = this.configuration.TimeFrecuency == 1 ? string.Empty : "s";

            return " every " + this.configuration.TimeFrecuency.ToString().Trim() + " " +
                this.configuration.TimeFrecuencyType.ToString().ToLower() + Plural +
                " between " + this.configuration.StartHour.Value.ToString() +
                " and " + this.configuration.EndHour.Value.ToString();
        }
    }
}