using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var thread1 = new Thread(delegate ()
            {
                Console.WriteLine($"Managed Thread Id for the current thread: " +
                                      $"{Thread.CurrentThread.ManagedThreadId}" +
                                      $"{Environment.NewLine}" +
                                      $"Thread Name: {Thread.CurrentThread.Name}" +
                                      $"{Environment.NewLine}" +
                                      $"Priority: {Thread.CurrentThread.Priority}" +
                                      $"{Environment.NewLine}" +
                                      $"State: {Thread.CurrentThread.ThreadState}" +
                                      $"{Environment.NewLine}" +
                                      $"From thread pool?: {Thread.CurrentThread.IsThreadPoolThread}");

            })
            {
                Name = "First Thread"
            };
            thread1.Start();

            Thread.Sleep(1000);
            Console.WriteLine($"First thread after one second: Alive? {thread1.IsAlive}, State: {thread1.ThreadState}");
        }
    }
}
