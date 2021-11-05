using System;
using System.Threading.Tasks;

namespace ATaskContinuationOptions
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Problem with managing the execution of our flow at each step.
            //var t1 = new Task<int>(
            //    () =>
            //    {
            //        throw new InvalidOperationException("Some error occurred.");
            //        //return 42;
            //    });
            //var t2 = t1.ContinueWith(
            //    p =>
            //    {
            //        if (p.IsCompletedSuccessfully)
            //        {
            //            Console.WriteLine(p.Result);
            //        }
            //        else
            //        {
            //            throw new Exception("Something is wrong, must not continue.");
            //        }
            //    });
            //var t3 = t2.ContinueWith(
            //    p =>
            //    {
            //        if (p.IsCompletedSuccessfully)
            //        {
            //            Console.WriteLine("I run after task 2.");
            //        }
            //    }
            //    );
            //t1.Start();
            //t3.Wait();
            #endregion

            var t1 = new Task<int>(() =>
            {
                throw new InvalidOperationException("Some error occurred.");
            });
            var t2 = t1.ContinueWith(p =>
            {
                return p.Result.ToString();
            }, 
            TaskContinuationOptions.OnlyOnRanToCompletion);
            var t3 = t2.ContinueWith(p =>
            {
                Console.WriteLine(p.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            t1.Start();

            Console.WriteLine("Press ENTER to quit.");
            Console.ReadLine();
        }
    }
}
