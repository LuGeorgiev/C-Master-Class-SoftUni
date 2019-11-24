using System;
using System.Threading;

namespace SemaphoreDemo
{
    class Program
    {
        static Semaphore semaphore = new Semaphore(3, 3);
        static void Main(string[] args)
        {
            //Semaphore limiths the MAXIMUM pool of thereads that can be used
            //SemaphoreSlin is for single process

            //varialble marked as VOLATILE can be used from a lot of processes and alway last value have to be given
            //VOLATILE guarantees only reading not writing

            while (true)
            {
                Thread.Sleep(100);
                var t = new Thread(Bouncer);
                t.Priority = ThreadPriority.Normal; // Can be uused when resources are limited
                t.Start();
            }
        }

        static void Bouncer()
        {
            semaphore.WaitOne();

            Console.WriteLine($"I'm bouncing on thread: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1500);

            semaphore.Release();
            Console.WriteLine("End buncing");
        }
    }
}
