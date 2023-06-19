using System;
using System.Threading;

namespace Hoja5
{
    class Program
    {
        static void Main(string[] args)
        {
            int number, threeCount = 0;
            bool has3 = false;


            Console.WriteLine("Let's see how many 3s there are in your number!");

            Console.Write("Input your number here: ");
            number = int.Parse(Console.ReadLine());

            while (number > 0)                                                              //conditioning while so it stops when reaching 0
            {
                if (has3 = ((number % 10) == 3))                                            //three counter bool resets itself with number operations
                {
                    threeCount += 1;
                }
                number /= 10;
            }

            Console.WriteLine("Your number has " + threeCount + " threes in it.");

        }
    }
}
