using System;
using System.Threading;

namespace ThrPool
{
    class Program
    {
        static void Main(string[] args)
        {
            //int max, num;

            //ThreadPool.GetAvailableThreads(out max, out num);
            //Console.WriteLine($"Available threads: {max}");
            //ThreadPool.GetMinThreads(out max, out num);
            //Console.WriteLine($"Min to be available always threads: {max}");

            //Change form Background to Foreground
            //var t = new Thread(Print);
            //t.IsBackground = true;
            //t.Start();

            ThreadPool.QueueUserWorkItem((object obj) =>
            {
                Print();
            });
        }


        public static void Print()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
