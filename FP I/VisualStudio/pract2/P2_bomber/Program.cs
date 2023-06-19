//Alejandro Martínez Fernández
//Enrique Juan Gamboa

using System;

namespace P2_bomber
{
    class Program
    {
        //Generador de Nºs aleatorios(I)
        static Random rnd = new Random();
        //Límites del juego (movimiento, bombas y combustible)
        const int ANCHO = 30, ALTO = 18, MAX_BOMBAS = 10, COMBUSTIBLE = 15;
        //Tiempo entre instancias
        const int RETARDO = 50;
        //True para activar modo debug
        const bool DEBUG = false;
        //Generador de Nºs aleatorios(II)
        public static Random Rnd { get => rnd; set => rnd = value; }

        static void Main(string[] args)
        {
            //Indica fin de la partida
            bool finPartida = false;
            //Arrays para altura de edificios y Nº de bombas por columna
            int[] edificios = new int[ANCHO], bombas = new int[ANCHO];
            //Variables para los métodos
            int avionX, avionY, combustible, puntos = 0;


            Inicializa(edificios, bombas, out avionX, out avionY, out combustible, puntos);

            Renderiza(edificios, bombas, avionX, avionY, combustible, puntos);


            // B U C L E  P R I N C I P A L
            while (!finPartida)
            {
                char c = LeeInput();

                MueveAvion(ref avionX, ref avionY, ref combustible, c);

                //Lanzamiento de bombas
                if (c == 'b')
                {
                    LanzamientoBomba(bombas, avionX, avionY);
                }

                MueveBombas(bombas);

                ColisionBombas(edificios, bombas, ref puntos);
                //Detección fin de partida
                if(ColisionAvion(c, edificios, avionX, avionY) || FinPartida(edificios))
                {
                    finPartida = true;
                }

                Renderiza(edificios, bombas, avionX, avionY, combustible, puntos);

                System.Threading.Thread.Sleep(RETARDO);
            }


        //F I N  D E  P A R T I D A
            Console.Clear();
            Console.SetCursorPosition(ANCHO, ALTO / 2);

            //Texto final si se ha ganado
            if (FinPartida(edificios))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("HAS GANADO!");
            }

            //Texto final si se ha perdido
            else
            {
                Console.SetCursorPosition(ANCHO, ALTO / 2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("HAS PERDIDO...");
            }

            //Puntuación final de la partida
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(ANCHO, ALTO / 2 + 3);
            Console.WriteLine("          Puntuación: {0}", puntos);
            Console.SetCursorPosition(ANCHO, ALTO / 2 + 4);
            Console.WriteLine("Combustible restante: {0}", combustible);
            Console.SetCursorPosition(ANCHO, ALTO / 2 + 6);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("PUNTUACIÓN TOTAL:  {0}", combustible * 10 + puntos);

            //Para esconder el texto de final de programa
            Console.SetCursorPosition(ANCHO * 2, ALTO);
            Console.ForegroundColor = ConsoleColor.Black;
        }


    //M É T O D O S

        //Detección del input del jugador
        static char LeeInput()
        {
            char d = ' ';
            if (Console.KeyAvailable)
            {
                string tecla = Console.ReadKey(true).Key.ToString();
                tecla = tecla.ToUpper(); // conversion a mayúsculas
                switch (tecla)
                {
                    case "A": d = 'a'; break;
                    case "S": d = 's'; break;
                    case "W": d = 'w'; break;
                    case "D": d = 'd'; break;
                    case "B": d = 'b'; break;
                    case "P": d = 'p'; break;
                    case "Q": d = 'q'; break;
                }
            }
            while (Console.KeyAvailable) Console.ReadKey().Key.ToString();
            return d;

        }

        //Inicialización del juego (valores, posiciones y alturas)
        static void Inicializa(int[] edificios,int[] bombas, out int avionX, out int avionY, out int combustible, int puntos)
        {
            //Pos inicial del jugador
            avionX = ANCHO - 1;
            avionY = ALTO;

            //Generador de alturas de los edificios
            if (!DEBUG)
            {
                for (int i = 0; i < ANCHO; i++)
                {
                    edificios[i] = rnd.Next(1, ALTO - 3);
                }
            }

            //Alturas de los edificios si en modo debug
            else
            {
                for (int i = 0; i < ANCHO; i++)
                {
                    //Hace que lso edificios no se pasen de altura
                    if (i >= ALTO - 3)
                    {
                        edificios[i] = 3;
                    }

                    else
                    {
                        edificios[i] = i;
                    }
                }
            }

            //Valores iniciales de puntos y combustible
            puntos = 0;
            combustible = COMBUSTIBLE;

            //Asignador del valor inicial a todo el array bombas
            for (int i = 0; i < bombas.Length; i++)
            {
                bombas[i] = -1;
            }
        }

        //Renderizado del espacio de juego
        static void Renderiza(int[] edificios, int[] bombas, int avionX, int avionY, int combustible, int puntos)
        {
            //Borra la consola para el siguiente "frame"
            Console.Clear();

            //Asigna colores al array
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            colors[0] = ConsoleColor.Gray;
            colors[1] = ConsoleColor.DarkGreen;
            colors[2] = ConsoleColor.DarkCyan;
            colors[3] = ConsoleColor.DarkMagenta;
            colors[4] = ConsoleColor.Green;
            colors[5] = ConsoleColor.Cyan;
            colors[6] = ConsoleColor.DarkBlue;
            colors[7] = ConsoleColor.Magenta;
            colors[8] = ConsoleColor.Yellow;
            colors[9] = ConsoleColor.White;

            //Asigna los colores anteriores a cada edificio y lo renderiza
            for(int i = 0; i < edificios.Length; i++)
            {
                for (int j = 0; j <= edificios[i]; j++)
                {
                    Console.BackgroundColor = colors[(i + 1) % 10];
                    Console.SetCursorPosition(2 * i, ALTO - j);
                    Console.Write("  ");
                }
            }

            //Renderizado del avión
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(2 * avionX, ALTO - avionY);
            Console.Write("<-");

            //Renderizado de las boombas (si están activas)
            for (int k = 0; k < bombas.Length; k++)
            {
                if (bombas[k] > 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.SetCursorPosition(2 * k, ALTO - bombas[k]);
                    Console.Write("**");
                } 
            }

            //Renderizado del valor del combustible
            Console.ResetColor();
            Console.SetCursorPosition(0, ALTO + 4);
            Console.Write("C O M B U S T I B L E =\t" + combustible);
            //Asigna un color a diferentes porcentajes de combustible
            if (combustible < COMBUSTIBLE / 3)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else if (combustible < 2 * COMBUSTIBLE / 3)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
            }
            //Renderizado de la barra de combustible
            for (int l = 0; l < combustible; l++)
            {
                Console.Write(" ");
            }

            //Renderizado de los puntos obtenidos
            Console.ResetColor();
            Console.SetCursorPosition(0, ALTO + 2);
            Console.Write("P U N T O S =\t" + puntos);

            //Renderizado de información relevante en modo debug
            if (DEBUG)
            {
                Console.SetCursorPosition(0, ALTO + 6);
                Console.WriteLine("DEBUG ON");
                Console.WriteLine("<- coords: {0} , {1}" , avionX, avionY);
                Console.WriteLine("Refreshrate: {0}ms", RETARDO);
                Console.WriteLine("Layers removed: {0}", puntos);
            }
        }

        //Movimiento del jugador
        static void MueveAvion(ref int avionX, ref int avionY, ref int combustible, char c)
        {
            //Movimiento normal del avión
            if (avionX <= 0)
            {
                avionY -= 1;
                avionX = ANCHO - 1;
            }

            else
            {
                avionX -= 1;
            }

            //Movimientos con input del jugador y consumo de combustible
            if (combustible > 0)
            {
                if (c == 'a' && avionX > 0)
                {
                    avionX --;
                    combustible --;
                }
                else if (c == 'd')
                {
                    avionX ++;
                    combustible --;
                }
                else if (c == 'w' && avionY < ALTO)
                {
                    avionY ++;
                    
                    combustible --;
                }
                else if (c == 's' && avionY > 0)
                {
                    avionY --;
                    
                    combustible --;
                }
            }
        }

        //Colisión jugador - edificio
        static bool ColisionAvion(char c, int[] edificios, int avionX, int avionY)
        {
            //Booleano para ver si se ha chocado
            bool crashed = false;
            //Para las condiciones de impacto y parar el while
            int i = 0;

            //Repite el if hasta que pasa por todos los edificios o el avión se choca
            while (i < edificios.Length && !crashed)
            {
                //Comprobador del impacto
                if (((c == 'a' && (avionX == i || avionX == i - 1)) || avionX == i) && avionY <= edificios[i])
                {
                    crashed = true;
                }
                i++;
            }

            return crashed;
        }

        //Lanzador de bombas
        static void LanzamientoBomba(int[] bombas, int avionX, int avionY)
        {
            //Lanza una bomba syss no se ha llegado al máximo de bombas y no hay na en la columna
            if (CuentaBombas(bombas) < MAX_BOMBAS && bombas[avionX] == -1)
            {
                bombas[avionX] = avionY;
            }
        }

        //Contador de bombas
        static int CuentaBombas(int[] bombas)
        {
            //Número de bombas
            int i = 0;

            //Comprueba si hay una bomba en cada columna (y la suma si hay)
            for (int j = 0; j < bombas.Length; j++)
            {
                if (bombas[j] != -1)
                {
                    i++;
                }
            }

            return i;
        }

        //Movimiento de las bombas
        static void MueveBombas(int[] bombas)
        {
            //Mueve la bomba hacia abajo hasta el suelo
            for (int i = 0; i < bombas.Length; i++)
            {
                if (bombas[i] >= 0)
                {
                    bombas[i]--;
                }
            }
        }

        //Colisión bomba - edificio
        static void ColisionBombas(int[] edificios, int[] bombas, ref int puntos)
        {
            //Comprueba si ha habido colisión en cada columna (si la hay borra la bomba)
            for (int i = 0; i < edificios.Length; i++)
            {
                if (edificios[i] == bombas[i] && edificios[i] > 0)
                {
                    //Llama a la destruccón del edificio
                    Impacto(edificios, i, ref puntos);

                    bombas[i] = -1;
                }
            }
        }

        //Colisión edificio(s) - bomba
        static void Impacto(int[] edificios, int i, ref int puntos)
        {
            //Suma puntos y baja el nivel del edificio
            puntos++;
            edificios[i]--;

            //Comprueba si hay edificios de su misma altura al lado (si los hay vuelve a llamar al método)

            //Une el último edificio con el primero
            if (i + 1 > 30)
            {
                i = 0;
            }

            if (i + 1 >= 0 && edificios[(i + 1) % ANCHO] - 1 == edificios[i])   //"% ANCHO" impide salirse del array
            {
                Impacto(edificios, i + 1, ref puntos);
            }

            if (i - 1 >= 0 && edificios[i - 1] - 1 == edificios[i])
            {
                Impacto(edificios, i - 1, ref puntos);
            }
        }

        //Detección de victoria o derrota
        static bool FinPartida(int[] edificios)
        {
            //Booleano para ver si se ha acabado el juego
            bool endGame = true;
            //Para las condiciones de ganar y parar el while
            int i = 0;

            //Recorre todos los edificios para comprobar si están todos destruidos
            while (i < edificios.Length && endGame)
            {
                if (edificios[i] > 0)
                {
                    endGame = false;
                }
                i++;
            }

            return endGame;
        }
    }
}
