using System;

namespace ejerc3
{
    class Program
    {
        static void Main(string[] args)
        {
            double notaE, notaP1, notaP2, actA, notaF;
            string notaEs, notaP1s, notaP2s, actAs;

            Console.WriteLine("Hola! Vamos a calcular tu nota final de FP con tu nota del examen final, la nota de tus prácticas y de tu actividad adicional.");

            Console.Write("Dime tu nota del examen final: ");
            notaEs = Console.ReadLine();

            Console.Write("Ahora la de tu primera práctica: ");
            notaP1s = Console.ReadLine();

            Console.Write("Ahora la de tu segunda práctica: ");
            notaP2s = Console.ReadLine();

            Console.Write("Finalmente, el de tu actividad adicional: ");
            actAs = Console.ReadLine();

            notaE = double.Parse(notaEs);
            notaP1 = double.Parse(notaP1s);
            notaP2 = double.Parse(notaP2s);
            actA = double.Parse(actAs);

            if ((notaE >= 4) && (notaP1 >= 5) && (notaP2 >= 5))
            {
                notaF = Math.Round((notaE * 0.7) + (notaP1 * 0.1) + (notaP2 * 0.1) + (actA * 0.1), 3);
                Console.WriteLine("Tu nota final es un " + notaF + ".");

            }
                
            else 
                Console.WriteLine("Lo siento, pero no pasas las restricciones para el cálculo de nota");


            
        }
    }
}
