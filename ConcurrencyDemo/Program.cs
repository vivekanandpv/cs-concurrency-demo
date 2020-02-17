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
            for (int i = 0; i < 4; i++)
            {
                Thread t = new Thread(() =>
                {
                    //  By the way, this is the closure
                    Thread.Sleep(200 * i);
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is executing...");

                });

                //  set t as a background thread
                t.IsBackground = true;

                //  Start
                t.Start();
            }

            Thread.Sleep(500);

            //  When Main Thread exits, the background threads are halted.
            //  By default, the threads that we create are not background threads.
        }
    }
}
