using ChatterDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    public static class Cmds
    {
        public static void getCmd(Message msg, Socket sock)
        {
            string[] cmd = msg.data.Split(' ');

            switch (cmd[0])
            {
                case "/users":
                    cmd_Users(sock);
                    break;

                case "/ping":
                    cmd_Ping(sock);
                    break;

                case "/kick":
                    cmd_Kick(sock, cmd);
                    break;

                default:
                    try
                    {
                        Messager.sendServerMessage("Unknown Command.", sock);
                    }
                    catch(Exception e)
                    {

                    }
                    break;
            }
        }

        private static void cmd_Kick(Socket sock, string[] args)
        {
            if (args.Length == 2)
            {
                if (HandleConnection.users.ContainsKey(args[1]))
                {
                    Socket user = HandleConnection.users[args[1]];

                    //Messager.sendServerMessage("You got kicked. GIT REKT M8Y!", HandleConnection.users[args[1]]);
                    //HandleConnection.signOut(HandleConnection.users[args[1]]);
                    user.Shutdown(SocketShutdown.Both);
                    user.Close();
                }
            }
        }

        private static void cmd_Ping(Socket sock)
        {
            Message msg = new Message();
            msg.type = msgType.chat;
            msg.sender = MessageFunctions.user_Server;
            msg.data = "Pong.";

            sock.Send(serial.getSerialMsg(msg));
        }

        private static void cmd_Users(Socket sock)
        {
            string users = "Online Users: ";

            foreach (KeyValuePair<String, Socket> kv in HandleConnection.users)
            {
                users += kv.Key + " ";
            }

            Message nMsg = new Message();
            nMsg.type = msgType.chat;
            nMsg.sender = MessageFunctions.user_Server;
            nMsg.data = users;

            try
            {
                sock.Send(serial.getSerialMsg(nMsg));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
