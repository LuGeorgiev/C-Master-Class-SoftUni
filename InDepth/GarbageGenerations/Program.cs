using System;

namespace GarbageGenerations
{
    class Program
    {
        static void Main(string[] args)
        {
            var prg = new Program();
            Console.WriteLine(GC.GetGeneration(prg));
            GC.Collect();
            Console.WriteLine(GC.GetGeneration(prg));
            GC.Collect();
            Console.WriteLine(GC.GetGeneration(prg));

            var test = new byte[10];
            Console.WriteLine(GC.GetGeneration(test));

            var largeObjectHeap = new byte[4*84000];
            Console.WriteLine(GC.GetGeneration(largeObjectHeap));
        }
    }
}
