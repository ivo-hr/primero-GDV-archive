//Enrique Juan Gamboa
//Alejandro Martínez Fernández

using System;
using System.IO;


namespace Practica1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Selección de nivel
            Console.Write("Selecciona un nivel: ");
            int n = int.Parse(Console.ReadLine());

            //Inicio del nivel seleccionado
            Tablero tab = LeeNivel("levels", n);

            //Dibujo inicial
            Dibuja(tab, n);

            //Variables relevantes para el bucle ppal
            string move = "";
            char a;
            bool finJuego = false;

            // B U C L E  P R I N C I P A L
            while (!finJuego)
            {

                Console.Clear();
                a = LeeInput();
                ProcesaInput(ref tab, a, ref move);
                Dibuja(tab, n);
                finJuego = Terminado(tab);
                System.Threading.Thread.Sleep(100);
            }

        }

        struct Coor { public int fil, col; };
        // coordenadas fila y columna en el tablero
        enum TipoCasilla { Muro, Libre, Destino };
        // 3 tipos de casillas en el tablero
        struct Casilla
        {
            public TipoCasilla tipo; // información fija de la casilla (muro, libre o destino)
            public bool caja;
            // información variable: si tiene o no caja
        }
        struct Tablero
        { // tipo tablero
            public Casilla[,] cas; // matriz de casillas
            public Coor jug;
            // posición del jugador
        }


        static Tablero LeeNivel(string file, int n)
        {
            //Convierte el archivo en un string
            StreamReader lvlFile = new StreamReader(file);
            //Variables para la búsqueda del nivel
            Tablero tab = new Tablero();
            string nombre = "Level " + n;
            string nivel = "";
            //Búsqueda del nivel
            while (nivel != nombre)
            {
                nivel = lvlFile.ReadLine();
            }
            //Pone un ";" en cada línea nueva
            string mapa = "";
            while (nivel != "")
            {
                nivel = lvlFile.ReadLine();

                if (nivel != "") mapa += nivel + ";";
            }
            //Cálculo del número de filas y columnas
            int fil = 0;
            int col = 0;
            int colMax = 0;
            for (int i = 0; i < mapa.Length; i++)
            {
                char u;
                u = mapa[i];

                if (u != ';') col++;
                else
                {
                    fil++;
                    if (col > colMax) colMax = col;
                    col = 0;
                }

            }
            //Cierre del archivo
            lvlFile.Close();
            //Variables par aestructurar el nivel
            String[] tablero = mapa.Split(";");
            tab.cas = new Casilla[fil, colMax];

            //Estructuración del nivel
            for (int i = 0; i < fil; i++)
            {
                char[] letras = tablero[i].ToCharArray();
                for (int j = 0; j < letras.Length; j++)
                {
                    char u = letras[j];
                    if (u == '#')
                    {
                        tab.cas[i, j].tipo = TipoCasilla.Muro;
                        tab.cas[i, j].caja = false;

                    }
                    else if (u == ' ')
                    {
                        tab.cas[i, j].tipo = TipoCasilla.Libre;
                        tab.cas[i, j].caja = false;

                    }
                    else if (u == '$')
                    {
                        tab.cas[i, j].tipo = TipoCasilla.Libre;
                        tab.cas[i, j].caja = true;

                    }
                    else if (u == '.')
                    {
                        tab.cas[i, j].tipo = TipoCasilla.Destino;
                        tab.cas[i, j].caja = false;

                    }
                    else if (u == '*')
                    {
                        tab.cas[i, j].tipo = TipoCasilla.Destino;
                        tab.cas[i, j].caja = true;

                    }
                    else if (u == '@')
                    {
                        tab.cas[i, j].tipo = TipoCasilla.Libre;
                        tab.cas[i, j].caja = false;
                        tab.jug.fil = i;
                        tab.jug.col = j;

                    }
                    else if (u == '+')
                    {
                        tab.cas[i, j].tipo = TipoCasilla.Destino;
                        tab.cas[i, j].caja = false;
                        tab.jug.fil = i;
                        tab.jug.col = j;

                    }


                }
            }
            //Devuelve el nivel
            return tab;
        }


        static void Dibuja(Tablero tab, int mov)
        {
            //Var. par adibujar el nivel completo
            int fil = tab.cas.GetLength(0);
            int col = tab.cas.GetLength(1);
            //Dibujo por líneas del nivel
            for (int i = 0; i < fil; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    //Dibujo de cada elemento distinctivamente
                    if ((i == tab.jug.fil) && (j == tab.jug.col))
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write("ºº");
                    }
                    else if (tab.cas[i, j].tipo == TipoCasilla.Libre && tab.cas[i, j].caja)
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.Write("[]");
                    }
                    else if (tab.cas[i, j].tipo == TipoCasilla.Destino && tab.cas[i, j].caja)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write("[]");
                    }
                    else if (tab.cas[i, j].tipo == TipoCasilla.Libre && !tab.cas[i, j].caja)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write("  ");
                    }
                    else if (tab.cas[i, j].tipo == TipoCasilla.Destino && !tab.cas[i, j].caja)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("  ");
                    }
                    else if (tab.cas[i, j].tipo == TipoCasilla.Muro)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write("  ");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine("");
            }
        }


        static char LeeInput()
        {
            char c = ' ';
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


        static bool Siguiente(Coor pos, char dir, Tablero tab, out Coor sig)
        {
            //Var. par aver si se puede mover el jugador
            sig.col = pos.col;
            sig.fil = pos.fil;
            int colTab = tab.cas.GetLength(1);
            int filTab = tab.cas.GetLength(0);
            bool siguientear = false;

            if (dir == 'l' && pos.col - 1 > 0)
            {
                sig.col = pos.col - 1;
                siguientear = true;
            }

            else if (dir == 'r' && pos.col + 1 < colTab)
            {
                sig.col = pos.col + 1;
                siguientear = true;
            }
            else if (dir == 'u' && pos.fil - 1 > 0)
            {
                sig.fil = pos.fil - 1;
                siguientear = true;
            }

            else if (dir == 'd' && pos.fil + 1 < filTab)
            {
                sig.fil = pos.fil + 1;
                siguientear = true;
            }

            return siguientear;
        }


        static char Mueve(ref Tablero tab, char dir)
        {
            Coor pos;
            Coor sig;
            pos.fil = tab.jug.fil;
            pos.col = tab.jug.col;
            //Añade info a los movimientos (Si se puede, si hay caja empujada, etc)
            if (Siguiente(pos, dir, tab, out sig))
            {
                if (dir == 'l' && tab.cas[sig.fil, sig.col].tipo != TipoCasilla.Muro)
                {
                    if ((tab.cas[sig.fil, sig.col].caja) && (!tab.cas[sig.fil, sig.col - 1].caja) && (tab.cas[sig.fil, sig.col - 1].tipo != TipoCasilla.Muro))
                    {
                        dir = 'L';
                    }
                    else if ((tab.cas[sig.fil, sig.col].caja && (tab.cas[sig.fil, sig.col - 1].caja) || (tab.cas[sig.fil, sig.col - 1].tipo == TipoCasilla.Muro)))
                    {
                        dir = 'X';
                    }

                    else dir = 'l';

                }

                else if (dir == 'r' && tab.cas[sig.fil, sig.col].tipo != TipoCasilla.Muro)
                {
                    if (tab.cas[sig.fil, sig.col].caja && !tab.cas[sig.fil, sig.col + 1].caja && (tab.cas[sig.fil, sig.col + 1].tipo != TipoCasilla.Muro))
                    {
                        dir = 'R';
                    }
                    else if ((tab.cas[sig.fil, sig.col].caja && (tab.cas[sig.fil, sig.col + 1].caja) || (tab.cas[sig.fil, sig.col + 1].tipo == TipoCasilla.Muro)))
                    {
                        dir = 'X';
                    }

                    else dir = 'r';

                }

                else if (dir == 'u' && tab.cas[sig.fil, sig.col].tipo != TipoCasilla.Muro)
                {
                    if (tab.cas[sig.fil, sig.col].caja && !tab.cas[sig.fil - 1, sig.col].caja && (tab.cas[sig.fil - 1, sig.col].tipo != TipoCasilla.Muro))
                    {
                        dir = 'U';
                    }
                    else if ((tab.cas[sig.fil, sig.col].caja && (tab.cas[sig.fil - 1, sig.col].caja) || (tab.cas[sig.fil - 1, sig.col].tipo == TipoCasilla.Muro)))
                    {
                        dir = 'X';
                    }

                    else dir = 'u';

                }

                else if (dir == 'd' && tab.cas[sig.fil, sig.col].tipo != TipoCasilla.Muro)
                {
                    if (tab.cas[sig.fil, sig.col].caja && !tab.cas[sig.fil + 1, sig.col].caja && (tab.cas[sig.fil + 1, sig.col].tipo != TipoCasilla.Muro))
                    {
                        dir = 'D';
                    }
                    else if ((tab.cas[sig.fil, sig.col].caja && (tab.cas[sig.fil + 1, sig.col].caja) || (tab.cas[sig.fil + 1, sig.col].tipo == TipoCasilla.Muro)))
                    {
                        dir = 'X';
                    }

                    else dir = 'd';

                }

                else dir = 'X';
            }

            return dir;
        }


        static void ProcesaInput(ref Tablero tab, char dir, ref string movs)
        {
            //Método mueve en un char
            char muevMet = Mueve(ref tab, dir);

            //Proceso general de movimiento, incluye el de cajas
            //Minúsculas => no se mueve caja
            if (muevMet == 'l')
            {
                tab.jug.col--;

                dir = 'l';
            }
            //Mayúsculas => se mueve una caja
            else if (muevMet == 'L')
            {
                tab.cas[tab.jug.fil, tab.jug.col - 2].caja = true;
                tab.cas[tab.jug.fil, tab.jug.col - 1].caja = false;

                tab.jug.col--;

                dir = 'L';
            }

            else if (muevMet == 'r')
            {
                tab.jug.col++;

                dir = 'r';
            }

            else if (muevMet == 'R')
            {
                tab.cas[tab.jug.fil, tab.jug.col + 2].caja = true;
                tab.cas[tab.jug.fil, tab.jug.col + 1].caja = false;

                tab.jug.col++;

                dir = 'R';
            }

            else if (muevMet == 'u')
            {
                tab.jug.fil--;

                dir = 'u';
            }

            else if (muevMet == 'U')
            {
                tab.cas[tab.jug.fil - 2, tab.jug.col].caja = true;
                tab.cas[tab.jug.fil - 1, tab.jug.col].caja = false;

                tab.jug.fil--;

                dir = 'U';
            }


            else if (muevMet == 'd')
            {
                tab.jug.fil++;

                dir = 'd';
            }

            else if (muevMet == 'D')
            {
                tab.cas[tab.jug.fil + 2, tab.jug.col].caja = true;
                tab.cas[tab.jug.fil + 1, tab.jug.col].caja = false;

                tab.jug.fil++;

                dir = 'D';
            }
            //No ha habido movimiento
            else if (muevMet == 'X')
            {
                dir = 'X';
            }
            //Guarda los movimientos realizados
            if (dir != 'z' && dir != 's' && dir != 'X')
            {
                movs += dir;
            }

            //Vuelve al movimiento anterior
            if (dir == 'z' && movs.Length > 0)
            {
                //Todo inverso a la primera parte del método
                char prevMov = movs[movs.Length - 1];

                if (prevMov == 'l')
                {
                    tab.jug.col++;
                }

                else if (prevMov == 'L')
                {
                    tab.cas[tab.jug.fil, tab.jug.col - 1].caja = false;
                    tab.cas[tab.jug.fil, tab.jug.col].caja = true;

                    tab.jug.col++;
                }

                else if (prevMov == 'r')
                {
                    tab.jug.col++;
                }

                else if (prevMov == 'R')
                {
                    tab.cas[tab.jug.fil, tab.jug.col + 1].caja = false;
                    tab.cas[tab.jug.fil, tab.jug.col].caja = true;

                    tab.jug.col--;
                }

                else if (prevMov == 'u')
                {
                    tab.jug.fil++;
                }

                else if (prevMov == 'U')
                {
                    tab.cas[tab.jug.fil + 1, tab.jug.col].caja = false;
                    tab.cas[tab.jug.fil, tab.jug.col].caja = true;

                    tab.jug.fil++;
                }

                else if (prevMov == 'd')
                {
                    tab.jug.fil--;
                }

                else if (prevMov == 'D')
                {
                    tab.cas[tab.jug.fil + 1, tab.jug.col].caja = false;
                    tab.cas[tab.jug.fil, tab.jug.col].caja = true;

                    tab.jug.fil--;
                }
                //Se quita el movimiento del que se vino
                movs = movs.Remove(movs.Length - 1);
            }

        }


        static bool Terminado(Tablero tab)
        {
            bool fin = false;  // Booleano para devolver al método

            int i = 0;
            while (!fin && i < tab.cas.GetLength(0))
            {
                int j = 0;
                while (j < tab.cas.GetLength(1))
                {
                    
                    fin = (tab.cas[i, j].tipo == TipoCasilla.Destino && tab.cas[i, j].caja);
                    j++;
                }
                i++;
            }
            return fin;

            /*for (int i = 0; i < tab.cas.GetLength(0); i++)      //
            {                                                   // Busca las casillas de destino y mira a ver si tienen una caja
                for (int j = 0; j < tab.cas.GetLength(1); j++)  //
                {
                    //Verificará todas las casillas de destino
                    if (tab.cas[i, j].tipo == TipoCasilla.Destino && tab.cas[i, j].caja)
                    {
                        fin = true;
                    }
                    else if (tab.cas[i, j].tipo == TipoCasilla.Destino && !tab.cas[i, j].caja)
                    {
                        fin = false;
                        //En cuanto se detecta una casilla destino vacía devuelve falso
                        return fin;
                    }
                    //Si la casilla no es de destino, pues ¯\_(ツ)_/¯
                }
            }

            return fin; //Devuelve el booleano utilizado para comprobar*/
        }



    }
}
