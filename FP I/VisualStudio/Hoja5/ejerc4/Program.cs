using System;

namespace ejerc4
{
    class Program
    {
        static void Main(string[] args)
        {                                                                                           //basis from ejerc2
            int number, numCountHelp, numberInv = 0, numCount = 0;
            

            Console.WriteLine("Number inverter");

            Console.Write("Input your number here: ");
            number = int.Parse(Console.ReadLine());
            numCountHelp = number;

            while (numCountHelp > 1)                                                                //conditioning while so it stops when reaching 1
            {
                numCountHelp /= 10;
                numCount += 1;
            }

            while (numCount >= 0)                                                                   //conditioning while so it stops in 0
            {
                numberInv += ((number % 10) * (int)Math.Pow(10, (double) numCount));                //double and int transformations, Math.Pow only works in double     
                number /= 10;
                numCount -= 1;
            }

            Console.WriteLine("Your inverted number is " + numberInv);
        }
    }
}
