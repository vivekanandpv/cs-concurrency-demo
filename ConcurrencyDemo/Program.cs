using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyDemo
{
    class Program
    {
        private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(4);
        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 10; i++)
            {
                threads.Add(new Thread(Foo));
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }
        }

        static void Foo()
        {
            try
            {
                semaphoreSlim.Wait();
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is entering");
                Thread.Sleep(1000);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is about to exit");
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }
    }

}
