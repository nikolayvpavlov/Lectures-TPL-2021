using System;
using System.Threading;
using System.Threading.Tasks;

namespace D2TaskCancellation
{
    class Program
    {
        static CancellationToken token;

        static int Compute()
        {
            Random rand = new Random();
            int sum = 0;
            for (int i = 0; i < 100; i++)
            {
                token.ThrowIfCancellationRequested();
                Task.Delay(100).Wait();
                sum = sum + rand.Next(100);
            }
            return sum;
        }

        static void Main(string[] args)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
            Task<int> computeTask = new Task<int>(Compute, token);
            computeTask.Start();

            Console.WriteLine("Task started (press C to cancel the operation): ");
            try
            {
                while (!computeTask.Wait(200))
                {
                    if (Console.KeyAvailable && Console.ReadKey().KeyChar == 'c')
                    {
                        tokenSource.Cancel();
                    }
                    Console.Write(".");
                }
                Console.WriteLine();
                Console.WriteLine("Result: " + computeTask.Result);
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is OperationCanceledException)
                {
                    Console.WriteLine();
                    Console.WriteLine("Task was canceled.");
                }
                else
                {
                    Console.WriteLine("Error occurred inside the task: " + ex.InnerException.Message);
                }
            }
            Console.ReadLine();
        }
    }
}
