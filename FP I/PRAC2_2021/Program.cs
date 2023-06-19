using System;
using System.Threading;

namespace naves {
    class Program {
        const bool DEBUG = true;
        const int ANCHO=30, ALTO = 15;
        static Random rnd = new Random(11);

        static void Main() {
            int [] suelo = new int[ANCHO], // límites del tunel
                   techo = new int[ANCHO];

            int naveC, naveF,   
                balaC, balaF,  
                enemigoC, enemigoF; 

            // inicializacion
            // renderizado
           
            while (...){
                // AvanzaTunel
                // renderizado
                Thread.Sleep(120);
                } //else                
            } // while
        } // Main




        static void AvanzaTunel(int [] suelo, int [] techo){
            for (int i=0; i<ANCHO-1; i++){ // desplazamiento de eltos a la izda
                techo[i] = techo[i+1];
                suelo[i] = suelo[i+1];
            }

            int s,t; // ultimas posiciones de suelo y techo
            s = suelo[ANCHO-1];
            t = techo[ANCHO-1]; 
            
            // generamos nuevos valores para esas ultimas posiciones
            int opt = rnd.Next(5); // 5 alternativas
            if (opt==0 && s<ALTO-1) {s++; t++;}   // tunel baja           
            else if (opt==1 && t>0) {s--; t--;}   // sube
            else if (opt==2 && s-t>7) {s--; t++;} // estrecha
            else if (opt==3) {                    // ensancha
                if (s<ALTO-1) s++;
                if (t>0) t--;
            } // con 4 se deja igual, no se hace nada

            // asignamos ultimas posiciones en el array
            suelo[ANCHO-1] = s;
            techo[ANCHO-1] = t;
        }   


        static char LeeInput(){
            char ch=' ';
			if (Console.KeyAvailable) {	
				string dir = Console.ReadKey(true).Key.ToString();			
				if (dir == "A" || dir=="LeftArrow") ch = 'l';
				else if (dir == "D" || dir=="RightArrow") ch='r';
				else if (dir == "W" || dir=="UpArrow") ch='u';
				else if (dir == "S" || dir=="DownArrow") ch='d';                    
				else if (dir == "X" || dir=="Spacebar") ch='x'; // bomba                   
                else if (dir == "P") ch = 'p'; // pausa					
				else if (dir == "Q" || dir=="Escape") ch='q'; // salir
                while (Console.KeyAvailable) Console.ReadKey ().Key.ToString ();	
			}
            return ch;
        }
    }
}
