using System;
using System.Collections.Generic;

namespace LastSundaysInYear.Library
{
    public interface ILastSundays
    {
        List<DateTime> GetLastSundays(int year);
    }
}