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
            //  When an exception happens in a task,
            //  it will be rethrown to the method that is awaiting
            //  either task.Wait() or task.Result or await
            try
            {
                Console.WriteLine(await GetIntValueAsync());
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae);
            }
        }

        static async Task<int> GetIntValueAsync()
        {
            var task = new Task<int>(() =>
            {
                Task.Delay(500);
                throw new Exception("Task throws exception");
            });

            task.Start();
            return await task;
        }
    }
}
