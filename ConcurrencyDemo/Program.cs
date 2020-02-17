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
        private static string result1;
        private static string result2;
        private static string finalResult;
        static void Main(string[] args)
        {
            var tApi1 = new Thread(() =>
            {
                Thread.Sleep(500);
                result1 = Api1("Initial");
                Console.WriteLine("Api1 completed");
            });

            var tApi2 = new Thread(() =>
            {
                Thread.Sleep(500);
                result2 = Api2(result1);
                Console.WriteLine("Api2 completed");
            });

            var tApi3 = new Thread(() =>
            {
                Thread.Sleep(1000);
                finalResult = Api3(result2);
                Console.WriteLine("Api3 completed");
            });

            tApi1.Start();
            tApi1.Join();

            tApi2.Start();
            tApi2.Join();

            tApi3.Start();
            tApi3.Join();

            Console.WriteLine(finalResult);
        }

        static string Api1(string key)
        {
            return "Key1";
        }

        static string Api2(string key)
        {
            return "Key2";
        }

        static string Api3(string key)
        {
            return "Finally there!";
        }
    }
}
