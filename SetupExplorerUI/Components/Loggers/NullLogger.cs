using SetupExplorerLibrary.Enum;
using SetupExplorerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerUI.Components.Loggers
{
    public class NullLogger : ILogger
    {
        public void Log(ELogLevel level, string message)
        {
        }
    }
}
