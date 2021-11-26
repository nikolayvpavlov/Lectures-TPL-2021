Uri qotdUri = new Uri("https://nvp-functions.azurewebsites.net/api/qotd?slow=true");

HttpClient client = new HttpClient();

Console.WriteLine("Making a few calls, result is coming soon...");

Task<string> downloadTask1 = client.GetStringAsync(qotdUri);
Task<string> downloadTask2 = client.GetStringAsync(qotdUri);
Task<string> downloadTask3 = client.GetStringAsync(qotdUri);
Task<string> downloadTask4 = client.GetStringAsync(qotdUri);

string q1 = await downloadTask1;
string q2 = await downloadTask2;
string q3 = await downloadTask3;
string q4 = await downloadTask4;

Console.WriteLine(q1);
Console.WriteLine(q2);
Console.WriteLine(q3);
Console.WriteLine(q4);

Console.ReadLine();