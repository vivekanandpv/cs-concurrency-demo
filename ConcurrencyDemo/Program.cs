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
        static void Main(string[] args)
        {
            var thread1 = new Thread(() =>
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine($"Counter is {i}");
                        Thread.Sleep(100);
                    }
                }
                catch (ThreadAbortException e)
                {
                    Console.WriteLine("Aborted");
                    //Thread.ResetAbort();
                }

                Console.WriteLine("Thread resumed");
                Thread.Sleep(1000);

            });

            thread1.Start();

            Thread.Sleep(200);
            thread1.Abort();
            thread1.Join();
        }
    }
}
