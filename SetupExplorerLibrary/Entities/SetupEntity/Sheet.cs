using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.SetupEntity
{
    public class Sheet
    {
        public string Name { get; set; }
        public List<Node> Nodes { get; set; } = new List<Node>();

        public Sheet(string name)
        {
            Name = name;
        }
    }
}
