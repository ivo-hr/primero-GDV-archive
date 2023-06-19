using System;
using System.Globalization;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

namespace ejerc9
{
    class Program
    {
        static void Main(string[] args)
        {
            char hexInput;
            int decOutput;
            

            Console.WriteLine("Hex to decimal number converter.");

            Console.Write("Hex number: ");
            hexInput = char.Parse(Console.ReadLine());

            if ((hexInput < '0') || (hexInput > 'F') || ((hexInput < 'A') && (hexInput > '9')))
            {
                Console.WriteLine("This hex number cannot be transformed into a decimal number");
            }
            else if ((hexInput <= '9') && (hexInput >= '0'))
            {
                decOutput = hexInput - '0';

                Console.WriteLine("Your hex number " + hexInput + " in decimal numbers is " + decOutput + ".");
            }
            else
            {
                decOutput = (Convert.ToInt32(hexInput) - 55);

                Console.WriteLine("Your hex number " + hexInput + " in decimal numbers is " + decOutput + ".");
            }
        }
    }
}
