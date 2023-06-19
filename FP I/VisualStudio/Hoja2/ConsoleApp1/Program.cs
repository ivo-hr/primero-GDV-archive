using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double sueldoBase, complDest, complAnt, horasExtra, numHijos, numDep, sueldoBruto, irpfPercent, irpfRet, sueldoNeto;
            string sueldoBaseS, complDestS, complAntS, horasExtraS, numHijosS, numDepS;

                // Aquí he declarado las variables que voy a ir necesitando a lo largo del programa.


            Console.WriteLine("Bienvenido al calculador de nóminas. A continuación se le pedirá los datos necesarios para este cálculo.");
            Console.WriteLine(" ");

            // Ésta es la introducción, mostrando lo que va a realizar este programa.


            Console.Write("Introduzca su sueldo base: ");
            sueldoBaseS = Console.ReadLine();

            Console.Write("Introduzca su complemento de destino: ");
            complDestS = Console.ReadLine();

            Console.Write("Introduzca su complemento de antigüedad: ");
            complAntS = Console.ReadLine();

            Console.Write("Introduzca sus horas extra realizadas: ");
            horasExtraS = Console.ReadLine();

            Console.Write("Introduzca su número de hij@s: ");
            numHijosS = Console.ReadLine();

            Console.Write("Introduzca su número de mayores dependientes: ");
            numDepS = Console.ReadLine();

            // Éste conjunto de lineas declaran la entrada del usuario, que más tarde será utilizada para realizar la función principal.


            sueldoBase = double.Parse(sueldoBaseS);
            complDest = double.Parse(complDestS);
            complAnt = double.Parse(complAntS);
            horasExtra = double.Parse(horasExtraS);
            numHijos = double.Parse(numHijosS);
            numDep = double.Parse(numDepS);

            // Aquí se está transformando la entrada del usuario en "string" a valores "double" para las próximas operaciones.


            sueldoBruto = (sueldoBase + complDest + complAnt + (horasExtra * 23));
            irpfPercent = (24 - ((numHijos * 2) + numDep));
            irpfRet = ((sueldoBruto * irpfPercent) / 100);
            sueldoNeto = (sueldoBruto - irpfRet);

            // Aquí se ha calculado todo lo que el programa ha de devolver al usuario: el sueldo bruto, el neto, el IRPF y la retención del mismo.


            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("-----  R E S U L T A D O S  -----");
            Console.WriteLine(" ");
            Console.WriteLine("Sueldo base: . . . . . . . . . ." + sueldoBase + "$");
            Console.WriteLine("Complemento de destino: . . . . " + complDest + "$");
            Console.WriteLine("Complemento de antigüedad: . . ." + complAnt + "$");
            Console.WriteLine("Horas extra: . . . . . . . . . ." + horasExtra + "horas");
            Console.WriteLine("Número de hij@s: . . . . . . . ." + numHijos + "hij@s");
            Console.WriteLine("Número de mayores dependientes: " + numDep + "mayores dependientes");
            Console.WriteLine(" ");
            Console.WriteLine("Resultado del cálculo de nómina:");
            Console.WriteLine("Sueldo Bruto: . . . . . . . . . " + sueldoBruto + "$");
            Console.WriteLine("Porcentaje de IRPF: . . . . . . " + irpfPercent + "%");
            Console.WriteLine("Retención por IRPF: . . . . . . " + irpfRet + "$");
            Console.WriteLine("Sueldo neto: . . . . . . . . . ." + sueldoNeto + "$");

            //Esto es lo que verá el usuario: todos los datos que ha introducido y el resultado del cálculo de, en este caso, su nómina.

        }
    }
}
