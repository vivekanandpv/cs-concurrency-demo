using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyDemo
{
    class Program
    {
        static object lockObject = new object();
        static Dictionary<int, string> logs = new Dictionary<int, string>();
        private static int randomNumber = 0;

        private static Random random = new Random();

        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 4; i++)
            {
                var t = new Thread(() =>
                {
                    while (true)
                    {
                        Log();
                    }
                }) { Name = $"Thread {i + 1}", IsBackground = true};
                threads.Add(t);
            }

            Console.WriteLine("Starting");

            foreach (var thread in threads)
            {
                thread.Start();
            }

            Console.WriteLine("Task");
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(100);
                    randomNumber = random.Next();
                }
            });

            Thread.Sleep(2000);
            Console.WriteLine("Finished");

        }


        static void Log()
        {
            lock (lockObject)
            {
                Console.WriteLine("Log");
                Thread.Sleep(200);
                logs.Add(randomNumber, Thread.CurrentThread.Name);
            }
        }



    }


}
