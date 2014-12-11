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
        public delegate void NotificationEventHandler (string message,EventType type);
        
        public event ScanStartedHandler ScanStarted;
        public event ScanCanceledHandler ScanCanceled;
        public event ScanFinishedHandler ScanFinished;
        public event NotificationEventHandler Notification;

        private List<MyFile> _files;
        private List<MyFile> _processedFiles = new List<MyFile>();

        public FolderAnalyzer ()
        {
            _files = new List<MyFile>();
        }
        
        public bool IsRunning  { get; set; }
        public string FolderToScan { get; set; }
        public StringCollection PriorityFolders { get; set; }
        
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

        private void OnNotification(string message,EventType type=EventType.Message)
        {
            //ako je  error i nitko ne sluša exception
            if (Notification != null)
            {
                Notification(message,type);
            }
            else
            {
                if (type==EventType.Error)
                {
                    throw new Exception(message);
                }
            }
        }

        
        public bool StartScan(string folder,StringCollection priorityFolders)
        {
            bool retValue = false;
            this.FolderToScan = folder;
            this.PriorityFolders = priorityFolders;
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
                OnNotification("Validation failed",EventType.Error);
            }
            OnScanFinished(retValue);
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

            foreach(string folder in this.PriorityFolders)
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
            //TODO: implement async...
            while (_files.Count()>0)
            {
                List<MyFile> fileGroup = new List<MyFile>();
                MyFile file = _files[0];
                
                fileGroup.Add(file);
                _files.Remove(file);
                 var duplicates = _files.Where(item => item.FileName == file.FileName && item.Size == file.Size &&  item.DateModified == file.DateModified).ToList<MyFile>();
                 if (duplicates.Count > 0)
                 {
                     _files.RemoveAll(item => item.FileName == file.FileName && item.Size == file.Size && item.DateModified == file.DateModified);
                     fileGroup.AddRange(duplicates);
                     var originalFile = fileGroup.Where(item => item.IsInPriorityFolder).FirstOrDefault();
                     if (originalFile != null)
                     {
                         fileGroup.Remove(originalFile);
                     }
                     else
                     {
                         originalFile = fileGroup[0];
                         fileGroup.Remove(originalFile);
                     }
                     if (fileGroup.Count > 0)
                     {
                         originalFile.SameFiles = fileGroup;
                     }
                     _processedFiles.Add(originalFile);
                 }
            }
          OnNotification(string.Format("Found {0} files with duplicates", _processedFiles.Count()));
            
        }

        public void CancelScan()
        {
            //TODO: implement when adding async scan
        }

        public  void ScanFolders(string folderToScan)
        {
            try
            {
                foreach (string folder in Directory.GetDirectories(folderToScan))
                {
                    foreach (string file in Directory.GetFiles(folder))
                    
                    {
                        FileInfo fi = new FileInfo(file);
                        if (!fi.Attributes.HasFlag(FileAttributes.System))
                        {
                            MyFile fileData = new MyFile(fi.Name, folder, fi.Length, fi.LastWriteTime);
                            fileData.IsInPriorityFolder = PriorityFolders.Contains(fileData.Path);
                            _files.Add(fileData);
                        }
                    }
                    OnNotification(string.Format("{0} files found in folder \"{1}\"!", Directory.GetFiles(folder).Count(), folder));
                    ScanFolders(folder);
                }
            }
            catch (Exception ex)
            {
                OnNotification(ex.ToString(), EventType.Error);
            }
        }
    }
}






