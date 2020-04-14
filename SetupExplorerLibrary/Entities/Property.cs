using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerApp.Entities
{
    public class Property
    {
        public string Mapping { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
        
        // internal string PropertyXPath
        public string PropertyXpath { get; set; }
        public string ValuesXpath { get; set; }
    }
}
