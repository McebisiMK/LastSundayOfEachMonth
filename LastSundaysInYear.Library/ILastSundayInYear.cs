using System;
using System.Collections.Generic;

namespace LastSundaysInYear.Library
{
    public interface ILastSundayInYear
    {
        List<DateTime> GetLastSundays(int year);
    }
}