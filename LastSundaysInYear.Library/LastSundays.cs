using System;
using System.Collections.Generic;
using System.Linq;
using LastSundaysInYear.Library.ILastSundayOfMonth;
using LastSundaysInYear.Library.IValidations;

namespace LastSundaysInYear.Library
{
    public class LastSundays : ILastSundays
    {
        private readonly IValidator _validator;
        private readonly ILastSunday _lastSunday;

        public LastSundays(IValidator validator, ILastSunday lastSunday)
        {
            _validator = validator;
            _lastSunday = lastSunday;
        }

        public List<DateTime> GetLastSundays(int year)
        {
            _validator.Validate(year);

            return Enumerable.Range(1, 12)
                             .Select(month => _lastSunday.GetLastSunday(year, month))
                             .ToList();
        }
    }
}