using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class HelloServer
{
    public static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Usage: hellpserver <port>");
            return;
        }

        TcpListener server = new TcpListener(IPAddress.Any, Int32.Parse(args[0]));

        Console.CancelKeyPress += (o, ev) => { ev.Cancel = true; server.Stop(); };
        try
        {
            server.Start();
            while (true)
            {
                var client = server.AcceptTcpClient();
                Task.Run(() => HandleClient(client));
            }
        }
        catch (SocketException ex)
        {
            if ((int)ex.SocketErrorCode != 10004)
            {
                Console.WriteLine($"Error: {ex}");
            }
        }
    }

    static void HandleClient(TcpClient client)
    {
        try
        {
            var bytes = new byte[20];
            var stream = client.GetStream();

            int nread;
            while ((nread = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                var data = Encoding.ASCII.GetString(bytes, 0, nread);
                var msg = Encoding.ASCII.GetBytes($"Hello, {data}");

                stream.Write(msg, 0, msg.Length);
            }
        }
        finally
        {
            client.Dispose();
        }
    }
}