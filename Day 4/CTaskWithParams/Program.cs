using System;
using System.Threading.Tasks;

namespace CTaskWithParams
{
    class Program
    {
        static double ComplexComputation (double input)
        {
            Task.Delay(2000).Wait(); //An alternative way to sleep, but better.  If you don't Wait the task, returned by Delay(), it will just expire behind your back.
            return 2 * input * Math.PI; 
        }

        static void Main(string[] args)
        {
            double taskParam = 10;
            var task = new Task<double>(() => ComplexComputation(taskParam));
            task.Start();
            
            Console.WriteLine("Task started.");

            //This will force our code to block until the task is completed.
            Console.WriteLine("Task result: " + task.Result);
            Console.ReadLine();
        }
    }
}
