using System;
using System.Net.Sockets;
using System.Text;

class HelloClient
{
    static void Main(string[] args)
    {
        if (args.Length != 3 || !int.TryParse(args[1], out var port))
        {
            Console.WriteLine("Usage helloclient <server> <port> <name>");
            return;
        }

        var data = Encoding.UTF8.GetBytes(args[2]);

        using var client = new TcpClient(args[0], port);
        using var stream = client.GetStream();

        stream.Write(data, 0, data.Length);

        data = new byte[256];
        var nread = stream.Read(data, 0, data.Length);
        Console.WriteLine(Encoding.UTF8.GetString(data, 0, nread));
    }
}

