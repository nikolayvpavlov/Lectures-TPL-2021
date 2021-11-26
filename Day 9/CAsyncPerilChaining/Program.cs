using System.Net;

class Program
{
    static Uri qotdUri = new Uri("https://nvp-functions.azurewebsites.net/api/qotd?slow=true");

    static void DownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        Console.WriteLine(e.Result);

        Console.WriteLine();
        Console.WriteLine("Making a second call, stay tuned...");
        Console.WriteLine();

        var webClient2 = new WebClient();
        webClient2.DownloadStringCompleted += Download2Completed;
        webClient2.DownloadStringAsync(qotdUri);
    }

    static void Download2Completed(object sender, DownloadStringCompletedEventArgs e)
    {
        Console.WriteLine("Second result is here: ");
        Console.WriteLine(e.Result);
    }

    static void Main()
    {
        var webClient = new WebClient();
        webClient.DownloadStringCompleted += DownloadCompleted;
        webClient.DownloadStringAsync(qotdUri);

        Console.WriteLine("Web call sent, result is coming soon...");
        Console.WriteLine();

        Console.ReadLine();
    }
}
