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
    public partial class Form1 : Form
    {
        private FolderAnalyzer _analyzer = null;
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };

        public Form1()
        {
            InitializeComponent();
            InitLog();
            InitTreeView();
            LoadSettings();
            RefreshPriorityItemsButtons();
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
            LogEvent(message,type);
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
                LogEvent("Scan failed",EventType.Warring);
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
                textFolderToScan.Text=DuplicateDetector.Properties.Settings.Default.FolderToScan;
            }

            if (!string.IsNullOrEmpty(DuplicateDetector.Properties.Settings.Default.FolderForMoving))
            {
                textFolderForMoving.Text = DuplicateDetector.Properties.Settings.Default.FolderForMoving;
            }
            if (!string.IsNullOrEmpty(Properties.Settings.Default.SelectedFilesAction))
            {
                radioDelete.Checked =  (Properties.Settings.Default.SelectedFilesAction == "D") ? true : false;
                radioMove.Checked = (Properties.Settings.Default.SelectedFilesAction == "M") ? true : false;
            }
            if (!(DuplicateDetector.Properties.Settings.Default.PriorityFolders==null))
            {
                var items = DuplicateDetector.Properties.Settings.Default.PriorityFolders;
                foreach(string item in items)
                {
                    lstPriorityFolders.Items.Add(item);
                }
            }
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.FolderToScan = textFolderToScan.Text;
            Properties.Settings.Default.FolderForMoving = textFolderForMoving.Text;
            Properties.Settings.Default.SelectedFilesAction = (radioDelete.Checked) ? "D" : "M";
            StringCollection priorityFolders = new StringCollection();
            foreach (ListViewItem item in lstPriorityFolders.Items)
            {
                priorityFolders.Add(item.Text);
            }
            Properties.Settings.Default.PriorityFolders = priorityFolders;
            Properties.Settings.Default.Save();
        }
        private void InitLog()
        {
            lstLog.Clear();
            lstLog.Columns.Add("time", "Time",-2);
            lstLog.Columns.Add("message", "Message",-2);
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
                    itemColor=Color.Purple;
                    break;
                case EventType.Error:
                    itemColor=Color.Red;
                    break;
                default:
                    break;
            }

            item.ForeColor = itemColor;
            lstLog.Items[lstLog.Items.Count - 1].EnsureVisible();
        }

        private void btnSelectFolderToScan_Click(object sender, EventArgs e)
        {
            if (selectFolderDialog.ShowDialog() == DialogResult.OK)
            {
                textFolderToScan.Text = selectFolderDialog.SelectedPath;
            }
        }
              

        private void btnRemovePriorityItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstPriorityFolders.SelectedItems)
            {
                lstPriorityFolders.Items.Remove(item);
            }
            RefreshPriorityItemsButtons();
        }

        private void btnAddPriorityItem_Click(object sender, EventArgs e)
        {
            if (selectFolderDialog.ShowDialog() == DialogResult.OK)
            {
                lstPriorityFolders.Items.Add(selectFolderDialog.SelectedPath);
            }
            RefreshPriorityItemsButtons();
        }

        private void RefreshPriorityItemsButtons()
        {
            btnRemovePriorityItem.Enabled = (lstPriorityFolders.Items.Count != 0);
        }

        private void btnStartScan_Click(object sender, EventArgs e)
        {

            if (!_analyzer.IsRunning)
            {
                
                SaveSettings();
                treeViewResult.Nodes.Clear();
                btnStartScan.Image = DuplicateDetector.Properties.Resources.media_stop_red;
                btnStartScan.ToolTipText = "Stop scan";
                Application.DoEvents();
                _analyzer.StartScan(textFolderToScan.Text, Properties.Settings.Default.PriorityFolders);
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
                TreeNode fileNode =  treeViewResult.Nodes.Add(item.GetFullPath()+string.Format("------{0} duplicates",item.SameFiles.Count()));
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
                pctPreview.Image = Image.FromFile(fileName);
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
            if (Directory.Exists(path));
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
            
            if (File.Exists(treeViewResult.SelectedNode.Tag.ToString()));
            {
                Process.Start(treeViewResult.SelectedNode.Tag.ToString());
            }
        }

        
    }
}



