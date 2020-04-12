using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetupExplorerLibrary.Entities;

namespace SetupExplorerLibrary.Entities.Setup.Sheets
{
    public class TiresSheet : Sheet
    {
        public Area LeftFront = new Area("Left Front", 1, 0);
        public Area LeftRear = new Area("Left Rear", 3, 0);
        public Area RightFront = new Area("Right Front", 1, 2);
        public Area RightRear = new Area("Right Rear", 3, 2);
        public TiresSheet() : base("Tires") // this is how you explicitly call the parent constructor
        {
            // register areas : is this useful ??
            Areas.Add(LeftFront);
            Areas.Add(LeftRear);
            Areas.Add(RightFront);
            Areas.Add(RightRear);
        }
    }
}
