using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary
{
    public class Template
    {
        public string Name { get; set; }
        public List<Sheet> Sheets { get; set; }
        public NotesSheet Notes { get; set; }
        public TiresSheet Tires { get; set; }

        public Template()
        {
            Sheets = new List<Sheet>();
            Tires = new TiresSheet();
            Notes = new NotesSheet();

            Sheets.Add(Tires);
            Sheets.Add(Notes);
        }
    }
}
