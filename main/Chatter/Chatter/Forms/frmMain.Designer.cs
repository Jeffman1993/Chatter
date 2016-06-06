namespace Chatter
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSend = new System.Windows.Forms.Button();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.lstContacts = new System.Windows.Forms.ListBox();
            this.chatWindow = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSend.Location = new System.Drawing.Point(0, 408);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(614, 30);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtChat
            // 
            this.txtChat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtChat.Location = new System.Drawing.Point(0, 388);
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(614, 20);
            this.txtChat.TabIndex = 3;
            this.txtChat.TextChanged += new System.EventHandler(this.txtChat_TextChanged);
            // 
            // lstContacts
            // 
            this.lstContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstContacts.FormattingEnabled = true;
            this.lstContacts.Items.AddRange(new object[] {
            "Jeffman",
            "RillyBoyz",
            "Yon"});
            this.lstContacts.Location = new System.Drawing.Point(449, 1);
            this.lstContacts.Name = "lstContacts";
            this.lstContacts.Size = new System.Drawing.Size(165, 277);
            this.lstContacts.TabIndex = 4;
            this.lstContacts.SelectedIndexChanged += new System.EventHandler(this.lstContacts_SelectedIndexChanged);
            // 
            // chatWindow
            // 
            this.chatWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chatWindow.Location = new System.Drawing.Point(0, 0);
            this.chatWindow.Name = "chatWindow";
            this.chatWindow.ReadOnly = true;
            this.chatWindow.Size = new System.Drawing.Size(293, 388);
            this.chatWindow.TabIndex = 5;
            this.chatWindow.Text = "";
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 438);
            this.Controls.Add(this.chatWindow);
            this.Controls.Add(this.lstContacts);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.btnSend);
            this.Name = "frmMain";
            this.Text = "Epyks Chat";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.ListBox lstContacts;
        private System.Windows.Forms.RichTextBox chatWindow;
    }
}

