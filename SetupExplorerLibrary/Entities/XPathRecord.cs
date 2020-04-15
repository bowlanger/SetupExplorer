using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities
{
    public class XPathRecord
    {
        public string XPath { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public XPathRecord(string xpath, string lastNodeName, string value)
        {
            XPath = xpath;
            Name = lastNodeName;
            Value = value;
        }
    }
}
