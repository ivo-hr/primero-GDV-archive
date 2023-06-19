using System;
using System.Runtime.ExceptionServices;

namespace ejerc4
{
    class Program
    {
        static void Main(string[] args)
        {
            double porcentD, precioO, saved, precioF;
            string porcentDs, precioOs;

            Console.WriteLine("Hi! Let's calculate your final price with discounts applied!");

            Console.Write("First, tell me the original price: ");
            precioOs = Console.ReadLine();

            Console.Write("Now, tell me the percentage of the discount: ");
            porcentDs = Console.ReadLine();

            porcentD = double.Parse(porcentDs);
            precioO = double.Parse(precioOs);

            saved = Math.Round(((precioO * porcentD) / 100), 2);
            precioF = Math.Round(precioO - saved, 2);

            Console.WriteLine("Your discounted price is of " + precioF + "$, saving a grand total of " + saved + "$!");

        }
    }
}
