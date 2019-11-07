using System;
using System.Runtime.InteropServices;

namespace UnmanagedCodeRunning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(add(4, 3));
            Console.WriteLine("No way");
            Console.WriteLine(mult(3,9));
        }

        [DllImport("CPlusPlus.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int add(int a, int b);

        [DllImport("CPlusPlus.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int mult(int a, int b);
    }
}
