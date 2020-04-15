using SetupExplorerLibrary.Components.Handlers;
using SetupExplorerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Components.Parsers
{
    public class SetupFileParser
    {
        private readonly ILogger _logger;
        public XPathHandler XPathHandler { get; set; }
        public SetupFileParser(ILogger logger)
        {
            _logger = logger;
            _logger.Info($@"{this.GetType().Name} > Constructor(logger)");
        }
    }
}
