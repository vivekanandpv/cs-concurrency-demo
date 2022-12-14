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
            //  Creation of the thread is a costly process
            //  Every thread has its own stack and context switching overheads as well
            //  If the developer can keep on creating threads, then the overhead can outweigh
            //  the performance benefit that could be gained. And the complexity of the application
            //  is yet another issue to tackle with.

            //  In this light, ThreadPool is a convenient abstraction mechanism which recycles the threads
            //  One can consider the ThreadPool like a taxi service. After every trip, the taxi is back to
            //  serve the next customer. As this has to be managed by the CLR, there is not much low-level
            //  API available.

            ThreadPool.QueueUserWorkItem((state) =>
            {
                Console.WriteLine($"Background Thread? {Thread.CurrentThread.IsBackground}" +
                                  $"{Environment.NewLine}" +
                                  $"From ThreadPool? {Thread.CurrentThread.IsThreadPoolThread}" +
                                  $"{Environment.NewLine}" +
                                  $"State: {state.ToString()}");
            }, DateTime.UtcNow);

            //  Since threads from the thread pool are background threads,
            //  the process finishes when the foreground thread (i.e., the Main Thread)
            //  exits. Therefore we delay the completion of Main Thread
            //  Even then, this behaviour is not predictable. Sometimes, the new thread
            //  might finish earlier than the main thread. In which case we can see the
            //  output to the console.

            //  ThreadPool doesn't offer any mechanism for closure as Java's ExecutorService provides
            //  If you need to wait till all the tasks are done in the pool, refer to this answer:
            //  https://stackoverflow.com/a/2520212/3969961
            Thread.Sleep(1000);
        }
    }
}
