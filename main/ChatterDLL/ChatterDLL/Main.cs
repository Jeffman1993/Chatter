using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ChatterDLL
{

    [Serializable]
    public class User
    {
        public User() { }

        public string username;
    }

    [Serializable]
    public class Message
    {
        public long messageId;
        public msgType type = msgType.none;
        public serverResponse servResponse = serverResponse.none;
        public User sender = null, receiver = null;
        public DateTime timestamp = DateTime.Now;
        public string data = string.Empty;
    }

    [Serializable]
    public enum msgType
    {
        none, login, chat, picture, server
    }

    [Serializable]
    public enum serverResponse
    {
        none, error, loginFail, loginSucess
    }



    public static class serial
    {
        public static byte[] getSerialMsg(Message msg)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();

            byte[] bMsg;

            try
            {
                bf.Serialize(ms, msg);
                bMsg = new byte[ms.Length];

                ms.Position = 0;
                ms.Read(bMsg, 0, bMsg.Length);
                ms.Close();

                return bMsg;
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Could not serialize: " + e.Message);
                ms.Close();
                return null;
            }
        }

        public static Message unserialMsg(byte[] _buffer)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            Message msg = null;

            try
            {
                ms.Write(_buffer, 0, _buffer.Length);
                ms.Position = 0;

                msg = (Message)bf.Deserialize(ms);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ms.Close();
            }
            return msg;
        }
    }
}
