using SetupExplorerLibrary.Entities.Setup;
using SetupExplorerLibrary.Entities.Setup.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.Template
{
    public class Template
    {
        public string Name { get; set; }
        public List<Sheet> Sheets { get; set; }
        public NotesSheet Notes { get; set; }

        public Dictionary<string, string> Mapping = new Dictionary<string, string>();

        public Template()
        {
            Sheets = new List<Sheet>();
            Notes = new NotesSheet();

            Sheets.Add(Notes);
        }

        public string GetKeyByValue(string value)
        {
            var myKey = Mapping.FirstOrDefault(x => x.Value == value).Key;
            return myKey;
        }
    }
}
