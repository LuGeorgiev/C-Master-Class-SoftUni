using System;

namespace WorkingWithPointers
{
    class Program
    {
        public struct MyStruct
        {
            public double a, b, c, d, e, f, g, h, i, j, k, l, m; 
        }

        static long topOfStack;
        static long stackSize = 1024 * 1024; 

        unsafe static void Main(string[] args)
        {
            long x = 5;
            long xPointer = (long)&x;
            long y = 5;

            Console.WriteLine(xPointer);
            Console.WriteLine((long)&y);

            topOfStack = (long)&x;

            var str = new MyStruct()
            {
                a = 2323.2387,
                b = 08929743,
                c = 614236.325,
                d  = 231.87346239,
                e = 34.43,
                f = 98,
                g = 9.0897,
                h = 87761,
                i = 10983,
                j = 9898.989898,
                k = 989,
                l = 9.08,
                m = 9
            };

            //Recurs(str, 0);
        }

        unsafe static void Recurs(MyStruct x, int times)
        {
            long remainingMemory;
            Console.WriteLine((long)&remainingMemory);
            remainingMemory =   topOfStack - (long)&remainingMemory;

            if (stackSize - remainingMemory < 0)
            {
                Console.WriteLine(times);
                return;
            }

            Recurs(x, ++times);
        }
    }
}
