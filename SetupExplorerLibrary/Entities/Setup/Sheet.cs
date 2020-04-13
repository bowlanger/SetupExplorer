using SetupExplorerLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.Setup
{
    public class Sheet
    {
        public string Title { get; set; }
        public List<Area> Areas = new List<Area>();

        public Area FrontLeft   { get; set; } = new Area(EArea.FrontLeft,   "FrontLeft");
        public Area Front       { get; set; } = new Area(EArea.Front,       "Front");
        public Area FrontRight  { get; set; } = new Area(EArea.FrontRight,  "FrontRight");

        public Area LeftFront   { get; set; } = new Area(EArea.LeftFront,   "LeftFront");
        public Area CenterFront { get; set; } = new Area(EArea.CenterFront, "CenterFront");
        public Area RightFront  { get; set; } = new Area(EArea.RightFront,  "RightFront");

        public Area Left        { get; set; } = new Area(EArea.Left,        "Left");
        public Area Center      { get; set; } = new Area(EArea.Center,      "Center");
        public Area Right       { get; set; } = new Area(EArea.Right,       "Right");

        public Area LeftRear    { get; set; } = new Area(EArea.LeftRear,    "LeftRear");
        public Area CenterRear  { get; set; } = new Area(EArea.CenterRear,  "CenterRear");
        public Area RightRear   { get; set; } = new Area(EArea.RightRear,   "RightRear");

        public Area RearLeft    { get; set; } = new Area(EArea.RearLeft,    "RearLeft");
        public Area Rear        { get; set; } = new Area(EArea.Rear,        "Rear");
        public Area RearRight   { get; set; } = new Area(EArea.RearRight,   "RearRight");

        public Sheet()
        {
            // explicit empty constructor in parent class to prevent necessity to chain declare constructors in children classes
            //
            // https://stackoverflow.com/questions/29959839/c-sharp-inheritance-and-default-constructors
            // https://stackoverflow.com/questions/30696006/inheritance-with-base-class-constructor-with-parameters

            //Title = "dummy";
        }
        public Sheet(string title)
        {
            Title = title;
        }
    }
}
