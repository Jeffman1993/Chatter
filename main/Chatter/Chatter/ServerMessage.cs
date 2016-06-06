using System;
using ChatterDLL;

namespace Chatter
{
    public static class ServerMessage
    {
        public static void handleMessage(Message msg)
        {

            switch (msg.servResponse)
            {
                case serverResponse.loginFail:
                    frmMain.isSignedIn = false;
                    Chat.addText(msg.data);
                    break;

                case serverResponse.loginSucess:
                    frmMain.isSignedIn = true;
                    Chat.addText(msg.data);
                    break;
            }
        }
    }
}