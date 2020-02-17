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
            var chainedTask = Task.Run(() =>
            {
                Task.Delay(1000).Wait();
                return Api1("Initial");
            }).ContinueWith((key) =>
            {
                Task.Delay(1000).Wait();
                return Api2(key.Result);
            }).ContinueWith((key) =>
            {
                Task.Delay(1000).Wait();
                return Api3(key.Result);
            });

            Console.WriteLine($"Result: {chainedTask.Result}");
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
