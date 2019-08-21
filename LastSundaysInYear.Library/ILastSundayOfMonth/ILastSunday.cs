using System;

namespace LastSundaysInYear.Library.ILastSundayOfMonth
{
    public interface ILastSunday
    {
        DateTime GetLastSunday(int year, int month);
    }
}