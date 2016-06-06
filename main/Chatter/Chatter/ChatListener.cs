using ChatterDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chatter
{
    public static class ChatListener
    {

        public static byte[] _buffer = new byte[1000000];

        public static void StartListener()
        {
            ServerConnect._serverSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), ServerConnect._serverSocket);

            if (!frmMain.isSignedIn)
            {

                ChatterDLL.Message loginReq = new ChatterDLL.Message();
                loginReq.type = msgType.login;
                loginReq.sender = Chat.localUser;
                loginReq.receiver = new User() { username = "SERVER" };


                ChatSender.sendMessage(loginReq);
                Chat.addText("Signing in...");
            }
        }

        private static void ReceiveCallBack(IAsyncResult AR)
        {
            Socket sock = (Socket)AR.AsyncState;
            int received;

            try
            {
                received = sock.EndReceive(AR);
            }
            catch(SocketException e)
            {
                Chat.addText("Lost connection to server.");
                frmMain.isSignedIn = false;
                return;
            }

            ServerConnect._serverSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), ServerConnect._serverSocket);

            byte[] data = new byte[received];
            Array.Copy(_buffer, data, received);

            Message msg = serial.unserialMsg(_buffer);

            if (msg.type == msgType.chat)
                Chat.addMessage(msg);
            else if (msg.type == msgType.server)
                ServerMessage.handleMessage(msg);
        }
    }
}
