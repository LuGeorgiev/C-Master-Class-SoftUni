using System;
using System.Text;

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

            var builder = new StringBuilder();
            var someRef = __makeref(builder);
            IntPtr intPointer = **(IntPtr**)&someRef;
            Console.WriteLine("the addres at heap of first Builder is: " + intPointer);

            var builder2 = new StringBuilder();
            var someRef2 = __makeref(builder2);
            IntPtr intPointer2 = **(IntPtr**)&someRef2;
            Console.WriteLine("the addres at heap of first Builder TWO is: " + intPointer2);

            Console.WriteLine(new string('=',20));
            //string table

            string first = "f";
            someRef = __makeref(first);
            var firstRef = **(IntPtr**)&someRef;
            Console.WriteLine((long)firstRef);
            string second = "f";
            someRef = __makeref(second);
            var secondRef = **(IntPtr**)&someRef;
            Console.WriteLine((long)secondRef);

            var third = Console.ReadLine();
            //var third = String.Intern( Console.ReadLine());
            someRef = __makeref(third);
            var thirdRef = **(IntPtr**)&someRef;
            Console.WriteLine((long)thirdRef);

            Console.WriteLine(new string('=', 20));


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
