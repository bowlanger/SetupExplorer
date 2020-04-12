using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.Setup.Properties
{
    public class StartingPressure : Property
    {
        public StartingPressure(string propertyXpath, string valuesXpath) : base(propertyXpath, valuesXpath)
        {
            PropertyMatch = "Starting pressure:";
            PropertyLabel = "Starting Pressure";
        }
    }
}
