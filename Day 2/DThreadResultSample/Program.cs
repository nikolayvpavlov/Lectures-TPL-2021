using System;
using System.Threading;

namespace DThreadResultSample
{
    class Program
    {
        enum ThreadResult { Success, Cancelled, Faulted };
        
        static volatile ThreadResult threadResult;
        static Exception threadException;

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
                threadResult = ThreadResult.Success;
            }
            catch (Exception x)
            {
                threadResult = ThreadResult.Faulted;
                threadException = x;

            }
            Console.WriteLine("Thread done.");
        }

        static void Main(string[] args)
        {
            Thread t = new Thread(FaultyWorker);
            t.Start();

            while (!t.Join(100))
            {
                Console.Write(".");
            }
            Console.WriteLine();

            switch (threadResult)
            {
                case ThreadResult.Success:
                    Console.WriteLine("All is well.");
                    break;
                case ThreadResult.Cancelled:
                    Console.WriteLine("Operation cancelled by us.");
                    break;
                case ThreadResult.Faulted:
                    Console.WriteLine("Some error occurred: \n" + threadException.Message);
                    break;
                default:
                    throw new ArgumentException("Unsupported value for: " + threadResult.ToString());
            }

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
