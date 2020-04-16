using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Interfaces
{
    public interface ILogger
    {
        void Debug(string message, Enum.ELogLevel level = Enum.ELogLevel.L0);
        void Error(string message, Enum.ELogLevel level = Enum.ELogLevel.L0);
        void Warn(string message, Enum.ELogLevel level = Enum.ELogLevel.L0);
        void Notice(string message, Enum.ELogLevel level = Enum.ELogLevel.L0);
        void Info(string message, Enum.ELogLevel level = Enum.ELogLevel.L0);
    }
}
