using System;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y;
            Console.WriteLine("Hi! Let's change the value of X and Y between them (by cheating of course)!");
            Console.Write("First, let's set a value for X: ");
            x = int.Parse(Console.ReadLine());

            Console.Write("Now let's do it for Y: ");
            y = int.Parse(Console.ReadLine());

            Console.WriteLine("Before, X had a value of " + x + " and Y a value of " + y + ".");

            int xTemp;
            xTemp = x;
            x = y;
            y = xTemp;


            Console.WriteLine("Now, X has a value of " + x + " and Y a value of " + y + "!");
        }
        }
    }
