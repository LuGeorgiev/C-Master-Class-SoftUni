using System;
using System.Linq;

namespace ParallelLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(1, 1000).ToList();

            var pLinq = (from num in list.AsParallel()
                       where num % 3 == 2
                       select num)
                       .ToList();

            Console.WriteLine(String.Join(", ",  pLinq));
        }
    }
}
