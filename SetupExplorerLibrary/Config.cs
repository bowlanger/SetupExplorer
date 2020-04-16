using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary
{
    internal class Config
    {
        public bool Debug { get; } = true;
        public string OutputFolder { get; }
        public string BaseFolder { get; }
        public string XPathRoot { get; }

        public Dictionary<string, string> Templates = new Dictionary<string, string>();

        public Dictionary<string, string> XPathQueries = new Dictionary<string, string>();

        public Config()
        {
            OutputFolder = @"D:\Yoann\";
            BaseFolder = @"E:\Temp\iRacing\SetupExplorer\setups\";
            XPathRoot = "/html[1]/body[1]/";

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