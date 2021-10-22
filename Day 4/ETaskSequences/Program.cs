using System;
using System.Threading.Tasks;

namespace ETaskSequences
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> first = new Task<int>(() => 42);
            Task<int> second = first.ContinueWith(prev => prev.Result * 2);
            Task<string> third = second.ContinueWith(prev => prev.Result.ToString());
            Task fourth = third.ContinueWith(prev => Console.WriteLine(prev.Result));

            first.Start();
            fourth.Wait();
            Console.ReadLine();
        }
    }
}
