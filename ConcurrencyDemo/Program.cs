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
            var thread1 = new Thread(ExecuteTask);
            var thread2 = new Thread(ExecuteTask);

            thread1.Name = "First Thread";
            thread2.Name = "Second Thread";

            thread1.Start();
            thread2.Start();
        }

        private static void ExecuteTask()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.Name}, Counter: {i}");
            }
        }
    }
}
