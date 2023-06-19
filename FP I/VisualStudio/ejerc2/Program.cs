using System;

namespace ejerc2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberWhole;
            int[] num = new int[4];
            string numberWholeS;
            bool isIt3 = false;
            int cycleNo = 0;

            Console.WriteLine("Hi! Give me four numbers and I'll tell you if there's two threes in it!");
            Console.Write("Write your four numbers: ");
            numberWholeS = Console.ReadLine();

            numberWhole = int.Parse(numberWholeS);

            num[0] = (numberWhole / 1000);
            num[1] = ((numberWhole % 1000) / 100);
            num[2] = (((numberWhole % 1000) % 100) / 10);
            num[3] = (((numberWhole % 1000) % 100) % 10);

            int numOf3 = 0;
            while (!isIt3 && cycleNo < num.Length)
            {
                if (cycleNo + 1 >= num.Length)
                {
                    if (num[0] == 3)
                    {
                        numOf3++;
                    }
                }
                else if (num[cycleNo] == 3)
                {
                    numOf3++;
                }

                if (numOf3 >= 2)
                {
                    isIt3 = true;
                }

                cycleNo++;
            }

            Console.WriteLine("The fact that your number has two threes in it is " + isIt3);
        }
    }
}
