using System;

namespace XUnitSamples
{
    public class DateHelper
    {
        public string GetTimeOfDay(TimeSpan time)
        {
            if (time.Hours >= 0 && time.Hours < 6)
            {
                return "Night";
            }

            if (time.Hours >= 6 && time.Hours < 12)
            {
                return "Morning";
            }

            if (time.Hours >= 12 && time.Hours < 18)
            {
                return "Afternoon";
            }

            if (time.Hours >= 18 && time.Hours < 20)
            {
                return "Evening";
            }

            if (time.Hours >= 20 && time.Hours <= 24)
            {
                return "Night";
            }

            return null;
        }

        /// <summary>
        /// Gets the next day, tomorrow.
        /// </summary>
        static DateTime GetTomorrow()
        {
            return DateTime.Today.AddDays(1);
        }

        /// <summary>
        /// Gets the previous day to the current day.
        /// </summary>
        static DateTime GetYesterday()
        {
            // Add -1 to now.
            return DateTime.Today.AddDays(-1);
        }

        /// <summary>
        /// Gets the first day of the current year.
        /// </summary>
        static DateTime FirstDayOfYear()
        {
            return FirstDayOfYear(DateTime.Today);
        }

        /// <summary>
        /// Finds the first day of year of the specified day.
        /// </summary>
        static DateTime FirstDayOfYear(DateTime y)
        {
            return new DateTime(y.Year, 1, 1);
        }

        /// <summary>
        /// Finds the last day of the year for today.
        /// </summary>
        static DateTime LastDayOfYear()
        {
            return LastDayOfYear(DateTime.Today);
        }

        /// <summary>
        /// Finds the last day of the year for the selected day's year.
        /// </summary>
        static DateTime LastDayOfYear(DateTime d)
        {
            // Get first of next year.
            DateTime n = new DateTime(d.Year + 1, 1, 1);

            // Subtract one from it.
            return n.AddDays(-1);
        }
    }
}