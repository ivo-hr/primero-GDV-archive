using System;

namespace ejerc7
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, xPos, xNeg;

            Console.WriteLine("x value finder in ax2 + bx + c = 0");

            Console.Write("a = ");
            a = double.Parse(Console.ReadLine());

            Console.Write("b = ");
            b = double.Parse(Console.ReadLine());

            Console.Write("c = ");
            c = double.Parse(Console.ReadLine());


            xPos = ((-b + (Math.Sqrt(Math.Pow(b, 2) - 4 * a * c))) / (2 * a));
            xNeg = (-b - (Math.Sqrt((Math.Pow(b, 2)) - 4 * a * c))) / (2 * a);


            Console.WriteLine("x is equal to " + xPos + " and " + xNeg + ".");
            Console.WriteLine("x = " + xPos + " , " + xNeg);




        }
    }
}
