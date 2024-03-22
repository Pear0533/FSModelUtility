namespace FSModelUtility
{
    partial class FSModelUtility
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSModelUtility));
            copyrightInfoLabel = new Label();
            modelArchivesFolderGroupBox = new GroupBox();
            modelArchivesFolderButton = new Button();
            modelArchivesFolderPathLabel = new Label();
            label2 = new Label();
            modelsFolderGroupBox = new GroupBox();
            modelsFolderButton = new Button();
            modelsFolderPathLabel = new Label();
            label6 = new Label();
            mainSplitContainer = new SplitContainer();
            modelArchivesGroupBox = new GroupBox();
            modelArchivesView = new TreeView();
            modelReplaceGroupBox = new GroupBox();
            splitContainer1 = new SplitContainer();
            modelReplaceButton = new Button();
            modelRestoreButton = new Button();
            modelReplaceView = new TreeView();
            searchBox = new TextBox();
            statusLabel = new Label();
            nodeRightClickMenu = new ContextMenuStrip(components);
            copyToolStripMenuItem = new ToolStripMenuItem();
            searchGroupBox = new GroupBox();
            modelArchivesRadioButton = new RadioButton();
            label1 = new Label();
            filterSearchOptionsBox = new ComboBox();
            modelReplaceRadioButton = new RadioButton();
            versionNumberLabel = new Label();
            gameTabs = new TabControl();
            tabPage1 = new TabPage();
            secondarySplitContainer = new SplitContainer();
            modelPreviewGroupBox = new GroupBox();
            modelPreviewPictureBox = new PictureBox();
            modelArchivesFolderGroupBox.SuspendLayout();
            modelsFolderGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainSplitContainer).BeginInit();
            mainSplitContainer.Panel1.SuspendLayout();
            mainSplitContainer.Panel2.SuspendLayout();
            mainSplitContainer.SuspendLayout();
            modelArchivesGroupBox.SuspendLayout();
            modelReplaceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            nodeRightClickMenu.SuspendLayout();
            searchGroupBox.SuspendLayout();
            gameTabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)secondarySplitContainer).BeginInit();
            secondarySplitContainer.Panel1.SuspendLayout();
            secondarySplitContainer.Panel2.SuspendLayout();
            secondarySplitContainer.SuspendLayout();
            modelPreviewGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)modelPreviewPictureBox).BeginInit();
            SuspendLayout();
            // 
            // copyrightInfoLabel
            // 
            copyrightInfoLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            copyrightInfoLabel.AutoSize = true;
            copyrightInfoLabel.ForeColor = Color.DimGray;
            copyrightInfoLabel.Location = new Point(931, 9);
            copyrightInfoLabel.Name = "copyrightInfoLabel";
            copyrightInfoLabel.Size = new Size(174, 15);
            copyrightInfoLabel.TabIndex = 3;
            copyrightInfoLabel.Text = "© Pear, 2023 All rights reserved.";
            // 
            // modelArchivesFolderGroupBox
            // 
            modelArchivesFolderGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            modelArchivesFolderGroupBox.Controls.Add(modelArchivesFolderButton);
            modelArchivesFolderGroupBox.Controls.Add(modelArchivesFolderPathLabel);
            modelArchivesFolderGroupBox.Controls.Add(label2);
            modelArchivesFolderGroupBox.Enabled = false;
            modelArchivesFolderGroupBox.Location = new Point(4, 80);
            modelArchivesFolderGroupBox.Margin = new Padding(4, 5, 4, 5);
            modelArchivesFolderGroupBox.Name = "modelArchivesFolderGroupBox";
            modelArchivesFolderGroupBox.Padding = new Padding(4, 5, 4, 5);
            modelArchivesFolderGroupBox.Size = new Size(519, 73);
            modelArchivesFolderGroupBox.TabIndex = 13;
            modelArchivesFolderGroupBox.TabStop = false;
            modelArchivesFolderGroupBox.Text = "Model Archives Folder";
            // 
            // modelArchivesFolderButton
            // 
            modelArchivesFolderButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            modelArchivesFolderButton.Location = new Point(9, 23);
            modelArchivesFolderButton.Margin = new Padding(4, 5, 4, 5);
            modelArchivesFolderButton.Name = "modelArchivesFolderButton";
            modelArchivesFolderButton.Size = new Size(501, 26);
            modelArchivesFolderButton.TabIndex = 5;
            modelArchivesFolderButton.Text = "Browse";
            modelArchivesFolderButton.UseVisualStyleBackColor = true;
            modelArchivesFolderButton.Click += BrowseModelArchivesButton_Click;
            // 
            // modelArchivesFolderPathLabel
            // 
            modelArchivesFolderPathLabel.AutoSize = true;
            modelArchivesFolderPathLabel.Location = new Point(40, 52);
            modelArchivesFolderPathLabel.Margin = new Padding(4, 0, 4, 0);
            modelArchivesFolderPathLabel.Name = "modelArchivesFolderPathLabel";
            modelArchivesFolderPathLabel.Size = new Size(29, 15);
            modelArchivesFolderPathLabel.TabIndex = 9;
            modelArchivesFolderPathLabel.Text = "N/A";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 52);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 8;
            label2.Text = "Path:";
            // 
            // modelsFolderGroupBox
            // 
            modelsFolderGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            modelsFolderGroupBox.Controls.Add(modelsFolderButton);
            modelsFolderGroupBox.Controls.Add(modelsFolderPathLabel);
            modelsFolderGroupBox.Controls.Add(label6);
            modelsFolderGroupBox.Location = new Point(4, 1);
            modelsFolderGroupBox.Margin = new Padding(4, 5, 4, 5);
            modelsFolderGroupBox.Name = "modelsFolderGroupBox";
            modelsFolderGroupBox.Padding = new Padding(4, 5, 4, 5);
            modelsFolderGroupBox.Size = new Size(519, 73);
            modelsFolderGroupBox.TabIndex = 12;
            modelsFolderGroupBox.TabStop = false;
            modelsFolderGroupBox.Text = "Models Folder (parts)";
            // 
            // modelsFolderButton
            // 
            modelsFolderButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            modelsFolderButton.Location = new Point(9, 22);
            modelsFolderButton.Margin = new Padding(4, 5, 4, 5);
            modelsFolderButton.Name = "modelsFolderButton";
            modelsFolderButton.Size = new Size(501, 26);
            modelsFolderButton.TabIndex = 5;
            modelsFolderButton.Text = "Browse";
            modelsFolderButton.UseVisualStyleBackColor = true;
            modelsFolderButton.Click += BrowseModelsFolderButton_Click;
            // 
            // modelsFolderPathLabel
            // 
            modelsFolderPathLabel.AutoSize = true;
            modelsFolderPathLabel.Location = new Point(40, 50);
            modelsFolderPathLabel.Margin = new Padding(4, 0, 4, 0);
            modelsFolderPathLabel.Name = "modelsFolderPathLabel";
            modelsFolderPathLabel.Size = new Size(29, 15);
            modelsFolderPathLabel.TabIndex = 9;
            modelsFolderPathLabel.Text = "N/A";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 50);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(34, 15);
            label6.TabIndex = 8;
            label6.Text = "Path:";
            // 
            // mainSplitContainer
            // 
            mainSplitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainSplitContainer.Enabled = false;
            mainSplitContainer.Location = new Point(6, 287);
            mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            mainSplitContainer.Panel1.Controls.Add(modelArchivesGroupBox);
            // 
            // mainSplitContainer.Panel2
            // 
            mainSplitContainer.Panel2.Controls.Add(modelReplaceGroupBox);
            mainSplitContainer.Size = new Size(1094, 377);
            mainSplitContainer.SplitterDistance = 527;
            mainSplitContainer.TabIndex = 15;
            // 
            // modelArchivesGroupBox
            // 
            modelArchivesGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            modelArchivesGroupBox.Controls.Add(modelArchivesView);
            modelArchivesGroupBox.Location = new Point(3, 3);
            modelArchivesGroupBox.Name = "modelArchivesGroupBox";
            modelArchivesGroupBox.Size = new Size(521, 371);
            modelArchivesGroupBox.TabIndex = 16;
            modelArchivesGroupBox.TabStop = false;
            modelArchivesGroupBox.Text = "Model Archives";
            // 
            // modelArchivesView
            // 
            modelArchivesView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            modelArchivesView.HideSelection = false;
            modelArchivesView.Location = new Point(5, 22);
            modelArchivesView.Name = "modelArchivesView";
            modelArchivesView.Size = new Size(510, 342);
            modelArchivesView.TabIndex = 0;
            modelArchivesView.AfterSelect += ModelArchivesView_AfterSelect;
            modelArchivesView.MouseDown += NodeRightClick;
            // 
            // modelReplaceGroupBox
            // 
            modelReplaceGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            modelReplaceGroupBox.Controls.Add(splitContainer1);
            modelReplaceGroupBox.Controls.Add(modelReplaceView);
            modelReplaceGroupBox.Location = new Point(3, 3);
            modelReplaceGroupBox.Name = "modelReplaceGroupBox";
            modelReplaceGroupBox.Size = new Size(557, 371);
            modelReplaceGroupBox.TabIndex = 15;
            modelReplaceGroupBox.TabStop = false;
            modelReplaceGroupBox.Text = "Model Replacement";
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(2, 330);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(modelReplaceButton);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(modelRestoreButton);
            splitContainer1.Size = new Size(552, 37);
            splitContainer1.SplitterDistance = 274;
            splitContainer1.TabIndex = 2;
            // 
            // modelReplaceButton
            // 
            modelReplaceButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            modelReplaceButton.Location = new Point(3, 3);
            modelReplaceButton.Name = "modelReplaceButton";
            modelReplaceButton.Size = new Size(268, 31);
            modelReplaceButton.TabIndex = 0;
            modelReplaceButton.Text = "Replace!";
            modelReplaceButton.UseVisualStyleBackColor = true;
            modelReplaceButton.Click += ModelReplaceButton_Click;
            // 
            // modelRestoreButton
            // 
            modelRestoreButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            modelRestoreButton.Location = new Point(3, 3);
            modelRestoreButton.Name = "modelRestoreButton";
            modelRestoreButton.Size = new Size(269, 31);
            modelRestoreButton.TabIndex = 1;
            modelRestoreButton.Text = "Restore!";
            modelRestoreButton.UseVisualStyleBackColor = true;
            modelRestoreButton.Click += ModelRestoreButton_Click;
            // 
            // modelReplaceView
            // 
            modelReplaceView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            modelReplaceView.Location = new Point(6, 22);
            modelReplaceView.Name = "modelReplaceView";
            modelReplaceView.ShowNodeToolTips = true;
            modelReplaceView.Size = new Size(545, 306);
            modelReplaceView.TabIndex = 1;
            modelReplaceView.AfterSelect += ModelReplaceView_AfterSelect;
            modelReplaceView.MouseDown += NodeRightClick;
            // 
            // searchBox
            // 
            searchBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchBox.Location = new Point(6, 22);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(507, 23);
            searchBox.TabIndex = 0;
            searchBox.TextChanged += SearchBox_TextChanged;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.ForeColor = SystemColors.ControlText;
            statusLabel.Location = new Point(3, 4);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(21, 15);
            statusLabel.TabIndex = 16;
            statusLabel.Text = "{0}";
            statusLabel.Visible = false;
            // 
            // nodeRightClickMenu
            // 
            nodeRightClickMenu.Items.AddRange(new ToolStripItem[] { copyToolStripMenuItem });
            nodeRightClickMenu.Name = "nodeRightClickMenu";
            nodeRightClickMenu.Size = new Size(103, 26);
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(102, 22);
            copyToolStripMenuItem.Text = "Copy";
            // 
            // searchGroupBox
            // 
            searchGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchGroupBox.Controls.Add(modelArchivesRadioButton);
            searchGroupBox.Controls.Add(label1);
            searchGroupBox.Controls.Add(filterSearchOptionsBox);
            searchGroupBox.Controls.Add(modelReplaceRadioButton);
            searchGroupBox.Controls.Add(searchBox);
            searchGroupBox.Enabled = false;
            searchGroupBox.Location = new Point(4, 157);
            searchGroupBox.Name = "searchGroupBox";
            searchGroupBox.Size = new Size(519, 73);
            searchGroupBox.TabIndex = 17;
            searchGroupBox.TabStop = false;
            searchGroupBox.Text = "Search";
            // 
            // modelArchivesRadioButton
            // 
            modelArchivesRadioButton.AutoSize = true;
            modelArchivesRadioButton.Location = new Point(6, 48);
            modelArchivesRadioButton.Name = "modelArchivesRadioButton";
            modelArchivesRadioButton.Size = new Size(107, 19);
            modelArchivesRadioButton.TabIndex = 4;
            modelArchivesRadioButton.TabStop = true;
            modelArchivesRadioButton.Text = "Model Archives";
            modelArchivesRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(250, 50);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 3;
            label1.Text = "Filter:";
            // 
            // filterSearchOptionsBox
            // 
            filterSearchOptionsBox.DropDownStyle = ComboBoxStyle.DropDownList;
            filterSearchOptionsBox.FormattingEnabled = true;
            filterSearchOptionsBox.Items.AddRange(new object[] { "None", "Available", "Taken" });
            filterSearchOptionsBox.Location = new Point(288, 46);
            filterSearchOptionsBox.Name = "filterSearchOptionsBox";
            filterSearchOptionsBox.Size = new Size(121, 23);
            filterSearchOptionsBox.TabIndex = 2;
            filterSearchOptionsBox.SelectedIndexChanged += FilterSearchOptionsBox_SelectedIndexChanged;
            // 
            // modelReplaceRadioButton
            // 
            modelReplaceRadioButton.AutoSize = true;
            modelReplaceRadioButton.Location = new Point(117, 48);
            modelReplaceRadioButton.Name = "modelReplaceRadioButton";
            modelReplaceRadioButton.Size = new Size(131, 19);
            modelReplaceRadioButton.TabIndex = 1;
            modelReplaceRadioButton.TabStop = true;
            modelReplaceRadioButton.Text = "Model Replacement";
            modelReplaceRadioButton.UseVisualStyleBackColor = true;
            // 
            // versionNumberLabel
            // 
            versionNumberLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            versionNumberLabel.AutoSize = true;
            versionNumberLabel.ForeColor = Color.DimGray;
            versionNumberLabel.Location = new Point(866, 9);
            versionNumberLabel.Name = "versionNumberLabel";
            versionNumberLabel.Size = new Size(48, 15);
            versionNumberLabel.TabIndex = 18;
            versionNumberLabel.Text = "Version:";
            // 
            // gameTabs
            // 
            gameTabs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gameTabs.Controls.Add(tabPage1);
            gameTabs.Location = new Point(-3, 24);
            gameTabs.Name = "gameTabs";
            gameTabs.SelectedIndex = 0;
            gameTabs.Size = new Size(1114, 649);
            gameTabs.TabIndex = 19;
            gameTabs.SelectedIndexChanged += GameTabs_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(1106, 621);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "GAME";
            // 
            // secondarySplitContainer
            // 
            secondarySplitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            secondarySplitContainer.Location = new Point(6, 52);
            secondarySplitContainer.Name = "secondarySplitContainer";
            // 
            // secondarySplitContainer.Panel1
            // 
            secondarySplitContainer.Panel1.Controls.Add(modelsFolderGroupBox);
            secondarySplitContainer.Panel1.Controls.Add(searchGroupBox);
            secondarySplitContainer.Panel1.Controls.Add(modelArchivesFolderGroupBox);
            // 
            // secondarySplitContainer.Panel2
            // 
            secondarySplitContainer.Panel2.Controls.Add(modelPreviewGroupBox);
            secondarySplitContainer.Size = new Size(1094, 232);
            secondarySplitContainer.SplitterDistance = 527;
            secondarySplitContainer.TabIndex = 10;
            // 
            // modelPreviewGroupBox
            // 
            modelPreviewGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            modelPreviewGroupBox.Controls.Add(modelPreviewPictureBox);
            modelPreviewGroupBox.Location = new Point(3, 3);
            modelPreviewGroupBox.Name = "modelPreviewGroupBox";
            modelPreviewGroupBox.Size = new Size(557, 227);
            modelPreviewGroupBox.TabIndex = 1;
            modelPreviewGroupBox.TabStop = false;
            modelPreviewGroupBox.Text = "Model Preview";
            // 
            // modelPreviewPictureBox
            // 
            modelPreviewPictureBox.Dock = DockStyle.Fill;
            modelPreviewPictureBox.Location = new Point(3, 19);
            modelPreviewPictureBox.Name = "modelPreviewPictureBox";
            modelPreviewPictureBox.Size = new Size(551, 205);
            modelPreviewPictureBox.TabIndex = 0;
            modelPreviewPictureBox.TabStop = false;
            // 
            // FSModelUtility
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1109, 670);
            Controls.Add(secondarySplitContainer);
            Controls.Add(mainSplitContainer);
            Controls.Add(gameTabs);
            Controls.Add(versionNumberLabel);
            Controls.Add(statusLabel);
            Controls.Add(copyrightInfoLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(600, 450);
            Name = "FSModelUtility";
            Text = "FromSoft Model Utility";
            Load += FSModelUtility_Load;
            modelArchivesFolderGroupBox.ResumeLayout(false);
            modelArchivesFolderGroupBox.PerformLayout();
            modelsFolderGroupBox.ResumeLayout(false);
            modelsFolderGroupBox.PerformLayout();
            mainSplitContainer.Panel1.ResumeLayout(false);
            mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainSplitContainer).EndInit();
            mainSplitContainer.ResumeLayout(false);
            modelArchivesGroupBox.ResumeLayout(false);
            modelReplaceGroupBox.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            nodeRightClickMenu.ResumeLayout(false);
            searchGroupBox.ResumeLayout(false);
            searchGroupBox.PerformLayout();
            gameTabs.ResumeLayout(false);
            secondarySplitContainer.Panel1.ResumeLayout(false);
            secondarySplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)secondarySplitContainer).EndInit();
            secondarySplitContainer.ResumeLayout(false);
            modelPreviewGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)modelPreviewPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label copyrightInfoLabel;
        private GroupBox modelArchivesFolderGroupBox;
        private Button modelArchivesFolderButton;
        private Label modelArchivesFolderPathLabel;
        private Label label2;
        private GroupBox modelsFolderGroupBox;
        private Button modelsFolderButton;
        private Label modelsFolderPathLabel;
        private Label label6;
        private SplitContainer mainSplitContainer;
        private GroupBox modelArchivesGroupBox;
        private GroupBox modelReplaceGroupBox;
        private TreeView modelReplaceView;
        private Button modelReplaceButton;
        private Label statusLabel;
        private ContextMenuStrip nodeRightClickMenu;
        private ToolStripMenuItem copyToolStripMenuItem;
        private TextBox searchBox;
        private TreeView modelArchivesView;
        private GroupBox searchGroupBox;
        private RadioButton modelReplaceRadioButton;
        private Label label1;
        private ComboBox filterSearchOptionsBox;
        private Label versionNumberLabel;
        private SplitContainer splitContainer1;
        private Button modelRestoreButton;
        private RadioButton modelArchivesRadioButton;
        private TabControl gameTabs;
        private TabPage tabPage1;
        private PictureBox modelPreviewPictureBox;
        private GroupBox modelPreviewGroupBox;
        private SplitContainer secondarySplitContainer;
    }
}