using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities
{
    public class TemplateProperty
    {
        private string sheet;
        private Area area;
        private string propertyXpath;
        private string propertyMatch;
        private string[] valuesXpath;
        private string valuesMatch;
        private string value;

        public TemplateProperty(string sheet, Area area, string propertyXpath, string propertyMatch, string[] valuesXpath, string valuesMatch)
        {
            this.sheet = sheet;
            this.area = area;
            this.propertyXpath = propertyXpath;
            this.propertyMatch = propertyMatch;
            this.valuesXpath = valuesXpath;
            this.valuesMatch = valuesMatch;
            this.value = "";
        }
    }
}
