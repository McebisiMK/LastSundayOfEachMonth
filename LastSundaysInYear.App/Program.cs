using System;
using System.Collections.Generic;
using System.Linq;
using LastSundaysInYear.Library;
using LastSundaysInYear.Library.Exceptions;

namespace LastSundaysInYear.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var lastSundays = new LastSundays();
            var terminator = "Y";
            while (terminator.ToUpper() == "Y")
            {
                Console.WriteLine("Please enter a year!");
                var year = ConvertInput();
                try
                {
                    var sundays = lastSundays.GetLastSundays(year);
                    Display(sundays);
                }
                catch (InvalidYearException exception)
                {
                    Console.WriteLine();
                    Console.WriteLine(exception.Message);
                }
                Console.WriteLine();
                Console.WriteLine("Press 'Y' if you want to check another year!");
                terminator = Console.ReadLine();
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static int ConvertInput()
        {
            var input = 0;
            int.TryParse(Console.ReadLine(), out input);

            return input;
        }

        private static void Display(List<DateTime> sundays)
        {
            Console.WriteLine();
            sundays.ForEach(sunday => Console.WriteLine(sunday.ToShortDateString()));
        }
    }
}
