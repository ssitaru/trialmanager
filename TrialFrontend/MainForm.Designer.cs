namespace TrialFrontend
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.changeUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeDBToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelNTrials = new System.Windows.Forms.Label();
            this.checkBoxShowDone = new System.Windows.Forms.CheckBox();
            this.comboBoxBlockFilter = new System.Windows.Forms.ComboBox();
            this.checkBoxFilterByBlock = new System.Windows.Forms.CheckBox();
            this.listViewTrials = new System.Windows.Forms.ListView();
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAssignment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxDetails = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabelOpenFile = new System.Windows.Forms.LinkLabel();
            this.textBoxFilepath = new System.Windows.Forms.TextBox();
            this.textBoxProofreader = new System.Windows.Forms.TextBox();
            this.textBoxTranslator = new System.Windows.Forms.TextBox();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.textBoxBlock = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAssignFile = new System.Windows.Forms.Button();
            this.buttonMarkDone = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openDbDialog = new System.Windows.Forms.OpenFileDialog();
            this.assignFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripDropDownButton1});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 388);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(813, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(213, 17);
            this.toolStripStatusLabel.Text = "Logged in as Sebastian Sitaru <ssitaru>";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeUserToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.changeDBToolStripMenuItem1});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(78, 20);
            this.toolStripDropDownButton1.Text = "DB Actions";
            // 
            // changeUserToolStripMenuItem
            // 
            this.changeUserToolStripMenuItem.Name = "changeUserToolStripMenuItem";
            this.changeUserToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.changeUserToolStripMenuItem.Text = "Change User";
            this.changeUserToolStripMenuItem.Click += new System.EventHandler(this.changeUserToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // changeDBToolStripMenuItem1
            // 
            this.changeDBToolStripMenuItem1.Name = "changeDBToolStripMenuItem1";
            this.changeDBToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.changeDBToolStripMenuItem1.Text = "Change DB";
            this.changeDBToolStripMenuItem1.Click += new System.EventHandler(this.changeDBToolStripMenuItem1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelNTrials);
            this.groupBox1.Controls.Add(this.checkBoxShowDone);
            this.groupBox1.Controls.Add(this.comboBoxBlockFilter);
            this.groupBox1.Controls.Add(this.checkBoxFilterByBlock);
            this.groupBox1.Controls.Add(this.listViewTrials);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 358);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Assigned Trials";
            // 
            // labelNTrials
            // 
            this.labelNTrials.AutoSize = true;
            this.labelNTrials.Location = new System.Drawing.Point(392, 336);
            this.labelNTrials.Name = "labelNTrials";
            this.labelNTrials.Size = new System.Drawing.Size(47, 13);
            this.labelNTrials.TabIndex = 5;
            this.labelNTrials.Text = "10 Trials";
            this.labelNTrials.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxShowDone
            // 
            this.checkBoxShowDone.AutoSize = true;
            this.checkBoxShowDone.Location = new System.Drawing.Point(7, 316);
            this.checkBoxShowDone.Name = "checkBoxShowDone";
            this.checkBoxShowDone.Size = new System.Drawing.Size(80, 17);
            this.checkBoxShowDone.TabIndex = 4;
            this.checkBoxShowDone.Text = "Show done";
            this.checkBoxShowDone.UseVisualStyleBackColor = true;
            this.checkBoxShowDone.CheckedChanged += new System.EventHandler(this.checkBoxShowDone_CheckedChanged);
            // 
            // comboBoxBlockFilter
            // 
            this.comboBoxBlockFilter.Enabled = false;
            this.comboBoxBlockFilter.FormattingEnabled = true;
            this.comboBoxBlockFilter.Location = new System.Drawing.Point(117, 333);
            this.comboBoxBlockFilter.Name = "comboBoxBlockFilter";
            this.comboBoxBlockFilter.Size = new System.Drawing.Size(115, 21);
            this.comboBoxBlockFilter.TabIndex = 3;
            this.comboBoxBlockFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxBlockFilter_SelectedIndexChanged);
            // 
            // checkBoxFilterByBlock
            // 
            this.checkBoxFilterByBlock.AutoSize = true;
            this.checkBoxFilterByBlock.Location = new System.Drawing.Point(7, 335);
            this.checkBoxFilterByBlock.Name = "checkBoxFilterByBlock";
            this.checkBoxFilterByBlock.Size = new System.Drawing.Size(104, 17);
            this.checkBoxFilterByBlock.TabIndex = 2;
            this.checkBoxFilterByBlock.Text = "Show only block";
            this.checkBoxFilterByBlock.UseVisualStyleBackColor = true;
            this.checkBoxFilterByBlock.CheckedChanged += new System.EventHandler(this.checkBoxFilterByBlock_CheckedChanged);
            // 
            // listViewTrials
            // 
            this.listViewTrials.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderAssignment,
            this.columnHeaderStatus,
            this.columnHeaderFile});
            this.listViewTrials.FullRowSelect = true;
            this.listViewTrials.Location = new System.Drawing.Point(7, 20);
            this.listViewTrials.MultiSelect = false;
            this.listViewTrials.Name = "listViewTrials";
            this.listViewTrials.ShowGroups = false;
            this.listViewTrials.Size = new System.Drawing.Size(432, 289);
            this.listViewTrials.TabIndex = 0;
            this.listViewTrials.UseCompatibleStateImageBehavior = false;
            this.listViewTrials.View = System.Windows.Forms.View.Details;
            this.listViewTrials.SelectedIndexChanged += new System.EventHandler(this.listViewTrials_SelectedIndexChanged);
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "ID";
            this.columnHeaderId.Width = 38;
            // 
            // columnHeaderAssignment
            // 
            this.columnHeaderAssignment.Text = "Function";
            this.columnHeaderAssignment.Width = 114;
            // 
            // columnHeaderStatus
            // 
            this.columnHeaderStatus.Text = "Status";
            this.columnHeaderStatus.Width = 70;
            // 
            // columnHeaderFile
            // 
            this.columnHeaderFile.Text = "File";
            this.columnHeaderFile.Width = 154;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxDetails);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.linkLabelOpenFile);
            this.groupBox2.Controls.Add(this.textBoxFilepath);
            this.groupBox2.Controls.Add(this.textBoxProofreader);
            this.groupBox2.Controls.Add(this.textBoxTranslator);
            this.groupBox2.Controls.Add(this.comboBoxStatus);
            this.groupBox2.Controls.Add(this.textBoxBlock);
            this.groupBox2.Controls.Add(this.textBoxId);
            this.groupBox2.Controls.Add(this.buttonReset);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.buttonAssignFile);
            this.groupBox2.Controls.Add(this.buttonMarkDone);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(463, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 358);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trial Detail";
            // 
            // textBoxDetails
            // 
            this.textBoxDetails.Enabled = false;
            this.textBoxDetails.Location = new System.Drawing.Point(83, 151);
            this.textBoxDetails.Multiline = true;
            this.textBoxDetails.Name = "textBoxDetails";
            this.textBoxDetails.Size = new System.Drawing.Size(249, 60);
            this.textBoxDetails.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Details";
            // 
            // linkLabelOpenFile
            // 
            this.linkLabelOpenFile.AutoSize = true;
            this.linkLabelOpenFile.Location = new System.Drawing.Point(299, 220);
            this.linkLabelOpenFile.Name = "linkLabelOpenFile";
            this.linkLabelOpenFile.Size = new System.Drawing.Size(33, 13);
            this.linkLabelOpenFile.TabIndex = 15;
            this.linkLabelOpenFile.TabStop = true;
            this.linkLabelOpenFile.Text = "Open";
            this.linkLabelOpenFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOpenFile_LinkClicked);
            // 
            // textBoxFilepath
            // 
            this.textBoxFilepath.Enabled = false;
            this.textBoxFilepath.Location = new System.Drawing.Point(83, 217);
            this.textBoxFilepath.Name = "textBoxFilepath";
            this.textBoxFilepath.Size = new System.Drawing.Size(210, 20);
            this.textBoxFilepath.TabIndex = 14;
            // 
            // textBoxProofreader
            // 
            this.textBoxProofreader.Enabled = false;
            this.textBoxProofreader.Location = new System.Drawing.Point(83, 125);
            this.textBoxProofreader.Name = "textBoxProofreader";
            this.textBoxProofreader.Size = new System.Drawing.Size(249, 20);
            this.textBoxProofreader.TabIndex = 13;
            // 
            // textBoxTranslator
            // 
            this.textBoxTranslator.Enabled = false;
            this.textBoxTranslator.Location = new System.Drawing.Point(83, 98);
            this.textBoxTranslator.Name = "textBoxTranslator";
            this.textBoxTranslator.Size = new System.Drawing.Size(249, 20);
            this.textBoxTranslator.TabIndex = 12;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.Enabled = false;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "seen",
            "done"});
            this.comboBoxStatus.Location = new System.Drawing.Point(83, 70);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(249, 21);
            this.comboBoxStatus.TabIndex = 11;
            // 
            // textBoxBlock
            // 
            this.textBoxBlock.Enabled = false;
            this.textBoxBlock.Location = new System.Drawing.Point(83, 44);
            this.textBoxBlock.Name = "textBoxBlock";
            this.textBoxBlock.Size = new System.Drawing.Size(249, 20);
            this.textBoxBlock.TabIndex = 10;
            // 
            // textBoxId
            // 
            this.textBoxId.Enabled = false;
            this.textBoxId.Location = new System.Drawing.Point(83, 17);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(249, 20);
            this.textBoxId.TabIndex = 9;
            this.textBoxId.Text = "<select trial>";
            // 
            // buttonReset
            // 
            this.buttonReset.Enabled = false;
            this.buttonReset.Location = new System.Drawing.Point(257, 301);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 8;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Proofreader";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Translator";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Block";
            // 
            // buttonAssignFile
            // 
            this.buttonAssignFile.Enabled = false;
            this.buttonAssignFile.Location = new System.Drawing.Point(7, 330);
            this.buttonAssignFile.Name = "buttonAssignFile";
            this.buttonAssignFile.Size = new System.Drawing.Size(75, 23);
            this.buttonAssignFile.TabIndex = 4;
            this.buttonAssignFile.Text = "Assign File";
            this.buttonAssignFile.UseVisualStyleBackColor = true;
            this.buttonAssignFile.Click += new System.EventHandler(this.buttonAssignFile_Click);
            // 
            // buttonMarkDone
            // 
            this.buttonMarkDone.Enabled = false;
            this.buttonMarkDone.Location = new System.Drawing.Point(257, 330);
            this.buttonMarkDone.Name = "buttonMarkDone";
            this.buttonMarkDone.Size = new System.Drawing.Size(75, 23);
            this.buttonMarkDone.TabIndex = 3;
            this.buttonMarkDone.Text = "Mark Done";
            this.buttonMarkDone.UseVisualStyleBackColor = true;
            this.buttonMarkDone.Click += new System.EventHandler(this.buttonMarkDone_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Linked File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DRKS ID";
            // 
            // openDbDialog
            // 
            this.openDbDialog.FileName = "openDbDialog";
            // 
            // assignFileDialog
            // 
            this.assignFileDialog.Filter = "Word Documents|*.docx|Word Documents|*.doc|All Files|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(813, 410);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trial Frontend";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listViewTrials;
        private System.Windows.Forms.CheckBox checkBoxShowDone;
        private System.Windows.Forms.ComboBox comboBoxBlockFilter;
        private System.Windows.Forms.CheckBox checkBoxFilterByBlock;
        private System.Windows.Forms.ColumnHeader columnHeaderAssignment;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
        private System.Windows.Forms.ColumnHeader columnHeaderFile;
        private System.Windows.Forms.Button buttonAssignFile;
        private System.Windows.Forms.Button buttonMarkDone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNTrials;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openDbDialog;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem changeDBToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem changeUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.LinkLabel linkLabelOpenFile;
        private System.Windows.Forms.TextBox textBoxFilepath;
        private System.Windows.Forms.TextBox textBoxProofreader;
        private System.Windows.Forms.TextBox textBoxTranslator;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.TextBox textBoxBlock;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.OpenFileDialog assignFileDialog;
        private System.Windows.Forms.TextBox textBoxDetails;
        private System.Windows.Forms.Label label5;
    }
}

