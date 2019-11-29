using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSchedulerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskFactory = new TaskFactory(new SimpleScheduler());
            for (int i = 0; i < 100; i++)
            {
                taskFactory.StartNew(() =>
                {
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                });
            }
            Console.ReadLine();
        }
    }

    public class SimpleScheduler : TaskScheduler
    {
        BlockingCollection<Task> tasks = new BlockingCollection<Task>();
        private Thread main;


        public SimpleScheduler()
        {
            main = new Thread(Execute);
            main.Start();
        }
        //[return: NullableAttribute(new[] { 2, 1 })]
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return tasks.GetConsumingEnumerable();
        }

        protected override void QueueTask(Task task)
        {
            tasks.Add(task);
            if (!main.IsAlive)
            {
                main = new Thread(Execute);
                main.Start();
            }
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return false;
        }

        private void Execute()
        {
            while (tasks.Count > 0)
            {
                var task = tasks.Take();
                TryExecuteTask(task);
            }
        }
    }
}
