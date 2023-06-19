using System;

namespace ejerc6
{
    class Program
    {
        static void Main(string[] args)
        {
            int cantIngrCent, bill500, bill200, bill100, bill50, bill20, bill10, bill5, coin2, coin1, coin05, coin02, coin01, coin005, coin002, coin001;
            double cantIngr;
            string cantIngrS;


            Console.WriteLine("Bienvenido a la calculadora de cambio.");

            Console.Write("Cantidad de dinero a cambiar: ");
            cantIngrS = Console.ReadLine();
            cantIngr = double.Parse(cantIngrS);

            cantIngrCent = (int)(100 * cantIngr);

            bill500 = cantIngrCent / (500 * 100);
            bill200 = cantIngrCent % (500 * 100) / (200 * 100);
            bill100 = cantIngrCent % (500 * 100) % (200 * 100) / (100 * 100);
            bill50 = cantIngrCent % (500 *100) % (200 * 100) % (100 * 100) / (50 * 100);
            bill20 = cantIngrCent % (500 * 100) % (200 * 100) % (100 * 100) % (50 * 100) / (20 * 100);
            bill10 = cantIngrCent % (500 * 100) % (200 * 100) % (100 * 100) % (50 * 100) % (20 * 100) / (10 * 100);
            bill5 = cantIngrCent % (500 * 100) % (200 * 100) % (100 * 100) % (50 * 100) % (20 * 100) % (10 * 100) / (5 * 100);
            coin2 = cantIngrCent % (500 * 100) % (200 * 100) % (100 * 100) % (50 * 100) % (20 * 100) % (10 * 100) % (5 * 100) / (2 * 100);
            coin1 = cantIngrCent % (500 * 100) % (200 * 100) % (100 * 100) % (50 * 100) % (20 * 100) % (10 * 100) % (5 * 100) % (2 * 100) / (100);
            coin05 = cantIngrCent % (500 * 100) % (200 * 100) % (100 * 100) % (50 * 100) % (20 * 100) % (10 * 100) % (5 * 100) % (2 * 100) % (100) / (50);
            coin02 = cantIngrCent % (500 * 100) % (200 * 100) % (100 * 100) % (50 * 100) % (20 * 100) % (10 * 100) % (5 * 100) % (2 * 100) % (100) % (50) / (20);
            coin01 = cantIngrCent % (500 * 100) % (200 * 100) % (100 * 100) % (50 * 100) % (20 * 100) % (10 * 100) % (5 * 100) % (2 * 100) % (100) % (50) % (20) / (10);
            coin005 = cantIngrCent % (500 * 100) % (200 * 100) % (100 * 100) % (50 * 100) % (20 * 100) % (10 * 100) % (5 * 100) % (2 * 100) % (100) % (50) % (20) % (10) / (5);
            coin002 = cantIngrCent % (500 * 100) % (200 * 100) % (100 * 100) % (50 * 100) % (20 * 100) % (10 * 100) % (5 * 100) % (2 * 100) % (100) % (50) % (20) % (10) % (5) / (2);
            coin001 = cantIngrCent % (500 * 100) % (200 * 100) % (100 * 100) % (50 * 100) % (20 * 100) % (10 * 100) % (5 * 100) % (2 * 100) % (100) % (50) % (20) % (10) % (5) % (2) / 1;

            Console.WriteLine(" - - - CAMBIO - - - ");
            Console.WriteLine(" ");
            Console.WriteLine("Billetes de 500$: . . ." + bill500 + "             Monedas de 2$: . . ." + coin2);
            Console.WriteLine("Billetes de 200$: . . ." + bill200 + "             Monedas de 1$: . . ." + coin1);
            Console.WriteLine("Billetes de 100$: . . ." + bill100 + "             Monedas de 50c: . . " + coin05);
            Console.WriteLine("Billetes de 50$: . . . " + bill50 + "             Monedas de 20c: . . " + coin02);
            Console.WriteLine("Billetes de 20$: . . . " + bill20 + "             Monedas de 10c: . . " + coin01);
            Console.WriteLine("Billetes de 10$: . . . " + bill10 + "             Monedas de 5c: . . ." + coin005);
            Console.WriteLine("Billetes de 5$: . . . ." + bill5 + "             Monedas de 2c: . . ." + coin002);
            Console.WriteLine("                                     Monedas de 1c: . . ." + coin001);



        }
    }
}
