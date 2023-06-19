using System;

namespace test1
{
    class Test
    {
        static void Main()
        {
            double RadC, AreC;
            string RadCs;

            Console.Write("Hi! Let's find the area to your circle.  ");

            Console.Write("What's the radius of your circle?  --->  ");

            RadCs = Console.ReadLine();
            RadC = double.Parse(RadCs);

            AreC = (RadC * Math.PI) / 2 ;

            Console.WriteLine("The area of your circle with a radius of " + RadC + " is " + AreC + ".");
        }
    }
}