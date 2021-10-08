using System;
using System.Threading;

namespace BThreadCancellation
{
    class Program
    {
        static volatile bool shouldStop;
        static volatile bool isReady;
        static void ThreadWorker()
        {
            Console.WriteLine("Thread starts...");
            string str = "";
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                if (shouldStop) break;
                str = str + rand.Next(10).ToString();
                Thread.Sleep(100);
            }
            Console.WriteLine("Thread is cleaning up and closing.");
            isReady = true;
        }

        static void Main(string[] args)
        {
            Thread t = new Thread(ThreadWorker);
            shouldStop = false;
            isReady = false;
            t.Start();
            Console.WriteLine("Press 'c' to cancel the worker.");
            while (!isReady)
            {
                ConsoleKeyInfo key;
                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey();
                    if (key.KeyChar == 'c') 
                    {
                        //Ask the thread to stop.
                        shouldStop = true;
                    }
                }
            }
            
            Console.WriteLine("Done.");

        }
    }
}
