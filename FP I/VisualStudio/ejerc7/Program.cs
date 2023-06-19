using System;

namespace ejerc7
{
    class Program
    {
        static void Main(string[] args)
        {
            double ano;
            string anoS;
            bool bisiesto;

            Console.WriteLine("Es tu año bisiesto?");
            Console.Write("Tu año: ");

            anoS = Console.ReadLine();
            ano = double.Parse(anoS);

            bisiesto = ((((ano % 4) == 0)) && (ano % 100 > 0)) || ((ano % 400) == 0 );

            Console.WriteLine("Tu año es bisiesto: " + bisiesto);

        }
    }
}
