using System;

namespace ejerc5
{
    class Program
    {
        static void Main(string[] args)
        {
            int number, numCountHelp, numCount = 0, side1 = 0, side2 = 0, side2inv = 0;

            Console.WriteLine("Miremos si tu número es capicúa!");

            Console.Write("Tu número: ");
            number = int.Parse(Console.ReadLine());
            numCountHelp = number;

            while (numCountHelp > 0)
            {
                numCountHelp /= 10;
                numCount += 1;
            }

            if ((numCount % 2) == 0)
            {
                side1 = number / (int)(Math.Pow(10, (double)(numCount / 2)));
                side2 = number % (int)(Math.Pow(10, (double)(numCount / 2)));

            }
            else
            {
                side1 = number / (int)(Math.Pow(10, (double)(numCount / 2) + 1));
                side2 = number % (int)(Math.Pow(10, (double)(numCount / 2)));
            }

            numCount /= 2;

            while (numCount >= 0)                                                                   
            {
                side2inv += ((side2 % 10) * (int)Math.Pow(10, (double)numCount));                
                side2 /= 10;
                numCount -= 1;
            }

            side2inv /= 10;

            if (side1 == side2inv)
            {
                Console.WriteLine("Tu número sí es capicúa!");
            }
            else
            {
                Console.WriteLine("Tu número no es capicúa.");
            }


        }
    }
}
