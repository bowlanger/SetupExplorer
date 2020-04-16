using SetupExplorerLibrary.Enum;
using SetupExplorerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerUI.Components.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(ELogLevel level, string message)
        {
            Console.WriteLine($"{(int)level} {level} | {message}");
        }
    }
}
