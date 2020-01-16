using System;
using LastSundaysInYear.Library.Exceptions;
using LastSundaysInYear.Library.ILastSundayOfMonth;

namespace LastSundaysInYear.Library._LastSunday
{
    public class LastSunday : ILastSunday
    {
        public DateTime GetLastSunday(int year, int month)
        {
            if (Invalid(month))
                throw new InvalidMonthException();

            var monthEnd = DateTime.DaysInMonth(year, month);
            var monthEndDay = GetMonthEndDay(year, month, monthEnd);
            var lastSunday = new DateTime(year, month, (monthEnd - (int)monthEndDay));

            return lastSunday;

        }

        private DayOfWeek GetMonthEndDay(int year, int month, int monthEnd)
        {
            var day = new DateTime(year, month, monthEnd).DayOfWeek;

            return day;
        }

        private bool Invalid(int month)
        {
            return (month < 1 || month > 12);
        }
    }
}