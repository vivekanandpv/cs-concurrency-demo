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
        //  We want to make the delegate body as a single atomic unit, though it is not.
        //  We do so by introducing the mutex (mutually exclusive) lock
        //  It is advisable to use a dedicated reference type object for locks.
        //  Please read this: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/lock-statement#remarks

        public static readonly object counterOperationLock = new object();

        public static int Counter = 0;
        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 4; i++)
            {
                Thread t = new Thread(() =>
                {
                    //  the effect is more pronounced if the limit is set higher
                    for (int j = 0; j < 10000; j++)
                    {
                        lock (counterOperationLock) //  only one thread can enter the block
                        {
                            Counter++;  //  This is now artificially atomic!
                        }
                    }
                });

                t.Start();
                threads.Add(t);
            }

            foreach (var thread in threads)
            {
                //  wait for all threads to finish
                //  otherwise we reach Console.WriteLine early
                thread.Join();
            }

            //  Result is now predictable
            Console.WriteLine($"Counter: {Counter}");
        }
    }
}
