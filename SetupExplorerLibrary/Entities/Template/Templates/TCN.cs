using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.Template.Templates
{
    public class TCN : Template
    {
        public TCN() : base()
        {
            Name = "TCN Template";
            Description = "Tires / Chassis / Notes";


            //https://stackoverflow.com/questions/689940/hashtable-with-multidimensional-key-in-c-sharp

            //Mapping["Summary"] = "1";

            Mapping["Tires:LeftFront"] = 2;
            Mapping["Tires:LeftRear"] = 3;
            Mapping["Tires:RightFront"] = 4;
            Mapping["Tires:RightRear"] = 5;

            Mapping["Chassis:Front"] = 6;
            Mapping["Chassis:LeftFront"] = 7;
            Mapping["Chassis:LeftRear"] = 8;
            Mapping["Chassis:RightFront"] = 9;
            Mapping["Chassis:RightRear"] = 10;
            Mapping["Chassis:Rear"] = 11;

            //Mapping["Notes"] = "12";

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
