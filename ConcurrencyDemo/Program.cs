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
                    //  the effect is more pronounced if the limit is set higher
                    for (int j = 0; j < 10000; j++)
                    {
                        Counter++;  //  This is not an atomic operation!
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

            //  Result is unpredictable and that is the root of all evil
            Console.WriteLine($"Counter: {Counter}");
        }

        static void Increment()
        {
            
        }
    }
}
