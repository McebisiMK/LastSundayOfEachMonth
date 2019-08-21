using System;

namespace LastSundaysInYear.Library.Exceptions
{
    public class InvalidYearException : Exception
    {
        static string message = "Year must be between 1 - 9999!!";

        public InvalidYearException() : base(message)
        {
        }
    }
}