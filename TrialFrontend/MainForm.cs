using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TrialFrontend.dialogs;
using System.Data.SQLite.Linq;
using TrialFrontend.entities;
using System.Data.SQLite;
using TranslationManagerCommon;

namespace TrialFrontend
{
    public partial class MainForm : Form
    {
        private bool LoggedIn = false;
        private User CurrentUser;
        private Dictionary<int, Trial> TrialCache;

        private bool ShowDone = false;
        private bool FilterByBlock = false;
        private TrialBlock FilterBlock;

        public MainForm()
        {
            InitializeComponent();

            TrialCache = new Dictionary<int, Trial>();

            groupBox1.Enabled = false;
            groupBox2.Enabled = false;

            if (Properties.Settings.Default.DbPath != "")
            {
                ConnectDb(Properties.Settings.Default.DbPath);
            }

            if (Program.SqliteConnection == null)
            {
                toolStripStatusLabel.Text = "No database connection!";
            }

            ListViewItemComparer c = new ListViewItemComparer();
            c.Order = System.Windows.Forms.SortOrder.Descending;
            listViewTrials.ListViewItemSorter = c;
            
        }

        private void ConnectDb(string fp)
        {
            try
            {
                Program.SqliteConnection = DbConnection.SQLiteFromFilePath(fp);
                //Program.DatabaseConnection = new DbConnection(Program.SqliteConnection);

                toolStripStatusLabel.Text = "Connected to DB " + Properties.Settings.Default.DbPath;

            }
            catch (Exception ex)
            {
                // handle it
                toolStripStatusLabel.Text = "Error: " + ex.Message;
            }
            finally
            {
                if(LoginUser())
                {
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = true;

                    toolStripStatusLabel.Text = "Logged in as " + CurrentUser.Name + " <" + CurrentUser.Username + ">";
                    UpdateFromDb();
                }
                else
                {
                    toolStripStatusLabel.Text = "Login failed";
                }
                
            }
        }

        private bool LoginUser()
        {
            string user = Properties.Settings.Default.User;
            string pw = Properties.Settings.Default.PasswordHash;
            if((user == "") || (pw == ""))
            {
                LoginDialog ld = new LoginDialog();
                if(ld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CurrentUser = Utils.GetUserByUsername(Properties.Settings.Default.User);
                    LoggedIn = true;
                    return true;
                }
            }
            else
            {
                User u = new User(user);
                if(u.Password == pw)
                {
                    LoggedIn = true;
                    CurrentUser = u;
                    return true;
                }
            }

            return false;
            
        }

        private void UpdateTrialCache()
        {
            TrialCache.Clear();
            foreach(ListViewItem lvi in listViewTrials.Items)
            {
                TrialCache.Add(int.Parse(lvi.SubItems[0].Text), new Trial(int.Parse(lvi.SubItems[0].Text)));
            }
        }

        private bool ShouldIncludeTrial(Trial t, string function)
        {
            bool includedByDone = false, includedByBlock = true;
            bool done = ((function == "Proofreader") && t.Corrected.Completed) || ((function == "Translator") && t.Translated.Completed);
            if (!ShowDone && !done)
            {
                includedByDone = true;
            }
            else if (ShowDone && done)
            {
                includedByDone = true;
            } 
            else if(ShowDone && !done)
            {
                includedByDone = true;
            }
            if(FilterByBlock)
            {
                includedByBlock = false;
                if(t.Block.Id == FilterBlock.Id)
                {
                    includedByBlock = true;
                }
            }

            return includedByBlock && includedByDone;            
        }

        private void UpdateFromDb()
        {
            TrialCache.Clear();
            listViewTrials.Items.Clear();
            if(LoggedIn)
            {
                List<int> trialBlocks = TrialBlock.GetAllTrialBlocksForUid();

                foreach(int blockId in trialBlocks)
                {
                    TrialBlock block = new TrialBlock(blockId);
                    string function;
                    if (block.Proofreader.Username == CurrentUser.Username)
                    {
                        function = "Proofreader";
                    }
                    else if (block.Translator.Username == CurrentUser.Username)
                    {
                        function = "Translator";
                    }
                    else
                    {
                        continue;
                    }
                    for (int i = block.FromId; i <= block.ToId; i++)
                    {
                        Trial t = new Trial(i);
                        if (t.IsNew) t.Block = block;
                        // Filtering
                        if (!ShouldIncludeTrial(t, function)) continue;
                        // ID, Function, Status, File
                        if (!t.IsNew)
                        {
                            TrialCache.Add(i, t);
                            string status = "";
                            if (function == "Translator")
                            {
                                if (t.Translated.Completed)
                                {
                                    status = "done";
                                }
                                else
                                {
                                    status = "seen";
                                }
                            }
                            else if (function == "Proofreader")
                            {
                                if (t.Corrected.Completed)
                                {
                                    status = "done";
                                }
                                else
                                {
                                    status = "seen";
                                }
                            }

                            string[] row = { i.ToString(), function, status, (t.Filepath == null) ? "" : t.Filepath };
                            ListViewItem lvi = new ListViewItem(row);
                            listViewTrials.Items.Add(lvi);
                        }
                        else
                        {
                            string[] row = { i.ToString(), function, "new", "" };
                            ListViewItem lvi = new ListViewItem(row);
                            listViewTrials.Items.Add(lvi);

                            t = new Trial();
                            t.Id = i;
                            t.Block = block;
                            t.IsNew = true;
                            TrialCache.Add(i, t);
                        }
                    }
                }
            }
            listViewTrials.Sort();
            UpdateTrialCount();
        }

        private void ClearDetailView()
        {
            textBoxId.Text = "";
            textBoxBlock.Text = "";
            textBoxFilepath.Text = "";
            textBoxProofreader.Text = "";
            textBoxTranslator.Text = "";
            textBoxDetails.Text = "";

            comboBoxStatus.Text = "";
            
        }

        private void SetDetailView(Trial t, TrialBlock tb)
        {
            StringBuilder detailsText = new StringBuilder();

            if(t.IsNew)
            {
                if(GetFunctionForTrialId(t.Id) == "Translator")
                {
                    // add it to the DB if we're the translator
                    t.Translated = new Milestone(MilestoneType.TRANSLATION);
                    t.Corrected = new Milestone(MilestoneType.CORRECTION);

                    t.UpdateToDb();

                    SetStatusForTrialId(t.Id, "seen");
                }
                else
                {
                    t.BlockId = t.Block.Id;
                }
                
            }

            textBoxId.Text = t.Id.ToString();
            textBoxBlock.Text = "Block #" + t.BlockId.ToString() + " (" + t.Block.FromId.ToString() + "-" + t.Block.ToId.ToString() + ")";
            detailsText.AppendFormat("Assignment last updated {0}\r\n", t.Block.Timestamp.ToString(TranslationManagerCommon.Utils.DATETIME_FORMAT));
            string status = GetStatusForTrialId(t.Id);
            if(status == "seen")
            {
                comboBoxStatus.SelectedIndex = 0;
                comboBoxStatus.Text = "seen";
            } else if(status == "done")
            {
                comboBoxStatus.SelectedIndex = 1;
                comboBoxStatus.Text = "done";
            }



            if (GetFunctionForTrialId(t.Id) == "Proofreader")
            {
                textBoxProofreader.Text = "you";
                textBoxTranslator.Text = t.Block.Translator.Name;
                if(t.IsNew)
                {
                    buttonMarkDone.Enabled = false;
                    buttonAssignFile.Enabled = false;
                    buttonReset.Enabled = false;
                    comboBoxStatus.Enabled = false;
                    comboBoxStatus.Text = "new";

                    detailsText.AppendFormat("Translation awaiting\r\n");
                    detailsText.AppendFormat("Correction awaiting");
                }
                else if(!t.Translated.Completed)
                {
                    buttonMarkDone.Enabled = false;
                    buttonAssignFile.Enabled = false;
                    buttonReset.Enabled = false;
                    comboBoxStatus.Enabled = false;

                    detailsText.AppendFormat("Translation in progress since {0}\r\n", t.Translated.Timestamp.ToShortDateString());
                    detailsText.AppendFormat("Correction awaiting");
                }
                else
                {
                    buttonMarkDone.Enabled = true;
                    buttonAssignFile.Enabled = true;
                    buttonReset.Enabled = true;

                    detailsText.AppendFormat("Translation completed {0}\r\n", t.Translated.Timestamp.ToShortDateString());
                    if(t.Corrected.Completed)
                    {
                        detailsText.AppendFormat("Correction completed {0}\r\n", t.Corrected.Timestamp.ToShortDateString());
                    }
                    else
                    {
                        detailsText.AppendFormat("Correction in progress since {0}\r\n", t.Corrected.Timestamp.ToShortDateString());
                    }
                    
                }
            }
            else if (GetFunctionForTrialId(t.Id) == "Translator")
            {
                textBoxTranslator.Text = "you";
                textBoxProofreader.Text = t.Block.Proofreader.Name;
                if (!t.Translated.Completed)
                {
                    detailsText.AppendFormat("Translation in progress since {0}\r\n", t.Translated.Timestamp.ToShortDateString());
                    detailsText.AppendFormat("Correction awaiting");
                }
                else
                {
                    detailsText.AppendFormat("Translation completed {0}\r\n", t.Translated.Timestamp.ToShortDateString());
                    detailsText.AppendFormat("Correction in progress since {0}", t.Corrected.Timestamp.ToShortDateString());
                }
                
            }
            
            textBoxDetails.Text = detailsText.ToString();
            
            textBoxFilepath.Text = (t.Filepath == null) ? "" : t.Filepath;
        }

        private void SetStatusForTrialId(int id, string status)
        {
            SetCellInTrialTable(id, 2, status);
        }

        private string GetStatusForTrialId(int id)
        {
            return GetCellInTrialTable(id, 2);
        }

        private string GetFunctionForTrialId(int id)
        {
            return GetCellInTrialTable(id, 1);
        }

        private string GetCellInTrialTable(int id, int column)
        {
            ListViewItem lvi = GetListViewItemById(id);
            if (lvi != null)
            {
                return lvi.SubItems[column].Text;
            }
            else 
            {
                return null;
            }
        }

        private void SetCellInTrialTable(int id, int column, string text)
        {
            ListViewItem lvi = GetListViewItemById(id);
            if (lvi != null)
            {
                lvi.SubItems[column].Text = text;
            }
        }

        private void SetDetailView(List<Trial> trials)
        {

        }


        private void changeDBToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string p = Properties.Settings.Default.DbPath;
            if (p != "")
            {
                openDbDialog.InitialDirectory = Path.GetDirectoryName(p);
            }

            if (openDbDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ConnectDb(openDbDialog.FileName);
                Properties.Settings.Default.DbPath = openDbDialog.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateFromDb();
        }

        private void changeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoggedIn = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            toolStripStatusLabel.Text = "Not logged in";
            Properties.Settings.Default.PasswordHash = "";
            Properties.Settings.Default.Save();

            LoginDialog ld = new LoginDialog();
            if (ld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CurrentUser = Utils.GetUserByUsername(Properties.Settings.Default.User);
                LoggedIn = true;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                toolStripStatusLabel.Text = "Logged in as " + CurrentUser.Name + " <" + CurrentUser.Username + ">";
                UpdateFromDb();
            }
            else
            {
                toolStripStatusLabel.Text = "Login failed";
            }

        }

        private void listViewTrials_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if(listViewTrials.SelectedItems.Count == 1)
            {
                buttonAssignFile.Enabled = true;
                buttonMarkDone.Enabled = true;
                buttonReset.Enabled = true;
                comboBoxStatus.Enabled = true;

                UpdateDetailView();
            } else if(listViewTrials.SelectedItems.Count > 1)
            {
                buttonAssignFile.Enabled = false;
                buttonMarkDone.Enabled = true;
                buttonReset.Enabled = true;
                comboBoxStatus.Enabled = true;

                UpdateDetailView();
            }
            else
            {
                buttonAssignFile.Enabled = false;
                buttonMarkDone.Enabled = false;
                buttonReset.Enabled = false;
                comboBoxStatus.Enabled = false;

                ClearDetailView();
            }

            Cursor = Cursors.Default;
        }

        private List<Trial> GetSelectedTrials()
        {
            List<Trial> trials = new List<Trial>();
            foreach (ListViewItem lvi in listViewTrials.SelectedItems)
            {
                trials.Add(TrialCache[int.Parse(listViewTrials.SelectedItems[0].SubItems[0].Text)]);
            }

            return trials;
        }

        private void UpdateTrialCount()
        {
            labelNTrials.Text = listViewTrials.Items.Count.ToString() + " Trials";
        }

        private ListViewItem GetListViewItemById(int id)
        {
            foreach(ListViewItem lvi in listViewTrials.Items)
            {
                if(lvi.SubItems[0].Text == id.ToString())
                {
                    return lvi;
                }
            }

            return null;
        }

        private void linkLabelOpenFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(textBoxFilepath.Text.Count() > 1)
            {
                System.Diagnostics.Process.Start(textBoxFilepath.Text);
            }
        }

        private void buttonAssignFile_Click(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.LastAssignFilepath != "")
            {
                assignFileDialog.InitialDirectory = Properties.Settings.Default.LastAssignFilepath;
            }
            if(assignFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Trial t = TrialCache[int.Parse(textBoxId.Text)];
                t.Filepath = textBoxFilepath.Text = assignFileDialog.FileName;

                t.UpdateToDb();

                Properties.Settings.Default.LastAssignFilepath = Path.GetDirectoryName(assignFileDialog.FileName);
                Properties.Settings.Default.Save();
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Trial t = null;
            foreach(ListViewItem lvi in listViewTrials.SelectedItems)
            {
                t = new Trial(int.Parse(lvi.SubItems[0].Text));
                t.Filepath = null;
                if(lvi.SubItems[1].Text == "Translator")
                {
                    t.Translated = new Milestone(MilestoneType.TRANSLATION, false, DateTime.Now);
                    t.Corrected = new Milestone(MilestoneType.CORRECTION, false, DateTime.Now);
                }
                else if (lvi.SubItems[1].Text == "Proofreader")
                {
                    t.Corrected = new Milestone(MilestoneType.CORRECTION, false, DateTime.Now);
                }

                SetStatusForTrialId(t.Id, "seen");

                t.UpdateToDb();

                UpdateTrialCache();
            }

            UpdateDetailView();
        }

        private void buttonMarkDone_Click(object sender, EventArgs e)
        {
            Trial t = null;
            foreach (ListViewItem lvi in listViewTrials.SelectedItems)
            {
                t = new Trial(int.Parse(lvi.SubItems[0].Text));
                if (lvi.SubItems[1].Text == "Translator")
                {
                    t.Translated = new Milestone(MilestoneType.TRANSLATION, true, DateTime.Now);
                    t.Corrected = new Milestone(MilestoneType.CORRECTION, false, DateTime.Now);
                }
                else if (lvi.SubItems[1].Text == "Proofreader")
                {
                    t.Corrected = new Milestone(MilestoneType.CORRECTION, true, DateTime.Now);
                }

                SetStatusForTrialId(t.Id, "done");

                t.UpdateToDb();

                UpdateTrialCache();
            }

            UpdateDetailView();
        }

        private void UpdateDetailView()
        {
            if (listViewTrials.SelectedItems.Count == 1)
            {
                Trial t = TrialCache[int.Parse(listViewTrials.SelectedItems[0].SubItems[0].Text)];
                SetDetailView(t, t.Block);
            }
            else if (listViewTrials.SelectedItems.Count > 1)
            {
                SetDetailView(GetSelectedTrials());
            }

            listViewTrials.Focus();
        }

        private void checkBoxShowDone_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            this.ShowDone = checkBoxShowDone.Checked;

            UpdateFromDb();

            if((listViewTrials.SelectedItems.Count > 1) && (TrialCache[int.Parse(textBoxId.Text)] != null))
            {
                foreach(ListViewItem lvi in listViewTrials.Items)
                {
                    if (lvi.SubItems[0].Text == textBoxId.Text)
                        lvi.Selected = true;
                        lvi.Focused = true;
                }
            }

            Cursor = Cursors.Default;
        }

        private void checkBoxFilterByBlock_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxBlockFilter.Enabled = checkBoxFilterByBlock.Checked;
            FilterByBlock = checkBoxFilterByBlock.Checked;

            if(checkBoxFilterByBlock.Checked)
            {
                comboBoxBlockFilter.Items.Clear();
                foreach(int tb in TrialBlock.GetAllTrialBlocksForUid(CurrentUser.Username))
                {
                    comboBoxBlockFilter.Items.Add(new TrialBlock(tb));
                }
                comboBoxBlockFilter.SelectedIndex = 0;
                FilterBlock = (TrialBlock)comboBoxBlockFilter.Items[0];
            }

            UpdateFromDb();
        }

        private void comboBoxBlockFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterBlock = (TrialBlock)comboBoxBlockFilter.SelectedItem;
            UpdateFromDb();
        }
    }
}
