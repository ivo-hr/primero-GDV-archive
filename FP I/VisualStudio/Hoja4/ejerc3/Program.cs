using System;

namespace ejerc3
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2, num3, num4;
            
            Console.WriteLine("Déme 4 números enteros");

            Console.Write("Nº 1: ");
            num1 = int.Parse(Console.ReadLine());

            Console.Write("Nº 2: ");
            num2 = int.Parse(Console.ReadLine());

            Console.Write("Nº 3: ");
            num3 = int.Parse(Console.ReadLine());

            Console.Write("Nº 4: ");
            num4 = int.Parse(Console.ReadLine());

            if ((num1 >= num2) && (num1 >= num3) && (num1 >= num4))
                Console.WriteLine("El mayor número es Nº1, " + num1);

            else if ((num2 >= num1) && (num2 >= num3) && (num2 >= num4))
                {
                Console.WriteLine("El mayor número es Nº2, " + num2);
            }

            else if ((num3 >= num1) && (num3 >= num2) && (num3 >= num4))
                {
                Console.WriteLine("El mayor número es Nº3, " + num3);
            }

            else if ((num4 >= num1) && (num4 >= num3) && (num4 >= num2))
                {
                Console.WriteLine("El mayor número es Nº4, " + num4);
            }

        }
    }
}
