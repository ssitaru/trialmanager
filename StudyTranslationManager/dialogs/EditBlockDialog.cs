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
using System.Data.SQLite;

namespace StudyTranslationManager.dialogs
{
    public partial class EditBlockDialog : Form
    {
        public TrialBlock ThisBlock;
        public bool IsNewBlock = false;

        private Dictionary<User, int> UserToComboboxIndex;

        public EditBlockDialog()
        {
            InitializeComponent();
            ThisBlock = new TrialBlock();
            UserToComboboxIndex = new Dictionary<User, int>();

            FillUsernames();

            IsNewBlock = true;

            comboBoxTranslator.SelectedIndex = 0;
            comboBoxProofreader.SelectedIndex = 0;

            maskedTextBoxFromId.Focus();

            if(Properties.Settings.Default.EditBlockDialog_LastSelectedProofreader != "")
            {
                comboBoxProofreader.SelectedItem = GetPComboboxItemForUsername(Properties.Settings.Default.EditBlockDialog_LastSelectedProofreader);
            }

            if (Properties.Settings.Default.EditBlockDialog_LastSelectedTranslator != "")
            {
                comboBoxTranslator.SelectedItem = GetTComboboxItemForUsername(Properties.Settings.Default.EditBlockDialog_LastSelectedTranslator);
            }

            this.ActiveControl = maskedTextBoxFromId;
        }

        public EditBlockDialog(TrialBlock t)
        {
            ThisBlock = t;
            UserToComboboxIndex = new Dictionary<User, int>();

            InitializeComponent();
            FillUsernames();

            textBoxId.Text = t.Id.ToString();
            maskedTextBoxFromId.Text = t.FromId.ToString();
            maskedTextBoxToId.Text = t.ToId.ToString();
            textBoxNotes.Text = t.Notes;

            comboBoxTranslator.SelectedItem = GetTComboboxItemForUsername(t.Translator.Username);
            comboBoxProofreader.SelectedItem = GetPComboboxItemForUsername(t.Proofreader.Username);

            if(t.Done > 0)
            {
                checkBoxDone.Checked = true;
            }

            UpdateTrialCount();

            this.ActiveControl = maskedTextBoxFromId;
        }

        // TODO: Check for overlap with other blocks (fromId/toId is between other blocks' from-to)
        private void buttonOK_Click(object sender, EventArgs e)
        {
            TrialBlock overlapCheck = CheckPlausibility();
            if(overlapCheck != null)
            {
                MessageBox.Show("Overlap check failed, please correct FromId/ToId (conflicts with TrialBlock " + overlapCheck.Id.ToString() + ": " + overlapCheck.FromId.ToString() + "-" + overlapCheck.ToId.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            ThisBlock.Timestamp = DateTime.Now;

            try
            {
                ThisBlock.UpdateToDb();
            } 
            catch(SQLiteException ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = System.Windows.Forms.DialogResult.None;
                
            }

            Properties.Settings.Default.EditBlockDialog_LastSelectedTranslator = ((User)comboBoxTranslator.SelectedItem).Username;
            Properties.Settings.Default.EditBlockDialog_LastSelectedProofreader = ((User)comboBoxProofreader.SelectedItem).Username;
            Properties.Settings.Default.Save();
        }

        private void maskedTextBoxFromId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ThisBlock.FromId = int.Parse(maskedTextBoxFromId.Text);
            } catch (Exception ex)
            {

            }
            
        }

        private void FillUsernames()
        {
            var users = User.GetAllUsers();

            foreach(User u in users)
            {
                if(u.Roles.Contains("Translator")) comboBoxTranslator.Items.Add(u);
                if(u.Roles.Contains("Proofreader")) comboBoxProofreader.Items.Add(u);
            }
        }

        private object GetPComboboxItemForUsername(string uid)
        {
            foreach(object o in comboBoxProofreader.Items)
            {
                if (((User)o).Username == uid) return o;
            }

            return null;
        }
        /// <summary>
        /// Get the object in the Translator ComboBox for a given username
        /// </summary>
        /// <param name="uid">Username</param>
        /// <returns>found object or null</returns>
        private object GetTComboboxItemForUsername(string uid)
        {
            foreach (object o in comboBoxTranslator.Items)
            {
                if (((User)o).Username == uid) return o;
            }

            return null;
        }

        private void UpdateTrialCount()
        {
            int from = int.Parse(maskedTextBoxFromId.Text);
            int to = int.Parse(maskedTextBoxToId.Text);

            labelNTrials.Text = (to - from + 1).ToString() + " Trials";
            labelNTrials.Visible = true;
        }

        private void maskedTextBoxToId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ThisBlock.ToId = int.Parse(maskedTextBoxToId.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void maskedTextBoxToId_Leave(object sender, EventArgs e)
        {
            UpdateTrialCount();
        }

        private void textBoxNotes_TextChanged(object sender, EventArgs e)
        {
            ThisBlock.Notes = textBoxNotes.Text;
        }

        private void comboBoxTranslator_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTranslator.SelectedItem != null)
            {
                ThisBlock.Translator = (User)comboBoxTranslator.SelectedItem;
            }
            
        }

        private void comboBoxProofreader_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProofreader.SelectedItem != null)
            {
                ThisBlock.Proofreader = (User)comboBoxProofreader.SelectedItem;
            }
        }

        private void checkBoxDone_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxDone.Checked)
            {
                ThisBlock.Done = 1;
            }
            else
            {
                ThisBlock.Done = 0;
            }
        }

        private TrialBlock CheckPlausibility()
        {
            TrialBlock ret = null;

            foreach(TrialBlock t in TrialBlock.GetAllTrialBlocks())
            {
                if (t.Id == ThisBlock.Id) continue;

                if((ThisBlock.FromId <= t.ToId) && (ThisBlock.FromId >= t.FromId))
                {
                    ret = t;
                }

                if ((ThisBlock.ToId <= t.ToId) && (ThisBlock.ToId >= t.FromId))
                {
                    ret = t;
                }
            }

            return ret;
        }

        private void EditBlockDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                buttonOK.PerformClick();
            }
        }
    }
}
