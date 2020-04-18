using SetupExplorerLibrary.Entities;
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

        public Dictionary<string, XPathQuery> XPathQueries = new Dictionary<string, XPathQuery>();

        public Config()
        {

            XPathRoot = "/html[1]/body[1]/"; // par defaut c'est <-

            Templates.Add("audirs3lms", "TCN");
            // QUESTION faire un dictionnaire inverse Templates => TCN  => { audirs3lms, ... }
            //                                                     SN   => { fr500, ... }


            /*
             * 
                // XPathQuery GetAllNodes { _xpr }
                // XPathQuery GetSetupNotes { _xpr }
                // XPathQuery GetSetupSummary { _xpr }
                // XPathQuery GetSetupNodeContent { _xpr, sn.Id }
             * 
             * 
             * */
            XPathQueries.Add("GetAllNodes", new XPathQuery("GetAllNodes", "{0}node()"));
            XPathQueries.Add("GetSetupNotes", new XPathQuery(
                "GetSetupNotes",
                "{0}node()[count(preceding-sibling::h2)=count({0}h2)]"
                ));
            XPathQueries.Add("GetSetupSummary", new XPathQuery("GetSetupSummary", "{0}h2[1]/text()"));
            /* 
            XPathQueries.Add("GetSetupNode", new XPathQuery(
                "GetSetupNode",
                "{0}node()[count(preceding-sibling::h2)={1} and not(*[not(h2)])]"
                ));
            */
            XPathQueries.Add("GetSetupNodeContent", new XPathQuery(
                "GetSetupNodeContent",
                "{0}node()[count(preceding-sibling::h2)={1} and not(*[not(h2)])]"
                ));


        }
    }
}