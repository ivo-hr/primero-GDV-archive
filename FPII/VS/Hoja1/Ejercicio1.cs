using System;

namespace Hoja1
{
    class Ejercicio1
    {
        //Tamaño arrays monomios
        const int N = 100;

        static void Main(string[] args)
        {
            leePoli(out Polinomio p);
        }
        struct Monomio
        {
            public double coef;
            public int exp;
        }

        struct Polinomio
        {
            //Array monomios
            public Monomio[] mon;
            //num monomios = 1ª pos libre en array mon
            public int oc;
        }

        static void leeMono(out Monomio m)
        {
            Console.Write("Coef.: ");
            m.coef = double.Parse(Console.ReadLine());

            Console.Write("Exp.: ");
            m.exp = int.Parse(Console.ReadLine());
        }

        static void leePoli(out Polinomio p)
        {
            p.mon = new Monomio[N];

            Console.Write("Nº de  monomios: ");
            p.oc = int.Parse(Console.ReadLine());

            for (int i = 0; i < p.oc; i++)
            {
                leeMono(out p.mon[i]);
            }
            compruebaTodo(p);
            escribeTodo(p);
        }

        static void compruebaTodo(Polinomio p)
        {

            int monDif = 0;
            for (int i = 0; i < p.oc; i++)
            {
                if ((p.mon[i].coef == 0) || (p.mon[i].exp < 0))
                {
                    Console.WriteLine("Perdón, no se permite un coeficiente = 0 ni un exponente < 0");
                    Console.WriteLine("se asignará el coeficiente a 1 y el exponente a 0");
                    p.mon[i].coef = 1;
                    p.mon[i].exp = 0;
                }

                for (int j = i; j < p.oc; j++)
                {
                    if (p.mon[i].exp == p.mon[j].exp)
                    {
                        monDif--;
                    }
                }
                monDif++;
            }

            if (monDif > p.oc)
            {
                Console.WriteLine("Demasiados monomios");
            }
        }

        static void escribeTodo(Polinomio p)
        {
            for (int i = 0; i < p.oc; i++)
            {
                if (p.mon[i].coef != 0)
                {
                    Console.Write(" + " + p.mon[i].coef + "x^" + p.mon[i].exp);
                }
            }
        }

        static void sumaCosas(Polinomio p)
        {
            for (int i = 0; i < p.oc; i++)
            {
                for (int j = i; j < p.oc; j++)
                {
                    if (p.mon[i].exp == p.mon[j].exp)
                    {
                        p.mon[i].coef += p.mon[j].coef;
                        p.mon[j].coef = 0;
                        p.mon[j].exp = 0;
                    }
                }
            }

            static void ordenaCosas(Polinomio p)
            {
                bool cont = true;
                int i = 0;
                while(i < p.oc - 1 && cont)
                {
                   
                }
            }

            void inserta(Monomio m, Polinomio p)
            {

            }
            static void burbujaMejorado(int[] v)
            {
                int n = v.Length;
                bool cont = true; // control de parada
                int i = 0; // ahora el for es un while con "cont" en la condición de parada
                while (i < n - 1 && cont)
                {
                    cont = false; // control de intercambio, inicialmente false
                    for (int j = n - 1; j > i; j--)
                    {
                        if (v[j - 1] > v[j])
                        {
                            //swap(ref v[j - 1], ref v[j]);
                            int k = v[j - 1];
                            v[j - 1] = v[j];
                            v[j] = k;
                            // si hay intercambio cont a true
                            cont = true;
                        }
                        i++;
                    }
                }
            }
        }
    } 
}
