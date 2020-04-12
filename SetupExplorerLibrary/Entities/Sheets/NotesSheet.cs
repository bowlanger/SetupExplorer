using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.Sheets
{
    public class NotesSheet : Sheet
    {
        public string Notes { get; set; }

        public NotesSheet() : base("Notes")
        {
            Notes = "";
        }
    }
}
