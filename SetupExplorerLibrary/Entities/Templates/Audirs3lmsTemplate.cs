using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary
{
    public class Audirs3lmsTemplate : Template
    {
        public List<Property> Properties = new List<Property>();
        public Audirs3lmsTemplate()
        {
            //Properties.Add(new Property())
            //List<Sheet> sheets = new List<Sheet>();
            //sheets.Add(new TiresSheet());
            Sheets.Add(new SetupSheet("Chassis"));
            //sheets.Add(new NotesSheet());

            string[] sheets = new string[3] { "Tires", "Chassis", "Notes" };
            int[] tiresXpathId = new int[4] { 2, 3, 4, 5 };
            int[] chassisXpathId = new int[6] { 6, 7, 8, 9, 10, 11 };

        }
    }
}
