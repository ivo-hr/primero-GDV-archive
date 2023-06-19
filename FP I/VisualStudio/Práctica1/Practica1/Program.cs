//Enrique Juan Gamboa
//Alejandro Martínez Fernández

using System;

namespace Practica1
{
    class MainClass
    {
        // declaración de constantes DELTA, ANCHO, ALTO
        const int DELTA = 10, ANCHO = 40, ALTO = 20;



        public static void Main(string[] args)
        {
            //Generador de aleatorios
            Random rnd = new Random();
            // declaración de constantes y variables para el estado del juego
                //Variables para el jugador
            int jugX, jugY,
                //Variables para el enemigo
                eneX = ANCHO / 2, eneY = ALTO / 4,
                //Variables para la bala
                balaX = 0, balaY = 0, jugXold = 0,
                //Variables para la bomba
                bombaX = 0, bombaY = 0, eneXold = 0, tiempoSinBomba = 0;
                
                //(jugXold y eneXold sirve para mantener la bala y bomba en la posición original de disparo)

            
            
                //Activación de la bala
            bool bala = false,
                //Activación de la bomba
                bomba = false,
                //Registro de enemigo tocado
                eneTocado = false,
                //Registro de jugador tocado
                jugTocado = false,
                //Finalizador del bucle principal
                finDeBcle = false;

            //Colocación del jugador al iniciar la partida
            jugX = ANCHO / 2;
            jugY = ALTO - 2;

            //BUCLE PRINCIPAL (depende de la booleana "FinDeBcle")
            while (finDeBcle == false)
            {
                // INPUT DEL USUARIO
                if (Console.KeyAvailable)
                {
                    string input = (Console.ReadKey(true)).KeyChar.ToString();

                    if (input == "a")
                    {
                        jugX -= 1;
                        Console.Beep(500, 50);
                    }
                    else if (input == "d")
                    {
                        jugX += 1;
                        Console.Beep(500, 50);
                    }
                    else if (input == "w")
                    {
                        jugY -= 1;
                        Console.Beep(500, 50);
                    }
                    else if (input == "s")
                    {
                        jugY += 1;
                        Console.Beep(500, 50);
                    }
                    else if (input == "1")
                    {
                        bala = true;
                        Console.Beep(1000, 50);
                    }
                }


                //Lógica del juego: movimiento del enemigo, bomba y bala


                //COLISIONES (Las colisiones entre objetos se calculan antes de sus movimientos para evitar posibles fallos)

                    //Colisión Jugador-Bomba
                if (((jugX == bombaX) && (jugY == bombaY)))
                {
                    //Muerte del jugador
                    jugTocado = true;
                    //Fin del bucle principal
                    finDeBcle = true;

                }
                    //Colisión Jugador-Enemigo
                if (((jugX == eneX - 1) || (jugX == eneX) || (jugX == eneX + 1)) && (jugY == eneY))
                {

                    jugTocado = true;
                    //Muerte del enemigo
                    eneTocado = true;
                    finDeBcle = true;
                }
                    //Colisión Enemigo-Bala
                if (((balaX == eneX - 1) || (balaX == eneX) || (balaX == eneX + 1)) && (((balaY + 1) == eneY) || (balaY == eneY)))
                {
                    eneTocado = true;
                    finDeBcle = true;
                }
                    //Colisión Bomba-Bala (se anulan entre sí)
                if ((balaX == bombaX) && (((balaY + 1) == bombaY) || (balaY == bombaY)))
                {
                    bomba = false;
                    bala = false;
                }

                
                //MOVIMIENTO DEL ENEMIGO

                    //Coge un Nº aleatorio del generador de aleatorios
                int rndM = rnd.Next(0, 9);
                    // si da 0, no hace nada conque no es necesario ningún código
                    //Cada número aleatorio mueve al enemigo de una forma u otra, haciendo el movimiento aleatorio
                if (rndM == 1)
                {
                    eneX += 1;
                    Console.Beep(250, 50);
                }
                else if (rndM == 2)
                {
                    eneX -= 1;
                    Console.Beep(250, 50);
                }
                else if (rndM == 3)
                {
                    eneY += 1;
                    Console.Beep(250, 50);
                }
                else if (rndM == 4)
                {
                    eneY -= 1;
                    Console.Beep(250, 50);
                }
                else if (rndM == 5)
                {
                    eneY += 1;
                    eneX -= 1;
                    Console.Beep(250, 50);
                }
                else if (rndM == 6)
                {
                    eneY += 1;
                    eneX +=1;
                    Console.Beep(250, 50);
                }
                else if (rndM == 7)
                {
                    eneY -= 1;
                    eneX -= 1;
                    Console.Beep(250, 50);
                }
                else if (rndM == 8)
                {
                    eneY -= 1;
                    eneX += 1;
                    Console.Beep(250, 50);
                }


                //ACTIVACIÓN Y MOVIMIENTO DE LA BOMBA
                    //aCTIVA una bomba si no hay ninguna presente y ha pasado un número de "tics" (en tiempo, número * DELTA)
                if ((tiempoSinBomba < 7) && (bomba == false))
                {
                    tiempoSinBomba += 1;
                }
                else if ((tiempoSinBomba >= 7) && (bomba == false))
                {
                    bomba = true;
                    tiempoSinBomba = 0;
                }
                    //Movimiento y lógica de la bomba
                if (bomba == false)
                {
                    bombaX = ANCHO;
                    bombaY = eneY;
                    eneXold = eneX;
                }
                else if (bomba == true)
                {
                    Console.Beep(150, 50);
                    bombaX = eneXold;

                    if (bombaY < ALTO)
                    {
                        bombaY += 1;
                    }
                    else if (bombaY == ALTO)
                    {
                        bomba = false;
                    }      
                }


                //MOVIMIENTO DE LA BALA

                if (bala == false)
                {
                    balaX = ANCHO;
                    balaY = jugY;
                    jugXold = jugX;
                }
                else if (bala == true)
                {
                    Console.Beep(1500, 50);
                    balaX = jugXold;

                    if (balaY > 0)
                    {
                        balaY -= 1;
                    }
                    else if (balaY == 0)
                    {
                        bala = false;
                    }
                    
                }
                


                // Control de colisiones
                //(debido a los fallos produciados si se colocan las colisionesde los objetos entre sí después de sus movimientos, se han desplazado a "logica del enemigo, bomba y bala")

                    //Collisiones del Jugador con los límites del juego
                if (jugX == ANCHO)
                {
                    jugX = ANCHO - 1;
                    Console.Beep(75, 50);
                }
                else if (jugX == 0)
                {
                    jugX = 1;
                    Console.Beep(75, 50);
                }

                if (jugY == ALTO)
                {
                    jugY = ALTO - 1;
                    Console.Beep(75, 50);
                }
                else if (jugY == 0)
                {
                    jugY = 1;
                    Console.Beep(75, 50);
                }

                    //Collisiones del Enemigo con los límites del juego
                if (eneX + 1 == ANCHO)
                {
                    eneX = ANCHO - 2;
                }
                else if (eneX - 1 == 0)
                {
                    eneX = 2;
                }

                if (eneY == (ALTO / 2))
                {
                    eneY = (ALTO / 2) - 1;
                }
                else if (eneY == 0)
                {
                    eneY = 1;
                }


                // dibujo del borde, enemigo, bomba, jugador, bala
                // Renderizado gráfico

                    //Limpia la pantalla para el siguiente "frame"
                Console.Clear();

                    //Coloca el cursor para dibujar (en este caso el jugador)
                Console.SetCursorPosition(jugX, jugY);
                    //Cambia de color el texto que se va a escribir
                Console.ForegroundColor = ConsoleColor.Cyan;
                    //El texto que se va a escribir
                Console.Write("0");

                Console.SetCursorPosition(eneX - 1, eneY);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("~~~");

                //Sólo dibuja si (en este caso, la bomba) está activa, así escondiéndola de la pantalla si no lo está
                if (bomba == true)
                {
                    Console.SetCursorPosition(bombaX, bombaY);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("X");
                    Console.SetCursorPosition(bombaX, bombaY - 1);
                    Console.Write(" ");
                }

                if (bala == true)
                {
                    Console.SetCursorPosition(balaX, balaY);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("^");
                    Console.SetCursorPosition(balaX, balaY + 1);
                    Console.Write(" ");
                }
                
                    //Estas variables permiten contar cuánto queda por dibujar sin modificar ANCHO ni ALTO
                int posHastaAlto = 0;
                int posHastaAncho = 0;
                    //Dibuja la barrera lateral hasta que posHastaAlto sea igual a ALTO
                while (posHastaAlto < ALTO)
                {
                    Console.SetCursorPosition(ANCHO, posHastaAlto);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("|");
                    posHastaAlto += 1;

                }
                    //Dibuja la barrera lateral hasta que posHastaAncho sea igual a ANCHO
                while (posHastaAncho < ANCHO)
                {
                    Console.SetCursorPosition(posHastaAncho, ALTO);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("-");
                    posHastaAncho += 1;
                }

                // retardo
                System.Threading.Thread.Sleep(DELTA);
            } // fin del bucle

            // Información del ganador, despedida...
                //Primero analiza si ambas entidades han sido heridas, exponiendo un mensaje concreto si es cierto
            if ((jugTocado == true) && (eneTocado == true))
            {
                Console.Clear();
                Console.SetCursorPosition(ANCHO / 2, ALTO / 2);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("BANZAI!!");
                Console.SetCursorPosition(ANCHO / 2, (ALTO / 2) + 2);                       
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("bueno... esa es otra manera de 'ganar'...");
            }
                //Mensaje de victoria
            else if (eneTocado == true)
            {
                Console.Clear();
                Console.SetCursorPosition(ANCHO / 2, ALTO / 2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("HAS GANADO!");
                Console.SetCursorPosition(ANCHO / 2, (ALTO / 2) + 2);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("bien jugado!");
                

            }
                //Mensaje de derrota
            else if (jugTocado == true)
            {
                Console.Clear();
                Console.SetCursorPosition(ANCHO / 2, ALTO / 2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("HAS PERDIDO...");
                Console.SetCursorPosition(ANCHO / 2, (ALTO / 2) + 2);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("qué rica la bomba, no?");

                Console.Beep(831, 500);
                Console.Beep(415, 500);
                Console.Beep(831, 500);
                Console.Beep(880, 1000);
                Console.Beep(831, 500);
                Console.Beep(415, 500);
                Console.Beep(831, 500);
                Console.Beep(784, 1000);


            }
            //Estas últimas líneas esconden el texto que aparece al acabar de ejecutarse el código
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(ANCHO, ALTO);
        }
    }
}


