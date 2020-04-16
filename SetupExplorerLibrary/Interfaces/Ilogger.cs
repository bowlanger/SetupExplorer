using SetupExplorerLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Interfaces
{
    public interface ILogger
    {
        void Log(ELogLevel level, string message);
    }
}
