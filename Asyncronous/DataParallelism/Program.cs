using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DataParallelism
{
    class Program
    {
        static ConcurrentDictionary<int, List<int>> dict = new ConcurrentDictionary<int, List<int>>();


        static void Main(string[] args)
        {
            var list = Enumerable.Range(1, 100).ToList();
            //Stopwatch w = Stopwatch.StartNew();
            foreach (var item in list)
            {
                for(int i = 0; i < 100; i++)
                {
                    var num = 5;
                }
            }
            //w.Stop();
            //Console.WriteLine(w.ElapsedMilliseconds + " not parallel");
            // w.Reset();
            //w.Start();

            Parallel.ForEach(list, (el)=> 
            {
                var id = Thread.CurrentThread.ManagedThreadId;
                if (!dict.ContainsKey(id))
                {
                    dict.TryAdd(id, new List<int>());
                }
                dict[id].Add(el);
                //for (int i = 0; i < 100; i++)
                //{
                //    var num = 5;
                //}
            });

            foreach (var item in dict)
            {
                item.Value.Sort();
                Console.WriteLine($"Thread: {item.Key} -> {String.Join(", ", item.Value)}");
            }

            //w.Stop();
            //Console.WriteLine(w.ElapsedMilliseconds + " parallel");
            //w.Reset();
            //w.Start();

            Parallel.For(0,list.Count, (el) =>
            {
                //for (int i = 0; i < 100; i++)
                //{
                //    var num = 5;
                //}
            });
            //w.Stop();
            //Console.WriteLine(w.ElapsedMilliseconds + "for parallel");
        }
    }
}
