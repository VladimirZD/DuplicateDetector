using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.IO;
using System.Diagnostics;

namespace DuplicateDetector
{
    public partial class frmMain : Form
    {
        private FolderAnalyzer _analyzer = null;
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };

        public frmMain()
        {
            InitializeComponent();
            InitLog();
            InitTreeView();
            LoadSettings();
            lowPriorityFolders.Description = "Low Priority folders (if duplicate images found copies in this folder will be selected for removal)";
            foldersToIgnore.Description = "Ignore folders (don't scan and don't remove files)";
            InitAnalyzer();
            UpdateToolbar();
            LogEvent("Program started");
        }

        private void InitAnalyzer()
        {
            _analyzer = new FolderAnalyzer();
            _analyzer.ScanStarted += _analyzer_ScanStarted;
            _analyzer.ScanCanceled += _analyzer_ScanCanceled;
            _analyzer.ScanFinished += _analyzer_ScanFinished;
            _analyzer.Notification += _analyzer_Notification;
        }

        void _analyzer_Notification(string message, EventType type)
        {
            LogEvent(message, type);
        }

        void _analyzer_ScanFinished(bool succes)
        {

            if (succes)
            {
                LogEvent("Scan finished");
                PopulateTreeView();
            }
            else
            {
                LogEvent("Scan failed", EventType.Warring);
            }
        }

        void _analyzer_ScanCanceled()
        {
            LogEvent("Scan canceled");
        }


        private void _analyzer_ScanStarted()
        {
            LogEvent("Scan started");

        }

        private void LoadSettings()
        {
            if (!string.IsNullOrEmpty(DuplicateDetector.Properties.Settings.Default.FolderToScan))
            {
                textFolderToScan.Text = DuplicateDetector.Properties.Settings.Default.FolderToScan;
            }

            if (!string.IsNullOrEmpty(DuplicateDetector.Properties.Settings.Default.FolderForMoving))
            {
                textFolderForMoving.Text = DuplicateDetector.Properties.Settings.Default.FolderForMoving;
            }
            if (!string.IsNullOrEmpty(Properties.Settings.Default.SelectedFilesAction))
            {
                radioDelete.Checked = (Properties.Settings.Default.SelectedFilesAction == "D") ? true : false;
                radioMove.Checked = (Properties.Settings.Default.SelectedFilesAction == "M") ? true : false;
            }

            if (!(DuplicateDetector.Properties.Settings.Default.PriorityFolders == null))
            {
                lowPriorityFolders.SelectedItems = DuplicateDetector.Properties.Settings.Default.PriorityFolders;
            }

            if (!(DuplicateDetector.Properties.Settings.Default.IgnoreFolders == null))
            {
                foldersToIgnore.SelectedItems = DuplicateDetector.Properties.Settings.Default.IgnoreFolders;
            }
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.FolderToScan = textFolderToScan.Text;
            Properties.Settings.Default.FolderForMoving = textFolderForMoving.Text;
            Properties.Settings.Default.SelectedFilesAction = (radioDelete.Checked) ? "D" : "M";
          
            Properties.Settings.Default.PriorityFolders = lowPriorityFolders.SelectedItems;
            Properties.Settings.Default.IgnoreFolders = foldersToIgnore.SelectedItems;
            Properties.Settings.Default.Save();
        }
        private void InitLog()
        {
            lstLog.Clear();
            lstLog.Columns.Add("time", "Time", -2);
            lstLog.Columns.Add("message", "Message", -2);
            lstLog.View = System.Windows.Forms.View.Details;
        }

        private void InitTreeView()
        {
            treeViewResult.Nodes.Clear();

        }

        private void LogEvent(string eventDescription, EventType evetType = EventType.Message)
        {
            Color itemColor = lstLog.ForeColor;
            ListViewItem item = lstLog.Items.Add(DateTime.Now.ToString());
            item.SubItems.Add(eventDescription);
            switch (evetType)
            {
                case EventType.Warring:
                    itemColor = Color.Purple;
                    break;
                case EventType.Error:
                    itemColor = Color.Red;
                    break;
                default:
                    break;
            }
            item.ForeColor = itemColor;
            lstLog.Items[lstLog.Items.Count - 1].EnsureVisible();
            Application.DoEvents();
        }

        private void btnSelectFolderToScan_Click(object sender, EventArgs e)
        {
            if (selectFolderDialog.ShowDialog() == DialogResult.OK)
            {
                textFolderToScan.Text = selectFolderDialog.SelectedPath;
            }
        }


        private void btnStartScan_Click(object sender, EventArgs e)
        {

            if (!_analyzer.IsRunning)
            {
                SaveSettings();
                treeViewResult.Nodes.Clear();
                lstLog.Items.Clear();
                btnStartScan.Image = DuplicateDetector.Properties.Resources.media_stop_red;
                btnStartScan.ToolTipText = "Stop scan";
                Application.DoEvents();
                _analyzer.StartScan(textFolderToScan.Text, Properties.Settings.Default.PriorityFolders, Properties.Settings.Default.IgnoreFolders);
                btnStartScan.Image = DuplicateDetector.Properties.Resources.media_play_green;
                btnStartScan.ToolTipText = "Start scan";

            }
            else
            {
                _analyzer.CancelScan();
            }
        }


        private void PopulateTreeView()
        {
            var items = _analyzer.GetResult();
            foreach (var item in items)
            {
                TreeNode fileNode = treeViewResult.Nodes.Add(item.GetFullPath() + string.Format("------{0} duplicates", item.SameFiles.Count()));
                
                fileNode.Tag = item.GetFullPath();
                foreach (var sameFile in item.SameFiles)
                {
                    TreeNode sameFileNode = fileNode.Nodes.Add(sameFile.GetFullPath());
                    sameFileNode.Tag = sameFile.GetFullPath();
                    sameFileNode.Checked = true;
                }

            }
        }

        private void treeViewResult_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string fileName = e.Node.Tag.ToString();
            if (IsImageFile(fileName))
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    pctPreview.Image  = Image.FromStream(stream);
                }
            }
            else
            {
                pctPreview.Image = Properties.Resources.placeholder;
            }
        }

        private bool IsImageFile(string fileName)
        {
            return ImageExtensions.Contains(Path.GetExtension(fileName).ToUpperInvariant());
        }

        private void btnSelectFolderToMoveFiles_Click(object sender, EventArgs e)
        {
            bool oldSelectNewFolderValue = selectFolderDialog.ShowNewFolderButton;
            selectFolderDialog.ShowNewFolderButton = true;
            if (selectFolderDialog.ShowDialog() == DialogResult.OK)
            {
                textFolderForMoving.Text = selectFolderDialog.SelectedPath;
            }
            selectFolderDialog.ShowNewFolderButton = oldSelectNewFolderValue;
        }

        private void tlExpandAll_Click(object sender, EventArgs e)
        {
            treeViewResult.ExpandAll();
        }

        private void tlColapseAll_Click(object sender, EventArgs e)
        {
            treeViewResult.CollapseAll();
        }

        private void radioMove_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToolbar();
        }

        private void UpdateToolbar()
        {
            btnDeleteFiles.Visible = !radioMove.Checked;
            btnMoveFiles.Visible = radioMove.Checked;
        }

        private void tlOpenFolder_Click(object sender, EventArgs e)
        {
            string path = new FileInfo(treeViewResult.SelectedNode.Tag.ToString()).DirectoryName;
            if (Directory.Exists(path))
            {
                Process.Start(path);
            }
        }

        private void treeViewResult_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewResult.SelectedNode = e.Node;
        }

        private void tlOpenFile_Click(object sender, EventArgs e)
        {

            if (File.Exists(treeViewResult.SelectedNode.Tag.ToString()))
            {
                Process.Start(treeViewResult.SelectedNode.Tag.ToString());
            }
        }

        private void btnMoveFiles_Click(object sender, EventArgs e)
        {
            ArchiveSelectedFiles();
        }

        private void ArchiveSelectedFiles()
        {
            //TODO: Messy delete nodes idea..stupid treeview has no hide node methods..:)
            List<TreeNode> nodesToRemove = new List<TreeNode>();
            if (Directory.Exists(textFolderForMoving.Text))
            {
                foreach (TreeNode item in treeViewResult.Nodes)
                {
                    if (item.Nodes.Count > 0)
                    {
                        foreach (TreeNode childNode in item.Nodes)
                        {
                            if (childNode.Checked)
                            {
                                if (ArchiveFile(childNode.Tag.ToString()))
                                {
                                    nodesToRemove.Add(childNode);
                                }
                            }
                        }
                    }
                    if (item.Checked)
                    {
                        if (ArchiveFile(item.Tag.ToString()))
                        {
                            nodesToRemove.Add(item);
                        }
                    }
                }

                foreach (TreeNode node in nodesToRemove)
                {
                    SmartRemoveNode(node);
                }
            }
            else
            {
                MessageBox.Show(string.Format("Folder {0} doesn't exists!", textFolderForMoving.Text), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlMove_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewResult.SelectedNode;
            
            if (MoveFile(node.Tag.ToString(), textFolderForMoving.Text))
            {
                SmartRemoveNode(node);
            }
        }

        
        private bool ArchiveFile(string file)
        {
            bool retValue = false;
            

            if (radioDelete.Checked)
            {
                retValue = DeleteFile(file);
            }
            else
            {
                retValue = MoveFile(file, textFolderForMoving.Text);
            }
            return retValue;
        }

        private bool DeleteFile(string fileName)
        {
            bool retValue = false;
            if (File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
                LogEvent(string.Format("File {0}  deleted.", fileName));
                retValue = true;
            }
            else
            {
                MessageBox.Show(string.Format("File {0} doesn't exists!", fileName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retValue;
        }

        private bool MoveFile(string file, string destinationFolder)
        {
            bool retValue = false;

            FileInfo fileInfo = new FileInfo(file);

            string fullName = fileInfo.FullName;
            string fileName = fileInfo.Name;
            string newPath = Path.Combine(destinationFolder, fileName);
            
            fileInfo = null;

            if (Directory.Exists(textFolderForMoving.Text))
            {
                if (File.Exists(newPath))
                {
                    newPath = string.Format("{0}_{1}", newPath, DateTime.Now.ToString("yyyyMMdd_HHmmss_fff"));
                }
                System.IO.File.Move(fullName, newPath);
                LogEvent(string.Format("File {0} moved to {1}.", fullName, newPath));
                retValue = true;
            }
            else
            {
                MessageBox.Show(string.Format("Folder {0} doesn't exists!", destinationFolder), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retValue;
        }

        private void tlDelete_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewResult.SelectedNode;
            if (DeleteFile(node.Tag.ToString()))
            {
                SmartRemoveNode(node);
            }

        }

        private void SmartRemoveNode(TreeNode node)
        {
            if (node.Parent.Nodes.Count == 1)
            {
                treeViewResult.Nodes.Remove(node.Parent);
            }
            else
            {
                treeViewResult.Nodes.Remove(node);
            }
        }
    }
}



