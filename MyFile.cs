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
        public List<MyFile> SameFiles{ get; set; }

        
        public MyFile (string fileName,string path,long size,DateTime dateModified)
        {
            this.FileName = fileName;
            this.Path = path;
            this.Size = size;
            this.DateModified = dateModified;
        }



        //public int Compare(object x, object y)
        //{
            
        //    int retValue = 0;
        //    MyFile f1 = (MyFile)x;
        //    MyFile f2 = (MyFile)y;

        //    retValue = f1.FileName.CompareTo(f2.FileName);
        //    return retValue;
        //}

    }
}

