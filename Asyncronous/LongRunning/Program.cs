using System;
using System.Threading;
using System.Threading.Tasks;

namespace LongRunning
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                Task.Factory.StartNew(DoLongWork, TaskCreationOptions.LongRunning); // if long running starts at new thread
                //Task.Run(DoLongWork); //Here Thread pool is used
            }

            Console.ReadKey();
        }

        static void DoLongWork()
        {
            Console.WriteLine($"Work Starting on thread: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
        }
    }
}
