namespace DuplicateDetector
{
    partial class Form1
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node5");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node6");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node7");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node8");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node3", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node9");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node10");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node11");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Node4", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitHorizontal = new System.Windows.Forms.SplitContainer();
            this.splitVertical = new System.Windows.Forms.SplitContainer();
            this.splitLeft = new System.Windows.Forms.SplitContainer();
            this.btnRemovePriorityItem = new System.Windows.Forms.Button();
            this.btnAddPriorityItem = new System.Windows.Forms.Button();
            this.lstPriorityFolders = new System.Windows.Forms.ListView();
            this.path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblPriorityFolderLocations = new System.Windows.Forms.Label();
            this.btnSelectFolderToScan = new System.Windows.Forms.Button();
            this.textFolderToScan = new System.Windows.Forms.TextBox();
            this.lblFolderToScan = new System.Windows.Forms.Label();
            this.treeViewResult = new System.Windows.Forms.TreeView();
            this.pctPreview = new System.Windows.Forms.PictureBox();
            this.lstLog = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolMenuBar = new System.Windows.Forms.ToolStrip();
            this.btnStartScan = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.selectFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitHorizontal)).BeginInit();
            this.splitHorizontal.Panel1.SuspendLayout();
            this.splitHorizontal.Panel2.SuspendLayout();
            this.splitHorizontal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitVertical)).BeginInit();
            this.splitVertical.Panel1.SuspendLayout();
            this.splitVertical.Panel2.SuspendLayout();
            this.splitVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLeft)).BeginInit();
            this.splitLeft.Panel1.SuspendLayout();
            this.splitLeft.Panel2.SuspendLayout();
            this.splitLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPreview)).BeginInit();
            this.toolMenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitHorizontal
            // 
            this.splitHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitHorizontal.Location = new System.Drawing.Point(0, 42);
            this.splitHorizontal.Name = "splitHorizontal";
            this.splitHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitHorizontal.Panel1
            // 
            this.splitHorizontal.Panel1.Controls.Add(this.splitVertical);
            // 
            // splitHorizontal.Panel2
            // 
            this.splitHorizontal.Panel2.Controls.Add(this.lstLog);
            this.splitHorizontal.Size = new System.Drawing.Size(1271, 723);
            this.splitHorizontal.SplitterDistance = 617;
            this.splitHorizontal.TabIndex = 3;
            // 
            // splitVertical
            // 
            this.splitVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitVertical.Location = new System.Drawing.Point(0, 0);
            this.splitVertical.Name = "splitVertical";
            // 
            // splitVertical.Panel1
            // 
            this.splitVertical.Panel1.Controls.Add(this.splitLeft);
            // 
            // splitVertical.Panel2
            // 
            this.splitVertical.Panel2.Controls.Add(this.pctPreview);
            this.splitVertical.Size = new System.Drawing.Size(1271, 617);
            this.splitVertical.SplitterDistance = 600;
            this.splitVertical.TabIndex = 0;
            // 
            // splitLeft
            // 
            this.splitLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitLeft.Location = new System.Drawing.Point(0, 0);
            this.splitLeft.Name = "splitLeft";
            this.splitLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitLeft.Panel1
            // 
            this.splitLeft.Panel1.Controls.Add(this.btnRemovePriorityItem);
            this.splitLeft.Panel1.Controls.Add(this.btnAddPriorityItem);
            this.splitLeft.Panel1.Controls.Add(this.lstPriorityFolders);
            this.splitLeft.Panel1.Controls.Add(this.lblPriorityFolderLocations);
            this.splitLeft.Panel1.Controls.Add(this.btnSelectFolderToScan);
            this.splitLeft.Panel1.Controls.Add(this.textFolderToScan);
            this.splitLeft.Panel1.Controls.Add(this.lblFolderToScan);
            // 
            // splitLeft.Panel2
            // 
            this.splitLeft.Panel2.Controls.Add(this.treeViewResult);
            this.splitLeft.Panel2MinSize = 250;
            this.splitLeft.Size = new System.Drawing.Size(600, 617);
            this.splitLeft.SplitterDistance = 208;
            this.splitLeft.TabIndex = 1;
            // 
            // btnRemovePriorityItem
            // 
            this.btnRemovePriorityItem.AutoSize = true;
            this.btnRemovePriorityItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemovePriorityItem.Image = global::DuplicateDetector.Properties.Resources.folder_delete;
            this.btnRemovePriorityItem.Location = new System.Drawing.Point(497, 39);
            this.btnRemovePriorityItem.Name = "btnRemovePriorityItem";
            this.btnRemovePriorityItem.Size = new System.Drawing.Size(40, 40);
            this.btnRemovePriorityItem.TabIndex = 6;
            this.btnRemovePriorityItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRemovePriorityItem.UseVisualStyleBackColor = true;
            this.btnRemovePriorityItem.Click += new System.EventHandler(this.btnRemovePriorityItem_Click);
            // 
            // btnAddPriorityItem
            // 
            this.btnAddPriorityItem.AutoSize = true;
            this.btnAddPriorityItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPriorityItem.Image = global::DuplicateDetector.Properties.Resources.folder_add;
            this.btnAddPriorityItem.Location = new System.Drawing.Point(451, 39);
            this.btnAddPriorityItem.Name = "btnAddPriorityItem";
            this.btnAddPriorityItem.Size = new System.Drawing.Size(40, 40);
            this.btnAddPriorityItem.TabIndex = 5;
            this.btnAddPriorityItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddPriorityItem.UseVisualStyleBackColor = true;
            this.btnAddPriorityItem.Click += new System.EventHandler(this.btnAddPriorityItem_Click);
            // 
            // lstPriorityFolders
            // 
            this.lstPriorityFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPriorityFolders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.path});
            this.lstPriorityFolders.Location = new System.Drawing.Point(3, 85);
            this.lstPriorityFolders.Name = "lstPriorityFolders";
            this.lstPriorityFolders.Size = new System.Drawing.Size(593, 109);
            this.lstPriorityFolders.TabIndex = 4;
            this.lstPriorityFolders.UseCompatibleStateImageBehavior = false;
            this.lstPriorityFolders.View = System.Windows.Forms.View.Details;
            // 
            // path
            // 
            this.path.Text = "Path";
            this.path.Width = 691;
            // 
            // lblPriorityFolderLocations
            // 
            this.lblPriorityFolderLocations.AutoSize = true;
            this.lblPriorityFolderLocations.Location = new System.Drawing.Point(6, 53);
            this.lblPriorityFolderLocations.Name = "lblPriorityFolderLocations";
            this.lblPriorityFolderLocations.Size = new System.Drawing.Size(439, 13);
            this.lblPriorityFolderLocations.TabIndex = 3;
            this.lblPriorityFolderLocations.Text = "Priority folders (if duplicate images found copies in this folder will not be sel" +
    "ected for removal)";
            // 
            // btnSelectFolderToScan
            // 
            this.btnSelectFolderToScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFolderToScan.AutoSize = true;
            this.btnSelectFolderToScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFolderToScan.Image = global::DuplicateDetector.Properties.Resources.Folder;
            this.btnSelectFolderToScan.Location = new System.Drawing.Point(557, 6);
            this.btnSelectFolderToScan.Name = "btnSelectFolderToScan";
            this.btnSelectFolderToScan.Size = new System.Drawing.Size(40, 40);
            this.btnSelectFolderToScan.TabIndex = 2;
            this.btnSelectFolderToScan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSelectFolderToScan.UseVisualStyleBackColor = true;
            this.btnSelectFolderToScan.Click += new System.EventHandler(this.btnSelectFolderToScan_Click);
            // 
            // textFolderToScan
            // 
            this.textFolderToScan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textFolderToScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFolderToScan.Location = new System.Drawing.Point(85, 17);
            this.textFolderToScan.Name = "textFolderToScan";
            this.textFolderToScan.Size = new System.Drawing.Size(466, 20);
            this.textFolderToScan.TabIndex = 1;
            // 
            // lblFolderToScan
            // 
            this.lblFolderToScan.AutoSize = true;
            this.lblFolderToScan.Location = new System.Drawing.Point(6, 20);
            this.lblFolderToScan.Name = "lblFolderToScan";
            this.lblFolderToScan.Size = new System.Drawing.Size(80, 13);
            this.lblFolderToScan.TabIndex = 0;
            this.lblFolderToScan.Text = "Folder to scan: ";
            // 
            // treeViewResult
            // 
            this.treeViewResult.CheckBoxes = true;
            this.treeViewResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewResult.FullRowSelect = true;
            this.treeViewResult.Location = new System.Drawing.Point(0, 0);
            this.treeViewResult.Name = "treeViewResult";
            treeNode1.Name = "Node5";
            treeNode1.Text = "Node5";
            treeNode2.Name = "Node6";
            treeNode2.Text = "Node6";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Node0";
            treeNode4.Name = "Node2";
            treeNode4.Text = "Node2";
            treeNode5.Name = "Node7";
            treeNode5.Text = "Node7";
            treeNode6.Name = "Node8";
            treeNode6.Text = "Node8";
            treeNode7.Name = "Node3";
            treeNode7.Text = "Node3";
            treeNode8.Name = "Node9";
            treeNode8.Text = "Node9";
            treeNode9.Name = "Node10";
            treeNode9.Text = "Node10";
            treeNode10.Name = "Node11";
            treeNode10.Text = "Node11";
            treeNode11.Name = "Node4";
            treeNode11.Text = "Node4";
            this.treeViewResult.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode7,
            treeNode11});
            this.treeViewResult.Size = new System.Drawing.Size(600, 405);
            this.treeViewResult.TabIndex = 1;
            this.treeViewResult.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewResult_AfterSelect);
            // 
            // pctPreview
            // 
            this.pctPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctPreview.Location = new System.Drawing.Point(0, 0);
            this.pctPreview.Name = "pctPreview";
            this.pctPreview.Size = new System.Drawing.Size(667, 617);
            this.pctPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctPreview.TabIndex = 0;
            this.pctPreview.TabStop = false;
            this.pctPreview.WaitOnLoad = true;
            // 
            // lstLog
            // 
            this.lstLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLog.FullRowSelect = true;
            this.lstLog.Location = new System.Drawing.Point(0, 0);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(1271, 102);
            this.lstLog.TabIndex = 1;
            this.lstLog.UseCompatibleStateImageBehavior = false;
            this.lstLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 114;
            // 
            // toolMenuBar
            // 
            this.toolMenuBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartScan,
            this.toolStripButton3});
            this.toolMenuBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolMenuBar.Location = new System.Drawing.Point(0, 0);
            this.toolMenuBar.Name = "toolMenuBar";
            this.toolMenuBar.Size = new System.Drawing.Size(1271, 39);
            this.toolMenuBar.Stretch = true;
            this.toolMenuBar.TabIndex = 5;
            this.toolMenuBar.Text = "toolStrip1";
            // 
            // btnStartScan
            // 
            this.btnStartScan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStartScan.Image = global::DuplicateDetector.Properties.Resources.media_play_green;
            this.btnStartScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartScan.Name = "btnStartScan";
            this.btnStartScan.Size = new System.Drawing.Size(36, 36);
            this.btnStartScan.Text = "toolStripButton4";
            this.btnStartScan.ToolTipText = "Start scan";
            this.btnStartScan.Click += new System.EventHandler(this.btnStartScan_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // selectFolderDialog
            // 
            this.selectFolderDialog.ShowNewFolderButton = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1271, 766);
            this.Controls.Add(this.toolMenuBar);
            this.Controls.Add(this.splitHorizontal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitHorizontal.Panel1.ResumeLayout(false);
            this.splitHorizontal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitHorizontal)).EndInit();
            this.splitHorizontal.ResumeLayout(false);
            this.splitVertical.Panel1.ResumeLayout(false);
            this.splitVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitVertical)).EndInit();
            this.splitVertical.ResumeLayout(false);
            this.splitLeft.Panel1.ResumeLayout(false);
            this.splitLeft.Panel1.PerformLayout();
            this.splitLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitLeft)).EndInit();
            this.splitLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctPreview)).EndInit();
            this.toolMenuBar.ResumeLayout(false);
            this.toolMenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitHorizontal;
        private System.Windows.Forms.ListView lstLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.SplitContainer splitVertical;
        private System.Windows.Forms.PictureBox pctPreview;
        private System.Windows.Forms.ToolStrip toolMenuBar;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton btnStartScan;
        private System.Windows.Forms.SplitContainer splitLeft;
        private System.Windows.Forms.TreeView treeViewResult;
        private System.Windows.Forms.Button btnSelectFolderToScan;
        private System.Windows.Forms.TextBox textFolderToScan;
        private System.Windows.Forms.Label lblFolderToScan;
        private System.Windows.Forms.FolderBrowserDialog selectFolderDialog;
        private System.Windows.Forms.Label lblPriorityFolderLocations;
        private System.Windows.Forms.Button btnRemovePriorityItem;
        private System.Windows.Forms.Button btnAddPriorityItem;
        private System.Windows.Forms.ListView lstPriorityFolders;
        private System.Windows.Forms.ColumnHeader path;
    }
}

