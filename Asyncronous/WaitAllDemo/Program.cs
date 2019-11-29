using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WaitAllDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task<Thread>> tasks = new List<Task<Thread>>();

            for (int i = 0; i < 50; i++)
            {
                tasks.Add(Task.Run(Zdr));
            }

            //int index = Task.WaitAny(tasks.ToArray());
            //Console.WriteLine("First: " + index);
            //Console.WriteLine("Id: " + tasks[index].Result.ManagedThreadId);
            Task.WaitAll();

            Console.ReadLine();
        }

        static async Task<Thread> Zdr()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            var rand = new Random();
            await Task.Delay(rand.Next(1000, 30000));

            return Thread.CurrentThread;
        }
    }
}
