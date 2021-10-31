using System;
using System.Collections.Generic;
using System.Threading;

namespace EWhatToLock
{
    class Program
    {
        static List<int> data = new List<int>();
        static object objLock = new object();

        static void Writer()
        {
            Random rand = new Random();
            for (int i = 0; i < 100_000; i++)
            {
                int num = rand.Next(1000);
                lock (objLock)
                {
                    data.Add(num);
                }
            }
        }

        static void Reader()
        {
            int sum = 0;
            lock (objLock)
            {
                foreach (int n in data)
                {
                    sum += n;
                }
            }
        }

        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 100; i++)
            {
                var t = new Thread(Writer);
                t.Start();
            }
            for (int i = 0; i < 100; i++)
            {
                var t = new Thread(Reader);
                t.Start();
            }
            foreach (var t in threads) t.Join();
            Console.WriteLine("Ready.");
            Console.ReadLine();

        }
    }
}
