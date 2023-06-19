//Enrique Juan Gamboa

using System;

namespace PRAC1_2021
{
    class MainClass
    {
        const int ANCHO = 9;
        const int TOPE = 40;

        //Aleatorios para el cambio de direccion
        static Random rnd = new Random();

        public static void Main()
        {
        //INICIALIZACIÓN

            //Pos inicial de la pista y coche, tasa de refresco
            int pistaIzq = TOPE / 2,
                posCoche = pistaIzq + ANCHO / 2,
                delta;
            //Delta mínima para la vel. dinámica
            int minDelta = 125;
            //(opcional) ancho variable
            int anchoVar = ANCHO;
            bool anchoBool;
            
            //Colisiones y término de juego voluntario
            bool colIzda = false,
                colDcha = false,
                quit = false;

            //Preparación de la consola
            Console.ResetColor();
            Console.CursorVisible = true;

            //Petición del delta
            Console.Write("Tasa de refresco (recomendado 250): ");
            delta = int.Parse(Console.ReadLine());
            Console.WriteLine();

            //Activación de delta variable
            Console.Write("Aceleración progresiva? (y/n): ");
            string dynDeltResp = Console.ReadLine();
            if (dynDeltResp == "n") minDelta = delta;
            Console.WriteLine();

            //(opcional) petición de ensanche
            Console.Write("Ancho de carretera variable? (y/n): ");
            string anchResp = Console.ReadLine();
            anchoBool = anchResp == "y";


        //1ER RENDERIZADO

            //Borra la consola para el renderizado
            Console.Clear();
            //Se esconde el cursor para no verlo "saltar por la pantalla"
            Console.CursorVisible = false;
            //Colocación del cursor en el punto de origen
            Console.SetCursorPosition(0, 0);

            //Dibujo del espaciado hasta que empiece la carretera
            for (int i = 0; i < pistaIzq - 1; i++) Console.Write(" ");

            //Barrera izq.
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|");

            //Dibujo de la carretera y el coche
            for (int i = pistaIzq; i < anchoVar + pistaIzq; i++)
            {
                //Dibuja la carretera a menos que esté el coche
                if (i != posCoche - 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("·");
                }
                //Dibuja el coche
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("<o>");
                    //Para que se continúe escribiendo (o no) la carretera a su dcha
                    i += 2;
                }
            }
            //Barrera dcha.
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|");

            

        //B U C L E   P P A L
            while (!colIzda && !colDcha && !quit)
            {
            //INPUT DE USUARIO

                string dir;
                // detección de tecla pulsada
                if (Console.KeyAvailable)
                {
                    // lectura de tecla
                    dir = (Console.ReadKey(true)).KeyChar.ToString();

                    //Dirección del coche
                    if (dir == "a")
                    {
                        posCoche--;
                    }

                    else if (dir == "d")
                    {
                        posCoche++;
                    }

                    //Término de juego voluntario
                    else if (dir == "q")
                    {
                        quit = true;
                    }

                }
                // vaciado buffer de entrada: en un frame solo se guarda la primera tecla pulsada
                while (Console.KeyAvailable) Console.ReadKey(true);


            //LOGICA DE JUEGO

                //Determinación de curvas
                int rndDir = rnd.Next(-1, 2);
                //Se le suma el valor aleatorio (-1, 0 o 1)
                if (pistaIzq < TOPE && pistaIzq > 0) pistaIzq += rndDir;

                //(opcional) ancho variable
                if (anchoBool)
                {
                    int rndWide = rnd.Next(-2, 3);
                    //Limita el ancho para que no se expanda/estreche mucho
                    if (anchoVar + rndWide < 18 && anchoVar + rndWide > 7)
                    {
                        //Se le suma el valor aleatorio (-2, -1, 0, 1 o 2)
                        anchoVar += rndWide;
                        //Si se le sumó -2 o 2 varía el ancho por los dos lados (usando pistaIzq)
                        if (rndWide <= -2 || rndWide >= 2) pistaIzq += (-rndWide / 2);
                    }
                }


            //CONTROL DE COLISIONES

                //Colisón izquerda
                if (posCoche <= pistaIzq) colIzda = true;

                //Colisión derecha
                else if (posCoche >= anchoVar + pistaIzq) colDcha = true;


            //RENDERIZADO

                //Se pone el cursor en una nueva línea para dibujar
                Console.WriteLine();

                //Dibujo del espaciado hasta que empiece la carretera
                for (int i = 0; i < pistaIzq - 1; i++) Console.Write(" ");

                //Dibujo de la primera barrera, colisionada o no
                if (colIzda)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else Console.Write("|");

                //Dibujo de la carretera y el coche
                for (int i = pistaIzq; i < anchoVar + pistaIzq; i++)
                {
                    //Dibuja la carretera a menos que esté el coche o la colisión izq.
                    if (i != posCoche - 1 && !(i == posCoche && colIzda))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("·");
                    }
                    //Dibuja el coche
                    else
                    {
                        //Si ha habido colisión izq.
                        if (colIzda)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("o>");
                            //Para que se continúe escribiendo la carretera a su dcha.
                            i += 2;
                        }
                        //Si ha habido colisión dcha.
                        else if (colDcha)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("<o");
                        }
                        //Si no hay colisión
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("<o>");
                            //Para que se continúe escribiendo (o no) la carretera a su dcha
                            i += 2;
                        }

                    }
                }

                //Dibujo de la segunda barrera, colisionada o no
                if (colDcha)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*   ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("|   ");
                }


            //T. DE RETARDO

                System.Threading.Thread.Sleep(delta);


            //VAR. DINÁMICA DE DELTA

                if (delta > minDelta) delta--;

            }


        //GAME OVER

            if (!quit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("");
                Console.WriteLine("CRASH!!!");
            }

            //Para no cerrar el juego sin querer
            System.Threading.Thread.Sleep(1000);
            //Para esconder el último mensaje
            Console.ForegroundColor = ConsoleColor.Black;


        //F I N
        }
    }
}

