using System;

namespace Exámenes
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int ancho, largo, posicion, pasos = 0;
            bool choff = false;
            int nextMove;


            ancho = pideEntero("Ancho de la pasarela: ", 1, 10);
            largo = pideEntero("Largo de la pasarela: ", 1, 300);
            posicion = ancho / 2;

            Console.SetCursorPosition(0, 3);
            dibuja(ancho, pasos, posicion, choff);

            while (pasos < largo && !choff)
            {
                nextMove = rnd.Next(0, 3);
                if (nextMove == 1) { posicion -= 1; }
                if (nextMove == 2) { posicion += 1; }

                if (posicion < 0 || posicion >= ancho)
                {
                    choff = true;
                }

                dibuja(ancho, pasos, posicion, choff);

                pasos += 1;
                System.Threading.Thread.Sleep(100 * rnd.Next(1, 10));
            }

            if (pasos == largo && !choff)
            {
                Console.SetCursorPosition(0, pasos + 2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Has llegado!");
                Console.ForegroundColor = ConsoleColor.Black;
            }

        }

        public static int pideEntero(string msg, int min, int max)
        {
            Console.Write(msg);
            int input = int.Parse(Console.ReadLine());

            if (input < min || input > max)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("number input too low/high. Selecting default value 4.");
                input = 4;
            }

            return input;
        }

        public static void dibuja (int ancho, int pasos, int posicion, bool choff)
        {
            if (choff)
            {
                Console.SetCursorPosition(0, pasos + 2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Choff!");
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.SetCursorPosition(0, pasos + 2);
                for (int i = 0; i < ancho; i++)
                {
                    if (i != (posicion))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("-");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("0");
                    }

                }
            }
        }
    }
}
