using System;

namespace ejerc5
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2, num3, num4, numberWhole, decimalNumber;
            string numberWholeS;

            
            Console.WriteLine("Hi! Give me a 4-bit binary number and I'll make it a decimal number!");
            Console.Write("Write your 4-bit number: ");
            numberWholeS = Console.ReadLine();

            numberWhole = int.Parse(numberWholeS);

            num1 = (numberWhole / 1000);
            num2 = ((numberWhole % 1000) / 100);
            num3 = (((numberWhole % 1000) % 100) / 10);
            num4 = (((numberWhole % 1000) % 100) % 10);

            decimalNumber = (num1 * 8) + (num2 * 4) + (num3 * 2) + (num1 * 1);

            Console.WriteLine("Your decimal number is: " + decimalNumber );
        }
    }
}
