using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace MemoryLeak
{
    class Olympics
    {
        public static List<Runner> TryoutRunners = new List<Runner>();
    }

    class Runner
    {
        private string _fileName = "test.txt";
        private FileStream _fStream;
        public void GetStats()
        {
            FileInfo fInfo = new FileInfo(_fileName);
            _fStream = fInfo.OpenRead();

            //opens WITHOUT closing teh file
        }
    }

    class Program
    {
        static event EventHandler someEvent;

        static void Main(string[] args)
        {
            //while (true)
            //{
            //    someEvent += (sender, arg) => { };
            //}

            while (true)
            {
                var runner = new Runner();
                Olympics.TryoutRunners.Add(runner);
                runner.GetStats();
            }

            //Even after teh program is stopped the memory is not free
        }
    }
}
