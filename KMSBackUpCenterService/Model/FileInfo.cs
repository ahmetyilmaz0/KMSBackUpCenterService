using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMSBackUpCenterService.Model
{
    public class FileInfo
    {
        //
        public Guid CustomerID { get; set; }
        //
        public string Name { get; set; }
        public string Extension { get; set; }
        public DateTime? CreationTime { get; set; }
        public string Directory { get; set; }
        public DateTime? LastAccessTime { get; set; }
        public DateTime? LastWriteTime { get; set; }
        public string FileMD5 { get; set; }
        public string FileSHA256 { get; set; }     
        public long Lenght { get; set; }
        public byte[] File { get; set; }
    }
}