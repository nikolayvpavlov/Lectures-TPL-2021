using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace FTaskFanning
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> first = new Task<int>(
                () =>
                {
                    Random rand = new Random();
                    return 5 + rand.Next(21);
                }
                );
            first.Start();
            //Fan out
            first.Wait();
            List<Task<double>> taskList = new List<Task<double>>();
            for (int i = 0; i < first.Result; i++)
            {
                taskList.Add(Task.Run(() =>
              {
                  Random rand = new Random();
                  return Math.Round(rand.NextDouble() * 100, 2);
              }));
            }
            //Fan in
            var fanInTask = Task.WhenAll(taskList);
            var final = fanInTask.ContinueWith(prev => Console.WriteLine(prev.Result.Sum()));
            final.Wait();
            Console.ReadLine();
        }
    }
}
