using SetupExplorerLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SetupExplorerLibrary.Entities.Setup
{
    public class SetupFile
    {
        public string Name;
        public long Size;
        public EFileType FileType;
        public string Ext;

        public SetupFile()
        {
            Name = "";
            Size = 0;
            FileType = EFileType.Unknown;
            Ext = "";
        }

        public SetupFile(string name)
        {
            Name = name;
            Size = 0;
            FileType = EFileType.Unknown;
            Ext = "";
        }

        public SetupFile(string name, long size, EFileType fileType, string ext)
        {
            Name = name;
            Size = size;
            FileType = fileType;
            Ext = ext;
        }
    }
}
