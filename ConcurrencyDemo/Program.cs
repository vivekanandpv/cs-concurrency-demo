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
            ThreadPool.QueueUserWorkItem((state) =>
            {
                Console.WriteLine($"State: {state}");

            }, DateTime.UtcNow);

            //  Minimum threads a thread pool can contain is usually the number of CPU cores
            //  Environment.ProcessorCount

            int minWorkerThreads = 0;
            int minCompletionPortThreads = 0;
            

            ThreadPool.GetMinThreads(out minWorkerThreads, out minCompletionPortThreads);


            //  Max is usually in thousands. On my machine, I got 2047 and 1000
            int maxWorkerThreads = 0;
            int maxCompletionPortThreads = 0;

            ThreadPool.GetMaxThreads(out maxWorkerThreads, out maxCompletionPortThreads);


            //  As said earlier, it is a good idea to restrict the threads a pool can have
            //  CPU cores * 2 (sometimes 4) is a healthy count in most circumstances
            //ThreadPool.SetMaxThreads(minWorkerThreads * 2, minCompletionPortThreads * 2);

            //  In some cases, particularly under the scarce resources, you can consider 
            //ThreadPool.SetMinThreads(...);
            //  Please also note that when demand is low, the actual number of thread pool
            //  threads can fall below the minimum values.

            Console.WriteLine($"Min: {minWorkerThreads} & {minCompletionPortThreads}");
            Console.WriteLine($"Max: {maxWorkerThreads} & {maxCompletionPortThreads}");

            Thread.Sleep(1000);
        }
    }
}
