using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities
{
    public class Property
    {
        public string Path { get; set; }
        public SetupNode SetupNode { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
        
        // internal string PropertyXPath
        public string PropertyXPath { get; set; }
        public string ValuesXPath { get; set; }

        public Property(SetupNode sn, string pXPath, string pVXPath, string pPath, string pLabel, string pValue)
        {
            SetupNode = sn;
            PropertyXPath = pXPath;
            ValuesXPath = pVXPath;
            Path = pPath;
            Label = pLabel;
            Value = pValue;
        }
    }
}
