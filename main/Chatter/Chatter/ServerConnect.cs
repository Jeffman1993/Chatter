using ChatterDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatter
{
    public static class ServerConnect
    {
        public static IPAddress serverIP = IPAddress.Loopback;
        private const int serverPort = 25565, loginTimeout = 10;

        public static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public static void attempLogin(User user)
        {
            Thread t = new Thread(() => login(user));
            t.IsBackground = true;
            t.Start();
        }

        public static void login(User user)
        {
            Chat.addText("Connecting to server...");
            int conAttempts = 0;

            while (!_serverSocket.Connected)
            {
                try
                {
                    conAttempts++;
                    _serverSocket.Connect(serverIP, serverPort);
                    Chat.addText("Connected to server!");
                    ChatListener.StartListener();
                }
                catch (SocketException e)
                {
                    if (conAttempts >= loginTimeout)
                    {
                        frmMain.isSignedIn = false;
                        Chat.addText("Connection failed.");
                        return;
                    }
                }
            }
        }
    }
}
