using SetupExplorerLibrary.Entities.Setup;
using SetupExplorerLibrary.Enum;
using SetupExplorerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Components.Handlers
{
    public class SetupHandler
    {
        private readonly ILogger logger;

        public SetupHandler(ILogger logger)
        {
            this.logger = logger;
            this.logger.Log("INFO | FileHandler > _constructor(logger)");
        }

        public SetupFile Create(string name)
        {
            var fileInfo = new FileInfo(name);
            var directory = fileInfo.Directory;
            var size = fileInfo.Length;
            var type = GetFileType(name);
            var ext = fileInfo.Extension;
            return new SetupFile(name, size, type, ext);
        }

        private EFileType GetFileType(string name)
        {
            return EFileType.Unknown;
        }
    }
}
