using System;
using System.Threading;

namespace Hoja5
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            bool has3 = false;


            Console.WriteLine("Let's search if your number has a 3 in it!");

            Console.Write("Input your number here: ");
            number = int.Parse(Console.ReadLine());

            while ((has3 == false) && (number > 0))
            {
                has3 = ((number % 10) == 3);
                number /= 10;
            }

            if (has3)
            {
                Console.WriteLine("There IS a 3 in your number!");
            }
            else
            {
                Console.WriteLine("There is NO 3 in your number.");
            }
            
        }
    }
}
