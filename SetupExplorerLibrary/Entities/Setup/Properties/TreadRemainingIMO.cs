using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.Setup.Properties
{
    public class TreadRemainingIMO : Property
    {
        public TreadRemainingIMO(string propertyXpath, string valuesXpath) : base(propertyXpath, valuesXpath)
        {
            PropertyMatch = "Tread remaining:";
            PropertyLabel = "Tread Remaining I M O";
        }
    }
}
