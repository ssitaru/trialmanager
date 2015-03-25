using StudyTranslationManager.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudyTranslationManager.dialogs;
using System.Text.RegularExpressions;

namespace StudyTranslationManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            TrialCache = new Dictionary<int, Trial>();

            if (Properties.Settings.Default.DbPath != "")
            {
                ConnectDb(Properties.Settings.Default.DbPath);
                
            }

            if(Program.SqliteConnection == null)
            {
                toolStripStatusLabel.Text = "No database connection!";
            }
        }
        #region DB Actions
        private void changeDbToolStripMenuItem_Click(object sender, EventArgs e)
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

        private bool ConnectDb(string fp)
        {
            try
            {
                Program.SqliteConnection = DbConnection.SQLiteFromFilePath(fp);

                toolStripStatusLabel.Text = "Connected to DB " + fp;

                UpdateBlockViewFromDb();

                return true;
            }
            catch (Exception ex)
            {
                // handle it
                toolStripStatusLabel.Text = "Error: " + ex.Message;

                return false;
            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewTrials.SelectedItems.Count == 1)
            {
                GetSelectedTrials().First().UpdateToDb();
            }

            if (saveDbDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Program.SqliteConnection.Close();

                ConnectDb(saveDbDialog.FileName);

                tabControl.SelectedIndex = 0;

                UpdateBlockViewFromDb();

                Properties.Settings.Default.DbPath = saveDbDialog.FileName;
                Properties.Settings.Default.Save();
            }

        }
        #endregion
        #region Block View
        private bool ShowDone_BlockView = false;
        private bool FilterByUser_BlockView = false;
        private User FilterUser_BlockView;

        private void checkBoxFilterUser_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxUserFilter.Enabled = checkBoxFilterUser.Checked;
            FilterByUser_BlockView = comboBoxUserFilter.Enabled;

            if(checkBoxFilterUser.Checked)
            {
                FillUsernames();

                comboBoxUserFilter.SelectedIndex = 0;
            }

            UpdateBlockViewFromDb();
        }


        private void UpdateBlockViewFromDb()
        {
            if (!CheckDbConnection()) return;
            
            // update users table
            var users = User.GetAllUsers();
            listViewUsers.Items.Clear();

            foreach(var user in users)
            {
                string[] item = { user.Username, user.Name, String.Join(", ", user.Roles) };
                listViewUsers.Items.Add(new ListViewItem(item));
            }

            // update trials table
            var trials = TrialBlock.GetAllTrialBlocks();
            listViewTrialBlocks.Items.Clear();

            foreach(var trialblock in trials)
            {
                bool includedByDone = false;
                bool includedByUser = false;
                string[] item = { trialblock.Id.ToString(), trialblock.FromId.ToString(), trialblock.ToId.ToString(), trialblock.Translator.Name, trialblock.Proofreader.Name, trialblock.Timestamp.ToString(TranslationManagerCommon.Utils.DATETIME_FORMAT), (trialblock.Done > 0) ? "yes" : "no" };
                if (ShowDone_BlockView && (trialblock.Done > 0))
                {
                    includedByDone = true;
                } 
                else if(!ShowDone_BlockView && (trialblock.Done == 0))
                {
                    includedByDone = true;
                }
                else if (ShowDone_BlockView && (trialblock.Done == 0))
                {
                    includedByDone = true;
                }

                if(FilterByUser_BlockView)
                {
                    if ((FilterUser_BlockView.Username == trialblock.Proofreader.Username) || (FilterUser_BlockView.Username == trialblock.Translator.Username)) 
                    {
                        includedByUser = true;
                    } else {
                        includedByUser = false;
                    }
                }
                else
                {
                    includedByUser = true;
                }

                if (includedByUser && includedByDone) listViewTrialBlocks.Items.Add(new ListViewItem(item));
                
            }
        }

        private bool CheckDbConnection()
        {
            if(Program.SqliteConnection != null)
            {
                return true;
            } else {
                return false;
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateBlockViewFromDb();
        }

        private void buttonNewUser_Click(object sender, EventArgs e)
        {
            EditUserDialog ed = new EditUserDialog();

            if(ed.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UpdateBlockViewFromDb();
            }
        }

        private void buttonEditUser_Click(object sender, EventArgs e)
        {
            if(listViewUsers.SelectedItems.Count == 1)
            {
                User selectedUser = Utils.GetUserByUsername(listViewUsers.SelectedItems[0].SubItems[0].Text);

                EditUserDialog ed = new EditUserDialog(selectedUser);

                if (ed.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    UpdateBlockViewFromDb();
                }
            }
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            if(listViewUsers.SelectedItems.Count == 1)
            {
                User selectedUser = Utils.GetUserByUsername(listViewUsers.SelectedItems[0].SubItems[0].Text);

                selectedUser.Delete();

                UpdateBlockViewFromDb();
            }
            
        }

        

        private void buttonNewBlock_Click(object sender, EventArgs e)
        {
            EditBlockDialog ed = new EditBlockDialog();

            if (ed.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UpdateBlockViewFromDb();
            }
        }

        private void buttonEditBlock_Click(object sender, EventArgs e)
        {
            if (listViewTrialBlocks.SelectedItems.Count == 1)
            {
                TrialBlock selectedBlock = GetBlockById(int.Parse(listViewTrialBlocks.SelectedItems[0].SubItems[0].Text));

                EditBlockDialog ed = new EditBlockDialog(selectedBlock);

                if (ed.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    UpdateBlockViewFromDb();
                }
            }
        }

        private void buttonTrialDelete_Click(object sender, EventArgs e)
        {
            if (listViewTrialBlocks.SelectedItems.Count == 1)
            {
                TrialBlock selectedBlock = GetBlockById(int.Parse(listViewTrialBlocks.SelectedItems[0].SubItems[0].Text));

                selectedBlock.Delete();

                UpdateBlockViewFromDb();
            }
        }

        private void checkBoxShowDone_CheckedChanged(object sender, EventArgs e)
        {
            ShowDone_BlockView = checkBoxShowDone.Checked;

            UpdateBlockViewFromDb();
        }

        private void FillUsernames()
        {
            comboBoxUserFilter.Items.Clear();
            var users = User.GetAllUsers();

            foreach (User u in users)
            {
                comboBoxUserFilter.Items.Add(u);
            }
        }

        private void comboBoxUserFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterByUser_BlockView = true;
            FilterUser_BlockView = (User)comboBoxUserFilter.SelectedItem;

            UpdateBlockViewFromDb();
        }

        private void buttonBlockInfo_Click_1(object sender, EventArgs e)
        {
            if (listViewTrialBlocks.SelectedItems.Count == 1)
            {
                TrialBlock selectedBlock = GetBlockById(int.Parse(listViewTrialBlocks.SelectedItems[0].SubItems[0].Text));

                TrialBlockInfo tbi = new TrialBlockInfo(selectedBlock);
                tbi.ShowDialog();
            }
            
        }
        private void buttonNewSingle_Click(object sender, EventArgs e)
        {
            EditSingleBlockDialog esb = new EditSingleBlockDialog();
            if (esb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UpdateBlockViewFromDb();
            }
        }
        #endregion
        #region Utils
        private TrialBlock GetBlockById(int id)
        {
            var selectedBlock = from block in TrialBlock.GetAllTrialBlocks().AsQueryable()
                                where block.Id == id
                                select block;

            return selectedBlock.First();
        }
        #endregion


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl.SelectedIndex == 1) // Trial View
            {
                UpdateTrialListView();
                if(listViewTrials.Items.Count == 0)
                {
                    ClearDetailView();
                }
            } 
            else if(tabControl.SelectedIndex == 0) // Block/User View
            {
                listViewTrialBlocks.Focus();
            }
        }
        #region Trial View
        private bool ShowAllTrials_TrialView = false;
        private bool ShowOnlyTranslated_TrialView = false;
        private bool ShowOnlyCorrected_TrialView = false;

        private Dictionary<int, Trial> TrialCache;
        private void UpdateTrialListView()
        {
            TrialCache.Clear();
            listViewTrials.Items.Clear();
            listViewTrials.Focus();

            IQueryable<Trial> trials;
            int fromId, toId = 0;

            if(listViewTrialBlocks.SelectedItems.Count == 1)
            {
                TrialBlock tb = GetBlockById(int.Parse(listViewTrialBlocks.SelectedItems[0].SubItems[0].Text));
                trials = from trial in Trial.GetAllTrials().AsQueryable()
                                           where trial.BlockId == tb.Id
                                           select trial;

                fromId = tb.FromId;
                toId = tb.ToId;
                AddTrialsForTrialBlock(tb, trials);
            } 
            else if(listViewTrialBlocks.SelectedItems.Count > 1)
            {
                IQueryable<Trial> allTrials = Trial.GetAllTrials().AsQueryable();
                foreach(ListViewItem lvi in listViewTrialBlocks.SelectedItems)
                {
                    TrialBlock tb = GetBlockById(int.Parse(lvi.SubItems[0].Text));
                    trials = from trial in allTrials
                             where trial.BlockId == tb.Id
                             select trial;

                    fromId = tb.FromId;
                    toId = tb.ToId;
                    AddTrialsForTrialBlock(tb, trials);
                }
            }
            
            if (ShowAllTrials_TrialView)
            {
                TrialCache.Clear();
                listViewTrials.Items.Clear();
                trials = Trial.GetAllTrials().AsQueryable();
                foreach (var tb in TrialBlock.GetAllTrialBlocks())
                {
                    AddTrialsForTrialBlock(tb, trials);
                }

            }
                
            


            if (textBoxID.Text.Length > 0)
            {
                foreach (ListViewItem lvi in listViewTrials.Items)
                {
                    if (lvi.SubItems[0].Text == textBoxID.Text)
                    {
                        lvi.Selected = true;
                        lvi.Focused = true;
                    }
                    else
                    {
                        lvi.Selected = false;
                        lvi.Focused = false;
                    }

                }
            }
        }

        private bool ShouldIncludeTrial(Trial t)
        {
            // !ShowOnlyCorrected && !ShowOnlyTranslated -> true
            if (!ShowOnlyTranslated_TrialView && !ShowOnlyCorrected_TrialView) return true;

            // ShowOnlyTranslated && t.Translated.Completed -> true
            // ShowOnlyTranslated && !t.Translated.Completed -> false
            if (ShowOnlyTranslated_TrialView && t.Translated.Completed) return true;

            // ShowOnlyCorrected && t.Corrected.Completed -> true
            // ShowOnlyCorrected && t.Corrected.Completed -> false
            if (ShowOnlyCorrected_TrialView && t.Corrected.Completed) return true;

            return false;
        }

        private void AddTrialsForTrialBlock(TrialBlock tb, IQueryable<Trial> trials)
        {
            ListViewItem lvi;

            for (int i = tb.FromId; i <= tb.ToId; i++)
            {
                Trial tTrial = new Trial(i);
                // Filtering
                if (!ShouldIncludeTrial(tTrial)) continue;
                if (!tTrial.IsNew)
                {
                    string corrected = ((tTrial.Corrected.Completed) ? "done" : "wip") + " (" + tTrial.Block.Proofreader.Username + ")";
                    string translated = ((tTrial.Translated.Completed) ? "done" : "wip") + " (" + tTrial.Block.Translator.Username + ")";
                    string[] row = { tTrial.Id.ToString(), translated, corrected, tTrial.Filepath };
                    lvi = new ListViewItem(row);
                }
                else
                {
                    tTrial.Id = i;
                    tTrial.Block = tb;
                    tTrial.Translated = new Milestone(MilestoneType.TRANSLATION);
                    tTrial.Corrected = new Milestone(MilestoneType.CORRECTION);
                    string[] row = { i.ToString(), "<not seen>", "<not seen>", "" };
                    lvi = new ListViewItem(row);
                }

                listViewTrials.Items.Add(lvi);
                TrialCache.Add(i, tTrial);
            }
        }

        private void listViewTrials_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDetail_TrialView();
        }

        private void UpdateDetail_TrialView()
        {
            if(listViewTrials.SelectedItems.Count == 1)
            {
                Trial t = GetSelectedTrials().First();
                textBoxID.Text = t.Id.ToString();
                textBoxBlockInfo.Text = "#" + t.Block.Id.ToString() + " (assigned " + t.Block.Timestamp.ToString(TranslationManagerCommon.Utils.DATETIME_FORMAT) + ")";
                textBoxTranslator.Text = t.Block.Translator.Name + " (" + t.Block.Translator.Username + ")";
                textBoxProofreader.Text = t.Block.Proofreader.Name + " (" + t.Block.Proofreader.Username + ")";
                if(t.IsNew)
                {
                    textBoxTranslationStatus.Text = "<not seen>";
                    textBoxCorrectionStatus.Text = "<not seen>";
                    // disable everything but "Mark seen"
                    textBoxNotes.Enabled = false;

                    buttonAssignFile.Enabled = false;
                    buttonAutoRename.Enabled = false;
                    buttonMarkCorrected.Enabled = false;
                    buttonMarkTranslated.Enabled = false;
                    buttonMoveFile.Enabled = false;
                    buttonResetStatus.Enabled = false;

                    buttonMarkSeen.Enabled = true;
                }
                else
                {
                    textBoxNotes.Enabled = true;

                    buttonAssignFile.Enabled = true;
                    buttonAutoRename.Enabled = true;
                    buttonMarkCorrected.Enabled = true;
                    buttonMarkTranslated.Enabled = true;
                    buttonMoveFile.Enabled = true;
                    buttonResetStatus.Enabled = true;

                    buttonMarkSeen.Enabled = false;

                    textBoxTranslationStatus.Text = ((t.Translated.Completed) ? "done" : "in progress") + " (" + t.Translated.Timestamp.ToString(TranslationManagerCommon.Utils.DATETIME_FORMAT) + ")";
                    textBoxCorrectionStatus.Text = ((t.Corrected.Completed) ? "done" : "in progress") + " (" + t.Corrected.Timestamp.ToString(TranslationManagerCommon.Utils.DATETIME_FORMAT) + ")";
                }
                if (t.Filepath == null || t.Filepath == "")
                {
                    textBoxFilepath.Text = "";
                    buttonAutoRename.Enabled = false;
                    buttonMoveFile.Enabled = false;
                } else {
                    textBoxFilepath.Text = t.Filepath;
                }
                
                textBoxNotes.Text = (t.Notes == null) ? "" : t.Notes;

            }
            else if(listViewTrials.SelectedItems.Count > 1)
            {
                ClearDetailView();

                List<Trial> selectedTrials = GetSelectedTrials();
                List<string> ids = new List<string>();
                List<string> blockIds = new List<string>();
                bool allTrialsSeen = true;
                int numTrialsCorrected = 0;
                int numTrialsTranslated = 0;

                foreach(Trial t in selectedTrials)
                {
                    ids.Add(t.Id.ToString());
                    if(!blockIds.Contains(t.Block.Id.ToString()))
                        blockIds.Add(t.Block.Id.ToString());
                    if (t.IsNew) allTrialsSeen = false;

                    if (t.Corrected.Completed) numTrialsCorrected++;
                    if (t.Translated.Completed) numTrialsTranslated++;
                }

                if(allTrialsSeen)
                {
                    buttonAssignFile.Enabled = false;
                    buttonAutoRename.Enabled = true;
                    buttonMarkCorrected.Enabled = true;
                    buttonMarkTranslated.Enabled = true;
                    buttonMoveFile.Enabled = false;
                    buttonResetStatus.Enabled = true;

                    buttonMarkSeen.Enabled = false;
                }
                else
                {
                    buttonAssignFile.Enabled = false;
                    buttonAutoRename.Enabled = false;
                    buttonMarkCorrected.Enabled = false;
                    buttonMarkTranslated.Enabled = false;
                    buttonMoveFile.Enabled = false;
                    buttonResetStatus.Enabled = true;

                    buttonMarkSeen.Enabled = true;
                }

                textBoxID.Text = string.Join(", ", ids.ToArray());
                textBoxBlockInfo.Text = string.Join(", ", blockIds.ToArray());
                textBoxTranslator.Text = "<multiple trials>";
                textBoxProofreader.Text = "<multiple trials>";
                textBoxTranslationStatus.Text = numTrialsTranslated.ToString() + " done";
                textBoxCorrectionStatus.Text = numTrialsCorrected.ToString() + " done";
                textBoxFilepath.Text = "<multiple trials>";
                textBoxNotes.Text = "<multiple trials>";


            }
            else
            {
                ClearDetailView();
            }
        }

        private void ClearDetailView()
        {
            textBoxNotes.Enabled = false;

            buttonAssignFile.Enabled = false;
            buttonAutoRename.Enabled = false;
            buttonMarkCorrected.Enabled = false;
            buttonMarkTranslated.Enabled = false;
            buttonMoveFile.Enabled = false;
            buttonResetStatus.Enabled = false;

            buttonMarkSeen.Enabled = false;

            textBoxID.Text = "";
            textBoxBlockInfo.Text = "";
            textBoxTranslator.Text = "";
            textBoxProofreader.Text = "";
            textBoxTranslationStatus.Text = "";
            textBoxCorrectionStatus.Text = "";
            textBoxFilepath.Text = "";
            textBoxNotes.Text = "";
        }

        private List<Trial> GetSelectedTrials()
        {
            List<Trial> ret = new List<Trial>();
            foreach (ListViewItem lvi in listViewTrials.SelectedItems)
            {
                ret.Add(TrialCache[int.Parse(lvi.SubItems[0].Text)]);
            }

            return ret;
        }

        

        private void textBoxNotes_TextChanged(object sender, EventArgs e)
        {
            if (listViewTrials.SelectedItems.Count == 1)
            {
                Trial t = GetSelectedTrials().First();
                t.Notes = textBoxNotes.Text;
            }
        }

        private void buttonResetTranslationMilestone_Click(object sender, EventArgs e)
        {
            foreach(Trial t in GetSelectedTrials())
            {
                t.Translated = new Milestone(MilestoneType.TRANSLATION);
                t.Corrected = new Milestone(MilestoneType.CORRECTION);

                t.UpdateToDb();
            }

            UpdateDetail_TrialView();

            UpdateTrialListView();

            TrySelectItemsInTrialListViewFromDetail();
        }

        private void textBoxNotes_Leave(object sender, EventArgs e)
        {
            if (listViewTrials.SelectedItems.Count == 1)
            {
                Trial t = GetSelectedTrials().First();
                t.UpdateToDb();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listViewTrials.SelectedItems.Count == 1)
            {
                Trial t = GetSelectedTrials().First();
                t.UpdateToDb();
            }
        }

        private void buttonResetCorrectionMilestone_Click(object sender, EventArgs e)
        {
            foreach (Trial t in GetSelectedTrials())
            {
                t.Corrected = new Milestone(MilestoneType.CORRECTION);

                t.UpdateToDb();
            }

            UpdateDetail_TrialView();

            UpdateTrialListView();

            TrySelectItemsInTrialListViewFromDetail();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (GetSelectedTrials().Count == 1 && File.Exists(textBoxFilepath.Text))
            {
                System.Diagnostics.Process.Start(textBoxFilepath.Text);
            }
        }

        private void buttonMarkSeen_Click(object sender, EventArgs e)
        {
            foreach(Trial t in GetSelectedTrials())
            {
                if(t.IsNew)
                {
                    t.Corrected = new Milestone(MilestoneType.CORRECTION);
                    t.Translated = new Milestone(MilestoneType.CORRECTION);
                    t.UpdateToDb();
                }
            }

            UpdateDetail_TrialView();

            UpdateTrialListView();

            TrySelectItemsInTrialListViewFromDetail();
        }

        private void TrySelectItemsInTrialListViewFromDetail()
        {
            List<int> ids = new List<int>();
            string[] split = textBoxID.Text.Split(new Char[] { ',', ' ' });
            if (split.Length > 1)
            {
                foreach (string s in split)
                {
                    if (s.Trim() != "")
                        ids.Add(int.Parse(s));
                }
            }
            else
            {
                return; // no need to do anything, if only one is selected
            }

            listViewTrials.SelectedIndices.Clear();
            bool found = false;

            foreach(int i in ids)
            {
                foreach (ListViewItem lvi in listViewTrials.Items)
                {
                    if (lvi.SubItems[0].Text == i.ToString())
                    {
                        lvi.Selected = true;
                        lvi.Focused = true;
                        found = true;
                    }
                        
                }
            }

            if(found)
            {
                UpdateDetail_TrialView();
                ActiveControl = listViewTrials;
            }
            else
            {
                ClearDetailView();
            }
        }

        private void buttonMarkTranslated_Click(object sender, EventArgs e)
        {
            foreach (Trial t in GetSelectedTrials())
            {
                t.Translated = new Milestone(MilestoneType.TRANSLATION, true, DateTime.Now);

                t.UpdateToDb();
            }
            UpdateDetail_TrialView();
            UpdateTrialListView();
            TrySelectItemsInTrialListViewFromDetail();
        }

        private void buttonMarkCorrected_Click(object sender, EventArgs e)
        {
            foreach (Trial t in GetSelectedTrials())
            {
                t.Corrected = new Milestone(MilestoneType.CORRECTION, true, DateTime.Now);
                if(!t.Translated.Completed)
                {
                    t.Translated = new Milestone(MilestoneType.TRANSLATION, true, DateTime.Now);
                }

                t.UpdateToDb();
            }
            UpdateDetail_TrialView();
            UpdateTrialListView();
            TrySelectItemsInTrialListViewFromDetail();
        }

        private void buttonResetStatus_Click(object sender, EventArgs e)
        {
            foreach (Trial t in GetSelectedTrials())
            {
                if(!t.IsNew)
                    t.Delete();
            }
            UpdateDetail_TrialView();
            UpdateTrialListView();
            TrySelectItemsInTrialListViewFromDetail();
        }

        private void checkBoxShowAll_TrialView_CheckedChanged(object sender, EventArgs e)
        {
            ShowAllTrials_TrialView = checkBoxShowAll_TrialView.Checked;

            UpdateTrialListView();
            UpdateDetail_TrialView();
            TrySelectItemsInTrialListViewFromDetail();
        }

        private void buttonAssignFile_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AssignFileDialog_DefaultPath != "")
            {
                assignFileDialog.InitialDirectory = Properties.Settings.Default.AssignFileDialog_DefaultPath;
            }

            if (assignFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Trial t = GetSelectedTrials().First();
                t.Filepath = assignFileDialog.FileName;
                t.UpdateToDb();

                UpdateTrialListView();
                UpdateDetail_TrialView();

                Properties.Settings.Default.AssignFileDialog_DefaultPath = Path.GetDirectoryName(assignFileDialog.FileName);
                Properties.Settings.Default.Save();
            }

            TrySelectItemsInTrialListViewFromDetail();
        }


        private void buttonMoveFile_Click(object sender, EventArgs e)
        {
            Trial t = GetSelectedTrials().First();

            if (Properties.Settings.Default.MoveFileDialog_DefaultPath != "")
            {
                moveFileDialog.InitialDirectory = Properties.Settings.Default.MoveFileDialog_DefaultPath;
            }

            moveFileDialog.FileName = Path.GetFileName(t.Filepath);
            moveFileDialog.Filter = "Document|*"+Path.GetExtension(t.Filepath);

            if (moveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    File.Move(t.Filepath, moveFileDialog.FileName);

                    t.Filepath = moveFileDialog.FileName;
                    t.UpdateToDb();

                    UpdateTrialListView();
                    UpdateDetail_TrialView();

                    Properties.Settings.Default.MoveFileDialog_DefaultPath = Path.GetDirectoryName(moveFileDialog.FileName);
                    Properties.Settings.Default.Save();
                } 
                catch (Exception ex)
                {
                    MessageBox.Show("Error moving file:\r\n"+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            TrySelectItemsInTrialListViewFromDetail();
        }

        private void buttonAutoRename_Click(object sender, EventArgs e)
        {
            foreach(Trial t in GetSelectedTrials())
            {
                if(t.Filepath.Length > 1)
                {
                    string newfilename = t.Id.ToString();
                    if(t.Translated.Completed)
                    {
                        newfilename += "Ü";
                        newfilename = t.Block.Translator.Name[0] + newfilename;
                        if(t.Corrected.Completed)
                        {
                            newfilename += "_k";
                        }
                    }

                    if(MessageBox.Show("About to rename '"+Path.GetFileName(t.Filepath)+"' to '"+newfilename+Path.GetExtension(t.Filepath)+"'. \r\nContinue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            File.Move(t.Filepath, Path.GetDirectoryName(t.Filepath) + Path.DirectorySeparatorChar + newfilename + Path.GetExtension(t.Filepath));
                            t.Filepath = Path.GetDirectoryName(t.Filepath) + Path.DirectorySeparatorChar + newfilename + Path.GetExtension(t.Filepath);
                            t.UpdateToDb();
                            UpdateDetail_TrialView();
                            UpdateTrialListView();
                        } 
                        catch(Exception ex)
                        {
                            MessageBox.Show("Error renaming file:\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            TrySelectItemsInTrialListViewFromDetail();
        }

        private void checkBoxShowOnlyTranslated_TrialView_CheckedChanged(object sender, EventArgs e)
        {
            ShowOnlyTranslated_TrialView = checkBoxShowOnlyTranslated_TrialView.Checked;

            UpdateTrialListView();
            TrySelectItemsInTrialListViewFromDetail();
        }

        private void checkBoxShowOnlyCorrected_TrialView_CheckedChanged(object sender, EventArgs e)
        {
            ShowOnlyCorrected_TrialView = checkBoxShowOnlyCorrected_TrialView.Checked;

            UpdateTrialListView();
            TrySelectItemsInTrialListViewFromDetail();
        }
        #endregion

        

        

        

        


    }
}
