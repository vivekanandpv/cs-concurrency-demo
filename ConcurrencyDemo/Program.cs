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
        private static Mutex mutex = new Mutex(false);
        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 10; i++)
            {
                threads.Add(new Thread(Foo));
                //threads.Add(new Thread(FooTimeBound));
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
                mutex.WaitOne();
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is entering");
                Thread.Sleep(1000);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is about to exit");
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        static void FooTimeBound()
        {
            if (!mutex.WaitOne(TimeSpan.FromSeconds(1), true))
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} could not get inside");

            }
            else
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is entering");
                Thread.Sleep(2000);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is about to exit");
                mutex.ReleaseMutex();
            }
        }
    }

}
