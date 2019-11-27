using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            DoWorkAsync().Wait();

            Task task = DoWorkAsync();
            task.ContinueWith((x) =>
            {
                Console.WriteLine("Over");
            });
                        
            Console.ReadLine();
        }

        static async Task DoWorkAsync()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            await Task.Run((Action)DoWork);

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Hello");
        }

        static void DoWork()
        {
            Thread.Sleep(3000);
            Console.WriteLine("DoWork: " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
