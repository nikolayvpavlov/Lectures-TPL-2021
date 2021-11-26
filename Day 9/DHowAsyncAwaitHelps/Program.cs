
Uri qotdUri = new Uri("https://nvp-functions.azurewebsites.net/api/qotd?slow=true");

HttpClient client = new HttpClient();

Console.WriteLine("Making the first call, result is coming soon...");

string q1 = await client.GetStringAsync(qotdUri);

Console.WriteLine(q1);
Console.WriteLine();
Console.WriteLine("Making a second call, stay tuned...");
Console.WriteLine();

string q2 = await client.GetStringAsync(qotdUri);

Console.WriteLine(q2);

Console.ReadLine();