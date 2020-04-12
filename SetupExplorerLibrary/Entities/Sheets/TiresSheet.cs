using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetupExplorerLibrary.Entities;

namespace SetupExplorerLibrary.Entities.Sheets
{
    public class TiresSheet : Sheet
    {
        public Tire LeftFrontTire;
        public Tire RightFrontTire;
        public Tire LeftRearTire;
        public Tire RightRearTire;

        public TiresSheet() : base("Tires") // this is how you explicitly call the parent constructor
        {

        }
    }
}
