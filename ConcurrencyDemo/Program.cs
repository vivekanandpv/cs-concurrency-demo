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
            //  Threads are low-level API. With power comes complexity.
            //  Tasks are higher level abstractions over threads that are
            //  most suited for I/O bound loads.
            //  Internally, tasks use ThreadPool hence they are efficient
            //  Working with the tasks is almost like working with threads
            //  but much easier

            Task t = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Hi there!");
            });

            t.Start();
            
            //  As said already, tasks use ThreadPool, which spawns up
            //  background threads that are abandoned as soon as the Main Thread
            //  ends. So don't forget to Wait (similar to thread.Join())

            t.Wait();
        }
    }
}
