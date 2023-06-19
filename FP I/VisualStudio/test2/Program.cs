using System;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            double timeInPure, timeS,  timeM;
            string timeIn;
            int timeH, timeMPure;

            Console.Write("Hi! ");
            Console.Write("Let's turn your seconds into hours and minutes!");
            Console.Write(" Write any number of seconds --->  ");

            timeIn = Console.ReadLine();
            timeInPure = double.Parse(timeIn);

            timeS = timeInPure % 60;
            timeMPure = (int)((timeInPure - timeS) / (60));
            timeM = timeMPure % (60);
            timeH = (timeMPure / (60));

            Console.Write("That's " + timeH + " hours, " + timeM + " minutes and " + timeS + " seconds.");
        }
    }
}