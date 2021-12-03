class Program
{
    static int Counter = 0;
    static ManualResetEvent mre = new ManualResetEvent(false);

    static void Worker()
    {
        mre.WaitOne();
        #region RaceCondition
        //for (int i = 0; i < 5_000_000; i++)
        //{
        //    Counter = Counter + 1; //Race condition. 
        //}
        //for (int i = 0; i < 4_000_000; i++)
        //{
        //    Counter = Counter - 1; //Race condition.
        //}
        #endregion

        #region Interlocked - Lock-free
        for (int i = 0; i < 5_000_000; i++)
        {
            Interlocked.Increment(ref Counter);
        }
        for (int i = 0; i < 4_000_000; i++)
        {
            Interlocked.Decrement (ref Counter);
        }
        #endregion 
        //Net added: 1 000 000
    }

    static void Main()
    {
        Console.WriteLine("Working...");
        List<Thread> threads = new List<Thread>();
        for (int i = 0; i < 20; i++)
        {
            var t = new Thread(Worker);
            threads.Add(t);
            t.Start();
        }
        mre.Set();
        foreach (var t in threads) t.Join();
        Console.WriteLine($"Counter.  Expected: 20 000 000.  Actual: {Counter}.");
        Console.ReadLine();
    }
}