using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ChatterDLL;

namespace ChatServer
{
    public static class HandleConnection
    {
        public static Dictionary<string, Socket> users = new Dictionary<string, Socket>();
        public static Dictionary<Socket, string> socks = new Dictionary<Socket, string>();

        public static byte[] _buffer = new byte[1000000];

        public static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket = Server._serverSocket.EndAccept(AR);
            Console.WriteLine("A client has connected.");
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            Server._serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private static void ReceiveCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            int recieved;

            try
            {
                recieved = socket.EndReceive(AR);
            }
            catch (SocketException e)
            {
                signOut(socket);
                return;
            }

            byte[] dataBuf = new byte[recieved];
            Array.Copy(_buffer, dataBuf, recieved);

            //Get Message Info.
            Message msg = serial.unserialMsg(_buffer);

            if(msg != null)
                MessageFunctions.handleMessage(msg, socket);

            try {
                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            }
            catch(Exception e)
            {

            }
        }

        public static void signOut(Socket socket)
        {
            if (socks.ContainsKey(socket))
            {
                string username = socks[socket];

                socks.Remove(socket);
                users.Remove(username);

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

                Console.WriteLine("[Disconnect]: " + username);
            }
        }
    }
}
