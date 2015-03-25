using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrialFrontend.entities;

namespace TrialFrontend.dialogs
{
    public partial class LoginDialog : Form
    {
        public LoginDialog()
        {
            InitializeComponent();

            textBoxPassword.UseSystemPasswordChar = true;

            if(Properties.Settings.Default.User != "")
            {
                textBoxUsername.Text = Properties.Settings.Default.User;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            User u = Utils.GetUserByUsername(textBoxUsername.Text);

            if(u == null)
            {
                LoginFailed();
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            if(!Utils.CheckSHA1Hash(textBoxPassword.Text, u.Password))
            {
                LoginFailed();
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            Properties.Settings.Default.User = textBoxUsername.Text;
            Properties.Settings.Default.PasswordHash = Utils.GetSHA1Hash(textBoxPassword.Text);
            Properties.Settings.Default.Save();
        }

        private void LoginFailed(string msg = "")
        {
            MessageBox.Show("Login Failed", "Check username/password!\r\n"+msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LoginDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                buttonOK.PerformClick();
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            LoginDialog_KeyDown(sender, e);
        }
    }
}
