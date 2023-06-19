using System;

namespace ejerc3
{
    class Program
    {
        static void Main(string[] args)
        {
            double number, factored = 1;                                            //using double to have wider range of numbers to operate with (int is limited)

            Console.WriteLine("Factorial calculator");

            Console.Write("number: " );
            number = double.Parse(Console.ReadLine());
            number = Math.Truncate(number);                                         //truncating so no decimal value messes up operations, rounding isn't accurate

            while (number != 0)
            {
                factored *= number;
                number -= 1;
            }

            Console.WriteLine("Your factored number is " + factored + ".");

        }
    }
}
