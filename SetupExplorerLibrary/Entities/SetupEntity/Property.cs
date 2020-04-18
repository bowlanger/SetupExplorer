using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.SetupEntity
{
    public class Property
    {
        public string Path { get; set; }
        public Node Node { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
        
        // internal string PropertyXPath
        public string PropertyXPath { get; set; }
        public string ValuesXPath { get; set; }

        public Property(Node sn, string pXPath, string pVXPath, string pPath, string pLabel, string pValue)
        {
            Node = sn;
            PropertyXPath = pXPath;
            ValuesXPath = pVXPath;
            Path = pPath;
            Label = pLabel;
            Value = pValue;
        }
    }
}
