using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using ChatterDLL;

namespace Chatter
{
    public partial class frmMain : Form
    {
        public static Chat chat;
        public static RichTextBox chatBox;
        public static string username = string.Empty, receiver = string.Empty;
        public static bool isSignedIn = false;


        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            chatBox = chatWindow;

            Forms.LogIn Login = new Forms.LogIn();
            Login.TopMost = true;
            Login.Show();
            lstContacts.SelectedIndex = 0;
        }

        public static void createClient()
        {
            chat = new Chat();
        }

        private void txtChat_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string text = txtChat.Text.Trim();

            if(text != string.Empty && receiver != string.Empty && isSignedIn)
            {
                User rec = new User() {username = receiver};

                ChatterDLL.Message msg = new ChatterDLL.Message() { receiver = rec, data = text, type = ChatterDLL.msgType.chat};
                ChatSender.sendMessage(msg);
                txtChat.Text = string.Empty;
            }

        }

        private void lstContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            receiver = lstContacts.SelectedItem.ToString();
        }
    }
}
