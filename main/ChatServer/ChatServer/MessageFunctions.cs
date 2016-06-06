using ChatterDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    public static class MessageFunctions
    {
        public static readonly User user_Server = new User() { username = "SERVER" };

        public static void handleMessage(Message msg, Socket sock)
        {
            switch (msg.type)
            {
                case msgType.chat:
                    sendMessage(msg, sock);
                    break;

                case msgType.login:
                    login(msg, sock);
                    break;

                default:
                    return;
            }
        }

        private static void sendMessage(Message msg, Socket sock)
        {
            if (msg.data[0].ToString() == "/")
            {
                Cmds.getCmd(msg, sock);
                return;
            }

            Messager.sendMsg(msg, sock);
        }

        private static void login(Message msg, Socket sock)
        {
            if (!HandleConnection.users.ContainsKey(msg.sender.username) && !HandleConnection.socks.ContainsKey(sock))
            {
                HandleConnection.users.Add(msg.sender.username, sock);
                HandleConnection.socks.Add(sock, msg.sender.username);
                Console.WriteLine("[Login]: " + msg.sender.username);

                Message loginResponse = new Message();
                loginResponse.type = msgType.server;
                loginResponse.sender = user_Server;
                loginResponse.receiver = msg.sender;
                loginResponse.servResponse = serverResponse.loginSucess;
                loginResponse.data = "Login Successful!";

                sock.Send(serial.getSerialMsg(loginResponse));
            }
            else
            {
                Message loginResponse = new Message();
                loginResponse.type = msgType.server;
                loginResponse.sender = user_Server;
                loginResponse.receiver = msg.sender;
                loginResponse.servResponse = serverResponse.loginFail;
                loginResponse.data = "Login Failed: Username in use.";

                sock.Send(serial.getSerialMsg(loginResponse));
            }
        }
    }
}
