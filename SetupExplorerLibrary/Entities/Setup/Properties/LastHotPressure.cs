using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.Setup.Properties
{
    public class LastHotPressure : Property
    {
        public LastHotPressure(string propertyXpath, string valuesXpath) : base(propertyXpath, valuesXpath)
        {
            PropertyMatch = "Last hot pressure:";
            PropertyLabel = "Last Hot Pressure";
        }
    }
}
