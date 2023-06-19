using System;

namespace ejerc1
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeM, timeH;
            double timeS, fulltimeS;
            string timeSst, timeMst, timeHst;

            Console.WriteLine("Hi! Let's covert your hours, minutes and seconds into seconds only!");

            Console.WriteLine("First, tell me the number of hours: ");
            timeHst = Console.ReadLine();

            Console.WriteLine("Now tell me the number of minutes: ");
            timeMst = Console.ReadLine();

            Console.WriteLine("Lastly, the number of seconds: ");
            timeSst = Console.ReadLine();

            timeH = int.Parse(timeHst);
            timeM = int.Parse(timeMst);
            timeS = double.Parse(timeSst);

            fulltimeS = (timeH * 60 * 60) + (timeM * 60) + timeS;

            Console.WriteLine("Okay! Your time in seconds is " + fulltimeS + " seconds!");
        }
    }
}
