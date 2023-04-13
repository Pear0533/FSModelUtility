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
            label1 = new Label();
            filterSearchOptionsBox = new ComboBox();
            modelReplaceRadioButton = new RadioButton();
            versionNumberLabel = new Label();
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
            SuspendLayout();
            // 
            // copyrightInfoLabel
            // 
            copyrightInfoLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            copyrightInfoLabel.AutoSize = true;
            copyrightInfoLabel.ForeColor = Color.DimGray;
            copyrightInfoLabel.Location = new Point(614, 6);
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
            modelArchivesFolderGroupBox.Location = new Point(4, 99);
            modelArchivesFolderGroupBox.Margin = new Padding(4, 5, 4, 5);
            modelArchivesFolderGroupBox.Name = "modelArchivesFolderGroupBox";
            modelArchivesFolderGroupBox.Padding = new Padding(4, 5, 4, 5);
            modelArchivesFolderGroupBox.Size = new Size(784, 73);
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
            modelArchivesFolderButton.Size = new Size(766, 26);
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
            modelsFolderGroupBox.Location = new Point(4, 20);
            modelsFolderGroupBox.Margin = new Padding(4, 5, 4, 5);
            modelsFolderGroupBox.Name = "modelsFolderGroupBox";
            modelsFolderGroupBox.Padding = new Padding(4, 5, 4, 5);
            modelsFolderGroupBox.Size = new Size(784, 73);
            modelsFolderGroupBox.TabIndex = 12;
            modelsFolderGroupBox.TabStop = false;
            modelsFolderGroupBox.Text = "Models Folder (parts, chr, etc.)";
            // 
            // modelsFolderButton
            // 
            modelsFolderButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            modelsFolderButton.Location = new Point(9, 22);
            modelsFolderButton.Margin = new Padding(4, 5, 4, 5);
            modelsFolderButton.Name = "modelsFolderButton";
            modelsFolderButton.Size = new Size(766, 26);
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
            mainSplitContainer.Location = new Point(4, 255);
            mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            mainSplitContainer.Panel1.Controls.Add(modelArchivesGroupBox);
            // 
            // mainSplitContainer.Panel2
            // 
            mainSplitContainer.Panel2.Controls.Add(modelReplaceGroupBox);
            mainSplitContainer.Size = new Size(784, 197);
            mainSplitContainer.SplitterDistance = 379;
            mainSplitContainer.TabIndex = 15;
            // 
            // modelArchivesGroupBox
            // 
            modelArchivesGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            modelArchivesGroupBox.Controls.Add(modelArchivesView);
            modelArchivesGroupBox.Location = new Point(3, 3);
            modelArchivesGroupBox.Name = "modelArchivesGroupBox";
            modelArchivesGroupBox.Size = new Size(373, 191);
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
            modelArchivesView.Size = new Size(362, 163);
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
            modelReplaceGroupBox.Size = new Size(395, 191);
            modelReplaceGroupBox.TabIndex = 15;
            modelReplaceGroupBox.TabStop = false;
            modelReplaceGroupBox.Text = "Model Replacement";
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(2, 150);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(modelReplaceButton);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(modelRestoreButton);
            splitContainer1.Size = new Size(390, 37);
            splitContainer1.SplitterDistance = 191;
            splitContainer1.TabIndex = 2;
            // 
            // modelReplaceButton
            // 
            modelReplaceButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            modelReplaceButton.Location = new Point(3, 3);
            modelReplaceButton.Name = "modelReplaceButton";
            modelReplaceButton.Size = new Size(185, 31);
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
            modelRestoreButton.Size = new Size(189, 31);
            modelRestoreButton.TabIndex = 1;
            modelRestoreButton.Text = "Restore!";
            modelRestoreButton.UseVisualStyleBackColor = true;
            // 
            // modelReplaceView
            // 
            modelReplaceView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            modelReplaceView.Location = new Point(6, 22);
            modelReplaceView.Name = "modelReplaceView";
            modelReplaceView.ShowNodeToolTips = true;
            modelReplaceView.Size = new Size(383, 126);
            modelReplaceView.TabIndex = 1;
            modelReplaceView.AfterSelect += ModelReplaceView_AfterSelect;
            modelReplaceView.MouseDown += NodeRightClick;
            // 
            // searchBox
            // 
            searchBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchBox.Location = new Point(6, 22);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(766, 23);
            searchBox.TabIndex = 0;
            searchBox.TextChanged += SearchBox_TextChanged;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.ForeColor = SystemColors.ControlText;
            statusLabel.Location = new Point(3, 3);
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
            searchGroupBox.Controls.Add(label1);
            searchGroupBox.Controls.Add(filterSearchOptionsBox);
            searchGroupBox.Controls.Add(modelReplaceRadioButton);
            searchGroupBox.Controls.Add(searchBox);
            searchGroupBox.Enabled = false;
            searchGroupBox.Location = new Point(7, 176);
            searchGroupBox.Name = "searchGroupBox";
            searchGroupBox.Size = new Size(778, 73);
            searchGroupBox.TabIndex = 17;
            searchGroupBox.TabStop = false;
            searchGroupBox.Text = "Search";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(139, 50);
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
            filterSearchOptionsBox.Location = new Point(177, 46);
            filterSearchOptionsBox.Name = "filterSearchOptionsBox";
            filterSearchOptionsBox.Size = new Size(121, 23);
            filterSearchOptionsBox.TabIndex = 2;
            filterSearchOptionsBox.SelectedIndexChanged += FilterSearchOptionsBox_SelectedIndexChanged;
            // 
            // modelReplaceRadioButton
            // 
            modelReplaceRadioButton.AutoSize = true;
            modelReplaceRadioButton.Location = new Point(6, 48);
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
            versionNumberLabel.Location = new Point(549, 6);
            versionNumberLabel.Name = "versionNumberLabel";
            versionNumberLabel.Size = new Size(48, 15);
            versionNumberLabel.TabIndex = 18;
            versionNumberLabel.Text = "Version:";
            // 
            // FSModelUtility
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 457);
            Controls.Add(versionNumberLabel);
            Controls.Add(searchGroupBox);
            Controls.Add(statusLabel);
            Controls.Add(copyrightInfoLabel);
            Controls.Add(mainSplitContainer);
            Controls.Add(modelArchivesFolderGroupBox);
            Controls.Add(modelsFolderGroupBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(600, 450);
            Name = "FSModelUtility";
            Text = "FromSoft Model Utility";
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
    }
}