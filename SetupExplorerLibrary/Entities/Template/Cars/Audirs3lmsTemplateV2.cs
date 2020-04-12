using SetupExplorerLibrary.Entities.Setup;
using SetupExplorerLibrary.Entities.Setup.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.Template.Cars
{
    public class Audirs3lmsTemplateV2 : Template
    {
        public Dictionary<string, Dictionary<string, int>> Areas = new Dictionary<string, Dictionary<string, int>>();
        public Dictionary<Sheet, Dictionary<Area, int>> SetupTemplate = new Dictionary<Sheet, Dictionary<Area, int>>();
        

        public Audirs3lmsTemplateV2() : base()
        {

            //https://stackoverflow.com/questions/689940/hashtable-with-multidimensional-key-in-c-sharp
            Areas["Tires"] = new Dictionary<string, int>();
            Areas["Tires"]["Left Front"] = 2;
            Areas["Tires"]["Left Rear"] = 3;
            Areas["Tires"]["Right Front"] = 4;
            Areas["Tires"]["Right Rear"] = 5;

            Mapping["2"] = "Tires:Left Front";
            Mapping["3"] = "Tires:Left Rear";
            Mapping["4"] = "Tires:Right Front";
            Mapping["5"] = "Tires:Right Rear";

            Mapping["6"] = "Chassis:Front";
            Mapping["7"] = "Chassis:Left Front";
            Mapping["8"] = "Chassis:Left Rear";
            Mapping["9"] = "Chassis:Right Front";
            Mapping["10"] = "Chassis:Right Rear";
            Mapping["11"] = "Chassis:Rear";
            
            //Template.Add("Tires", new Dictionary<string, int>());
            //Template["Tires"].Add("Left Front", 2);
            //Template["Tires"].Add("Left Rear", 3);
            //Template["Tires"].Add("Right Front", 4);
            //Template["Tires"].Add("Right Rear", 5);

            //Template.Add("Chassis", new Dictionary<string, int>());
            //Template["Chassis"].Add(6, "Front");
            //Template["Chassis"].Add(7, "Left Front");
            //Template["Chassis"].Add(8, "Left Rear");
            //Template["Chassis"].Add(9, "Right Front");
            //Template["Chassis"].Add(10, "Right Rear");
            //Template["Chassis"].Add(11, "Rear");


            //public Dictionary<string, 
            //                Dictionary<string, 
            //                        Dictionary<string, 
            //                                List<ResidentRecord>>>> PeopleCollection 
            //= new Dictionary<string, 
            //                Dictionary<string, 
            //                        Dictionary<string, 
            //                                List<ResidentRecord>>>>();


            //var domains = new Dictionary<string, string>();

            //domains.Add("de", "Germany");
            //domains.Add("sk", "Slovakia");
            //domains.Add("us", "United States");
            //domains.Add("ru", "Russia");
            //domains.Add("hu", "Hungary");
            //domains.Add("pl", "Poland");

            //Console.WriteLine(domains["sk"]);
            //Console.WriteLine(domains["de"]);

            //Console.WriteLine("Dictionary has {0} items",
            //    domains.Count);
        }
    }
}
