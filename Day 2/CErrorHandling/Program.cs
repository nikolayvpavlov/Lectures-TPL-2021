using System;
using System.Threading;

namespace CErrorHandling
{
    class Program
    {
        static void FaultyWorker()
        {
            try
            {
                Random rand = new Random();
                for (int i = 0; i < 1000; i++)
                {
                    int val = rand.Next(20);
                    if (val == 0) throw new Exception("Something bad happened.");
                    Thread.Sleep(10);
                }
            }
            catch (Exception x)
            {
                Console.WriteLine("Error occured in thread: \n" + x.Message);
            }
            Console.WriteLine("Thread done.");
        }

        static void Main(string[] args)
        {
            //Try - Catch is useless here, it cannot trap the error of the thread.

            Thread t = new Thread(FaultyWorker);
            t.Start();

            while (!t.Join(100))
            {
                Console.Write(".");
            }
            Console.WriteLine();

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
