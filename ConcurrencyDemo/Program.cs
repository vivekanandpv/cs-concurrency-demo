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
            var thread1 = new Thread(delegate()
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Anonymous function implementation, Counter: {i}");
                }
            });
            var thread2 = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Delegate implementation, Counter: {i}");
                }
            });

            thread1.Name = "First Thread";
            thread2.Name = "Second Thread";

            thread1.Start();
            thread2.Start();

            ExecuteTask();
        }

        private static void ExecuteTask()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Method implementation (main thread), Counter: {i}");
            }
        }
    }
}
