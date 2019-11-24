using System;
using System.Threading;

namespace Common
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var trace = new System.Diagnostics.StackTrace();
            Console.WriteLine(trace);
            Hey();

            new Thread(Hey).Start();
            new Thread(Hey).Start();
            new Thread(Hey).Start();
            new Thread(Hey).Start();
            new Thread(Hey).Start();
        }

        static void Hey() 
        {
            var trace = new System.Diagnostics.StackTrace();
            Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}\nStacK: " + trace);

            Thread.Sleep(12000);
        }
    }
}
