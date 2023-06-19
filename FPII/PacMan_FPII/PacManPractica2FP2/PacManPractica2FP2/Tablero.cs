using System;
using System.IO;

namespace PacMan_Practica_2_FP2
{
   
    class Tablero
    {
        // contenido de las casillas
        enum Casilla { Libre, Muro, Comida, Vitamina, MuroCelda };
        // matriz de casillas (tablero)
        Casilla[,] cas;
        // representacion de los personajes (pacman y fantasmas)
        struct Personaje
        {
            public Coor pos, dir, // posicion y direccion actual
            ini; // posicion inicial (para fantasmas)
        }
        // vector de personajes, 0 es pacman y el resto fantasmas
        Personaje[] pers = new Personaje[5];
        // colores para los personajes
        ConsoleColor[] colors = {ConsoleColor.DarkYellow, ConsoleColor.Red,
        ConsoleColor.Magenta, ConsoleColor.Cyan, ConsoleColor.DarkBlue };
        const int lapCarcelFantasmas = 3000; // retardo para quitar el muro a los fantasmas
        int lapFantasmas = lapCarcelFantasmas; // tiempo restante para quitar el muro
        int numComida;
        // numero de casillas restantes con comida o vitamina
        Random rnd; // generador de aleatorios
                    // flag para mensajes de depuracion en consola
        private bool Debug = true;
        public ListaPares ListaCoor;
        
       
        //Lee y transforma el archivo, lo traduce y la IA de fantasmikos
        public Tablero(String file)
        {
            //L E C T U R A  D E L  N I V E L 

            //lee el archivo
            StreamReader lvlRaw = new StreamReader(file);

            //el archivo en string con separaciones
            string lvlTrans = " ";

            while (!lvlRaw.EndOfStream)
            {
                lvlTrans += lvlRaw.ReadLine() + ";";
            }

            //Array final del nivel
            lvlTrans.Replace(" ", string.Empty);
            string[] lvlArray = lvlTrans.Split(";");

            

            //Cierre del archivo
            lvlRaw.Close();


            //T R A D U C C I Ó N

            //filas y columnas del nivel
            int fil = lvlArray.GetLength(0);
            int col = lvlArray[0].Length;

            cas = new Casilla[fil, col];
            //asignación de propiedades
            for (int i = 0; i < fil; i++)
            {
                char[] anaFil = lvlArray[i].ToCharArray();

                for (int j = 0; j <anaFil.Length; j++)
                {
                    
                    char a = anaFil[j]; 

                    if (a == '1')
                    {
                        cas[i, j] = Casilla.Muro;
                    }

                    else if (a == '2')
                    {
                        cas[i, j] = Casilla.Comida;
                        numComida++;
                    }

                    else if (a == '3')
                    {
                        cas[i, j] = Casilla.Vitamina;
                        numComida++;
                    }

                    else if (a == '4')
                    {
                        cas[i, j] = Casilla.MuroCelda;
                    }

                    else if (a == '5')
                    {
                        cas[i, j] = Casilla.Libre;
                        
                    }
                    else
                    {
                        //Método que determina que personaje es
                        MobAssign(a, i, j);
                    }
                }
            }


        }

        void MobAssign(char what, int whereFil, int whereCol)
        {
            if (what == '9')
            {
                pers[0].pos = new Coor(whereFil, whereCol);
            }
            
            else if (what == '5')
            {
                pers[1].ini = new Coor(whereFil, whereCol);
            }

            else if (what == '6')
            {
                pers[2].ini = new Coor(whereFil, whereCol);
            }

            else if (what == '7')
            {
                pers[3].ini = new Coor(whereFil, whereCol);
            }

            else if (what == '8')
            {
                pers[4].ini = new Coor(whereFil, whereCol);
            }
            
        }

        public void Dibuja()
        {
            for (int i = 0; i < cas.GetLength(0); i++) // filas
            {
                for (int j = 0; j < cas.GetLength(1); j++) // columnas
                {
                 
                        // MURO
                        if (cas[i, j] == Casilla.Muro)
                        {                   
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write("  ");
                            Console.ResetColor();                   
                        }

                        // LIBRE
                        else if (cas[i,j] == Casilla.Libre)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("  ");
                            Console.ResetColor();                        
                        }

                        // PERSONAJE Y FANTASMAS
                        else if(pers[0].pos.fil == i && pers[0].pos.col == j)
                        {
                            if (pers[0].dir == new Coor(0, 1))
                            {
                                Console.BackgroundColor = colors[0];
                                Console.Write("VV");
                                Console.ResetColor();
                            }
                            else if (pers[0].dir == new Coor(0, -1))
                            {
                                Console.BackgroundColor = colors[0];
                                Console.Write("^^");
                                Console.ResetColor();
                            }

                            else if (pers[0].dir == new Coor(1, 0))
                            {
                                Console.BackgroundColor = colors[0];
                                Console.Write(">>");
                                Console.ResetColor();
                            }

                            else if (pers[0].dir == new Coor(-1, 0))
                            {
                                Console.BackgroundColor = colors[0];
                                Console.Write("<<");
                                Console.ResetColor();
                            }
                        }


                        else if (pers[1].ini.fil == i && pers[1].ini.col == j)
                        {
                            Console.BackgroundColor = colors[1];
                            Console.Write("ºº");
                            Console.ResetColor();
                        }
                        else if (pers[2].ini.fil == i && pers[2].ini.col == j)
                        {
                                Console.BackgroundColor = colors[2];
                                Console.Write("ºº");
                                Console.ResetColor();
                        }
                        else if (pers[3].ini.fil == i && pers[3].ini.col == j)
                        {
                                Console.BackgroundColor = colors[3];
                                Console.Write("ºº");
                                Console.ResetColor();
                        }
                        else if (pers[4].ini.fil == i && pers[4].ini.col == j)
                        {
                                Console.BackgroundColor = colors[4];
                                Console.Write("ºº");
                                Console.ResetColor();
                        }


                    // COMIDA
                        if (cas[i, j] == Casilla.Comida)
                        {   
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("··");
                            Console.ResetColor();
                        }
                    // VITAMINA
                        if (cas[i, j] == Casilla.Vitamina)
                        {   
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("**");
                            Console.ResetColor();
                        }

                    //MURO CELDA
                        if (cas[i, j] == Casilla.MuroCelda)
                        { 
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write("  ");
                            Console.ResetColor();
                        }

                    Console.WriteLine();
                }
            }
            Console.WriteLine();

            if (Debug)
            {
                Console.WriteLine("Current food + vitamins: " + numComida);
                Console.WriteLine("");
                Console.WriteLine("PacMan pos + dir: " + pers[0].pos + "; " + pers[0].dir);
                Console.WriteLine("");
                Console.WriteLine("Time until ghosts" + lapFantasmas);
                Console.WriteLine("Ghost 1 pos + dir: " + pers[1].pos + "; " + pers[1].dir);
                Console.WriteLine("Ghost 2 pos + dir: " + pers[2].pos + "; " + pers[2].dir);
                Console.WriteLine("Ghost 3 pos + dir: " + pers[3].pos + "; " + pers[3].dir);
                Console.WriteLine("Ghost 4 pos + dir: " + pers[4].pos + "; " + pers[4].dir);
                Console.WriteLine("");
                Console.WriteLine("Current rnd seed: " + rnd);

            }
        }

        public bool Siguiente(Coor pos, Coor dir, out Coor newPos)
        {
            bool sig = false;

            if (dir == new Coor(0, 1)) //abajo
            {
                newPos = pos + dir;

                if (newPos.fil == cas.GetLength(0))
                {
                    newPos.fil = 0;
                }

                if (cas[newPos.col, newPos.fil] != Casilla.Muro)
                {
                    sig = true;
                }
            }

            else if (dir == new Coor(0, -1)) //arriba
            {
                newPos = pos + dir;

                if (newPos.fil == -1)
                {
                    newPos.fil = cas.GetLength(0);
                }

                if (cas[newPos.col, newPos.fil] != Casilla.Muro)
                {
                    sig = true;
                }
            }

            else if (dir == new Coor(-1, 0)) //izq
            {
                newPos = pos + dir;

                if (newPos.col == -1)
                {
                    newPos.col = cas.GetLength(1);
                }

                if (cas[newPos.col, newPos.fil] != Casilla.Muro)
                {
                    sig = true;
                }
            }

            else //dcha
            {
                newPos = pos + dir;

                if (newPos.col == cas.GetLength(1))
                {
                    newPos.col = 0;
                }

                if (cas[newPos.col, newPos.fil] != Casilla.Muro)
                {
                    sig = true;
                }
            }

            return sig;
        }

        public void MuevePacman()
        {
            Coor newPos;



            if (Siguiente(pers[0].pos, pers[0].dir, out newPos))
            {
                if (cas[newPos.col, newPos.fil] == Casilla.Comida)
                {
                    cas[newPos.col, newPos.fil] = Casilla.Libre;

                    numComida--;
                }

                else if (cas[newPos.col, newPos.fil] == Casilla.Vitamina)
                {
                    cas[newPos.col, newPos.fil] = Casilla.Libre;

                    numComida--;
                }

                pers[0].pos = newPos;
            }
        }

        public bool CambioDirecc(char c)
        {
            bool cambio = true;

            Coor pacmanPos = pers[0].pos;

            if (c == 'l' && Siguiente(pacmanPos, new Coor(-1, 0), out Coor newPos)) //izq
            {
                pers[0].dir = new Coor(-1, 0);
            }
            else if (c == 'r' && Siguiente(pacmanPos, new Coor(1, 0), out newPos)) //dcha
            {
                pers[0].dir = new Coor(1, 0);
            }
            else if (c == 'u' && Siguiente(pacmanPos, new Coor(0, -1), out newPos)) //arriba
            {
                pers[0].dir = new Coor(0, -1);
            }
            else if (c == 'd' && Siguiente(pacmanPos, new Coor(0, 1), out newPos)) //abajo
            {
                pers[0].dir = new Coor(0, 1);
            }
            else
            {
                cambio = false;
            }
            return cambio;
        }

        public bool finNivel()
        {
            bool acabo = false;
            
            if (numComida <= 0)
            {
                acabo = true;
            }
            else
            {
                acabo = false;
            }

            return acabo;
        }

        public bool PacMuerto()
        {
            bool haMuerto = false;

            if (HayFantasma(pers[0].pos))
            {
                haMuerto = true;
            }
            else
            {
                haMuerto = false;
            }

            return haMuerto;
        }
        
        public bool HayFantasma(Coor c)
        {
            bool loHay = false;
            
            for(int i = 0; i< cas.GetLength(0); i++)
            {
                for(int j = 0; j< cas.GetLength(1); j++)
                {

                    if (c == pers[1].pos || c == pers[2].pos || c == pers[3].pos || c == pers[4].pos)
                    {
                        loHay = true;
                    }

                    else
                    {
                        loHay = false;
                    }
                }
            }

            return loHay;
        }

        public int PosiblesDirs(int fant, out ListaPares lst)
        {
            int i = 0;
            lst = new ListaPares();
            Coor newPos = new Coor();

            if (Siguiente(pers[fant].pos, new Coor (0, 1), out newPos) && HayFantasma(newPos))
            {
                i++;
                lst.insertData(new Coor(0, 1));               
            }
            else if (Siguiente(pers[fant].pos, new Coor(0, -1), out newPos) && HayFantasma(newPos))
            {
                i++;
                lst.insertData(new Coor(0, -1));
            }
            else if (Siguiente(pers[fant].pos, new Coor(1, 0), out newPos) && HayFantasma(newPos))
            {
                i++;
                lst.insertData(new Coor(1, 0));
            }
            else if (Siguiente(pers[fant].pos, new Coor(-1, 0), out newPos) && HayFantasma(newPos))
            {
                i++;
                lst.insertData(new Coor(-1, 0));
            }

            return i;
        }

        public void SeleccionaDir(int fant)
        {
            if (!Debug)
            {
                rnd = new Random();
            }
            else
            {
                rnd = new Random(100);
            }
            
            
            ListaPares lst = new ListaPares();
            
            int possible = PosiblesDirs(fant, out lst);

            if (possible == 1)
            {
                pers[fant].dir = lst.coorNEsimo(0);
            }

            if (possible == 0)
            {
                pers[fant].dir = - pers[fant].dir;
            }

            else
            {
                int seed = rnd.Next(0, possible);
                while (-pers[fant].dir == lst.coorNEsimo(seed))
                {
                    seed = rnd.Next(0, possible);
                }
                pers[fant].dir = lst.coorNEsimo(seed);
            }
        }

        public void EliminaMuroFantasmas()
        {
           
               for(int i = 0; i < cas.GetLength(0); i++)
                {
                    for(int j = 0; j < cas.GetLength(1); j++)
                    {
                        if(cas[i,j]== Casilla.MuroCelda)
                        {
                            cas[i, j] = Casilla.Libre;
                        }
                    }
               }
                    
            
        }
        public void MueveFantasmas(int lap)
        {
            for (int i = 1; i < pers.Length; i++)
            {
                SeleccionaDir(i);

                if (Siguiente(pers[i].pos, pers[i].dir, out Coor newPos))
                {
                    pers[i].pos = newPos;
                }
            }

            lapFantasmas -= lap;

            if (lapFantasmas <= 0)
            {
                EliminaMuroFantasmas();
            }
        }
    }
   
}
   