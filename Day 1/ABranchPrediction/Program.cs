using System;

namespace ABranchPrediction
{
    class Program
    {
        static int size = 10_000_000;
        static int[] data = new int[size];

        static void GenerateData()
        {
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                data[i] = rand.Next(10);
            }
        }

        static int CheckBoundary(int boundary)
        {
            int result = 0;
            for (int i = 0; i < size; i++)
            {
                if (data[i] < boundary) result++;
            }
            return result;
        }

        static void Main(string[] args)
        {
            GenerateData();
            var watch = new System.Diagnostics.Stopwatch();
            for (int i = 0; i < 10; i++)
            {
                watch.Restart();
                int count = CheckBoundary(i);
                watch.Stop();
                Console.WriteLine($"{i}. Exec time: {watch.ElapsedMilliseconds}");
            }
            Console.WriteLine("Press ENTER to quit.");
            Console.ReadLine();
        }
    }
}
