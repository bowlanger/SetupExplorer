using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities
{
    public class Area
    {
        public string Name;
        public int CoordX;
        public int CoordY;

        public Area()
        {

        }
        public Area(string name)
        {
            Name = name;
        }
    }
}
