static async Task<int> M1()
{
    Console.WriteLine("M1 before await.  ThreadId: " + Thread.CurrentThread.ManagedThreadId);
    await Task.Delay(1000);
    Console.WriteLine("M1 after await. ThreadId: " + Thread.CurrentThread.ManagedThreadId);
    return 42;
}

//marking M1 as async will actuall make the compiler produce something like the following:
//(not true, but close enough)
Task taskM1Part1 = new Task(() =>
{
    Console.WriteLine("M1 before await.  ThreadId: " + Thread.CurrentThread.ManagedThreadId);
    Task.Delay(1000).Wait();
});
Task<int> taskM1Part2 = taskM1Part1.ContinueWith(p =>
{
    Console.WriteLine("M1 after await. ThreadId: " + Thread.CurrentThread.ManagedThreadId);
    return 42;
});


Console.WriteLine("Main before M1.  ThreadId: " + Thread.CurrentThread.ManagedThreadId);
var t = M1();
t.Wait();
Console.WriteLine("Main after M1.  ThreadId: " + Thread.CurrentThread.ManagedThreadId);
Console.ReadLine();

