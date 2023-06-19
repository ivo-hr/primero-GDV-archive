using System;

namespace ejerc3
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2, num3, num4, numberWhole;
            string numberWholeS;
            bool isIt3;


            Console.WriteLine("Hi! Give me four numbers and I'll tell you if there's two consecutive threes in it!");
            Console.Write("Write your four numbers: ");
            numberWholeS = Console.ReadLine();

            numberWhole = int.Parse(numberWholeS);

            num1 = (numberWhole / 1000);
            num2 = ((numberWhole % 1000) / 100);
            num3 = (((numberWhole % 1000) % 100) / 10);
            num4 = (((numberWhole % 1000) % 100) % 10);

            isIt3 = (num1 == 3) && (num2 == 3) || (num2 == 3) && (num3 == 3) || (num3 == 3) && (num4 == 3);


            Console.WriteLine("The fact that your number has two consecutive threes in it is " + isIt3);
        }
    }
}
