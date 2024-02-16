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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSModelUtility));
            this.copyrightInfoLabel = new System.Windows.Forms.Label();
            this.modelArchivesFolderGroupBox = new System.Windows.Forms.GroupBox();
            this.modelArchivesFolderButton = new System.Windows.Forms.Button();
            this.modelArchivesFolderPathLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.modelsFolderGroupBox = new System.Windows.Forms.GroupBox();
            this.modelsFolderButton = new System.Windows.Forms.Button();
            this.modelsFolderPathLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.modelArchivesGroupBox = new System.Windows.Forms.GroupBox();
            this.modelArchivesView = new System.Windows.Forms.TreeView();
            this.modelReplaceGroupBox = new System.Windows.Forms.GroupBox();
            this.modelReplaceView = new System.Windows.Forms.TreeView();
            this.modelReplaceButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.modelArchivesFolderGroupBox.SuspendLayout();
            this.modelsFolderGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.modelArchivesGroupBox.SuspendLayout();
            this.modelReplaceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // copyrightInfoLabel
            // 
            this.copyrightInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copyrightInfoLabel.AutoSize = true;
            this.copyrightInfoLabel.ForeColor = System.Drawing.Color.DimGray;
            this.copyrightInfoLabel.Location = new System.Drawing.Point(614, 6);
            this.copyrightInfoLabel.Name = "copyrightInfoLabel";
            this.copyrightInfoLabel.Size = new System.Drawing.Size(174, 15);
            this.copyrightInfoLabel.TabIndex = 3;
            this.copyrightInfoLabel.Text = "© Pear, 2023 All rights reserved.";
            // 
            // modelArchivesFolderGroupBox
            // 
            this.modelArchivesFolderGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modelArchivesFolderGroupBox.Controls.Add(this.modelArchivesFolderButton);
            this.modelArchivesFolderGroupBox.Controls.Add(this.modelArchivesFolderPathLabel);
            this.modelArchivesFolderGroupBox.Controls.Add(this.label2);
            this.modelArchivesFolderGroupBox.Enabled = false;
            this.modelArchivesFolderGroupBox.Location = new System.Drawing.Point(4, 99);
            this.modelArchivesFolderGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.modelArchivesFolderGroupBox.Name = "modelArchivesFolderGroupBox";
            this.modelArchivesFolderGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.modelArchivesFolderGroupBox.Size = new System.Drawing.Size(784, 73);
            this.modelArchivesFolderGroupBox.TabIndex = 13;
            this.modelArchivesFolderGroupBox.TabStop = false;
            this.modelArchivesFolderGroupBox.Text = "Model Archives Folder";
            // 
            // modelArchivesFolderButton
            // 
            this.modelArchivesFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modelArchivesFolderButton.Location = new System.Drawing.Point(9, 23);
            this.modelArchivesFolderButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.modelArchivesFolderButton.Name = "modelArchivesFolderButton";
            this.modelArchivesFolderButton.Size = new System.Drawing.Size(766, 26);
            this.modelArchivesFolderButton.TabIndex = 5;
            this.modelArchivesFolderButton.Text = "Browse";
            this.modelArchivesFolderButton.UseVisualStyleBackColor = true;
            this.modelArchivesFolderButton.Click += new System.EventHandler(this.BrowseModelArchivesButton_Click);
            // 
            // modelArchivesFolderPathLabel
            // 
            this.modelArchivesFolderPathLabel.AutoSize = true;
            this.modelArchivesFolderPathLabel.Location = new System.Drawing.Point(40, 52);
            this.modelArchivesFolderPathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.modelArchivesFolderPathLabel.Name = "modelArchivesFolderPathLabel";
            this.modelArchivesFolderPathLabel.Size = new System.Drawing.Size(29, 15);
            this.modelArchivesFolderPathLabel.TabIndex = 9;
            this.modelArchivesFolderPathLabel.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Path:";
            // 
            // modelsFolderGroupBox
            // 
            this.modelsFolderGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modelsFolderGroupBox.Controls.Add(this.modelsFolderButton);
            this.modelsFolderGroupBox.Controls.Add(this.modelsFolderPathLabel);
            this.modelsFolderGroupBox.Controls.Add(this.label6);
            this.modelsFolderGroupBox.Location = new System.Drawing.Point(4, 20);
            this.modelsFolderGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.modelsFolderGroupBox.Name = "modelsFolderGroupBox";
            this.modelsFolderGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.modelsFolderGroupBox.Size = new System.Drawing.Size(784, 73);
            this.modelsFolderGroupBox.TabIndex = 12;
            this.modelsFolderGroupBox.TabStop = false;
            this.modelsFolderGroupBox.Text = "Models Folder (parts, chr, etc.)";
            // 
            // modelsFolderButton
            // 
            this.modelsFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modelsFolderButton.Location = new System.Drawing.Point(9, 22);
            this.modelsFolderButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.modelsFolderButton.Name = "modelsFolderButton";
            this.modelsFolderButton.Size = new System.Drawing.Size(766, 26);
            this.modelsFolderButton.TabIndex = 5;
            this.modelsFolderButton.Text = "Browse";
            this.modelsFolderButton.UseVisualStyleBackColor = true;
            this.modelsFolderButton.Click += new System.EventHandler(this.BrowseModelsFolderButton_Click);
            // 
            // modelsFolderPathLabel
            // 
            this.modelsFolderPathLabel.AutoSize = true;
            this.modelsFolderPathLabel.Location = new System.Drawing.Point(40, 50);
            this.modelsFolderPathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.modelsFolderPathLabel.Name = "modelsFolderPathLabel";
            this.modelsFolderPathLabel.Size = new System.Drawing.Size(29, 15);
            this.modelsFolderPathLabel.TabIndex = 9;
            this.modelsFolderPathLabel.Text = "N/A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 50);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Path:";
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainSplitContainer.Enabled = false;
            this.mainSplitContainer.Location = new System.Drawing.Point(4, 176);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.modelArchivesGroupBox);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.modelReplaceGroupBox);
            this.mainSplitContainer.Size = new System.Drawing.Size(784, 276);
            this.mainSplitContainer.SplitterDistance = 379;
            this.mainSplitContainer.TabIndex = 15;
            // 
            // modelArchivesGroupBox
            // 
            this.modelArchivesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modelArchivesGroupBox.Controls.Add(this.modelArchivesView);
            this.modelArchivesGroupBox.Location = new System.Drawing.Point(3, 3);
            this.modelArchivesGroupBox.Name = "modelArchivesGroupBox";
            this.modelArchivesGroupBox.Size = new System.Drawing.Size(373, 270);
            this.modelArchivesGroupBox.TabIndex = 16;
            this.modelArchivesGroupBox.TabStop = false;
            this.modelArchivesGroupBox.Text = "Model Archives";
            // 
            // modelArchivesView
            // 
            this.modelArchivesView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modelArchivesView.HideSelection = false;
            this.modelArchivesView.Location = new System.Drawing.Point(5, 20);
            this.modelArchivesView.Name = "modelArchivesView";
            this.modelArchivesView.Size = new System.Drawing.Size(362, 244);
            this.modelArchivesView.TabIndex = 0;
            this.modelArchivesView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ModelArchivesView_AfterSelect);
            // 
            // modelReplaceGroupBox
            // 
            this.modelReplaceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modelReplaceGroupBox.Controls.Add(this.modelReplaceView);
            this.modelReplaceGroupBox.Controls.Add(this.modelReplaceButton);
            this.modelReplaceGroupBox.Location = new System.Drawing.Point(3, 3);
            this.modelReplaceGroupBox.Name = "modelReplaceGroupBox";
            this.modelReplaceGroupBox.Size = new System.Drawing.Size(395, 270);
            this.modelReplaceGroupBox.TabIndex = 15;
            this.modelReplaceGroupBox.TabStop = false;
            this.modelReplaceGroupBox.Text = "Model Replacement";
            // 
            // modelReplaceView
            // 
            this.modelReplaceView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modelReplaceView.Location = new System.Drawing.Point(6, 22);
            this.modelReplaceView.Name = "modelReplaceView";
            this.modelReplaceView.Size = new System.Drawing.Size(383, 205);
            this.modelReplaceView.TabIndex = 1;
            this.modelReplaceView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ModelReplaceView_AfterSelect);
            // 
            // modelReplaceButton
            // 
            this.modelReplaceButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modelReplaceButton.Location = new System.Drawing.Point(5, 231);
            this.modelReplaceButton.Name = "modelReplaceButton";
            this.modelReplaceButton.Size = new System.Drawing.Size(385, 34);
            this.modelReplaceButton.TabIndex = 0;
            this.modelReplaceButton.Text = "Replace!";
            this.modelReplaceButton.UseVisualStyleBackColor = true;
            this.modelReplaceButton.Click += new System.EventHandler(this.ModelReplaceButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.statusLabel.Location = new System.Drawing.Point(3, 3);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(21, 15);
            this.statusLabel.TabIndex = 16;
            this.statusLabel.Text = "{0}";
            this.statusLabel.Visible = false;
            // 
            // FSModelUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 457);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.copyrightInfoLabel);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.modelArchivesFolderGroupBox);
            this.Controls.Add(this.modelsFolderGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "FSModelUtility";
            this.Text = "FromSoft Model Utility";
            this.modelArchivesFolderGroupBox.ResumeLayout(false);
            this.modelArchivesFolderGroupBox.PerformLayout();
            this.modelsFolderGroupBox.ResumeLayout(false);
            this.modelsFolderGroupBox.PerformLayout();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.modelArchivesGroupBox.ResumeLayout(false);
            this.modelReplaceGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private TreeView modelArchivesView;
        private GroupBox modelReplaceGroupBox;
        private TreeView modelReplaceView;
        private Button modelReplaceButton;
        private Label statusLabel;
    }
}