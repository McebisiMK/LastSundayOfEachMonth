using System;
using LastSundaysInYear.Library.Exceptions;
using LastSundaysInYear.Library.ILastSundayOfMonth;

public class LastSunday : ILastSunday
{
    public DateTime GetLastSunday(int year, int month)
    {
        if (month < 1 || month > 12)
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
}