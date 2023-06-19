using System;

namespace ejerc8
{
    class Program
    {
        static void Main(string[] args)
        {
            int numb1, numb2, numb3;
            double numb1sq, numb2sq, numb3sq;
            string numb1s, numb2s, numb3s;
            bool isTriangle, isEquil, isIsos, isEsc, isRect;

            Console.WriteLine("Dame tres números y veamos si forman diferentes triángulos.");

            Console.Write("Primer número: ");
            numb1s = Console.ReadLine();
            numb1 = int.Parse(numb1s);

            Console.Write("Segundo número: ");
            numb2s = Console.ReadLine();
            numb2 = int.Parse(numb2s);

            Console.Write("Tercer número: ");
            numb3s = Console.ReadLine();
            numb3 = int.Parse(numb3s);

            numb1sq = Math.Pow(numb1, 2);
            numb2sq = Math.Pow(numb2, 2);
            numb3sq = Math.Pow(numb3, 2);

            isTriangle = (numb1 + numb2 > numb3) && (numb2 + numb3 > numb1) && (numb3 + numb1 > numb2);
            isEquil = (isTriangle == true) && (numb1 == numb2) && (numb2 == numb3);
            isIsos = (isTriangle == true) && (((numb1 == numb2) || (numb1 == numb3) || (numb2 == numb3)) && ((numb2 != numb3) || (numb1 != numb2) || (numb1 != numb3)));
            isEsc = (isTriangle == true) && ((numb1 != numb2) && (numb1 != numb3) && (numb2 != numb3));
            isRect = (isTriangle == true) && ((numb1sq + numb2sq == numb3sq) || (numb1sq + numb3sq == numb2sq) || (numb2sq + numb3sq == numb1sq));

            Console.WriteLine(" - - - - - R E S U L T A D O S - - - - - ");
            Console.WriteLine(" ");
            Console.WriteLine("Pueden formar un triángulo: . . . . . " + isTriangle);
            Console.WriteLine(" ");
            Console.WriteLine("Es equilátero: . . . . . . . . . . . ." + isEquil);
            Console.WriteLine("Es isósceles: . . . . . . . . . . . . " + isIsos);
            Console.WriteLine("Es escaleno: . . . . . . . . . . . . ." + isEsc);
            Console.WriteLine("Es rectángulo: . . . . . . . . . . . ." + isRect);

        }
    }
}
