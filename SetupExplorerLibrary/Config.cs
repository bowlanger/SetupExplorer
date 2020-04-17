using SetupExplorerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary
{
    public class Config : IConfigLibrary
    {
        public bool Debug { get; set; }
        public string OutputFolder { get; set; }
        public string BaseFolder { get; set; }
        public string XPathRoot { get; }

        public ILogger Logger { get; set; }

        public void UseLogger(ILogger logger)
        {
            Logger = logger;
        }

        public Dictionary<string, string> Templates = new Dictionary<string, string>();

        public Dictionary<string, string> XPathQueries = new Dictionary<string, string>();

        public Config()
        {

            XPathRoot = "/html[1]/body[1]/"; // par defaut c'est <-

            Templates.Add("audirs3lms", "TCN");
            // QUESTION faire un dictionnaire inverse Templates => TCN  => { audirs3lms, ... }
            //                                                     SN   => { fr500, ... }

            XPathQueries.Add(
                "GetSetupNotes",
                $@"{XPathRoot}node()[count(preceding - sibling::h2) = count({XPathRoot}h2)]"
                );
            XPathQueries.Add(
                "GetSetupNode[%id%]",
                $@"{XPathRoot}node()[count(preceding-sibling::h2)=%id% and not(*[not(h2)])]"
                );
        }
    }
}