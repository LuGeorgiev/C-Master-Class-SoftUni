using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace ThreadsWithParams
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = 8;
            var primes = new Primes();
            Stopwatch watch = Stopwatch.StartNew();

            for (int i = 0; i < times; i++)
            {
                primes.CalculatePrimes(i * 1000, (i * 1000) + 1000);
            }

            watch.Stop();
            Console.WriteLine(primes.primes.Count);
            Console.WriteLine($"Elapsed milliseconds sequential: {watch.ElapsedMilliseconds}");
            watch.Reset();

            Console.WriteLine("Using threads");
            var threads = new List<Thread>();
            primes = new Primes();
            watch.Start();
            for (int i = 0; i < times; i++)
            {
                int j = i;
                threads.Add(new Thread(() =>
                {
                    primes.CalculatePrimes(j * 1000, (j * 1000) + 1000);
                }));
                threads[i].Start();
            }
            //this will await all the threads to finish jobs
            threads.ForEach(t => t.Join());
            watch.Stop();
            Console.WriteLine(primes.primes.Count);
            Console.WriteLine($"Elapsed milliseconds multithreading: {watch.ElapsedMilliseconds}");

            Console.WriteLine("Using threads with Object param input");
            threads = new List<Thread>();
            primes = new Primes();
            watch.Start();
            for (int i = 0; i < times; i++)
            {
                int j = i;
                var t = new Thread(primes.CalculatePrimes);
                threads.Add(t);
                t.Start(new Tuple<int, int>(j*1000, (j * 1000) + 1000));
            }
            //this will await all the threads to finish jobs
            threads.ForEach(t => t.Join());
            watch.Stop();
            Console.WriteLine(primes.primes.Count);
            Console.WriteLine($"Elapsed milliseconds multithreading: {watch.ElapsedMilliseconds}");
        }
    }

    public class Primes
    {
        public List<int> primes = new List<int>();

        public void CalculatePrimes(int start, int end)
        {
            for (int i = start; i < end; i++)
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

                if (!isPrime)
                {
                    primes.Add(i);
                }
            }
        }

        public void CalculatePrimes(object data)
        {
            int start, end;
            var input = (Tuple<int, int>)data;
            start = input.Item1;
            end = input.Item2;

            for (int i = start; i < end; i++)
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

                if (!isPrime)
                {
                    primes.Add(i);
                }
            }
        }
    }
}
