using System;

namespace ejerc3
{
    class Program
    {
        static void Main(string[] args)
        {
            double notaE, notaP1, notaP2, actA, notaF;
            string notaEs, notaP1s, notaP2s, actAs;

            Console.WriteLine("Hola! Vamos a calcular tu nota final de FP con tu nota del examen final, la nota de tus prácticas y de tu actividad adicional!");

            Console.WriteLine("Dime tu nota del examen final: ");
            notaEs = Console.ReadLine();

            Console.WriteLine("Ahora la de tu primera práctica: ");
            notaP1s = Console.ReadLine();

            Console.WriteLine("Ahora la de tu segunda práctica: ");
            notaP2s = Console.ReadLine();

            Console.WriteLine("Finalmente, el de tu actividad adicional: ");
            actAs = Console.ReadLine();

            notaE = double.Parse(notaEs);
            notaP1 = double.Parse(notaP1s);
            notaP2 = double.Parse(notaP2s);
            actA = double.Parse(actAs);

            notaF = (notaE * 0.7) + (notaP1 * 0.1) + (notaP2 * 0.1) + (actA * 0.1);

            Console.WriteLine("Vale, tu nota final es de " + notaF + ".");
        }
    }
}
