using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        { 
            double nota;


            Console.WriteLine("Calculadora de calificación");

            Console.Write("Nota: ");
            nota = double.Parse(Console.ReadLine());

            if (nota < 5)
                Console.WriteLine("Tu calificación es un SS");


            else if ((nota >= 5) && (nota < 7))
            {
                Console.WriteLine("Tu calificación es un AP");
            }

            else if ((nota >= 7) && (nota < 9))
            {
                Console.WriteLine("Tu calificación es un NT");
            }

            else if ((nota >= 9) && (nota < 10))
            {
                Console.WriteLine("Tu calificación es un SB");
            }
            else if (nota == 10)
            {
                Console.WriteLine("Tu calificación es una MH");
            }

            

           

        }
    }
}
