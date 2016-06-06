using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ChatterDLL;
using System.Windows.Forms;

namespace Chatter
{
    public class Chat
    {
        public static User localUser = new User() {username = frmMain.username}, lastChatUser = new User();
        public static bool isLocal = false;

        public Chat()
        {
            ServerConnect.attempLogin(localUser);
        }


        public static void addText(string msg)
        {
            frmMain.chatBox.Invoke((MethodInvoker)delegate () { frmMain.chatBox.Text += msg + "\n"; });
        }

        public static void addMessage(ChatterDLL.Message msg)
        {
            string chatMessage = string.Empty;

            //Same user.
            if ((lastChatUser.username == msg.sender.username && lastChatUser.username != string.Empty && msg.data[0].ToString() != "/") || msg.sender.username.ToLower() == "server")
            {
                chatMessage = msg.sender.username + ": " + msg.data + "\n";
            }
            //Different user.
            else if (msg.data[0].ToString() != "/")
            {
                chatMessage = "\n" + msg.sender.username + ": " + msg.data + "\n";
            }
            else
                return;

            lastChatUser = msg.sender;

            frmMain.chatBox.Invoke((MethodInvoker)delegate () { frmMain.chatBox.Text += chatMessage; });
            frmMain.chatBox.Invoke((MethodInvoker)delegate () { frmMain.chatBox.SelectionStart = frmMain.chatBox.Text.Length; });
            frmMain.chatBox.Invoke((MethodInvoker)delegate () { frmMain.chatBox.ScrollToCaret(); });
        }

        public static void clear()
        {
            frmMain.chatBox.Text = string.Empty;
        }
    }
}
