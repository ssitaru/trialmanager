using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudyTranslationManager.entities;

namespace StudyTranslationManager.dialogs
{
    public partial class EditUserDialog : Form
    {
        public User ThisUser;
        private bool PasswordChanged = false;
        private bool AdminChecked = false;

        public EditUserDialog()
        {
            InitializeComponent();

            this.ThisUser = new User();

            this.ActiveControl = textBoxUsername;
        }

        public EditUserDialog(User u)
        {
            InitializeComponent();

            ThisUser = u;

            textBoxUsername.Text = u.Username;
            textBoxName.Text = u.Name;

            foreach(string role in u.Roles)
            {
                GetListViewItemByText(role).Checked = true;
            }
            if(!u.IsNew)
            {
                textBoxUsername.Enabled = false;
                this.ActiveControl = textBoxName;
            }
            else
            {
                this.ActiveControl = textBoxUsername;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxPassword.Text = "";
            textBoxPassword.Font = TextBox.DefaultFont;

            PasswordChanged = true;
        }

        // TODO: Check if username exists!
        private void buttonOK_Click(object sender, EventArgs e)
        {
            List<string> roles = new List<string>();
            foreach(ListViewItem lvi in listViewRoles.CheckedItems)
            {
                roles.Add(lvi.Text);
            }
            ThisUser.Roles = roles.ToArray();

            if(PasswordChanged) ThisUser.Password = Utils.GetSHA1Hash(textBoxPassword.Text);
            try
            {
                ThisUser.UpdateToDb();

            } catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            ThisUser.Username = textBoxUsername.Text;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            ThisUser.Name = textBoxName.Text;
        }

        private void EditUserDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                buttonOK.PerformClick();
            }
        }


        private void SetPasswordNullPrompt()
        {
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Text = "<click to change password>";
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if(textBoxPassword.Text == "")
            {
                SetPasswordNullPrompt();
                PasswordChanged = false;
            }
        }

        private ListViewItem GetListViewItemByText(string text)
        {
            foreach(ListViewItem lvi in listViewRoles.Items)
            {
                if (lvi.Text == text) return lvi;
            }

            return null;
        }

        private void listViewRoles_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(AdminChecked && (listViewRoles.Items[e.Index].Text != "Admin"))
            {
                e.NewValue = CheckState.Checked;
            }

            if(AdminChecked && (listViewRoles.Items[e.Index].Text == "Admin"))
            {
                AdminChecked = false;
            }
            else if(!AdminChecked && (listViewRoles.Items[e.Index].Text == "Admin"))
            {
                AdminChecked = true;
                foreach(ListViewItem lvi in listViewRoles.Items)
                {
                    if (lvi.Text != "Admin") lvi.Checked = true;
                }
            }
        }

        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            EditUserDialog_KeyDown(sender, e);
        }
    }
}
