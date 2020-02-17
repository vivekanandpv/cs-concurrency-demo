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
            DoStuff();
            Console.WriteLine("Main Continue");

            Thread.Sleep(1000);
            Console.WriteLine("Main Finish");
        }

        static async Task DoStuff()
        {
            Console.WriteLine(await GetIntValueAsync());
        }

        static async Task<int> GetIntValueAsync()
        {
            var task = new Task<int>(() =>
            {
                Thread.Sleep(500);
                return 100;
            });

            task.Start();
            return await task;
        }
    }
}
