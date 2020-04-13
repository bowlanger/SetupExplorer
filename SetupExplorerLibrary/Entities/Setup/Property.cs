using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.Setup
{
    public class Property
    {
        public string PropertyLabel { get; set; }
        
        // internal string PropertyXPath
        public string PropertyXpath { get; set; }
        public string PropertyMatch = "";
        public string ValuesXpath { get; set; }
        //private ValueValidator valueValidator;

        public Property(string propertyXpath, string valuesXpath)
        {
            PropertyXpath = propertyXpath;
            ValuesXpath = valuesXpath;
        }
    }
}
