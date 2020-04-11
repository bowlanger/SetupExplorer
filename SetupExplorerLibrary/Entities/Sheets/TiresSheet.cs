using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary
{
    public class TiresSheet : Sheet
    {
        public List<Area> Tires = new List<Area>();

        public TiresSheet() : base("Tires") // this is how you explicitly call the parent constructor
        {
            Tires.Add(new Area("LeftFront"));
            Tires.Add(new Area("RightFront"));
            Tires.Add(new Area("LeftRear"));
            Tires.Add(new Area("RightRear"));
        }
    }
}
