namespace StudyTranslationManager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeDbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteUser = new System.Windows.Forms.Button();
            this.buttonEditUser = new System.Windows.Forms.Button();
            this.buttonNewUser = new System.Windows.Forms.Button();
            this.listViewUsers = new System.Windows.Forms.ListView();
            this.columnUserUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUserRoles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonBlockInfo = new System.Windows.Forms.Button();
            this.buttonNewSingle = new System.Windows.Forms.Button();
            this.buttonTrialDelete = new System.Windows.Forms.Button();
            this.comboBoxUserFilter = new System.Windows.Forms.ComboBox();
            this.checkBoxFilterUser = new System.Windows.Forms.CheckBox();
            this.checkBoxShowDone = new System.Windows.Forms.CheckBox();
            this.buttonEditBlock = new System.Windows.Forms.Button();
            this.buttonNewBlock = new System.Windows.Forms.Button();
            this.listViewTrialBlocks = new System.Windows.Forms.ListView();
            this.columnTrialBlockId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTrialBlockFromId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTrialBlockToId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTrialBlockTranslator = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTrialBlockProofreader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTimestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTrialBlockDone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openDbDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonAssignFile = new System.Windows.Forms.Button();
            this.buttonResetStatus = new System.Windows.Forms.Button();
            this.buttonMarkSeen = new System.Windows.Forms.Button();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textBoxFilepath = new System.Windows.Forms.TextBox();
            this.textBoxCorrectionStatus = new System.Windows.Forms.TextBox();
            this.textBoxTranslationStatus = new System.Windows.Forms.TextBox();
            this.textBoxProofreader = new System.Windows.Forms.TextBox();
            this.textBoxTranslator = new System.Windows.Forms.TextBox();
            this.textBoxBlockInfo = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAutoRename = new System.Windows.Forms.Button();
            this.buttonMoveFile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonResetTranslationMilestone = new System.Windows.Forms.Button();
            this.buttonResetCorrectionMilestone = new System.Windows.Forms.Button();
            this.buttonMarkCorrected = new System.Windows.Forms.Button();
            this.buttonMarkTranslated = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxShowAll_TrialView = new System.Windows.Forms.CheckBox();
            this.checkBoxShowOnlyCorrected_TrialView = new System.Windows.Forms.CheckBox();
            this.checkBoxShowOnlyTranslated_TrialView = new System.Windows.Forms.CheckBox();
            this.listViewTrials = new System.Windows.Forms.ListView();
            this.columnId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTranslation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderProofreading = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFilepath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.assignFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDbDialog = new System.Windows.Forms.SaveFileDialog();
            this.moveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.statusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabel1,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2});
            this.statusStrip.Location = new System.Drawing.Point(0, 513);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(882, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.changeDbToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(78, 20);
            this.toolStripDropDownButton1.Text = "DB Actions";
            this.toolStripDropDownButton1.ToolTipText = "Optionen";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // changeDbToolStripMenuItem
            // 
            this.changeDbToolStripMenuItem.Name = "changeDbToolStripMenuItem";
            this.changeDbToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.changeDbToolStripMenuItem.Text = "Change";
            this.changeDbToolStripMenuItem.Click += new System.EventHandler(this.changeDbToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonDeleteUser);
            this.groupBox1.Controls.Add(this.buttonEditUser);
            this.groupBox1.Controls.Add(this.buttonNewUser);
            this.groupBox1.Controls.Add(this.listViewUsers);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(844, 207);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Users";
            // 
            // buttonDeleteUser
            // 
            this.buttonDeleteUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteUser.Location = new System.Drawing.Point(763, 79);
            this.buttonDeleteUser.Name = "buttonDeleteUser";
            this.buttonDeleteUser.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteUser.TabIndex = 3;
            this.buttonDeleteUser.Text = "Delete User";
            this.buttonDeleteUser.UseVisualStyleBackColor = true;
            this.buttonDeleteUser.Click += new System.EventHandler(this.buttonDeleteUser_Click);
            // 
            // buttonEditUser
            // 
            this.buttonEditUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditUser.Location = new System.Drawing.Point(763, 49);
            this.buttonEditUser.Name = "buttonEditUser";
            this.buttonEditUser.Size = new System.Drawing.Size(75, 23);
            this.buttonEditUser.TabIndex = 2;
            this.buttonEditUser.Text = "Edit User";
            this.buttonEditUser.UseVisualStyleBackColor = true;
            this.buttonEditUser.Click += new System.EventHandler(this.buttonEditUser_Click);
            // 
            // buttonNewUser
            // 
            this.buttonNewUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewUser.Location = new System.Drawing.Point(763, 19);
            this.buttonNewUser.Name = "buttonNewUser";
            this.buttonNewUser.Size = new System.Drawing.Size(75, 23);
            this.buttonNewUser.TabIndex = 1;
            this.buttonNewUser.Text = "New User";
            this.buttonNewUser.UseVisualStyleBackColor = true;
            this.buttonNewUser.Click += new System.EventHandler(this.buttonNewUser_Click);
            // 
            // listViewUsers
            // 
            this.listViewUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnUserUsername,
            this.columnUserName,
            this.columnUserRoles});
            this.listViewUsers.FullRowSelect = true;
            this.listViewUsers.Location = new System.Drawing.Point(7, 20);
            this.listViewUsers.MultiSelect = false;
            this.listViewUsers.Name = "listViewUsers";
            this.listViewUsers.Size = new System.Drawing.Size(751, 181);
            this.listViewUsers.TabIndex = 0;
            this.listViewUsers.UseCompatibleStateImageBehavior = false;
            this.listViewUsers.View = System.Windows.Forms.View.Details;
            // 
            // columnUserUsername
            // 
            this.columnUserUsername.Text = "Username";
            this.columnUserUsername.Width = 77;
            // 
            // columnUserName
            // 
            this.columnUserName.Text = "Name";
            this.columnUserName.Width = 228;
            // 
            // columnUserRoles
            // 
            this.columnUserRoles.Text = "Roles";
            this.columnUserRoles.Width = 152;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.buttonBlockInfo);
            this.groupBox2.Controls.Add(this.buttonNewSingle);
            this.groupBox2.Controls.Add(this.buttonTrialDelete);
            this.groupBox2.Controls.Add(this.comboBoxUserFilter);
            this.groupBox2.Controls.Add(this.checkBoxFilterUser);
            this.groupBox2.Controls.Add(this.checkBoxShowDone);
            this.groupBox2.Controls.Add(this.buttonEditBlock);
            this.groupBox2.Controls.Add(this.buttonNewBlock);
            this.groupBox2.Controls.Add(this.listViewTrialBlocks);
            this.groupBox2.Location = new System.Drawing.Point(3, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(844, 243);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trial Blocks";
            // 
            // buttonBlockInfo
            // 
            this.buttonBlockInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBlockInfo.Location = new System.Drawing.Point(763, 214);
            this.buttonBlockInfo.Name = "buttonBlockInfo";
            this.buttonBlockInfo.Size = new System.Drawing.Size(75, 23);
            this.buttonBlockInfo.TabIndex = 9;
            this.buttonBlockInfo.Text = "Block Info";
            this.buttonBlockInfo.UseVisualStyleBackColor = true;
            this.buttonBlockInfo.Click += new System.EventHandler(this.buttonBlockInfo_Click_1);
            // 
            // buttonNewSingle
            // 
            this.buttonNewSingle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewSingle.Location = new System.Drawing.Point(764, 49);
            this.buttonNewSingle.Name = "buttonNewSingle";
            this.buttonNewSingle.Size = new System.Drawing.Size(75, 23);
            this.buttonNewSingle.TabIndex = 8;
            this.buttonNewSingle.Text = "New Single";
            this.buttonNewSingle.UseVisualStyleBackColor = true;
            this.buttonNewSingle.Click += new System.EventHandler(this.buttonNewSingle_Click);
            // 
            // buttonTrialDelete
            // 
            this.buttonTrialDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTrialDelete.Location = new System.Drawing.Point(764, 107);
            this.buttonTrialDelete.Name = "buttonTrialDelete";
            this.buttonTrialDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonTrialDelete.TabIndex = 7;
            this.buttonTrialDelete.Text = "Delete";
            this.buttonTrialDelete.UseVisualStyleBackColor = true;
            this.buttonTrialDelete.Click += new System.EventHandler(this.buttonTrialDelete_Click);
            // 
            // comboBoxUserFilter
            // 
            this.comboBoxUserFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxUserFilter.Enabled = false;
            this.comboBoxUserFilter.FormattingEnabled = true;
            this.comboBoxUserFilter.Location = new System.Drawing.Point(192, 218);
            this.comboBoxUserFilter.Name = "comboBoxUserFilter";
            this.comboBoxUserFilter.Size = new System.Drawing.Size(138, 21);
            this.comboBoxUserFilter.TabIndex = 5;
            this.comboBoxUserFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxUserFilter_SelectedIndexChanged);
            // 
            // checkBoxFilterUser
            // 
            this.checkBoxFilterUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxFilterUser.AutoSize = true;
            this.checkBoxFilterUser.Location = new System.Drawing.Point(95, 220);
            this.checkBoxFilterUser.Name = "checkBoxFilterUser";
            this.checkBoxFilterUser.Size = new System.Drawing.Size(91, 17);
            this.checkBoxFilterUser.TabIndex = 4;
            this.checkBoxFilterUser.Text = "Filter By User:";
            this.checkBoxFilterUser.UseVisualStyleBackColor = true;
            this.checkBoxFilterUser.CheckedChanged += new System.EventHandler(this.checkBoxFilterUser_CheckedChanged);
            // 
            // checkBoxShowDone
            // 
            this.checkBoxShowDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxShowDone.AutoSize = true;
            this.checkBoxShowDone.Location = new System.Drawing.Point(7, 220);
            this.checkBoxShowDone.Name = "checkBoxShowDone";
            this.checkBoxShowDone.Size = new System.Drawing.Size(82, 17);
            this.checkBoxShowDone.TabIndex = 3;
            this.checkBoxShowDone.Text = "Show Done";
            this.checkBoxShowDone.UseVisualStyleBackColor = true;
            this.checkBoxShowDone.CheckedChanged += new System.EventHandler(this.checkBoxShowDone_CheckedChanged);
            // 
            // buttonEditBlock
            // 
            this.buttonEditBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditBlock.Location = new System.Drawing.Point(764, 78);
            this.buttonEditBlock.Name = "buttonEditBlock";
            this.buttonEditBlock.Size = new System.Drawing.Size(75, 23);
            this.buttonEditBlock.TabIndex = 2;
            this.buttonEditBlock.Text = "Edit Block";
            this.buttonEditBlock.UseVisualStyleBackColor = true;
            this.buttonEditBlock.Click += new System.EventHandler(this.buttonEditBlock_Click);
            // 
            // buttonNewBlock
            // 
            this.buttonNewBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewBlock.Location = new System.Drawing.Point(764, 20);
            this.buttonNewBlock.Name = "buttonNewBlock";
            this.buttonNewBlock.Size = new System.Drawing.Size(75, 23);
            this.buttonNewBlock.TabIndex = 1;
            this.buttonNewBlock.Text = "New Block";
            this.buttonNewBlock.UseVisualStyleBackColor = true;
            this.buttonNewBlock.Click += new System.EventHandler(this.buttonNewBlock_Click);
            // 
            // listViewTrialBlocks
            // 
            this.listViewTrialBlocks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewTrialBlocks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnTrialBlockId,
            this.columnTrialBlockFromId,
            this.columnTrialBlockToId,
            this.columnTrialBlockTranslator,
            this.columnTrialBlockProofreader,
            this.columnHeaderTimestamp,
            this.columnTrialBlockDone});
            this.listViewTrialBlocks.FullRowSelect = true;
            this.listViewTrialBlocks.Location = new System.Drawing.Point(7, 20);
            this.listViewTrialBlocks.Name = "listViewTrialBlocks";
            this.listViewTrialBlocks.Size = new System.Drawing.Size(751, 192);
            this.listViewTrialBlocks.TabIndex = 0;
            this.listViewTrialBlocks.UseCompatibleStateImageBehavior = false;
            this.listViewTrialBlocks.View = System.Windows.Forms.View.Details;
            // 
            // columnTrialBlockId
            // 
            this.columnTrialBlockId.Text = "ID";
            this.columnTrialBlockId.Width = 30;
            // 
            // columnTrialBlockFromId
            // 
            this.columnTrialBlockFromId.Text = "From ID";
            // 
            // columnTrialBlockToId
            // 
            this.columnTrialBlockToId.Text = "To ID";
            this.columnTrialBlockToId.Width = 63;
            // 
            // columnTrialBlockTranslator
            // 
            this.columnTrialBlockTranslator.Text = "Translator";
            this.columnTrialBlockTranslator.Width = 159;
            // 
            // columnTrialBlockProofreader
            // 
            this.columnTrialBlockProofreader.Text = "Proofreader";
            this.columnTrialBlockProofreader.Width = 198;
            // 
            // columnHeaderTimestamp
            // 
            this.columnHeaderTimestamp.Text = "Date/Time";
            this.columnHeaderTimestamp.Width = 86;
            // 
            // columnTrialBlockDone
            // 
            this.columnTrialBlockDone.Text = "Done?";
            // 
            // openDbDialog
            // 
            this.openDbDialog.FileName = "openFileDialog1";
            this.openDbDialog.Filter = "SQL Files|*.db";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(858, 491);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(850, 465);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Users/Blocks";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(850, 465);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Trials";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.buttonAssignFile);
            this.groupBox3.Controls.Add(this.buttonResetStatus);
            this.groupBox3.Controls.Add(this.buttonMarkSeen);
            this.groupBox3.Controls.Add(this.textBoxNotes);
            this.groupBox3.Controls.Add(this.linkLabel1);
            this.groupBox3.Controls.Add(this.textBoxFilepath);
            this.groupBox3.Controls.Add(this.textBoxCorrectionStatus);
            this.groupBox3.Controls.Add(this.textBoxTranslationStatus);
            this.groupBox3.Controls.Add(this.textBoxProofreader);
            this.groupBox3.Controls.Add(this.textBoxTranslator);
            this.groupBox3.Controls.Add(this.textBoxBlockInfo);
            this.groupBox3.Controls.Add(this.textBoxID);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.buttonAutoRename);
            this.groupBox3.Controls.Add(this.buttonMoveFile);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.buttonResetTranslationMilestone);
            this.groupBox3.Controls.Add(this.buttonResetCorrectionMilestone);
            this.groupBox3.Controls.Add(this.buttonMarkCorrected);
            this.groupBox3.Controls.Add(this.buttonMarkTranslated);
            this.groupBox3.Location = new System.Drawing.Point(451, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(393, 452);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Trial Details";
            // 
            // buttonAssignFile
            // 
            this.buttonAssignFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAssignFile.Enabled = false;
            this.buttonAssignFile.Location = new System.Drawing.Point(230, 423);
            this.buttonAssignFile.Name = "buttonAssignFile";
            this.buttonAssignFile.Size = new System.Drawing.Size(75, 23);
            this.buttonAssignFile.TabIndex = 25;
            this.buttonAssignFile.Text = "Assign file";
            this.buttonAssignFile.UseVisualStyleBackColor = true;
            this.buttonAssignFile.Click += new System.EventHandler(this.buttonAssignFile_Click);
            // 
            // buttonResetStatus
            // 
            this.buttonResetStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResetStatus.Enabled = false;
            this.buttonResetStatus.Location = new System.Drawing.Point(103, 423);
            this.buttonResetStatus.Name = "buttonResetStatus";
            this.buttonResetStatus.Size = new System.Drawing.Size(90, 23);
            this.buttonResetStatus.TabIndex = 24;
            this.buttonResetStatus.Text = "Reset status";
            this.buttonResetStatus.UseVisualStyleBackColor = true;
            this.buttonResetStatus.Click += new System.EventHandler(this.buttonResetStatus_Click);
            // 
            // buttonMarkSeen
            // 
            this.buttonMarkSeen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMarkSeen.Enabled = false;
            this.buttonMarkSeen.Location = new System.Drawing.Point(6, 394);
            this.buttonMarkSeen.Name = "buttonMarkSeen";
            this.buttonMarkSeen.Size = new System.Drawing.Size(89, 23);
            this.buttonMarkSeen.TabIndex = 23;
            this.buttonMarkSeen.Text = "Mark seen";
            this.buttonMarkSeen.UseVisualStyleBackColor = true;
            this.buttonMarkSeen.Click += new System.EventHandler(this.buttonMarkSeen_Click);
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNotes.Enabled = false;
            this.textBoxNotes.Location = new System.Drawing.Point(116, 206);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(270, 114);
            this.textBoxNotes.TabIndex = 22;
            this.textBoxNotes.TextChanged += new System.EventHandler(this.textBoxNotes_TextChanged);
            this.textBoxNotes.Leave += new System.EventHandler(this.textBoxNotes_Leave);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(353, 183);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(33, 13);
            this.linkLabel1.TabIndex = 21;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Open";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // textBoxFilepath
            // 
            this.textBoxFilepath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilepath.Enabled = false;
            this.textBoxFilepath.Location = new System.Drawing.Point(116, 180);
            this.textBoxFilepath.Name = "textBoxFilepath";
            this.textBoxFilepath.Size = new System.Drawing.Size(231, 20);
            this.textBoxFilepath.TabIndex = 20;
            // 
            // textBoxCorrectionStatus
            // 
            this.textBoxCorrectionStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCorrectionStatus.Enabled = false;
            this.textBoxCorrectionStatus.Location = new System.Drawing.Point(116, 154);
            this.textBoxCorrectionStatus.Name = "textBoxCorrectionStatus";
            this.textBoxCorrectionStatus.Size = new System.Drawing.Size(189, 20);
            this.textBoxCorrectionStatus.TabIndex = 19;
            // 
            // textBoxTranslationStatus
            // 
            this.textBoxTranslationStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTranslationStatus.Enabled = false;
            this.textBoxTranslationStatus.Location = new System.Drawing.Point(116, 128);
            this.textBoxTranslationStatus.Name = "textBoxTranslationStatus";
            this.textBoxTranslationStatus.Size = new System.Drawing.Size(189, 20);
            this.textBoxTranslationStatus.TabIndex = 18;
            // 
            // textBoxProofreader
            // 
            this.textBoxProofreader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProofreader.Enabled = false;
            this.textBoxProofreader.Location = new System.Drawing.Point(116, 101);
            this.textBoxProofreader.Name = "textBoxProofreader";
            this.textBoxProofreader.Size = new System.Drawing.Size(270, 20);
            this.textBoxProofreader.TabIndex = 17;
            // 
            // textBoxTranslator
            // 
            this.textBoxTranslator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTranslator.Enabled = false;
            this.textBoxTranslator.Location = new System.Drawing.Point(116, 74);
            this.textBoxTranslator.Name = "textBoxTranslator";
            this.textBoxTranslator.Size = new System.Drawing.Size(270, 20);
            this.textBoxTranslator.TabIndex = 16;
            // 
            // textBoxBlockInfo
            // 
            this.textBoxBlockInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBlockInfo.Enabled = false;
            this.textBoxBlockInfo.Location = new System.Drawing.Point(116, 47);
            this.textBoxBlockInfo.Name = "textBoxBlockInfo";
            this.textBoxBlockInfo.Size = new System.Drawing.Size(270, 20);
            this.textBoxBlockInfo.TabIndex = 15;
            // 
            // textBoxID
            // 
            this.textBoxID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxID.Enabled = false;
            this.textBoxID.Location = new System.Drawing.Point(116, 20);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(271, 20);
            this.textBoxID.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Block";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(79, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "File";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Notes";
            // 
            // buttonAutoRename
            // 
            this.buttonAutoRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAutoRename.AutoSize = true;
            this.buttonAutoRename.Enabled = false;
            this.buttonAutoRename.Location = new System.Drawing.Point(308, 394);
            this.buttonAutoRename.Name = "buttonAutoRename";
            this.buttonAutoRename.Size = new System.Drawing.Size(79, 23);
            this.buttonAutoRename.TabIndex = 10;
            this.buttonAutoRename.Text = "AutoRename";
            this.buttonAutoRename.UseVisualStyleBackColor = true;
            this.buttonAutoRename.Click += new System.EventHandler(this.buttonAutoRename_Click);
            // 
            // buttonMoveFile
            // 
            this.buttonMoveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMoveFile.Enabled = false;
            this.buttonMoveFile.Location = new System.Drawing.Point(308, 423);
            this.buttonMoveFile.Name = "buttonMoveFile";
            this.buttonMoveFile.Size = new System.Drawing.Size(79, 23);
            this.buttonMoveFile.TabIndex = 9;
            this.buttonMoveFile.Text = "Move file";
            this.buttonMoveFile.UseVisualStyleBackColor = true;
            this.buttonMoveFile.Click += new System.EventHandler(this.buttonMoveFile_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Correction Status";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Translation Status";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Proofreader";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Translator";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Trial ID";
            // 
            // buttonResetTranslationMilestone
            // 
            this.buttonResetTranslationMilestone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResetTranslationMilestone.Location = new System.Drawing.Point(312, 127);
            this.buttonResetTranslationMilestone.Name = "buttonResetTranslationMilestone";
            this.buttonResetTranslationMilestone.Size = new System.Drawing.Size(75, 20);
            this.buttonResetTranslationMilestone.TabIndex = 3;
            this.buttonResetTranslationMilestone.Text = "Reset";
            this.buttonResetTranslationMilestone.UseVisualStyleBackColor = true;
            this.buttonResetTranslationMilestone.Click += new System.EventHandler(this.buttonResetTranslationMilestone_Click);
            // 
            // buttonResetCorrectionMilestone
            // 
            this.buttonResetCorrectionMilestone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResetCorrectionMilestone.Location = new System.Drawing.Point(312, 154);
            this.buttonResetCorrectionMilestone.Name = "buttonResetCorrectionMilestone";
            this.buttonResetCorrectionMilestone.Size = new System.Drawing.Size(75, 20);
            this.buttonResetCorrectionMilestone.TabIndex = 2;
            this.buttonResetCorrectionMilestone.Text = "Reset";
            this.buttonResetCorrectionMilestone.UseVisualStyleBackColor = true;
            this.buttonResetCorrectionMilestone.Click += new System.EventHandler(this.buttonResetCorrectionMilestone_Click);
            // 
            // buttonMarkCorrected
            // 
            this.buttonMarkCorrected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMarkCorrected.AutoSize = true;
            this.buttonMarkCorrected.Enabled = false;
            this.buttonMarkCorrected.Location = new System.Drawing.Point(8, 423);
            this.buttonMarkCorrected.Name = "buttonMarkCorrected";
            this.buttonMarkCorrected.Size = new System.Drawing.Size(89, 23);
            this.buttonMarkCorrected.TabIndex = 1;
            this.buttonMarkCorrected.Text = "Mark corrected";
            this.buttonMarkCorrected.UseVisualStyleBackColor = true;
            this.buttonMarkCorrected.Click += new System.EventHandler(this.buttonMarkCorrected_Click);
            // 
            // buttonMarkTranslated
            // 
            this.buttonMarkTranslated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMarkTranslated.AutoSize = true;
            this.buttonMarkTranslated.Enabled = false;
            this.buttonMarkTranslated.Location = new System.Drawing.Point(103, 394);
            this.buttonMarkTranslated.Name = "buttonMarkTranslated";
            this.buttonMarkTranslated.Size = new System.Drawing.Size(90, 23);
            this.buttonMarkTranslated.TabIndex = 0;
            this.buttonMarkTranslated.Text = "Mark translated";
            this.buttonMarkTranslated.UseVisualStyleBackColor = true;
            this.buttonMarkTranslated.Click += new System.EventHandler(this.buttonMarkTranslated_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.checkBoxShowAll_TrialView);
            this.groupBox4.Controls.Add(this.checkBoxShowOnlyCorrected_TrialView);
            this.groupBox4.Controls.Add(this.checkBoxShowOnlyTranslated_TrialView);
            this.groupBox4.Controls.Add(this.listViewTrials);
            this.groupBox4.Location = new System.Drawing.Point(6, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(438, 452);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Trials";
            // 
            // checkBoxShowAll_TrialView
            // 
            this.checkBoxShowAll_TrialView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxShowAll_TrialView.AutoSize = true;
            this.checkBoxShowAll_TrialView.Location = new System.Drawing.Point(7, 406);
            this.checkBoxShowAll_TrialView.Name = "checkBoxShowAll_TrialView";
            this.checkBoxShowAll_TrialView.Size = new System.Drawing.Size(90, 17);
            this.checkBoxShowAll_TrialView.TabIndex = 3;
            this.checkBoxShowAll_TrialView.Text = "Show all trials";
            this.checkBoxShowAll_TrialView.UseVisualStyleBackColor = true;
            this.checkBoxShowAll_TrialView.CheckedChanged += new System.EventHandler(this.checkBoxShowAll_TrialView_CheckedChanged);
            // 
            // checkBoxShowOnlyCorrected_TrialView
            // 
            this.checkBoxShowOnlyCorrected_TrialView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxShowOnlyCorrected_TrialView.AutoSize = true;
            this.checkBoxShowOnlyCorrected_TrialView.Location = new System.Drawing.Point(138, 429);
            this.checkBoxShowOnlyCorrected_TrialView.Name = "checkBoxShowOnlyCorrected_TrialView";
            this.checkBoxShowOnlyCorrected_TrialView.Size = new System.Drawing.Size(123, 17);
            this.checkBoxShowOnlyCorrected_TrialView.TabIndex = 2;
            this.checkBoxShowOnlyCorrected_TrialView.Text = "Show only corrected";
            this.checkBoxShowOnlyCorrected_TrialView.UseVisualStyleBackColor = true;
            this.checkBoxShowOnlyCorrected_TrialView.CheckedChanged += new System.EventHandler(this.checkBoxShowOnlyCorrected_TrialView_CheckedChanged);
            // 
            // checkBoxShowOnlyTranslated_TrialView
            // 
            this.checkBoxShowOnlyTranslated_TrialView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxShowOnlyTranslated_TrialView.AutoSize = true;
            this.checkBoxShowOnlyTranslated_TrialView.Location = new System.Drawing.Point(7, 429);
            this.checkBoxShowOnlyTranslated_TrialView.Name = "checkBoxShowOnlyTranslated_TrialView";
            this.checkBoxShowOnlyTranslated_TrialView.Size = new System.Drawing.Size(124, 17);
            this.checkBoxShowOnlyTranslated_TrialView.TabIndex = 1;
            this.checkBoxShowOnlyTranslated_TrialView.Text = "Show only translated";
            this.checkBoxShowOnlyTranslated_TrialView.UseVisualStyleBackColor = true;
            this.checkBoxShowOnlyTranslated_TrialView.CheckedChanged += new System.EventHandler(this.checkBoxShowOnlyTranslated_TrialView_CheckedChanged);
            // 
            // listViewTrials
            // 
            this.listViewTrials.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewTrials.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnId,
            this.columnHeaderTranslation,
            this.columnHeaderProofreading,
            this.columnHeaderFilepath});
            this.listViewTrials.FullRowSelect = true;
            this.listViewTrials.Location = new System.Drawing.Point(7, 20);
            this.listViewTrials.Name = "listViewTrials";
            this.listViewTrials.Size = new System.Drawing.Size(425, 380);
            this.listViewTrials.TabIndex = 0;
            this.listViewTrials.UseCompatibleStateImageBehavior = false;
            this.listViewTrials.View = System.Windows.Forms.View.Details;
            this.listViewTrials.SelectedIndexChanged += new System.EventHandler(this.listViewTrials_SelectedIndexChanged);
            // 
            // columnId
            // 
            this.columnId.Text = "ID";
            // 
            // columnHeaderTranslation
            // 
            this.columnHeaderTranslation.Text = "Translation";
            this.columnHeaderTranslation.Width = 99;
            // 
            // columnHeaderProofreading
            // 
            this.columnHeaderProofreading.Text = "Proofreading";
            this.columnHeaderProofreading.Width = 86;
            // 
            // columnHeaderFilepath
            // 
            this.columnHeaderFilepath.Text = "Filepath";
            this.columnHeaderFilepath.Width = 145;
            // 
            // assignFileDialog
            // 
            this.assignFileDialog.Filter = "Word Documents|*.docx|Word Documents|*.doc|All Files|*.*";
            // 
            // saveDbDialog
            // 
            this.saveDbDialog.DefaultExt = "db";
            this.saveDbDialog.Filter = "SQL Databases|*.db";
            // 
            // moveFileDialog
            // 
            this.moveFileDialog.Filter = "Word Document|*.docx|Word Document|*.doc|All Files|*.*";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(703, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.ShowDropDownArrow = false;
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(16, 20);
            this.toolStripDropDownButton2.Text = "?";
            this.toolStripDropDownButton2.Click += new System.EventHandler(this.toolStripDropDownButton2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 535);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.MinimumSize = new System.Drawing.Size(898, 574);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Translation Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Button buttonDeleteUser;
        private System.Windows.Forms.Button buttonEditUser;
        private System.Windows.Forms.Button buttonNewUser;
        private System.Windows.Forms.ListView listViewUsers;
        private System.Windows.Forms.ColumnHeader columnUserName;
        private System.Windows.Forms.ColumnHeader columnUserRoles;
        private System.Windows.Forms.ColumnHeader columnUserUsername;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeDbToolStripMenuItem;
        private System.Windows.Forms.ListView listViewTrialBlocks;
        private System.Windows.Forms.ColumnHeader columnTrialBlockId;
        private System.Windows.Forms.ColumnHeader columnTrialBlockFromId;
        private System.Windows.Forms.ColumnHeader columnTrialBlockToId;
        private System.Windows.Forms.ColumnHeader columnTrialBlockTranslator;
        private System.Windows.Forms.ColumnHeader columnTrialBlockProofreader;
        private System.Windows.Forms.ColumnHeader columnTrialBlockDone;
        private System.Windows.Forms.CheckBox checkBoxShowDone;
        private System.Windows.Forms.Button buttonEditBlock;
        private System.Windows.Forms.Button buttonNewBlock;
        private System.Windows.Forms.CheckBox checkBoxFilterUser;
        private System.Windows.Forms.ComboBox comboBoxUserFilter;
        private System.Windows.Forms.OpenFileDialog openDbDialog;
        private System.Windows.Forms.Button buttonTrialDelete;
        private System.Windows.Forms.ColumnHeader columnHeaderTimestamp;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonNewSingle;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView listViewTrials;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxShowOnlyCorrected_TrialView;
        private System.Windows.Forms.CheckBox checkBoxShowOnlyTranslated_TrialView;
        private System.Windows.Forms.ColumnHeader columnId;
        private System.Windows.Forms.ColumnHeader columnHeaderTranslation;
        private System.Windows.Forms.ColumnHeader columnHeaderProofreading;
        private System.Windows.Forms.ColumnHeader columnHeaderFilepath;
        private System.Windows.Forms.CheckBox checkBoxShowAll_TrialView;
        private System.Windows.Forms.Button buttonBlockInfo;
        private System.Windows.Forms.Button buttonMarkCorrected;
        private System.Windows.Forms.Button buttonMarkTranslated;
        private System.Windows.Forms.Button buttonResetTranslationMilestone;
        private System.Windows.Forms.Button buttonResetCorrectionMilestone;
        private System.Windows.Forms.TextBox textBoxCorrectionStatus;
        private System.Windows.Forms.TextBox textBoxTranslationStatus;
        private System.Windows.Forms.TextBox textBoxProofreader;
        private System.Windows.Forms.TextBox textBoxTranslator;
        private System.Windows.Forms.TextBox textBoxBlockInfo;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAutoRename;
        private System.Windows.Forms.Button buttonMoveFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox textBoxFilepath;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.Button buttonMarkSeen;
        private System.Windows.Forms.Button buttonResetStatus;
        private System.Windows.Forms.Button buttonAssignFile;
        private System.Windows.Forms.OpenFileDialog assignFileDialog;
        private System.Windows.Forms.SaveFileDialog saveDbDialog;
        private System.Windows.Forms.SaveFileDialog moveFileDialog;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
    }
}

