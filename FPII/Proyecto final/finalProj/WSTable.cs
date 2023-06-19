using System;
using System.IO;

namespace finalProj
{
    //MODO SOPA DE LETRAS
    class WSTable
    {
        
        //Variables necesarias para el juego:

        //Archivo del nivel en un string
        string lvlTrans = "";
        //sopa de letras
        char[,] soup;
        //Definiciones
        string[] defs;
        //Soluciones
        string[] sol;
        //Palabras resueltas/por resolver
        bool[] resolved;

        public WSTable(string file)
        {
            //Inic. del lector del nivel
            StreamReader lvlRaw;

            //Intenta leer el nivel seleccionado
            try
            {
                lvlRaw = new StreamReader(file);
            }
            //Si no inicia el de prueba
            catch
            {
                lvlRaw = new StreamReader("lv00.txt");
            }
            
            //Crea lvlTrans hasta el final del archivo
            while (!lvlRaw.EndOfStream)
            {
                lvlTrans += lvlRaw.ReadLine() + ";";

            }

            //Reconstruye el archivo del nivel con lvlTrans y cuenta las líneas
            string[] fullLvl = lvlTrans.Split(";");
            int lines = fullLvl.GetLength(0);


            //Construye lo necesario para el juego:
            for (int i = 0; i < lines; i++)
            {
                //La sopa de letras
                if (fullLvl[i] == "0")
                {
                    SoupMaker(out soup, fullLvl, i);
                }
                //Las definiciones
                else if (fullLvl[i] == "2")
                {
                    DefsMaker(out defs, fullLvl, i);
                }
                //Las soluciones
                else if (fullLvl[i] == "3")
                {
                    SolMaker(out sol, out resolved, fullLvl, i);
                }
            }


        }


        //Creador de la sopa de letras
        void SoupMaker(out char[,] soup, string[] lvl, int line)
        {
            //La línea de la sopa de letras (indep. de la linea del archivo)
            int soupLine = 0;

            //Crea el array de la sopa de letras
            soup = new char[lvl[line + 1].Length, lvl[line + 1].Length];

            //Asigna los caracteres a cada posicion del array
            while (lvl[line] != "1")
            {
                line++;

                char[] lvlLine = lvl[line].ToCharArray();

                for (int i = 0; i < lvl[line].Length; i++)
                {
                    soup[i, soupLine] = lvlLine[i];                   
                }
                if (soupLine < soup.GetLength(0)-1)
                {
                    soupLine++;
                }
                
            }
        }

        //Creador de las definiciones
        void DefsMaker(out string[] defs, string[] lvl, int line)
        {
            //Crea el tamaño del array de las definicones
            defs = new string[6];
            
            //La línea de las definiciones (indep. del archivo)
            int solLine = 0;

            //Asigna las definiciones en el array
            while (lvl[line] != "3" || solLine < defs.Length)
            {
                line++;

                //Por si se pasa del límite del array
                try
                {
                    defs[solLine] = lvl[line];
                }
                catch
                {

                }

                solLine++;
            }
        }

        //Creador de las soluciones
        void SolMaker(out string[] sol, out bool[] resolved, string[] lvl, int line)
        {
            //Crea los arrays de las soluciones y si se han solucionado
            sol = new string[6];
            resolved = new bool[6];

            //Línea de las soluciones (indep. del archivo)
            int solLine = 0;

            //Asigna las soluciones en el array
            while (lvl[line] != "")
            {
                line++;

                //Por si se pasa del límite del array
                try
                {
                    sol[solLine] = lvl[line];
                    resolved[solLine] = false;
                }
                catch
                {

                }

                
                solLine++;
                
            }
        }

        //DIBUJADOR DEL NIVEL
        public void Draw()
        {
            //Resetea la consola
            Console.Clear();
            //Variables necesarias para dibujar
            int fil = soup.GetLength(0);
            int col = soup.GetLength(1);
            int defNum = defs.GetLength(0);

            //Dibujo de la sopa
            for (int i = 0; i < fil; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.SetCursorPosition(2 * i, 2 * j);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(soup[i, j]);
                } 
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            //Dibujo de las definiciones
            for (int i = 0; i < defNum; i++)
            {
                if (resolved[i])
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(sol[i]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(defs[i]);
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(" ");
            Console.WriteLine(" ");


            //Si no se ha acabado,
            if (!Finish())
            {
                //Permite al jugador hacer un input
                PlayerInput();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }

        }

        //INPUT DEL USUARIO
        public void PlayerInput()
        {
            //Lo que escribe el jugador
            string playerWrite = Console.ReadLine();

            //Lo convierte a mayúsculas para funcionar mejor
            playerWrite = playerWrite.ToUpper();

            //Mira si se ha solucionado algo
            for (int i = 0; i < sol.GetLength(0); i++)
            {
                if (playerWrite == sol[i])
                {
                    resolved[i] = true;
                }
            }

            //Dibuja de nuevo
            Draw();
        }

        //SENSOR DEL FIN
        bool Finish()
        {
            //Para devolver al método
            bool finish = false;
            //Par acomparar nú. de soluciones con lo solucionado
            int actualRes = 0;

            //Cuenta cuántas se han solucionado
            for (int i = 0; i < resolved.Length; i++)
            {
                if (resolved[i])
                {
                    actualRes++;
                }
            }

            //Dependiendo si se han solucionado todas,
            if (actualRes < resolved.Length)
            {
                //no se acaba el juego
                finish = false;
            }
            else
            {
                //o sí
                finish = true;
            }
            return finish;
        }
    }
}
