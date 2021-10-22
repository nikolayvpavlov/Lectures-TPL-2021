using System;
using System.Threading.Tasks;

namespace BTaskResults
{
    class Program
    {
        static int GenerateRandomNumber()
        {
            Random rand = new Random();
            return rand.Next(1000);
        }

        static void Main(string[] args)
        {
            Task<int> task = new Task<int>(GenerateRandomNumber);
            task.Start();

            //Do something else here.
            Console.WriteLine("Hi, I am working while the task is running in parallel.");

            task.Wait();

            int result = task.Result;
            Console.WriteLine($"The result of the task is: {result}.");

            Console.ReadLine();
        }
    }
}
