using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.Setup
{
    public class Area
    {
        public string Name;
        public int Row, Col;

        public List<Property> Properties = new List<Property>();

        public Area(string name, int row, int col)
        {
            Name = name;
            Row = row;
            Col = col;
        }
    }
}
