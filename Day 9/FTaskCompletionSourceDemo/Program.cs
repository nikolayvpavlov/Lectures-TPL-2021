TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();

Thread thread = new Thread(() =>
{
    Thread.Sleep(1000);
    tcs.SetResult("I am ready!");
});
thread.Start();

Console.WriteLine("Starting a task.");

Task<string> task = tcs.Task;

Console.WriteLine("Task is running, we will now wait for it.");

string result = await task;

Console.WriteLine("Press ENTER to quit.");
Console.ReadLine();
