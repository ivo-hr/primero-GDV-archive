using System;
using System.IO;

namespace PacMan_Practica_2_FP2
{
    class Ppal
    {
        
        
        static void Main()
        {
            string levelNo;

            levelSelect(out levelNo);
            
            Tablero t = new Tablero("levels/level" + levelNo + ".dat");
            t.Dibuja();
            int lap = 200; // retardo para bucle ppal
            char c = ' ';
            while (!t.finNivel() && !t.PacMuerto()) 
            {
                // input de usuario
                LeeInput(ref c);
                // procesamiento del input
                if (c! == ' ' && t.CambioDirecc(c)) c = ' ';
                t.MuevePacman();
                // IA de los fantasmas: TODO
                // rederizado
                t.Dibuja();

            }
            // retardo
            System.Threading.Thread.Sleep(lap);
        }

        static void levelSelect(out string levelNo)
        {
            int parsable;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" _______ _______ _______      __   __ _______ __    _ ");
            Console.WriteLine("|       |   _   |       |    |  |_|  |   _   |  |  | |");
            Console.WriteLine("|    _  |  |_|  |       |____|       |  |_|  |   |_| |");
            Console.WriteLine("|   |_| |       |       |____|       |       |       |");
            Console.WriteLine("|    ___|       |      _|    |       |       |  _    |");
            Console.WriteLine("|   |   |   _   |     |_     | ||_|| |   _   | | |   |");
            Console.WriteLine("|___|   |__| |__|_______|    |_|   |_|__| |__|_|  |__|");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                  Select level: ");

            levelNo = Console.ReadLine();

            try
            {
                parsable = int.Parse(levelNo);
            }
            catch
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You must insert a number!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Sending you to level 01...");
            }

            if(levelNo.Length < 2)
            {
                levelNo = "0" + levelNo;
            }
        
        }

        static char LeeInput(ref char c)
        {
            c = ' ';
            if (Console.KeyAvailable)
            {
                string tecla = Console.ReadKey(true).Key.ToString();
                switch (tecla)
                {
                    case "LeftArrow": c = 'l'; break;
                    case "UpArrow": c = 'u'; break;
                    case "RightArrow": c = 'r'; break;
                    case "DownArrow": c = 'd'; break;
                    case "Escape": c = 'q'; break;
                    case "Z": c = 'z'; break;
                    case "S": c = 's'; break;
                    default: c = ' '; break;
                }
            }
            Console.WriteLine(c);
            return c;
        }

    }
}

