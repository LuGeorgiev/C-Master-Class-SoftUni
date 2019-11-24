using System;
using System.Threading;

namespace RaceConditionsLock
{
    class Program
    {
        static int num = 0;
        static object obj = new object();

        static void Main(string[] args)
        {
            for (int i = 0; i < 8; i++)
            {
                new Thread(Increment).Start();
            }
            Console.WriteLine("Type sth to finish");
            Console.ReadLine();
            Console.WriteLine(num);
        }

        static void Increment()
        {
            for (int i = 0; i < 100000; i++)
            {
                lock (obj)
                { 
                    num ++;                
                }
            }
            Console.WriteLine("Finished");
        }
    }
}
