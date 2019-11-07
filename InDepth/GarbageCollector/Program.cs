using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GarbageCollector
{
    class User
    {
        ~User() // destructor
        {
            //Console.WriteLine("I was destroyed");
        }
    }

    class Person
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            //List<User> user = new List<User>();
            //while (true)
            //{
            //    user.Add(new User());
            //}

            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //User user;
            //for (int i = 0; i < 100000; i++)
            //{
            //    GC.Collect();
            //    user = new User();
            //}
            //Console.WriteLine(watch.ElapsedMilliseconds);

            var weakRef = Test();
            Console.WriteLine(weakRef.IsAlive);
            GC.Collect();
            Console.WriteLine(weakRef.IsAlive);

        }

        static WeakReference Test()
        {
            var p = new User();

            return new WeakReference(p);
        }
    }
}
