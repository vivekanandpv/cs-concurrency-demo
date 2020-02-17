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
            //  Internally, tasks create a state machine. So they can
            //  return values. This is not directly possible using the
            //  Threads, where we should use shared state (recall that a thread
            //  cannot start a delegate that returns a value). This, as we
            //  know brings in complexity of dealing with thread safety issues.

            var t = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                return 100;
            });

            t.Start();
            
            t.Wait();
            Console.WriteLine(t.Result);
        }
    }
}
