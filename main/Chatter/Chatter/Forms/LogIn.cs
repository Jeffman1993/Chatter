using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatter.Forms
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbUsername.SelectedItem != null && cmbIP.SelectedItem != null)
                if(cmbUsername.SelectedItem.ToString() != string.Empty)
                {
                    Chatter.frmMain.username = cmbUsername.SelectedItem.ToString();
                    Chatter.ServerConnect.serverIP = IPAddress.Parse(cmbIP.SelectedItem.ToString());
                    Chatter.frmMain.createClient();
                    this.Close();
                }

        }
    }
}
