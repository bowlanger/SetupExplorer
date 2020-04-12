using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.Setup.Properties
{
    public class LastTempsIMO : Property
    {
        public LastTempsIMO(string propertyXpath, string valuesXpath) : base(propertyXpath, valuesXpath)
        {
            PropertyMatch = "Last temps I M O:";
            PropertyLabel = "Last Temps I M O";
        }
    }
}
