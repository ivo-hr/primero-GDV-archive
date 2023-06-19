using System;

namespace finalProj
{
    class MainScript
    {
        static void Main(string[] args)
        {
            //Tipo de juego
            bool tableType = false;

            //Nombre del nivel
            string lvl;


            //Menú ppal del juego
            Menu(out tableType, out lvl);


            Console.Clear();

            //Dependiendo del modo de juego:
            if (tableType)
            {
                //Se inicia la sopa de letras
                WSTable ws = new WSTable(lvl);
                ws.Draw();
            }
            else
            {
                //Se inicia el crucigrama
                CWTable cw = new CWTable(lvl);
                cw.Draw();
            }

            
        }

        //Menú ppal
        public static void Menu(out bool tableType, out string lvl)
        {
            //Asignación inicial del tipo de juego
            tableType = true;

            //Título
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" _     _  _______  ______    ______   _______  _______  _______  ______    _______  __   __ ");
            Console.WriteLine("| | _ | ||       ||    _ |  |      | |       ||       ||   _   ||    _ |  |       ||  | |  |");
            Console.WriteLine("| || || ||   _   ||   | ||  |  _    ||  _____||    ___||  |_|  ||   | ||  |       ||  |_|  |");
            Console.WriteLine("|       ||  | |  ||   |_||_ | | |   || |_____ |   |___ |       ||   |_||_ |       ||       |");
            Console.WriteLine("|       ||  |_|  ||    __  || |_|   ||_____  ||    ___||       ||    __  ||      _||       |");
            Console.WriteLine("|   _   ||       ||   |  | ||       | _____| ||   |___ |   _   ||   |  | ||     |_ |   _   |");
            Console.WriteLine("|__| |__||_______||___|  |_||______| |_______||_______||__| |__||___|  |_||_______||__| |__|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("&   _______  ______    _______  _______  _______  _     _  _______  ______    ______        ");
            Console.WriteLine("   |       ||    _ |  |       ||       ||       || | _ | ||       ||    _ |  |      |       ");
            Console.WriteLine("   |       ||   | ||  |   _   ||  _____||  _____|| || || ||   _   ||   | ||  |  _    |      ");
            Console.WriteLine("   |       ||   |_||_ |  | |  || |_____ | |_____ |       ||  | |  ||   |_||_ | | |   |      ");
            Console.WriteLine("   |      _||    __  ||  |_|  ||_____  ||_____  ||       ||  |_|  ||    __  || |_|   |      ");
            Console.WriteLine("   |     |_ |   |  | ||       | _____| | _____| ||   _   ||       ||   |  | ||       |      ");
            Console.WriteLine("   |_______||___|  |_||_______||_______||_______||__| |__||_______||___|  |_||______|       ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            //Opciones de juego
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                   G A M E  S E L E C T");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                       1. WordSearch"); //l20
            Console.WriteLine("                                       2. Crossword");  //l21

            //Lectura del selector del juego
            string typeSel = Console.ReadLine();

            //Elige tablero según el número escrito
            if (typeSel == "1")
            {
                tableType = true;
            }
            else if (typeSel == "2")
            {
                tableType = false;
            }

            //Selección del nivel
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                  L E V E L  S E L E C T");
            Console.WriteLine("");

            //Lectura de selecc. del nivel
            string rawLvlNo = Console.ReadLine();

            //Constructor del nombre del archivo
            while (rawLvlNo.Length < 2)
            {
                rawLvlNo = "0" + rawLvlNo;
            }

            lvl = "lv" + rawLvlNo + ".txt";
        }
    }   
}
