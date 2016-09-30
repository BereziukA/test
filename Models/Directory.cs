using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication14.Models
{
    public class Directory
    {
        public List<DirectoryItem> Files { get; set; } 
        public List<DirectoryItem> Directories { get; set; } 
        public int SmallFilesCount { get; set; }
        public int MediumFilesCount { get; set; }
        public int LargeFilesCount { get; set; }
        public string Path { get; set; }
    }
}