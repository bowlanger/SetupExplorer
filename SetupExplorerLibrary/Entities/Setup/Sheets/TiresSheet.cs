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
        public TiresSheet() : base("Tires") // this is how you explicitly call the parent constructor
        {
            Areas.Add(LeftFront);
            Areas.Add(LeftRear);
            Areas.Add(RightFront);
            Areas.Add(RightRear);
        }
    }
}
