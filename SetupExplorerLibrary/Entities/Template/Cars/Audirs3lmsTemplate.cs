using SetupExplorerLibrary.Entities.Setup;
using SetupExplorerLibrary.Entities.Setup.Properties;
using SetupExplorerLibrary.Entities.Setup.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.Template.Cars
{
    public class Audirs3lmsTemplate : Template
    {
        //public List<Property> Properties = new List<Property>();
        //public List<PropertyTemplate>
        //    LeftFrontTire,
        //    LeftRearTire,
        //    RightFrontTire,
        //    RightRearTire
        //    = new List<PropertyTemplate>();

        TiresSheet Tires = new TiresSheet();
        SetupSheet Chassis = new SetupSheet("Chassis");

        public List<Property> LeftFrontTire = new List<Property>();
        public List<Property> LeftRearTire = new List<Property>();
        public List<Property> RightFrontTire = new List<Property>();
        public List<Property> RightRearTire = new List<Property>();

        public List<Property> FrontChassis = new List<Property>();
        public List<Property> LeftFrontChassis = new List<Property>();
        public List<Property> LeftRearChassis = new List<Property>();
        public List<Property> RightFrontChassis = new List<Property>();
        public List<Property> RightRearChassis = new List<Property>();
        public List<Property> RearChassis = new List<Property>();




        public Audirs3lmsTemplate() : base()
        {
            // Tires sheet
            LeftFrontTire.Add(new StartingPressure("/html[1]/body[1]/text()[5]", "/html[1]/body[1]/u[1]"));
            LeftFrontTire.Add(new LastHotPressure("/html[1]/body[1]/text()[6]", "/html[1]/body[1]/u[2]"));
            //LeftFrontTire.Add(new LastTempsOMI("/html[1]/body[1]/text()[7]", "/html[1]/body[1]/(u[3]|u[4]|u[5])"));
            LeftFrontTire.Add(new LastTempsOMI("/html[1]/body[1]/text()[7]", "/html[1]/body[1]/u[3]|/html[1]/body[1]/u[4]|/html[1]/body[1]/u[5]"));
            LeftFrontTire.Add(new TreadRemainingOMI("/html[1]/body[1]/text()[8]", "/html[1]/body[1]/u[6]|/html[1]/body[1]/u[7]|/html[1]/body[1]/u[8]"));

            LeftRearTire.Add(new StartingPressure("/html[1]/body[1]/text()[10]", "/html[1]/body[1]/u[9]"));
            LeftRearTire.Add(new LastHotPressure("/html[1]/body[1]/text()[11]", "/html[1]/body[1]/u[10]"));
            LeftRearTire.Add(new LastTempsOMI("/html[1]/body[1]/text()[12]", "/html[1]/body[1]/u[11]|/html[1]/body[1]/u[12]|/html[1]/body[1]/u[13]"));
            LeftRearTire.Add(new TreadRemainingOMI("/html[1]/body[1]/text()[13]", "/html[1]/body[1]/u[14]|/html[1]/body[1]/u[15]|/html[1]/body[1]/u[16]"));

            RightFrontTire.Add(new StartingPressure("/html[1]/body[1]/text()[15]", "/html[1]/body[1]/u[17]"));
            RightFrontTire.Add(new LastHotPressure("/html[1]/body[1]/text()[16]", "/html[1]/body[1]/u[18]"));
            RightFrontTire.Add(new LastTempsIMO("/html[1]/body[1]/text()[17]", "/html[1]/body[1]/u[19]|/html[1]/body[1]/u[20]|/html[1]/body[1]/u[21]"));
            RightFrontTire.Add(new TreadRemainingIMO("/html[1]/body[1]/text()[18]", "/html[1]/body[1]/u[22]|/html[1]/body[1]/u[23]|/html[1]/body[1]/u[24]"));

            RightRearTire.Add(new StartingPressure("/html[1]/body[1]/text()[20]", "/html[1]/body[1]/u[20]"));
            RightRearTire.Add(new LastHotPressure("/html[1]/body[1]/text()[21]", "/html[1]/body[1]/u[26]"));
            RightRearTire.Add(new LastTempsIMO("/html[1]/body[1]/text()[22]", "/html[1]/body[1]/u[27]|//u[28]|//u[29]"));
            RightRearTire.Add(new TreadRemainingIMO("/html[1]/body[1]/text()[23]", "/html[1]/body[1]/u[30]|/html[1]/body[1]/u[31]|/html[1]/body[1]/u[32]"));

            Tires.LeftFront.Properties = LeftFrontTire;
            Tires.LeftRear.Properties = LeftRearTire;
            Tires.RightFront.Properties = RightFrontTire;
            Tires.RightRear.Properties = RightRearTire;

            // Chassis sheet
            //FrontChassis.Add(new NoseWeight("/html[1]/body[1]/#text[25]", "/html[1]/body[1]/u[33]"));
            //FrontChassis.Add(new CrossWeight("/html[1]/body[1]/#text[26]", "/html[1]/body[1]/u[34]"));
            //FrontChassis.Add(new ARBWallThickness("/html[1]/body[1]/#text[27]", "/html[1]/body[1]/u[35]"));
            //FrontChassis.Add(new ARBBladeLength("/html[1]/body[1]/#text[28]", "/html[1]/body[1]/u[36]"));
            //FrontChassis.Add(new ToeIn("/html[1]/body[1]/#text[29]", "/html[1]/body[1]/u[37]"));
            //FrontChassis.Add(new ABSSetting("/html[1]/body[1]/#text[30]", "/html[1]/body[1]/u[38]"));
            //FrontChassis.Add(new BrakePressureBias("/html[1]/body[1]/#text[31]", "/html[1]/body[1]/u[39]"));
            //FrontChassis.Add(new RearBrakeValve("/html[1]/body[1]/#text[32]", "/html[1]/body[1]/u[40]"));
            //FrontChassis.Add(new HandbrakeRatio("/html[1]/body[1]/#text[33]", "/html[1]/body[1]/u[41]"));
            //FrontChassis.Add(new LaunchRPMLimit("/html[1]/body[1]/#text[34]", "/html[1]/body[1]/u[42]"));
            //FrontChassis.Add(new DiffMap("/html[1]/body[1]/#text[35]", "/html[1]/body[1]/u[43]"));
            //FrontChassis.Add(new DashDisplayPage("/html[1]/body[1]/#text[36]", "/html[1]/body[1]/u[44]"));

            Chassis.Front.Properties = FrontChassis;
        }
    }
}
