using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Multitreading
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"Started from: {Thread.CurrentThread.ManagedThreadId}");
            //Print();
            //new Thread(Print).Start();

            int times = 4;
            var watch = Stopwatch.StartNew();
            for (int i = 0; i < times; i++)
            {
                Primes.CalculatePrimes();
            }
            watch.Stop();
            Console.WriteLine($"Elapsed milliseconds: {watch.ElapsedMilliseconds}");

            watch.Reset();
            Console.WriteLine("Using threads");
            var threads = new List<Thread>();
            watch.Start();
            for (int i = 0; i < times; i++)
            {
                var thread = new Thread(Primes.CalculatePrimes);
                threads.Add(thread);
                threads[i].Start();
            }
            //this will await all the threads to finish jobs
            threads.ForEach(t => t.Join());

            watch.Stop();
            Console.WriteLine($"Elapsed milliseconds: {watch.ElapsedMilliseconds}");
        }

        public static void Print()
        {
            Console.WriteLine("print");
            Console.WriteLine($"Printed from: {Thread.CurrentThread.ManagedThreadId}");
        }

    }

    class Primes
    {
        public static void CalculatePrimes()
        {
            for (int i = 0; i < 10000; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }
        }
    }
}
