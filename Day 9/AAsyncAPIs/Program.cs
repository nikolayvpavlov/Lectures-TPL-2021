using System;
using System.IO;

class Program
{
    static string fileName = @"c:\temp\Claims-Based Identity for Windows.pdf";
    static byte[] buffer = new byte[1024 * 1024];
    static FileStream? fileStream;

    static void ReadingComplete(IAsyncResult ar)
    {
        int bytesRead = fileStream.EndRead(ar);
        //Now we can read the file content from array buffer.
        for (int i = 0; i < bytesRead; i++)
        {
            //Do something with the content of the buffer.
        }
    }

    static void Main() {

        fileStream = new FileStream(fileName, FileMode.Open);
        fileStream.BeginRead(buffer, 0, 1024 * 1024, ReadingComplete, null);
        

        Console.WriteLine("Hello, World!");
    }
}
