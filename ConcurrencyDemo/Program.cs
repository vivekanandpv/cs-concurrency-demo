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
        //  Threads are autonomous execution streams, which may have shared state
        //  So, the exception handling is specific to the thread that caused the exception
        //  A general error is to anticipate the exception handling in a different thread.
        //  Exceptions do not permeate to the Main Thread as beginners usually think.

        private static string result1;
        
        static void Main(string[] args)
        {
            var tApi1 = new Thread(() =>
            {
                try
                {
                    result1 = Api1("Initial");
                    Console.WriteLine("Api1 completed");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception caught in the thread: {e.Message}");
                }
            });

            tApi1.Start();
            Console.WriteLine("Can I see this?");
        }

        static string Api1(string key)
        {
            throw new NotImplementedException("Not yet available");
        }

    }
}
