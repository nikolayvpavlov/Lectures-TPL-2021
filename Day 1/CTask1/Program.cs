using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CTask1
{
    class Program
    {
        static int size = 10;
        static int[] numbers = new int[size];

        static void GenerateRandomNumber(object objIndex)
        {
            int index = (int)objIndex;
            numbers[index] = (new Random()).Next(1000);
        }

        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < size; i++)
            {
                Thread t = new Thread(GenerateRandomNumber);
                threads.Add(t);
                t.Start(i);
            }
            //Wait for all threads to complete.
            foreach (var t in threads) t.Join();
            //Now, that all are complete, we can safely sum the numbers.
            Console.WriteLine(numbers.Sum());
            Console.ReadLine();


        }
    }
}
