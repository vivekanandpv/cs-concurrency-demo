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
        public static int Counter = 0;
        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 4; i++)
            {
                Thread t = new Thread(() =>
                {
                    //  Any variable created within the thread is local to it
                    //  This cannot be mutated or changed by other threads
                    //  Therefore the j will always be 10000 for every thread
                    //  Every thread's j is different by the way!

                    var j = 0;  

                    while(j < 10000)
                    {
                        Increment();
                        Decrement();
                        j++;
                    }

                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} exited after {j} iterations");
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

            //  Counter is the shared resource and is prone to thread synchronization issues
            Console.WriteLine($"Counter: {Counter}");
        }

        static void Increment()
        {
            Counter++;
        }

        static void Decrement()
        {
            Counter--;
        }
    }
}
