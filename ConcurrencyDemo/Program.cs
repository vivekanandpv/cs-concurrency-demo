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
        private static ReaderWriterLockSlim readerWriterLockSlim = new ReaderWriterLockSlim();
        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 10; i++)
            {
                threads.Add(new Thread(WritePage));
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
                readerWriterLockSlim.EnterReadLock();
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is reading");
                Thread.Sleep(300);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is about to exit reading");
            }
            finally
            {
                readerWriterLockSlim.ExitReadLock();
            }
        }

        static void WritePage()
        {
            try
            {
                readerWriterLockSlim.EnterWriteLock();
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is writing");
                Thread.Sleep(300);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is about to exit writing");
            }
            finally
            {
                readerWriterLockSlim.ExitWriteLock();
            }
        }
    }

}
