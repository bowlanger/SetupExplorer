using SetupExplorerLibrary.Components.Handlers;
using SetupExplorerLibrary.Enum;
using SetupExplorerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Components.Parsers
{
    public class SetupFileHelper
    {
        private readonly ILogger _logger;

        private XPathHandler _xH;
        private string _xPathRoot = "";
        public SetupFileHelper(XPathHandler xH, Config cfg, ILogger logger)
        {
            _logger = logger;
            _logger.Log(ELogLevel.Debug, $@"{this.GetType().Name} > Constructor(logger)");

            _xH = xH;
            _xPathRoot = cfg.XPathRoot;
        }

        public void Configure(XPathHandler xh, string xPathRoot)
        {
            _xH = xh;
            _xPathRoot = xPathRoot;
        }

        public List<string> GetSetupNotes()
        {
            var query = $@"{_xPathRoot}node()[count(preceding-sibling::h2)=count({_xPathRoot}h2)]";
            var notes = new List<string>();
            foreach (var xr in _xH.SelectRecords(query).Where(x => x.Name != "br"))
            {
                notes.Add(xr.Value);
            }
            return notes;
        }
    }
}
