using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateDetector
{
    public enum EventType
    {
        Message = 0,
        Warring = 1,
        Error = 2
    }

    class FolderAnalyzer
    {

        public delegate void ScanStartedHandler();
        public delegate void ScanCanceledHandler();
        public delegate void ScanFinishedHandler(bool succes);
        public delegate void NotificationEventHandler(string message, EventType type);

        public event ScanStartedHandler ScanStarted;
        public event ScanCanceledHandler ScanCanceled;
        public event ScanFinishedHandler ScanFinished;
        public event NotificationEventHandler Notification;

        private List<MyFile> _files;
        private List<MyFile> _processedFiles = new List<MyFile>();


        public FolderAnalyzer()
        {
            _files = new List<MyFile>();
            this.IgnoreFolders = new StringCollection();
        }

        public bool IsRunning { get; set; }
        public string FolderToScan { get; set; }
        public StringCollection PriorityFolders { get; set; }
        public StringCollection IgnoreFolders{ get; set; }
        public bool CancelInProgress { get; set; }

        public List<MyFile> GetResult()
        {
            return _processedFiles;
        }

        private void OnScanStarted()
        {
            this.IsRunning = true;
            if (ScanStarted != null)
            {
                ScanStarted();
            }
        }

        private void OnScanCanceled()
        {
            this.IsRunning = false;
            this.CancelInProgress = false;
            if (ScanCanceled != null)
            {
                ScanCanceled();
            }
        }

        private void OnScanFinished(bool succes)
        {
            this.IsRunning = false;
            if (ScanFinished != null)
            {
                ScanFinished(succes);
            }
        }

        private void OnNotification(string message, EventType type = EventType.Message)
        {
            //error and no listeners
            if (Notification != null)
            {
                Notification(message, type);
            }
            else
            {
                if (type == EventType.Error)
                {
                    throw new Exception(message);
                }
            }
        }


        public bool StartScan(string folder, StringCollection priorityFolders, StringCollection ignoreFolders)
        {
            DateTime startTime = DateTime.Now;
            bool retValue = false;
            this.FolderToScan = folder;
            this.PriorityFolders = priorityFolders;
            this.IgnoreFolders = ignoreFolders;
            _files.Clear();
            _processedFiles.Clear();
            if (ValidateFolders())
            {
                OnNotification("Validation succesfull");
                retValue = true;
                OnScanStarted();
                ScanFolders(this.FolderToScan);



                OnNotification(string.Format("Total files found {0}", _files.Count));
                AnalyzeFiles();
                retValue = true;
            }
            else
            {
                OnNotification("Validation failed", EventType.Error);
            }
            TimeSpan duration = DateTime.Now - startTime;
            OnNotification(string.Format("Scan duration {0} hours {1} minutes {2} seconds", duration.Hours, duration.Minutes, duration.Seconds));
            if (this.CancelInProgress)
            {
                OnScanCanceled();
            }
            else
            {
                OnScanFinished(retValue);
            }
            return retValue;
        }

        private bool ValidateFolders()
        {
            bool retValue = true;
            if (!Directory.Exists(this.FolderToScan))
            {
                retValue = false;
                this.OnNotification(string.Format("Folder {0} doesn't exists!", this.FolderToScan), EventType.Error);
            }

            foreach (string folder in this.PriorityFolders)
            {
                if (!Directory.Exists(folder))
                {
                    retValue = false;
                    this.OnNotification(string.Format("Folder {0} doesn't exists!", folder), EventType.Error);
                }

            }
            return retValue;
        }


        private void AnalyzeFiles()
        {
            //TODO: implement async...for md5hash
            OnNotification(string.Format("File compare started! {0} files to process", _files.Count));
            int duplicatesCount = 0;
            while (_files.Count() > 0)
            {
                List<MyFile> fileGroup = new List<MyFile>();
                MyFile file = _files[0];

                fileGroup.Add(file);
                _files.Remove(file);
                MyFile originalFile;
                var duplicates = _files.Where(item => item.FileName == file.FileName && item.Size == file.Size && item.DateModified == file.DateModified).ToList<MyFile>();
                if (duplicates.Count > 0)
                {
                    _files.RemoveAll(item => item.FileName == file.FileName && item.Size == file.Size && item.DateModified == file.DateModified);
                    fileGroup.AddRange(duplicates);
                    originalFile = fileGroup.Where(item => !item.IsInLowPriorityFolder).FirstOrDefault();
                    if (originalFile == null)
                    {
                        originalFile = fileGroup.OrderByDescending(item => item.DateModified).FirstOrDefault();
                    }
                    fileGroup.Remove(originalFile);
                    if (fileGroup.Count > 0)
                    {
                        originalFile.SameFiles = fileGroup;
                        duplicatesCount = duplicatesCount + fileGroup.Count();
                    }
                    _processedFiles.Add(originalFile);
                    if (this.CancelInProgress) break;
                }
            }
            OnNotification(string.Format("Found {0} files with duplicates and total {1} duplicates", _processedFiles.Count(), duplicatesCount));

        }

        public void CancelScan()
        {
            this.CancelInProgress = true;
            OnNotification("Canceling scan");
        }

        public void ScanFolders(string folderToScan)
        {
            try
            {
                DirectoryInfo dirInfo =null;
                StringCollection foldersToIgnore = new StringCollection();
                foreach (var item in IgnoreFolders)
                {
                    foldersToIgnore.Add(item);
                    dirInfo = new DirectoryInfo(item);
                    var items = dirInfo.EnumerateDirectories("*.*",SearchOption.AllDirectories);
                    foldersToIgnore.AddRange(items.Select(f => f.FullName).ToArray<string>());
                }
                
                dirInfo = new DirectoryInfo(folderToScan);
                
                var result = from file in dirInfo.EnumerateFiles("*.*", SearchOption.AllDirectories)
                             where (!file.Attributes.HasFlag(FileAttributes.System) && !foldersToIgnore.Contains(file.DirectoryName))
                             select new MyFile
                                 (
                                    file.Name, 
                                    file.DirectoryName, 
                                    file.Length, 
                                    file.LastWriteTime, 
                                    PriorityFolders.Contains(file.DirectoryName)
                                 );

                _files = result.ToList<MyFile>();
                OnNotification(string.Format("{0} files found.", _files.Count()));
            }
            catch (Exception ex)
            {
                OnNotification(ex.ToString(), EventType.Error);
            }
        }
    }
}






