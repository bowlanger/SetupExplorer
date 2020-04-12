using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.Setup.Sheets
{
    public class SetupSheet : Sheet
    {
        public Area FrontLeft = new Area("Front Left", 0, 0);
        public Area Front = new Area("Front", 0, 1);
        public Area FrontRight = new Area("Front Right", 0, 2);

        public Area LeftFront = new Area("Left Front", 1, 0);
        public Area CenterFront = new Area("Center Front", 1, 1);
        public Area RightFront = new Area("Right Front", 1, 2);

        public Area Left = new Area("Left", 2, 0);
        public Area Center = new Area("Center", 2, 1);
        public Area Right = new Area("Right", 2, 2);

        public Area LeftRear = new Area("Left Rear", 3, 0);
        public Area CenterRear = new Area("Center Rear", 3, 1);
        public Area RightRear = new Area("Right Rear", 3, 2);

        public Area RearLeft = new Area("Rear Left", 4, 0);
        public Area Rear = new Area("Rear", 4, 1);
        public Area RearRight = new Area("Rear Right", 4, 2);

        public SetupSheet(string title) : base(title)
        {

        }
    }
}
