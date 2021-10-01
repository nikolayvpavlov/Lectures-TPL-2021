using System;
using System.Threading;

namespace BFirstThread
{
    class Program
    {
        static void ThreadMethod()
        {
            Console.WriteLine("Hello from my first thread!");
            for (int i = 0; i < 10 ; i++)
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Thread myThread;
            myThread = new Thread(ThreadMethod);
            myThread.Start();
            Console.WriteLine("Main() is minding its own business.");
            
            Console.WriteLine("Main is waiting for myThread to finish.");
            myThread.Join();

            Console.WriteLine("Press ENTER to quit.");
            Console.Read();
        }
    }
}
