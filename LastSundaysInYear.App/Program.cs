using System;
using System.Collections.Generic;
using Autofac;
using LastSundaysInYear.Library;
using LastSundaysInYear.Library.Exceptions;

namespace LastSundaysInYear.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Container();
            var lastSundays = container.Resolve<ILastSundays>();
            var terminator = "Y";

            while (terminator.ToUpper() == "Y")
            {
                Console.WriteLine("Please enter a year!");
                var year = ConvertInput();
                Console.WriteLine();
                try
                {
                    var sundays = lastSundays.GetLastSundays(year);
                    Display(sundays);
                }
                catch (InvalidYearException exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine();
                }
                Console.WriteLine("Press 'Y' if you want to check another year!");
                terminator = Console.ReadLine();
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static IContainer Container()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<Modules>();

            return containerBuilder.Build();
        }

        private static int ConvertInput()
        {
            var input = 0;
            int.TryParse(Console.ReadLine(), out input);

            return input;
        }

        private static void Display(List<DateTime> sundays)
        {
            sundays.ForEach(sunday => Console.WriteLine(sunday.ToShortDateString()));
            Console.WriteLine();
        }
    }
}
