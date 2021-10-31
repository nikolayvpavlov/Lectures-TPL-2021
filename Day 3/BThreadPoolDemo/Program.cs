using System;
using System.Threading;

namespace BThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(
                param =>
                {
                    Console.WriteLine("Hello from the thread pool.");
                });
            Console.WriteLine("Press ENTER to quit.");
            Console.ReadLine();
        }
    }
}
