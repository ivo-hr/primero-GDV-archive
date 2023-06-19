using System;

namespace Hoja7
{
    class Program
    {
        public static void Main()
        {
    int x = 3, y = 2;
    suma(out x, ref y);
    Console.WriteLine(x);
        }

public static void suma(out int a, ref int b)
        {
    a = 1;
    b += a;
        }
    }
}
