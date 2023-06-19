using System;

namespace ejerc6
{
    class Program
    {
        static void Main(string[] args)
        {
            double fund, interest, installAn, quota, total, totInterest ;
            string fundS, interestS, installAnS;

            Console.WriteLine("Welcome to your mortgage calculator. We will start your calculation by asking necessary data for the forementioned.");
            Console.WriteLine(" ");

            Console.Write("Amount of funds applied for: ");
            fundS = Console.ReadLine();

            Console.Write("Interest per year: ");
            interestS = Console.ReadLine();

            Console.Write("Installments (years): ");
            installAnS = Console.ReadLine();

            fund = double.Parse(fundS);
            interest = double.Parse(interestS);
            installAn = double.Parse(installAnS);
            
            quota = (fund * (interest / 12)) / (100 * (1 - (Math.Pow(1 + ((interest /12) / 100), (-installAn * 12)))));
            total = (quota * installAn * 12);
            totInterest = (total - fund);

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("- - - - -  R E S U L T S  - - - - -");
            Console.WriteLine(" ");
            Console.WriteLine("Monthly quota: . . . . . . . . . " + quota + "$");
            Console.WriteLine("Interest in total: . . . . . . . " + totInterest + "$");
            Console.WriteLine("Due in total: . . . . . . . . . ." + total + "$");
            



        }
    }
}
