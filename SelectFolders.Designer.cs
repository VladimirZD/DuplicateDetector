namespace DuplicateDetector
{
    partial class SelectFolders
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstPriorityFolders = new System.Windows.Forms.ListView();
            this.path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblPriorityFolderLocations = new System.Windows.Forms.Label();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.selectFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // lstPriorityFolders
            // 
            this.lstPriorityFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPriorityFolders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.path});
            this.lstPriorityFolders.Location = new System.Drawing.Point(2, 43);
            this.lstPriorityFolders.Name = "lstPriorityFolders";
            this.lstPriorityFolders.Size = new System.Drawing.Size(783, 154);
            this.lstPriorityFolders.TabIndex = 11;
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
            this.lblPriorityFolderLocations.Location = new System.Drawing.Point(3, 11);
            this.lblPriorityFolderLocations.Name = "lblPriorityFolderLocations";
            this.lblPriorityFolderLocations.Size = new System.Drawing.Size(80, 13);
            this.lblPriorityFolderLocations.TabIndex = 10;
            this.lblPriorityFolderLocations.Text = "Select folders...";
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveItem.AutoSize = true;
            this.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItem.Image = global::DuplicateDetector.Properties.Resources.folder_delete;
            this.btnRemoveItem.Location = new System.Drawing.Point(739, 1);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(40, 40);
            this.btnRemoveItem.TabIndex = 13;
            this.btnRemoveItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.AutoSize = true;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Image = global::DuplicateDetector.Properties.Resources.folder_add;
            this.btnAddItem.Location = new System.Drawing.Point(693, 1);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(40, 40);
            this.btnAddItem.TabIndex = 12;
            this.btnAddItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // selectFolderDialog
            // 
            this.selectFolderDialog.ShowNewFolderButton = false;
            // 
            // SelectFolders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.lstPriorityFolders);
            this.Controls.Add(this.lblPriorityFolderLocations);
            this.Name = "SelectFolders";
            this.Size = new System.Drawing.Size(788, 200);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.ListView lstPriorityFolders;
        private System.Windows.Forms.ColumnHeader path;
        private System.Windows.Forms.Label lblPriorityFolderLocations;
        private System.Windows.Forms.FolderBrowserDialog selectFolderDialog;
    }
}
