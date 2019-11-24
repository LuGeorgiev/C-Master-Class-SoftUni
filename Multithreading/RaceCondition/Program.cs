using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RaceCondition
{
    class Program
    {
        static int num = 0;

        static void Main(string[] args)
        {
            for (int i = 0; i < 8; i++)
            {
                new Thread(Increment).Start();
            }
            Console.WriteLine("Type sth to finish");
            Console.ReadLine();
            Console.WriteLine(num);

            Console.WriteLine("Second BAD Race condition example");
            var numbers = Enumerable.Range(0, 10000).ToList();
            for (int i = 0; i < 4; i++)
            {
                new Thread(() =>
                {
                    while (numbers.Count > 0)
                    {
                        numbers.RemoveAt(numbers.Count - 1);
                    }
                }).Start();
            }
        }


        static void Increment()
        {
            for (int i = 0; i < 100000; i++)
            {
                num++;
            }
            Console.WriteLine("Finished");
        }
    }
}
