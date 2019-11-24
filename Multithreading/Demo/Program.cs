using System;
using System.Threading;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            while (true)
            {
                input = Console.ReadLine();
                if (input == "calc")
                {
                    LongCalc();
                    Console.WriteLine(input + " Long Calc");
                }
                Console.WriteLine("Enter sth");
            }
        }

        static void LongCalc()
        {
            Thread.Sleep(5000);
        }
    }
}
