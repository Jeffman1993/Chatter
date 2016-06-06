using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class Server
    {
        private static byte[] _buffer = new byte[1024];
        private static List<Socket> _clientSockets = new List<Socket>();
        public static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main(string[] args)
        {
            Console.Title = "Chat Server";
            SetupServer();
            Console.ReadLine();
        }


        private static void SetupServer()
        {
            Console.WriteLine("Setting up server...");
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 25565));
            _serverSocket.Listen(5);
            _serverSocket.BeginAccept(new AsyncCallback(HandleConnection.AcceptCallback), null);
            Console.WriteLine("Server is now online.");
        }
    }
}
