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
        public string Label { get; set; }
        public string Value { get; set; }
        
        public string PropertyXPath { get; set; }
        public string ValuesXPath { get; set; }

        public Property(string pXPath, string pVXPath, string pPath, string pLabel, string pValue)
        {
            PropertyXPath = pXPath;
            ValuesXPath = pVXPath;
            Path = pPath;
            Label = pLabel;
            Value = pValue;
        }
    }
}
