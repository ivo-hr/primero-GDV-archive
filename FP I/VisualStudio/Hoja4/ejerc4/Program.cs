using System;

namespace ejerc4
{
    class Program
    {
        static void Main(string[] args)
        {
            double consum, toOwe = 0;

            Console.WriteLine("< Excessive water consumption penalty calculator >");
            Console.WriteLine(" ");
            Console.WriteLine("     - - - P E N A L T I E S - - -");
            Console.WriteLine("First 100 m3: . . . . . . . . 0.15$/m3");
            Console.WriteLine("100 to 500 m3: . . . . . . . .0.20$/m3");
            Console.WriteLine("500 to 1000 m3: . . . . . . . 0.35$/m3");
            Console.WriteLine("More than 1000 m3: . . . . . .0.80$/m3");
            Console.WriteLine("                  - - -");
            Console.WriteLine(" ");
            Console.Write("Your consumption: ");
            consum = double.Parse(Console.ReadLine());

            if (consum <= 100)
                toOwe = consum * 0.15;

            else if ((100 < consum) && (consum <= 500))
            {
                toOwe = (100 * 0.15) + ((consum - 100) * 0.2);
            }
            else if ((500 < consum) && (consum <= 1000))
            {
                toOwe = (100 * 0.15 + 400 * 0.2) + ((consum - 500) * 0.35);
            }
            else if ((consum > 1000))
            {
                toOwe = (100 * 0.15 + 400 * 0.2 + 500 * 0.35) + ((consum - 1000) * 0.8);
            }

            Console.WriteLine("Due to your consumption you owe " + toOwe + "$.");
        }
    }
}
