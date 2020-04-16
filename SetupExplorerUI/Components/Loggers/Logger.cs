﻿using SetupExplorerLibrary.Enum;
using SetupExplorerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerUI.Components.Loggers
{
    public class Logger : ILogger
    {
        public List<ILogger> Loggers { get; set; } = new List<ILogger>();

        public void Log(ELogLevel level, string message)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(level, message);
            }
        }
    }
}
