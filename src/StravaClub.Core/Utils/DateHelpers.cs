using System;

namespace StravaClub.Core.Utils
{
    public static class DateHelpers
    {
        /// <summary>
        /// Get the number days to the end of the year
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <returns></returns>
        public static decimal DaysToEndYear(this DateTime dateTime)
        {
            var lastdate = new DateTime(dateTime.Year, 12, 31);

            var diff = lastdate - dateTime;

            return Convert.ToDecimal(diff.TotalDays);
        }

        /// <summary>
        /// Get the number days to the end of month
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <returns></returns>
        public static decimal DaysToEndMonth(this DateTime dateTime)
        {
            var totalDays = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);

            return totalDays - (dateTime.Day - 1);
        }
    }
}
