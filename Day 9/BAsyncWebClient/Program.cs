using System.Net;

static void DownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
{
    Console.WriteLine(e.Result);
}

Uri qotdUri = new Uri("https://nvp-functions.azurewebsites.net/api/qotd?slow=true");

WebClient webClient = new WebClient();
webClient.DownloadStringCompleted += DownloadCompleted;

webClient.DownloadStringAsync(qotdUri);

Console.WriteLine("Web call sent, result is coming soon...");
Console.WriteLine();

Console.ReadLine();
