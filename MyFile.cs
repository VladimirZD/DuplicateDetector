using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateDetector
{
    public class MyFile  //: IComparer
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public DateTime DateModified { get; set; }
        public List<MyFile> SameFiles { get; set; }
        public bool IsInLowPriorityFolder { get; set; }


        public MyFile(string fileName, string path, long size, DateTime dateModified, bool isInLowPriorityFolder)
        {
            this.FileName = fileName;
            this.Path = path;
            this.Size = size;
            this.DateModified = dateModified;
            this.IsInLowPriorityFolder = isInLowPriorityFolder;
        }

        public string GetFullPath()
        {
            return string.Format(@"{0}\{1}", this.Path, this.FileName);
        }


        //    Calculate MD5
        //      using (var md5 = MD5.Create())
        //{
        //using (var stream = File.OpenRead(filename))
        //{
        //    return md5.ComputeHash(stream);
        //     *return  BitConverter.ToString(md5.ComputeHash(stream)).Replace("-","").ToLower();
        //}

    }

}



