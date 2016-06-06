using ChatterDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    public static class Messager
    {
        public static void sendMsg(Message msg, Socket sock)
        {
            //If user is online try to send them the message.
            if (HandleConnection.users.ContainsKey(msg.receiver.username))
            {
                try
                {
                    Socket receiver = HandleConnection.users[msg.receiver.username];
                    receiver.Send(serial.getSerialMsg(msg));
                    Console.WriteLine("[Route Message]: " + msg.sender.username + " ==> " + msg.receiver.username);
                }
                catch(Exception e)
                {
                    Console.WriteLine("[Error]: Could not pass message to " + msg.receiver.username);
                }
            }

            //Receiver is offline, send message back to sender.
            else
            {
                Message eMsg = new Message();
                eMsg.type = msgType.chat;
                eMsg.sender = MessageFunctions.user_Server;
                eMsg.data = "[Error]: " + msg.receiver.username + " is not online... :'(";

                sock.Send(serial.getSerialMsg(eMsg));
            }
        }

        public static void sendServerMessage(string msgData, Socket sock)
        {
            if (HandleConnection.socks.ContainsKey(sock))
            {
                try
                {
                    Message msg = new Message();
                    msg.type = msgType.chat;
                    msg.sender = MessageFunctions.user_Server;
                    msg.data = msgData;

                    Socket receiver = sock;
                    receiver.Send(serial.getSerialMsg(msg));
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
