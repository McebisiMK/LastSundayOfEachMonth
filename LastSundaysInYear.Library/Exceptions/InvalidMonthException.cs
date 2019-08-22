using System;

namespace LastSundaysInYear.Library.Exceptions
{
    public class InvalidMonthException : Exception
    {
        static string message = "Month must be between 1 and 12!!";

        public InvalidMonthException() : base(message)
        {
        }
    }
}