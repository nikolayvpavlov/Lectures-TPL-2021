using System;
using System.Collections.Generic;
using System.Threading;

namespace AThreadPriorities
{
    class Program
    {
        static void BusyWorker()
        {
            while (true)
            {
                ;
            }
        }

        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                var t = new Thread(BusyWorker);
                t.Priority = ThreadPriority.Lowest;
                t.IsBackground = true;
                t.Start();
                threads.Add(t);
            }
            Console.WriteLine("Press ENTER to quit.");
            Console.ReadLine();
        }
    }
}
