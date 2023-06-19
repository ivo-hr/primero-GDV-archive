using System;
using System.IO;

namespace prac2
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
        Personaje[] pers;
        // colores para los personajes
        ConsoleColor[] colors = {ConsoleColor.DarkYellow, ConsoleColor.Red,
        ConsoleColor.Magenta, ConsoleColor.Cyan, ConsoleColor.DarkBlue };
        const int lapCarcelFantasmas = 3000; // retardo para quitar el muro a los fantasmas
        int lapFantasmas; // tiempo restante para quitar el muro
        int numComida;
        // numero de casillas restantes con comida o vitamina
        Random rnd; // generador de aleatorios
                    // flag para mensajes de depuracion en consola
        private bool Debug = true;
    

        //Lee y transforma el archivo, lo traduce y la IA de fantasmikos
        public Tablero(String file)
        {
            //L E C T U R A  D E L  N I V E L 

            //lee el archivo
            StreamReader lvlRaw = new StreamReader(file);
            
            //el archivo en string con separaciones
            string lvlTrans = "";

            while (!lvlRaw.EndOfStream)
            {
                lvlTrans += lvlRaw.ReadLine() + ";";
            }
            
            //Array final del nivel
            string[] lvlArray = lvlTrans.Split(";");

            //Cierre del archivo
            lvlRaw.Close();


            //T R A D U C C I Ó N

            //filas y columnas del nivel
            int fil = lvlArray.GetLength(0);
            int col = lvlArray.GetLength(1);

            //asignación de propiedades
            for (int i = 0; i < fil; i++)
            {
                char[] anaFil = lvlArray[i].ToCharArray();

                for (int j = 0; j < col; j++)
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

                    else
                    {
                        cas[i, j] = Casilla.Libre;

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
                pers[0].pos = Coor.(whereFil, whereCol);
            }
            else
            {
                if (what == '5')
                {
                    pers[1].ini = Coor.(whereFil, whereCol);
                }

                if (what == '6')
                {
                    pers[2].ini = Coor.(whereFil, whereCol);
                }

                if (what == '7')
                {
                    pers[3].ini = Coor.(whereFil, whereCol);
                }

                if (what == '8')
                {
                    pers[4].ini = Coor.(whereFil, whereCol);
                }
            }
        }

        public bool Siguiente(Coor pos, Coor dir, out Coor newPos)
        {
            bool sig = false;

            if (dir == new Coor(0, 1)) //abajo
            {
                newPos = pos + dir;

                if(newPos.fil == cas.GetLength(0))
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
                if(cas[newPos.col, newPos.fil] == Casilla.Comida)
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

            if (c == 'l' && Siguiente(pacmanPos, new Coor (-1, 0), out Coor newPos)) //izq
            {
                pers[0].dir = new Coor (-1, 0);
            }
            else if (c == 'r' && Siguiente(pacmanPos, new Coor(1, 0), out  newPos)) //dcha
            {
                pers[0].dir = new Coor(1, 0);
            }
            else if (c == 'u' && Siguiente(pacmanPos, new Coor(0, -1), out  newPos)) //arriba
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
            if (numComida == 0) return true;
            else return false;
        }
    }
}

