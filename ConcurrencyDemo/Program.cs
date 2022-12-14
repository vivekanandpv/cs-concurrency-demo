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
        public static readonly object _la = new object();
        public static readonly object _lb = new object();

        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
            {
                lock (_la)
                {
                    Foo();

                    Thread.Sleep(1000);

                    lock (_lb)
                    {
                        Bar();
                    }
                }
            })
            { Name = "T1" };

            Thread t2 = new Thread(() =>
            {
                lock (_lb)
                {
                    Bar();

                    Thread.Sleep(1000);

                    lock (_la)
                    {
                        Foo();
                    }
                }
            })
            { Name = "T2" };

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("Main ends");
        }

        static void Foo()
        {
            Console.WriteLine($"Thread: {Thread.CurrentThread.Name} executes Foo");
        }

        static void Bar()
        {
            Console.WriteLine($"Thread: {Thread.CurrentThread.Name} executes Bar");
        }
    }
}
