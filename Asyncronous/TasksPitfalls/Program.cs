using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TasksPitfalls
{
    class Program
    {
        static void Main(string[] args)
        {
            var delta = GC.GetTotalMemory(false);
            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i < 10000000; i++)
            {
                //GetNiki();
                GetNikiAsync();
                //new Thread(GetNiki).Start();
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            delta = GC.GetTotalMemory(false) - delta;
            Console.WriteLine(delta);
        }

        static async Task GetNikiAsync()
        {

        }
        static void GetNiki()
        {

        }
    }
}
