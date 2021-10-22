using System;
using System.Threading;
using System.Threading.Tasks;

namespace AIntroTasks
{
    class Program
    {
        static void Worker()
        {
            Console.WriteLine("Hello from my first task!");
        }

        static void Main(string[] args)
        {
            Task task = new Task(Worker);
            task.Start();

            //Wait for the task to complete.
            task.Wait();

            //Alternatively: spin until task is completed:
            //Be careful not to rely on TaskStatus.Running: task may not have started yet
            //while (task.Status != TaskStatus.RanToCompletion)
            //{
            //    //Do nothing
            //}

            Console.WriteLine("Press ENTER to quit.");
            Console.ReadLine();
        }
    }
}
