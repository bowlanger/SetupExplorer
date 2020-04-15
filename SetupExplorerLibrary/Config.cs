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
        public string OutputDir { get; } = @"D:\Yoann\";
        public string XPathRoot { get; } = "/html[1]/body[1]/";

        public Dictionary<string, string> Templates = new Dictionary<string, string>();

        public Config()
        {
            Templates.Add("audirs3lms", "TCN");
            // QUESTION faire un dictionnaire inverse Templates => TCN  => { audirs3lms, ... }
            //                                                     SN   => { fr500, ... }
        }
    }
}