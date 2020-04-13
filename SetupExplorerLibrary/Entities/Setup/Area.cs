using SetupExplorerLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.Setup
{

    public class Area
    {
        //public string Name;
        public EArea AreaId { get; set; }
        public string Name { get; set; }
        public List<Property> Properties { get; set; } = new List<Property>();

        public Area(EArea area, string name)
        {
            AreaId = area;
            Name = name;
        }
    }
}
