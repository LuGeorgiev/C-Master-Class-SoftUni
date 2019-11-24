using System;
using System.Threading;

namespace MutexDemo
{
    class Program
    {
        //static Mutex mutex = new Mutex(false, "Pesho");

        static void Main(string[] args)
        {
            //Name can be given to the Mutex and other processes can use it also like Chrome or other apps
            //Locking the resource wile used by other proceses
            new Thread(FromProcess).Start();
        }

        static void FromProcess()
        {
            Mutex mutex;
            Mutex.TryOpenExisting("Pesho", out mutex);
            if (mutex == null)
            {
                mutex = new Mutex(false, "Pesho"); //fasle will not acquire ownership from the other process
            }
            else
            {
                mutex.WaitOne();
            }

            Console.WriteLine("Inside mutex");
            Console.ReadLine();
            mutex.ReleaseMutex();
        }
    }
}
