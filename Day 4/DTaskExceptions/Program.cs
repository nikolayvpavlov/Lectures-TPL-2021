using System;
using System.Threading.Tasks;

namespace DTaskExceptions
{
    class Program
    {
        static void FaultyWorker()
        {
            Task.Delay(2000).Wait();
            throw new InvalidOperationException("Something bad happened.");
        }

        static void Main(string[] args)
        {
            Task task = new Task(FaultyWorker);
            task.Start();

            Console.WriteLine("Doing something else after starting the task.");
            Task.Delay(500).Wait();

            Console.WriteLine("Now wait for the task to complete.");
            try
            {
                task.Wait();
            }
            catch (AggregateException ae)
            {
                Exception taskException = ae.InnerException;
                Console.WriteLine("My task faulted with: " + taskException.Message);
            }
            Console.WriteLine("Task ran to completion.");

            Console.WriteLine("Press ENTER to quit.");
            Console.ReadLine();
        }
    }
}
