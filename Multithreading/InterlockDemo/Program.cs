using System;
using System.Threading;

namespace InterlockDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;

            // no need to lock with Interlocked when HIGH performance is needed
            Interlocked.Increment(ref x);

            Console.WriteLine(x); ;
        }
    }
}
