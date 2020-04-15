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
        public string OutputDir { get; }
        public string XPathRoot { get; }

        public Dictionary<string, string> Templates = new Dictionary<string, string>();

        public Dictionary<string, string> XPathQueries = new Dictionary<string, string>();

        public Config()
        {
            OutputDir = @"D:\Yoann\";
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