using System;
using System.Runtime.ExceptionServices;

namespace ejerc2
{
    class Program
    {
        static void Main(string[] args)
        {
            int edad1, edad2, edad3;
            string edad1st, edad2st, edad3st;
            double mediaEdad;

            Console.WriteLine("Hi! Let's calculate the average age between three students!");

            Console.WriteLine("Firstly, tell me the age of the first student: ");
            edad1st = Console.ReadLine();

            Console.WriteLine("Now the second student's age: ");
            edad2st = Console.ReadLine();

            Console.WriteLine("Lastly, the third student's age: ");
            edad3st = Console.ReadLine();

            edad1 = int.Parse(edad1st);
            edad2 = int.Parse(edad2st);
            edad3 = int.Parse(edad3st);

            mediaEdad = (edad1 + edad2 + edad3) / (3);
            Console.WriteLine("Okay, the average age between these three students is " + mediaEdad + "!");




        }
    }
}
