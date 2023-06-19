using System;

namespace ejerc4
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2, num3, num4, numberWhole;
            string numberWholeS;
            bool isItCapicua;


            Console.WriteLine("Hi! Give me four numbers and I'll tell you if it's capicua!");
            Console.Write("Write your four numbers: ");
            numberWholeS = Console.ReadLine();

            numberWhole = int.Parse(numberWholeS);

            num1 = (numberWhole / 1000);
            num2 = ((numberWhole % 1000) / 100);
            num3 = (((numberWhole % 1000) % 100) / 10);
            num4 = (((numberWhole % 1000) % 100) % 10);

            isItCapicua = (num1 == num4) && (num2 == num3);


            Console.WriteLine("The fact that your number is capicua is " + isItCapicua);
        }
    }
}
