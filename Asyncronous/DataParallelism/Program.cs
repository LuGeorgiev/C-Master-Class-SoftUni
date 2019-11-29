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
        static ConcurrentDictionary<int, List<string>> dict = new ConcurrentDictionary<int, List<string>>();


        static void Main(string[] args)
        {
            var list = Enumerable.Range(1, 1000).ToList();
            var partitioner = Partitioner.Create(0, 100);
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

            //Parallel.ForEach(list, (el)=> 
            //{
            Parallel.ForEach(partitioner, (startEnd) =>
            {
                for (int i = startEnd.Item1; i < startEnd.Item2; i++)
                {
                    //Here we work in one portion from the wjole collection due to partitioner
                }

                var id = Thread.CurrentThread.ManagedThreadId;
                if (!dict.ContainsKey(id))
                {
                    dict.TryAdd(id, new List<string>());
                }
                dict[id].Add(startEnd.Item1 + "->" + startEnd.Item2);
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

    //public class MyPart : Partitioner<string>
    //{
    //    public override IList<IEnumerator<string>> GetPartitions(int partitionCount)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
