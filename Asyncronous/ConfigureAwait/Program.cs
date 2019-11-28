using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConfigureAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SynchronizationContext.Current); //This is always null in console apps
            Task.Run(Hello);
        }

        static async Task Hello()
        {
            await DoLongWork().ConfigureAwait(false);// this do not work in Console app
        }

        static async Task DoLongWork()
        {
            Console.WriteLine($"Long work starting: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(1000).ConfigureAwait(false);
            Console.WriteLine($"Long work finished:  {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
