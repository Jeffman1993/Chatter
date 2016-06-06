using ChatterDLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Chatter
{
    public static class ChatSender
    {
        public static void sendMessage(Message msg)
        {
            byte[] bMsg = null;

            msg.sender = Chat.localUser;

            bMsg = serial.getSerialMsg(msg);

            if (bMsg != null)
                try
                {
                    ServerConnect._serverSocket.Send(bMsg);

                    if (msg.type == msgType.chat)
                        Chat.addMessage(msg);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
        }
    }
}
