using SetupExplorerLibrary.Enum;
using SetupExplorerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerUI
{
    public class NullLogger : ILogger
    {
        public void Debug(string message, ELogLevel level = ELogLevel.L0)
        {
        }

        public void Error(string message, ELogLevel level = ELogLevel.L0)
        {
        }

        public void Info(string message, ELogLevel level = ELogLevel.L0)
        {
        }

        public void Log(string message)
        {
        }

        public void Notice(string message, ELogLevel level = ELogLevel.L0)
        {
        }

        public void Warn(string message, ELogLevel level = ELogLevel.L0)
        {
        }
    }
}
