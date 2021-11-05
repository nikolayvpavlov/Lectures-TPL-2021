using System;
using System.Threading;

namespace BWaitEvents
{
    class Program
    {
        static ManualResetEvent workerBarrier;
        static ManualResetEvent workerCompleted;

        static void Worker()
        {
            Console.WriteLine("Thread starts.");
            Console.WriteLine("Thread doing some work...");
            Thread.Sleep(1000); //Simulate some delay here...
            //Now we must wait for something else before we continue.
            Console.WriteLine("Thread waits to be allowed to continue.");
            workerBarrier.WaitOne(); //Blocks execution until some other thread sets the event handler.
            Console.WriteLine("Thread continues.");
            Thread.Sleep(1000); //Simulate some more work...
            Console.WriteLine("Thread ends and notifies the main thread.");
            workerCompleted.Set();
        }

        static void Main(string[] args)
        {
            workerBarrier = new ManualResetEvent(false);
            workerCompleted = new ManualResetEvent(false);

            Console.WriteLine("Main creates a thread and runs it.");
            Thread t = new Thread(Worker);
            t.Start();

            Console.WriteLine("Main is doing some work...");
            Thread.Sleep(3000); //simulate some work, longer than the first portion of work in Worker
            Console.WriteLine("Main signals Worker to continue");
            workerBarrier.Set(); //Sets the wait handler so that all who wait can continue.

            Console.WriteLine("Main is waiting for Worker to complete...");
            while (!workerCompleted.WaitOne(100))
            {
                //Do something here...
            }

            Console.WriteLine("Show is over.  Press ENTER to quit.");
            Console.ReadLine();

        }
    }
}
