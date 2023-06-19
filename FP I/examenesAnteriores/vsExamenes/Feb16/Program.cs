using System;

namespace Feb16
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int[] combSecr = { 0, 0, 0, 0}, combJug = {0, 0, 0, 0};
            int m = 0, h = 0;

            generaComb(combSecr);

            Console.WriteLine("Bienvenido a Mastermind!");
            Console.WriteLine(combSecr[0] + " " + combSecr[1] + " " + combSecr[2] + " " + combSecr[3]);
            while (m < 4)
            {
                Console.WriteLine(" ");
                Console.Write("Tu combinación (4 dígitos): ");
                leeCombinacion(combJug);
                Console.WriteLine(combJug[0] + " " + combJug[1] + " " + combJug[2] + " " + combJug[3]);

                evalua(combSecr, combJug, ref m, ref h);
                Console.WriteLine("Muertos: " + m + "      Heridos: " + h);
            }

            if(m == 4)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("HAS GANADO!!!");
                Console.ForegroundColor = ConsoleColor.Black;
            }

        }

        static void generaComb(int[] combSecr)
        {
            int[] v = { 5, 3, 1, 9, 6, 0, 2, 8, 4, 7 };

            Random rnd = new Random();
            int i = rnd.Next(0, 7);
            for(int j = 0; j < 4; j++)
            {
                combSecr[j] = v[i + j];
            }
        }

        static bool muerto(int[] combSecr, int[] combJug, int pos)
        {
            if (combSecr[pos] == combJug[pos]) { return true; }   
            else { return false; }
        }

        static bool herido(int[] combSecr, int[] combJug, int pos)
        {
            if (combSecr[pos] != combJug[pos])
            {
                bool wtf = false;
                for (int i = 0; i < 4; i++)
                {
                    if (combSecr[i] == combJug[pos]) { wtf = true; }
                }
                return wtf;
            }
            else { return false; }

        }

        static void evalua(int[] combSecr, int[] combJug, ref int m, ref int h)
        {
            m = 0;
            h = 0;
            for(int pos = 0; pos < 4; pos++)
            {
                if (muerto(combSecr, combJug, pos)) { m++; }
                if (herido(combSecr, combJug, pos)) { h++; }
            }
        }

        static void leeCombinacion(int[] combJug)
        {
            
            int input = int.Parse(Console.ReadLine());

            combJug[0] = input / 1000;
            combJug[1] = input / 100 % 10;
            combJug[2] = input / 10 % 10;
            combJug[3] = input % 10;
        }
    }
}
