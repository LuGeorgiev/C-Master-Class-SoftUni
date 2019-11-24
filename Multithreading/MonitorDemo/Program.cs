using System;
using System.Collections.Generic;
using System.Threading;

namespace MonitorDemo
{
    class Program
    {
        public static object obj = new object();
        static void Main(string[] args)
        {
            Salvation();

            var acc1 = new Account() { amount = 100 };
            var acc2 = new Account() { amount = 55 };
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 10; i++)
            {
                var t1 = new Thread(() =>
                {
                    TransferFifty(acc1, acc2);
                });
                threads.Add(t1);
                t1.Start();


                var t2 = new Thread(() =>
                {
                    TransferFifty(acc2, acc1);
                });
                threads.Add(t2);
                t2.Start();
            }
            threads.ForEach(t => t.Join());

            Console.WriteLine(acc1.amount);
            Console.WriteLine(acc2.amount);
        }

        public static void Salvation()
        {
            //lock (obj)
            //{
            //    Console.WriteLine("Locked");
            //}

            // Above code is equal to following:
            Monitor.Enter(obj);
            Console.WriteLine("Monitor locked");
            Monitor.Exit(obj);
        }

        public static void TransferFifty(Account sender, Account receiver)
        {
            bool isEnteredSender = Monitor.TryEnter(sender, 2000);
            bool isEnteredReceiver = Monitor.TryEnter(receiver, 2000);

            sender.amount -= 50;
            receiver.amount += 50;

            if (isEnteredReceiver)
            {
                Monitor.Exit(receiver);
            }
            if (isEnteredSender)
            {
                Monitor.Exit(sender);
            }
           
            if (!isEnteredReceiver || isEnteredSender)
            {
                Console.WriteLine("Deadlocked");
            }
        }

        public static object first = new object();
        public static object second = new object();
        public static void Deadlock()
        {
            lock (first)
            {
                Console.WriteLine("In First");
                Thread.Sleep(1000);
                lock (second)
                {
                    Console.WriteLine("In Second");
                }
            }
        }

        public static void DeadlockTwo()
        {
            lock (second)
            {
                Console.WriteLine("In TWO First");
                Thread.Sleep(1000);
                lock (first)
                {
                    Console.WriteLine("In TWO Second");
                }
            }
        }
    }

    public class Account
    {
        public decimal amount = 0;
    }
}
