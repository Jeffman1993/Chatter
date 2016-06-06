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
    public class SerialTest
    {

        public static void test()
        {
            User fred = new User { username = "Papa Franku" };

            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            Byte[] bFred = null;

            try
            {
                bf.Serialize(ms, fred);
                fred = null;
                bFred = new byte[ms.Length];

                ms.Position = 0;
                ms.Read(bFred, 0, bFred.Length);
            }
            catch(SerializationException e)
            {
                Console.WriteLine("Could not serialize: " + e.Message);
            }
            finally
            {
                ms.Close();
            }

            //Deser
            User newFred = null;

            try
            {
                BinaryFormatter bff = new BinaryFormatter();
                MemoryStream mss = new MemoryStream();

                mss.Write(bFred, 0, bFred.Length);
                mss.Position = 0;

                newFred = (User)bff.Deserialize(mss);
            }
            catch(SerializationException e)
            {
                Console.WriteLine(e.Message);
            }

            frmMain.chatBox.Text = newFred.username + " has joined the chat.";
        }
    }
}
