using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyDemo
{
    class Program
    {
        private static object lockObject = new object();
        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 10; i++)
            {
                threads.Add(new Thread(ReadPage));
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }
        }

        static void ReadPage()
        {
            try
            {
                Monitor.Enter(lockObject);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is reading");
                Thread.Sleep(300);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is about to exit reading");
            }
            finally
            {
               Monitor.Exit(lockObject);
            }
        }

        static void ReadPageLimit()
        {
            if (Monitor.TryEnter(lockObject))
            {
                try
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is reading");
                    Thread.Sleep(300);
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is about to exit reading");
                }
                finally
                {
                    Monitor.Exit(lockObject);
                }
            }
            else
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} could not make it");

            }

        }

    }
}
