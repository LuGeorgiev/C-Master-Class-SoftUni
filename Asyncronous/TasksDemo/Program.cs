using System;
using System.Threading;
using System.Threading.Tasks;

namespace TasksDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Task.Run((Action)Hello);
            Task.Factory.StartNew((Action)Hello);
            var task = Task.Run(() =>
            {
                Console.WriteLine(5);
                Console.WriteLine("5 ->" + Thread.CurrentThread.ManagedThreadId);

            });

            Console.Read();
        }

        static void Hello()
        { 
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Hello World!");        
        }
    }
}
