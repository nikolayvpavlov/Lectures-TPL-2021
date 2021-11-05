using System;
using System.Threading;
using System.Linq;

namespace CSemaphore
{
    class Program
    {
        static Semaphore semaphore;

        static void Worker(object obj)
        {
            string id = obj.ToString();
            Console.WriteLine($"{id} starts.");
            Thread.Sleep(500); //Simulate some work.
            Console.WriteLine($"{id} tries to acquire a limited resource...");
            semaphore.WaitOne(); //Blocks until resource becomes available.
            Console.WriteLine($"{id} acquires the resource successfully.");
            Thread.Sleep(1000); //Simulate some work again.
            Console.WriteLine($"{id} releases the resource.");
            semaphore.Release();
            Console.WriteLine($"{id} ends.");
        }

        static void Main(string[] args)
        {
            semaphore = new Semaphore(3, 3);

            var workers = Enumerable
                .Range(0, 10)
                .Select(i =>
                  {
                      var t = new Thread(Worker);
                      t.Start((Char)('A' + i));
                      return t;
                  }).ToArray();

            foreach (var w in workers) w.Join();
        }
    }
}
